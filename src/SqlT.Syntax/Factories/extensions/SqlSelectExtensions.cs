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
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlSyntax;

    using sxc = contracts;

    using sx = SqlSyntax;
    using static sql;

    public static partial class SqlSelectExtensiona
    {
        public static select_statement SelectAllFrom(this SqlTableName table)
           => select(STAR, from(table));

        public static select_statement SelectFrom(this IEnumerable<SqlColumnName> columns, SqlTableName source)
            => select(columns.ToSelectList(), from(source));

        public static select_statement SelectFrom(this IEnumerable<SqlColumnName> columns, SqlViewName source)
            => select(columns.ToSelectList(), from(source));

        public static select_statement SelectFrom(this IEnumerable<SqlColumnName> columns, table_alias source)
            => select(columns.ToSelectList(), from(source));

        public static select_statement SelectFrom(this IEnumerable<SqlColumnName> columns, table_source source)
            => select(columns.ToSelectList(), from(source));

        public static column_list ToColumnList(this IEnumerable<SqlColumnName> columns)
           => new column_list(array(columns));

        public static select_list ToSelectList(this IEnumerable<SqlColumnName> columns)
            => columns.ToColumnList();

        public static select_list ToSelectList(this column_list list)
            => list.ColumnNames().ToSelectList();

    }

}