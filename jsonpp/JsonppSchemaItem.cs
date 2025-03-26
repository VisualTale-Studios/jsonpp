namespace jsonpp
{
    internal abstract class JsonppSchemaItem
    {
        public JsonppSchemaItem(DuckTyping type) { Type = type; }

        public DuckTyping Type { get; }

        public abstract string Name { get; }
    }
}