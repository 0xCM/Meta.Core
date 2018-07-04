//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {

        [TSqlBuilder]
        static TSql.BooleanBinaryExpression And(this TSql.BooleanExpression x, TSql.BooleanExpression y)
            => new TSql.BooleanBinaryExpression
            {
                BinaryExpressionType = TSql.BooleanBinaryExpressionType.And,
                FirstExpression = x,
                SecondExpression = y
            };

        /// <summary>
        /// Combines a list of boolean expressions in a disjunction
        /// </summary>
        /// <typeparam name="T">The boolean expression type</typeparam>
        /// <param name="expressions">The expressions to combine</param>
        /// <returns></returns>
        [TSqlBuilder]
        public static TSql.BooleanBinaryExpression And<T>(this IReadOnlyList<T> expressions)
            where T : TSql.BooleanExpression

        {
            if(expressions.Count < 2)
                throw new ArgumentException($"At least two expressions are required");

            if (expressions.Count == 2)
            {
                return new TSql.BooleanBinaryExpression
                {
                    BinaryExpressionType = TSql.BooleanBinaryExpressionType.And,
                    FirstExpression = expressions.First(),
                    SecondExpression = expressions.Second()
                };
            }
            else
            {
                return new TSql.BooleanBinaryExpression
                {
                    BinaryExpressionType = TSql.BooleanBinaryExpressionType.And,
                    FirstExpression = expressions.First(),
                    SecondExpression = expressions.Skip(1).And()
                };
            }
        }

        [TSqlBuilder]
        public static TSql.BooleanBinaryExpression And<T>(this IEnumerable<T> tsql)
            where T : TSql.BooleanExpression
                => tsql.ToReadOnlyList().And();
    }
}