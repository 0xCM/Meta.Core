//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Meta.Syntax;

    using SqlT.Core;

    using static SqlSyntax;
    using static metacore;    
    using static grammar;

    using sxc = contracts;
    using sx = SqlSyntax;
    using ops = SqlSyntax.sqlops;


    /// <summary>
    /// Requires the presence of an identifier
    /// </summary>
    public class IdentifierRule : SyntaxRule<IdentifierRule>
    {
        public IdentifierRule(string Name, string Description = null)
            : base(Name,Description)
        {

        }
        protected override IdentifierRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new IdentifierRule(RuleName, Description);
    }

    public static partial class SqlGrammar
    {
        public static SyntaxRule stringLiteral([CallerMemberName] string ruleName = null)
            => adjacent(ascii.SingleQuote, slot(ruleName), ascii.DoubleQuote);



        /// <summary>
        /// Defines directory_name placeholder
        /// </summary>
        public static SyntaxRule directory_name
            => stringLiteral();

        /// <summary>
        /// Defines a slot for a database name
        /// </summary>
        public static SyntaxRule database_name
            => slot();

        /// <summary>
        /// Defines a schema_name placeholder
        /// </summary>
        public static SyntaxRule schema_name
            => slot();

        /// <summary>
        /// Defines a (potentially) database-qualified object name placeholder
        /// </summary>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public static SyntaxRule object_name([CallerMemberName] string ruleName = null)
            => maybe(
                    (database_name + AsciiSymbol.Period + maybe(schema_name) + AsciiSymbol.Period)
                  | schema_name + AsciiSymbol.Period
                ) + name(ruleName);

        /// <summary>
        /// Defines a table_name placeholder
        /// </summary>
        public static SyntaxRule table_name
            => object_name();

        /// <summary>
        /// Defines a slot for a column name
        /// </summary>
        public static SyntaxRule column_name
            => slot();

        /// <summary>
        /// Defines a slot for a collation name
        /// </summary>
        public static SyntaxRule collation_name
            => slot();

        /// <summary>
        /// Defines a slot for a constraint name
        /// </summary>
        public static SyntaxRule constraint_name
            => slot();

        public static SyntaxRule not_for_replication
            => NOT + FOR + REPLICATION;

        /// <summary>
        /// Defines a slot for a constant value
        /// </summary>
        public static SyntaxRule constant
            => slot();

        public static SyntaxRule on_or_off
            => group(ON | OFF);

        public static SyntaxRule Or
            => token(ops.OR);

        
        public static SyntaxRule Eq
            => token(ops.EQ);

        public static SyntaxRule Neq
            => token(ops.NEQ);

        public static SyntaxRule Gt
            => token(ops.GT);

        public static SyntaxRule GtEq
            => token(ops.GTEQ);

        public static SyntaxRule Lt
            => token(ops.LT);

        public static SyntaxRule LtEq
            => token(ops.LTEQ);

        public static SyntaxRule Ngt
            => token(ops.NGT);

        public static SyntaxRule Nlt
            => token(ops.NLT);

        public static SyntaxRule comparison
            => Eq | Neq | Gt | GtEq | Lt | LtEq | Ngt | Nlt;


        /// <summary>
        /// Specifies a sequence of the form <paramref name="keyword"/> { ON | OFF}
        /// </summary>
        /// <param name="keyword">The assignee</param>
        /// <returns></returns>
        public static SyntaxRule toggle(IKeyword keyword, [CallerMemberName] string ruleName = null)
            => new Spaced(ruleName, stream<SyntaxRule>(token(keyword), new RuleGroup(sx.ON | sx.OFF)));

        /// <summary>
        /// Specifies a rule that requires the presence of a non-qualified name of any sort
        /// </summary>
        /// <param name="ruleName">The name given to the rule</param>
        /// <returns></returns>
        public static IdentifierRule name([CallerMemberName] string ruleName = null)
            => new IdentifierRule(ruleName);

        public static partial class LanguageElements
        {

        }

        public static partial class Queries
        {

        }

        public static partial class Choices
        {

            /// <summary>
            /// Recursively discovers <see cref="ChoiceGroup"/> definitions
            /// </summary>
            /// <param name="DeclaringType">The type under inspection</param>
            /// <returns></returns>
            static IEnumerable<ChoiceGroup> All(ClrClass DeclaringType)
            {
                foreach (var p in ClrClass.Get(DeclaringType).DeclaredPublicStaticProperties)
                    yield return p.GetValue<ChoiceGroup>(null);

                foreach (var nested in DeclaringType.NestedClasses)
                    foreach (var x in All(nested))
                        yield return x;

            }

            /// <summary>
            /// Discovers all defined choice groups
            /// </summary>
            /// <returns></returns>
            public static IEnumerable<ChoiceGroup> All()
                => All(typeof(Choices));

            public static partial class QueryStore
            {

            }

        }

        public static partial class DataTypes
        {

        }

        public static partial class Functions
        {

        }

        public static partial class Statements
        {
            public static partial class Alter
            {

            }

            public static partial class Create
            {

            }

        }
    }
}