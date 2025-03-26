namespace jsonpp
{
    internal abstract class JsonppItem
    {
        public abstract AstNodeType NodeType { get; }

        public abstract DuckTyping Type { get; }
    }
}