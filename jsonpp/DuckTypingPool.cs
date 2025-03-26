using System;
using System.Linq;

namespace jsonpp
{
    class DuckTypingPool : IDisposable
    {
        private int anonymousIndex = 0;
        private DuckTypingTree duckTypingTree = new DuckTypingTree(null);

        internal DuckTyping GetType(DuckTyping inputType, out bool createNew)
        {
            return GetTree(inputType, out createNew).SourceType;
        }

        private DuckTypingTree GetTree(DuckTyping inputType, out bool createNew)
        {
            createNew = false;
            var tree = duckTypingTree;
            var order = inputType.OrderBy(x => x.Key).ToArray();
            for (var i = 0; i < order.Length; i++)
            {
                var member = order[i];
                var child = tree.Childrens.ContainsKey(member.Key, member.Value) ? tree.Childrens[member.Key, member.Value] : null;
                if (child == null)
                    tree.Childrens.Add(member.Key, member.Value, tree = new DuckTypingTree(tree));
                else
                    tree = child;
            }

            if (tree.SourceType == null)
            {
                createNew = true;
                tree.SourceType = new DuckTyping("s_" + GetColumnName(++anonymousIndex));

                foreach (var field in order)
                    tree.SourceType[field.Key] = field.Value;
            }

            return tree;
        }

        internal static string GetColumnName(int index)
        {
            const string letters = "abcdefghijklmnopqrstuvwsyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }

        public void Dispose()
        {
            duckTypingTree.Dispose();
            duckTypingTree = null;
        }
    }
}
