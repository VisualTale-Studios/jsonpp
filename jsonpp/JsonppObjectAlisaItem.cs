namespace jsonpp
{
    internal class JsonppObjectAlisaItem : JsonppObjectItem
    {
        public unsafe JsonppObjectAlisaItem(Match loc_1_0, JsonppItem loc_11_0, char* mInput, JsonppParserBase jsonppParser)
            : base(loc_11_0)
        {
            var alisa = loc_1_0.GetContent(mInput);
            Name = new NameReference(alisa, jsonppParser.GetAlisaLiteral(alisa, loc_1_0.SourceSpan));
        }

        public override NameReference Name { get; }
    }
}