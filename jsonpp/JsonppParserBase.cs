using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace jsonpp
{
    abstract class JsonppParserBase : IDisposable
    {
        private readonly static Vector4 EscapeColor = new Vector4(255, 243, 160, 15);
        private readonly static Vector4 StringColor = new Vector4(255, 152, 195, 95);
        private readonly static Vector4 InvaildColor = new Vector4(255, 88, 88, 88);
        internal readonly static Vector4 NumberColor = new Vector4(255, 209, 137, 78);

        private IJsonppReader reader;
        private DuckTypingPool typePool = new DuckTypingPool();

        public JsonppParserBase(IJsonppReader reader) 
        {
            this.reader = reader;
        }

        internal Dictionary<string, DuckTyping> DuckTypings { get; set; } = new Dictionary<string, DuckTyping>();
        internal Dictionary<string, string> Alisas { get; set; } = new Dictionary<string, string>();

        protected unsafe abstract Jsonpp DoParse(char* input, int length);

        protected abstract int Index { get; set; }

        protected abstract unsafe char* Input { get; set; }

        protected abstract int Length { get; }

        protected abstract int GetMatchTokenTag(ushort token);

        public unsafe Jsonpp Parse(string json) 
        {
            fixed (char* ptr = json)
                return Parse(ptr, json.Length);
        }

        public unsafe Jsonpp Parse(char* input, int length) 
        {
            return DoParse(input, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DefineType(DuckTyping type, SourceSpan span) 
        {
            if (DuckTypings.ContainsKey(type.Name))
            {
                ReportError(span, string.Format(GetMessage("已包含相同Schema {0}"), type.Name));
            }
            else
            {
                DuckTypings[type.Name] = type;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DefineAlisa(string alisa, string literal, SourceSpan span) 
        {
            if (Alisas.ContainsKey(alisa))
            {
                ReportError(span, string.Format(GetMessage("已包含相同别名{0}"), alisa));
            }
            else
            {
                Alisas[alisa] = literal;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetAlisaLiteral(string alisa, SourceSpan span) 
        {
            if (!Alisas.ContainsKey(alisa))
            {
                ReportError(span, string.Format(GetMessage("不包含别名{0}"), alisa));
                return null;
            }
            return Alisas[alisa];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe DuckTyping GetDuckTypeing(Match id, char* input) 
        {
            var name = id.GetContent(input);
            if (!DuckTypings.ContainsKey(name))
            {
                ReportError(id.SourceSpan, string.Format(GetMessage("不包含Schema {0}"), name));
                return DuckTyping.Null;
            }

            return DuckTypings[name];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DuckTyping GetDuckTypeing(DuckTyping input, SourceSpan span) 
        {
            var type = typePool.GetType(input, out var isNew);
            if (isNew)
                DefineType(type, span);

            return type;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnMatch(int start, int end, ushort token)
        {
            var color = reader?.GetTokenColor(GetMatchTokenTag(token)) ?? Vector4.Zero;
            if (color.X > 0)
                reader?.Colour(start, end, color);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected Match Back(Match readStep, int rindex, ref int index)
        {
            index = rindex;
            //mSkipState ++;
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected internal void ReportError(SourceSpan span, string message)
        {
            reader?.ReportError(span.Start, span.End, message);
        }

        /// <summary>
        /// 着色
        /// </summary>
        /// <param name="span">着色位置</param>
        /// <param name="color">ARGB</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected internal void Colour(SourceSpan span, Vector4 color) 
        {
            reader?.Colour(span.Start, span.End, color);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string GetMessage(string msg) => msg;

        protected unsafe Match ParseString(Match match, char* input)
        {
            const char quote = '"';

            var start = Index - 1;
            var curr = start;
            if (Input[start] != quote)
                return new Match(new SourceSpan(Index, Index), match.Token);

            //assert((quote == '\'' || quote == '"'),
            //    'String literal must starts with a quote');

            //++Index;
            while (Index < Length)
            {
                var ch = Input[Index];
                Index++;

                if (ch == quote)
                {
                    break;
                }
                else if (ch == '\\')
                {
                    if (Index >= Length)
                    {
                        break;
                    }
                    ch = Input[Index];
                    Index++;
                    if (!IsLineTerminator(ch))
                    {
                        if (Index - 2 > curr)
                            Colour(new SourceSpan(curr, Index - 2), StringColor);
   
                        switch (ch)
                        {
                            case 'u':
                                if (Input[Index] == '{')
                                {
                                    ++Index;
                                    //str.AppendCodePoint(ScanUnicodeCodePointEscape());
                                    var hexStart = Index - 3;
                                    if (!TryScanUnicodeCodePointEscape(out int code))
                                    {
                                        if (code > UnicodeLastCodePoint)
                                            ReportError(new SourceSpan(hexStart, Index), GetMessage("未定义的 Unicode 码点"));
                                        else
                                            ReportError(new SourceSpan(hexStart, Index), GetMessage("无效的 Unicode 转义序列"));
                                    }

                                    Colour(new SourceSpan(hexStart, Index), EscapeColor);
                                }
                                else
                                {
                                    var hexStart = Index - 2;
                                    if (!ScanHexEscape(ch, out var unescaped))
                                    {
                                        ReportError(new SourceSpan(hexStart, Index), GetMessage("无效的十六进制转义序列"));
                                    }

                                    Colour(new SourceSpan(hexStart, Index), EscapeColor);
                                }

                                break;
                            case 'x':
                                {
                                    var hexStart = Index - 2;
                                    if (!ScanHexEscape(ch, out var unescaped2))
                                    {
                                        ReportError(new SourceSpan(hexStart, Index), GetMessage("无效的十六进制转义序列"));
                                    }

                                    Colour(new SourceSpan(hexStart, Index), EscapeColor);
                                }
                                //str.Append(unescaped2);
                                break;
                            case 'n':
                                //str.Append('\n');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case 'r':
                                //str.Append('\r');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case 't':
                                //str.Append('\t');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case 'b':
                                //str.Append('\b');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case 'f':
                                //str.Append('\f');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case 'v':
                                //str.Append('\v');
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;
                            case '8':
                            case '9':
                                //str.Append(ch);
                                //octal = LegacyOctalKind.Escaped8or9;
                                Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                break;

                            default:
                                if (IsOctalDigit(ch))
                                {
                                    var octToDec = OctalToDecimal(ch, out var length);

                                    if (octToDec != 0 || length > 1 || Input[Index] is '8' or '9')
                                    {

                                    }

                                    Colour(new SourceSpan(Index - 2, Index), EscapeColor);
                                }
                                else
                                {
                                }
                                break;
                        }

                        curr = Index;
                    }
                    else
                    {
                        if (Index - 2 > curr)
                            Colour(new SourceSpan(curr, Index - 2), StringColor);

                        Colour(new SourceSpan(Index - 2, Index - 1), InvaildColor);
                        if (ch == '\r' && Input[Index] == '\n')
                        {
                            ++Index;
                        }

                        curr = Index;
                    }
                }
                else if (IsLineTerminator(ch))
                {
                    // Since ES2019, line and paragraph separators are allowed in string literals.
                    Index--;
                    ReportError(new SourceSpan(start, Index), GetMessage("字符串没有以 \" 字符结尾"));
                    break;
                }
            }

            if (Index > curr)
                Colour(new SourceSpan(curr, Index), StringColor);

            return new Match(new SourceSpan(start, Index), match.Token);
        }

        internal const int UnicodeLastCodePoint = 0x10FFFF;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe bool TryScanUnicodeCodePointEscape(out int code)
        {
            var ch = Input[Index];
            code = 0;

            // At least, one hex digit is required.
            if (ch == '}')
            {
                return false;
            }

            while (Index < Length)
            {
                ch = Input[Index++];
                if (!IsHexDigit(ch))
                {
                    break;
                }

                code = code * 16 + FromChar(ch);

                // The Unicode standard guarantees that a code point above 0x10FFFF will never be assigned
                // (see https://stackoverflow.com/a/52203901/8656352).
                if (code > UnicodeLastCodePoint)
                {
                    return false;
                }
            }

            if (ch != '}')
            {
                return false;
            }

            // The surrogate range is valid in literals (e.g. "a\u{d800}\u{dc00}") but not valid in identifiers (e.g. a\u{d800}\u{dc00}).
            // Let's return true in both cases and let the caller deal with it.

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int OctalValue(char ch)
        {
            return ch - '0';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe int OctalToDecimal(char ch, out int length)
        {
            var code = OctalValue(ch);
            length = 1;

            if (Index < Length && IsOctalDigit(Input[Index]))
            {
                code = code * 8 + OctalValue(Input[Index++]);
                length++;

                // 3 digits are only allowed when string starts
                // with 0, 1, 2, 3
                if (ch >= '0' && ch <= '3' && Index < Length && IsOctalDigit(Input[Index]))
                {
                    code = code * 8 + OctalValue(Input[Index++]);
                    length++;
                }
            }

            return code;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IsInRange(char c, char min, char max) => c - (uint)min <= max - (uint)min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IsOctalDigit(char cp) => IsInRange(cp, '0', '7');

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsLineTerminator(char ch)
        {
            return ch == 10
                   || ch == 13
                   || ch == 0x2028 // line separator
                   || ch == 0x2029 // paragraph separator
                ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsHexChar(int c)
        {
            if (IntPtr.Size == 8)
            {
                ulong i = (uint)c - '0';
                ulong shift = 18428868213665201664UL << (int)i;
                ulong mask = i - 64;

                return (long)(shift & mask) < 0 ? true : false;
            }

            return FromChar(c) != 0xFF;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHexDigit(char cp) => IsHexChar(cp);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe bool ScanHexEscape(char prefix, out char result)
        {
            var len = prefix == 'u' ? 4 : 2;
            var code = 0;

            for (var i = 0; i < len; ++i)
            {
                if (Index < Length)
                {
                    var d = Input[Index];
                    if (IsHexDigit(d))
                    {
                        code = code * 16 + FromChar(d);
                        Index++;
                    }
                    else
                    {
                        result = char.MinValue;
                        return false;
                    }
                }
                else
                {
                    result = char.MinValue;
                    return false;
                }
            }

            result = (char)code;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FromChar(int c)
        {
            return c >= CharToHexLookup.Length ? 0xFF : CharToHexLookup[c];
        }

        public void Dispose()
        {
            typePool.Dispose();
            typePool = null;

            DuckTypings.Clear();
            DuckTypings.TrimExcess();
            DuckTypings = null;

            Alisas.Clear();
            Alisas.TrimExcess();
            Alisas = null;
        }

        static ReadOnlySpan<byte> CharToHexLookup => new byte[]
        {
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 15
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 31
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 47
            0x0,  0x1,  0x2,  0x3,  0x4,  0x5,  0x6,  0x7,  0x8,  0x9,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 63
            0xFF, 0xA,  0xB,  0xC,  0xD,  0xE,  0xF,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 79
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 95
            0xFF, 0xa,  0xb,  0xc,  0xd,  0xe,  0xf,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 111
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 127
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 143
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 159
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 175
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 191
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 207
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 223
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 239
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  // 255
        };
    }
}
