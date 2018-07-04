//This file was generated at 5/12/2018 8:42:24 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.SqlStore
{
    using System;
    using SqlT.Types;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlStoreSequenceNames
    {
        public readonly static SqlSequenceName SqlStoreKey = "[SqlStore].[SqlStoreKey]";
        public readonly static SqlSequenceName StoreKeySequence = "[SqlStore].[StoreKeySequence]";
    }

    public sealed class SqlStoreTableNames
    {
        public readonly static SqlTableName BackupDescription = "[SqlStore].[BackupDescription]";
        public readonly static SqlTableName ColumnComparision = "[SqlStore].[ColumnComparision]";
        public readonly static SqlTableName ColumnGroupMembership = "[SqlStore].[ColumnGroupMembership]";
        public readonly static SqlTableName ColumnGroupType = "[SqlStore].[ColumnGroupType]";
        public readonly static SqlTableName ColumnRoleAssignment = "[SqlStore].[ColumnRoleAssignment]";
        public readonly static SqlTableName ColumnRoleType = "[SqlStore].[ColumnRoleType]";
        public readonly static SqlTableName ComparisionOperator = "[SqlStore].[ComparisionOperator]";
        public readonly static SqlTableName Database = "[SqlStore].[Database]";
        public readonly static SqlTableName DataType = "[SqlStore].[DataType]";
        public readonly static SqlTableName FieldListDefinition = "[SqlStore].[FieldListDefinition]";
        public readonly static SqlTableName ForeignKey = "[SqlStore].[ForeignKey]";
        public readonly static SqlTableName GeneratedArtifactType = "[SqlStore].[GeneratedArtifactType]";
        public readonly static SqlTableName GenerationProfile = "[SqlStore].[GenerationProfile]";
        public readonly static SqlTableName GenerationProfileType = "[SqlStore].[GenerationProfileType]";
        public readonly static SqlTableName NativeDataType = "[SqlStore].[NativeDataType]";
        public readonly static SqlTableName Schema = "[SqlStore].[Schema]";
        public readonly static SqlTableName SqlProxyDefinitionStore = "[SqlStore].[SqlProxyDefinitionStore]";
        public readonly static SqlTableName Table = "[SqlStore].[Table]";
        public readonly static SqlTableName TableColumn = "[SqlStore].[TableColumn]";
        public readonly static SqlTableName TableColumnFacet = "[SqlStore].[TableColumnFacet]";
        public readonly static SqlTableName TableFacet = "[SqlStore].[TableFacet]";
        public readonly static SqlTableName TableQuery = "[SqlStore].[TableQuery]";
        public readonly static SqlTableName TableQueryColumn = "[SqlStore].[TableQueryColumn]";
        public readonly static SqlTableName TableType = "[SqlStore].[TableType]";
    }

    [SqlTable("SqlStore", "ForeignKey")]
    public partial class ForeignKey : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeySchema", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ForeignKeySchema
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeyName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ForeignKeyName
        {
            get;
            set;
        }

        [SqlColumn("ClientTableSchema", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientTableSchema
        {
            get;
            set;
        }

        [SqlColumn("ClientTableName", 6), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientTableName
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableSchema", 7), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableName", 8), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierTableName
        {
            get;
            set;
        }

        [SqlColumn("KeyColumnId", 9), SqlTypeFacets("int", false)]
        public int KeyColumnId
        {
            get;
            set;
        }

        [SqlColumn("ClientColumnName", 10), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientColumnName
        {
            get;
            set;
        }

        [SqlColumn("ClientColummnId", 11), SqlTypeFacets("int", false)]
        public int ClientColummnId
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnName", 12), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierColumnName
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnId", 13), SqlTypeFacets("int", false)]
        public int SupplierColumnId
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 14), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public ForeignKey()
        {
        }

        public ForeignKey(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ForeignKeySchema = (string)items[3];
            ForeignKeyName = (string)items[4];
            ClientTableSchema = (string)items[5];
            ClientTableName = (string)items[6];
            SupplierTableSchema = (string)items[7];
            SupplierTableName = (string)items[8];
            KeyColumnId = (int)items[9];
            ClientColumnName = (string)items[10];
            ClientColummnId = (int)items[11];
            SupplierColumnName = (string)items[12];
            SupplierColumnId = (int)items[13];
            Documentation = (string)items[14];
        }

        public ForeignKey(int StoreKey, string ServerName, string DatabaseName, string ForeignKeySchema, string ForeignKeyName, string ClientTableSchema, string ClientTableName, string SupplierTableSchema, string SupplierTableName, int KeyColumnId, string ClientColumnName, int ClientColummnId, string SupplierColumnName, int SupplierColumnId, string Documentation)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ForeignKeySchema = ForeignKeySchema;
            this.ForeignKeyName = ForeignKeyName;
            this.ClientTableSchema = ClientTableSchema;
            this.ClientTableName = ClientTableName;
            this.SupplierTableSchema = SupplierTableSchema;
            this.SupplierTableName = SupplierTableName;
            this.KeyColumnId = KeyColumnId;
            this.ClientColumnName = ClientColumnName;
            this.ClientColummnId = ClientColummnId;
            this.SupplierColumnName = SupplierColumnName;
            this.SupplierColumnId = SupplierColumnId;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, ForeignKeySchema, ForeignKeyName, ClientTableSchema, ClientTableName, SupplierTableSchema, SupplierTableName, KeyColumnId, ClientColumnName, ClientColummnId, SupplierColumnName, SupplierColumnId, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ForeignKeySchema = (string)items[3];
            ForeignKeyName = (string)items[4];
            ClientTableSchema = (string)items[5];
            ClientTableName = (string)items[6];
            SupplierTableSchema = (string)items[7];
            SupplierTableName = (string)items[8];
            KeyColumnId = (int)items[9];
            ClientColumnName = (string)items[10];
            ClientColummnId = (int)items[11];
            SupplierColumnName = (string)items[12];
            SupplierColumnId = (int)items[13];
            Documentation = (string)items[14];
        }
    }

    [SqlTable("SqlStore", "ColumnRoleAssignment")]
    public partial class ColumnRoleAssignment : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ObjectSchema", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectSchema
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnRole", 6), SqlTypeFacets("nvarchar", false, 75)]
        public string ColumnRole
        {
            get;
            set;
        }

        public ColumnRoleAssignment()
        {
        }

        public ColumnRoleAssignment(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ObjectSchema = (string)items[3];
            ObjectName = (string)items[4];
            ColumnName = (string)items[5];
            ColumnRole = (string)items[6];
        }

        public ColumnRoleAssignment(int StoreKey, string ServerName, string DatabaseName, string ObjectSchema, string ObjectName, string ColumnName, string ColumnRole)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ObjectSchema = ObjectSchema;
            this.ObjectName = ObjectName;
            this.ColumnName = ColumnName;
            this.ColumnRole = ColumnRole;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName, ColumnRole };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ObjectSchema = (string)items[3];
            ObjectName = (string)items[4];
            ColumnName = (string)items[5];
            ColumnRole = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "TableType")]
    public partial class TableType : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        public TableType()
        {
        }

        public TableType(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            ObjectName = (string)items[4];
        }

        public TableType(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string ObjectName)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.ObjectName = ObjectName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, ObjectName };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            ObjectName = (string)items[4];
        }
    }

    [SqlTable("SqlStore", "DataType")]
    public partial class DataType : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("IsUserDefined", 5), SqlTypeFacets("bit", false)]
        public bool IsUserDefined
        {
            get;
            set;
        }

        [SqlColumn("MaxLength", 6), SqlTypeFacets("smallint", false)]
        public short MaxLength
        {
            get;
            set;
        }

        [SqlColumn("Precision", 7), SqlTypeFacets("tinyint", false)]
        public byte Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 8), SqlTypeFacets("tinyint", false)]
        public byte Scale
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 9), SqlTypeFacets("bit", true)]
        public bool? IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsClrType", 10), SqlTypeFacets("bit", false)]
        public bool IsClrType
        {
            get;
            set;
        }

        public DataType()
        {
        }

        public DataType(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TypeName = (string)items[4];
            IsUserDefined = (bool)items[5];
            MaxLength = (short)items[6];
            Precision = (byte)items[7];
            Scale = (byte)items[8];
            IsNullable = (bool?)items[9];
            IsClrType = (bool)items[10];
        }

        public DataType(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string TypeName, bool IsUserDefined, short MaxLength, byte Precision, byte Scale, bool? IsNullable, bool IsClrType)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.IsUserDefined = IsUserDefined;
            this.MaxLength = MaxLength;
            this.Precision = Precision;
            this.Scale = Scale;
            this.IsNullable = IsNullable;
            this.IsClrType = IsClrType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, TypeName, IsUserDefined, MaxLength, Precision, Scale, IsNullable, IsClrType };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TypeName = (string)items[4];
            IsUserDefined = (bool)items[5];
            MaxLength = (short)items[6];
            Precision = (byte)items[7];
            Scale = (byte)items[8];
            IsNullable = (bool?)items[9];
            IsClrType = (bool)items[10];
        }
    }

    [SqlTable("SqlStore", "ColumnRoleType")]
    public partial class ColumnRoleType : SqlTableProxy, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public ColumnRoleType()
        {
        }

        public ColumnRoleType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public ColumnRoleType(int TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("SqlStore", "BackupDescription")]
    public partial class BackupDescription : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("HostName", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostPath", 2), SqlTypeFacets("varchar", false, 500)]
        public string HostPath
        {
            get;
            set;
        }

        [SqlColumn("LogicalName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string LogicalName
        {
            get;
            set;
        }

        [SqlColumn("PhysicalName", 4), SqlTypeFacets("nvarchar", false, 260)]
        public string PhysicalName
        {
            get;
            set;
        }

        [SqlColumn("Type", 5), SqlTypeFacets("char", false, 1)]
        public string Type
        {
            get;
            set;
        }

        [SqlColumn("FileGroupName", 6), SqlTypeFacets("nvarchar", true, 128)]
        public string FileGroupName
        {
            get;
            set;
        }

        [SqlColumn("Size", 7), SqlTypeFacets("numeric", false, 20, 0)]
        public decimal Size
        {
            get;
            set;
        }

        [SqlColumn("MaxSize", 8), SqlTypeFacets("numeric", false, 20, 0)]
        public decimal MaxSize
        {
            get;
            set;
        }

        [SqlColumn("FileId", 9), SqlTypeFacets("bigint", false)]
        public long FileId
        {
            get;
            set;
        }

        [SqlColumn("CreateLSN", 10), SqlTypeFacets("numeric", false, 25, 0)]
        public decimal CreateLSN
        {
            get;
            set;
        }

        [SqlColumn("DropLSN", 11), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? DropLSN
        {
            get;
            set;
        }

        [SqlColumn("UniqueId", 12), SqlTypeFacets("uniqueidentifier", false)]
        public Guid UniqueId
        {
            get;
            set;
        }

        [SqlColumn("ReadOnlyLSN", 13), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? ReadOnlyLSN
        {
            get;
            set;
        }

        [SqlColumn("ReadWriteLSN", 14), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? ReadWriteLSN
        {
            get;
            set;
        }

        [SqlColumn("BackupSizeInBytes", 15), SqlTypeFacets("bigint", false)]
        public long BackupSizeInBytes
        {
            get;
            set;
        }

        [SqlColumn("SourceBlockSize", 16), SqlTypeFacets("bigint", false)]
        public long SourceBlockSize
        {
            get;
            set;
        }

        [SqlColumn("FileGroupId", 17), SqlTypeFacets("int", false)]
        public int FileGroupId
        {
            get;
            set;
        }

        [SqlColumn("LogGroupGUID", 18), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? LogGroupGUID
        {
            get;
            set;
        }

        [SqlColumn("DifferentialBaseLSN", 19), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? DifferentialBaseLSN
        {
            get;
            set;
        }

        [SqlColumn("DifferentialBaseGUID", 20), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? DifferentialBaseGUID
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 21), SqlTypeFacets("bit", false)]
        public bool IsReadOnly
        {
            get;
            set;
        }

        [SqlColumn("IsPresent", 22), SqlTypeFacets("bit", false)]
        public bool IsPresent
        {
            get;
            set;
        }

        [SqlColumn("TDEThumbprint", 23), SqlTypeFacets("varbinary", true, 32)]
        public Byte[] TDEThumbprint
        {
            get;
            set;
        }

        [SqlColumn("SnapshotURL", 24), SqlTypeFacets("nvarchar", true, 360)]
        public string SnapshotURL
        {
            get;
            set;
        }

        public BackupDescription()
        {
        }

        public BackupDescription(object[] items)
        {
            StoreKey = (int)items[0];
            HostName = (string)items[1];
            HostPath = (string)items[2];
            LogicalName = (string)items[3];
            PhysicalName = (string)items[4];
            Type = (string)items[5];
            FileGroupName = (string)items[6];
            Size = (decimal)items[7];
            MaxSize = (decimal)items[8];
            FileId = (long)items[9];
            CreateLSN = (decimal)items[10];
            DropLSN = (decimal?)items[11];
            UniqueId = (Guid)items[12];
            ReadOnlyLSN = (decimal?)items[13];
            ReadWriteLSN = (decimal?)items[14];
            BackupSizeInBytes = (long)items[15];
            SourceBlockSize = (long)items[16];
            FileGroupId = (int)items[17];
            LogGroupGUID = (Guid?)items[18];
            DifferentialBaseLSN = (decimal?)items[19];
            DifferentialBaseGUID = (Guid?)items[20];
            IsReadOnly = (bool)items[21];
            IsPresent = (bool)items[22];
            TDEThumbprint = (Byte[])items[23];
            SnapshotURL = (string)items[24];
        }

        public BackupDescription(int StoreKey, string HostName, string HostPath, string LogicalName, string PhysicalName, string Type, string FileGroupName, decimal Size, decimal MaxSize, long FileId, decimal CreateLSN, decimal? DropLSN, Guid UniqueId, decimal? ReadOnlyLSN, decimal? ReadWriteLSN, long BackupSizeInBytes, long SourceBlockSize, int FileGroupId, Guid? LogGroupGUID, decimal? DifferentialBaseLSN, Guid? DifferentialBaseGUID, bool IsReadOnly, bool IsPresent, Byte[] TDEThumbprint, string SnapshotURL)
        {
            this.StoreKey = StoreKey;
            this.HostName = HostName;
            this.HostPath = HostPath;
            this.LogicalName = LogicalName;
            this.PhysicalName = PhysicalName;
            this.Type = Type;
            this.FileGroupName = FileGroupName;
            this.Size = Size;
            this.MaxSize = MaxSize;
            this.FileId = FileId;
            this.CreateLSN = CreateLSN;
            this.DropLSN = DropLSN;
            this.UniqueId = UniqueId;
            this.ReadOnlyLSN = ReadOnlyLSN;
            this.ReadWriteLSN = ReadWriteLSN;
            this.BackupSizeInBytes = BackupSizeInBytes;
            this.SourceBlockSize = SourceBlockSize;
            this.FileGroupId = FileGroupId;
            this.LogGroupGUID = LogGroupGUID;
            this.DifferentialBaseLSN = DifferentialBaseLSN;
            this.DifferentialBaseGUID = DifferentialBaseGUID;
            this.IsReadOnly = IsReadOnly;
            this.IsPresent = IsPresent;
            this.TDEThumbprint = TDEThumbprint;
            this.SnapshotURL = SnapshotURL;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, HostName, HostPath, LogicalName, PhysicalName, Type, FileGroupName, Size, MaxSize, FileId, CreateLSN, DropLSN, UniqueId, ReadOnlyLSN, ReadWriteLSN, BackupSizeInBytes, SourceBlockSize, FileGroupId, LogGroupGUID, DifferentialBaseLSN, DifferentialBaseGUID, IsReadOnly, IsPresent, TDEThumbprint, SnapshotURL };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            HostName = (string)items[1];
            HostPath = (string)items[2];
            LogicalName = (string)items[3];
            PhysicalName = (string)items[4];
            Type = (string)items[5];
            FileGroupName = (string)items[6];
            Size = (decimal)items[7];
            MaxSize = (decimal)items[8];
            FileId = (long)items[9];
            CreateLSN = (decimal)items[10];
            DropLSN = (decimal?)items[11];
            UniqueId = (Guid)items[12];
            ReadOnlyLSN = (decimal?)items[13];
            ReadWriteLSN = (decimal?)items[14];
            BackupSizeInBytes = (long)items[15];
            SourceBlockSize = (long)items[16];
            FileGroupId = (int)items[17];
            LogGroupGUID = (Guid?)items[18];
            DifferentialBaseLSN = (decimal?)items[19];
            DifferentialBaseGUID = (Guid?)items[20];
            IsReadOnly = (bool)items[21];
            IsPresent = (bool)items[22];
            TDEThumbprint = (Byte[])items[23];
            SnapshotURL = (string)items[24];
        }
    }

    [SqlTable("SqlStore", "ColumnGroupType")]
    public partial class ColumnGroupType : SqlTableProxy, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public ColumnGroupType()
        {
        }

        public ColumnGroupType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public ColumnGroupType(int TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("SqlStore", "ColumnGroupMembership")]
    public partial class ColumnGroupMembership : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ObjectSchema", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectSchema
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("GroupTypeName", 6), SqlTypeFacets("nvarchar", false, 75)]
        public string GroupTypeName
        {
            get;
            set;
        }

        public ColumnGroupMembership()
        {
        }

        public ColumnGroupMembership(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ObjectSchema = (string)items[3];
            ObjectName = (string)items[4];
            ColumnName = (string)items[5];
            GroupTypeName = (string)items[6];
        }

        public ColumnGroupMembership(int StoreKey, string ServerName, string DatabaseName, string ObjectSchema, string ObjectName, string ColumnName, string GroupTypeName)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ObjectSchema = ObjectSchema;
            this.ObjectName = ObjectName;
            this.ColumnName = ColumnName;
            this.GroupTypeName = GroupTypeName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName, GroupTypeName };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            ObjectSchema = (string)items[3];
            ObjectName = (string)items[4];
            ColumnName = (string)items[5];
            GroupTypeName = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "NativeDataType")]
    public partial class NativeDataType : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("MaxLength", 2), SqlTypeFacets("int", true)]
        public int? MaxLength
        {
            get;
            set;
        }

        [SqlColumn("Precision", 3), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 4), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 5), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsClrType", 6), SqlTypeFacets("bit", false)]
        public bool IsClrType
        {
            get;
            set;
        }

        public NativeDataType()
        {
        }

        public NativeDataType(object[] items)
        {
            StoreKey = (int)items[0];
            TypeName = (string)items[1];
            MaxLength = (int?)items[2];
            Precision = (byte?)items[3];
            Scale = (byte?)items[4];
            IsNullable = (bool)items[5];
            IsClrType = (bool)items[6];
        }

        public NativeDataType(int StoreKey, string TypeName, int? MaxLength, byte? Precision, byte? Scale, bool IsNullable, bool IsClrType)
        {
            this.StoreKey = StoreKey;
            this.TypeName = TypeName;
            this.MaxLength = MaxLength;
            this.Precision = Precision;
            this.Scale = Scale;
            this.IsNullable = IsNullable;
            this.IsClrType = IsClrType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, TypeName, MaxLength, Precision, Scale, IsNullable, IsClrType };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            TypeName = (string)items[1];
            MaxLength = (int?)items[2];
            Precision = (byte?)items[3];
            Scale = (byte?)items[4];
            IsNullable = (bool)items[5];
            IsClrType = (bool)items[6];
        }
    }

    [SqlTable("SqlStore", "Database")]
    public partial class Database : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseType
        {
            get;
            set;
        }

        public Database()
        {
        }

        public Database(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
        }

        public Database(int StoreKey, string ServerName, string DatabaseName, string DatabaseType)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, DatabaseType };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
        }
    }

    [SqlTable("SqlStore", "TableColumn")]
    public partial class TableColumn : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnId", 6), SqlTypeFacets("int", false)]
        public int ColumnId
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 7), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 8), SqlTypeFacets("nvarchar", false, 128)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 9), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsIdentity", 10), SqlTypeFacets("bit", false)]
        public bool IsIdentity
        {
            get;
            set;
        }

        [SqlColumn("Length", 11), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 12), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 13), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("ComputationExpression", 14), SqlTypeFacets("nvarchar", true, 250)]
        public string ComputationExpression
        {
            get;
            set;
        }

        [SqlColumn("ComputationPersisted", 15), SqlTypeFacets("bit", true)]
        public bool? ComputationPersisted
        {
            get;
            set;
        }

        [SqlColumn("ColumnRole", 16), SqlTypeFacets("nvarchar", true, 75)]
        public string ColumnRole
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 17), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public TableColumn()
        {
        }

        public TableColumn(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            ColumnName = (string)items[5];
            ColumnId = (int)items[6];
            ColumnPosition = (int)items[7];
            DataTypeName = (string)items[8];
            IsNullable = (bool)items[9];
            IsIdentity = (bool)items[10];
            Length = (int?)items[11];
            Precision = (byte?)items[12];
            Scale = (byte?)items[13];
            ComputationExpression = (string)items[14];
            ComputationPersisted = (bool?)items[15];
            ColumnRole = (string)items[16];
            Documentation = (string)items[17];
        }

        public TableColumn(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string TableName, string ColumnName, int ColumnId, int ColumnPosition, string DataTypeName, bool IsNullable, bool IsIdentity, int? Length, byte? Precision, byte? Scale, string ComputationExpression, bool? ComputationPersisted, string ColumnRole, string Documentation)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.ColumnName = ColumnName;
            this.ColumnId = ColumnId;
            this.ColumnPosition = ColumnPosition;
            this.DataTypeName = DataTypeName;
            this.IsNullable = IsNullable;
            this.IsIdentity = IsIdentity;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
            this.ComputationExpression = ComputationExpression;
            this.ComputationPersisted = ComputationPersisted;
            this.ColumnRole = ColumnRole;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, TableName, ColumnName, ColumnId, ColumnPosition, DataTypeName, IsNullable, IsIdentity, Length, Precision, Scale, ComputationExpression, ComputationPersisted, ColumnRole, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            ColumnName = (string)items[5];
            ColumnId = (int)items[6];
            ColumnPosition = (int)items[7];
            DataTypeName = (string)items[8];
            IsNullable = (bool)items[9];
            IsIdentity = (bool)items[10];
            Length = (int?)items[11];
            Precision = (byte?)items[12];
            Scale = (byte?)items[13];
            ComputationExpression = (string)items[14];
            ComputationPersisted = (bool?)items[15];
            ColumnRole = (string)items[16];
            Documentation = (string)items[17];
        }
    }

    [SqlTable("SqlStore", "Schema")]
    public partial class Schema : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 4), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public Schema()
        {
        }

        public Schema(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            Documentation = (string)items[4];
        }

        public Schema(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string Documentation)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            Documentation = (string)items[4];
        }
    }

    [SqlTable("SqlStore", "Table")]
    public partial class Table : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("FileGroupName", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string FileGroupName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 6), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public Table()
        {
        }

        public Table(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            FileGroupName = (string)items[5];
            Documentation = (string)items[6];
        }

        public Table(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string TableName, string FileGroupName, string Documentation)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.FileGroupName = FileGroupName;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, TableName, FileGroupName, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            FileGroupName = (string)items[5];
            Documentation = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "ComparisionOperator")]
    public partial class ComparisionOperator : SqlTableProxy
    {
        [SqlColumn("Name", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string Name
        {
            get;
            set;
        }

        [SqlColumn("Symbol", 1), SqlTypeFacets("nvarchar", false, 5)]
        public string Symbol
        {
            get;
            set;
        }

        public ComparisionOperator()
        {
        }

        public ComparisionOperator(object[] items)
        {
            Name = (string)items[0];
            Symbol = (string)items[1];
        }

        public ComparisionOperator(string Name, string Symbol)
        {
            this.Name = Name;
            this.Symbol = Symbol;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Name, Symbol };
        }

        public override void SetItemArray(object[] items)
        {
            Name = (string)items[0];
            Symbol = (string)items[1];
        }
    }

    [SqlTable("SqlStore", "SqlProxyDefinitionStore")]
    public partial class SqlProxyDefinitionStore : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("AssemblyDesignator", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceNode", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 6), SqlTypeFacets("nvarchar", false, 0)]
        public string ProfileText
        {
            get;
            set;
        }

        public SqlProxyDefinitionStore()
        {
        }

        public SqlProxyDefinitionStore(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }

        public SqlProxyDefinitionStore(int StoreKey, string AssemblyDesignator, string ProfileName, string SourceNode, string SourceDatabase, string TargetAssembly, string ProfileText)
        {
            this.StoreKey = StoreKey;
            this.AssemblyDesignator = AssemblyDesignator;
            this.ProfileName = ProfileName;
            this.SourceNode = SourceNode;
            this.SourceDatabase = SourceDatabase;
            this.TargetAssembly = TargetAssembly;
            this.ProfileText = ProfileText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, AssemblyDesignator, ProfileName, SourceNode, SourceDatabase, TargetAssembly, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "TableFacet")]
    public partial class TableFacet : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("FacetName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string FacetName
        {
            get;
            set;
        }

        [SqlColumn("FacetValue", 6), SqlTypeFacets("nvarchar", true, 250)]
        public string FacetValue
        {
            get;
            set;
        }

        public TableFacet()
        {
        }

        public TableFacet(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            FacetName = (string)items[5];
            FacetValue = (string)items[6];
        }

        public TableFacet(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string TableName, string FacetName, string FacetValue)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.FacetName = FacetName;
            this.FacetValue = FacetValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, TableName, FacetName, FacetValue };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            FacetName = (string)items[5];
            FacetValue = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "ColumnComparision")]
    public partial class ColumnComparision : SqlTableProxy
    {
        [SqlColumn("ComparisonId", 0), SqlTypeFacets("int", false)]
        public int ComparisonId
        {
            get;
            set;
        }

        [SqlColumn("ColumnId", 1), SqlTypeFacets("int", false)]
        public int ColumnId
        {
            get;
            set;
        }

        [SqlColumn("ComparisonPosition", 2), SqlTypeFacets("int", false)]
        public int ComparisonPosition
        {
            get;
            set;
        }

        [SqlColumn("Junction", 3), SqlTypeFacets("nvarchar", true, 5)]
        public string Junction
        {
            get;
            set;
        }

        [SqlColumn("ComparisonOp", 4), SqlTypeFacets("nvarchar", false, 5)]
        public string ComparisonOp
        {
            get;
            set;
        }

        [SqlColumn("Operand", 5), SqlTypeFacets("sql_variant", false)]
        public Object Operand
        {
            get;
            set;
        }

        public ColumnComparision()
        {
        }

        public ColumnComparision(object[] items)
        {
            ComparisonId = (int)items[0];
            ColumnId = (int)items[1];
            ComparisonPosition = (int)items[2];
            Junction = (string)items[3];
            ComparisonOp = (string)items[4];
            Operand = (Object)items[5];
        }

        public ColumnComparision(int ComparisonId, int ColumnId, int ComparisonPosition, string Junction, string ComparisonOp, Object Operand)
        {
            this.ComparisonId = ComparisonId;
            this.ColumnId = ColumnId;
            this.ComparisonPosition = ComparisonPosition;
            this.Junction = Junction;
            this.ComparisonOp = ComparisonOp;
            this.Operand = Operand;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ComparisonId, ColumnId, ComparisonPosition, Junction, ComparisonOp, Operand };
        }

        public override void SetItemArray(object[] items)
        {
            ComparisonId = (int)items[0];
            ColumnId = (int)items[1];
            ComparisonPosition = (int)items[2];
            Junction = (string)items[3];
            ComparisonOp = (string)items[4];
            Operand = (Object)items[5];
        }
    }

    [SqlTable("SqlStore", "TableColumnFacet")]
    public partial class TableColumnFacet : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("FacetName", 6), SqlTypeFacets("nvarchar", false, 128)]
        public string FacetName
        {
            get;
            set;
        }

        [SqlColumn("FacetValue", 7), SqlTypeFacets("nvarchar", true, 150)]
        public string FacetValue
        {
            get;
            set;
        }

        public TableColumnFacet()
        {
        }

        public TableColumnFacet(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            ColumnName = (string)items[5];
            FacetName = (string)items[6];
            FacetValue = (string)items[7];
        }

        public TableColumnFacet(int StoreKey, string ServerName, string DatabaseName, string SchemaName, string TableName, string ColumnName, string FacetName, string FacetValue)
        {
            this.StoreKey = StoreKey;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.ColumnName = ColumnName;
            this.FacetName = FacetName;
            this.FacetValue = FacetValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, ServerName, DatabaseName, SchemaName, TableName, ColumnName, FacetName, FacetValue };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            ColumnName = (string)items[5];
            FacetName = (string)items[6];
            FacetValue = (string)items[7];
        }
    }

    [SqlTable("SqlStore", "GenerationProfileType")]
    public partial class GenerationProfileType : SqlTableProxy, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public GenerationProfileType()
        {
        }

        public GenerationProfileType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public GenerationProfileType(int TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("SqlStore", "TableQueryColumn")]
    public partial class TableQueryColumn : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("QueryId", 1), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 2), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 3), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        public TableQueryColumn()
        {
        }

        public TableQueryColumn(object[] items)
        {
            StoreKey = (int)items[0];
            QueryId = (int)items[1];
            ColumnPosition = (int)items[2];
            ColumnName = (string)items[3];
            ColumnAlias = (string)items[4];
        }

        public TableQueryColumn(int StoreKey, int QueryId, int ColumnPosition, string ColumnName, string ColumnAlias)
        {
            this.StoreKey = StoreKey;
            this.QueryId = QueryId;
            this.ColumnPosition = ColumnPosition;
            this.ColumnName = ColumnName;
            this.ColumnAlias = ColumnAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, QueryId, ColumnPosition, ColumnName, ColumnAlias };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            QueryId = (int)items[1];
            ColumnPosition = (int)items[2];
            ColumnName = (string)items[3];
            ColumnAlias = (string)items[4];
        }
    }

    [SqlTable("SqlStore", "GenerationProfile")]
    public partial class GenerationProfile : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("AssemblyDesignator", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceNode", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 6), SqlTypeFacets("nvarchar", false, 0)]
        public string ProfileText
        {
            get;
            set;
        }

        public GenerationProfile()
        {
        }

        public GenerationProfile(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }

        public GenerationProfile(int StoreKey, string AssemblyDesignator, string ProfileName, string SourceNode, string SourceDatabase, string TargetAssembly, string ProfileText)
        {
            this.StoreKey = StoreKey;
            this.AssemblyDesignator = AssemblyDesignator;
            this.ProfileName = ProfileName;
            this.SourceNode = SourceNode;
            this.SourceDatabase = SourceDatabase;
            this.TargetAssembly = TargetAssembly;
            this.ProfileText = ProfileText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, AssemblyDesignator, ProfileName, SourceNode, SourceDatabase, TargetAssembly, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }
    }

    [SqlTable("SqlStore", "TableQuery")]
    public partial class TableQuery : SqlTableProxy
    {
        [SqlColumn("QueryId", 0), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("QueryName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 2), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 3), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        public TableQuery()
        {
        }

        public TableQuery(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
        }

        public TableQuery(int QueryId, string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias)
        {
            this.QueryId = QueryId;
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryId, QueryName, TableCatalog, TableSchema, TableName, TableAlias };
        }

        public override void SetItemArray(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
        }
    }

    [SqlTable("SqlStore", "GeneratedArtifactType")]
    public partial class GeneratedArtifactType : SqlTableProxy, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public GeneratedArtifactType()
        {
        }

        public GeneratedArtifactType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public GeneratedArtifactType(int TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("SqlStore", "FieldListDefinition")]
    public partial class FieldListDefinition : SqlTableProxy
    {
        [SqlColumn("StoreKey", 0), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("AssemblyDesignator", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("ListName", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string ListName
        {
            get;
            set;
        }

        [SqlColumn("SourceTableSchema", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string SourceTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SourceTableName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string SourceTableName
        {
            get;
            set;
        }

        [SqlColumn("IdentifierColumn", 6), SqlTypeFacets("nvarchar", false, 128)]
        public string IdentifierColumn
        {
            get;
            set;
        }

        [SqlColumn("TableTypeSchema", 7), SqlTypeFacets("nvarchar", true, 128)]
        public string TableTypeSchema
        {
            get;
            set;
        }

        [SqlColumn("TableTypeName", 8), SqlTypeFacets("nvarchar", true, 128)]
        public string TableTypeName
        {
            get;
            set;
        }

        [SqlColumn("TypedIdentifierType", 9), SqlTypeFacets("nvarchar", true, 75)]
        public string TypedIdentifierType
        {
            get;
            set;
        }

        [SqlColumn("IdentifierValueColumn", 10), SqlTypeFacets("nvarchar", true, 128)]
        public string IdentifierValueColumn
        {
            get;
            set;
        }

        public FieldListDefinition()
        {
        }

        public FieldListDefinition(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            ListName = (string)items[3];
            SourceTableSchema = (string)items[4];
            SourceTableName = (string)items[5];
            IdentifierColumn = (string)items[6];
            TableTypeSchema = (string)items[7];
            TableTypeName = (string)items[8];
            TypedIdentifierType = (string)items[9];
            IdentifierValueColumn = (string)items[10];
        }

        public FieldListDefinition(int StoreKey, string AssemblyDesignator, string ProfileName, string ListName, string SourceTableSchema, string SourceTableName, string IdentifierColumn, string TableTypeSchema, string TableTypeName, string TypedIdentifierType, string IdentifierValueColumn)
        {
            this.StoreKey = StoreKey;
            this.AssemblyDesignator = AssemblyDesignator;
            this.ProfileName = ProfileName;
            this.ListName = ListName;
            this.SourceTableSchema = SourceTableSchema;
            this.SourceTableName = SourceTableName;
            this.IdentifierColumn = IdentifierColumn;
            this.TableTypeSchema = TableTypeSchema;
            this.TableTypeName = TableTypeName;
            this.TypedIdentifierType = TypedIdentifierType;
            this.IdentifierValueColumn = IdentifierValueColumn;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreKey, AssemblyDesignator, ProfileName, ListName, SourceTableSchema, SourceTableName, IdentifierColumn, TableTypeSchema, TableTypeName, TypedIdentifierType, IdentifierValueColumn };
        }

        public override void SetItemArray(object[] items)
        {
            StoreKey = (int)items[0];
            AssemblyDesignator = (string)items[1];
            ProfileName = (string)items[2];
            ListName = (string)items[3];
            SourceTableSchema = (string)items[4];
            SourceTableName = (string)items[5];
            IdentifierColumn = (string)items[6];
            TableTypeSchema = (string)items[7];
            TableTypeName = (string)items[8];
            TypedIdentifierType = (string)items[9];
            IdentifierValueColumn = (string)items[10];
        }
    }

    public sealed class SqlStoreViewNames
    {
        public readonly static SqlViewName ColumnComparisionInfo = "[SqlStore].[ColumnComparisionInfo]";
        public readonly static SqlViewName TableQueryColumnInfo = "[SqlStore].[TableQueryColumnInfo]";
    }

    [SqlView("SqlStore", "ColumnComparisionInfo")]
    public partial class ColumnComparisionInfo : SqlViewProxy
    {
        [SqlColumn("QueryId", 0), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("QueryName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 2), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 3), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        [SqlColumn("StoreKey", 6), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 7), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 8), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 9), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        [SqlColumn("ComparisonId", 10), SqlTypeFacets("int", false)]
        public int ComparisonId
        {
            get;
            set;
        }

        [SqlColumn("Operand", 11), SqlTypeFacets("sql_variant", false)]
        public Object Operand
        {
            get;
            set;
        }

        [SqlColumn("ComparisonOp", 12), SqlTypeFacets("nvarchar", false, 5)]
        public string ComparisonOp
        {
            get;
            set;
        }

        public ColumnComparisionInfo()
        {
        }

        public ColumnComparisionInfo(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
            ComparisonId = (int)items[10];
            Operand = (Object)items[11];
            ComparisonOp = (string)items[12];
        }

        public ColumnComparisionInfo(int QueryId, string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias, int StoreKey, string ColumnName, int ColumnPosition, string ColumnAlias, int ComparisonId, Object Operand, string ComparisonOp)
        {
            this.QueryId = QueryId;
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
            this.StoreKey = StoreKey;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.ColumnAlias = ColumnAlias;
            this.ComparisonId = ComparisonId;
            this.Operand = Operand;
            this.ComparisonOp = ComparisonOp;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryId, QueryName, TableCatalog, TableSchema, TableName, TableAlias, StoreKey, ColumnName, ColumnPosition, ColumnAlias, ComparisonId, Operand, ComparisonOp };
        }

        public override void SetItemArray(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
            ComparisonId = (int)items[10];
            Operand = (Object)items[11];
            ComparisonOp = (string)items[12];
        }
    }

    [SqlView("SqlStore", "TableQueryColumnInfo")]
    public partial class TableQueryColumnInfo : SqlViewProxy
    {
        [SqlColumn("QueryId", 0), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("QueryName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 2), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 3), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        [SqlColumn("StoreKey", 6), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 7), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 8), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 9), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        public TableQueryColumnInfo()
        {
        }

        public TableQueryColumnInfo(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
        }

        public TableQueryColumnInfo(int QueryId, string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias, int StoreKey, string ColumnName, int ColumnPosition, string ColumnAlias)
        {
            this.QueryId = QueryId;
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
            this.StoreKey = StoreKey;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.ColumnAlias = ColumnAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryId, QueryName, TableCatalog, TableSchema, TableName, TableAlias, StoreKey, ColumnName, ColumnPosition, ColumnAlias };
        }

        public override void SetItemArray(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
        }
    }
}
namespace SqlT.SqlStore
{
    using System;
    using SqlT.Types;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class SqlStoreBrokerFactory : SqlProxyBrokerFactory<SqlStoreBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"SqlT";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<SqlStoreBrokerFactory>)(new SqlStoreBrokerFactory())).CreateBroker(cs);
    }
}
// Emission concluded at 5/12/2018 8:42:25 PM
