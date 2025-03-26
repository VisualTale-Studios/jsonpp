namespace jsonpp
{
    internal class JsonppSchema : JsonppExt
    {
        public unsafe JsonppSchema(Match loc_6_0, JsonppSchemaItems loc_7_0, char* mInput, JsonppParserBase jsonppParser)
        {
            var input = new DuckTyping(loc_6_0.GetContent(mInput));
            foreach (var item in loc_7_0.Items)
                input[item.Name] = item.Type;

            Type = jsonppParser.GetDuckTypeing(input, loc_6_0.SourceSpan);
        }

        public JsonppSchema(DuckTyping type) 
        {
            Type = type;
        }

        public override AstNodeType NodeType => AstNodeType.Schema;

        public override DuckTyping Type { get; }
    }
}