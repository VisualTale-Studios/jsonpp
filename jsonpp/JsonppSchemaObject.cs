using System;
using System.Collections.Generic;
using System.Linq;

namespace jsonpp
{
    internal class JsonppSchemaObject : JsonppCollection
    {
        private List<JsonppObjectItem> items;

        public unsafe JsonppSchemaObject(Match loc_1_0, JsonppArray loc_21_0, char* mInput, JsonppParserBase jsonppParser)
        {
            Type = jsonppParser.GetDuckTypeing(loc_1_0, mInput);
            this.items = new List<JsonppObjectItem>();
            if (loc_21_0 != null) 
            {
                var list = Type.ToArray();
                for (var i = 0; i < loc_21_0.Items.Count; i++)
                {
                    var item = loc_21_0.Items[i];
                    var type = list[i];

                    if (type.Value != item.Type)
                        throw new NotImplementedException();

                    this.items.Add(new JsonppObjectFieldItem(new NameReference(default, type.Key), item));
                }
            }
        }

        public override AstNodeType NodeType => AstNodeType.SchemaObject;

        public override DuckTyping Type { get; }

        public List<JsonppObjectItem> Items => items;

        internal override void AddItem(JsonppItem item)
        {
            throw new Exception("Schema Object不允许使用AddItem");
        }

        internal override void Field(NameReference refer)
        {
            throw new Exception("Schema Object不允许使用Field");
        }

        internal override DuckTyping GetFields()
        {
            throw new Exception("Schema Object不允许使用GetFields");
        }
    }
}