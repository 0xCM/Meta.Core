//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

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
