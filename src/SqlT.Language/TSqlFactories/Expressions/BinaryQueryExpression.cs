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
    using SqlT.Models;
    using SqlT.Core;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.BinaryQueryExpression Except<L, R>(this L Left, R Right)
            where L : TSql.QueryExpression
            where R : TSql.QueryExpression
            => new TSql.BinaryQueryExpression
            {
                BinaryQueryExpressionType = TSql.BinaryQueryExpressionType.Except,
                FirstQueryExpression = Left,
                SecondQueryExpression = Right
            };

        [TSqlBuilder]
        public static TSql.BinaryQueryExpression Union<L, R>(this L Left, R Right)
            where L : TSql.QueryExpression
            where R : TSql.QueryExpression
            => new TSql.BinaryQueryExpression
            {
                BinaryQueryExpressionType = TSql.BinaryQueryExpressionType.Union,
                FirstQueryExpression = Left,
                SecondQueryExpression = Right
            };

        [TSqlBuilder]
        public static TSql.BinaryQueryExpression Intersect<L, R>(this L Left, R Right)
            where L : TSql.QueryExpression
            where R : TSql.QueryExpression
            => new TSql.BinaryQueryExpression
            {
                BinaryQueryExpressionType = TSql.BinaryQueryExpressionType.Intersect,
                FirstQueryExpression = Left,
                SecondQueryExpression = Right
            };

    }

}

