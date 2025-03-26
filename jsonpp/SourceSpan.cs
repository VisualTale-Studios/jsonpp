using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace jsonpp
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct SourceSpan : IEquatable<SourceSpan>, ISourceSpan
    {
        public int Start { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public int End { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public int Length { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return End - Start; } }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SourceSpan(int start, int end)
        {
            Start = start;
            End = end;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(int charIndex)
        {
            return charIndex >= Start && charIndex <= End;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains2(int charIndex)
        {
            return charIndex > Start && charIndex < End;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains3(int charIndex)
        {
            return Start == End ? charIndex == Start : charIndex >= Start && charIndex <= End;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(SourceSpan span)
        {
            return Contains(span.Start) && Contains(span.End);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SourceSpan Combine(SourceSpan sourceSpan)
        {
            return new SourceSpan(Start < sourceSpan.Start ? Start : sourceSpan.Start, End > sourceSpan.End ? End : sourceSpan.End);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is SourceSpan))
                return false;

            return Equals((SourceSpan)obj);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return Start << 16 ^ End;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SourceSpan other)
        {
            return Start == other.Start && End == other.End;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("start {0} end {1}", Start, End);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToFormat() 
        {
            return $"{Start}-{End}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range ToRange() => new Range(Start, End);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SourceSpan Offset(int left, int right) => new SourceSpan(Start + left, End + right);

        public static SourceSpan Combine(params ISourceSpan[] spans) 
        {
            if (spans == null || spans.Length == 0)
                return default;

            var start = spans[0];
            if (start == default)
                return default;

            for (var i = spans.Length - 1; i >= 0; i--)
            {
                var end = spans[i];
                if (end != default)
                    return new SourceSpan(spans[0].Start, end.End);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range(SourceSpan span) => new Range(span.Start, span.End);
    }

}
