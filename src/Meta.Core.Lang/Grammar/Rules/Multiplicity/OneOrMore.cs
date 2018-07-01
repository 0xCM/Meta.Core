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
    /// Specifies a rule that can be repeated an arbitrary number of times
    /// </summary>
    public class OneOrMore : SyntaxRule<OneOrMore>
    {
        protected OneOrMore(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName,Terms, Description)
        {

        }

        public OneOrMore(string RuleName, SyntaxRule Rule, string Description = null)
            : base(RuleName, stream(Rule), Description)
        {
            
        }

        public OneOrMore(SyntaxRule Rule)
            : base(string.Empty, stream(Rule))
        {

        }

        protected override OneOrMore Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new OneOrMore(RuleName, Terms, Description);

        SyntaxRule Rule => Terms[0];

        public override string ToString()
            => $"{Rule} [,...n]";
    }
}