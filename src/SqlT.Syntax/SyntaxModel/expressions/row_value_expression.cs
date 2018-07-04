//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using Meta.Syntax;

    partial class SqlSyntax
    {
        public abstract class row_value_expression<M> : SyntaxExpression<M>
            where M : row_value_expression<M>
        {
            public row_value_expression(params CoreDataValue[] CellValues)
            {
                this.CellValues = CellValues.ToReadOnlyList();
            }

            public ReadOnlyList<CoreDataValue> CellValues { get; }

        }

        public abstract class row_value_expression<M, X> : row_value_expression<M>
            where M : row_value_expression<M, X>
        {
            public row_value_expression(params CoreDataValue[] CellValues)
                : base(CellValues)
            {

            }

        }

        public sealed class row_value_expression : row_value_expression<row_value_expression>
        {
            public row_value_expression(params CoreDataValue[] CellValues)
                : base(CellValues)
            {
            }

        }
    }
}