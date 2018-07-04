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

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.BooleanComparisonExpression TSqlBooleanComparison(
            this SqlColumnProxySelection left,
            TSql.BooleanComparisonType type,
            SqlColumnProxySelection right)
                => new TSql.BooleanComparisonExpression
                {
                    ComparisonType = type,
                    FirstExpression = left.TSqlColumnRef(),
                    SecondExpression = right.TSqlColumnRef()
                };
    }
}