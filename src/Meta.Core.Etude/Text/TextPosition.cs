//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Text
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Specifies a location in a block of text
    /// </summary>
    public readonly struct TextPosition : IEquatable<TextPosition>
    {
        public static readonly TextPosition Empty = (0, 0);
        public static readonly TextPosition Initial = (1, 1);

        public static implicit operator TextPosition((int line, int col) x)
            => new TextPosition(x.line, x.col);

        public static bool operator ==(TextPosition x1, TextPosition x2)
            => x1.Equals(x2);

        public static bool operator !=(TextPosition x1, TextPosition x2)
            => not(x1 == x2);

        public static bool operator <(TextPosition x1, TextPosition x2)
            => x1.LineNumber < x2.LineNumber ? true
            : x1.ColumnNumber < x2.ColumnNumber;

        public static bool operator >(TextPosition x1, TextPosition x2)
            => x1.LineNumber > x2.LineNumber ? true
            : x1.ColumnNumber > x2.ColumnNumber;

        public static bool operator >=(TextPosition x1, TextPosition x2)
            => x1 > x2 || x1 == x2;

        public static bool operator <=(TextPosition x1, TextPosition x2)
            => x1 < x2 || x1 == x2;

        public TextPosition(int LineNumber, int ColumnNumber)
        {
            this.LineNumber = LineNumber;
            this.ColumnNumber = ColumnNumber;
        }

        /// <summary>
        /// The position line number
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// The position column
        /// </summary>
        public int ColumnNumber { get; }

        public TextPosition AdvanceColumn(int distance)
            => new TextPosition(LineNumber, ColumnNumber + distance);

        public TextPosition NextColumn()
            => AdvanceColumn(1);

        public TextPosition AdvanceLine(int distance)
            => new TextPosition(LineNumber + distance, ColumnNumber);

        public TextPosition NextLine()
            => AdvanceLine(1);

        /// <summary>
        /// True if the position has the empty value, false otherwise
        /// </summary>
        public bool IsEmpty
            => this == Empty;

        public bool Equals(TextPosition other)
            => this.LineNumber == other.LineNumber
            && this.ColumnNumber == other.ColumnNumber;

        public override bool Equals(object obj)
            => (obj is TextPosition) ? Equals((TextPosition)obj) : false;

        public override int GetHashCode()
            => (LineNumber, ColumnNumber).GetHashCode();

        public override string ToString()
            => $"({LineNumber},{ColumnNumber})";

    }



}