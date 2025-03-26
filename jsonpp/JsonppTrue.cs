namespace jsonpp
{
    internal class JsonppTrue : JsonppItem
    {
        public JsonppTrue(Match loc_1_0, JsonppParserBase jsonppParser)
        {
        }

        public JsonppTrue() 
        {
        }

        public override DuckTyping Type => DuckTyping.Bool;

        public override AstNodeType NodeType => AstNodeType.True;
    }
}