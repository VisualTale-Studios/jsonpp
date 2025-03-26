using System.Collections.Generic;

namespace jsonpp
{
    internal class JsonppExts
    {
        private List<JsonppExt> items;

        public JsonppExts() { items = new List<JsonppExt>(); }

        public JsonppExts(JsonppExt item) : this() { items.Add(item); }

        public JsonppExts Add(JsonppExt item) { items.Add(item); return this; }

        public List<JsonppExt> Items => items;
    }
}