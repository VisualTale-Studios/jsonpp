using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsonpp
{
    class JsonppPlaintextWriter : AstNodeVisitor
    {
        const int interval = 2;

        private bool format;
        private StringBuilder sb;
        private Dictionary<string, string> alisas;
        private HashSet<DuckTyping> schemas;

        private int level;

        public JsonppPlaintextWriter(bool format)
        {
            this.format = format;
            this.alisas = new Dictionary<string, string>();
            this.schemas = new HashSet<DuckTyping>();
            this.sb = new StringBuilder();
        }

        public string Json => sb.ToString();

        protected override void VisitDefineAlisa(JsonppDefineAlisa? jsonppDefineAlisa)
        {
            this.alisas[jsonppDefineAlisa.Literal] = jsonppDefineAlisa.Alisa;
            Write($"{jsonppDefineAlisa.Alisa}=\"{jsonppDefineAlisa.Literal}\"");
            WriteLine();
        }

        protected override void VisitSchema(JsonppSchema? jsonppSchema)
        {
            this.schemas.Add(jsonppSchema.Type);
            Write($"schema {jsonppSchema.Type.Name} {{");
            level++;
            WriteLine();
            var last = jsonppSchema.Type.LastOrDefault();
            foreach (var field in jsonppSchema.Type)
            {
                Write($"{field.Value.Name} {(alisas.ContainsKey(field.Key) ? alisas[field.Key] : $"\"{field.Key}\"")}");
                if (last.Key != field.Key)
                    WriteLine();
            }
            level--;
            WriteLine("}");
        }

        protected override void VisitJsonpp(Jsonpp? jsonpp)
        {
            for (var i = 0; i < jsonpp.Exts.Items.Count; i++)
                Visit(jsonpp.Exts.Items[i]);

            if(jsonpp.Exts.Items.Count > 0) 
                WriteLine();

            Visit(jsonpp.Item);
        }

        protected override void VisitFalse(JsonppFalse? jsonppFalse)
        {
            Write("false");
        }

        protected override void VisitHex(JsonppHex? jsonppHex)
        {
            Write(jsonppHex.Value.ToString());
        }

        protected override void VisitNull(JsonppNull? jsonppNull)
        {
        }

        protected override void VisitNumber(JsonppNumber? jsonppNumber)
        {
            Write(jsonppNumber.Value.ToString());
        }

        protected override void VisitArray(JsonppArray? jsonppArray)
        {
            var newline = false;

            Write("[");
            level++;
            for (var i = 0; i < jsonppArray.Items.Count; i++)
            {
                var item = jsonppArray.Items[i];
                Visit(item);
                if (i != jsonppArray.Items.Count - 1)
                    Write(",");
                else if (item.NodeType == AstNodeType.Object || item.NodeType == AstNodeType.Array)
                    newline = true;
            }
            level--;
            if (newline)
                WriteLine();

            Write("]");
        }

        protected override void VisitObject(JsonppObject? jsonppObject)
        {
            if (schemas.Contains(jsonppObject.Type))
            {
                WriteLine($"{jsonppObject.Type.Name} {{");
                level++;
                WriteLine();
                for (var i = 0; i < jsonppObject.Items.Count; i++)
                {
                    var item = jsonppObject.Items[i];
                    Visit(item.Item);
                    if (i != jsonppObject.Items.Count - 1)
                    {
                        Write(",");
                        WriteLine();
                    }
                }
                level--;
                WriteLine("}");
            }
            else
            {
                WriteLine("{");
                level++;
                WriteLine();
                for (var i = 0; i < jsonppObject.Items.Count; i++)
                {
                    var item = jsonppObject.Items[i];
                    Write(alisas.ContainsKey(item.Name.Literal) ? alisas[item.Name.Literal] : $"\"{item.Name.Literal}\"");
                    Write(":");
                    Visit(item.Item);
                    if (i != jsonppObject.Items.Count - 1)
                    {
                        Write(",");
                        WriteLine();
                    }
                }
                level--;
                WriteLine("}");
            }
        }

        protected override void VisitScientific(JsonppScientific? jsonppScientific)
        {
            Write(jsonppScientific.Value.ToString());
        }

        protected override void VisitString(JsonppString? jsonppString)
        {
            Write($"\"{jsonppString.Value}\"");
        }

        protected override void VisitTrue(JsonppTrue? jsonppTrue)
        {
            Write("true");
        }

        protected override void VisitUnicode(JsonppUnicode? jsonppUnicode)
        {
            Write(jsonppUnicode.Value.ToString());
        }

        private void Write(string str) 
        {
            sb.Append(str);
        }

        private void WriteLine() 
        {
            WriteLine(string.Empty);
        }

        private void WriteLine(string str)
        {
            if (format)
                sb.Append($"\n{string.Empty.PadLeft(level * interval)}{str}");
            else 
                sb.Append(str);
        }

        protected override void VisitSchemaObject(JsonppSchemaObject? jsonppSchemaObject)
        {
            throw new Exception("写入器不应存在Schema Object");
        }
    }
}
