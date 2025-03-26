using System.Collections.Generic;

namespace jsonpp
{
    internal class JsonppSchemaItems
    {
        private List<JsonppSchemaItem> items;

        public JsonppSchemaItems() { items = new List<JsonppSchemaItem>(); }

        public JsonppSchemaItems(JsonppSchemaItem item) : this() { items.Add(item); }

        public JsonppSchemaItems Add(JsonppSchemaItem item) { items.Add(item); return this; }

        internal List<JsonppSchemaItem> Items => items;
    }
}