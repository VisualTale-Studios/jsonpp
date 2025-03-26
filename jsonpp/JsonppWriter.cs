using System;
using System.Collections.Generic;
using System.IO;

namespace jsonpp
{
    class JsonppWriter : IJsonppWriter
    {
        private int anonymousIndex = 0;
        private JsonppConfig config;
        private DuckTypingPool typePool;
        private List<JsonppSchema> schemas;
        private Dictionary<string, NameReference> alisas;
        private LevelCollection<JsonppCollection> collections;

        private JsonppItem item;

        public JsonppWriter(JsonppConfig config)
        {
            this.config = config;
            this.typePool = new DuckTypingPool();
            this.schemas = new List<JsonppSchema>();
            this.alisas = new Dictionary<string, NameReference>();
            this.collections = new LevelCollection<JsonppCollection>();
        }

        public void Clear() 
        {
            typePool = new DuckTypingPool();
            schemas.Clear();
            alisas.Clear();
            collections = new LevelCollection<JsonppCollection>();

            item = null;
        }

        public void Write(string value) 
        {
            if (this.collections.Current == null && this.item != null)
                throw new Exception("无法写入更多元素");

            var item = value != null ? new JsonppString(value) : null;
            if (this.collections.Current != null)
                this.collections.Current.AddItem(item);
            else
                this.item = item;
        }

        public void Write(float value) 
        {
            if (this.collections.Current == null && this.item != null)
                throw new Exception("无法写入更多元素");

            var item = new JsonppNumber(value);
            if (this.collections.Current != null)
                this.collections.Current.AddItem(item);
            else
                this.item = item;
        }

        public void Write(bool value) 
        {
            if (this.collections.Current == null && this.item != null)
                throw new Exception("无法写入更多元素");

            var item = value ? new JsonppTrue() : new JsonppFalse() as JsonppItem;
            if (this.collections.Current != null)
                this.collections.Current.AddItem(item);
            else
                this.item = item;
        }

        public void BeginObject() 
        {
            if (this.collections.Current == null && this.item != null)
                throw new Exception("无法写入更多元素");

            var item = new JsonppObject();
            if (this.collections.Current != null)
                this.collections.Current.AddItem(item);
            else
                this.item = item;

            this.collections.Push(item);
        }

        public void Field(string fieldName) 
        {
            if (this.collections.Current == null)
                throw new Exception("当前未开始任意集合");

            if (!alisas.ContainsKey(fieldName))
            {
                var refer = new NameReference(DuckTypingPool.GetColumnName(anonymousIndex++), fieldName);
                refer.Times = 1;
                alisas[fieldName] = refer;
            }
            else
            {
                alisas[fieldName].Times++;
            }

            this.collections.Current.Field(alisas[fieldName]);
        }

        public void EndObject() 
        {
            var item = this.collections.Pop();
            if (item is not JsonppObject)
                throw new Exception("接口调用失败，弹出值不是一个Object");

            // 计算鸭子类型
            var type = this.typePool.GetType(item.GetFields(), out var isNew);
            if (isNew)
                schemas.Add(new JsonppSchema(type));

            // 标记鸭子类型
            (item as JsonppObject).Finish(type);
        }

        public void BeginArray() 
        {
            if (this.collections.Current == null && this.item != null)
                throw new Exception("无法写入更多元素");

            var item = new JsonppArray();
            if (this.collections.Current != null)
                this.collections.Current.AddItem(item);
            else
                this.item = item;

            this.collections.Push(item);
        }

        public void EndArray() 
        {
            var item = this.collections.Pop();
            if (item is not JsonppArray)
                throw new Exception("接口调用失败，弹出值不是一个Array");
        }

        public Stream ToBinary()
        {
            Stream memory = new MemoryStream();
            var bw = new BinaryWriter(memory);
            bw.Write('j');
            bw.Write('s');
            bw.Write('o');
            bw.Write('n');
            bw.Write('p');
            bw.Write('p');

            if (item == null)
            {
                memory.Position = 0;
                return memory;
            }

            var json = new Jsonpp(GetExts(), item);
            var c = new JsonppBinaryWriter(bw);
            c.Visit(json);
            memory = c.ToStream();
            memory.Position = 0;
            return memory;
        }

        public string ToJson(bool format)
        {
            if (item == null)
                return string.Empty;

            var json = new Jsonpp(GetExts(), item);
            var c = new JsonppPlaintextWriter(format);
            c.Visit(json);
            return c.Json;
        }

        private JsonppExts GetExts() 
        {
            var exts = new JsonppExts();
            if (config.AutoAlisa)
                foreach (var alisa in alisas)
                    if (alisa.Value.Times > 1)
                        exts.Add(new JsonppDefineAlisa(alisa.Value.Alisa, alisa.Value.Literal));

            if (config.AutoSchema)
                exts.Items.AddRange(schemas);

            return exts;
        }
    }
}
