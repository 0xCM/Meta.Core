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
    /// Specifies a rule that can be repeated 0 or more times
    /// </summary>
    public class ZeroOrMore : SyntaxRule<ZeroOrMore>
    {
        public static implicit operator OptionalRule(ZeroOrMore x)
            => new OptionalRule(new OneOrMore(x.RuleName, x.Rule));

        public ZeroOrMore(string RuleName, SyntaxRule Terms, string Description)
            : base(string.Empty, stream(Terms))
        {

        }

        public ZeroOrMore(SyntaxRule Terms)
            : base(string.Empty, stream(Terms))
        {

        }

        protected override ZeroOrMore Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new ZeroOrMore(RuleName, Terms.Single(), Description);

        SyntaxRule Rule => Terms[0];


        public override string ToString()
            => $"[{Rule} [,...n]]";

    }

}