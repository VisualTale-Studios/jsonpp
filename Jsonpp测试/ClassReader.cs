using jsonpp;
using System.Numerics;

namespace Jsonpp测试
{
    class ClassReader : IJsonppReader
    {
        public Vector4 GetTokenColor(int token)
        {
            switch (token)
            {
                case 1:
                    return new Vector4(255, 193, 121, 212);
                case 2:
                    return new Vector4(255, 255, 214, 143);
                case 3:
                    return new Vector4(255, 133, 140, 153);
                case 4:
                    return new Vector4(255, 229, 192, 123);
            }

            return Vector4.Zero;
        }

        public void ReportError(int start, int end, string message)
        {
        }

        public void Colour(int start, int end, Vector4 color)
        {
        }


        public void Field(string name)
        {
            Console.WriteLine($"[Field]{name}");
        }


        public void BeginArray()
        {
            Console.WriteLine("开始Array");
        }

        public void BeginObject()
        {
            Console.WriteLine("开始Object");
        }

        public void EndArray()
        {
            Console.WriteLine("结束Array");
        }

        public void EndObject()
        {
            Console.WriteLine("结束Object");
        }

        public void Null()
        {
            Console.WriteLine($"值 null");
        }

        public void Value(float value)
        {
            Console.WriteLine($"值 {value}");
        }

        public void Value(bool value)
        {
            Console.WriteLine($"值 {value}");
        }

        public void Value(string value)
        {
            Console.WriteLine($"值 {value}");
        }
    }
}
