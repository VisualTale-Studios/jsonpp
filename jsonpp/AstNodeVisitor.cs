namespace jsonpp
{
    abstract class AstNodeVisitor
    {
        public virtual void Visit(JsonppItem node) 
        {
            if (node == null)
                return;

            switch (node.NodeType)
            {
                case AstNodeType.Unicode:
                    VisitUnicode(node as JsonppUnicode);
                    break;
                case AstNodeType.True:
                    VisitTrue(node as JsonppTrue);
                    break;
                case AstNodeType.String:
                    VisitString(node as JsonppString);
                    break;
                case AstNodeType.Scientific:
                    VisitScientific(node as JsonppScientific);
                    break;
                case AstNodeType.Object:
                    VisitObject(node as JsonppObject);
                    break;
                case AstNodeType.Number:
                    VisitNumber(node as  JsonppNumber);
                    break;
                case AstNodeType.Null:
                    VisitNull(node as  JsonppNull);
                    break;
                case AstNodeType.Hex:
                    VisitHex(node as JsonppHex);
                    break;
                case AstNodeType.False:
                    VisitFalse(node as JsonppFalse);
                    break;
                case AstNodeType.Array:
                    VisitArray(node as JsonppArray);
                    break;
                case AstNodeType.Jsonpp:
                    VisitJsonpp(node as Jsonpp);
                    break;
                case AstNodeType.DefineAlisa:
                    VisitDefineAlisa(node as JsonppDefineAlisa);
                    break;
                case AstNodeType.Schema:
                    VisitSchema(node as JsonppSchema);
                    break;
                case AstNodeType.SchemaObject:
                    VisitSchemaObject(node as JsonppSchemaObject);
                    break;
            }
        }

        protected abstract void VisitSchemaObject(JsonppSchemaObject? jsonppSchemaObject);
        protected abstract void VisitSchema(JsonppSchema? jsonppSchema);
        protected abstract void VisitDefineAlisa(JsonppDefineAlisa? jsonppDefineAlisa);
        protected abstract void VisitJsonpp(Jsonpp? jsonpp);
        protected abstract void VisitArray(JsonppArray? jsonppArray);
        protected abstract void VisitFalse(JsonppFalse? jsonppFalse);
        protected abstract void VisitHex(JsonppHex? jsonppHex);
        protected abstract void VisitNull(JsonppNull? jsonppNull);
        protected abstract void VisitNumber(JsonppNumber? jsonppNumber);
        protected abstract void VisitObject(JsonppObject? jsonppObject);
        protected abstract void VisitScientific(JsonppScientific? jsonppScientific);
        protected abstract void VisitString(JsonppString? jsonppString);
        protected abstract void VisitTrue(JsonppTrue? jsonppTrue);
        protected abstract void VisitUnicode(JsonppUnicode? jsonppUnicode);
    }
}
