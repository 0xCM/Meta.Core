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
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using static metacore;

    public static class SqlTableTypeTranslation
    {

        public static TSql.CreateTypeTableStatement TSqlCreate(this SqlTableType model)
        {
            var tdef = new TSql.TableDefinition();

            foreach (var col in model.Columns)
                tdef.ColumnDefinitions.Add(col.TSqlColumnDef());

            if (model.PrimaryKey)
            {
                var xpk = model.PrimaryKey.Require();
                var tpk = new TSql.UniqueConstraintDefinition()
                {
                    ConstraintIdentifier = xpk.ObjectName.UnqualifiedName.TSqlIdentifier(),
                    IsPrimaryKey = true,

                };
                tdef.TableConstraints.Add(tpk);
                foreach (var xKeyCol in xpk.Columns)
                {
                    tpk.Columns.Add(new TSql.ColumnWithSortOrder()
                    {
                        Column = xKeyCol.TSqlColumnRef()
                    });
                }

            }

            var table = new TSql.CreateTypeTableStatement
            {
                Definition = tdef,
                Name = model.TSqlSchemaObjectName()

            };

            return table;

        }


    }
}
