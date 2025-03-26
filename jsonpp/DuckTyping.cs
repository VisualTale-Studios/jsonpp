using System.Collections.Generic;

namespace jsonpp
{
    class DuckTyping : Dictionary<string, DuckTyping>
    {
        public readonly static DuckTyping Number = new DuckTyping("number");
        public readonly static DuckTyping String = new DuckTyping("string");
        public readonly static DuckTyping Bool = new DuckTyping("bool");
        public readonly static DuckTyping Null = new DuckTyping("null");
        public readonly static DuckTyping Array = new DuckTyping("array");

        public DuckTyping(string name) { Name = name; }

        public string Name { get; }
    }
}
