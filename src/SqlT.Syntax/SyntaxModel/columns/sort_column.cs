//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using sx = SqlSyntax;

    partial class SqlSyntax
    {
        public sealed class sort_column : SyntaxExpression<sort_column>, IBinaryExpression<column_ref, sort_direction>
        {
            public sort_column(SqlColumnName column, sort_direction direction)
            {
                this.column = column;
                this.direction = direction;
            }

            ISyntaxExpression IBinaryExpression.Left 
                => column;

            ISyntaxExpression IBinaryExpression.Right
                => direction;

            public column_ref column { get; }

            public sort_direction direction { get; }

            sx.column_ref IBinaryExpression<column_ref, sort_direction>.Left
                => column;

            sx.sort_direction IBinaryExpression<sx.column_ref, sx.sort_direction>.Right
                => direction;

            public override string ToString()
                => $"{column} {direction}";
        }
    }

}