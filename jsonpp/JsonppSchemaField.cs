namespace jsonpp
{
    internal class JsonppSchemaField : JsonppSchemaItem
    {
        public unsafe JsonppSchemaField(DuckTyping type, Match loc_1_0, char* mInput, JsonppParserBase jsonppParser)
            : base(type)
        {
            Name = new Match(0, loc_1_0.SourceSpan.Start + 1, loc_1_0.SourceSpan.End - 1).GetContent(mInput);
        }

        public JsonppSchemaField(DuckTyping type, string name)
            : base(type)
        {
            Name = name;
        }

        public override string Name { get; }
    }
}