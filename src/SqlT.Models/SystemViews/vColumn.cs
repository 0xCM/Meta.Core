//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    public class vColumn : vSystemElement, IColumn
    {
        static IReadOnlyDictionary<string, IExtendedProperty> PropertyIndex(IColumn subject, IEnumerable<IExtendedProperty> properties)
        {
            try
            {
                return properties.Where
                (
                    x =>
                    x.major_id == subject.object_id
                 && x.minor_id == subject.column_id
                ).ToDictionary(x => x.name);
            }
            catch (Exception)
            {
                return new Dictionary<string, IExtendedProperty>();
            }
        }

        public vColumn(ISchema schema, ISystemObject parent, IColumn column, vType dataType, IEnumerable<IExtendedProperty> properties)
            : base(column.name, PropertyIndex(column, properties), parent.is_user_defined)
        {
            this.schema = schema;
            this.parent = parent;
            this.column = column;
            this.vDataType = dataType;
        }

        public vColumn(ISchema schema, ITableType parent, IColumn column, vType dataType, IReadOnlyDictionary<string, IExtendedProperty> properties)
            : base(column.name, properties, parent.is_user_defined)
        {
            this.schema = schema;
            this.parentTableType = parent;
            this.column = column;
            this.vDataType = dataType;
        }

        ISystemObject parent { get; }

        ITableType parentTableType { get; }

        IColumn column { get; }

        ISchema schema { get; }

        vType vDataType { get; }

        SqlName ParentQualifiedName
            => ParentName + Name;

        public int ParentSchemaId
            => schema.schema_id;

        public int ParentId
            => parent != null
            ? parent.object_id
            : parentTableType.type_table_object_id;

        public TypeReference DataType 
            => new TypeReference 
            (
                ReferencedType: vDataType,
                IsNullable: column.is_nullable ?? false,
                MaxDataLength: column.max_length,
                Precision: column.precision,
                Scale: column.scale
            );
           
        public bool IsNullable
            => column.is_nullable ?? false;

        public sxc.ISqlObjectName ParentName
            => new SqlObjectName(schema.name, parent != null ? parent.name : parentTableType.name);

        public override string ToString()
            => $"{ParentQualifiedName}";

        #region IColumn
        int IColumn.object_id  => column.object_id;
        int IColumn.column_id  => column.column_id;
        string IColumn.collation_name  => column.collation_name;
        int IColumn.default_object_id => column.default_object_id;
        bool IColumn.is_ansi_padded => column.is_ansi_padded;
        bool? IColumn.is_column_set => column.is_column_set;

        bool IColumn.is_computed
        {
            get
            {
                return column.is_computed;
            }
        }

        bool? IColumn.is_dts_replicated
        {
            get
            {
                return column.is_dts_replicated;
            }
        }

        bool IColumn.is_filestream
        {
            get
            {
                return column.is_filestream;
            }
        }

        bool IColumn.is_identity
        {
            get
            {
                return column.is_identity;
            }
        }

        bool? IColumn.is_merge_published
        {
            get
            {
                return column.is_merge_published;
            }
        }

        bool? IColumn.is_non_sql_subscribed
        {
            get
            {
                return column.is_non_sql_subscribed;
            }
        }

        bool? IColumn.is_nullable
        {
            get
            {
                return column.is_nullable;
            }
        }

        bool? IColumn.is_replicated
        {
            get
            {
                return column.is_replicated;
            }
        }

        bool IColumn.is_rowguidcol
        {
            get
            {
                return column.is_rowguidcol;
            }
        }

        bool? IColumn.is_sparse
        {
            get
            {
                return column.is_sparse;
            }
        }

        bool IColumn.is_xml_document
        {
            get
            {
                return column.is_xml_document;
            }
        }

        short IColumn.max_length
        {
            get
            {
                return column.max_length;
            }
        }

        byte IColumn.precision
        {
            get
            {
                return column.precision;
            }
        }

        int IColumn.rule_object_id
        {
            get
            {
                return column.rule_object_id;
            }
        }

        byte IColumn.scale
        {
            get
            {
                return column.scale;
            }
        }

        byte IColumn.system_type_id
        {
            get
            {
                return column.system_type_id;
            }
        }

        int IColumn.user_type_id
        {
            get
            {
                return column.user_type_id;
            }
        }

        int IColumn.xml_collection_id
        {
            get
            {
                return column.xml_collection_id;
            }
        }
        #endregion IColumn
    }
}