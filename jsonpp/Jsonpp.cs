namespace jsonpp
{
    internal class Jsonpp : JsonppItem
    {
        private JsonppExts loc_9_0;
        private JsonppItem loc_18_0;

        public Jsonpp(JsonppExts loc_9_0, JsonppItem loc_18_0)
        {
            this.loc_9_0 = loc_9_0;
            this.loc_18_0 = loc_18_0;
        }

        public override AstNodeType NodeType => AstNodeType.Jsonpp;

        public override DuckTyping Type => loc_18_0.Type;

        public JsonppExts Exts => loc_9_0;

        public JsonppItem Item => loc_18_0;
    }
}