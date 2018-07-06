//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlSelectBuilder<B, X>
        : SqlStatementBuilder<SqlSelectBuilder<B, X>, SqlSelectStatement>
            where B : SqlSelectBuilder<B, X>
    {
        protected SqlSelectBuilder()
        {

        }

        protected SqlSelectBuilder(IEnumerable<SqlColumnName> selection)
        {
            ColumnSelection.AddRange(selection);
        }

        MutableList<sxc.clause> Clauses { get; }
            = MutableList.Create<sxc.clause>();

        MutableList<sxc.order_by_expression> OrderByExpressions { get; }
            = MutableList.Create<sxc.order_by_expression>();

        MutableList<ISyntaxExpression> ColumnExpressions { get; }
            = MutableList.Create<ISyntaxExpression>();

        MutableList<ISyntaxExpression> GroupExpressions { get; }
            = MutableList.Create<ISyntaxExpression>();

        protected MutableList<SqlColumnName> ColumnSelection { get; }
            = MutableList.Create<SqlColumnName>();

        protected ModelOption<sxc.from_clause> from { get; set; }

        public Builder<SqlSelectBuilder<B, X>> Top(int n, bool percent = false, bool ties = false)
        {
            Clauses.Add(new top_clause(new integer_literal(n), percent, ties));
            return this;
        }

        protected Builder<SqlSelectBuilder<B, X>> Columns(IEnumerable<SqlColumnName> columns)
        {
            ColumnSelection.AddRange(columns);
            return this;
        }

        public Builder<SqlSelectBuilder<B, X>> From(SqlTableName table)
        {
            from = new from_clause(new from_table_or_view(table));
            return this;
        }

        public Builder<SqlSelectBuilder<B, X>> From(SqlVariableName source)
        {
            from = new from_clause(new from_table_variable(source));
            return this;
        }

        public Builder<SqlSelectBuilder<B, X>> From(SqlFunctionName source)
        {
            from = new from_clause(new from_udf(source));
            return this;
        }

        public Builder<SqlSelectBuilder<B, X>> From(SqlViewName source)
        {
            from = new from_clause(new from_table_or_view(source));
            return this;
        }

        public Builder<SqlSelectBuilder<B, X>> OrderBy(SqlColumnName c, sort_direction_kind? direction = null, string collation = null)
        {
            OrderByExpressions.Add(new SqlOrderByColummnExpression(c, direction, collation));
            return this;
        }

        public override SqlSelectStatement Complete()
        {
            var allClauses = MutableList.FromItems(Clauses);
            if (OrderByExpressions.Count != 0)
                allClauses.Add(new order_by_clause(OrderByExpressions.ToArray()));

            return new SqlSelectStatement(allClauses);
        }
    }


}