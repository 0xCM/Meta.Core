//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    /// <summary>
    /// Represents a SQL foreign key column
    /// </summary>
    [SqlElementType(SqlElementTypeNames.ForeignKeyColumn)]
    public sealed class SqlForeignKeyColumn : SqlConstraintColumn<SqlForeignKeyColumn>
    {

        public SqlForeignKeyColumn(int OrdinalPosition, SqlTableColumn ClientColumn, SqlTableColumn SupplierColumn) 
            : base(ClientColumn)
        {
            this.OrdinalPosition = OrdinalPosition;
            this.ClientColumn = ClientColumn;
            this.SupplierColumn = SupplierColumn;
        }

        public int OrdinalPosition { get; }

        public SqlTableColumn ClientColumn { get; }

        public SqlTableColumn SupplierColumn { get; }

        public override string ToString()
            => $"({ClientColumn.Name},{SupplierColumn.Name})";
    }

    public sealed class SqlForeignKeyColumns : ReadOnlyList<SqlForeignKeyColumn>
    {

        public static implicit operator SqlForeignKeyColumn[] (SqlForeignKeyColumns items)
            => new SqlForeignKeyColumns(items);

        public static implicit operator SqlForeignKeyColumns(SqlForeignKeyColumn[] items)
            => new SqlForeignKeyColumns(items);

        public SqlForeignKeyColumns(IEnumerable<SqlForeignKeyColumn> items)
            : base(items,comma())
        { }
    }

}
