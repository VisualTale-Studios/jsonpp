using System.Numerics;

namespace jsonpp
{
    public interface IJsonppReader
    {
        Vector4 GetTokenColor(int token);

        void Colour(int start, int end, Vector4 color);

        void ReportError(int start, int end, string message);

        void BeginObject();

        void EndObject();

        void BeginArray();

        void EndArray();

        void Field(string name);

        void Value(float value);

        void Value(bool value);

        void Value(string value);

        void Null();
    }
}
