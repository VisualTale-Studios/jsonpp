using System;
using System.Collections.Generic;

namespace jsonpp
{
    internal class JsonppArray : JsonppCollection
    {
        private List<JsonppItem> items;

        public JsonppArray() { items = new List<JsonppItem>(); }

        public JsonppArray(JsonppItem item) : this() { items.Add(item); }

        public JsonppArray Add(JsonppItem item) { items.Add(item); return this; }

        public override DuckTyping Type => DuckTyping.Array;

        public override AstNodeType NodeType => AstNodeType.Array;

        public List<JsonppItem> Items => items;

        internal override void AddItem(JsonppItem item)
        {
            if (item == null)
                item = new JsonppNull();

            items.Add(item);
        }

        internal override void Field(NameReference refer)
        {
            throw new Exception("Array不允许使用Field");
        }

        internal override DuckTyping GetFields()
        {
            throw new Exception("Array不允许使用GetFields");
        }
    }
}