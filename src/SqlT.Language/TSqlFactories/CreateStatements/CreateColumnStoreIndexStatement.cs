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
        [TSqlBuilder]
        public static TSql.CreateColumnStoreIndexStatement TSqlCreate(this SqlColumnStoreIndex src)
        {
            var idxKind = src.Clustered ? TSql.IndexTypeKind.Clustered : TSql.IndexTypeKind.NonClustered;
            var idxName = src.IndexName.UnqualifiedName.TSqlIdentifier(true);

            var cols = map(src.Columns, c => c.TSqlColumnRef());

            var idx = new TSql.CreateColumnStoreIndexStatement()
            {
                Clustered = src.Clustered,
                OnName = src.TableName.TSqlSchemaObjectName(),
                Name = idxName,
            };
            idx.Columns.AddRange(cols);

            if (src.DropExisting)
            {
                idx.IndexOptions.Add(new TSql.IndexStateOption()
                {
                    OptionKind = TSql.IndexOptionKind.DropExisting,
                    OptionState = TSql.OptionState.On
                });
            }

            return idx;
        }


    }
}