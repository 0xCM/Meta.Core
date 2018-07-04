//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using Meta.Syntax;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using System;

    using static SqlT.Syntax.sql;

    using sxc = SqlT.Syntax.contracts;

    public static class PatternExtensions
    {

        public static ISyntaxExpression ToSqlExpression<T>(this SqlColumnInterval<T> ci)
            where T : struct, IComparable
        {
            var min = L(ci.Min);
            var max = L(ci.Max);
            var col = column(ci.ColumnName);
            if (ci.IsClosed)
                return between(col, min, max);

            var left = ci.MinInclusive
               ? gteq(col, min)
               : gt(col, min);

            var right = ci.MaxInclusive
                ? lteq(col, max)
                : lt(col, max);

            return and(left, right);
        }



    }
}
