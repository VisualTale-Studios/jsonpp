namespace jsonpp
{
    internal class JsonppDefineAlisa : JsonppExt
    {
        public unsafe JsonppDefineAlisa(Match loc_1_0, Match match, char* mInput, JsonppParserBase jsonppParser)
        {
            Alisa = loc_1_0.GetContent(mInput);
            Literal = match.GetContent(mInput);
            jsonppParser.DefineAlisa(Alisa, Literal, loc_1_0.SourceSpan);
        }

        public JsonppDefineAlisa(string alisa, string literal) 
        {
            Alisa = alisa;
            Literal = literal;
        }

        public override AstNodeType NodeType => AstNodeType.DefineAlisa;

        public override DuckTyping Type => DuckTyping.String;

        public string Alisa { get; }

        public string Literal { get; }
    }
}