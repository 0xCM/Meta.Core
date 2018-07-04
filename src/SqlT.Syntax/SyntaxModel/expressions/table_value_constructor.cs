//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;

    using SqlT.Syntax;
    using SqlT.Core;

    using static metacore;
    using sx = Syntax.SqlSyntax;

    partial class SqlSyntax
    {
        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/queries/table-value-constructor-transact-sql
        /// </summary>
        /// <typeparam name="M"></typeparam>
        public abstract class table_value_constructor<M> : SyntaxExpression<M>
            where M : table_value_constructor<M>
        {
            public table_value_constructor(SqlDataFrame frame, SqlIdentifier Alias = null)
            {
                Rows = map(frame.Rows, row
                    => new row_value_expression(~CoreDataValue.FromObjects(row)));
                this.Alias = Alias;
            }

            public ReadOnlyList<row_value_expression> Rows { get; }

            public Option<SqlIdentifier> Alias { get; }
        }

        public sealed class table_value_constructor : table_value_constructor<table_value_constructor>
        {
            public table_value_constructor(SqlDataFrame frame, SqlIdentifier Alias = null)
                : base(frame, Alias)
            {
            }

        }

        public abstract class inline_table_expression<M, X> : table_value_constructor<M>
            where M : inline_table_expression<M, X>
        {
            public inline_table_expression(SqlDataFrame frame, SqlIdentifier Alias = null)
                : base(frame, Alias)
            {
            }

        }

    }

}
