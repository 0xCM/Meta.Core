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
    using System.Diagnostics;
    using SqlT.Core;
    using SqlT.Models;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class SqlTFactory
    {

        [SqlTBuilder]
        public static Option<SqlTable> SqlTModel(this TSql.CreateTableStatement src)
        {
            var columns = src.Definition.ColumnDefinitions.Mapi((i, c) => c.ModelTableColumn(i));
            var pk = src.Definition
                         .TableConstraints
                         .OfType<TSql.UniqueConstraintDefinition>()
                         .Where(constraint => constraint.IsPrimaryKey)
                         .Map(constraint => constraint.ModelPrimaryKey(columns))
                         .SingleOrDefault();
            return new SqlTable(src.SchemaObjectName.ToTableName(), columns, pk);
        }
    }
}
