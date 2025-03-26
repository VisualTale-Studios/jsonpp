using System.IO;

namespace jsonpp
{
    public interface IJsonppWriter
    {
        /// <summary>
        /// 转换成json
        /// </summary>
        /// <param name="format">是否格式化</param>
        string ToJson(bool format);

        /// <summary>
        /// 转换成二进制数据
        /// </summary>
        Stream ToBinary();
        void Write(string value);
        void Write(float value);
        void Write(bool value);
        void BeginObject();
        void Field(string fieldName);
        void EndObject();
        void BeginArray();
        void EndArray();
        void Clear();
    }
}
