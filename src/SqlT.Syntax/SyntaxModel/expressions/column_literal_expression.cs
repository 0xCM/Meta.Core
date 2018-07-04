//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;

    using sx = Syntax.SqlSyntax;

    partial class SqlSyntax
    {


        public abstract class column_literal_expression<M> : SyntaxExpression<M>
            where M : column_literal_expression<M>
        {
            public column_literal_expression(SqlColumnName ColumnName, scalar_value LiteralValue)
            {
                this.ColumnName = ColumnName;
                this.LiteralValue = LiteralValue;
            }

            public SqlColumnName ColumnName { get; }

            public scalar_value LiteralValue { get; }

            public override string ToString()
                => $"{LiteralValue} as {ColumnName}";
        }

        public class column_literal_expression : column_literal_expression<column_literal_expression>
        {
            public column_literal_expression(SqlColumnName ColumnName, scalar_value LiteralValue)
                : base(ColumnName, LiteralValue)
            {

            }



        }



    }

}