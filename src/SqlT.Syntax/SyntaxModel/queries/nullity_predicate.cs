//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;

    using kwt = SqlKeywordTypes;
    using kpt = SqlKeyPhraseTypes;

    partial class SqlSyntax
    {

        public sealed class nullity_expression : BooleanExpression<nullity_expression>
        {

            public static implicit operator nullity_predicate(nullity_expression x)
                => new nullity_predicate(x);

            public nullity_expression(kwt.NULL NULL)
            {
                this.nullity = NULL;
            }

            public nullity_expression(kpt.NOTNULL NOTNULL)
            {
                this.nullity = NOTNULL;
            }

            public du<kwt.NULL, kpt.NOTNULL> nullity { get; }

            public override string ToString()
                => $"is {nullity}";
        }

        public sealed class nullity_predicate : predicate<nullity_expression>
        {
            public static implicit operator nullity_expression(nullity_predicate p)
                => p.expression;

            public nullity_predicate(nullity_expression e)
                : base(e)
            { }
        }

    }

}