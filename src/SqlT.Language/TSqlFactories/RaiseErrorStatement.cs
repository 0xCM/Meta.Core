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

    using SqlT.Services;

    partial class TSqlFactory
    {
        public static TSql.RaiseErrorStatement RaiseError
            (
                string messageText,
                SqlSeverityLevel severity = SqlSeverityLevel.Level00,
                int state = 0,
                TSql.RaiseErrorOptions options = TSql.RaiseErrorOptions.NoWait
            ) => new TSql.RaiseErrorStatement
            {
                FirstParameter = messageText.TSqlStringLiteral(),
                SecondParameter = severity.TSqlIntegerLiteral(),
                ThirdParameter = state.TSqlIntegerLiteral(),
                RaiseErrorOptions = TSql.RaiseErrorOptions.NoWait
            };

    }


}
