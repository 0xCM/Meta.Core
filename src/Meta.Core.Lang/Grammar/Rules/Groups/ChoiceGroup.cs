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
    /// Requires an expression of the form {Choice1 | ... | ChoiceN}
    /// </summary>
    public class ChoiceGroup : RuleGroup<ChoiceGroup>
    {
        protected ChoiceGroup(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms, Description)
        {

        }

        public ChoiceGroup(string RuleName, OneOf Choices, string Description = null)
            : base(RuleName ?? Choices.RuleName, Choices, Description)
        {

        }

        protected override ChoiceGroup Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new ChoiceGroup(RuleName, Terms, Description);

    }


}