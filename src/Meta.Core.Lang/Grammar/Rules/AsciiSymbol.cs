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
    /// Defines the set of recognized ASCII symbols
    /// </summary>
    public class AsciiSymbol : SyntaxRule<AsciiSymbol>
    {
        public static readonly AsciiSymbol Space = ascii.Space;
        public static readonly AsciiSymbol Percent = ascii.Percent;
        public static readonly AsciiSymbol Period = ascii.Period;
        public static readonly AsciiSymbol Dollar = ascii.Dollar;
        public static readonly AsciiSymbol Star = ascii.Star;
        public static readonly AsciiSymbol LessThan = ascii.LessThan;
        public static readonly AsciiSymbol GreaterThan = ascii.GreaterThan;
        public static readonly AsciiSymbol Plus = ascii.Plus;
        public static readonly AsciiSymbol Minus = ascii.Minus;
        public static readonly AsciiSymbol Bang = ascii.Bang;
        public static readonly AsciiSymbol At = ascii.At;
        public static readonly AsciiSymbol Pound = ascii.Pound;
        public static readonly AsciiSymbol Caret = ascii.Caret;
        public static readonly AsciiSymbol Ampersand = ascii.Ampersand;
        public static readonly AsciiSymbol SingleQuote = ascii.SingleQuote;
        public static readonly AsciiSymbol DoubleQuote = ascii.DoubleQuote;


        public static implicit operator AsciiSymbol(char symbol)
            => new AsciiSymbol(symbol);

        public AsciiSymbol(char Value, string Description = null)
            : base(Value.ToString(),Description)
        {

        }

        protected override AsciiSymbol Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new AsciiSymbol(RuleName.First(), Description);

        public override string ToString()
            => RuleName;
    }
}