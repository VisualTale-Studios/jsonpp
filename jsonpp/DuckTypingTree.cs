using System;
using System.Collections.Generic;

namespace jsonpp
{
    class DuckTypingTree : IDisposable
    {
        public DuckTyping SourceType { get; set; }

        public DuckTypingTree Parent { get; }

        public TwoKeyDictionary<string, DuckTyping, DuckTypingTree> Childrens { get; }

        public DuckTypingTree(DuckTypingTree parent)
        {
            Parent = parent;
            Childrens = new TwoKeyDictionary<string, DuckTyping, DuckTypingTree>();
        }

        public IEnumerable<DuckTyping> GetTypes()
        {
            if (SourceType != null)
                yield return SourceType;

            foreach (var item in Childrens.GetEnumerator3())
                foreach (var type in item.Value.GetTypes())
                    yield return type;
        }

        public void Dispose()
        {
            Childrens?.Dispose();
        }
    }
}
