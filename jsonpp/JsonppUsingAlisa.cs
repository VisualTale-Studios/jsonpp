namespace jsonpp
{
    internal class JsonppUsingAlisa : JsonppSchemaItem
    {
        public unsafe JsonppUsingAlisa(DuckTyping type, Match loc_1_0, char* mInput, JsonppParserBase jsonppParser)
            : base(type)
        {
            Alisa = loc_1_0.GetContent(mInput);
            Name = jsonppParser.GetAlisaLiteral(Alisa, loc_1_0.SourceSpan);
        }

        public JsonppUsingAlisa(DuckTyping type, string alisa, string name)
            : base(type)
        {
            Alisa = alisa;
            Name = name;
        }


        public string Alisa { get; }

        public override string Name { get; }
    }
}