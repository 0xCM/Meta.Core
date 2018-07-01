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
    /// Requires an expression of the form {Term}
    /// </summary>
    public abstract class RuleGroup<R> : SyntaxRule<R>
       where R : RuleGroup<R>
    {

        protected RuleGroup(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms, Description)
        { }

        protected RuleGroup(string RuleName, SyntaxRule Term, string Description = null)
            : this(RuleName, stream(Term), Description)
        {

        }

        protected override string LeftBodyDelimiter
            => lbrace();

        protected override string RightBodyDelimiter
            => rbrace();
    }

}