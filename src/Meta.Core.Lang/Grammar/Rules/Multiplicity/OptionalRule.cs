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
    /// Requires either 0 or 1 rule instances, i.e, an optional rule
    /// </summary>
    public class OptionalRule : SyntaxRule<OptionalRule>
    {

        public OptionalRule(string RuleName, SyntaxRule Rule, string Description = null)
            : base(RuleName, stream(Rule), Description)
        {
            
        }

        public OptionalRule(SyntaxRule Rule, string Description = null)
            : base(string.Empty, stream(Rule), Description)
        {

        }

        /// <summary>
        /// The optional rule
        /// </summary>
        SyntaxRule Rule => Terms[0];

        protected override OptionalRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new OptionalRule(RuleName, Terms.Single(), Description);

        public override string ToString()
            => Rule is VerbatimRule ? $"{Rule}" :   $"[{Rule}]";
    }
}