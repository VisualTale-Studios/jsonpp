namespace jsonpp
{
    partial class JsonppParser : JsonppParserBase
    {
        public JsonppParser(IJsonppReader reader)
            : base(reader)
        {
        }

        protected override int Index { get => mIndex; set => mIndex = value; }

        protected override unsafe char* Input { get => mInput; set => mInput = value; }

        protected override int Length => mLength;

        protected override unsafe Jsonpp DoParse(char* input, int length)
        {
            return parse(input, length);
        }

        protected override int GetMatchTokenTag(ushort token)
        {
            return GetMatchTag(token);
        }
    }
}
