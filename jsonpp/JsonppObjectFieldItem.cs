namespace jsonpp
{
    internal class JsonppObjectFieldItem : JsonppObjectItem
    {
        public unsafe JsonppObjectFieldItem(Match match, JsonppItem loc_11_0, char* mInput, JsonppParserBase jsonppParser)
            : base(loc_11_0)
        {
            Name = new NameReference() { Literal = match.GetContent(mInput) };
        }

        public JsonppObjectFieldItem(NameReference name, JsonppItem loc_11_0)
            : base(loc_11_0)
        {
            Name = name;
        }

        public override NameReference Name { get; }
    }
}