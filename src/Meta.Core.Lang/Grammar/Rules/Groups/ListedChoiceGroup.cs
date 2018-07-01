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
    /// Requires an expression of the form {Choice1 | ... | ChoiceN} where each
    /// Choice1...ChoiceN is respectively determined by items 
    /// defined in a typed item list containing items of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The item type upon which the choices are based</typeparam>
    public class ListedChoiceGroup<T> : ChoiceGroup
       
    {
        protected ListedChoiceGroup(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms)
        {

        }

        public ListedChoiceGroup(string RuleName, ITypedItemList<T> ItemList, string Description = null)
            : base(RuleName, grammar.oneOf(map(ItemList, item => new IdentifierRule(item.ToString()))))
        {

        }

        protected override ChoiceGroup Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new ListedChoiceGroup<T>(RuleName, Terms, Description);
    }
}