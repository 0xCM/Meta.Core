//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;
    using System.Linq;


    using sx = Syntax.SqlSyntax;

    using static metacore;
    using kwt = SqlKeywordTypes;

    partial class sql
    {
        public static sx.left_join left(kwt.JOIN JOIN, 
            sx.table_source left_table, 
            sx.table_source right_table, 
            kwt.ON ON, 
            sx.search_condition join_criteria) 
                => new sx.left_join(left_table, right_table, join_criteria);

        public static sx.cross_join cross(kwt.JOIN JOIN,
            sx.table_source left_table,
            sx.table_source right_table)
                => new sx.cross_join(left_table, right_table);

        public static sx.inner_join inner(kwt.JOIN JOIN,
            sx.table_source left_table,
            sx.table_source right_table,
            kwt.ON ON,
            sx.search_condition join_criteria)
                => new sx.inner_join(left_table, right_table, join_criteria);

        public static sx.right_join right(kwt.JOIN JOIN,
            sx.table_source left_table,
            sx.table_source right_table,
            kwt.ON ON,
            sx.search_condition join_criteria)
                => new sx.right_join(left_table, right_table, join_criteria);

        public static sx.full_join full(kwt.JOIN JOIN,
            sx.table_source left_table,
            sx.table_source right_table,
            kwt.ON ON,
            sx.search_condition join_criteria)
                => new sx.full_join(left_table, right_table, join_criteria);
    }
}