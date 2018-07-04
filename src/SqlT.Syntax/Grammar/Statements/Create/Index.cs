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
        partial class Statements
        {
            partial class Create
            {
                public static class Index
                {

                    public static SyntaxRule comparison_op
                        => define(group(IS | IS + NOT | comparison));

                    public static SyntaxRule comparison
                        => column_name + comparison_op + constant;

                    public static SyntaxRule disjunct
                        => define(column_name + IN + paren(+constant));

                    public static SyntaxRule conjunt
                        => choices(disjunct | comparison);

                    public static SyntaxRule filter_predicate
                        => define(
                            conjunt + maybe(AND + conjunt)
                            );

                    public static SyntaxRule relational_index_option
                        => choices(
                            assign(PAD_INDEX, on_or_off)
                          | assign(SORT_IN_TEMPDB, on_or_off)
                          | assign(IGNORE_DUP_KEY, on_or_off)
                          | assign(STATISTICS_NORECOMPUTE, on_or_off)
                          | assign(STATISTICS_INCREMENTAL, on_or_off)
                          | assign(DROP_EXISTING, on_or_off)
                          | assign(ONLINE, on_or_off)
                          | assign(ALLOW_ROW_LOCKS, on_or_off)
                          | assign(ALLOW_TABLE_LOCKS, on_or_off)
                            );
                }
            }
        }
    }
}