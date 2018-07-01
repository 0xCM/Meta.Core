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
    /// Requires an expression of the form {Choice1 | ... | ChoiceN} where 
    /// Choice1...ChoiceN are determined by the names of the enumeration literals (or attributions thereof)
    /// defined for the the type <typeparamref name="E"/>
    /// </summary>
    /// <typeparam name="E">The enumeration type upon which the choices are based</typeparam>
    public class EnumSyntaxChoice<E> : ChoiceGroup
        where E : Enum
    {

        protected EnumSyntaxChoice(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms, Description)
        {

        }

        public EnumSyntaxChoice(string RuleName, string Description = null)
            : base(RuleName, grammar.oneOf(map(grammar.identifiers<E>(), id => new IdentifierRule(id))), Description)
        {

        }

        protected override ChoiceGroup Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new EnumSyntaxChoice<E>(RuleName, Terms, Description);
    }
}
