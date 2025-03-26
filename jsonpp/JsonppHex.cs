using System.Text.RegularExpressions;

namespace jsonpp
{
    internal class JsonppHex : JsonppItem
    {
        static Regex regex = new Regex("^(0x|0X)?[a-fA-F0-9]+$", RegexOptions.Compiled);

        public unsafe JsonppHex(Match loc_1_0, char* mInput, JsonppParserBase jsonppParser)
        {
            var ctx = loc_1_0.GetContent(mInput);
            Value = float.Parse(ctx.Substring(2), System.Globalization.NumberStyles.HexNumber);
            jsonppParser.Colour(loc_1_0.SourceSpan, JsonppParserBase.NumberColor);
            //builder.Module.AutoComplete(new SourceSpan(loc_1_0.Start, loc_1_0.End), AutoCompleteType.SpecialType, analysis.Type.Number);

            if (!regex.IsMatch(ctx))
                jsonppParser.ReportError(loc_1_0.SourceSpan, jsonppParser.GetMessage("无效的十六进制转义序列"));
        }

        public override AstNodeType NodeType => AstNodeType.Hex;

        public override DuckTyping Type => DuckTyping.Number;

        public float Value { get; }
    }
}