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
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static class SqlAlterIndexTranslation
    {

        public static TSql.AlterIndexType TSqlValue(this SqlAlterIndexAction src)
        {
            var type = TSql.AlterIndexType.Disable;
            switch (src)
            {
                case SqlAlterIndexAction.Disable:
                    type = TSql.AlterIndexType.Disable;
                    break;
                case SqlAlterIndexAction.Rebuild:
                    type = TSql.AlterIndexType.Rebuild;
                    break;
                case SqlAlterIndexAction.Reorganize:
                    type = TSql.AlterIndexType.Reorganize;
                    break;

            }
            return type;

        }

        [TSqlBuilder]
        public static TSql.AlterIndexStatement TSqlStatement(this SqlAlterIndex src)
            => new TSql.AlterIndexStatement
            {
                OnName = src.TableName.TSqlSchemaObjectName(),
                Name = src.IndexName.TSqlIdentifier(),
                AlterIndexType = src.AlterAction.TSqlValue()
            }; 
        

    }
}
