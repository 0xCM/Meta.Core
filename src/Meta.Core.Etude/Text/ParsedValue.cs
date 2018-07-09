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
    /// Encapsulates a parsed value together with the current parser state
    /// </summary>
    /// <typeparam name="A">The parsed value type</typeparam>
    public readonly struct ParsedValue<A>
    {
        public ParsedValue(A Parsed, TextBlock Remainder)
        {
            this.Parsed = Parsed;
            this.Remainder = Remainder;
        }

        /// <summary>
        /// A value parsed from the text block
        /// </summary>
        public A Parsed { get; }

        /// <summary>
        /// The remaining text to parse as determined by
        /// the encapsulated position value
        /// </summary>
        public TextBlock Remainder { get; }

        public (A Parsed, TextBlock Remainder) AsTuple()
            => (Parsed, Remainder);

        public override string ToString()
            => AsTuple().Format();
    }

}