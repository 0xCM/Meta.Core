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
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using static SqlSyntax;

    public partial class sql
    {
        public static select_clause select()
                    => new select_clause(new select_list(STAR));

        public static select_clause select(select_list list)
                    => new select_clause(list);

        public static select_clause select(column_list list)
                    => new select_clause(list);

        public static select_clause select(selected_item item, params selected_item[] items)
            => new select_clause(new select_list(stream(item, items)));
        
        public static select_clause select(top_clause top, params selected_item[] items)
            => new select_clause(new select_list(items), top);

        public static select_clause select(kwt.DISTINCT DISTINCT, params selected_item[] items)
            => new select_clause(new select_list(items), distinct: DISTINCT);

        public static select_statement select(select_list selection, from_clause from)
            => select(selection, () => from, null);

        public static select_list column_select_list(params string[] names)
            => new select_list(map(names, n => new selected_item(new SqlColumnName(n))));
        
        public static select_statement select(select_list selection, params table_source[] sources)
            => select(selection, () => from(sources), null);

        static select_statement select(select_list selection, Func<from_clause> from,
            Func<where_clause> where) 
                => select(selection, from?.Invoke(), where?.Invoke());

        public static select_statement select(column_list selection, from_clause from, 
            where_clause where) 
                => new select_statement(select(selection), from, where);

        public static select_statement select(select_clause selection, from_clause from = null,
            where_clause where = null) 
                => new select_statement(selection, from, where);

    }
}

