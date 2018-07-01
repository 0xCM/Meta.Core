//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines the set of recognized ASCII digits
    /// </summary>
    public class AsciiDigit : SyntaxRule<AsciiDigit>
    {
        public static readonly AsciiDigit Zero = ascii.Zero;
        public static readonly AsciiDigit One = ascii.One;
        public static readonly AsciiDigit Two = ascii.Two;
        public static readonly AsciiDigit Three = ascii.Three;
        public static readonly AsciiDigit Four = ascii.Four;
        public static readonly AsciiDigit Five = ascii.Five;
        public static readonly AsciiDigit Six = ascii.Six;
        public static readonly AsciiDigit Seven = ascii.Seven;
        public static readonly AsciiDigit Eight = ascii.Eight;
        public static readonly AsciiDigit Nine = ascii.Nine;

        /// <summary>
        /// Specifies the presence of a single digit
        /// </summary>
        public static readonly SyntaxRule AnyDigit
            = Zero | One | Two | Three | Four| Five| Six | Seven | Eight | Nine;
              
        /// <summary>
        /// Specifies the presence of a nonzero digit
        /// </summary>
        public static readonly SyntaxRule NonzeroDigit
            = One | Two | Three | Four | Five | Six | Seven | Eight | Nine;

        public static implicit operator AsciiDigit(char Digit)
            => new AsciiDigit(Digit);

        public static AsciiDigit Define(char Digit)
            => new AsciiDigit(Digit);

        public AsciiDigit(char Digit = 'n')
            : base(Digit.ToString())
        {

        }

        protected override AsciiDigit Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new AsciiDigit(RuleName.First());
    }

}