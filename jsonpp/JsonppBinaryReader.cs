using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jsonpp
{
    static class JsonppBinaryReader
    {
        public static void Read(Stream stream, bool vaild, IJsonppReader reader) 
        {
            using var br = new BinaryReader(stream);
            if (vaild || IsVaild(stream))
            {
                using var visitor = new JsonppVisitor(reader);

                var alisas = new Dictionary<string, string>();
                var types = new Dictionary<ushort, DuckTyping>();

                // 读取string数量
                var count = br.ReadUInt16();
                var strings = new string[count];
                for (var i = 0; i < count; i++)
                    strings[i] = br.ReadString();


                DuckTyping GetType(ushort index)
                {
                    if (types.ContainsKey(index))
                        return types[index];

                    var typeName = strings[index];
                    switch (typeName)
                    {
                        case "bool": return DuckTyping.Bool;
                        case "number": return DuckTyping.Number;
                        case "string": return DuckTyping.String;
                        case "array": return DuckTyping.Array;
                        case "null":  return DuckTyping.Null;
                    }

                    throw new NotImplementedException();
                }

                // 读取ext数量
                var exts = new JsonppExts();
                count = br.ReadUInt16();
                for (var i = 0; i < count; i++)
                {
                    var type = br.ReadByte();
                    switch (type)
                    {
                        // 别名
                        case 0:
                            var alisa = strings[br.ReadUInt16()];
                            var literal = strings[br.ReadUInt16()];
                            alisas[alisa] = literal;
                            exts.Add(new JsonppDefineAlisa(alisa, literal));
                            break;
                        // schema
                        case 1:
                            var index = br.ReadUInt16();
                            var memberCount = br.ReadUInt16();
                            var schema = new DuckTyping(strings[index]);
                            for (var x = 0; x < memberCount; x++)
                            {
                                var memberType = GetType(br.ReadUInt16());
                                var memberName = strings[br.ReadUInt16()];
                                schema[memberName] = memberType;
                            }
                            exts.Add(new JsonppSchema(schema));
                            types[index] = schema;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }

                JsonppItem ReadItem(DuckTyping type) 
                {
                    if (type == DuckTyping.Number)
                        return new JsonppNumber(br.ReadSingle());

                    if (type == DuckTyping.Bool)
                        return br.ReadBoolean() ? new JsonppTrue() : new JsonppFalse();

                    if (type == DuckTyping.String)
                        return new JsonppString(br.ReadString());

                    if (type == DuckTyping.Null)
                        return new JsonppNull();

                    if (type == DuckTyping.Array)
                    {
                        var array = new JsonppArray();
                        var count = br.ReadUInt16();
                        for (var i = 0; i < count; i++)
                            array.Items.Add(ReadItem(GetType(br.ReadUInt16())));

                        return array;
                    }
                    else 
                    {
                        var obj = new JsonppObject();
                        var fromSchma = br.ReadBoolean();
                        if (fromSchma)
                        {
                            var schma = GetType(br.ReadUInt16());
                            var list = schma.ToArray();
                            for (var i = 0; i < list.Length; i++) 
                            {
                                var field = list[i];
                                obj.Items.Add(new JsonppObjectFieldItem(new NameReference(default, field.Key), ReadItem(field.Value)));
                            }
                        }
                        else
                        {
                            var count = br.ReadUInt16();
                            for (var i = 0; i < count; i++)
                            {
                                var name = strings[br.ReadUInt16()];
                                var refer = alisas.ContainsKey(name) ?
                                    new NameReference(name, alisas[name]) : 
                                    new NameReference(default, name);

                                obj.Items.Add(new JsonppObjectFieldItem(refer, ReadItem(GetType(br.ReadUInt16()))));
                            }
                        }
                        return obj;
                    }
                }

                // 读取item
                var item = ReadItem(GetType(br.ReadUInt16()));
                var json = new Jsonpp(exts, item);
                visitor.Visit(json);
            }
        }

        public static bool IsVaild(Stream stream) 
        {
            var br = new BinaryReader(stream);
            if (br.ReadByte() == 'j' && br.ReadByte() == 's' && br.ReadByte() == 'o' && br.ReadByte() == 'n' && br.ReadByte() == 'p' & br.ReadByte() == 'p')
                return true;

            return false;
        }
    }
}
