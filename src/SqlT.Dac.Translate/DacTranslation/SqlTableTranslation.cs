//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;
    using DacM = Microsoft.SqlServer.Dac.Model;
    using sxc = SqlT.Syntax.contracts;

    public static class SqlTableTranslation
    {
        public static IEnumerable<ISqlElementSpecScript> SpecifyTableScripts(this DacM.TSqlModel src, ISqlGenerationContext GC)
        {
            foreach (var o in src.GetObjects(DacM.DacQueryScopes.UserDefined, DacM.Table.TypeClass))
            {
                var script = o.TrySpecifyScript();
                if (script)
                {
                    var type = GC.FindElementType(o.ObjectType.Name);
                    yield return SqlElementSpecScript.Create(o.Name.SpecifyElementName(), type, script.ValueOrDefault());
                }
            }
        }

        [SqlTBuilder]
        public static IEnumerable<sxc.ISqlObjectName> SpecifyTableNames(this DacM.TSqlModel dsql)
            => map(dsql.GetObjects(DacM.DacQueryScopes.UserDefined, DacM.Table.TypeClass), o => o.Name.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlTableName SpecifyTableName(this DacX.TSqlTable dsql)
            => new SqlTableName(dsql.SpecifyObjectName());

        [SqlTBuilder]
        public static IReadOnlyList<SqlColumnName> GetColumnNames(this DacX.TSqlTable dsql)
        {
            var names = new List<SqlColumnName>();
            var pk = dsql.PrimaryKeyConstraints.SingleOrDefault();
            if (pk != null)
            {
                foreach (var keycol in pk.Columns)
                {
                    names.Add(new SqlColumnName(dsql.SpecifyTableName(), keycol.GetLocalName()));
                }
            }
            return names;
        }

        [SqlTBuilder]
        public static IEnumerable<SqlTable> SpecifyTable(this DacX.TSqlTypedModel src, SqlPropertyIndex xpidx)
        {
            var tables = src.GetDacObjects<DacX.TSqlTable>();
            foreach (var table in tables)
            {
                var sqlcols = table.SpecifyColumns();
                var sqlPK = none<SqlPrimaryKey>();
                var pk = table.PrimaryKeyConstraints.SingleOrDefault();
                if (pk != null)
                {
                    var columns = new List<SqlPrimaryKeyColumn>();
                    var colnames = table.GetColumnNames();
                    foreach (var colname in colnames)
                        columns.Add(new SqlPrimaryKeyColumn(sqlcols.Single(col => col.Name == colname.UnqualifiedName)));
                    sqlPK = new SqlPrimaryKey(pk.SpecifyPrimaryKeyName(), columns);
                }


                yield return new SqlTable
                    (
                        TableName: new SqlTableName(table.SpecifyObjectName()),
                        Columns: sqlcols,
                        PrimaryKey: sqlPK.ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(table)
                    );
            }
        }
    }
}