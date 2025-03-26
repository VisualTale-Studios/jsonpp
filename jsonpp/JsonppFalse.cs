namespace jsonpp
{
    internal class JsonppFalse : JsonppItem
    {
        public JsonppFalse(Match loc_1_0, JsonppParserBase jsonppParser)
        {
        }

        public JsonppFalse() 
        {
        }

        public override DuckTyping Type => DuckTyping.Bool;

        public override AstNodeType NodeType => AstNodeType.False;
    }
}