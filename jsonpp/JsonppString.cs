namespace jsonpp
{
    internal class JsonppString : JsonppItem
    {
        public unsafe JsonppString(Match match, char* mInput, JsonppParserBase jsonppParser)
        {
            Value = new Match(0, match.SourceSpan.Start + 1, match.SourceSpan.End - 1).GetContent(mInput);
        }

        public JsonppString(string text) 
        {
            Value = text;
        }

        public override DuckTyping Type => DuckTyping.String;

        public string Value { get; }

        public override AstNodeType NodeType => AstNodeType.String;
    }
}