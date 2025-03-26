namespace jsonpp
{
    static class JsonppPlaintextReader
    {
        public static void Read(string v, IJsonppReader reader, bool report) 
        {
            using var visitor = new JsonppVisitor(reader);

            var parser = report ? 
                new JsonppReportParser(reader) : 
                new JsonppParser(reader) as JsonppParserBase;

            visitor.Visit(parser.Parse(v));
            parser.Dispose();
        }
    }
}
