//This file was generated at 5/12/2018 8:42:23 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Store
{
    using System;
    using SqlT.Types;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlTTableFunctionNames
    {
        public readonly static SqlFunctionName DescribeDataTypes = "[SqlT].[DescribeDataTypes]";
        public readonly static SqlFunctionName DescribeFileTables = "[SqlT].[DescribeFileTables]";
        public readonly static SqlFunctionName DescribeForeignKeys = "[SqlT].[DescribeForeignKeys]";
        public readonly static SqlFunctionName DescribeSchemaIndexes = "[SqlT].[DescribeSchemaIndexes]";
        public readonly static SqlFunctionName DescribeTableColumns = "[SqlT].[DescribeTableColumns]";
        public readonly static SqlFunctionName Dir = "[SqlT].[Dir]";
        public readonly static SqlFunctionName Drives = "[SqlT].[Drives]";
        public readonly static SqlFunctionName FindSqlProxyDefinition = "[SqlT].[FindSqlProxyDefinition]";
        public readonly static SqlFunctionName GenerateColumnDropSql = "[SqlT].[GenerateColumnDropSql]";
        public readonly static SqlFunctionName GetCpuUsage = "[SqlT].[GetCpuUsage]";
        public readonly static SqlFunctionName GetIndexCreationProgress = "[SqlT].[GetIndexCreationProgress]";
        public readonly static SqlFunctionName GetIndexStatsUpdate = "[SqlT].[GetIndexStatsUpdate]";
        public readonly static SqlFunctionName GetIndexStorageCost = "[SqlT].[GetIndexStorageCost]";
        public readonly static SqlFunctionName GetObjectDefinitions = "[SqlT].[GetObjectDefinitions]";
        public readonly static SqlFunctionName GetRunningQueries = "[SqlT].[GetRunningQueries]";
        public readonly static SqlFunctionName GetServerCollations = "[SqlT].[GetServerCollations]";
        public readonly static SqlFunctionName GetSystemSummary = "[SqlT].[GetSystemSummary]";
        public readonly static SqlFunctionName GetTableIndexFragmentation = "[SqlT].[GetTableIndexFragmentation]";
        public readonly static SqlFunctionName NodeVars = "[SqlT].[NodeVars]";
        public readonly static SqlFunctionName ObjectExists = "[SqlT].[ObjectExists]";
        public readonly static SqlFunctionName SqlProxyDefinitions = "[SqlT].[SqlProxyDefinitions]";
        public readonly static SqlFunctionName SqlProxyDefinitionsByDatabase = "[SqlT].[SqlProxyDefinitionsByDatabase]";
    }

    public sealed class SqlTViewNames
    {
        public readonly static SqlViewName TableStatsView = "[SqlT].[TableStatsView]";
        public readonly static SqlViewName TimeZoneDescriptor = "[SqlT].[TimeZoneDescriptor]";
    }

    public sealed class SqlTPCNames
    {
        public readonly static SqlProcedureName ConfigureServer = "[SqlT].[ConfigureServer]";
        public readonly static SqlProcedureName ConfigureServerOption = "[SqlT].[ConfigureServerOption]";
        public readonly static SqlProcedureName CopyFile = "[SqlT].[CopyFile]";
        public readonly static SqlProcedureName CopyFolder = "[SqlT].[CopyFolder]";
        public readonly static SqlProcedureName CreateLinkedServer = "[SqlT].[CreateLinkedServer]";
        public readonly static SqlProcedureName DescribeBackup = "[SqlT].[DescribeBackup]";
        public readonly static SqlProcedureName DropDatabase = "[SqlT].[DropDatabase]";
        public readonly static SqlProcedureName EnabledContainedDatabases = "[SqlT].[EnabledContainedDatabases]";
        public readonly static SqlProcedureName EnableSqlClr = "[SqlT].[EnableSqlClr]";
        public readonly static SqlProcedureName EnableStatisticsProfiling = "[SqlT].[EnableStatisticsProfiling]";
        public readonly static SqlProcedureName EnableXpCmdShell = "[SqlT].[EnableXpCmdShell]";
        public readonly static SqlProcedureName ExportQueryData = "[SqlT].[ExportQueryData]";
        public readonly static SqlProcedureName ExportTableData = "[SqlT].[ExportTableData]";
        public readonly static SqlProcedureName GetFileDescriptions = "[SqlT].[GetFileDescriptions]";
        public readonly static SqlProcedureName GetServerPathDefaults = "[SqlT].[GetServerPathDefaults]";
        public readonly static SqlProcedureName GoOffline = "[SqlT].[GoOffline]";
        public readonly static SqlProcedureName GoOnline = "[SqlT].[GoOnline]";
        public readonly static SqlProcedureName HttpPost = "[SqlT].[HttpPost]";
        public readonly static SqlProcedureName RestoreBackup = "[SqlT].[RestoreBackup]";
        public readonly static SqlProcedureName SetVar = "[SqlT].[SetVar]";
        public readonly static SqlProcedureName StoreBackupDescriptions = "[SqlT].[StoreBackupDescriptions]";
        public readonly static SqlProcedureName StoreDataTypeDescriptions = "[SqlT].[StoreDataTypeDescriptions]";
        public readonly static SqlProcedureName StoreNativeTypes = "[SqlT].[StoreNativeTypes]";
        public readonly static SqlProcedureName StoreTableQueries = "[SqlT].[StoreTableQueries]";
        public readonly static SqlProcedureName SyncColumnRoleTypes = "[SqlT].[SyncColumnRoleTypes]";
        public readonly static SqlProcedureName SyncDatabases = "[SqlT].[SyncDatabases]";
        public readonly static SqlProcedureName SyncForeignKeys = "[SqlT].[SyncForeignKeys]";
        public readonly static SqlProcedureName SynColumnGroupMemberships = "[SqlT].[SynColumnGroupMemberships]";
        public readonly static SqlProcedureName SynColumnRoleAssignments = "[SqlT].[SynColumnRoleAssignments]";
        public readonly static SqlProcedureName SyncSqlProxyDefinitions = "[SqlT].[SyncSqlProxyDefinitions]";
        public readonly static SqlProcedureName SyncTables = "[SqlT].[SyncTables]";
        public readonly static SqlProcedureName WriteTextToFile = "[SqlT].[WriteTextToFile]";
    }

    [SqlTableFunctionResult("SqlT", "ObjectExists")]
    public partial class ObjectExistsResult : SqlTabularProxy
    {
        [SqlColumn("ObjectExists", 0), SqlTypeFacets("bit", false)]
        public bool ObjectExistsColumn
        {
            get;
            set;
        }

        public ObjectExistsResult()
        {
        }

        public ObjectExistsResult(object[] items)
        {
            ObjectExistsColumn = (bool)items[0];
        }

        public ObjectExistsResult(bool ObjectExistsColumn)
        {
            this.ObjectExistsColumn = ObjectExistsColumn;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ObjectExistsColumn };
        }

        public override void SetItemArray(object[] items)
        {
            ObjectExistsColumn = (bool)items[0];
        }
    }

    [SqlTableFunction("SqlT", "ObjectExists")]
    public partial class ObjectExists : SqlTableFunctionProxy<ObjectExists, ObjectExistsResult>
    {
        [SqlParameter("@ObjectName", 0, false, false), SqlTypeFacets("nvarchar", true, 260)]
        public string ObjectName
        {
            get;
            set;
        }

        public ObjectExists()
        {
        }

        public ObjectExists(object[] items)
        {
            ObjectName = (string)items[0];
        }

        public ObjectExists(string ObjectName)
        {
            this.ObjectName = ObjectName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ObjectName };
        }

        public override void SetItemArray(object[] items)
        {
            ObjectName = (string)items[0];
        }
    }

    [SqlTableFunctionResult("SqlT", "GetTableIndexFragmentation")]
    public partial class GetTableIndexFragmentationResult : SqlTabularProxy
    {
        [SqlColumn("TableSchema", 0), SqlTypeFacets("sysname", false)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 1), SqlTypeFacets("sysname", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("IndexName", 2), SqlTypeFacets("sysname", true)]
        public string IndexName
        {
            get;
            set;
        }

        [SqlColumn("IndexType", 3), SqlTypeFacets("nvarchar", true, 60)]
        public string IndexType
        {
            get;
            set;
        }

        [SqlColumn("avg_fragmentation_in_percent", 4), SqlTypeFacets("float", true)]
        public double? avg_fragmentation_in_percent
        {
            get;
            set;
        }

        public GetTableIndexFragmentationResult()
        {
        }

        public GetTableIndexFragmentationResult(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
            IndexName = (string)items[2];
            IndexType = (string)items[3];
            avg_fragmentation_in_percent = (double?)items[4];
        }

        public GetTableIndexFragmentationResult(string TableSchema, string TableName, string IndexName, string IndexType, double? avg_fragmentation_in_percent)
        {
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.IndexName = IndexName;
            this.IndexType = IndexType;
            this.avg_fragmentation_in_percent = avg_fragmentation_in_percent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TableSchema, TableName, IndexName, IndexType, avg_fragmentation_in_percent };
        }

        public override void SetItemArray(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
            IndexName = (string)items[2];
            IndexType = (string)items[3];
            avg_fragmentation_in_percent = (double?)items[4];
        }
    }

    [SqlTableFunction("SqlT", "GetTableIndexFragmentation")]
    public partial class GetTableIndexFragmentation : SqlTableFunctionProxy<GetTableIndexFragmentation, GetTableIndexFragmentationResult>
    {
        [SqlParameter("@TableSchema", 0, false, false), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlParameter("@TableName", 1, false, false), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        public GetTableIndexFragmentation()
        {
        }

        public GetTableIndexFragmentation(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
        }

        public GetTableIndexFragmentation(string TableSchema, string TableName)
        {
            this.TableSchema = TableSchema;
            this.TableName = TableName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TableSchema, TableName };
        }

        public override void SetItemArray(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
        }
    }

    [SqlTableFunctionResult("SqlT", "GetSystemSummary")]
    public partial class GetSystemSummaryResult : SqlTabularProxy
    {
        [SqlColumn("MetricName", 0), SqlTypeFacets("varchar", false, 18)]
        public string MetricName
        {
            get;
            set;
        }

        [SqlColumn("MetricValue", 1), SqlTypeFacets("int", true)]
        public int? MetricValue
        {
            get;
            set;
        }

        public GetSystemSummaryResult()
        {
        }

        public GetSystemSummaryResult(object[] items)
        {
            MetricName = (string)items[0];
            MetricValue = (int?)items[1];
        }

        public GetSystemSummaryResult(string MetricName, int? MetricValue)
        {
            this.MetricName = MetricName;
            this.MetricValue = MetricValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { MetricName, MetricValue };
        }

        public override void SetItemArray(object[] items)
        {
            MetricName = (string)items[0];
            MetricValue = (int?)items[1];
        }
    }

    [SqlTableFunction("SqlT", "GetSystemSummary")]
    public partial class GetSystemSummary : SqlTableFunctionProxy<GetSystemSummary, GetSystemSummaryResult>
    {
        public GetSystemSummary()
        {
        }
    }

    [SqlTableFunction("SqlT", "GetServerCollations")]
    public partial class GetServerCollations : SqlTableFunctionProxy<GetServerCollations, ServerCollation>
    {
        public GetServerCollations()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GetRunningQueries")]
    public partial class GetRunningQueriesResult : SqlTabularProxy
    {
        [SqlColumn("SPID", 0), SqlTypeFacets("smallint", false)]
        public short SPID
        {
            get;
            set;
        }

        [SqlColumn("Status", 1), SqlTypeFacets("nvarchar", true, 30)]
        public string Status
        {
            get;
            set;
        }

        [SqlColumn("Login", 2), SqlTypeFacets("nvarchar", true, 128)]
        public string Login
        {
            get;
            set;
        }

        [SqlColumn("Host", 3), SqlTypeFacets("nvarchar", true, 128)]
        public string Host
        {
            get;
            set;
        }

        [SqlColumn("BlkBy", 4), SqlTypeFacets("smallint", true)]
        public short? BlkBy
        {
            get;
            set;
        }

        [SqlColumn("DBName", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string DBName
        {
            get;
            set;
        }

        [SqlColumn("CommandType", 6), SqlTypeFacets("nvarchar", false, 32)]
        public string CommandType
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 7), SqlTypeFacets("nvarchar", true, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("CPUTime", 8), SqlTypeFacets("int", false)]
        public int CPUTime
        {
            get;
            set;
        }

        [SqlColumn("StartTime", 9), SqlTypeFacets("datetime", false)]
        public DateTime StartTime
        {
            get;
            set;
        }

        [SqlColumn("TimeElapsed", 10), SqlTypeFacets("time", true, -1, 7)]
        public TimeOfDay? TimeElapsed
        {
            get;
            set;
        }

        [SqlColumn("SQLStatement", 11), SqlTypeFacets("nvarchar", true, 0)]
        public string SQLStatement
        {
            get;
            set;
        }

        public GetRunningQueriesResult()
        {
        }

        public GetRunningQueriesResult(object[] items)
        {
            SPID = (short)items[0];
            Status = (string)items[1];
            Login = (string)items[2];
            Host = (string)items[3];
            BlkBy = (short?)items[4];
            DBName = (string)items[5];
            CommandType = (string)items[6];
            ObjectName = (string)items[7];
            CPUTime = (int)items[8];
            StartTime = (DateTime)items[9];
            TimeElapsed = (TimeOfDay?)items[10];
            SQLStatement = (string)items[11];
        }

        public GetRunningQueriesResult(short SPID, string Status, string Login, string Host, short? BlkBy, string DBName, string CommandType, string ObjectName, int CPUTime, DateTime StartTime, TimeOfDay? TimeElapsed, string SQLStatement)
        {
            this.SPID = SPID;
            this.Status = Status;
            this.Login = Login;
            this.Host = Host;
            this.BlkBy = BlkBy;
            this.DBName = DBName;
            this.CommandType = CommandType;
            this.ObjectName = ObjectName;
            this.CPUTime = CPUTime;
            this.StartTime = StartTime;
            this.TimeElapsed = TimeElapsed;
            this.SQLStatement = SQLStatement;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SPID, Status, Login, Host, BlkBy, DBName, CommandType, ObjectName, CPUTime, StartTime, TimeElapsed, SQLStatement };
        }

        public override void SetItemArray(object[] items)
        {
            SPID = (short)items[0];
            Status = (string)items[1];
            Login = (string)items[2];
            Host = (string)items[3];
            BlkBy = (short?)items[4];
            DBName = (string)items[5];
            CommandType = (string)items[6];
            ObjectName = (string)items[7];
            CPUTime = (int)items[8];
            StartTime = (DateTime)items[9];
            TimeElapsed = (TimeOfDay?)items[10];
            SQLStatement = (string)items[11];
        }
    }

    [SqlTableFunction("SqlT", "GetRunningQueries")]
    public partial class GetRunningQueries : SqlTableFunctionProxy<GetRunningQueries, GetRunningQueriesResult>
    {
        public GetRunningQueries()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GetObjectDefinitions")]
    public partial class GetObjectDefinitionsResult : SqlTabularProxy
    {
        [SqlColumn("schema_name", 0), SqlTypeFacets("nvarchar", true, 128)]
        public string schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 1), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("type", 2), SqlTypeFacets("char", true, 2)]
        public string type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 3), SqlTypeFacets("nvarchar", true, 60)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("definition", 4), SqlTypeFacets("nvarchar", true, 0)]
        public string definition
        {
            get;
            set;
        }

        public GetObjectDefinitionsResult()
        {
        }

        public GetObjectDefinitionsResult(object[] items)
        {
            schema_name = (string)items[0];
            name = (string)items[1];
            type = (string)items[2];
            type_desc = (string)items[3];
            definition = (string)items[4];
        }

        public GetObjectDefinitionsResult(string schema_name, string name, string type, string type_desc, string definition)
        {
            this.schema_name = schema_name;
            this.name = name;
            this.type = type;
            this.type_desc = type_desc;
            this.definition = definition;
        }

        public override object[] GetItemArray()
        {
            return new object[] { schema_name, name, type, type_desc, definition };
        }

        public override void SetItemArray(object[] items)
        {
            schema_name = (string)items[0];
            name = (string)items[1];
            type = (string)items[2];
            type_desc = (string)items[3];
            definition = (string)items[4];
        }
    }

    [SqlTableFunction("SqlT", "GetObjectDefinitions")]
    public partial class GetObjectDefinitions : SqlTableFunctionProxy<GetObjectDefinitions, GetObjectDefinitionsResult>
    {
        public GetObjectDefinitions()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GetIndexStorageCost")]
    public partial class GetIndexStorageCostResult : SqlTabularProxy
    {
        [SqlColumn("IndexName", 0), SqlTypeFacets("sysname", true)]
        public string IndexName
        {
            get;
            set;
        }

        [SqlColumn("IndexSizeMB", 1), SqlTypeFacets("bigint", true)]
        public long? IndexSizeMB
        {
            get;
            set;
        }

        public GetIndexStorageCostResult()
        {
        }

        public GetIndexStorageCostResult(object[] items)
        {
            IndexName = (string)items[0];
            IndexSizeMB = (long?)items[1];
        }

        public GetIndexStorageCostResult(string IndexName, long? IndexSizeMB)
        {
            this.IndexName = IndexName;
            this.IndexSizeMB = IndexSizeMB;
        }

        public override object[] GetItemArray()
        {
            return new object[] { IndexName, IndexSizeMB };
        }

        public override void SetItemArray(object[] items)
        {
            IndexName = (string)items[0];
            IndexSizeMB = (long?)items[1];
        }
    }

    [SqlTableFunction("SqlT", "GetIndexStorageCost")]
    public partial class GetIndexStorageCost : SqlTableFunctionProxy<GetIndexStorageCost, GetIndexStorageCostResult>
    {
        public GetIndexStorageCost()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GetIndexStatsUpdate")]
    public partial class GetIndexStatsUpdateResult : SqlTabularProxy
    {
        [SqlColumn("schema_name", 0), SqlTypeFacets("sysname", false)]
        public string schema_name
        {
            get;
            set;
        }

        [SqlColumn("table_name", 1), SqlTypeFacets("sysname", false)]
        public string table_name
        {
            get;
            set;
        }

        [SqlColumn("index_name", 2), SqlTypeFacets("sysname", true)]
        public string index_name
        {
            get;
            set;
        }

        [SqlColumn("stats_updated", 3), SqlTypeFacets("datetime", true)]
        public DateTime? stats_updated
        {
            get;
            set;
        }

        public GetIndexStatsUpdateResult()
        {
        }

        public GetIndexStatsUpdateResult(object[] items)
        {
            schema_name = (string)items[0];
            table_name = (string)items[1];
            index_name = (string)items[2];
            stats_updated = (DateTime?)items[3];
        }

        public GetIndexStatsUpdateResult(string schema_name, string table_name, string index_name, DateTime? stats_updated)
        {
            this.schema_name = schema_name;
            this.table_name = table_name;
            this.index_name = index_name;
            this.stats_updated = stats_updated;
        }

        public override object[] GetItemArray()
        {
            return new object[] { schema_name, table_name, index_name, stats_updated };
        }

        public override void SetItemArray(object[] items)
        {
            schema_name = (string)items[0];
            table_name = (string)items[1];
            index_name = (string)items[2];
            stats_updated = (DateTime?)items[3];
        }
    }

    [SqlTableFunction("SqlT", "GetIndexStatsUpdate")]
    public partial class GetIndexStatsUpdate : SqlTableFunctionProxy<GetIndexStatsUpdate, GetIndexStatsUpdateResult>
    {
        public GetIndexStatsUpdate()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GetIndexCreationProgress")]
    public partial class GetIndexCreationProgressResult : SqlTabularProxy
    {
        [SqlColumn("CurrentStep", 0), SqlTypeFacets("nvarchar", true, 256)]
        public string CurrentStep
        {
            get;
            set;
        }

        [SqlColumn("TotalRows", 1), SqlTypeFacets("bigint", true)]
        public long? TotalRows
        {
            get;
            set;
        }

        [SqlColumn("RowsProcessed", 2), SqlTypeFacets("bigint", true)]
        public long? RowsProcessed
        {
            get;
            set;
        }

        [SqlColumn("RowsLeft", 3), SqlTypeFacets("bigint", true)]
        public long? RowsLeft
        {
            get;
            set;
        }

        [SqlColumn("PercentComplete", 4), SqlTypeFacets("decimal", true, 5, 2)]
        public decimal? PercentComplete
        {
            get;
            set;
        }

        [SqlColumn("ElapsedSeconds", 5), SqlTypeFacets("numeric", true, 26, 6)]
        public decimal? ElapsedSeconds
        {
            get;
            set;
        }

        [SqlColumn("EstimatedSecondsLeft", 6), SqlTypeFacets("numeric", true, 38, 6)]
        public decimal? EstimatedSecondsLeft
        {
            get;
            set;
        }

        [SqlColumn("EstimatedCompletionTime", 7), SqlTypeFacets("datetime", true)]
        public DateTime? EstimatedCompletionTime
        {
            get;
            set;
        }

        public GetIndexCreationProgressResult()
        {
        }

        public GetIndexCreationProgressResult(object[] items)
        {
            CurrentStep = (string)items[0];
            TotalRows = (long?)items[1];
            RowsProcessed = (long?)items[2];
            RowsLeft = (long?)items[3];
            PercentComplete = (decimal?)items[4];
            ElapsedSeconds = (decimal?)items[5];
            EstimatedSecondsLeft = (decimal?)items[6];
            EstimatedCompletionTime = (DateTime?)items[7];
        }

        public GetIndexCreationProgressResult(string CurrentStep, long? TotalRows, long? RowsProcessed, long? RowsLeft, decimal? PercentComplete, decimal? ElapsedSeconds, decimal? EstimatedSecondsLeft, DateTime? EstimatedCompletionTime)
        {
            this.CurrentStep = CurrentStep;
            this.TotalRows = TotalRows;
            this.RowsProcessed = RowsProcessed;
            this.RowsLeft = RowsLeft;
            this.PercentComplete = PercentComplete;
            this.ElapsedSeconds = ElapsedSeconds;
            this.EstimatedSecondsLeft = EstimatedSecondsLeft;
            this.EstimatedCompletionTime = EstimatedCompletionTime;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CurrentStep, TotalRows, RowsProcessed, RowsLeft, PercentComplete, ElapsedSeconds, EstimatedSecondsLeft, EstimatedCompletionTime };
        }

        public override void SetItemArray(object[] items)
        {
            CurrentStep = (string)items[0];
            TotalRows = (long?)items[1];
            RowsProcessed = (long?)items[2];
            RowsLeft = (long?)items[3];
            PercentComplete = (decimal?)items[4];
            ElapsedSeconds = (decimal?)items[5];
            EstimatedSecondsLeft = (decimal?)items[6];
            EstimatedCompletionTime = (DateTime?)items[7];
        }
    }

    [SqlTableFunction("SqlT", "GetIndexCreationProgress")]
    public partial class GetIndexCreationProgress : SqlTableFunctionProxy<GetIndexCreationProgress, GetIndexCreationProgressResult>
    {
        [SqlParameter("@SessionId", 0, false, false), SqlTypeFacets("int", true)]
        public int? SessionId
        {
            get;
            set;
        }

        public GetIndexCreationProgress()
        {
        }

        public GetIndexCreationProgress(object[] items)
        {
            SessionId = (int?)items[0];
        }

        public GetIndexCreationProgress(int? SessionId)
        {
            this.SessionId = SessionId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SessionId };
        }

        public override void SetItemArray(object[] items)
        {
            SessionId = (int?)items[0];
        }
    }

    [SqlTableFunctionResult("SqlT", "GetCpuUsage")]
    public partial class GetCpuUsageResult : SqlTabularProxy
    {
        [SqlColumn("AvgCPU", 0), SqlTypeFacets("decimal", true, 15, 5)]
        public decimal? AvgCPU
        {
            get;
            set;
        }

        [SqlColumn("AvgLogicalReads", 1), SqlTypeFacets("decimal", true, 15, 5)]
        public decimal? AvgLogicalReads
        {
            get;
            set;
        }

        [SqlColumn("NumExecutionPlans", 2), SqlTypeFacets("int", true)]
        public int? NumExecutionPlans
        {
            get;
            set;
        }

        [SqlColumn("TotalExecutions", 3), SqlTypeFacets("bigint", true)]
        public long? TotalExecutions
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("QueryText", 6), SqlTypeFacets("nvarchar", true, 0)]
        public string QueryText
        {
            get;
            set;
        }

        public GetCpuUsageResult()
        {
        }

        public GetCpuUsageResult(object[] items)
        {
            AvgCPU = (decimal?)items[0];
            AvgLogicalReads = (decimal?)items[1];
            NumExecutionPlans = (int?)items[2];
            TotalExecutions = (long?)items[3];
            DatabaseName = (string)items[4];
            ObjectName = (string)items[5];
            QueryText = (string)items[6];
        }

        public GetCpuUsageResult(decimal? AvgCPU, decimal? AvgLogicalReads, int? NumExecutionPlans, long? TotalExecutions, string DatabaseName, string ObjectName, string QueryText)
        {
            this.AvgCPU = AvgCPU;
            this.AvgLogicalReads = AvgLogicalReads;
            this.NumExecutionPlans = NumExecutionPlans;
            this.TotalExecutions = TotalExecutions;
            this.DatabaseName = DatabaseName;
            this.ObjectName = ObjectName;
            this.QueryText = QueryText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AvgCPU, AvgLogicalReads, NumExecutionPlans, TotalExecutions, DatabaseName, ObjectName, QueryText };
        }

        public override void SetItemArray(object[] items)
        {
            AvgCPU = (decimal?)items[0];
            AvgLogicalReads = (decimal?)items[1];
            NumExecutionPlans = (int?)items[2];
            TotalExecutions = (long?)items[3];
            DatabaseName = (string)items[4];
            ObjectName = (string)items[5];
            QueryText = (string)items[6];
        }
    }

    [SqlTableFunction("SqlT", "GetCpuUsage")]
    public partial class GetCpuUsage : SqlTableFunctionProxy<GetCpuUsage, GetCpuUsageResult>
    {
        public GetCpuUsage()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "GenerateColumnDropSql")]
    public partial class GenerateColumnDropSqlResult : SqlTabularProxy
    {
        [SqlColumn("SqlScript", 0), SqlTypeFacets("nvarchar", true, 410)]
        public string SqlScript
        {
            get;
            set;
        }

        public GenerateColumnDropSqlResult()
        {
        }

        public GenerateColumnDropSqlResult(object[] items)
        {
            SqlScript = (string)items[0];
        }

        public GenerateColumnDropSqlResult(string SqlScript)
        {
            this.SqlScript = SqlScript;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SqlScript };
        }

        public override void SetItemArray(object[] items)
        {
            SqlScript = (string)items[0];
        }
    }

    [SqlTableFunction("SqlT", "GenerateColumnDropSql")]
    public partial class GenerateColumnDropSql : SqlTableFunctionProxy<GenerateColumnDropSql, GenerateColumnDropSqlResult>
    {
        [SqlParameter("@ColumnName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        public GenerateColumnDropSql()
        {
        }

        public GenerateColumnDropSql(object[] items)
        {
            ColumnName = (string)items[0];
        }

        public GenerateColumnDropSql(string ColumnName)
        {
            this.ColumnName = ColumnName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ColumnName };
        }

        public override void SetItemArray(object[] items)
        {
            ColumnName = (string)items[0];
        }
    }

    [SqlTableFunctionResult("SqlT", "DescribeTableColumns")]
    public partial class DescribeTableColumnsResult : SqlTabularProxy
    {
        [SqlColumn("RowId", 0), SqlTypeFacets("bigint", true)]
        public long? RowId
        {
            get;
            set;
        }

        [SqlColumn("CatalogName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string CatalogName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("sysname", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("Description", 5), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public DescribeTableColumnsResult()
        {
        }

        public DescribeTableColumnsResult(object[] items)
        {
            RowId = (long?)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
            Description = (string)items[5];
        }

        public DescribeTableColumnsResult(long? RowId, string CatalogName, string SchemaName, string TableName, string ColumnName, string Description)
        {
            this.RowId = RowId;
            this.CatalogName = CatalogName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.ColumnName = ColumnName;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { RowId, CatalogName, SchemaName, TableName, ColumnName, Description };
        }

        public override void SetItemArray(object[] items)
        {
            RowId = (long?)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
            Description = (string)items[5];
        }
    }

    [SqlTableFunction("SqlT", "DescribeTableColumns")]
    public partial class DescribeTableColumns : SqlTableFunctionProxy<DescribeTableColumns, DescribeTableColumnsResult>
    {
        public DescribeTableColumns()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "DescribeSchemaIndexes")]
    public partial class DescribeSchemaIndexesResult : SqlTabularProxy
    {
        [SqlColumn("RowId", 0), SqlTypeFacets("bigint", true)]
        public long? RowId
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 1), SqlTypeFacets("sysname", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 2), SqlTypeFacets("sysname", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("IndexName", 3), SqlTypeFacets("sysname", true)]
        public string IndexName
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 4), SqlTypeFacets("int", false)]
        public int IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("IndexType", 5), SqlTypeFacets("nvarchar", true, 60)]
        public string IndexType
        {
            get;
            set;
        }

        [SqlColumn("IsUnique", 6), SqlTypeFacets("bit", true)]
        public bool? IsUnique
        {
            get;
            set;
        }

        public DescribeSchemaIndexesResult()
        {
        }

        public DescribeSchemaIndexesResult(object[] items)
        {
            RowId = (long?)items[0];
            SchemaName = (string)items[1];
            TableName = (string)items[2];
            IndexName = (string)items[3];
            IsEnabled = (int)items[4];
            IndexType = (string)items[5];
            IsUnique = (bool?)items[6];
        }

        public DescribeSchemaIndexesResult(long? RowId, string SchemaName, string TableName, string IndexName, int IsEnabled, string IndexType, bool? IsUnique)
        {
            this.RowId = RowId;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.IndexName = IndexName;
            this.IsEnabled = IsEnabled;
            this.IndexType = IndexType;
            this.IsUnique = IsUnique;
        }

        public override object[] GetItemArray()
        {
            return new object[] { RowId, SchemaName, TableName, IndexName, IsEnabled, IndexType, IsUnique };
        }

        public override void SetItemArray(object[] items)
        {
            RowId = (long?)items[0];
            SchemaName = (string)items[1];
            TableName = (string)items[2];
            IndexName = (string)items[3];
            IsEnabled = (int)items[4];
            IndexType = (string)items[5];
            IsUnique = (bool?)items[6];
        }
    }

    [SqlTableFunction("SqlT", "DescribeSchemaIndexes")]
    public partial class DescribeSchemaIndexes : SqlTableFunctionProxy<DescribeSchemaIndexes, DescribeSchemaIndexesResult>
    {
        [SqlParameter("@SchemaName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string SchemaName
        {
            get;
            set;
        }

        public DescribeSchemaIndexes()
        {
        }

        public DescribeSchemaIndexes(object[] items)
        {
            SchemaName = (string)items[0];
        }

        public DescribeSchemaIndexes(string SchemaName)
        {
            this.SchemaName = SchemaName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SchemaName };
        }

        public override void SetItemArray(object[] items)
        {
            SchemaName = (string)items[0];
        }
    }

    [SqlTableFunction("SqlT", "DescribeForeignKeys")]
    public partial class DescribeForeignKeys : SqlTableFunctionProxy<DescribeForeignKeys, ForeignKeyInfo>
    {
        public DescribeForeignKeys()
        {
        }
    }

    [SqlTableFunction("SqlT", "DescribeFileTables")]
    public partial class DescribeFileTables : SqlTableFunctionProxy<DescribeFileTables, FileTableDescription>
    {
        public DescribeFileTables()
        {
        }
    }

    [SqlTableFunction("SqlT", "DescribeDataTypes")]
    public partial class DescribeDataTypes : SqlTableFunctionProxy<DescribeDataTypes, DataTypeDescription>
    {
        public DescribeDataTypes()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "NodeVars")]
    public partial class NodeVarsResult : SqlTabularProxy
    {
        [SqlColumn("VarName", 0), SqlTypeFacets("nvarchar", true, 250)]
        public string VarName
        {
            get;
            set;
        }

        [SqlColumn("VarValue", 1), SqlTypeFacets("nvarchar", true, 4000)]
        public string VarValue
        {
            get;
            set;
        }

        public NodeVarsResult()
        {
        }

        public NodeVarsResult(object[] items)
        {
            VarName = (string)items[0];
            VarValue = (string)items[1];
        }

        public NodeVarsResult(string VarName, string VarValue)
        {
            this.VarName = VarName;
            this.VarValue = VarValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { VarName, VarValue };
        }

        public override void SetItemArray(object[] items)
        {
            VarName = (string)items[0];
            VarValue = (string)items[1];
        }
    }

    [SqlTableFunction("SqlT", "NodeVars")]
    public partial class NodeVars : SqlTableFunctionProxy<NodeVars, NodeVarsResult>
    {
        public NodeVars()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "Drives")]
    public partial class DrivesResult : SqlTabularProxy
    {
        [SqlColumn("DrivePath", 0), SqlTypeFacets("nvarchar", true, 250)]
        public string DrivePath
        {
            get;
            set;
        }

        public DrivesResult()
        {
        }

        public DrivesResult(object[] items)
        {
            DrivePath = (string)items[0];
        }

        public DrivesResult(string DrivePath)
        {
            this.DrivePath = DrivePath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DrivePath };
        }

        public override void SetItemArray(object[] items)
        {
            DrivePath = (string)items[0];
        }
    }

    [SqlTableFunction("SqlT", "Drives")]
    public partial class Drives : SqlTableFunctionProxy<Drives, DrivesResult>
    {
        public Drives()
        {
        }
    }

    [SqlTableFunctionResult("SqlT", "Dir")]
    public partial class DirResult : SqlTabularProxy
    {
        [SqlColumn("FilePath", 0), SqlTypeFacets("nvarchar", true, 4000)]
        public string FilePath
        {
            get;
            set;
        }

        [SqlColumn("IsDirectory", 1), SqlTypeFacets("bit", true)]
        public bool? IsDirectory
        {
            get;
            set;
        }

        [SqlColumn("CreationTime", 2), SqlTypeFacets("datetime", true)]
        public DateTime? CreationTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 3), SqlTypeFacets("datetime", true)]
        public DateTime? LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("Size", 4), SqlTypeFacets("bigint", true)]
        public long? Size
        {
            get;
            set;
        }

        public DirResult()
        {
        }

        public DirResult(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool?)items[1];
            CreationTime = (DateTime?)items[2];
            LastWriteTime = (DateTime?)items[3];
            Size = (long?)items[4];
        }

        public DirResult(string FilePath, bool? IsDirectory, DateTime? CreationTime, DateTime? LastWriteTime, long? Size)
        {
            this.FilePath = FilePath;
            this.IsDirectory = IsDirectory;
            this.CreationTime = CreationTime;
            this.LastWriteTime = LastWriteTime;
            this.Size = Size;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FilePath, IsDirectory, CreationTime, LastWriteTime, Size };
        }

        public override void SetItemArray(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool?)items[1];
            CreationTime = (DateTime?)items[2];
            LastWriteTime = (DateTime?)items[3];
            Size = (long?)items[4];
        }
    }

    [SqlTableFunction("SqlT", "Dir")]
    public partial class Dir : SqlTableFunctionProxy<Dir, DirResult>
    {
        [SqlParameter("@SrcPath", 0, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string SrcPath
        {
            get;
            set;
        }

        [SqlParameter("@Filter", 1, false, false), SqlTypeFacets("nvarchar", true, 250)]
        public string Filter
        {
            get;
            set;
        }

        public Dir()
        {
        }

        public Dir(object[] items)
        {
            SrcPath = (string)items[0];
            Filter = (string)items[1];
        }

        public Dir(string SrcPath, string Filter)
        {
            this.SrcPath = SrcPath;
            this.Filter = Filter;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcPath, Filter };
        }

        public override void SetItemArray(object[] items)
        {
            SrcPath = (string)items[0];
            Filter = (string)items[1];
        }
    }

    [SqlTableFunction("SqlT", "FindSqlProxyDefinition")]
    public partial class FindSqlProxyDefinition : SqlTableFunctionProxy<FindSqlProxyDefinition, ProxyProfileDefinition>
    {
        [SqlParameter("@ProfileName", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        public FindSqlProxyDefinition()
        {
        }

        public FindSqlProxyDefinition(object[] items)
        {
            ProfileName = (string)items[0];
        }

        public FindSqlProxyDefinition(string ProfileName)
        {
            this.ProfileName = ProfileName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ProfileName };
        }

        public override void SetItemArray(object[] items)
        {
            ProfileName = (string)items[0];
        }
    }

    [SqlTableFunction("SqlT", "SqlProxyDefinitionsByDatabase")]
    public partial class SqlProxyDefinitionsByDatabase : SqlTableFunctionProxy<SqlProxyDefinitionsByDatabase, ProxyProfileDefinition>
    {
        [SqlParameter("@DbName", 0, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string DbName
        {
            get;
            set;
        }

        public SqlProxyDefinitionsByDatabase()
        {
        }

        public SqlProxyDefinitionsByDatabase(object[] items)
        {
            DbName = (string)items[0];
        }

        public SqlProxyDefinitionsByDatabase(string DbName)
        {
            this.DbName = DbName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DbName };
        }

        public override void SetItemArray(object[] items)
        {
            DbName = (string)items[0];
        }
    }

    [SqlTableFunction("SqlT", "SqlProxyDefinitions")]
    public partial class SqlProxyDefinitions : SqlTableFunctionProxy<SqlProxyDefinitions, ProxyProfileDefinition>
    {
        public SqlProxyDefinitions()
        {
        }
    }

    [SqlView("SqlT", "TimeZoneDescriptor")]
    public partial class TimeZoneDescriptor : SqlViewProxy
    {
        [SqlColumn("Identifier", 0), SqlTypeFacets("nvarchar", true, 4000)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("UtcOffset", 2), SqlTypeFacets("decimal", true, 4, 2)]
        public decimal? UtcOffset
        {
            get;
            set;
        }

        [SqlColumn("OffsetDirection", 3), SqlTypeFacets("int", false)]
        public int OffsetDirection
        {
            get;
            set;
        }

        [SqlColumn("ObservervesDST", 4), SqlTypeFacets("bit", false)]
        public bool ObservervesDST
        {
            get;
            set;
        }

        public TimeZoneDescriptor()
        {
        }

        public TimeZoneDescriptor(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            UtcOffset = (decimal?)items[2];
            OffsetDirection = (int)items[3];
            ObservervesDST = (bool)items[4];
        }

        public TimeZoneDescriptor(string Identifier, string Label, decimal? UtcOffset, int OffsetDirection, bool ObservervesDST)
        {
            this.Identifier = Identifier;
            this.Label = Label;
            this.UtcOffset = UtcOffset;
            this.OffsetDirection = OffsetDirection;
            this.ObservervesDST = ObservervesDST;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Identifier, Label, UtcOffset, OffsetDirection, ObservervesDST };
        }

        public override void SetItemArray(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            UtcOffset = (decimal?)items[2];
            OffsetDirection = (int)items[3];
            ObservervesDST = (bool)items[4];
        }
    }

    [SqlView("SqlT", "TableStatsView")]
    public partial class TableStatsView : SqlViewProxy
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sql_variant", true)]
        public Object ServerName
        {
            get;
            set;
        }

        [SqlColumn("CatalogName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string CatalogName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("sysname", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("RecordCount", 4), SqlTypeFacets("int", true)]
        public int? RecordCount
        {
            get;
            set;
        }

        [SqlColumn("DataStorage (MB)", 5), SqlTypeFacets("decimal", true, 10, 3)]
        public decimal? DataStorage_ᐸMBᐳ
        {
            get;
            set;
        }

        [SqlColumn("IndexStorage (MB)", 6), SqlTypeFacets("decimal", true, 10, 3)]
        public decimal? IndexStorage_ᐸMBᐳ
        {
            get;
            set;
        }

        [SqlColumn("Total Storage (MB)", 7), SqlTypeFacets("decimal", true, 11, 3)]
        public decimal? Total_Storage_ᐸMBᐳ
        {
            get;
            set;
        }

        public TableStatsView()
        {
        }

        public TableStatsView(object[] items)
        {
            ServerName = (Object)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            RecordCount = (int?)items[4];
            DataStorage_ᐸMBᐳ = (decimal?)items[5];
            IndexStorage_ᐸMBᐳ = (decimal?)items[6];
            Total_Storage_ᐸMBᐳ = (decimal?)items[7];
        }

        public TableStatsView(Object ServerName, string CatalogName, string SchemaName, string TableName, int? RecordCount, decimal? DataStorage_ᐸMBᐳ, decimal? IndexStorage_ᐸMBᐳ, decimal? Total_Storage_ᐸMBᐳ)
        {
            this.ServerName = ServerName;
            this.CatalogName = CatalogName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.RecordCount = RecordCount;
            this.DataStorage_ᐸMBᐳ = DataStorage_ᐸMBᐳ;
            this.IndexStorage_ᐸMBᐳ = IndexStorage_ᐸMBᐳ;
            this.Total_Storage_ᐸMBᐳ = Total_Storage_ᐸMBᐳ;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, CatalogName, SchemaName, TableName, RecordCount, DataStorage_ᐸMBᐳ, IndexStorage_ᐸMBᐳ, Total_Storage_ᐸMBᐳ };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (Object)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            RecordCount = (int?)items[4];
            DataStorage_ᐸMBᐳ = (decimal?)items[5];
            IndexStorage_ᐸMBᐳ = (decimal?)items[6];
            Total_Storage_ᐸMBᐳ = (decimal?)items[7];
        }
    }

    [SqlProcedure("SqlT", "SynColumnRoleAssignments")]
    public partial class SynColumnRoleAssignments : SqlProcedureProxy
    {
        [SqlParameter("@ServerName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseName", 1, false, false), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@Assignments", 2, true, false), SqlTypeFacets("[SqlT].[ColumnRoleAssignment]", true)]
        public IEnumerable<ColumnRoleAssignment> Assignments
        {
            get;
            set;
        }

        public SynColumnRoleAssignments()
        {
        }

        public SynColumnRoleAssignments(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Assignments = (IEnumerable<ColumnRoleAssignment>)items[2];
        }

        public SynColumnRoleAssignments(string ServerName, string DatabaseName, IEnumerable<ColumnRoleAssignment> Assignments)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.Assignments = Assignments;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, Assignments };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Assignments = (IEnumerable<ColumnRoleAssignment>)items[2];
        }
    }

    [SqlProcedure("SqlT", "SyncColumnRoleTypes")]
    public partial class SyncColumnRoleTypes : SqlProcedureProxy
    {
        [SqlParameter("@Roles", 0, true, false), SqlTypeFacets("[SqlT].[LargeTypeTable]", true)]
        public IEnumerable<LargeTypeTable> Roles
        {
            get;
            set;
        }

        public SyncColumnRoleTypes()
        {
        }

        public SyncColumnRoleTypes(object[] items)
        {
            Roles = (IEnumerable<LargeTypeTable>)items[0];
        }

        public SyncColumnRoleTypes(IEnumerable<LargeTypeTable> Roles)
        {
            this.Roles = Roles;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Roles };
        }

        public override void SetItemArray(object[] items)
        {
            Roles = (IEnumerable<LargeTypeTable>)items[0];
        }
    }

    [SqlProcedure("SqlT", "RestoreBackup")]
    public partial class RestoreBackup : SqlProcedureProxy
    {
        [SqlParameter("@BackupName", 0, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string BackupName
        {
            get;
            set;
        }

        [SqlParameter("@BackupFolder", 1, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string BackupFolder
        {
            get;
            set;
        }

        [SqlParameter("@DataFolder", 2, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string DataFolder
        {
            get;
            set;
        }

        public RestoreBackup()
        {
        }

        public RestoreBackup(object[] items)
        {
            BackupName = (string)items[0];
            BackupFolder = (string)items[1];
            DataFolder = (string)items[2];
        }

        public RestoreBackup(string BackupName, string BackupFolder, string DataFolder)
        {
            this.BackupName = BackupName;
            this.BackupFolder = BackupFolder;
            this.DataFolder = DataFolder;
        }

        public override object[] GetItemArray()
        {
            return new object[] { BackupName, BackupFolder, DataFolder };
        }

        public override void SetItemArray(object[] items)
        {
            BackupName = (string)items[0];
            BackupFolder = (string)items[1];
            DataFolder = (string)items[2];
        }
    }

    [SqlProcedure("SqlT", "GoOnline")]
    public partial class GoOnline : SqlProcedureProxy
    {
        [SqlParameter("@DbName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string DbName
        {
            get;
            set;
        }

        public GoOnline()
        {
        }

        public GoOnline(object[] items)
        {
            DbName = (string)items[0];
        }

        public GoOnline(string DbName)
        {
            this.DbName = DbName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DbName };
        }

        public override void SetItemArray(object[] items)
        {
            DbName = (string)items[0];
        }
    }

    [SqlProcedure("SqlT", "GoOffline")]
    public partial class GoOffline : SqlProcedureProxy
    {
        [SqlParameter("@DbName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string DbName
        {
            get;
            set;
        }

        public GoOffline()
        {
        }

        public GoOffline(object[] items)
        {
            DbName = (string)items[0];
        }

        public GoOffline(string DbName)
        {
            this.DbName = DbName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DbName };
        }

        public override void SetItemArray(object[] items)
        {
            DbName = (string)items[0];
        }
    }

    [SqlProcedure("SqlT", "GetServerPathDefaults")]
    public partial class GetServerPathDefaults : SqlProcedureProxy<GetServerPathDefaults, DefaultFilePath>
    {
        public GetServerPathDefaults()
        {
        }
    }

    /// <summary>
    /// Retrieves descriptions for the files that match with the supplied state and file type
    /// </summary>
    [SqlProcedure("SqlT", "GetFileDescriptions")]
    public partial class GetFileDescriptions : SqlProcedureProxy
    {
        [SqlParameter("@FileState", 0, false, false), SqlTypeFacets("nvarchar", true, 50)]
        public string FileState
        {
            get;
            set;
        }

        [SqlParameter("@FileType", 1, false, false), SqlTypeFacets("nvarchar", true, 50)]
        public string FileType
        {
            get;
            set;
        }

        public GetFileDescriptions()
        {
        }

        public GetFileDescriptions(object[] items)
        {
            FileState = (string)items[0];
            FileType = (string)items[1];
        }

        public GetFileDescriptions(string FileState, string FileType)
        {
            this.FileState = FileState;
            this.FileType = FileType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FileState, FileType };
        }

        public override void SetItemArray(object[] items)
        {
            FileState = (string)items[0];
            FileType = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "ExportTableData")]
    public partial class ExportTableData : SqlProcedureProxy
    {
        [SqlParameter("@TableSchema", 0, false, false), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlParameter("@TableName", 1, false, false), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlParameter("@DstFile", 2, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string DstFile
        {
            get;
            set;
        }

        public ExportTableData()
        {
        }

        public ExportTableData(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
            DstFile = (string)items[2];
        }

        public ExportTableData(string TableSchema, string TableName, string DstFile)
        {
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.DstFile = DstFile;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TableSchema, TableName, DstFile };
        }

        public override void SetItemArray(object[] items)
        {
            TableSchema = (string)items[0];
            TableName = (string)items[1];
            DstFile = (string)items[2];
        }
    }

    [SqlProcedure("SqlT", "ExportQueryData")]
    public partial class ExportQueryData : SqlProcedureProxy
    {
        [SqlParameter("@Query", 0, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string Query
        {
            get;
            set;
        }

        [SqlParameter("@DstFile", 1, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string DstFile
        {
            get;
            set;
        }

        public ExportQueryData()
        {
        }

        public ExportQueryData(object[] items)
        {
            Query = (string)items[0];
            DstFile = (string)items[1];
        }

        public ExportQueryData(string Query, string DstFile)
        {
            this.Query = Query;
            this.DstFile = DstFile;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Query, DstFile };
        }

        public override void SetItemArray(object[] items)
        {
            Query = (string)items[0];
            DstFile = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "EnableXpCmdShell")]
    public partial class EnableXpCmdShell : SqlProcedureProxy
    {
        public EnableXpCmdShell()
        {
        }
    }

    [SqlProcedure("SqlT", "EnableStatisticsProfiling")]
    public partial class EnableStatisticsProfiling : SqlProcedureProxy
    {
        public EnableStatisticsProfiling()
        {
        }
    }

    [SqlProcedure("SqlT", "EnableSqlClr")]
    public partial class EnableSqlClr : SqlProcedureProxy
    {
        public EnableSqlClr()
        {
        }
    }

    [SqlProcedure("SqlT", "EnabledContainedDatabases")]
    public partial class EnabledContainedDatabases : SqlProcedureProxy
    {
        public EnabledContainedDatabases()
        {
        }
    }

    [SqlProcedure("SqlT", "DropDatabase")]
    public partial class DropDatabase : SqlProcedureProxy
    {
        [SqlParameter("@DbName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string DbName
        {
            get;
            set;
        }

        public DropDatabase()
        {
        }

        public DropDatabase(object[] items)
        {
            DbName = (string)items[0];
        }

        public DropDatabase(string DbName)
        {
            this.DbName = DbName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DbName };
        }

        public override void SetItemArray(object[] items)
        {
            DbName = (string)items[0];
        }
    }

    [SqlProcedure("SqlT", "DescribeBackup")]
    public partial class DescribeBackup : SqlProcedureProxy<DescribeBackup, BackupDescription>
    {
        [SqlParameter("@BackupPath", 0, false, false), SqlTypeFacets("nvarchar", true, 256)]
        public string BackupPath
        {
            get;
            set;
        }

        public DescribeBackup()
        {
        }

        public DescribeBackup(object[] items)
        {
            BackupPath = (string)items[0];
        }

        public DescribeBackup(string BackupPath)
        {
            this.BackupPath = BackupPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { BackupPath };
        }

        public override void SetItemArray(object[] items)
        {
            BackupPath = (string)items[0];
        }
    }

    [SqlProcedure("SqlT", "CreateLinkedServer")]
    public partial class CreateLinkedServer : SqlProcedureProxy
    {
        [SqlParameter("@Alias", 0, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string Alias
        {
            get;
            set;
        }

        [SqlParameter("@HostName", 1, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string HostName
        {
            get;
            set;
        }

        [SqlParameter("@User", 2, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string User
        {
            get;
            set;
        }

        [SqlParameter("@Password", 3, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string Password
        {
            get;
            set;
        }

        public CreateLinkedServer()
        {
        }

        public CreateLinkedServer(object[] items)
        {
            Alias = (string)items[0];
            HostName = (string)items[1];
            User = (string)items[2];
            Password = (string)items[3];
        }

        public CreateLinkedServer(string Alias, string HostName, string User, string Password)
        {
            this.Alias = Alias;
            this.HostName = HostName;
            this.User = User;
            this.Password = Password;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Alias, HostName, User, Password };
        }

        public override void SetItemArray(object[] items)
        {
            Alias = (string)items[0];
            HostName = (string)items[1];
            User = (string)items[2];
            Password = (string)items[3];
        }
    }

    [SqlProcedure("SqlT", "ConfigureServerOption")]
    public partial class ConfigureServerOption : SqlProcedureProxy
    {
        [SqlParameter("@OptionName", 0, false, false), SqlTypeFacets("varchar", true, 35)]
        public string OptionName
        {
            get;
            set;
        }

        [SqlParameter("@OptionValue", 1, false, false), SqlTypeFacets("int", true)]
        public int? OptionValue
        {
            get;
            set;
        }

        public ConfigureServerOption()
        {
        }

        public ConfigureServerOption(object[] items)
        {
            OptionName = (string)items[0];
            OptionValue = (int?)items[1];
        }

        public ConfigureServerOption(string OptionName, int? OptionValue)
        {
            this.OptionName = OptionName;
            this.OptionValue = OptionValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { OptionName, OptionValue };
        }

        public override void SetItemArray(object[] items)
        {
            OptionName = (string)items[0];
            OptionValue = (int?)items[1];
        }
    }

    /// <summary>
    /// Specifies and applies a server-level setting
    /// </summary>
    [SqlProcedure("SqlT", "ConfigureServer")]
    public partial class ConfigureServer : SqlProcedureProxy
    {
        [SqlParameter("@SettingName", 0, false, false), SqlTypeFacets("varchar", true, 35)]
        public string SettingName
        {
            get;
            set;
        }

        [SqlParameter("@SettingValue", 1, false, false), SqlTypeFacets("int", true)]
        public int? SettingValue
        {
            get;
            set;
        }

        public ConfigureServer()
        {
        }

        public ConfigureServer(object[] items)
        {
            SettingName = (string)items[0];
            SettingValue = (int?)items[1];
        }

        public ConfigureServer(string SettingName, int? SettingValue)
        {
            this.SettingName = SettingName;
            this.SettingValue = SettingValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SettingName, SettingValue };
        }

        public override void SetItemArray(object[] items)
        {
            SettingName = (string)items[0];
            SettingValue = (int?)items[1];
        }
    }

    [SqlProcedure("SqlT", "StoreDataTypeDescriptions")]
    public partial class StoreDataTypeDescriptions : SqlProcedureProxy
    {
        [SqlParameter("@Descriptions", 0, true, false), SqlTypeFacets("[SqlT].[DataTypeDescription]", true)]
        public IEnumerable<DataTypeDescription> Descriptions
        {
            get;
            set;
        }

        public StoreDataTypeDescriptions()
        {
        }

        public StoreDataTypeDescriptions(object[] items)
        {
            Descriptions = (IEnumerable<DataTypeDescription>)items[0];
        }

        public StoreDataTypeDescriptions(IEnumerable<DataTypeDescription> Descriptions)
        {
            this.Descriptions = Descriptions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Descriptions };
        }

        public override void SetItemArray(object[] items)
        {
            Descriptions = (IEnumerable<DataTypeDescription>)items[0];
        }
    }

    [SqlProcedure("SqlT", "StoreNativeTypes")]
    public partial class StoreNativeTypes : SqlProcedureProxy
    {
        public StoreNativeTypes()
        {
        }
    }

    [SqlProcedure("SqlT", "SynColumnGroupMemberships")]
    public partial class SynColumnGroupMemberships : SqlProcedureProxy
    {
        [SqlParameter("@ServerName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseName", 1, false, false), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@Assignments", 2, true, false), SqlTypeFacets("[SqlT].[ColumnGroupMember]", true)]
        public IEnumerable<ColumnGroupMember> Assignments
        {
            get;
            set;
        }

        public SynColumnGroupMemberships()
        {
        }

        public SynColumnGroupMemberships(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Assignments = (IEnumerable<ColumnGroupMember>)items[2];
        }

        public SynColumnGroupMemberships(string ServerName, string DatabaseName, IEnumerable<ColumnGroupMember> Assignments)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.Assignments = Assignments;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, Assignments };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Assignments = (IEnumerable<ColumnGroupMember>)items[2];
        }
    }

    [SqlProcedure("SqlT", "StoreBackupDescriptions")]
    public partial class StoreBackupDescriptions : SqlProcedureProxy
    {
        [SqlParameter("@HostName", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string HostName
        {
            get;
            set;
        }

        [SqlParameter("@HostPath", 1, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string HostPath
        {
            get;
            set;
        }

        [SqlParameter("@Descriptions", 2, true, false), SqlTypeFacets("[SqlT].[BackupDescription]", true)]
        public IEnumerable<BackupDescription> Descriptions
        {
            get;
            set;
        }

        public StoreBackupDescriptions()
        {
        }

        public StoreBackupDescriptions(object[] items)
        {
            HostName = (string)items[0];
            HostPath = (string)items[1];
            Descriptions = (IEnumerable<BackupDescription>)items[2];
        }

        public StoreBackupDescriptions(string HostName, string HostPath, IEnumerable<BackupDescription> Descriptions)
        {
            this.HostName = HostName;
            this.HostPath = HostPath;
            this.Descriptions = Descriptions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostName, HostPath, Descriptions };
        }

        public override void SetItemArray(object[] items)
        {
            HostName = (string)items[0];
            HostPath = (string)items[1];
            Descriptions = (IEnumerable<BackupDescription>)items[2];
        }
    }

    [SqlProcedure("SqlT", "SyncSqlProxyDefinitions")]
    public partial class SyncSqlProxyDefinitions : SqlProcedureProxy
    {
        [SqlParameter("@Specs", 0, true, false), SqlTypeFacets("[SqlT].[ProxyProfileDefinition]", true)]
        public IEnumerable<ProxyProfileDefinition> Specs
        {
            get;
            set;
        }

        public SyncSqlProxyDefinitions()
        {
        }

        public SyncSqlProxyDefinitions(object[] items)
        {
            Specs = (IEnumerable<ProxyProfileDefinition>)items[0];
        }

        public SyncSqlProxyDefinitions(IEnumerable<ProxyProfileDefinition> Specs)
        {
            this.Specs = Specs;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Specs };
        }

        public override void SetItemArray(object[] items)
        {
            Specs = (IEnumerable<ProxyProfileDefinition>)items[0];
        }
    }

    [SqlProcedure("SqlT", "SyncDatabases")]
    public partial class SyncDatabases : SqlProcedureProxy
    {
        [SqlParameter("@ServerName", 0, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlParameter("@Databases", 1, true, false), SqlTypeFacets("[SqlT].[Database]", true)]
        public IEnumerable<Database> Databases
        {
            get;
            set;
        }

        public SyncDatabases()
        {
        }

        public SyncDatabases(object[] items)
        {
            ServerName = (string)items[0];
            Databases = (IEnumerable<Database>)items[1];
        }

        public SyncDatabases(string ServerName, IEnumerable<Database> Databases)
        {
            this.ServerName = ServerName;
            this.Databases = Databases;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, Databases };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            Databases = (IEnumerable<Database>)items[1];
        }
    }

    [SqlProcedure("SqlT", "SetVar")]
    public partial class SetVar : SqlProcedureProxy
    {
        [SqlParameter("@VarName", 0, false, false), SqlTypeFacets("nvarchar", true, 250)]
        public string VarName
        {
            get;
            set;
        }

        [SqlParameter("@VarValue", 1, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string VarValue
        {
            get;
            set;
        }

        public SetVar()
        {
        }

        public SetVar(object[] items)
        {
            VarName = (string)items[0];
            VarValue = (string)items[1];
        }

        public SetVar(string VarName, string VarValue)
        {
            this.VarName = VarName;
            this.VarValue = VarValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { VarName, VarValue };
        }

        public override void SetItemArray(object[] items)
        {
            VarName = (string)items[0];
            VarValue = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "WriteTextToFile")]
    public partial class WriteTextToFile : SqlProcedureProxy
    {
        [SqlParameter("@SrcText", 0, false, false), SqlTypeFacets("nvarchar", true, 0)]
        public string SrcText
        {
            get;
            set;
        }

        [SqlParameter("@DstPath", 1, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string DstPath
        {
            get;
            set;
        }

        public WriteTextToFile()
        {
        }

        public WriteTextToFile(object[] items)
        {
            SrcText = (string)items[0];
            DstPath = (string)items[1];
        }

        public WriteTextToFile(string SrcText, string DstPath)
        {
            this.SrcText = SrcText;
            this.DstPath = DstPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcText, DstPath };
        }

        public override void SetItemArray(object[] items)
        {
            SrcText = (string)items[0];
            DstPath = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "SyncTables")]
    public partial class SyncTables : SqlProcedureProxy
    {
        [SqlParameter("@ServerName", 0, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseName", 1, false, false), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@Tables", 2, true, false), SqlTypeFacets("[SqlT].[TableDescription]", true)]
        public IEnumerable<TableDescription> Tables
        {
            get;
            set;
        }

        [SqlParameter("@Columns", 3, true, false), SqlTypeFacets("[SqlT].[TableColumn]", true)]
        public IEnumerable<TableColumn> Columns
        {
            get;
            set;
        }

        public SyncTables()
        {
        }

        public SyncTables(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Tables = (IEnumerable<TableDescription>)items[2];
            Columns = (IEnumerable<TableColumn>)items[3];
        }

        public SyncTables(string ServerName, string DatabaseName, IEnumerable<TableDescription> Tables, IEnumerable<TableColumn> Columns)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.Tables = Tables;
            this.Columns = Columns;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, Tables, Columns };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            Tables = (IEnumerable<TableDescription>)items[2];
            Columns = (IEnumerable<TableColumn>)items[3];
        }
    }

    [SqlProcedure("SqlT", "HttpPost")]
    public partial class HttpPost : SqlProcedureProxy
    {
        [SqlParameter("@url", 0, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string url
        {
            get;
            set;
        }

        [SqlParameter("@json", 1, false, false), SqlTypeFacets("nvarchar", true, 0)]
        public string json
        {
            get;
            set;
        }

        public HttpPost()
        {
        }

        public HttpPost(object[] items)
        {
            url = (string)items[0];
            json = (string)items[1];
        }

        public HttpPost(string url, string json)
        {
            this.url = url;
            this.json = json;
        }

        public override object[] GetItemArray()
        {
            return new object[] { url, json };
        }

        public override void SetItemArray(object[] items)
        {
            url = (string)items[0];
            json = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "SyncForeignKeys")]
    public partial class SyncForeignKeys : SqlProcedureProxy
    {
        [SqlParameter("@ServerName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseName", 1, false, false), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@ForeignKeys", 2, true, false), SqlTypeFacets("[SqlT].[ForeignKeyInfo]", true)]
        public IEnumerable<ForeignKeyInfo> ForeignKeys
        {
            get;
            set;
        }

        public SyncForeignKeys()
        {
        }

        public SyncForeignKeys(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeys = (IEnumerable<ForeignKeyInfo>)items[2];
        }

        public SyncForeignKeys(string ServerName, string DatabaseName, IEnumerable<ForeignKeyInfo> ForeignKeys)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ForeignKeys = ForeignKeys;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ForeignKeys };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeys = (IEnumerable<ForeignKeyInfo>)items[2];
        }
    }

    [SqlProcedure("SqlT", "CopyFolder")]
    public partial class CopyFolder : SqlProcedureProxy
    {
        [SqlParameter("@SrcPath", 0, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string SrcPath
        {
            get;
            set;
        }

        [SqlParameter("@DstPath", 1, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string DstPath
        {
            get;
            set;
        }

        public CopyFolder()
        {
        }

        public CopyFolder(object[] items)
        {
            SrcPath = (string)items[0];
            DstPath = (string)items[1];
        }

        public CopyFolder(string SrcPath, string DstPath)
        {
            this.SrcPath = SrcPath;
            this.DstPath = DstPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcPath, DstPath };
        }

        public override void SetItemArray(object[] items)
        {
            SrcPath = (string)items[0];
            DstPath = (string)items[1];
        }
    }

    [SqlProcedure("SqlT", "StoreTableQueries")]
    public partial class StoreTableQueries : SqlProcedureProxy
    {
        [SqlParameter("@Tables", 0, true, false), SqlTypeFacets("[SqlT].[TableQuery]", true)]
        public IEnumerable<TableQuery> Tables
        {
            get;
            set;
        }

        [SqlParameter("@Columns", 1, true, false), SqlTypeFacets("[SqlT].[TableQueryColumn]", true)]
        public IEnumerable<TableQueryColumn> Columns
        {
            get;
            set;
        }

        [SqlParameter("@Comparisons", 2, true, false), SqlTypeFacets("[SqlT].[ColumnComparison]", true)]
        public IEnumerable<ColumnComparison> Comparisons
        {
            get;
            set;
        }

        public StoreTableQueries()
        {
        }

        public StoreTableQueries(object[] items)
        {
            Tables = (IEnumerable<TableQuery>)items[0];
            Columns = (IEnumerable<TableQueryColumn>)items[1];
            Comparisons = (IEnumerable<ColumnComparison>)items[2];
        }

        public StoreTableQueries(IEnumerable<TableQuery> Tables, IEnumerable<TableQueryColumn> Columns, IEnumerable<ColumnComparison> Comparisons)
        {
            this.Tables = Tables;
            this.Columns = Columns;
            this.Comparisons = Comparisons;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Tables, Columns, Comparisons };
        }

        public override void SetItemArray(object[] items)
        {
            Tables = (IEnumerable<TableQuery>)items[0];
            Columns = (IEnumerable<TableQueryColumn>)items[1];
            Comparisons = (IEnumerable<ColumnComparison>)items[2];
        }
    }

    [SqlProcedure("SqlT", "CopyFile")]
    public partial class CopyFile : SqlProcedureProxy
    {
        [SqlParameter("@SrcPath", 0, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string SrcPath
        {
            get;
            set;
        }

        [SqlParameter("@DstPath", 1, false, false), SqlTypeFacets("nvarchar", true, 4000)]
        public string DstPath
        {
            get;
            set;
        }

        public CopyFile()
        {
        }

        public CopyFile(object[] items)
        {
            SrcPath = (string)items[0];
            DstPath = (string)items[1];
        }

        public CopyFile(string SrcPath, string DstPath)
        {
            this.SrcPath = SrcPath;
            this.DstPath = DstPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcPath, DstPath };
        }

        public override void SetItemArray(object[] items)
        {
            SrcPath = (string)items[0];
            DstPath = (string)items[1];
        }
    }
}
// Emission concluded at 5/12/2018 8:42:24 PM
