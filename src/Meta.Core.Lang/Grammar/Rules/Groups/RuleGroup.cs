﻿//-------------------------------------------------------------------------------------------
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
    public class RuleGroup : RuleGroup<RuleGroup>
    {
        public RuleGroup(string RuleName, SyntaxRule Term, string Description = null)
            : base(RuleName, Term)
        {

        }

        public RuleGroup(SyntaxRule Term, string Description = null)
            : base(string.Empty, Term)
        {

        }

        protected override RuleGroup Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new RuleGroup(RuleName, Terms.Single(), Description);
    }
}