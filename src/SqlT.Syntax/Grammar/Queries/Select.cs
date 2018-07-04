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
    using SqlT.Core;
    using Meta.Syntax;

    using static SqlSyntax;
    using ops = SqlSyntax.sqlops;

    using static metacore;
    using static grammar;

    partial class SqlGrammar
    {
        partial class Queries
        {
            public static SyntaxRule expression
                => slot();

            public static SyntaxRule string_expression
                => slot();

            public static SyntaxRule escape_character
                => stringLiteral();

            public static SyntaxRule subquery
                => slot();

            public static SyntaxRule contains_search_condition
                => stringLiteral();

            public static SyntaxRule freetext_string
                => stringLiteral();

            public static SyntaxRule predicate
                = choices(
                    (expression + group(comparison) + expression)
                    | string_expression + maybe(NOT) + LIKE + string_expression + maybe(ESCAPE + escape_character)
                    | expression + maybe(NOT) + BETWEEN + expression + AND + expression
                    | expression + IS + maybe(NOT) + NULL
                    | CONTAINS + paren(group(column_name | ascii.Star), contains_search_condition)
                    | FREETEXT + paren(group(column_name | ascii.Star), freetext_string)
                    | expression + maybe(NOT) + IN + paren(subquery | +expression)
                    | expression + group(comparison)
                                 + group(ALL | SOME | ANY)
                                 + paren(subquery)
                    | EXISTS + paren(subquery)
                    );

            public static SyntaxRule search_condition
                => choices(
                    maybe(NOT) + predicate | paren(recurse()))
                    + (+maybe(group(AND | OR) + maybe(NOT) + group(predicate | paren(recurse()))));
                

            

            public static class Select
            {

            }


        }

    }

}