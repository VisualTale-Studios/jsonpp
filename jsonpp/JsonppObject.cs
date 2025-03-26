using System;
using System.Collections.Generic;

namespace jsonpp
{
    internal class JsonppObject : JsonppCollection
    {
        private DuckTyping type;
        private List<JsonppObjectItem> items;

        public JsonppObject() { items = new List<JsonppObjectItem>(); }

        public JsonppObject(JsonppObjectItem item) : this() { items.Add(item); }

        public override DuckTyping Type => type;

        public override AstNodeType NodeType => AstNodeType.Object;

        public List<JsonppObjectItem> Items => items;

        public JsonppObject Add(JsonppObjectItem item) { items.Add(item); return this; }

        public void Finish(JsonppParserBase parser) { type = parser.GetDuckTypeing(GetFields(), default); }

        public void Finish(DuckTyping type) => this.type = type;

        private NameReference currRefer;

        internal override void AddItem(JsonppItem item)
        {
            if (currRefer == null)
                throw new Exception("需要先使用Field");

            if (item == null)
                item = new JsonppNull();

            items.Add(new JsonppObjectFieldItem(currRefer, item));
            currRefer = null;
        }

        internal override void Field(NameReference refer)
        {
            if (currRefer != null)
                throw new Exception("当前还有未处理完的field");

            if(refer == null)
                throw new Exception("不可使用空field");

            currRefer = refer;
        }

        internal override DuckTyping GetFields()
        {
            var input = new DuckTyping("temp");
            foreach (var item in items)
                input[item.Name.Literal] = item.Item.Type;

            return input;
        }
    }
}