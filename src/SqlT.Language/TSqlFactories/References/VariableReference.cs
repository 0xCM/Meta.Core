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

    public static partial class TSqlFactory
    {
        public static TSql.VariableReference TSqlVariableRef(this SqlName src)
            => new TSql.VariableReference
            {
                Name = src
            };

        public static TSql.VariableTableReference TSqlVariableTableRef(this SqlName src, string alias = null)
            => new TSql.VariableTableReference
            {
                Variable = src.TSqlVariableRef(),
                Alias = alias?.TSqlIdentifier(false),

            };

        [TSqlBuilder]
        public static TSql.VariableReference TSqlReference(this SqlVariableDeclaration x)
            => new TSql.VariableReference()
            {
                Name = x.VariableName
            };     
    }
}