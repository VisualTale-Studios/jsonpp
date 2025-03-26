namespace jsonpp
{
    abstract class JsonppCollection : JsonppItem
    {
        internal abstract void AddItem(JsonppItem item);

        internal abstract void Field(NameReference refer);

        internal abstract DuckTyping GetFields();
    }
}
