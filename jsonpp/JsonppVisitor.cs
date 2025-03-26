using System;

namespace jsonpp
{
    class JsonppVisitor : AstNodeVisitor, IDisposable
    {
        private IJsonppReader reader;

        public JsonppVisitor(IJsonppReader reader) => this.reader = reader;

        protected override void VisitSchema(JsonppSchema? jsonppSchema)
        {
        }

        protected override void VisitDefineAlisa(JsonppDefineAlisa? jsonppDefineAlisa)
        {
        }

        protected override void VisitArray(JsonppArray? jsonppArray)
        {
            reader.BeginArray();
            if (jsonppArray.Items != null)
                for (var i = 0; i < jsonppArray.Items.Count; i++)
                    Visit(jsonppArray.Items[i]);
            reader.EndArray();
        }

        protected override void VisitFalse(JsonppFalse? jsonppFalse)
        {
            reader.Value(false);
        }

        protected override void VisitHex(JsonppHex? jsonppHex)
        {
            reader.Value(jsonppHex.Value);
        }

        protected override void VisitJsonpp(Jsonpp? jsonpp)
        {
            Visit(jsonpp.Item);
        }

        protected override void VisitNull(JsonppNull? jsonppNull)
        {
            reader.Null();
        }

        protected override void VisitNumber(JsonppNumber? jsonppNumber)
        {
            reader.Value(jsonppNumber.Value);
        }

        protected override void VisitObject(JsonppObject? jsonppObject)
        {
            reader.BeginObject();
            if (jsonppObject.Items != null)
                for (var i = 0; i < jsonppObject.Items.Count; i++)
                {
                    var item = jsonppObject.Items[i];
                    if (item != null)
                    {
                        reader.Field(item.Name.Literal);
                        Visit(item.Item);
                    }
                }
            reader.EndObject();
        }

        protected override void VisitSchemaObject(JsonppSchemaObject? jsonppSchemaObject)
        {
            reader.BeginObject();
            if (jsonppSchemaObject.Items != null)
                for (var i = 0; i < jsonppSchemaObject.Items.Count; i++)
                {
                    var item = jsonppSchemaObject.Items[i];
                    if (item != null)
                    {
                        reader.Field(item.Name.Literal);
                        Visit(item.Item);
                    }
                }
            reader.EndObject();
        }

        protected override void VisitScientific(JsonppScientific? jsonppScientific)
        {
            reader.Value(jsonppScientific.Value);
        }

        protected override void VisitString(JsonppString? jsonppString)
        {
            reader.Value(jsonppString.Value);
        }

        protected override void VisitTrue(JsonppTrue? jsonppTrue)
        {
            reader.Value(true);
        }

        protected override void VisitUnicode(JsonppUnicode? jsonppUnicode)
        {
            reader.Value(jsonppUnicode.Value);
        }

        public void Dispose()
        {
        }
    }
}
