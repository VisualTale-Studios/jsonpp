namespace jsonpp
{
    internal class JsonppUnicode : JsonppItem
    {
        public unsafe JsonppUnicode(Match loc_1_0, char* mInput, JsonppParserBase jsonppParser)
        {
            var ctx = loc_1_0.GetContent(mInput);
         
            jsonppParser.Colour(loc_1_0.SourceSpan, JsonppParserBase.NumberColor);
            if (ctx.Length != 6)
            {
                jsonppParser.ReportError(loc_1_0.SourceSpan, jsonppParser.GetMessage("无效的 Unicode 转义序列"));
            }
            else
            {
                var ch = ctx[0];
                var code = 0;
                var result = true;

                if (ch != '\\')
                {
                    result = false;
                }

                else if (ctx.Length > 1 && ctx[1] != 'u')
                {
                    result = false;
                }
                else
                {
                    for (var i = 2; i < ctx.Length; i++)
                    {
                        ch = ctx[i];
                        code = code * 16 + JsonppReportParser.FromChar(ch);
                        if (code > JsonppReportParser.UnicodeLastCodePoint)
                        {
                            result = false;
                        }
                    }
                }

                if (!result)
                {
                    if (code > JsonppReportParser.UnicodeLastCodePoint)
                    {
                        jsonppParser.ReportError(loc_1_0.SourceSpan, jsonppParser.GetMessage("未定义的 Unicode 码点"));
                    }
                    else
                    {
                        jsonppParser.ReportError(loc_1_0.SourceSpan, jsonppParser.GetMessage("无效的 Unicode 转义序列"));
                    }
                }
                else
                {
                    Value = code;
                }
            }
        }

        public override DuckTyping Type => DuckTyping.Number;

        public float Value { get; }

        public override AstNodeType NodeType => AstNodeType.Unicode;
    }
}