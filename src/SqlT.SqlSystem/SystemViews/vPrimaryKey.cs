//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;
    using System;
    using sxc = SqlT.Syntax.contracts;

    public class vPrimaryKey : vObject, IPrimaryKey, IColumnProvider
    {



        public vPrimaryKey
            (
                ISchema schema, 
                ITable table, 
                ISystemObject pko,
                IIndex index, 
                IEnumerable<vPrimaryKeyColumn> keyColumns, 
                IEnumerable<IExtendedProperty> properties
            )
            : base(schema, pko, properties)
        {
            this.index = index;
            this.Table = table;
            this.Schema = schema;
            this.KeyColumns = rolist(keyColumns);

        }

        ISchema Schema { get; }

        ITable Table { get; }

        IIndex index { get; }

        public IReadOnlyList<vPrimaryKeyColumn> KeyColumns { get; }

        public SqlTableName TableName 
            => new SqlTableName(SchemaName, Table.name);

        IReadOnlyList<vColumn> IColumnProvider.Columns
            => KeyColumns;

        public override sxc.ISqlObjectName ObjectName
            => new SqlPrimaryKeyName(SchemaName, Name);

        #region IIndex
        int IIndex.object_id => index.object_id;
        int IIndex.index_id => index.index_id;
        byte IIndex.type => index.type;
        string IIndex.type_desc => index.type_desc;
        bool? IIndex.is_unique => index.is_unique;
        int? IIndex.data_space_id => index.data_space_id;
        bool? IIndex.ignore_dup_key => index.ignore_dup_key;
        bool? IIndex.is_primary_key => index.is_primary_key;
        bool? IIndex.is_unique_constraint => index.is_unique_constraint;
        byte IIndex.fill_factor => index.fill_factor;
        bool? IIndex.is_padded => index.is_padded;
        bool? IIndex.is_disabled => index.is_disabled;
        bool? IIndex.is_hypothetical => index.is_hypothetical;
        bool? IIndex.allow_row_locks => index.allow_row_locks;
        bool? IIndex.allow_page_locks => index.allow_page_locks;
        bool? IIndex.has_filter => index.has_filter;
        string IIndex.filter_definition => index.filter_definition;
        int? IIndex.compression_delay => index.compression_delay;
        #endregion

   }

}