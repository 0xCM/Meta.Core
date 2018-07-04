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
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlSyntax;
    
    using ops = SqlSyntax.sqlops;
    using static sql;

    public static class SqlLogicExtensions
    {
        public static column_predicate Between(this SqlColumnName c, ISyntaxExpression lower, ISyntaxExpression upper)
          => new column_predicate(c, @bool(ops.BETWEEN, lower, upper));

        public static column_predicate Between(this SqlColumnName c, SqlParameterName lower, SqlParameterName upper)
            => c.Between(lower, upper);

        public static column_predicate Between(this SqlColumnName c, CoreDataValue lower, CoreDataValue upper)
            => c.Between(lower.ToSqlLiteral(), upper.ToSqlLiteral());

        public static column_predicate And(this SqlColumnName c, ISyntaxExpression left, ISyntaxExpression right)
            => new column_predicate(c, @bool(ops.AND, left, right));

        public static column_predicate Or(this SqlColumnName c, ISyntaxExpression left, ISyntaxExpression right)
            => new column_predicate(c, @bool(ops.OR, left, right));

        public static column_predicate Like(this SqlColumnName c, ISyntaxExpression x)
            => new column_predicate(c, @bool(ops.LIKE, x));

        public static column_predicate Not(this SqlColumnName c, ISyntaxExpression x)
            => new column_predicate(c, @bool(ops.NOT, x));
    }

}