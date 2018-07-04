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

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = Syntax.SqlSyntax;

    partial class SqlSyntax
    {
        public abstract class order_by_expression<e> : SyntaxExpression<e>, sxc.order_by_expression
            where e : order_by_expression<e>
        {
            protected order_by_expression(column_ref column, sort_direction direction, string collation_name)
            {
                this.column = column;
                this.sort_direction = sort_direction;
                this.collation_name = collation_name;
            }

            public column_ref column { get; }

            public sort_direction sort_direction { get; }

            public string collation_name { get; }

            sort_direction_kind sxc.order_by_expression.sort_direction
                => sort_direction.selected_value == DESC 
                ? sort_direction_kind.Descending 
                : sort_direction_kind.Ascending;

            public override string ToString()
                => isBlank(collation_name)
                ? $"{column} {sort_direction}"
                : $"{column} collate {collation_name} {sort_direction}";

        }
    }

    public abstract class SqlOrderByExpression<T> : SyntaxExpression<T>, sxc.order_by_expression
        where T : SqlOrderByExpression<T>
    {
        protected SqlOrderByExpression(sort_direction_kind SortDirection, string CollationName)
        {
            this.sort_direction = SortDirection;
            this.collation_name = CollationName;
        }

        public sort_direction_kind sort_direction { get; }

        public string collation_name { get; }
    }

    public sealed class SqlOrderByColummnExpression : SqlOrderByExpression<SqlOrderByColummnExpression>
    {
        public SqlOrderByColummnExpression
            (SqlColumnName ColumnName,
            sort_direction_kind? SortDirection = null,
            string CollationName = null
            ) : base(SortDirection ?? sort_direction_kind.Ascending, CollationName ?? string.Empty)
        {
            this.ColumnName = ColumnName;
        }

        public SqlColumnName ColumnName { get; }

        public override string ToString()
            => isBlank(collation_name)
            ? $"{ColumnName} {sort_direction}"
            : $"{ColumnName} collate {collation_name} {sort_direction}";
    }


}
