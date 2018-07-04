﻿//-------------------------------------------------------------------------------------------
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

    public static partial class SqlTFactory
    { 

        [SqlTBuilder]
        public static Option<SqlIndex> Model(this TSql.CreateColumnStoreIndexStatement src)
            => new SqlIndex
                (
                    IndexName: src.Name.Value,
                    TableName: src.OnName.ToTableName(),
                    PrimaryColumns: map(src.Columns, c => new SqlIndexColumn(c.FormatName())).ToArray(),
                    Clustered: src.Clustered.HasValue ? src.Clustered.Value : false,
                    DropExisting: src.DropExisting()
                );
    }
}