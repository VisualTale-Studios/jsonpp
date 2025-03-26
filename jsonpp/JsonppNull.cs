namespace jsonpp
{
    internal class JsonppNull : JsonppItem
    {
        public JsonppNull(Match loc_1_0, JsonppParserBase jsonppParser)
        {
        }

        public JsonppNull() { }

        public override AstNodeType NodeType => AstNodeType.Null;

        public override DuckTyping Type => DuckTyping.Null;
    }
}