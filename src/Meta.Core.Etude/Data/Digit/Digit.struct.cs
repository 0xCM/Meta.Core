//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Represents a digit
    /// </summary>
    public readonly struct Digit : IEquatable<Digit>
    {
        public static readonly Digit Empty = Define(0xFF);

        public static IOrdered<Digit> Ordered
            => DigitOrder.instance;

        /// <summary>
        /// Parses the text as a <see cref="Digit"/> if possible; otherwise, returns none
        /// </summary>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<Digit> Parse(string text)
            => byte.TryParse(text, out byte result)
                ? some(Define(result)) : none<Digit>();

        /// <summary>
        /// Constructs a digit from a character, if possible; otherwise, reurns none
        /// </summary>
        /// <param name="c">The input character</param>
        /// <returns></returns>
        public static Option<Digit> Parse(char c)
            => byte.TryParse(c.ToString(), out byte result)
                ? some(Define(result)) : none<Digit>();

        /// <summary>
        /// Converts a digit to its character representation
        /// </summary>
        /// <param name="d">The digit to convert</param>
        public static implicit operator char(Digit d)
            => d.Value.ToString()[0];

        /// <summary>
        /// Converts an integer int the range [0,..,9] to its digit
        /// representation. 
        /// </summary>
        /// <param name="i"></param>
        public static implicit operator Digit(int i)
            => FromChar(i.ToString()[0]);

        static Digit FromChar(char c)
        {
            switch (c)
            {
                case '0': return Define(0);
                case '1': return Define(1);
                case '2': return Define(2);
                case '3': return Define(3);
                case '4': return Define(4);
                case '5': return Define(5);
                case '6': return Define(6);
                case '7': return Define(7);
                case '8': return Define(8);
                case '9': return Define(9);
            }
            return Empty;

        }

        /// <summary>
        /// Converts a character to a digit if possible; otherwise,
        /// returns the emtpy digit
        /// </summary>
        /// <param name="c"></param>
        public static explicit operator Digit(char c)
            => FromChar(c);

        public static bool operator ==(Digit x1, Digit x2)
            => Equals(x1, x2);

        public static bool operator !=(Digit x1, Digit x2)
            => not(Equals(x1, x2));

        public static bool operator <(Digit x1, Digit x2)
            => x1.Value < x2.Value;

        public static bool operator >(Digit x1, Digit x2)
            => x1.Value > x2.Value;

        public static bool operator >=(Digit x1, Digit x2)
            => x1.Value >= x2.Value;

        public static bool operator <=(Digit x1, Digit x2)
            => x1.Value <= x2.Value;


        public static Digit Define(byte Value)
            => new Digit(Value);

        public Digit(byte Value)
            => this.Value = require(Value, x => x <= 9 || x == 0xFF);

        /// <summary>
        /// Returns true if the digit is the empty digit
        /// </summary>
        public bool IsEmtpy
            => this == Empty;

        /// <summary>
        /// An initeger in the range [0,9]
        /// </summary>
        public byte Value { get; }

        public override string ToString()
            => Value.ToString();

        public override bool Equals(object obj)
            => obj is Digit ? Equals((Digit)obj) : false;

        public override int GetHashCode()
            => Value;

        public bool Equals(Digit other)
            => this.Value == other.Value;
    }
}