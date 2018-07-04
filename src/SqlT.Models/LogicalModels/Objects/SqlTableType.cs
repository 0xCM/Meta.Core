//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;




    [SqlElementType(SqlElementTypeNames.TableType)]
    public sealed class SqlTableType : SqlType<SqlTableType,SqlTableTypeName>, ISqlTableType
    {

        public  IReadOnlyList<SqlTableTypeColumn> Columns { get; }
        public Option<SqlUniqueConstraint> PrimaryKey { get; }

        

        public SqlTableType
        (
            SqlTableTypeName TypeName,
            IEnumerable<SqlTableTypeColumn> Columns,
            SqlUniqueConstraint PrimaryKey = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null
         )
            : base
            (
                  TypeName,
                  Properties: Properties,
                  Documentation: Documentation
            )
        {
            this.PrimaryKey = PrimaryKey;
            this.Columns = rolist(
                Columns.Select(c => 
                    new SqlTableTypeColumn
                    (
                        c.Name,
                        c.Position, 
                        c.DataTypeReference, 
                        this
                    )));
        }

        IReadOnlyList<ISqlColumn> ISqlColumnProvider.Columns 
            => Columns;

        IReadOnlyList<SqlColumnName> sxc.column_name_provider.ColumnNames
            => map(Columns, c => c.Name);

    }
}
