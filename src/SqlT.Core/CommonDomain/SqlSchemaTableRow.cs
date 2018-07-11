//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    [SqlNamedResult(nameof(SqlSchemaTableRow))]
    public class SqlSchemaTableRow : SqlTabularProxy<SqlSchemaTableRow>
    {
        [SqlColumn("ColumnName", 0)]
        public string ColumnName { get; set; }

        [SqlColumn("ColumnOrdinal", 1)]
        public System.Int32 ColumnOrdinal { get; set; }

        [SqlColumn("ColumnSize", 2)]
        public System.Int32 ColumnSize { get; set; }

        [SqlColumn("NumericPrecision", 3)]
        public byte NumericPrecision { get; set; }

        [SqlColumn("NumericScale", 4)]
        public byte NumericScale { get; set; }

        [SqlColumn("IsUnique", 5)]
        public bool IsUnique { get; set; }

        [SqlColumn("IsKey", 6)]
        public bool? IsKey { get; set; }

        [SqlColumn("BaseServerName", 7)]
        public string BaseServerName { get; set; }

        [SqlColumn("BaseCatalogName", 8)]
        public string BaseCatalogName { get; set; }

        [SqlColumn("BaseColumnName", 9)]
        public string BaseColumnName { get; set; }

        [SqlColumn("BaseSchemaName", 10)]
        public string BaseSchemaName { get; set; }

        [SqlColumn("BaseTableName", 11)]
        public string BaseTableName { get; set; }

        [SqlColumn("DataType", 12)]
        public Type DataType { get; set; }

        [SqlColumn("AllowDBNull", 13)]
        public bool AllowDBNull { get; set; }

        [SqlColumn("ProviderType", 14)]
        public System.Int32 ProviderType { get; set; }

        [SqlColumn("IsAliased", 15)]
        public bool? IsAliased { get; set; }

        [SqlColumn("IsExpression", 16)]
        public bool? IsExpression { get; set; }

        [SqlColumn("IsIdentity", 17)]
        public bool IsIdentity { get; set; }

        [SqlColumn("IsAutoIncrement", 18)]
        public bool IsAutoIncrement { get; set; }

        [SqlColumn("IsRowVersion", 19)]
        public bool IsRowVersion { get; set; }

        [SqlColumn("IsHidden", 20)]
        public bool? IsHidden { get; set; }

        [SqlColumn("IsLong", 21)]
        public bool IsLong { get; set; }

        [SqlColumn("IsReadOnly", 22)]
        public bool IsReadOnly { get; set; }

        [SqlColumn("ProviderSpecificDataType", 23)]
        public Type ProviderSpecificDataType { get; set; }

        [SqlColumn("DataTypeName", 24)]
        public string DataTypeName { get; set; }

        [SqlColumn("XmlSchemaCollectionDatabase", 25)]
        public string XmlSchemaCollectionDatabase { get; set; }

        [SqlColumn("XmlSchemaCollectionOwningSchema", 26)]
        public string XmlSchemaCollectionOwningSchema { get; set; }

        [SqlColumn("XmlSchemaCollectionCollectionName", 27)]
        public string XmlSchemaCollectionCollectionName { get; set; }

        [SqlColumn("UdtAssemblyQualifiedName", 28)]
        public string UdtAssemblyQualifiedName { get; set; }

        [SqlColumn("NonVersionedProviderType", 29)]
        public System.Int32 NonVersionedProviderType { get; set; }

        [SqlColumn("IsColumnSet", 30)]
        public bool IsColumnSet { get; set; }

    }
}
