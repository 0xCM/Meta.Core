//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    public class vForeignKeyColumn : vColumn, IForeignKeyColumn
    {
        public vForeignKeyColumn
            (
                ISchema ClientSchema,
                ITable ClientTable,
                IColumn ClientColumn,
                ISchema SupplierSchema,
                ITable SupplierTable,
                IColumn SupplierColumn,
                vType ColumnDataType,
                IForeignKeyColumn ForeignKeyColumn,
                IEnumerable<IExtendedProperty> Properties
            ) : base(ClientSchema, ClientTable, ClientColumn, ColumnDataType, Properties)

        {
            this.ClientSchema = ClientSchema;
            this.ClientTable = ClientTable;
            this.ClientColumn = ClientColumn;
            this.SupplierSchema = SupplierSchema;
            this.SupplierTable = SupplierTable;
            this.SupplierColumn = SupplierColumn;
            this.Subject = ForeignKeyColumn;
        }

        IForeignKeyColumn Subject { get; }

        ISchema ClientSchema { get; }

        ITable ClientTable { get; }

        IColumn ClientColumn { get; }

        ISchema SupplierSchema { get; }

        ITable SupplierTable { get; }

        IColumn SupplierColumn { get; }

        int IForeignKeyColumn.constraint_object_id
            => Subject.constraint_object_id;

        int IForeignKeyColumn.constraint_column_id
            => Subject.constraint_column_id;

        int IForeignKeyColumn.parent_object_id
            => Subject.parent_object_id;

        int IForeignKeyColumn.parent_column_id
            => Subject.parent_column_id;

        int IForeignKeyColumn.referenced_object_id
            => Subject.referenced_object_id;

        int IForeignKeyColumn.referenced_column_id
            => Subject.referenced_column_id;
    }
}