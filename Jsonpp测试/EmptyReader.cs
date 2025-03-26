using jsonpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Jsonpp测试
{
    class EmptyReader : IJsonppReader
    {
        public void BeginArray()
        {
        }

        public void BeginObject()
        {
        }

        public void Colour(int start, int end, Vector4 color)
        {
        }

        public void EndArray()
        {
        }

        public void EndObject()
        {
        }

        public void Field(string name)
        {
        }

        public Vector4 GetTokenColor(int token)
        {
            return Vector4.Zero;
        }

        public void Null()
        {
        }

        public void ReportError(int start, int end, string message)
        {
        }

        public void Value(float value)
        {
        }

        public void Value(bool value)
        {
        }

        public void Value(string value)
        {
        }
    }
}
