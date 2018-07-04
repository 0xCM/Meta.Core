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
    using SqlT.Syntax;

    using sx = SqlT.Syntax.SqlSyntax;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static class SqlDatabaseTranslation
    {

        [TSqlBuilder]
        public static TSql.CreateDatabaseStatement TSqlCreate(this SqlDatabase model)
        {
            


            var tSql = new TSql.CreateDatabaseStatement()
            {
                DatabaseName = model.Name.TSqlIdentifier(),
                 Collation = model.Collation.MapValueOrDefault(x => x.TSqlIdentifier()),
                  Containment = model.DatabaseOptions.containment_type.map(x => x.TSqlOption(), () => null),                                                     
            };



            
            return tSql;
        }
    }
}
