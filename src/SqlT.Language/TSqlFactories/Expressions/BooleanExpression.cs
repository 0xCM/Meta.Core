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
        public static TSql.BooleanExpression Not<T>(this T src)
            where T : TSql.BooleanExpression
                => src.TSqlNotExpression();

        [TSqlBuilder]
        public static TSql.BooleanExpression IsEmpty(this TSql.ScalarSubquery src)
            => src.Exists().Not();

        [TSqlBuilder]
        public static TSql.BooleanExpression Compare(this
            TSql.BooleanComparisonType src,
            TSql.ScalarExpression lhs,
            TSql.ScalarExpression rhs)
            => new TSql.BooleanComparisonExpression
            {
                ComparisonType = src,
                FirstExpression = lhs,
                SecondExpression = rhs
            };

    }
}