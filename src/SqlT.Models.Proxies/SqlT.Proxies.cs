//This file was generated at 6/14/2017 11:13:23 AM using version 1.0.77 the SqT data access toolset.
namespace SqlT.Models.Proxies
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    public sealed class SqlTTableTypeNames
    {
        public readonly static SqlTypeName DefaultFilePathRecord = "[SqlT].[DefaultFilePathRecord]";
        public readonly static SqlTypeName TableRowCount = "[SqlT].[TableRowCount]";
    }

    public sealed class SqlTProcedureNames
    {
        public readonly static SqlProcedureName ConfigureServer = "[SqlT].[ConfigureServer]";
        public readonly static SqlProcedureName ConfigureServerOption = "[SqlT].[ConfigureServerOption]";
        public readonly static SqlProcedureName CreateLinkedServer = "[SqlT].[CreateLinkedServer]";
        public readonly static SqlProcedureName DropDatabase = "[SqlT].[DropDatabase]";
        public readonly static SqlProcedureName EnabledContainedDatabases = "[SqlT].[EnabledContainedDatabases]";
        public readonly static SqlProcedureName EnableStatisticsProfiling = "[SqlT].[EnableStatisticsProfiling]";
        public readonly static SqlProcedureName ExportQueryData = "[SqlT].[ExportQueryData]";
        public readonly static SqlProcedureName ExportTableData = "[SqlT].[ExportTableData]";
        public readonly static SqlProcedureName GetFileDescriptions = "[SqlT].[GetFileDescriptions]";
        public readonly static SqlProcedureName GetServerPathDefaults = "[SqlT].[GetServerPathDefaults]";
        public readonly static SqlProcedureName GoOffline = "[SqlT].[GoOffline]";
        public readonly static SqlProcedureName GoOnline = "[SqlT].[GoOnline]";
    }

    public sealed class SqlTViewNames
    {
        public readonly static SqlViewName ExcludedSchema = "[SqlT].[ExcludedSchema]";
        public readonly static SqlViewName TimeZoneDescriptor = "[SqlT].[TimeZoneDescriptor]";
    }

    public sealed class SqlTTableFunctionNames
    {
        public readonly static SqlFunctionName DescribeForeignKeys = "[SqlT].[DescribeForeignKeys]";
        public readonly static SqlFunctionName DescribeSchemaIndexes = "[SqlT].[DescribeSchemaIndexes]";
        public readonly static SqlFunctionName GenerateColumnDropSql = "[SqlT].[GenerateColumnDropSql]";
        public readonly static SqlFunctionName GetCpuUsage = "[SqlT].[GetCpuUsage]";
        public readonly static SqlFunctionName GetIndexCreationProgress = "[SqlT].[GetIndexCreationProgress]";
        public readonly static SqlFunctionName GetIndexStatsUpdate = "[SqlT].[GetIndexStatsUpdate]";
        public readonly static SqlFunctionName GetIndexStorageCost = "[SqlT].[GetIndexStorageCost]";
        public readonly static SqlFunctionName GetObjectDefinitions = "[SqlT].[GetObjectDefinitions]";
        public readonly static SqlFunctionName GetRowCounts = "[SqlT].[GetRowCounts]";
        public readonly static SqlFunctionName GetRunningQueries = "[SqlT].[GetRunningQueries]";
        public readonly static SqlFunctionName GetSystemSummary = "[SqlT].[GetSystemSummary]";
        public readonly static SqlFunctionName GetTableColumns = "[SqlT].[GetTableColumns]";
        public readonly static SqlFunctionName GetTableIndexFragmentation = "[SqlT].[GetTableIndexFragmentation]";
        public readonly static SqlFunctionName ObjectExists = "[SqlT].[ObjectExists]";
    }

    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface IDefaultFilePathRecord
    {
        [SqlColumn("DefaultBackupPath", 0), SqlTypeFacets("nvarchar", false, 1000)]
        string DefaultBackupPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataPath", 1), SqlTypeFacets("nvarchar", false, 1000)]
        string DefaultDataPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogPath", 2), SqlTypeFacets("nvarchar", false, 1000)]
        string DefaultLogPath
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface ITableRowCount
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 256)]
        string ServerName
        {
            get;
            set;
        }

        [SqlColumn("CatalogName", 1), SqlTypeFacets("nvarchar", false, 256)]
        string CatalogName
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("nvarchar", false, 256)]
        string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 256)]
        string TableName
        {
            get;
            set;
        }

        [SqlColumn("RowCountValue", 4), SqlTypeFacets("int", false)]
        int RowCountValue
        {
            get;
            set;
        }
    }

    [SqlRecord("SqlT", "DefaultFilePathRecord")]
    public partial class DefaultFilePathRecord : SqlTableTypeProxy<DefaultFilePathRecord>, IDefaultFilePathRecord
    {
        [SqlColumn("DefaultBackupPath", 0), SqlTypeFacets("nvarchar", false, 1000)]
        public string DefaultBackupPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataPath", 1), SqlTypeFacets("nvarchar", false, 1000)]
        public string DefaultDataPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogPath", 2), SqlTypeFacets("nvarchar", false, 1000)]
        public string DefaultLogPath
        {
            get;
            set;
        }

        public DefaultFilePathRecord()
        {
        }

        public DefaultFilePathRecord(object[] items)
        {
            DefaultBackupPath = (string)items[0];
            DefaultDataPath = (string)items[1];
            DefaultLogPath = (string)items[2];
        }

        public DefaultFilePathRecord(string DefaultBackupPath, string DefaultDataPath, string DefaultLogPath)
        {
            this.DefaultBackupPath = DefaultBackupPath;
            this.DefaultDataPath = DefaultDataPath;
            this.DefaultLogPath = DefaultLogPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DefaultBackupPath, DefaultDataPath, DefaultLogPath };
        }

        public override void SetItemArray(object[] items)
        {
            DefaultBackupPath = (string)items[0];
            DefaultDataPath = (string)items[1];
            DefaultLogPath = (string)items[2];
        }
    }

    [SqlRecord("SqlT", "TableRowCount")]
    public partial class TableRowCount : SqlTableTypeProxy<TableRowCount>, ITableRowCount
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 256)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("CatalogName", 1), SqlTypeFacets("nvarchar", false, 256)]
        public string CatalogName
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("nvarchar", false, 256)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 256)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("RowCountValue", 4), SqlTypeFacets("int", false)]
        public int RowCountValue
        {
            get;
            set;
        }

        public TableRowCount()
        {
        }

        public TableRowCount(object[] items)
        {
            ServerName = (string)items[0];
            CatalogName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            RowCountValue = (int)items[4];
        }

        public TableRowCount(string ServerName, string CatalogName, string TableSchema, string TableName, int RowCountValue)
        {
            this.ServerName = ServerName;
            this.CatalogName = CatalogName;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.RowCountValue = RowCountValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, CatalogName, TableSchema, TableName, RowCountValue };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            CatalogName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            RowCountValue = (int)items[4];
        }
    }
}
namespace SqlT.Models.Proxies
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class SqlTModelBrokerFactory : SqlProxyBrokerFactory<SqlTModelBrokerFactory>
    {
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<SqlTModelBrokerFactory>)(new SqlTModelBrokerFactory())).CreateBroker(cs);
        protected override void RegisterConverters(ISqlProxyBroker broker)
        {
            broker.RegisterConverter<DateTime, Date>(SqlConversionDirection.ToProxy, src => new Date(src.Year, src.Month, src.Day));
            broker.RegisterConverter<Date, DateTime>(SqlConversionDirection.ToTransport, src => src.ToDateTimeAtMidnight());
            broker.RegisterConverter<TimeSpan, TimeOfDay>(SqlConversionDirection.ToProxy, src => new TimeOfDay(src.Hours, src.Minutes, src.Seconds, src.Milliseconds));
            broker.RegisterConverter<TimeOfDay, TimeSpan>(SqlConversionDirection.ToTransport, src => new TimeSpan(src.Ticks));
        }
    }
}
// Emission concluded at 6/14/2017 11:13:25 AM
