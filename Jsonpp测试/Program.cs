// See https://aka.ms/new-console-template for more information
using jsonpp;
using Jsonpp测试;
using System.Diagnostics;

Console.WriteLine("// ================ 基础数据 ================");

var config = new JsonppConfig() { AutoAlisa = true, AutoSchema = true };
var writer = JsonPP.Write(config);
writer.Write("test");
var json = writer.ToJson(true);
Console.WriteLine($"json {(json == "\"test\"" ? "==" : "!=")} test");

writer.Clear();
writer.Write(true);
json = writer.ToJson(true);
Console.WriteLine($"json {(json == "true" ? "==" : "!=")} true");

writer.Clear();
writer.Write(false);
json = writer.ToJson(true);
Console.WriteLine($"json {(json == "false" ? "==" : "!=")} false");

writer.Clear();
writer.Write(1001);
json = writer.ToJson(false);
Console.WriteLine($"json {(json == "1001" ? "==" : "!=")} 1001");

Console.WriteLine("// ================ 同行数组 ================");
writer.Clear();
writer.BeginArray();
writer.Write(1);
writer.Write(2);
writer.Write(3);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(null);
writer.Write(7);
writer.Write(null);
writer.Write(true);
writer.EndArray();
json = writer.ToJson(true);
Console.WriteLine(json);

Console.WriteLine("// ================ Object ================");
config.AutoAlisa = false;
config.AutoSchema = false;
writer.Clear();
writer.BeginArray();
writer.BeginObject();
writer.Field("field");
writer.Write(true);
writer.Field("field2");
writer.Write("可爱看的萨达是非");
writer.EndObject();
writer.EndArray();
json = writer.ToJson(true);
Console.WriteLine(json);
var binary = writer.ToBinary();
Console.WriteLine($"紧凑序列化后size {binary.Length}bytes");
config.AutoAlisa = false;
config.AutoSchema = true;

Console.WriteLine("// ================ Schema Object ================");
writer.Clear();
writer.BeginArray();
writer.BeginObject();
writer.Field("field");
writer.Write(true);
writer.Field("field2");
writer.Write("可爱看的萨达是非");
writer.EndObject();
writer.EndArray();
json = writer.ToJson(true);
Console.WriteLine(json);
binary = writer.ToBinary();
Console.WriteLine($"紧凑序列化后size {binary.Length}bytes");

Console.WriteLine("// ================ 读取json ================");
Console.WriteLine("// ======== 会着色与更详细的汇报错误 ========");
JsonPP.Read(json, new ClassReader(), true);
Console.WriteLine("// ================ 读取二进制 ==============");
JsonPP.Read(binary, new ClassReader());
Console.WriteLine("// ================ 解析性能 ================");
var ctx = File.ReadAllText("json.txt");

var ereader = new EmptyReader();
JsonPP.Read(ctx, ereader, false);
var sw = new Stopwatch();
sw.Start();
for (var i = 0; i < 1000; i++)
    JsonPP.Read(ctx, ereader, false);
sw.Stop();
Console.WriteLine($"解析ctx 1000次用时{sw.ElapsedMilliseconds}毫秒 平均{sw.ElapsedMilliseconds / 1000f}毫秒");
Console.WriteLine($"平均每毫秒错误恢复并着色{(ctx.Length * 1000) / sw.ElapsedMilliseconds}个字");

Console.ReadLine();