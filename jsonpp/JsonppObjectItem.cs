namespace jsonpp
{
    internal abstract class JsonppObjectItem
    {
        public JsonppObjectItem(JsonppItem item)
        {
            Item = item;
        }

        public abstract NameReference Name { get; }

        public JsonppItem Item { get; }
    }
}