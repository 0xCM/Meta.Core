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
    using SqlT.Services;

    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.ProcedureParameter TSqlProcedureParameter(this SqlTableType model, string name)
            => new TSql.ProcedureParameter
            {
                DataType = model.TSqlReference(),
                Modifier = TSql.ParameterModifier.ReadOnly,
                VariableName = name.TSqlIdentifier(false)
            };
    }
}