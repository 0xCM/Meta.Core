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

    public static class AlterDatabase
    {
        static TSql.Identifier DatabaseNameVar
            = "[$(DatabaseName)]".TSqlIdentifier();

        public static TSql.AlterDatabaseAddFileGroupStatement TSqlAddFileGroup(this SqlFileGroup model)
        {
            return new TSql.AlterDatabaseAddFileGroupStatement
            {
                DatabaseName = DatabaseNameVar,
                FileGroup = model.Name.TSqlIdentifier()
            };
        }


        public static TSql.AlterDatabaseSetStatement TSqlAlterDatabseSet(this SqlDatabase model)
        {
            var tSql = new TSql.AlterDatabaseSetStatement
            {
                DatabaseName = DatabaseNameVar,
            };

            model.DatabaseOptions.recovery_model.onValue(recovery => tSql.Options.Add(recovery.TSqlOption()));
            return tSql;
        }
    }
}
