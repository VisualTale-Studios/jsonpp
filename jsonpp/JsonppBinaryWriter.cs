using System;
using System.Collections.Generic;
using System.IO;

namespace jsonpp
{
    class JsonppBinaryWriter : AstNodeVisitor
    {
        private BinaryWriter bw;
        private BinaryWriter bw2;
        private Dictionary<string, string> alisas;
        private Dictionary<string, ushort> strings;
        private HashSet<DuckTyping> schemas;

        public JsonppBinaryWriter(BinaryWriter bw)
        {
            this.alisas = new Dictionary<string, string>();
            this.strings = new Dictionary<string, ushort>();
            this.schemas = new HashSet<DuckTyping>();
            this.bw2 = bw;

            var memory = new MemoryStream();
            this.bw = new BinaryWriter(memory);
        }

        public Stream ToStream() 
        {
            bw.Flush();

            bw2.Write((ushort)strings.Count);
            foreach (var str in strings)
                bw2.Write(str.Key);

            bw.BaseStream.Position = 0;
            bw.BaseStream.CopyTo(bw2.BaseStream);
            bw2.Flush();
            return bw2.BaseStream;
        }

        protected override void VisitDefineAlisa(JsonppDefineAlisa? jsonppDefineAlisa)
        {
            this.alisas[jsonppDefineAlisa.Literal] = jsonppDefineAlisa.Alisa;

            bw.Write((byte)0); // 标记为define alisa
            bw.Write(GetStringIndex(jsonppDefineAlisa.Alisa));
            bw.Write(GetStringIndex(jsonppDefineAlisa.Literal));
        }

        protected override void VisitSchema(JsonppSchema? jsonppSchema)
        {
            this.schemas.Add(jsonppSchema.Type);

            bw.Write((byte)1); // 标记为schema
            bw.Write(GetTypeIndex(jsonppSchema.Type.Name));
            bw.Write((ushort)jsonppSchema.Type.Count);
            foreach (var field in jsonppSchema.Type)
            {
                bw.Write(GetTypeIndex(field.Value.Name)); // 写入类型名
                bw.Write(GetStringIndex(alisas.ContainsKey(field.Key) ? alisas[field.Key] : field.Key));
            }
        }

        protected override void VisitFalse(JsonppFalse? jsonppFalse)
        {
            bw.Write(false);
        }

        protected override void VisitHex(JsonppHex? jsonppHex)
        {
            bw.Write(jsonppHex.Value);
        }

        protected override void VisitJsonpp(Jsonpp? jsonpp)
        {
            bw.Write((ushort)jsonpp.Exts.Items.Count);
            for (var i = 0; i < jsonpp.Exts.Items.Count; i++)
                Visit(jsonpp.Exts.Items[i]);

            // 存入当前类型schema
            bw.Write(GetTypeIndex(jsonpp.Item.Type.Name));

            // 写入物体
            Visit(jsonpp.Item);
        }

        protected override void VisitNull(JsonppNull? jsonppNull)
        {
        }

        protected override void VisitNumber(JsonppNumber? jsonppNumber)
        {
            bw.Write(jsonppNumber.Value);
        }

        protected override void VisitArray(JsonppArray? jsonppArray)
        {
            bw.Write((ushort)jsonppArray.Items.Count);
            for (var i = 0; i < jsonppArray.Items.Count; i++)
            {
                var item = jsonppArray.Items[i];
                bw.Write(GetTypeIndex(item.Type.Name));
                Visit(item);
            }
        }

        protected override void VisitObject(JsonppObject? jsonppObject)
        {
            if (schemas.Contains(jsonppObject.Type))
            {
                bw.Write(true);
                bw.Write(GetTypeIndex(jsonppObject.Type.Name));
                for (var i = 0; i < jsonppObject.Items.Count; i++)
                    Visit(jsonppObject.Items[i].Item);
            }
            else
            {
                bw.Write(false);
                bw.Write((ushort)jsonppObject.Items.Count);
                for (var i = 0; i < jsonppObject.Items.Count; i++)
                {
                    var item = jsonppObject.Items[i];
                    bw.Write(GetStringIndex(alisas.ContainsKey(item.Name.Literal) ? alisas[item.Name.Literal] : item.Name.Literal));
                    bw.Write(GetTypeIndex(item.Item.Type.Name));
                    Visit(item.Item);
                }
            }
        }

        protected override void VisitScientific(JsonppScientific? jsonppScientific)
        {
            bw.Write(jsonppScientific.Value);
        }

        protected override void VisitString(JsonppString? jsonppString)
        {
            bw.Write(jsonppString.Value);
        }

        protected override void VisitTrue(JsonppTrue? jsonppTrue)
        {
            bw.Write(true);
        }

        protected override void VisitUnicode(JsonppUnicode? jsonppUnicode)
        {
            bw.Write(jsonppUnicode.Value);
        }

        private ushort GetStringIndex(string str) 
        {
            if (!this.strings.ContainsKey(str))
                this.strings[str] = (ushort)this.strings.Count;

            return this.strings[str];
        }

        private ushort GetTypeIndex(string name) 
        {
            return GetStringIndex(name);
        }

        protected override void VisitSchemaObject(JsonppSchemaObject? jsonppSchemaObject)
        {
            throw new Exception("写入器不应存在Schema Object");
        }
    }
}
