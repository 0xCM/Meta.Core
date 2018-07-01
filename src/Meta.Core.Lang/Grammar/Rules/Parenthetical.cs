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
    /// Specifies a rule enclosed by parenthesis of the form (rule)
    /// </summary>
    public class Parenthetical : SyntaxRule<Parenthetical>
    {
        public static Parenthetical Define(SyntaxRule rule, string Description = null)
            => new Parenthetical(rule, Description);

        public Parenthetical(SyntaxRule Rule, string Description = null)
            : base(string.Empty, stream(Rule), Description)
        {

        }

        /// <summary>
        /// The rule enclosed by parentheses
        /// </summary>
        SyntaxRule Rule => Terms[0];

        public override string ToString()
            => $"({Rule})";

        protected override Parenthetical Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new Parenthetical(Terms.Single(), Description);
    }
}