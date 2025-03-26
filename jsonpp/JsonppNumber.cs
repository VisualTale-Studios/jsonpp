namespace jsonpp
{
    internal class JsonppNumber : JsonppItem
    {
        private float value;

        public unsafe JsonppNumber(Match loc_1_0, char* mInput, JsonppParserBase jsonppParser)
        {
            jsonppParser.Colour(loc_1_0.SourceSpan, JsonppParserBase.NumberColor);
            if (!float.TryParse(loc_1_0.GetContent(mInput), out value))
                jsonppParser.ReportError(loc_1_0.SourceSpan, jsonppParser.GetMessage("无效的数字，可能超出float32长度。"));
        }

        public JsonppNumber(float value) 
        {
            this.value = value;
        }

        public override AstNodeType NodeType => AstNodeType.Number;

        public override DuckTyping Type => DuckTyping.Number;

        public float Value => value;
    }
}