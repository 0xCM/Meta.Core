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
    /// Specifies a rule that requires an expression of the form "first = second"
    /// </summary>
    public class AssignmentRule : SyntaxRule<AssignmentRule>
    {
        AssignmentRule(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms, Description)
        { }

        public AssignmentRule(string RuleName, SyntaxRule first, SyntaxRule second, string Description = null)
            : base(RuleName, stream(first,second), Description)
        {

        }
        
        protected override string TermDelimiter
            => " = ";

        protected override AssignmentRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new AssignmentRule(RuleName, Terms, Description);
    }
}