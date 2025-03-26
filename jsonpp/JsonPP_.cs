using System.IO;

namespace jsonpp
{
    public static class JsonPP
    {
        /// <summary>
        /// 写入jsonpp
        /// </summary>
        public static IJsonppWriter Write(JsonppConfig config) 
        {
            return new JsonppWriter(config);
        }

        /// <summary>
        /// 读取jsonpp
        /// </summary>
        /// <param name="plaintext">明文</param>
        public static void Read(string plaintext‌, IJsonppReader reader, bool report)
        {
            JsonppPlaintextReader.Read(plaintext, reader, report);
        }

        /// <summary>
        /// 读取jsonpp
        /// </summary>
        /// <param name="stream">二进制数据</param>
        public static void Read(Stream stream‌‌, IJsonppReader reader)
        {
            JsonppBinaryReader.Read(stream, false, reader);
        }

        /// <summary>
        /// 从文件读取jsonpp
        /// </summary>
        public static void FromFile(string fileName‌‌, IJsonppReader reader, bool report) 
        {
            using var stream = File.OpenRead(fileName);
            if (JsonppBinaryReader.IsVaild(stream))
                JsonppBinaryReader.Read(stream, true, reader);
            else
                JsonppPlaintextReader.Read(File.ReadAllText(fileName), reader, report);
        }
    }
}
