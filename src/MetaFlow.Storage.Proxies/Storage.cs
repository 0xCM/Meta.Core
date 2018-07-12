//This file was generated at 7/9/2018 7:10:09 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.Core.Storage
{
    using System;
    using System.Collections.Generic;
    using SqlT.Types;
    using SqlT.Types.MC;
    using MetaFlow.Core;
    using MetaFlow.XE;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class PFTableNames
    {
        public const string ArtifactReferenceStore = "[PF].[ArtifactReferenceStore]";
        public const string ComponentType = "[PF].[ComponentType]";
        public const string DacDeployLog = "[PF].[DacDeployLog]";
        public const string DacProfileStore = "[PF].[DacProfileStore]";
        public const string DatabaseBackup = "[PF].[DatabaseBackup]";
        public const string DatabaseBackupArchive = "[PF].[DatabaseBackupArchive]";
        public const string DatabaseCreateLog = "[PF].[DatabaseCreateLog]";
        public const string DatabaseDropLog = "[PF].[DatabaseDropLog]";
        public const string DatabaseServerRegistry = "[PF].[DatabaseServerRegistry]";
        public const string DatabaseVersionStore = "[PF].[DatabaseVersionStore]";
        public const string DistributionRegistry = "[PF].[DistributionRegistry]";
        public const string EnterpriseDatabaseType = "[PF].[EnterpriseDatabaseType]";
        public const string EnterpriseServerType = "[PF].[EnterpriseServerType]";
        public const string EnterpriseShareDefinition = "[PF].[EnterpriseShareDefinition]";
        public const string FileReceiptLog = "[PF].[FileReceiptLog]";
        public const string MessageClass = "[PF].[MessageClass]";
        public const string MessageFormatArchive = "[PF].[MessageFormatArchive]";
        public const string MessageFormatDefinition = "[PF].[MessageFormatDefinition]";
        public const string MessageTypeAttribute = "[PF].[MessageTypeAttribute]";
        public const string MessageTypeRegistry = "[PF].[MessageTypeRegistry]";
        public const string ModelDatabaseRegistry = "[PF].[ModelDatabaseRegistry]";
        public const string MonitoredTableSetting = "[PF].[MonitoredTableSetting]";
        public const string NavigationFolderDefinition = "[PF].[NavigationFolderDefinition]";
        public const string NodeDriveMapDefinition = "[PF].[NodeDriveMapDefinition]";
        public const string PlatformAgentRegistry = "[PF].[PlatformAgentRegistry]";
        public const string PlatformArtifactType = "[PF].[PlatformArtifactType]";
        public const string PlatformChannelType = "[PF].[PlatformChannelType]";
        public const string PlatformDacRegistry = "[PF].[PlatformDacRegistry]";
        public const string PlatformDatabaseRegistry = "[PF].[PlatformDatabaseRegistry]";
        public const string PlatformDatabaseType = "[PF].[PlatformDatabaseType]";
        public const string PlatformDatabaseVersionHistory = "[PF].[PlatformDatabaseVersionHistory]";
        public const string PlatformEntityChangeLog = "[PF].[PlatformEntityChangeLog]";
        public const string PlatformEntityStore = "[PF].[PlatformEntityStore]";
        public const string PlatformFileType = "[PF].[PlatformFileType]";
        public const string PlatformNavigatorType = "[PF].[PlatformNavigatorType]";
        public const string PlatformProjectRegistry = "[PF].[PlatformProjectRegistry]";
        public const string PlatformServerRegistry = "[PF].[PlatformServerRegistry]";
        public const string PlatformShareDefinition = "[PF].[PlatformShareDefinition]";
        public const string PlatformShareFolderType = "[PF].[PlatformShareFolderType]";
        public const string PlatformShareRegistry = "[PF].[PlatformShareRegistry]";
        public const string PlatformShareType = "[PF].[PlatformShareType]";
        public const string PlatformSolutionStore = "[PF].[PlatformSolutionStore]";
        public const string PlatformStoreChangeLog = "[PF].[PlatformStoreChangeLog]";
        public const string PlatformSystemRegistry = "[PF].[PlatformSystemRegistry]";
        public const string PlatformSystemType = "[PF].[PlatformSystemType]";
        public const string PlatformVariableStore = "[PF].[PlatformVariableStore]";
        public const string ReceivedFile = "[PF].[ReceivedFile]";
        public const string SqlArtifactType = "[PF].[SqlArtifactType]";
        public const string SqlMessageDefinition = "[PF].[SqlMessageDefinition]";
        public const string SystemCommandRegistry = "[PF].[SystemCommandRegistry]";
        public const string SystemComponentRegistry = "[PF].[SystemComponentRegistry]";
        public const string SystemDistribution = "[PF].[SystemDistribution]";
        public const string SystemEventRegistry = "[PF].[SystemEventRegistry]";
        public const string SystemLog = "[PF].[SystemLog]";
        public const string SystemProxyDefinition = "[PF].[SystemProxyDefinition]";
        public const string TableMonitorLog = "[PF].[TableMonitorLog]";
        public const string ToolDistribution = "[PF].[ToolDistribution]";
        public const string TypedDataFlowRegistry = "[PF].[TypedDataFlowRegistry]";
        public const string TypeSystemDataType = "[PF].[TypeSystemDataType]";
        public const string TypeSystemType = "[PF].[TypeSystemType]";
        public const string VirtualDisk = "[PF].[VirtualDisk]";
    }

    public sealed class PFViewNames
    {
        public const string ExecutingNode = "[PF].[ExecutingNode]";
        public const string ExecutingServer = "[PF].[ExecutingServer]";
        public const string HostDatabase = "[PF].[HostDatabase]";
        public const string PlatformDatabaseDescription = "[PF].[PlatformDatabaseDescription]";
        public const string PlatformDatabaseServer = "[PF].[PlatformDatabaseServer]";
        public const string PlatformNotificationData = "[PF].[PlatformNotificationData]";
    }

    public sealed class PFSequenceNames
    {
        public const string DacDeploymentIdSequence = "[PF].[DacDeploymentIdSequence]";
        public const string FileReceiptSequence = "[PF].[FileReceiptSequence]";
        public const string LogEntrySequence = "[PF].[LogEntrySequence]";
        public const string PlatformSettingSequence = "[PF].[PlatformSettingSequence]";
        public const string PlatformStoreChangeSequence = "[PF].[PlatformStoreChangeSequence]";
        public const string RuntimeKeySequence = "[PF].[RuntimeKeySequence]";
        public const string SystemKeySequence = "[PF].[SystemKeySequence]";
        public const string TableMonitorLogSequence = "[PF].[TableMonitorLogSequence]";
    }

    public sealed class PFProcedureNames
    {
        public const string ApplyDropLogs = "[PF].[ApplyDropLogs]";
        public const string ConfigureTableMonitoring = "[PF].[ConfigureTableMonitoring]";
        public const string DefineSqlMessages = "[PF].[DefineSqlMessages]";
        public const string HandleReleaseReceipt = "[PF].[HandleReleaseReceipt]";
        public const string LogDacDeployFinish = "[PF].[LogDacDeployFinish]";
        public const string LogDacDeployStart = "[PF].[LogDacDeployStart]";
        public const string LogFileReceipt = "[PF].[LogFileReceipt]";
        public const string LogPlatformStoreChanges = "[PF].[LogPlatformStoreChanges]";
        public const string PopFileReceiptQueue = "[PF].[PopFileReceiptQueue]";
        public const string ProcessReleases = "[PF].[ProcessReleases]";
        public const string PublishFileReceipt = "[PF].[PublishFileReceipt]";
        public const string PurgeFileReceiptQueue = "[PF].[PurgeFileReceiptQueue]";
        public const string RegisterHostDatabase = "[PF].[RegisterHostDatabase]";
        public const string StoreArtifactReferences = "[PF].[StoreArtifactReferences]";
        public const string StoreDatabaseVersions = "[PF].[StoreDatabaseVersions]";
        public const string StorePlatformEntities = "[PF].[StorePlatformEntities]";
        public const string StorePlatformEntity = "[PF].[StorePlatformEntity]";
        public const string StorePlatformVariables = "[PF].[StorePlatformVariables]";
        public const string StoreTableMonitorLogEntries = "[PF].[StoreTableMonitorLogEntries]";
        public const string StubMessageFormats = "[PF].[StubMessageFormats]";
        public const string SyncDacProfiles = "[PF].[SyncDacProfiles]";
        public const string SyncDatabaseServers = "[PF].[SyncDatabaseServers]";
        public const string SyncDistributionRegistry = "[PF].[SyncDistributionRegistry]";
        public const string SyncEventRegistry = "[PF].[SyncEventRegistry]";
        public const string SyncHostDatabases = "[PF].[SyncHostDatabases]";
        public const string SyncMessageClasses = "[PF].[SyncMessageClasses]";
        public const string SyncMessageFormats = "[PF].[SyncMessageFormats]";
        public const string SyncMessageTypeRegistry = "[PF].[SyncMessageTypeRegistry]";
        public const string SyncPlatformAgents = "[PF].[SyncPlatformAgents]";
        public const string SyncPlatformDacRegistry = "[PF].[SyncPlatformDacRegistry]";
        public const string SyncPlatformDatabases = "[PF].[SyncPlatformDatabases]";
        public const string SyncPlatformProjects = "[PF].[SyncPlatformProjects]";
        public const string SyncPlatformServerRegistry = "[PF].[SyncPlatformServerRegistry]";
        public const string SyncPlatformSolutions = "[PF].[SyncPlatformSolutions]";
        public const string SyncPlatformSystems = "[PF].[SyncPlatformSystems]";
        public const string SyncSqlProxyDefinitions = "[PF].[SyncSqlProxyDefinitions]";
        public const string SyncSystemCommandRegistry = "[PF].[SyncSystemCommandRegistry]";
        public const string SyncSystemComponents = "[PF].[SyncSystemComponents]";
        public const string SyncTypedDataFlowRegistry = "[PF].[SyncTypedDataFlowRegistry]";
        public const string UnregisterMissingHostDatabases = "[PF].[UnregisterMissingHostDatabases]";
    }

    public sealed class PFTableFunctionNames
    {
        public const string ArchivedPlatformNotifications = "[PF].[ArchivedPlatformNotifications]";
        public const string DacProfiles = "[PF].[DacProfiles]";
        public const string DatabaseBackups = "[PF].[DatabaseBackups]";
        public const string DatabaseServers = "[PF].[DatabaseServers]";
        public const string FindDatabaseProfiles = "[PF].[FindDatabaseProfiles]";
        public const string FindPlatformEntity = "[PF].[FindPlatformEntity]";
        public const string FindSqlProxyDefinition = "[PF].[FindSqlProxyDefinition]";
        public const string HostFiles = "[PF].[HostFiles]";
        public const string MessageAttributes = "[PF].[MessageAttributes]";
        public const string MessageClasses = "[PF].[MessageClasses]";
        public const string MessageFormats = "[PF].[MessageFormats]";
        public const string MessageTypes = "[PF].[MessageTypes]";
        public const string MonitoredTables = "[PF].[MonitoredTables]";
        public const string NavigationFolders = "[PF].[NavigationFolders]";
        public const string PlatformAgents = "[PF].[PlatformAgents]";
        public const string PlatformDacs = "[PF].[PlatformDacs]";
        public const string PlatformDatabaseProfiles = "[PF].[PlatformDatabaseProfiles]";
        public const string PlatformDatabases = "[PF].[PlatformDatabases]";
        public const string PlatformNotifications = "[PF].[PlatformNotifications]";
        public const string PlatformProjects = "[PF].[PlatformProjects]";
        public const string PlatformReleases = "[PF].[PlatformReleases]";
        public const string PlatformServers = "[PF].[PlatformServers]";
        public const string PlatformSolutions = "[PF].[PlatformSolutions]";
        public const string ProjectComponents = "[PF].[ProjectComponents]";
        public const string RegisteredDistributions = "[PF].[RegisteredDistributions]";
        public const string SqlMessageDefinitions = "[PF].[SqlMessageDefinitions]";
        public const string SqlProxyDefinitions = "[PF].[SqlProxyDefinitions]";
        public const string SqlProxyDefinitionsByDatabase = "[PF].[SqlProxyDefinitionsByDatabase]";
        public const string SqlProxyProjects = "[PF].[SqlProxyProjects]";
        public const string SystemCommands = "[PF].[SystemCommands]";
        public const string SystemComponents = "[PF].[SystemComponents]";
        public const string SystemEvents = "[PF].[SystemEvents]";
        public const string Systems = "[PF].[Systems]";
        public const string TableMonitorLogEntries = "[PF].[TableMonitorLogEntries]";
        public const string TargetedDatabaseComponents = "[PF].[TargetedDatabaseComponents]";
        public const string TypedDataFlows = "[PF].[TypedDataFlows]";
        public const string UnclassifiedDatabases = "[PF].[UnclassifiedDatabases]";
        public const string XEventDataBlocks = "[PF].[XEventDataBlocks]";
        public const string XEventLogFiles = "[PF].[XEventLogFiles]";
    }

    /// <summary>
    /// Declares the columns defined by the PF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDatabaseDropEventData
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false)]
        string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false)]
        string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("LoginName", 2), SqlTypeFacets("nvarchar", false)]
        string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime EventTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the PF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDatabaseCreateEventData
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false)]
        string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false)]
        string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("LoginName", 2), SqlTypeFacets("nvarchar", false)]
        string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime EventTS
        {
            get;
            set;
        }
    }

    [SqlTable("PF", "MessageFormatArchive")]
    public partial class MessageFormatArchive : SqlTableProxy<MessageFormatArchive>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("int", false)]
        public int SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 1), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 2), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("FormatTemplate", 3), SqlTypeFacets("nvarchar", false)]
        public string FormatTemplate
        {
            get;
            set;
        }

        [SqlColumn("P1", 4), SqlTypeFacets("nvarchar", true)]
        public string P1
        {
            get;
            set;
        }

        [SqlColumn("P2", 5), SqlTypeFacets("nvarchar", true)]
        public string P2
        {
            get;
            set;
        }

        [SqlColumn("P3", 6), SqlTypeFacets("nvarchar", true)]
        public string P3
        {
            get;
            set;
        }

        [SqlColumn("P4", 7), SqlTypeFacets("nvarchar", true)]
        public string P4
        {
            get;
            set;
        }

        [SqlColumn("P5", 8), SqlTypeFacets("nvarchar", true)]
        public string P5
        {
            get;
            set;
        }

        [SqlColumn("P6", 9), SqlTypeFacets("nvarchar", true)]
        public string P6
        {
            get;
            set;
        }

        [SqlColumn("P7", 10), SqlTypeFacets("nvarchar", true)]
        public string P7
        {
            get;
            set;
        }

        [SqlColumn("P8", 11), SqlTypeFacets("nvarchar", true)]
        public string P8
        {
            get;
            set;
        }

        [SqlColumn("P9", 12), SqlTypeFacets("nvarchar", true)]
        public string P9
        {
            get;
            set;
        }

        [SqlColumn("ArchiveTS", 13), SqlTypeFacets("datetime2", false)]
        public DateTime ArchiveTS
        {
            get;
            set;
        }

        public MessageFormatArchive()
        {
        }

        public MessageFormatArchive(object[] items)
        {
            SystemKey = (int)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            FormatTemplate = (string)items[3];
            P1 = (string)items[4];
            P2 = (string)items[5];
            P3 = (string)items[6];
            P4 = (string)items[7];
            P5 = (string)items[8];
            P6 = (string)items[9];
            P7 = (string)items[10];
            P8 = (string)items[11];
            P9 = (string)items[12];
            ArchiveTS = (DateTime)items[13];
        }

        public MessageFormatArchive(int SystemKey, string SchemaName, string TypeName, string FormatTemplate, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, DateTime ArchiveTS)
        {
            this.SystemKey = SystemKey;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.FormatTemplate = FormatTemplate;
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
            this.P4 = P4;
            this.P5 = P5;
            this.P6 = P6;
            this.P7 = P7;
            this.P8 = P8;
            this.P9 = P9;
            this.ArchiveTS = ArchiveTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SchemaName, TypeName, FormatTemplate, P1, P2, P3, P4, P5, P6, P7, P8, P9, ArchiveTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (int)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            FormatTemplate = (string)items[3];
            P1 = (string)items[4];
            P2 = (string)items[5];
            P3 = (string)items[6];
            P4 = (string)items[7];
            P5 = (string)items[8];
            P6 = (string)items[9];
            P7 = (string)items[10];
            P8 = (string)items[11];
            P9 = (string)items[12];
            ArchiveTS = (DateTime)items[13];
        }
    }

    [SqlTable("PF", "MessageFormatDefinition")]
    public partial class MessageFormatDefinition : SqlTableProxy<MessageFormatDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("int", false)]
        public int SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 1), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 2), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("FormatTemplate", 3), SqlTypeFacets("nvarchar", false)]
        public string FormatTemplate
        {
            get;
            set;
        }

        [SqlColumn("P1", 4), SqlTypeFacets("nvarchar", true)]
        public string P1
        {
            get;
            set;
        }

        [SqlColumn("P2", 5), SqlTypeFacets("nvarchar", true)]
        public string P2
        {
            get;
            set;
        }

        [SqlColumn("P3", 6), SqlTypeFacets("nvarchar", true)]
        public string P3
        {
            get;
            set;
        }

        [SqlColumn("P4", 7), SqlTypeFacets("nvarchar", true)]
        public string P4
        {
            get;
            set;
        }

        [SqlColumn("P5", 8), SqlTypeFacets("nvarchar", true)]
        public string P5
        {
            get;
            set;
        }

        [SqlColumn("P6", 9), SqlTypeFacets("nvarchar", true)]
        public string P6
        {
            get;
            set;
        }

        [SqlColumn("P7", 10), SqlTypeFacets("nvarchar", true)]
        public string P7
        {
            get;
            set;
        }

        [SqlColumn("P8", 11), SqlTypeFacets("nvarchar", true)]
        public string P8
        {
            get;
            set;
        }

        [SqlColumn("P9", 12), SqlTypeFacets("nvarchar", true)]
        public string P9
        {
            get;
            set;
        }

        public MessageFormatDefinition()
        {
        }

        public MessageFormatDefinition(object[] items)
        {
            SystemKey = (int)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            FormatTemplate = (string)items[3];
            P1 = (string)items[4];
            P2 = (string)items[5];
            P3 = (string)items[6];
            P4 = (string)items[7];
            P5 = (string)items[8];
            P6 = (string)items[9];
            P7 = (string)items[10];
            P8 = (string)items[11];
            P9 = (string)items[12];
        }

        public MessageFormatDefinition(int SystemKey, string SchemaName, string TypeName, string FormatTemplate, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
        {
            this.SystemKey = SystemKey;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.FormatTemplate = FormatTemplate;
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
            this.P4 = P4;
            this.P5 = P5;
            this.P6 = P6;
            this.P7 = P7;
            this.P8 = P8;
            this.P9 = P9;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SchemaName, TypeName, FormatTemplate, P1, P2, P3, P4, P5, P6, P7, P8, P9 };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (int)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            FormatTemplate = (string)items[3];
            P1 = (string)items[4];
            P2 = (string)items[5];
            P3 = (string)items[6];
            P4 = (string)items[7];
            P5 = (string)items[8];
            P6 = (string)items[9];
            P7 = (string)items[10];
            P8 = (string)items[11];
            P9 = (string)items[12];
        }
    }

    [SqlTable("PF", "MessageTypeAttribute")]
    public partial class MessageTypeAttribute : SqlTableProxy<MessageTypeAttribute>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 3), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("nvarchar", false)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 5), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 6), SqlTypeFacets("nvarchar", false)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 7), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("Length", 8), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 9), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 10), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("Description", 11), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public MessageTypeAttribute()
        {
        }

        public MessageTypeAttribute(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnPosition = (int)items[5];
            DataTypeName = (string)items[6];
            IsNullable = (bool)items[7];
            Length = (int?)items[8];
            Precision = (byte?)items[9];
            Scale = (byte?)items[10];
            Description = (string)items[11];
        }

        public MessageTypeAttribute(long SystemKey, string SystemId, string SchemaName, string TypeName, string ColumnName, int ColumnPosition, string DataTypeName, bool IsNullable, int? Length, byte? Precision, byte? Scale, string Description)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.DataTypeName = DataTypeName;
            this.IsNullable = IsNullable;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, SchemaName, TypeName, ColumnName, ColumnPosition, DataTypeName, IsNullable, Length, Precision, Scale, Description };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnPosition = (int)items[5];
            DataTypeName = (string)items[6];
            IsNullable = (bool)items[7];
            Length = (int?)items[8];
            Precision = (byte?)items[9];
            Scale = (byte?)items[10];
            Description = (string)items[11];
        }
    }

    [SqlTable("PF", "MessageTypeRegistry")]
    public partial class MessageTypeRegistry : SqlTableProxy<MessageTypeRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 3), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("MessageClass", 4), SqlTypeFacets("nvarchar", false)]
        public string MessageClass
        {
            get;
            set;
        }

        [SqlColumn("Description", 5), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public MessageTypeRegistry()
        {
        }

        public MessageTypeRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            MessageClass = (string)items[4];
            Description = (string)items[5];
        }

        public MessageTypeRegistry(long SystemKey, string SystemId, string SchemaName, string TypeName, string MessageClass, string Description)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.MessageClass = MessageClass;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, SchemaName, TypeName, MessageClass, Description };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            MessageClass = (string)items[4];
            Description = (string)items[5];
        }
    }

    [SqlTable("PF", "ModelDatabaseRegistry")]
    public partial class ModelDatabaseRegistry : SqlTableProxy<ModelDatabaseRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("NodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 3), SqlTypeFacets("nvarchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        public ModelDatabaseRegistry()
        {
        }

        public ModelDatabaseRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
        }

        public ModelDatabaseRegistry(long SystemKey, string NodeId, string DatabaseName, string DatabaseType)
        {
            this.SystemKey = SystemKey;
            this.NodeId = NodeId;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, NodeId, DatabaseName, DatabaseType };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
        }
    }

    [SqlTable("PF", "DatabaseBackupArchive")]
    public partial class DatabaseBackupArchive : SqlTableProxy<DatabaseBackupArchive>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public DatabaseBackupArchive()
        {
        }

        public DatabaseBackupArchive(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public DatabaseBackupArchive(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "MonitoredTableSetting")]
    public partial class MonitoredTableSetting : SqlTableProxy<MonitoredTableSetting>
    {
        [SqlColumn("SettingId", 0), SqlTypeFacets("int", false)]
        public int SettingId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("MonitorFrequency", 5), SqlTypeFacets("int", false)]
        public int MonitorFrequency
        {
            get;
            set;
        }

        [SqlColumn("MonitorEnabled", 6), SqlTypeFacets("bit", false)]
        public bool MonitorEnabled
        {
            get;
            set;
        }

        [SqlColumn("SystemRV", 7), SqlTypeFacets("timestamp", false)]
        public SqlRowVersion SystemRV
        {
            get;
            set;
        }

        public MonitoredTableSetting()
        {
        }

        public MonitoredTableSetting(object[] items)
        {
            SettingId = (int)items[0];
            HostId = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            MonitorFrequency = (int)items[5];
            MonitorEnabled = (bool)items[6];
            SystemRV = (SqlRowVersion)items[7];
        }

        public MonitoredTableSetting(int SettingId, string HostId, string DatabaseName, string SchemaName, string TableName, int MonitorFrequency, bool MonitorEnabled, SqlRowVersion SystemRV)
        {
            this.SettingId = SettingId;
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.MonitorFrequency = MonitorFrequency;
            this.MonitorEnabled = MonitorEnabled;
            this.SystemRV = SystemRV;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SettingId, HostId, DatabaseName, SchemaName, TableName, MonitorFrequency, MonitorEnabled, SystemRV };
        }

        public override void SetItemArray(object[] items)
        {
            SettingId = (int)items[0];
            HostId = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            MonitorFrequency = (int)items[5];
            MonitorEnabled = (bool)items[6];
            SystemRV = (SqlRowVersion)items[7];
        }
    }

    [SqlTable("PF", "NavigationFolderDefinition")]
    public partial class NavigationFolderDefinition : SqlTableProxy<NavigationFolderDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("FolderIdentifier", 1), SqlTypeFacets("nvarchar", false)]
        public string FolderIdentifier
        {
            get;
            set;
        }

        [SqlColumn("NavigatorType", 2), SqlTypeFacets("nvarchar", false)]
        public string NavigatorType
        {
            get;
            set;
        }

        [SqlColumn("FolderName", 3), SqlTypeFacets("nvarchar", false)]
        public string FolderName
        {
            get;
            set;
        }

        public NavigationFolderDefinition()
        {
        }

        public NavigationFolderDefinition(object[] items)
        {
            SystemKey = (long)items[0];
            FolderIdentifier = (string)items[1];
            NavigatorType = (string)items[2];
            FolderName = (string)items[3];
        }

        public NavigationFolderDefinition(long SystemKey, string FolderIdentifier, string NavigatorType, string FolderName)
        {
            this.SystemKey = SystemKey;
            this.FolderIdentifier = FolderIdentifier;
            this.NavigatorType = NavigatorType;
            this.FolderName = FolderName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, FolderIdentifier, NavigatorType, FolderName };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            FolderIdentifier = (string)items[1];
            NavigatorType = (string)items[2];
            FolderName = (string)items[3];
        }
    }

    [SqlTable("PF", "NodeDriveMapDefinition")]
    public partial class NodeDriveMapDefinition : SqlTableProxy<NodeDriveMapDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("NodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeId
        {
            get;
            set;
        }

        [SqlColumn("DriveLetter", 2), SqlTypeFacets("char", false)]
        public string DriveLetter
        {
            get;
            set;
        }

        [SqlColumn("DataSource", 3), SqlTypeFacets("nvarchar", false)]
        public string DataSource
        {
            get;
            set;
        }

        [SqlColumn("UserName", 4), SqlTypeFacets("nvarchar", true)]
        public string UserName
        {
            get;
            set;
        }

        [SqlColumn("UserPass", 5), SqlTypeFacets("nvarchar", true)]
        public string UserPass
        {
            get;
            set;
        }

        public NodeDriveMapDefinition()
        {
        }

        public NodeDriveMapDefinition(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            DriveLetter = (string)items[2];
            DataSource = (string)items[3];
            UserName = (string)items[4];
            UserPass = (string)items[5];
        }

        public NodeDriveMapDefinition(long SystemKey, string NodeId, string DriveLetter, string DataSource, string UserName, string UserPass)
        {
            this.SystemKey = SystemKey;
            this.NodeId = NodeId;
            this.DriveLetter = DriveLetter;
            this.DataSource = DataSource;
            this.UserName = UserName;
            this.UserPass = UserPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, NodeId, DriveLetter, DataSource, UserName, UserPass };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            DriveLetter = (string)items[2];
            DataSource = (string)items[3];
            UserName = (string)items[4];
            UserPass = (string)items[5];
        }
    }

    [SqlTable("PF", "PlatformAgentRegistry")]
    public partial class PlatformAgentRegistry : SqlTableProxy<PlatformAgentRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 2), SqlTypeFacets("nvarchar", false)]
        public string AgentId
        {
            get;
            set;
        }

        public PlatformAgentRegistry()
        {
        }

        public PlatformAgentRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
        }

        public PlatformAgentRegistry(long SystemKey, string SystemId, string AgentId)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
        }
    }

    [SqlTable("PF", "PlatformArtifactType")]
    public partial class PlatformArtifactType : SqlTableProxy<PlatformArtifactType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformArtifactType()
        {
        }

        public PlatformArtifactType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformArtifactType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "PlatformChannelType")]
    public partial class PlatformChannelType : SqlTableProxy<PlatformChannelType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformChannelType()
        {
        }

        public PlatformChannelType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformChannelType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "VirtualDisk")]
    public partial class VirtualDisk : SqlTableProxy<VirtualDisk>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public VirtualDisk()
        {
        }

        public VirtualDisk(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public VirtualDisk(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "PlatformDacRegistry")]
    public partial class PlatformDacRegistry : SqlTableProxy<PlatformDacRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("PackageName", 2), SqlTypeFacets("nvarchar", false)]
        public string PackageName
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 3), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 4), SqlTypeFacets("nvarchar", false)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 5), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        public PlatformDacRegistry()
        {
        }

        public PlatformDacRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            PackageName = (string)items[2];
            ComponentId = (string)items[3];
            ComponentVersion = (string)items[4];
            ComponentTS = (DateTime)items[5];
        }

        public PlatformDacRegistry(long SystemKey, string SystemId, string PackageName, string ComponentId, string ComponentVersion, DateTime ComponentTS)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.PackageName = PackageName;
            this.ComponentId = ComponentId;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, PackageName, ComponentId, ComponentVersion, ComponentTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            PackageName = (string)items[2];
            ComponentId = (string)items[3];
            ComponentVersion = (string)items[4];
            ComponentTS = (DateTime)items[5];
        }
    }

    [SqlTable("PF", "PlatformDatabaseRegistry")]
    public partial class PlatformDatabaseRegistry : SqlTableProxy<PlatformDatabaseRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ServerId", 1), SqlTypeFacets("nvarchar", false)]
        public string ServerId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 3), SqlTypeFacets("nvarchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("IsPrimary", 4), SqlTypeFacets("bit", false)]
        public bool IsPrimary
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 5), SqlTypeFacets("bit", false)]
        public bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("IsModel", 6), SqlTypeFacets("bit", false)]
        public bool IsModel
        {
            get;
            set;
        }

        [SqlColumn("IsRestore", 7), SqlTypeFacets("bit", false)]
        public bool IsRestore
        {
            get;
            set;
        }

        public PlatformDatabaseRegistry()
        {
        }

        public PlatformDatabaseRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            ServerId = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
            IsPrimary = (bool)items[4];
            IsEnabled = (bool)items[5];
            IsModel = (bool)items[6];
            IsRestore = (bool)items[7];
        }

        public PlatformDatabaseRegistry(long SystemKey, string ServerId, string DatabaseName, string DatabaseType, bool IsPrimary, bool IsEnabled, bool IsModel, bool IsRestore)
        {
            this.SystemKey = SystemKey;
            this.ServerId = ServerId;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.IsPrimary = IsPrimary;
            this.IsEnabled = IsEnabled;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, ServerId, DatabaseName, DatabaseType, IsPrimary, IsEnabled, IsModel, IsRestore };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            ServerId = (string)items[1];
            DatabaseName = (string)items[2];
            DatabaseType = (string)items[3];
            IsPrimary = (bool)items[4];
            IsEnabled = (bool)items[5];
            IsModel = (bool)items[6];
            IsRestore = (bool)items[7];
        }
    }

    [SqlTable("PF", "PlatformDatabaseType")]
    public partial class PlatformDatabaseType : SqlTableProxy<PlatformDatabaseType>, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformDatabaseType()
        {
        }

        public PlatformDatabaseType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformDatabaseType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "PlatformEntityChangeLog")]
    public partial class PlatformEntityChangeLog : SqlTableProxy<PlatformEntityChangeLog>
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("EntityName", 2), SqlTypeFacets("nvarchar", false)]
        public string EntityName
        {
            get;
            set;
        }

        [SqlColumn("ChangeType", 3), SqlTypeFacets("char", false)]
        public string ChangeType
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        public PlatformEntityChangeLog()
        {
        }

        public PlatformEntityChangeLog(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            EntityName = (string)items[2];
            ChangeType = (string)items[3];
            EventTS = (DateTime)items[4];
        }

        public PlatformEntityChangeLog(long EntryId, string HostId, string EntityName, string ChangeType, DateTime EventTS)
        {
            this.EntryId = EntryId;
            this.HostId = HostId;
            this.EntityName = EntityName;
            this.ChangeType = ChangeType;
            this.EventTS = EventTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, HostId, EntityName, ChangeType, EventTS };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            EntityName = (string)items[2];
            ChangeType = (string)items[3];
            EventTS = (DateTime)items[4];
        }
    }

    [SqlTable("PF", "PlatformEntityStore")]
    public partial class PlatformEntityStore : SqlTableProxy<PlatformEntityStore>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("EntityName", 1), SqlTypeFacets("nvarchar", false)]
        public string EntityName
        {
            get;
            set;
        }

        [SqlColumn("TypeUri", 2), SqlTypeFacets("nvarchar", false)]
        public string TypeUri
        {
            get;
            set;
        }

        [SqlColumn("Body", 3), SqlTypeFacets("nvarchar", false)]
        public string Body
        {
            get;
            set;
        }

        public PlatformEntityStore()
        {
        }

        public PlatformEntityStore(object[] items)
        {
            SystemKey = (long)items[0];
            EntityName = (string)items[1];
            TypeUri = (string)items[2];
            Body = (string)items[3];
        }

        public PlatformEntityStore(long SystemKey, string EntityName, string TypeUri, string Body)
        {
            this.SystemKey = SystemKey;
            this.EntityName = EntityName;
            this.TypeUri = TypeUri;
            this.Body = Body;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, EntityName, TypeUri, Body };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            EntityName = (string)items[1];
            TypeUri = (string)items[2];
            Body = (string)items[3];
        }
    }

    [SqlTable("PF", "PlatformFileType")]
    public partial class PlatformFileType : SqlTableProxy<PlatformFileType>, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformFileType()
        {
        }

        public PlatformFileType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformFileType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "PlatformNavigatorType")]
    public partial class PlatformNavigatorType : SqlTableProxy<PlatformNavigatorType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformNavigatorType()
        {
        }

        public PlatformNavigatorType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformNavigatorType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "ToolDistribution")]
    public partial class ToolDistribution : SqlTableProxy<ToolDistribution>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public ToolDistribution()
        {
        }

        public ToolDistribution(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public ToolDistribution(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "PlatformProjectRegistry")]
    public partial class PlatformProjectRegistry : SqlTableProxy<PlatformProjectRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 2), SqlTypeFacets("nvarchar", false)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("ProjectId", 3), SqlTypeFacets("nvarchar", false)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 4), SqlTypeFacets("nvarchar", false)]
        public string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 5), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("IsSqlProject", 6), SqlTypeFacets("bit", false)]
        public bool IsSqlProject
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 7), SqlTypeFacets("nvarchar", true)]
        public string TargetDatabase
        {
            get;
            set;
        }

        public PlatformProjectRegistry()
        {
        }

        public PlatformProjectRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            ProjectId = (string)items[3];
            ProjectName = (string)items[4];
            TargetAssembly = (string)items[5];
            IsSqlProject = (bool)items[6];
            TargetDatabase = (string)items[7];
        }

        public PlatformProjectRegistry(long SystemKey, string SystemId, string SolutionId, string ProjectId, string ProjectName, string TargetAssembly, bool IsSqlProject, string TargetDatabase)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.SolutionId = SolutionId;
            this.ProjectId = ProjectId;
            this.ProjectName = ProjectName;
            this.TargetAssembly = TargetAssembly;
            this.IsSqlProject = IsSqlProject;
            this.TargetDatabase = TargetDatabase;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, SolutionId, ProjectId, ProjectName, TargetAssembly, IsSqlProject, TargetDatabase };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            ProjectId = (string)items[3];
            ProjectName = (string)items[4];
            TargetAssembly = (string)items[5];
            IsSqlProject = (bool)items[6];
            TargetDatabase = (string)items[7];
        }
    }

    [SqlTable("PF", "PlatformServerRegistry")]
    public partial class PlatformServerRegistry : SqlTableProxy<PlatformServerRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("NodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeId
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 2), SqlTypeFacets("nvarchar", false)]
        public string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 3), SqlTypeFacets("nvarchar", false)]
        public string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 4), SqlTypeFacets("varchar", true)]
        public string HostIP
        {
            get;
            set;
        }

        [SqlColumn("NetworkName", 5), SqlTypeFacets("varchar", true)]
        public string NetworkName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorName", 6), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorPass", 7), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorPass
        {
            get;
            set;
        }

        public PlatformServerRegistry()
        {
        }

        public PlatformServerRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            NodeName = (string)items[2];
            HostName = (string)items[3];
            HostIP = (string)items[4];
            NetworkName = (string)items[5];
            WinOperatorName = (string)items[6];
            WinOperatorPass = (string)items[7];
        }

        public PlatformServerRegistry(long SystemKey, string NodeId, string NodeName, string HostName, string HostIP, string NetworkName, string WinOperatorName, string WinOperatorPass)
        {
            this.SystemKey = SystemKey;
            this.NodeId = NodeId;
            this.NodeName = NodeName;
            this.HostName = HostName;
            this.HostIP = HostIP;
            this.NetworkName = NetworkName;
            this.WinOperatorName = WinOperatorName;
            this.WinOperatorPass = WinOperatorPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, NodeId, NodeName, HostName, HostIP, NetworkName, WinOperatorName, WinOperatorPass };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            NodeName = (string)items[2];
            HostName = (string)items[3];
            HostIP = (string)items[4];
            NetworkName = (string)items[5];
            WinOperatorName = (string)items[6];
            WinOperatorPass = (string)items[7];
        }
    }

    [SqlTable("PF", "PlatformShareDefinition")]
    public partial class PlatformShareDefinition : SqlTableProxy<PlatformShareDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("ShareType", 2), SqlTypeFacets("nvarchar", false)]
        public string ShareType
        {
            get;
            set;
        }

        [SqlColumn("ShareName", 3), SqlTypeFacets("nvarchar", false)]
        public string ShareName
        {
            get;
            set;
        }

        [SqlColumn("HostPath", 4), SqlTypeFacets("nvarchar", false)]
        public string HostPath
        {
            get;
            set;
        }

        [SqlColumn("UserName", 5), SqlTypeFacets("nvarchar", true)]
        public string UserName
        {
            get;
            set;
        }

        [SqlColumn("UserPass", 6), SqlTypeFacets("nvarchar", true)]
        public string UserPass
        {
            get;
            set;
        }

        public PlatformShareDefinition()
        {
        }

        public PlatformShareDefinition(object[] items)
        {
            SystemKey = (long)items[0];
            HostId = (string)items[1];
            ShareType = (string)items[2];
            ShareName = (string)items[3];
            HostPath = (string)items[4];
            UserName = (string)items[5];
            UserPass = (string)items[6];
        }

        public PlatformShareDefinition(long SystemKey, string HostId, string ShareType, string ShareName, string HostPath, string UserName, string UserPass)
        {
            this.SystemKey = SystemKey;
            this.HostId = HostId;
            this.ShareType = ShareType;
            this.ShareName = ShareName;
            this.HostPath = HostPath;
            this.UserName = UserName;
            this.UserPass = UserPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, HostId, ShareType, ShareName, HostPath, UserName, UserPass };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            HostId = (string)items[1];
            ShareType = (string)items[2];
            ShareName = (string)items[3];
            HostPath = (string)items[4];
            UserName = (string)items[5];
            UserPass = (string)items[6];
        }
    }

    [SqlTable("PF", "PlatformShareFolderType")]
    public partial class PlatformShareFolderType : SqlTableProxy<PlatformShareFolderType>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("ShareType", 2), SqlTypeFacets("nvarchar", false)]
        public string ShareType
        {
            get;
            set;
        }

        [SqlColumn("RelativePath", 3), SqlTypeFacets("nvarchar", false)]
        public string RelativePath
        {
            get;
            set;
        }

        public PlatformShareFolderType()
        {
        }

        public PlatformShareFolderType(object[] items)
        {
            SystemKey = (long)items[0];
            Identifier = (string)items[1];
            ShareType = (string)items[2];
            RelativePath = (string)items[3];
        }

        public PlatformShareFolderType(long SystemKey, string Identifier, string ShareType, string RelativePath)
        {
            this.SystemKey = SystemKey;
            this.Identifier = Identifier;
            this.ShareType = ShareType;
            this.RelativePath = RelativePath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, Identifier, ShareType, RelativePath };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            Identifier = (string)items[1];
            ShareType = (string)items[2];
            RelativePath = (string)items[3];
        }
    }

    [SqlTable("PF", "PlatformShareRegistry")]
    public partial class PlatformShareRegistry : SqlTableProxy<PlatformShareRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("NodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeId
        {
            get;
            set;
        }

        [SqlColumn("ShareName", 2), SqlTypeFacets("nvarchar", false)]
        public string ShareName
        {
            get;
            set;
        }

        [SqlColumn("ShareType", 3), SqlTypeFacets("nvarchar", false)]
        public string ShareType
        {
            get;
            set;
        }

        [SqlColumn("HostPath", 4), SqlTypeFacets("nvarchar", false)]
        public string HostPath
        {
            get;
            set;
        }

        [SqlColumn("UncPath", 5), SqlTypeFacets("nvarchar", false)]
        public string UncPath
        {
            get;
            set;
        }

        public PlatformShareRegistry()
        {
        }

        public PlatformShareRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            ShareName = (string)items[2];
            ShareType = (string)items[3];
            HostPath = (string)items[4];
            UncPath = (string)items[5];
        }

        public PlatformShareRegistry(long SystemKey, string NodeId, string ShareName, string ShareType, string HostPath, string UncPath)
        {
            this.SystemKey = SystemKey;
            this.NodeId = NodeId;
            this.ShareName = ShareName;
            this.ShareType = ShareType;
            this.HostPath = HostPath;
            this.UncPath = UncPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, NodeId, ShareName, ShareType, HostPath, UncPath };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            NodeId = (string)items[1];
            ShareName = (string)items[2];
            ShareType = (string)items[3];
            HostPath = (string)items[4];
            UncPath = (string)items[5];
        }
    }

    [SqlTable("PF", "PlatformShareType")]
    public partial class PlatformShareType : SqlTableProxy<PlatformShareType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformShareType()
        {
        }

        public PlatformShareType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformShareType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "SystemLog")]
    public partial class SystemLog : SqlTableProxy<SystemLog>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public SystemLog()
        {
        }

        public SystemLog(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public SystemLog(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "PlatformSolutionStore")]
    public partial class PlatformSolutionStore : SqlTableProxy<PlatformSolutionStore>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 2), SqlTypeFacets("nvarchar", false)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("SolutionName", 3), SqlTypeFacets("nvarchar", false)]
        public string SolutionName
        {
            get;
            set;
        }

        public PlatformSolutionStore()
        {
        }

        public PlatformSolutionStore(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            SolutionName = (string)items[3];
        }

        public PlatformSolutionStore(long SystemKey, string SystemId, string SolutionId, string SolutionName)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.SolutionId = SolutionId;
            this.SolutionName = SolutionName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, SolutionId, SolutionName };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            SolutionName = (string)items[3];
        }
    }

    [SqlTable("PF", "PlatformSystemRegistry")]
    public partial class PlatformSystemRegistry : SqlTableProxy<PlatformSystemRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        public PlatformSystemRegistry()
        {
        }

        public PlatformSystemRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            Label = (string)items[2];
        }

        public PlatformSystemRegistry(long SystemKey, string SystemId, string Label)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.Label = Label;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, Label };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            Label = (string)items[2];
        }
    }

    [SqlTable("PF", "PlatformSystemType")]
    public partial class PlatformSystemType : SqlTableProxy<PlatformSystemType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public PlatformSystemType()
        {
        }

        public PlatformSystemType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformSystemType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "DatabaseVersionStore")]
    public partial class DatabaseVersionStore : SqlTableProxy<DatabaseVersionStore>
    {
        [SqlColumn("VersionKey", 0), SqlTypeFacets("int", false)]
        public int VersionKey
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("MajorVersion", 2), SqlTypeFacets("int", false)]
        public int MajorVersion
        {
            get;
            set;
        }

        [SqlColumn("MinorVersion", 3), SqlTypeFacets("int", false)]
        public int MinorVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildVersion", 4), SqlTypeFacets("int", false)]
        public int BuildVersion
        {
            get;
            set;
        }

        [SqlColumn("RevisionVersion", 5), SqlTypeFacets("int", false)]
        public int RevisionVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime BuildTS
        {
            get;
            set;
        }

        [SqlColumn("EffectiveDate", 7), SqlTypeFacets("datetime2", false)]
        public DateTime EffectiveDate
        {
            get;
            set;
        }

        [SqlColumn("ExpirationDate", 8), SqlTypeFacets("datetime2", false)]
        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public DatabaseVersionStore()
        {
        }

        public DatabaseVersionStore(object[] items)
        {
            VersionKey = (int)items[0];
            DatabaseName = (string)items[1];
            MajorVersion = (int)items[2];
            MinorVersion = (int)items[3];
            BuildVersion = (int)items[4];
            RevisionVersion = (int)items[5];
            BuildTS = (DateTime)items[6];
            EffectiveDate = (DateTime)items[7];
            ExpirationDate = (DateTime)items[8];
        }

        public DatabaseVersionStore(int VersionKey, string DatabaseName, int MajorVersion, int MinorVersion, int BuildVersion, int RevisionVersion, DateTime BuildTS, DateTime EffectiveDate, DateTime ExpirationDate)
        {
            this.VersionKey = VersionKey;
            this.DatabaseName = DatabaseName;
            this.MajorVersion = MajorVersion;
            this.MinorVersion = MinorVersion;
            this.BuildVersion = BuildVersion;
            this.RevisionVersion = RevisionVersion;
            this.BuildTS = BuildTS;
            this.EffectiveDate = EffectiveDate;
            this.ExpirationDate = ExpirationDate;
        }

        public override object[] GetItemArray()
        {
            return new object[] { VersionKey, DatabaseName, MajorVersion, MinorVersion, BuildVersion, RevisionVersion, BuildTS, EffectiveDate, ExpirationDate };
        }

        public override void SetItemArray(object[] items)
        {
            VersionKey = (int)items[0];
            DatabaseName = (string)items[1];
            MajorVersion = (int)items[2];
            MinorVersion = (int)items[3];
            BuildVersion = (int)items[4];
            RevisionVersion = (int)items[5];
            BuildTS = (DateTime)items[6];
            EffectiveDate = (DateTime)items[7];
            ExpirationDate = (DateTime)items[8];
        }
    }

    [SqlTable("PF", "PlatformVariableStore")]
    public partial class PlatformVariableStore : SqlTableProxy<PlatformVariableStore>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("VariableName", 1), SqlTypeFacets("nvarchar", false)]
        public string VariableName
        {
            get;
            set;
        }

        [SqlColumn("VariableValue", 2), SqlTypeFacets("nvarchar", false)]
        public string VariableValue
        {
            get;
            set;
        }

        public PlatformVariableStore()
        {
        }

        public PlatformVariableStore(object[] items)
        {
            SystemKey = (long)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }

        public PlatformVariableStore(long SystemKey, string VariableName, string VariableValue)
        {
            this.SystemKey = SystemKey;
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, VariableName, VariableValue };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }
    }

    [SqlTable("PF", "PlatformDatabaseVersionHistory")]
    public partial class PlatformDatabaseVersionHistory : SqlTableProxy<PlatformDatabaseVersionHistory>
    {
        [SqlColumn("VersionKey", 0), SqlTypeFacets("int", false)]
        public int VersionKey
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("MajorVersion", 2), SqlTypeFacets("int", false)]
        public int MajorVersion
        {
            get;
            set;
        }

        [SqlColumn("MinorVersion", 3), SqlTypeFacets("int", false)]
        public int MinorVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildVersion", 4), SqlTypeFacets("int", false)]
        public int BuildVersion
        {
            get;
            set;
        }

        [SqlColumn("RevisionVersion", 5), SqlTypeFacets("int", false)]
        public int RevisionVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime BuildTS
        {
            get;
            set;
        }

        [SqlColumn("EffectiveDate", 7), SqlTypeFacets("datetime2", false)]
        public DateTime EffectiveDate
        {
            get;
            set;
        }

        [SqlColumn("ExpirationDate", 8), SqlTypeFacets("datetime2", false)]
        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public PlatformDatabaseVersionHistory()
        {
        }

        public PlatformDatabaseVersionHistory(object[] items)
        {
            VersionKey = (int)items[0];
            DatabaseName = (string)items[1];
            MajorVersion = (int)items[2];
            MinorVersion = (int)items[3];
            BuildVersion = (int)items[4];
            RevisionVersion = (int)items[5];
            BuildTS = (DateTime)items[6];
            EffectiveDate = (DateTime)items[7];
            ExpirationDate = (DateTime)items[8];
        }

        public PlatformDatabaseVersionHistory(int VersionKey, string DatabaseName, int MajorVersion, int MinorVersion, int BuildVersion, int RevisionVersion, DateTime BuildTS, DateTime EffectiveDate, DateTime ExpirationDate)
        {
            this.VersionKey = VersionKey;
            this.DatabaseName = DatabaseName;
            this.MajorVersion = MajorVersion;
            this.MinorVersion = MinorVersion;
            this.BuildVersion = BuildVersion;
            this.RevisionVersion = RevisionVersion;
            this.BuildTS = BuildTS;
            this.EffectiveDate = EffectiveDate;
            this.ExpirationDate = ExpirationDate;
        }

        public override object[] GetItemArray()
        {
            return new object[] { VersionKey, DatabaseName, MajorVersion, MinorVersion, BuildVersion, RevisionVersion, BuildTS, EffectiveDate, ExpirationDate };
        }

        public override void SetItemArray(object[] items)
        {
            VersionKey = (int)items[0];
            DatabaseName = (string)items[1];
            MajorVersion = (int)items[2];
            MinorVersion = (int)items[3];
            BuildVersion = (int)items[4];
            RevisionVersion = (int)items[5];
            BuildTS = (DateTime)items[6];
            EffectiveDate = (DateTime)items[7];
            ExpirationDate = (DateTime)items[8];
        }
    }

    [SqlTable("PF", "DatabaseDropLog")]
    public partial class DatabaseDropLog : SqlTableProxy<DatabaseDropLog>
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("LoginName", 3), SqlTypeFacets("nvarchar", false)]
        public string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("Applied", 5), SqlTypeFacets("bit", false)]
        public bool Applied
        {
            get;
            set;
        }

        [SqlColumn("AppliedTS", 6), SqlTypeFacets("datetime2", true)]
        public DateTime? AppliedTS
        {
            get;
            set;
        }

        public DatabaseDropLog()
        {
        }

        public DatabaseDropLog(object[] items)
        {
            EntryId = (long)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            LoginName = (string)items[3];
            EventTS = (DateTime)items[4];
            Applied = (bool)items[5];
            AppliedTS = (DateTime?)items[6];
        }

        public DatabaseDropLog(long EntryId, string ServerName, string DatabaseName, string LoginName, DateTime EventTS, bool Applied, DateTime? AppliedTS)
        {
            this.EntryId = EntryId;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.LoginName = LoginName;
            this.EventTS = EventTS;
            this.Applied = Applied;
            this.AppliedTS = AppliedTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, ServerName, DatabaseName, LoginName, EventTS, Applied, AppliedTS };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            LoginName = (string)items[3];
            EventTS = (DateTime)items[4];
            Applied = (bool)items[5];
            AppliedTS = (DateTime?)items[6];
        }
    }

    [SqlTable("PF", "DatabaseCreateLog")]
    public partial class DatabaseCreateLog : SqlTableProxy<DatabaseCreateLog>
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("ServerName", 1), SqlTypeFacets("nvarchar", false)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("LoginName", 3), SqlTypeFacets("nvarchar", false)]
        public string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        public DatabaseCreateLog()
        {
        }

        public DatabaseCreateLog(object[] items)
        {
            EntryId = (long)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            LoginName = (string)items[3];
            EventTS = (DateTime)items[4];
        }

        public DatabaseCreateLog(long EntryId, string ServerName, string DatabaseName, string LoginName, DateTime EventTS)
        {
            this.EntryId = EntryId;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.LoginName = LoginName;
            this.EventTS = EventTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, ServerName, DatabaseName, LoginName, EventTS };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            ServerName = (string)items[1];
            DatabaseName = (string)items[2];
            LoginName = (string)items[3];
            EventTS = (DateTime)items[4];
        }
    }

    [SqlTable("PF", "ReceivedFile")]
    public partial class ReceivedFile : SqlTableProxy<ReceivedFile>
    {
        [SqlColumn("FileId", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid FileId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 1), SqlTypeFacets("nvarchar", false)]
        public string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 2), SqlTypeFacets("bigint", false)]
        public long FileSize
        {
            get;
            set;
        }

        [SqlColumn("ReceivedTime", 3), SqlTypeFacets("datetime2", false)]
        public DateTime ReceivedTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 4), SqlTypeFacets("datetime2", false)]
        public DateTime LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 5), SqlTypeFacets("nvarchar", false)]
        public string ReceiptPath
        {
            get;
            set;
        }

        public ReceivedFile()
        {
        }

        public ReceivedFile(object[] items)
        {
            FileId = (Guid)items[0];
            FileName = (string)items[1];
            FileSize = (long)items[2];
            ReceivedTime = (DateTime)items[3];
            LastWriteTime = (DateTime)items[4];
            ReceiptPath = (string)items[5];
        }

        public ReceivedFile(Guid FileId, string FileName, long FileSize, DateTime ReceivedTime, DateTime LastWriteTime, string ReceiptPath)
        {
            this.FileId = FileId;
            this.FileName = FileName;
            this.FileSize = FileSize;
            this.ReceivedTime = ReceivedTime;
            this.LastWriteTime = LastWriteTime;
            this.ReceiptPath = ReceiptPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FileId, FileName, FileSize, ReceivedTime, LastWriteTime, ReceiptPath };
        }

        public override void SetItemArray(object[] items)
        {
            FileId = (Guid)items[0];
            FileName = (string)items[1];
            FileSize = (long)items[2];
            ReceivedTime = (DateTime)items[3];
            LastWriteTime = (DateTime)items[4];
            ReceiptPath = (string)items[5];
        }
    }

    [SqlTable("PF", "SqlArtifactType")]
    public partial class SqlArtifactType : SqlTableProxy<SqlArtifactType>, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public SqlArtifactType()
        {
        }

        public SqlArtifactType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public SqlArtifactType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "PlatformStoreChangeLog")]
    public partial class PlatformStoreChangeLog : SqlTableProxy<PlatformStoreChangeLog>
    {
        [SqlColumn("LogEntryId", 0), SqlTypeFacets("bigint", false)]
        public long LogEntryId
        {
            get;
            set;
        }

        [SqlColumn("StoreName", 1), SqlTypeFacets("nvarchar", false)]
        public string StoreName
        {
            get;
            set;
        }

        [SqlColumn("SystemKey", 2), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ChangeType", 3), SqlTypeFacets("char", false)]
        public string ChangeType
        {
            get;
            set;
        }

        [SqlColumn("ChangeTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime ChangeTS
        {
            get;
            set;
        }

        public PlatformStoreChangeLog()
        {
        }

        public PlatformStoreChangeLog(object[] items)
        {
            LogEntryId = (long)items[0];
            StoreName = (string)items[1];
            SystemKey = (long)items[2];
            ChangeType = (string)items[3];
            ChangeTS = (DateTime)items[4];
        }

        public PlatformStoreChangeLog(long LogEntryId, string StoreName, long SystemKey, string ChangeType, DateTime ChangeTS)
        {
            this.LogEntryId = LogEntryId;
            this.StoreName = StoreName;
            this.SystemKey = SystemKey;
            this.ChangeType = ChangeType;
            this.ChangeTS = ChangeTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { LogEntryId, StoreName, SystemKey, ChangeType, ChangeTS };
        }

        public override void SetItemArray(object[] items)
        {
            LogEntryId = (long)items[0];
            StoreName = (string)items[1];
            SystemKey = (long)items[2];
            ChangeType = (string)items[3];
            ChangeTS = (DateTime)items[4];
        }
    }

    [SqlTable("PF", "SystemDistribution")]
    public partial class SystemDistribution : SqlTableProxy<SystemDistribution>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public SystemDistribution()
        {
        }

        public SystemDistribution(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public SystemDistribution(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "ArtifactReferenceStore")]
    public partial class ArtifactReferenceStore : SqlTableProxy<ArtifactReferenceStore>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SpecFileName", 1), SqlTypeFacets("nvarchar", false)]
        public string SpecFileName
        {
            get;
            set;
        }

        [SqlColumn("SpecLabel", 2), SqlTypeFacets("nvarchar", false)]
        public string SpecLabel
        {
            get;
            set;
        }

        [SqlColumn("AreaName", 3), SqlTypeFacets("nvarchar", false)]
        public string AreaName
        {
            get;
            set;
        }

        [SqlColumn("SectionName", 4), SqlTypeFacets("nvarchar", false)]
        public string SectionName
        {
            get;
            set;
        }

        [SqlColumn("ReferenceType", 5), SqlTypeFacets("nvarchar", false)]
        public string ReferenceType
        {
            get;
            set;
        }

        [SqlColumn("SpecContent", 6), SqlTypeFacets("nvarchar", false)]
        public string SpecContent
        {
            get;
            set;
        }

        public ArtifactReferenceStore()
        {
        }

        public ArtifactReferenceStore(object[] items)
        {
            SystemKey = (long)items[0];
            SpecFileName = (string)items[1];
            SpecLabel = (string)items[2];
            AreaName = (string)items[3];
            SectionName = (string)items[4];
            ReferenceType = (string)items[5];
            SpecContent = (string)items[6];
        }

        public ArtifactReferenceStore(long SystemKey, string SpecFileName, string SpecLabel, string AreaName, string SectionName, string ReferenceType, string SpecContent)
        {
            this.SystemKey = SystemKey;
            this.SpecFileName = SpecFileName;
            this.SpecLabel = SpecLabel;
            this.AreaName = AreaName;
            this.SectionName = SectionName;
            this.ReferenceType = ReferenceType;
            this.SpecContent = SpecContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SpecFileName, SpecLabel, AreaName, SectionName, ReferenceType, SpecContent };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SpecFileName = (string)items[1];
            SpecLabel = (string)items[2];
            AreaName = (string)items[3];
            SectionName = (string)items[4];
            ReferenceType = (string)items[5];
            SpecContent = (string)items[6];
        }
    }

    [SqlTable("PF", "ComponentType")]
    public partial class ComponentType : SqlTableProxy<ComponentType>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public ComponentType()
        {
        }

        public ComponentType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public ComponentType(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlTable("PF", "SqlMessageDefinition")]
    public partial class SqlMessageDefinition : SqlTableProxy<SqlMessageDefinition>
    {
        [SqlColumn("MessageNumber", 0), SqlTypeFacets("int", false)]
        public int MessageNumber
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 2), SqlTypeFacets("nvarchar", false)]
        public string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Severity", 3), SqlTypeFacets("int", false)]
        public int Severity
        {
            get;
            set;
        }

        [SqlColumn("FormatString", 4), SqlTypeFacets("nvarchar", false)]
        public string FormatString
        {
            get;
            set;
        }

        public SqlMessageDefinition()
        {
        }

        public SqlMessageDefinition(object[] items)
        {
            MessageNumber = (int)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Severity = (int)items[3];
            FormatString = (string)items[4];
        }

        public SqlMessageDefinition(int MessageNumber, string SystemId, string MessageName, int Severity, string FormatString)
        {
            this.MessageNumber = MessageNumber;
            this.SystemId = SystemId;
            this.MessageName = MessageName;
            this.Severity = Severity;
            this.FormatString = FormatString;
        }

        public override object[] GetItemArray()
        {
            return new object[] { MessageNumber, SystemId, MessageName, Severity, FormatString };
        }

        public override void SetItemArray(object[] items)
        {
            MessageNumber = (int)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Severity = (int)items[3];
            FormatString = (string)items[4];
        }
    }

    [SqlTable("PF", "SystemCommandRegistry")]
    public partial class SystemCommandRegistry : SqlTableProxy<SystemCommandRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 2), SqlTypeFacets("nvarchar", false)]
        public string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 3), SqlTypeFacets("nvarchar", true)]
        public string Purpose
        {
            get;
            set;
        }

        public SystemCommandRegistry()
        {
        }

        public SystemCommandRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Purpose = (string)items[3];
        }

        public SystemCommandRegistry(long SystemKey, string SystemId, string MessageName, string Purpose)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.MessageName = MessageName;
            this.Purpose = Purpose;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, MessageName, Purpose };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Purpose = (string)items[3];
        }
    }

    [SqlTable("PF", "DacDeployLog")]
    public partial class DacDeployLog : SqlTableProxy<DacDeployLog>
    {
        [SqlColumn("DeploymentId", 0), SqlTypeFacets("bigint", false)]
        public long DeploymentId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourcePackage", 2), SqlTypeFacets("nvarchar", false)]
        public string SourcePackage
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 4), SqlTypeFacets("nvarchar", false)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 5), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("StartTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime StartTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 7), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompletionTS", 8), SqlTypeFacets("datetime2", true)]
        public DateTime? CompletionTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 9), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("CompletionMessage", 10), SqlTypeFacets("nvarchar", true)]
        public string CompletionMessage
        {
            get;
            set;
        }

        public DacDeployLog()
        {
        }

        public DacDeployLog(object[] items)
        {
            DeploymentId = (long)items[0];
            SourceNodeId = (string)items[1];
            SourcePackage = (string)items[2];
            TargetNodeId = (string)items[3];
            TargetDatabase = (string)items[4];
            CorrelationToken = (string)items[5];
            StartTS = (DateTime)items[6];
            Completed = (bool)items[7];
            CompletionTS = (DateTime?)items[8];
            Succeeded = (bool)items[9];
            CompletionMessage = (string)items[10];
        }

        public DacDeployLog(long DeploymentId, string SourceNodeId, string SourcePackage, string TargetNodeId, string TargetDatabase, string CorrelationToken, DateTime StartTS, bool Completed, DateTime? CompletionTS, bool Succeeded, string CompletionMessage)
        {
            this.DeploymentId = DeploymentId;
            this.SourceNodeId = SourceNodeId;
            this.SourcePackage = SourcePackage;
            this.TargetNodeId = TargetNodeId;
            this.TargetDatabase = TargetDatabase;
            this.CorrelationToken = CorrelationToken;
            this.StartTS = StartTS;
            this.Completed = Completed;
            this.CompletionTS = CompletionTS;
            this.Succeeded = Succeeded;
            this.CompletionMessage = CompletionMessage;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DeploymentId, SourceNodeId, SourcePackage, TargetNodeId, TargetDatabase, CorrelationToken, StartTS, Completed, CompletionTS, Succeeded, CompletionMessage };
        }

        public override void SetItemArray(object[] items)
        {
            DeploymentId = (long)items[0];
            SourceNodeId = (string)items[1];
            SourcePackage = (string)items[2];
            TargetNodeId = (string)items[3];
            TargetDatabase = (string)items[4];
            CorrelationToken = (string)items[5];
            StartTS = (DateTime)items[6];
            Completed = (bool)items[7];
            CompletionTS = (DateTime?)items[8];
            Succeeded = (bool)items[9];
            CompletionMessage = (string)items[10];
        }
    }

    [SqlTable("PF", "SystemComponentRegistry")]
    public partial class SystemComponentRegistry : SqlTableProxy<SystemComponentRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 1), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 2), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ComponentType", 3), SqlTypeFacets("nvarchar", false)]
        public string ComponentType
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 4), SqlTypeFacets("nvarchar", true)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 5), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        public SystemComponentRegistry()
        {
        }

        public SystemComponentRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            ComponentId = (string)items[1];
            SystemId = (string)items[2];
            ComponentType = (string)items[3];
            ComponentVersion = (string)items[4];
            ComponentTS = (DateTime)items[5];
        }

        public SystemComponentRegistry(long SystemKey, string ComponentId, string SystemId, string ComponentType, string ComponentVersion, DateTime ComponentTS)
        {
            this.SystemKey = SystemKey;
            this.ComponentId = ComponentId;
            this.SystemId = SystemId;
            this.ComponentType = ComponentType;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, ComponentId, SystemId, ComponentType, ComponentVersion, ComponentTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            ComponentId = (string)items[1];
            SystemId = (string)items[2];
            ComponentType = (string)items[3];
            ComponentVersion = (string)items[4];
            ComponentTS = (DateTime)items[5];
        }
    }

    [SqlTable("PF", "DacProfileStore")]
    public partial class DacProfileStore : SqlTableProxy<DacProfileStore>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ProfileFileName", 1), SqlTypeFacets("nvarchar", false)]
        public string ProfileFileName
        {
            get;
            set;
        }

        [SqlColumn("SourcePackage", 2), SqlTypeFacets("nvarchar", true)]
        public string SourcePackage
        {
            get;
            set;
        }

        [SqlColumn("TargetServerId", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetServerId
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 4), SqlTypeFacets("nvarchar", false)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 5), SqlTypeFacets("nvarchar", false)]
        public string ProfileXml
        {
            get;
            set;
        }

        [SqlColumn("ProfilePath", 6), SqlTypeFacets("nvarchar", true)]
        public string ProfilePath
        {
            get;
            set;
        }

        public DacProfileStore()
        {
        }

        public DacProfileStore(object[] items)
        {
            SystemKey = (long)items[0];
            ProfileFileName = (string)items[1];
            SourcePackage = (string)items[2];
            TargetServerId = (string)items[3];
            TargetDatabase = (string)items[4];
            ProfileXml = (string)items[5];
            ProfilePath = (string)items[6];
        }

        public DacProfileStore(long SystemKey, string ProfileFileName, string SourcePackage, string TargetServerId, string TargetDatabase, string ProfileXml, string ProfilePath)
        {
            this.SystemKey = SystemKey;
            this.ProfileFileName = ProfileFileName;
            this.SourcePackage = SourcePackage;
            this.TargetServerId = TargetServerId;
            this.TargetDatabase = TargetDatabase;
            this.ProfileXml = ProfileXml;
            this.ProfilePath = ProfilePath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, ProfileFileName, SourcePackage, TargetServerId, TargetDatabase, ProfileXml, ProfilePath };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            ProfileFileName = (string)items[1];
            SourcePackage = (string)items[2];
            TargetServerId = (string)items[3];
            TargetDatabase = (string)items[4];
            ProfileXml = (string)items[5];
            ProfilePath = (string)items[6];
        }
    }

    [SqlTable("PF", "SystemEventRegistry")]
    public partial class SystemEventRegistry : SqlTableProxy<SystemEventRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("int", false)]
        public int SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 2), SqlTypeFacets("nvarchar", false)]
        public string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 3), SqlTypeFacets("nvarchar", true)]
        public string Purpose
        {
            get;
            set;
        }

        public SystemEventRegistry()
        {
        }

        public SystemEventRegistry(object[] items)
        {
            SystemKey = (int)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Purpose = (string)items[3];
        }

        public SystemEventRegistry(int SystemKey, string SystemId, string MessageName, string Purpose)
        {
            this.SystemKey = SystemKey;
            this.SystemId = SystemId;
            this.MessageName = MessageName;
            this.Purpose = Purpose;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SystemId, MessageName, Purpose };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (int)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Purpose = (string)items[3];
        }
    }

    [SqlTable("PF", "DatabaseServerRegistry")]
    public partial class DatabaseServerRegistry : SqlTableProxy<DatabaseServerRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SqlNodeId", 2), SqlTypeFacets("nvarchar", false)]
        public string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("SqlInstanceName", 3), SqlTypeFacets("nvarchar", false)]
        public string SqlInstanceName
        {
            get;
            set;
        }

        [SqlColumn("SqlInstancePort", 4), SqlTypeFacets("int", true)]
        public int? SqlInstancePort
        {
            get;
            set;
        }

        [SqlColumn("SqlAlias", 5), SqlTypeFacets("nvarchar", false)]
        public string SqlAlias
        {
            get;
            set;
        }

        [SqlColumn("AliasProtocal", 6), SqlTypeFacets("nvarchar", true)]
        public string AliasProtocal
        {
            get;
            set;
        }

        [SqlColumn("AliasConnector", 7), SqlTypeFacets("nvarchar", true)]
        public string AliasConnector
        {
            get;
            set;
        }

        [SqlColumn("FileStreamRoot", 8), SqlTypeFacets("nvarchar", true)]
        public string FileStreamRoot
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataDir", 9), SqlTypeFacets("nvarchar", true)]
        public string DefaultDataDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogDir", 10), SqlTypeFacets("nvarchar", true)]
        public string DefaultLogDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultBackupDir", 11), SqlTypeFacets("nvarchar", true)]
        public string DefaultBackupDir
        {
            get;
            set;
        }

        [SqlColumn("AdminLogDir", 12), SqlTypeFacets("nvarchar", true)]
        public string AdminLogDir
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorName", 13), SqlTypeFacets("nvarchar", true)]
        public string SqlOperatorName
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorPass", 14), SqlTypeFacets("nvarchar", true)]
        public string SqlOperatorPass
        {
            get;
            set;
        }

        public DatabaseServerRegistry()
        {
        }

        public DatabaseServerRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            HostId = (string)items[1];
            SqlNodeId = (string)items[2];
            SqlInstanceName = (string)items[3];
            SqlInstancePort = (int?)items[4];
            SqlAlias = (string)items[5];
            AliasProtocal = (string)items[6];
            AliasConnector = (string)items[7];
            FileStreamRoot = (string)items[8];
            DefaultDataDir = (string)items[9];
            DefaultLogDir = (string)items[10];
            DefaultBackupDir = (string)items[11];
            AdminLogDir = (string)items[12];
            SqlOperatorName = (string)items[13];
            SqlOperatorPass = (string)items[14];
        }

        public DatabaseServerRegistry(long SystemKey, string HostId, string SqlNodeId, string SqlInstanceName, int? SqlInstancePort, string SqlAlias, string AliasProtocal, string AliasConnector, string FileStreamRoot, string DefaultDataDir, string DefaultLogDir, string DefaultBackupDir, string AdminLogDir, string SqlOperatorName, string SqlOperatorPass)
        {
            this.SystemKey = SystemKey;
            this.HostId = HostId;
            this.SqlNodeId = SqlNodeId;
            this.SqlInstanceName = SqlInstanceName;
            this.SqlInstancePort = SqlInstancePort;
            this.SqlAlias = SqlAlias;
            this.AliasProtocal = AliasProtocal;
            this.AliasConnector = AliasConnector;
            this.FileStreamRoot = FileStreamRoot;
            this.DefaultDataDir = DefaultDataDir;
            this.DefaultLogDir = DefaultLogDir;
            this.DefaultBackupDir = DefaultBackupDir;
            this.AdminLogDir = AdminLogDir;
            this.SqlOperatorName = SqlOperatorName;
            this.SqlOperatorPass = SqlOperatorPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, HostId, SqlNodeId, SqlInstanceName, SqlInstancePort, SqlAlias, AliasProtocal, AliasConnector, FileStreamRoot, DefaultDataDir, DefaultLogDir, DefaultBackupDir, AdminLogDir, SqlOperatorName, SqlOperatorPass };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            HostId = (string)items[1];
            SqlNodeId = (string)items[2];
            SqlInstanceName = (string)items[3];
            SqlInstancePort = (int?)items[4];
            SqlAlias = (string)items[5];
            AliasProtocal = (string)items[6];
            AliasConnector = (string)items[7];
            FileStreamRoot = (string)items[8];
            DefaultDataDir = (string)items[9];
            DefaultLogDir = (string)items[10];
            DefaultBackupDir = (string)items[11];
            AdminLogDir = (string)items[12];
            SqlOperatorName = (string)items[13];
            SqlOperatorPass = (string)items[14];
        }
    }

    [SqlTable("PF", "SystemProxyDefinition")]
    public partial class SystemProxyDefinition : SqlTableProxy<SystemProxyDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("AssemblyDesignator", 1), SqlTypeFacets("nvarchar", false)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 2), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 3), SqlTypeFacets("nvarchar", false)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceNode", 4), SqlTypeFacets("nvarchar", false)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 5), SqlTypeFacets("nvarchar", true)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 6), SqlTypeFacets("nvarchar", true)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 7), SqlTypeFacets("nvarchar", false)]
        public string ProfileText
        {
            get;
            set;
        }

        public SystemProxyDefinition()
        {
        }

        public SystemProxyDefinition(object[] items)
        {
            SystemKey = (long)items[0];
            AssemblyDesignator = (string)items[1];
            SystemId = (string)items[2];
            ProfileName = (string)items[3];
            SourceNode = (string)items[4];
            SourceDatabase = (string)items[5];
            TargetAssembly = (string)items[6];
            ProfileText = (string)items[7];
        }

        public SystemProxyDefinition(long SystemKey, string AssemblyDesignator, string SystemId, string ProfileName, string SourceNode, string SourceDatabase, string TargetAssembly, string ProfileText)
        {
            this.SystemKey = SystemKey;
            this.AssemblyDesignator = AssemblyDesignator;
            this.SystemId = SystemId;
            this.ProfileName = ProfileName;
            this.SourceNode = SourceNode;
            this.SourceDatabase = SourceDatabase;
            this.TargetAssembly = TargetAssembly;
            this.ProfileText = ProfileText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, AssemblyDesignator, SystemId, ProfileName, SourceNode, SourceDatabase, TargetAssembly, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            AssemblyDesignator = (string)items[1];
            SystemId = (string)items[2];
            ProfileName = (string)items[3];
            SourceNode = (string)items[4];
            SourceDatabase = (string)items[5];
            TargetAssembly = (string)items[6];
            ProfileText = (string)items[7];
        }
    }

    [SqlTable("PF", "DistributionRegistry")]
    public partial class DistributionRegistry : SqlTableProxy<DistributionRegistry>
    {
        [SqlColumn("DistributionId", 0), SqlTypeFacets("nvarchar", false)]
        public string DistributionId
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public DistributionRegistry()
        {
        }

        public DistributionRegistry(object[] items)
        {
            DistributionId = (string)items[0];
            Description = (string)items[1];
        }

        public DistributionRegistry(string DistributionId, string Description)
        {
            this.DistributionId = DistributionId;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DistributionId, Description };
        }

        public override void SetItemArray(object[] items)
        {
            DistributionId = (string)items[0];
            Description = (string)items[1];
        }
    }

    [SqlTable("PF", "TableMonitorLog")]
    public partial class TableMonitorLog : SqlTableProxy<TableMonitorLog>, ILogTable
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 3), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("nvarchar", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("LastObservedVersion", 5), SqlTypeFacets("varbinary", true)]
        public Byte[] LastObservedVersion
        {
            get;
            set;
        }

        [SqlColumn("ObservationTS", 6), SqlTypeFacets("datetime2", true)]
        public DateTime? ObservationTS
        {
            get;
            set;
        }

        [SqlColumn("LastProcessedVersion", 7), SqlTypeFacets("varbinary", true)]
        public Byte[] LastProcessedVersion
        {
            get;
            set;
        }

        [SqlColumn("ProcessedTS", 8), SqlTypeFacets("datetime2", true)]
        public DateTime? ProcessedTS
        {
            get;
            set;
        }

        [SqlColumn("LoggedTS", 9), SqlTypeFacets("datetime2", false)]
        public DateTime LoggedTS
        {
            get;
            set;
        }

        [SqlColumn("SystemRV", 10), SqlTypeFacets("timestamp", false)]
        public SqlRowVersion SystemRV
        {
            get;
            set;
        }

        public TableMonitorLog()
        {
        }

        public TableMonitorLog(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            LastObservedVersion = (Byte[])items[5];
            ObservationTS = (DateTime?)items[6];
            LastProcessedVersion = (Byte[])items[7];
            ProcessedTS = (DateTime?)items[8];
            LoggedTS = (DateTime)items[9];
            SystemRV = (SqlRowVersion)items[10];
        }

        public TableMonitorLog(long EntryId, string HostId, string DatabaseName, string SchemaName, string TableName, Byte[] LastObservedVersion, DateTime? ObservationTS, Byte[] LastProcessedVersion, DateTime? ProcessedTS, DateTime LoggedTS, SqlRowVersion SystemRV)
        {
            this.EntryId = EntryId;
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.LastObservedVersion = LastObservedVersion;
            this.ObservationTS = ObservationTS;
            this.LastProcessedVersion = LastProcessedVersion;
            this.ProcessedTS = ProcessedTS;
            this.LoggedTS = LoggedTS;
            this.SystemRV = SystemRV;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, HostId, DatabaseName, SchemaName, TableName, LastObservedVersion, ObservationTS, LastProcessedVersion, ProcessedTS, LoggedTS, SystemRV };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            DatabaseName = (string)items[2];
            SchemaName = (string)items[3];
            TableName = (string)items[4];
            LastObservedVersion = (Byte[])items[5];
            ObservationTS = (DateTime?)items[6];
            LastProcessedVersion = (Byte[])items[7];
            ProcessedTS = (DateTime?)items[8];
            LoggedTS = (DateTime)items[9];
            SystemRV = (SqlRowVersion)items[10];
        }
    }

    [SqlTable("PF", "TypedDataFlowRegistry")]
    public partial class TypedDataFlowRegistry : SqlTableProxy<TypedDataFlowRegistry>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("SourceAssembly", 1), SqlTypeFacets("nvarchar", false)]
        public string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 3), SqlTypeFacets("nvarchar", false)]
        public string DataFlowName
        {
            get;
            set;
        }

        [SqlColumn("WorkflowTypeUri", 4), SqlTypeFacets("nvarchar", false)]
        public string WorkflowTypeUri
        {
            get;
            set;
        }

        [SqlColumn("ArgumentTypeUri", 5), SqlTypeFacets("nvarchar", true)]
        public string ArgumentTypeUri
        {
            get;
            set;
        }

        public TypedDataFlowRegistry()
        {
        }

        public TypedDataFlowRegistry(object[] items)
        {
            SystemKey = (long)items[0];
            SourceAssembly = (string)items[1];
            TargetAssembly = (string)items[2];
            DataFlowName = (string)items[3];
            WorkflowTypeUri = (string)items[4];
            ArgumentTypeUri = (string)items[5];
        }

        public TypedDataFlowRegistry(long SystemKey, string SourceAssembly, string TargetAssembly, string DataFlowName, string WorkflowTypeUri, string ArgumentTypeUri)
        {
            this.SystemKey = SystemKey;
            this.SourceAssembly = SourceAssembly;
            this.TargetAssembly = TargetAssembly;
            this.DataFlowName = DataFlowName;
            this.WorkflowTypeUri = WorkflowTypeUri;
            this.ArgumentTypeUri = ArgumentTypeUri;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, SourceAssembly, TargetAssembly, DataFlowName, WorkflowTypeUri, ArgumentTypeUri };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            SourceAssembly = (string)items[1];
            TargetAssembly = (string)items[2];
            DataFlowName = (string)items[3];
            WorkflowTypeUri = (string)items[4];
            ArgumentTypeUri = (string)items[5];
        }
    }

    [SqlTable("PF", "EnterpriseDatabaseType")]
    public partial class EnterpriseDatabaseType : SqlTableProxy<EnterpriseDatabaseType>, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public EnterpriseDatabaseType()
        {
        }

        public EnterpriseDatabaseType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public EnterpriseDatabaseType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "TypeSystemDataType")]
    public partial class TypeSystemDataType : SqlTableProxy<TypeSystemDataType>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("int", false)]
        public int SystemKey
        {
            get;
            set;
        }

        [SqlColumn("TypeSystemId", 1), SqlTypeFacets("int", false)]
        public int TypeSystemId
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 2), SqlTypeFacets("nvarchar", false)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("RuntimeType", 3), SqlTypeFacets("nvarchar", false)]
        public string RuntimeType
        {
            get;
            set;
        }

        public TypeSystemDataType()
        {
        }

        public TypeSystemDataType(object[] items)
        {
            SystemKey = (int)items[0];
            TypeSystemId = (int)items[1];
            DataTypeName = (string)items[2];
            RuntimeType = (string)items[3];
        }

        public TypeSystemDataType(int SystemKey, int TypeSystemId, string DataTypeName, string RuntimeType)
        {
            this.SystemKey = SystemKey;
            this.TypeSystemId = TypeSystemId;
            this.DataTypeName = DataTypeName;
            this.RuntimeType = RuntimeType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, TypeSystemId, DataTypeName, RuntimeType };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (int)items[0];
            TypeSystemId = (int)items[1];
            DataTypeName = (string)items[2];
            RuntimeType = (string)items[3];
        }
    }

    [SqlTable("PF", "EnterpriseServerType")]
    public partial class EnterpriseServerType : SqlTableProxy<EnterpriseServerType>, ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public EnterpriseServerType()
        {
        }

        public EnterpriseServerType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public EnterpriseServerType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "TypeSystemType")]
    public partial class TypeSystemType : SqlTableProxy<TypeSystemType>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public TypeSystemType()
        {
        }

        public TypeSystemType(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public TypeSystemType(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlTable("PF", "EnterpriseShareDefinition")]
    public partial class EnterpriseShareDefinition : SqlTableProxy<EnterpriseShareDefinition>
    {
        [SqlColumn("SystemKey", 0), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ShareLabel", 1), SqlTypeFacets("nvarchar", false)]
        public string ShareLabel
        {
            get;
            set;
        }

        [SqlColumn("UncRootPath", 2), SqlTypeFacets("nvarchar", false)]
        public string UncRootPath
        {
            get;
            set;
        }

        [SqlColumn("UserName", 3), SqlTypeFacets("nvarchar", true)]
        public string UserName
        {
            get;
            set;
        }

        [SqlColumn("UserPass", 4), SqlTypeFacets("nvarchar", true)]
        public string UserPass
        {
            get;
            set;
        }

        public EnterpriseShareDefinition()
        {
        }

        public EnterpriseShareDefinition(object[] items)
        {
            SystemKey = (long)items[0];
            ShareLabel = (string)items[1];
            UncRootPath = (string)items[2];
            UserName = (string)items[3];
            UserPass = (string)items[4];
        }

        public EnterpriseShareDefinition(long SystemKey, string ShareLabel, string UncRootPath, string UserName, string UserPass)
        {
            this.SystemKey = SystemKey;
            this.ShareLabel = ShareLabel;
            this.UncRootPath = UncRootPath;
            this.UserName = UserName;
            this.UserPass = UserPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemKey, ShareLabel, UncRootPath, UserName, UserPass };
        }

        public override void SetItemArray(object[] items)
        {
            SystemKey = (long)items[0];
            ShareLabel = (string)items[1];
            UncRootPath = (string)items[2];
            UserName = (string)items[3];
            UserPass = (string)items[4];
        }
    }

    [SqlTable("PF", "DatabaseBackup")]
    public partial class DatabaseBackup : SqlTableProxy<DatabaseBackup>
    {
        [SqlColumn("stream_id", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        [SqlColumn("file_stream", 1), SqlTypeFacets("varbinary", true)]
        public Byte[] file_stream
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("nvarchar", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("file_type", 3), SqlTypeFacets("nvarchar", true)]
        public string file_type
        {
            get;
            set;
        }

        [SqlColumn("cached_file_size", 4), SqlTypeFacets("bigint", true)]
        public long? cached_file_size
        {
            get;
            set;
        }

        [SqlColumn("creation_time", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset creation_time
        {
            get;
            set;
        }

        [SqlColumn("last_write_time", 6), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset last_write_time
        {
            get;
            set;
        }

        [SqlColumn("last_access_time", 7), SqlTypeFacets("datetimeoffset", true)]
        public DateTimeOffset? last_access_time
        {
            get;
            set;
        }

        [SqlColumn("is_directory", 8), SqlTypeFacets("bit", false)]
        public bool is_directory
        {
            get;
            set;
        }

        [SqlColumn("is_offline", 9), SqlTypeFacets("bit", false)]
        public bool is_offline
        {
            get;
            set;
        }

        [SqlColumn("is_hidden", 10), SqlTypeFacets("bit", false)]
        public bool is_hidden
        {
            get;
            set;
        }

        [SqlColumn("is_readonly", 11), SqlTypeFacets("bit", false)]
        public bool is_readonly
        {
            get;
            set;
        }

        [SqlColumn("is_archive", 12), SqlTypeFacets("bit", false)]
        public bool is_archive
        {
            get;
            set;
        }

        [SqlColumn("is_system", 13), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_temporary", 14), SqlTypeFacets("bit", false)]
        public bool is_temporary
        {
            get;
            set;
        }

        public DatabaseBackup()
        {
        }

        public DatabaseBackup(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }

        public DatabaseBackup(Guid stream_id, Byte[] file_stream, string name, string file_type, long? cached_file_size, DateTimeOffset creation_time, DateTimeOffset last_write_time, DateTimeOffset? last_access_time, bool is_directory, bool is_offline, bool is_hidden, bool is_readonly, bool is_archive, bool is_system, bool is_temporary)
        {
            this.stream_id = stream_id;
            this.file_stream = file_stream;
            this.name = name;
            this.file_type = file_type;
            this.cached_file_size = cached_file_size;
            this.creation_time = creation_time;
            this.last_write_time = last_write_time;
            this.last_access_time = last_access_time;
            this.is_directory = is_directory;
            this.is_offline = is_offline;
            this.is_hidden = is_hidden;
            this.is_readonly = is_readonly;
            this.is_archive = is_archive;
            this.is_system = is_system;
            this.is_temporary = is_temporary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { stream_id, file_stream, name, file_type, cached_file_size, creation_time, last_write_time, last_access_time, is_directory, is_offline, is_hidden, is_readonly, is_archive, is_system, is_temporary };
        }

        public override void SetItemArray(object[] items)
        {
            stream_id = (Guid)items[0];
            file_stream = (Byte[])items[1];
            name = (string)items[2];
            file_type = (string)items[3];
            cached_file_size = (long?)items[4];
            creation_time = (DateTimeOffset)items[5];
            last_write_time = (DateTimeOffset)items[6];
            last_access_time = (DateTimeOffset?)items[7];
            is_directory = (bool)items[8];
            is_offline = (bool)items[9];
            is_hidden = (bool)items[10];
            is_readonly = (bool)items[11];
            is_archive = (bool)items[12];
            is_system = (bool)items[13];
            is_temporary = (bool)items[14];
        }
    }

    [SqlTable("PF", "FileReceiptLog")]
    public partial class FileReceiptLog : SqlTableProxy<FileReceiptLog>, ILogTable
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("FileId", 2), SqlTypeFacets("uniqueidentifier", false)]
        public Guid FileId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 3), SqlTypeFacets("nvarchar", false)]
        public string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileType", 4), SqlTypeFacets("nvarchar", false)]
        public string FileType
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 5), SqlTypeFacets("nvarchar", false)]
        public string ReceiptPath
        {
            get;
            set;
        }

        [SqlColumn("WrittenTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime WrittenTS
        {
            get;
            set;
        }

        [SqlColumn("ReceiptTS", 7), SqlTypeFacets("datetime2", false)]
        public DateTime ReceiptTS
        {
            get;
            set;
        }

        [SqlColumn("LoggedTS", 8), SqlTypeFacets("datetime2", false)]
        public DateTime LoggedTS
        {
            get;
            set;
        }

        [SqlColumn("SystemRV", 9), SqlTypeFacets("timestamp", false)]
        public SqlRowVersion SystemRV
        {
            get;
            set;
        }

        public FileReceiptLog()
        {
        }

        public FileReceiptLog(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            FileId = (Guid)items[2];
            FileName = (string)items[3];
            FileType = (string)items[4];
            ReceiptPath = (string)items[5];
            WrittenTS = (DateTime)items[6];
            ReceiptTS = (DateTime)items[7];
            LoggedTS = (DateTime)items[8];
            SystemRV = (SqlRowVersion)items[9];
        }

        public FileReceiptLog(long EntryId, string HostId, Guid FileId, string FileName, string FileType, string ReceiptPath, DateTime WrittenTS, DateTime ReceiptTS, DateTime LoggedTS, SqlRowVersion SystemRV)
        {
            this.EntryId = EntryId;
            this.HostId = HostId;
            this.FileId = FileId;
            this.FileName = FileName;
            this.FileType = FileType;
            this.ReceiptPath = ReceiptPath;
            this.WrittenTS = WrittenTS;
            this.ReceiptTS = ReceiptTS;
            this.LoggedTS = LoggedTS;
            this.SystemRV = SystemRV;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, HostId, FileId, FileName, FileType, ReceiptPath, WrittenTS, ReceiptTS, LoggedTS, SystemRV };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            FileId = (Guid)items[2];
            FileName = (string)items[3];
            FileType = (string)items[4];
            ReceiptPath = (string)items[5];
            WrittenTS = (DateTime)items[6];
            ReceiptTS = (DateTime)items[7];
            LoggedTS = (DateTime)items[8];
            SystemRV = (SqlRowVersion)items[9];
        }
    }

    [SqlTable("PF", "MessageClass")]
    public partial class MessageClass : SqlTableProxy<MessageClass>, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public MessageClass()
        {
        }

        public MessageClass(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public MessageClass(byte TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlView("PF", "PlatformNotificationData")]
    public partial class PlatformNotificationData : SqlViewProxy
    {
        [SqlColumn("event_data", 0), SqlTypeFacets("xml", true)]
        public string event_data
        {
            get;
            set;
        }

        public PlatformNotificationData()
        {
        }

        public PlatformNotificationData(object[] items)
        {
            event_data = (string)items[0];
        }

        public PlatformNotificationData(string event_data)
        {
            this.event_data = event_data;
        }

        public override object[] GetItemArray()
        {
            return new object[] { event_data };
        }

        public override void SetItemArray(object[] items)
        {
            event_data = (string)items[0];
        }
    }

    [SqlView("PF", "ExecutingNode")]
    public partial class ExecutingNode : SqlViewProxy
    {
        [SqlColumn("NodeId", 0), SqlTypeFacets("nvarchar", false)]
        public string NodeId
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 2), SqlTypeFacets("nvarchar", false)]
        public string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 3), SqlTypeFacets("varchar", true)]
        public string HostIP
        {
            get;
            set;
        }

        public ExecutingNode()
        {
        }

        public ExecutingNode(object[] items)
        {
            NodeId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
        }

        public ExecutingNode(string NodeId, string NodeName, string HostName, string HostIP)
        {
            this.NodeId = NodeId;
            this.NodeName = NodeName;
            this.HostName = HostName;
            this.HostIP = HostIP;
        }

        public override object[] GetItemArray()
        {
            return new object[] { NodeId, NodeName, HostName, HostIP };
        }

        public override void SetItemArray(object[] items)
        {
            NodeId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
        }
    }

    [SqlView("PF", "ExecutingServer")]
    public partial class ExecutingServer : SqlViewProxy
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SqlNodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("SqlInstanceName", 2), SqlTypeFacets("nvarchar", false)]
        public string SqlInstanceName
        {
            get;
            set;
        }

        [SqlColumn("SqlInstancePort", 3), SqlTypeFacets("int", true)]
        public int? SqlInstancePort
        {
            get;
            set;
        }

        [SqlColumn("SqlAlias", 4), SqlTypeFacets("nvarchar", false)]
        public string SqlAlias
        {
            get;
            set;
        }

        [SqlColumn("FileStreamRoot", 5), SqlTypeFacets("nvarchar", true)]
        public string FileStreamRoot
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataDir", 6), SqlTypeFacets("nvarchar", true)]
        public string DefaultDataDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogDir", 7), SqlTypeFacets("nvarchar", true)]
        public string DefaultLogDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultBackupDir", 8), SqlTypeFacets("nvarchar", true)]
        public string DefaultBackupDir
        {
            get;
            set;
        }

        [SqlColumn("AdminLogDir", 9), SqlTypeFacets("nvarchar", true)]
        public string AdminLogDir
        {
            get;
            set;
        }

        public ExecutingServer()
        {
        }

        public ExecutingServer(object[] items)
        {
            HostId = (string)items[0];
            SqlNodeId = (string)items[1];
            SqlInstanceName = (string)items[2];
            SqlInstancePort = (int?)items[3];
            SqlAlias = (string)items[4];
            FileStreamRoot = (string)items[5];
            DefaultDataDir = (string)items[6];
            DefaultLogDir = (string)items[7];
            DefaultBackupDir = (string)items[8];
            AdminLogDir = (string)items[9];
        }

        public ExecutingServer(string HostId, string SqlNodeId, string SqlInstanceName, int? SqlInstancePort, string SqlAlias, string FileStreamRoot, string DefaultDataDir, string DefaultLogDir, string DefaultBackupDir, string AdminLogDir)
        {
            this.HostId = HostId;
            this.SqlNodeId = SqlNodeId;
            this.SqlInstanceName = SqlInstanceName;
            this.SqlInstancePort = SqlInstancePort;
            this.SqlAlias = SqlAlias;
            this.FileStreamRoot = FileStreamRoot;
            this.DefaultDataDir = DefaultDataDir;
            this.DefaultLogDir = DefaultLogDir;
            this.DefaultBackupDir = DefaultBackupDir;
            this.AdminLogDir = AdminLogDir;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, SqlNodeId, SqlInstanceName, SqlInstancePort, SqlAlias, FileStreamRoot, DefaultDataDir, DefaultLogDir, DefaultBackupDir, AdminLogDir };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            SqlNodeId = (string)items[1];
            SqlInstanceName = (string)items[2];
            SqlInstancePort = (int?)items[3];
            SqlAlias = (string)items[4];
            FileStreamRoot = (string)items[5];
            DefaultDataDir = (string)items[6];
            DefaultLogDir = (string)items[7];
            DefaultBackupDir = (string)items[8];
            AdminLogDir = (string)items[9];
        }
    }

    [SqlView("PF", "HostDatabase")]
    public partial class HostDatabase : SqlViewProxy
    {
        [SqlColumn("ServerId", 0), SqlTypeFacets("nvarchar", false)]
        public string ServerId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("IsPrimary", 3), SqlTypeFacets("bit", false)]
        public bool IsPrimary
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 4), SqlTypeFacets("bit", false)]
        public bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("IsModel", 5), SqlTypeFacets("bit", false)]
        public bool IsModel
        {
            get;
            set;
        }

        [SqlColumn("IsRestore", 6), SqlTypeFacets("bit", false)]
        public bool IsRestore
        {
            get;
            set;
        }

        public HostDatabase()
        {
        }

        public HostDatabase(object[] items)
        {
            ServerId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
            IsPrimary = (bool)items[3];
            IsEnabled = (bool)items[4];
            IsModel = (bool)items[5];
            IsRestore = (bool)items[6];
        }

        public HostDatabase(string ServerId, string DatabaseName, string DatabaseType, bool IsPrimary, bool IsEnabled, bool IsModel, bool IsRestore)
        {
            this.ServerId = ServerId;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.IsPrimary = IsPrimary;
            this.IsEnabled = IsEnabled;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerId, DatabaseName, DatabaseType, IsPrimary, IsEnabled, IsModel, IsRestore };
        }

        public override void SetItemArray(object[] items)
        {
            ServerId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
            IsPrimary = (bool)items[3];
            IsEnabled = (bool)items[4];
            IsModel = (bool)items[5];
            IsRestore = (bool)items[6];
        }
    }

    [SqlView("PF", "PlatformDatabaseDescription")]
    public partial class PlatformDatabaseDescription : SqlViewProxy
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 1), SqlTypeFacets("nvarchar", false)]
        public string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 2), SqlTypeFacets("nvarchar", false)]
        public string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 3), SqlTypeFacets("varchar", true)]
        public string HostIP
        {
            get;
            set;
        }

        [SqlColumn("SqlNodeId", 4), SqlTypeFacets("nvarchar", false)]
        public string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("SqlInstancePort", 5), SqlTypeFacets("int", false)]
        public int SqlInstancePort
        {
            get;
            set;
        }

        [SqlColumn("SqlAlias", 6), SqlTypeFacets("nvarchar", false)]
        public string SqlAlias
        {
            get;
            set;
        }

        [SqlColumn("FileStreamRoot", 7), SqlTypeFacets("nvarchar", true)]
        public string FileStreamRoot
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 8), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 9), SqlTypeFacets("nvarchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("IsPrimary", 10), SqlTypeFacets("bit", false)]
        public bool IsPrimary
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 11), SqlTypeFacets("bit", false)]
        public bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("IsModel", 12), SqlTypeFacets("bit", false)]
        public bool IsModel
        {
            get;
            set;
        }

        [SqlColumn("IsRestore", 13), SqlTypeFacets("bit", false)]
        public bool IsRestore
        {
            get;
            set;
        }

        [SqlColumn("SqlInstanceName", 14), SqlTypeFacets("nvarchar", false)]
        public string SqlInstanceName
        {
            get;
            set;
        }

        public PlatformDatabaseDescription()
        {
        }

        public PlatformDatabaseDescription(object[] items)
        {
            HostId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
            SqlNodeId = (string)items[4];
            SqlInstancePort = (int)items[5];
            SqlAlias = (string)items[6];
            FileStreamRoot = (string)items[7];
            DatabaseName = (string)items[8];
            DatabaseType = (string)items[9];
            IsPrimary = (bool)items[10];
            IsEnabled = (bool)items[11];
            IsModel = (bool)items[12];
            IsRestore = (bool)items[13];
            SqlInstanceName = (string)items[14];
        }

        public PlatformDatabaseDescription(string HostId, string NodeName, string HostName, string HostIP, string SqlNodeId, int SqlInstancePort, string SqlAlias, string FileStreamRoot, string DatabaseName, string DatabaseType, bool IsPrimary, bool IsEnabled, bool IsModel, bool IsRestore, string SqlInstanceName)
        {
            this.HostId = HostId;
            this.NodeName = NodeName;
            this.HostName = HostName;
            this.HostIP = HostIP;
            this.SqlNodeId = SqlNodeId;
            this.SqlInstancePort = SqlInstancePort;
            this.SqlAlias = SqlAlias;
            this.FileStreamRoot = FileStreamRoot;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.IsPrimary = IsPrimary;
            this.IsEnabled = IsEnabled;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
            this.SqlInstanceName = SqlInstanceName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, NodeName, HostName, HostIP, SqlNodeId, SqlInstancePort, SqlAlias, FileStreamRoot, DatabaseName, DatabaseType, IsPrimary, IsEnabled, IsModel, IsRestore, SqlInstanceName };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
            SqlNodeId = (string)items[4];
            SqlInstancePort = (int)items[5];
            SqlAlias = (string)items[6];
            FileStreamRoot = (string)items[7];
            DatabaseName = (string)items[8];
            DatabaseType = (string)items[9];
            IsPrimary = (bool)items[10];
            IsEnabled = (bool)items[11];
            IsModel = (bool)items[12];
            IsRestore = (bool)items[13];
            SqlInstanceName = (string)items[14];
        }
    }

    [SqlView("PF", "PlatformDatabaseServer")]
    public partial class PlatformDatabaseServer : SqlViewProxy
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SqlNodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("SqlAlias", 2), SqlTypeFacets("nvarchar", false)]
        public string SqlAlias
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 3), SqlTypeFacets("nvarchar", false)]
        public string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 4), SqlTypeFacets("nvarchar", false)]
        public string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostNetworkName", 5), SqlTypeFacets("varchar", true)]
        public string HostNetworkName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 6), SqlTypeFacets("varchar", true)]
        public string HostIP
        {
            get;
            set;
        }

        [SqlColumn("SqlInstanceName", 7), SqlTypeFacets("nvarchar", false)]
        public string SqlInstanceName
        {
            get;
            set;
        }

        [SqlColumn("SqlInstancePort", 8), SqlTypeFacets("int", true)]
        public int? SqlInstancePort
        {
            get;
            set;
        }

        [SqlColumn("FileStreamRoot", 9), SqlTypeFacets("nvarchar", true)]
        public string FileStreamRoot
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataDir", 10), SqlTypeFacets("nvarchar", true)]
        public string DefaultDataDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultBackupDir", 11), SqlTypeFacets("nvarchar", true)]
        public string DefaultBackupDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogDir", 12), SqlTypeFacets("nvarchar", true)]
        public string DefaultLogDir
        {
            get;
            set;
        }

        [SqlColumn("AdminLogDir", 13), SqlTypeFacets("nvarchar", true)]
        public string AdminLogDir
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorName", 14), SqlTypeFacets("nvarchar", true)]
        public string SqlOperatorName
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorPass", 15), SqlTypeFacets("nvarchar", true)]
        public string SqlOperatorPass
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorName", 16), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorPass", 17), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorPass
        {
            get;
            set;
        }

        public PlatformDatabaseServer()
        {
        }

        public PlatformDatabaseServer(object[] items)
        {
            HostId = (string)items[0];
            SqlNodeId = (string)items[1];
            SqlAlias = (string)items[2];
            NodeName = (string)items[3];
            HostName = (string)items[4];
            HostNetworkName = (string)items[5];
            HostIP = (string)items[6];
            SqlInstanceName = (string)items[7];
            SqlInstancePort = (int?)items[8];
            FileStreamRoot = (string)items[9];
            DefaultDataDir = (string)items[10];
            DefaultBackupDir = (string)items[11];
            DefaultLogDir = (string)items[12];
            AdminLogDir = (string)items[13];
            SqlOperatorName = (string)items[14];
            SqlOperatorPass = (string)items[15];
            WinOperatorName = (string)items[16];
            WinOperatorPass = (string)items[17];
        }

        public PlatformDatabaseServer(string HostId, string SqlNodeId, string SqlAlias, string NodeName, string HostName, string HostNetworkName, string HostIP, string SqlInstanceName, int? SqlInstancePort, string FileStreamRoot, string DefaultDataDir, string DefaultBackupDir, string DefaultLogDir, string AdminLogDir, string SqlOperatorName, string SqlOperatorPass, string WinOperatorName, string WinOperatorPass)
        {
            this.HostId = HostId;
            this.SqlNodeId = SqlNodeId;
            this.SqlAlias = SqlAlias;
            this.NodeName = NodeName;
            this.HostName = HostName;
            this.HostNetworkName = HostNetworkName;
            this.HostIP = HostIP;
            this.SqlInstanceName = SqlInstanceName;
            this.SqlInstancePort = SqlInstancePort;
            this.FileStreamRoot = FileStreamRoot;
            this.DefaultDataDir = DefaultDataDir;
            this.DefaultBackupDir = DefaultBackupDir;
            this.DefaultLogDir = DefaultLogDir;
            this.AdminLogDir = AdminLogDir;
            this.SqlOperatorName = SqlOperatorName;
            this.SqlOperatorPass = SqlOperatorPass;
            this.WinOperatorName = WinOperatorName;
            this.WinOperatorPass = WinOperatorPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, SqlNodeId, SqlAlias, NodeName, HostName, HostNetworkName, HostIP, SqlInstanceName, SqlInstancePort, FileStreamRoot, DefaultDataDir, DefaultBackupDir, DefaultLogDir, AdminLogDir, SqlOperatorName, SqlOperatorPass, WinOperatorName, WinOperatorPass };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            SqlNodeId = (string)items[1];
            SqlAlias = (string)items[2];
            NodeName = (string)items[3];
            HostName = (string)items[4];
            HostNetworkName = (string)items[5];
            HostIP = (string)items[6];
            SqlInstanceName = (string)items[7];
            SqlInstancePort = (int?)items[8];
            FileStreamRoot = (string)items[9];
            DefaultDataDir = (string)items[10];
            DefaultBackupDir = (string)items[11];
            DefaultLogDir = (string)items[12];
            AdminLogDir = (string)items[13];
            SqlOperatorName = (string)items[14];
            SqlOperatorPass = (string)items[15];
            WinOperatorName = (string)items[16];
            WinOperatorPass = (string)items[17];
        }
    }

    [SqlProcedure("PF", "SyncTypedDataFlowRegistry")]
    public partial class SyncTypedDataFlowRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[TypedDataFlowDescriptor]", true)]
        public IEnumerable<TypedDataFlowDescriptor> Entries
        {
            get;
            set;
        }

        public SyncTypedDataFlowRegistry()
        {
        }

        public SyncTypedDataFlowRegistry(object[] items)
        {
            Entries = (IEnumerable<TypedDataFlowDescriptor>)items[0];
        }

        public SyncTypedDataFlowRegistry(IEnumerable<TypedDataFlowDescriptor> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<TypedDataFlowDescriptor>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncHostDatabases")]
    public partial class SyncHostDatabases : SqlProcedureProxy
    {
        [SqlParameter("@Databases", 0, true, false), SqlTypeFacets("[T0].[PlatformDatabase]", true)]
        public IEnumerable<PlatformDatabase> Databases
        {
            get;
            set;
        }

        public SyncHostDatabases()
        {
        }

        public SyncHostDatabases(object[] items)
        {
            Databases = (IEnumerable<PlatformDatabase>)items[0];
        }

        public SyncHostDatabases(IEnumerable<PlatformDatabase> Databases)
        {
            this.Databases = Databases;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Databases };
        }

        public override void SetItemArray(object[] items)
        {
            Databases = (IEnumerable<PlatformDatabase>)items[0];
        }
    }

    [SqlProcedure("PF", "UnregisterMissingHostDatabases")]
    public partial class UnregisterMissingHostDatabases : SqlProcedureProxy
    {
        public UnregisterMissingHostDatabases()
        {
        }
    }

    [SqlProcedure("PF", "ApplyDropLogs")]
    public partial class ApplyDropLogs : SqlProcedureProxy
    {
        public ApplyDropLogs()
        {
        }
    }

    [SqlProcedure("PF", "StoreDatabaseVersions")]
    public partial class StoreDatabaseVersions : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[T0].[DatabaseVersion]", true)]
        public IEnumerable<DatabaseVersion> Records
        {
            get;
            set;
        }

        public StoreDatabaseVersions()
        {
        }

        public StoreDatabaseVersions(object[] items)
        {
            Records = (IEnumerable<DatabaseVersion>)items[0];
        }

        public StoreDatabaseVersions(IEnumerable<DatabaseVersion> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<DatabaseVersion>)items[0];
        }
    }

    [SqlProcedure("PF", "PurgeFileReceiptQueue")]
    public partial class PurgeFileReceiptQueue : SqlProcedureProxy
    {
        public PurgeFileReceiptQueue()
        {
        }
    }

    [SqlProcedure("PF", "PublishFileReceipt")]
    public partial class PublishFileReceipt : SqlProcedureProxy
    {
        [SqlParameter("@MessageContent", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string MessageContent
        {
            get;
            set;
        }

        public PublishFileReceipt()
        {
        }

        public PublishFileReceipt(object[] items)
        {
            MessageContent = (string)items[0];
        }

        public PublishFileReceipt(string MessageContent)
        {
            this.MessageContent = MessageContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { MessageContent };
        }

        public override void SetItemArray(object[] items)
        {
            MessageContent = (string)items[0];
        }
    }

    [SqlProcedure("PF", "ProcessReleases")]
    public partial class ProcessReleases : SqlProcedureProxy
    {
        [SqlParameter("@streamIds", 0, true, false), SqlTypeFacets("[T0].[FileStreamIdentifier]", true)]
        public IEnumerable<FileStreamIdentifier> streamIds
        {
            get;
            set;
        }

        public ProcessReleases()
        {
        }

        public ProcessReleases(object[] items)
        {
            streamIds = (IEnumerable<FileStreamIdentifier>)items[0];
        }

        public ProcessReleases(IEnumerable<FileStreamIdentifier> streamIds)
        {
            this.streamIds = streamIds;
        }

        public override object[] GetItemArray()
        {
            return new object[] { streamIds };
        }

        public override void SetItemArray(object[] items)
        {
            streamIds = (IEnumerable<FileStreamIdentifier>)items[0];
        }
    }

    [SqlProcedure("PF", "PopFileReceiptQueue")]
    public partial class PopFileReceiptQueue : SqlProcedureProxy
    {
        public PopFileReceiptQueue()
        {
        }
    }

    [SqlProcedure("PF", "HandleReleaseReceipt")]
    public partial class HandleReleaseReceipt : SqlProcedureProxy
    {
        public HandleReleaseReceipt()
        {
        }
    }

    [SqlProcedure("PF", "LogPlatformStoreChanges")]
    public partial class LogPlatformStoreChanges : SqlProcedureProxy
    {
        [SqlParameter("@Changes", 0, true, false), SqlTypeFacets("[T0].[PlatformStoreChange]", true)]
        public IEnumerable<PlatformStoreChange> Changes
        {
            get;
            set;
        }

        public LogPlatformStoreChanges()
        {
        }

        public LogPlatformStoreChanges(object[] items)
        {
            Changes = (IEnumerable<PlatformStoreChange>)items[0];
        }

        public LogPlatformStoreChanges(IEnumerable<PlatformStoreChange> Changes)
        {
            this.Changes = Changes;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Changes };
        }

        public override void SetItemArray(object[] items)
        {
            Changes = (IEnumerable<PlatformStoreChange>)items[0];
        }
    }

    [SqlProcedure("PF", "ConfigureTableMonitoring")]
    public partial class ConfigureTableMonitoring : SqlProcedureProxy
    {
        [SqlParameter("@HostId", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string HostId
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseName", 1, false, false), SqlTypeFacets("nvarchar", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@SchemaName", 2, false, false), SqlTypeFacets("nvarchar", true)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlParameter("@TableName", 3, false, false), SqlTypeFacets("nvarchar", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlParameter("@MonitorFrequency", 4, false, false), SqlTypeFacets("int", true)]
        public int? MonitorFrequency
        {
            get;
            set;
        }

        [SqlParameter("@MonitorEnabled", 5, false, false), SqlTypeFacets("bit", true)]
        public bool? MonitorEnabled
        {
            get;
            set;
        }

        public ConfigureTableMonitoring()
        {
        }

        public ConfigureTableMonitoring(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            MonitorFrequency = (int?)items[4];
            MonitorEnabled = (bool?)items[5];
        }

        public ConfigureTableMonitoring(string HostId, string DatabaseName, string SchemaName, string TableName, int? MonitorFrequency, bool? MonitorEnabled)
        {
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.MonitorFrequency = MonitorFrequency;
            this.MonitorEnabled = MonitorEnabled;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, DatabaseName, SchemaName, TableName, MonitorFrequency, MonitorEnabled };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            MonitorFrequency = (int?)items[4];
            MonitorEnabled = (bool?)items[5];
        }
    }

    [SqlProcedure("PF", "DefineSqlMessages")]
    public partial class DefineSqlMessages : SqlProcedureProxy
    {
        [SqlParameter("@Definitions", 0, true, false), SqlTypeFacets("[T0].[SqlMessageSpec]", true)]
        public IEnumerable<SqlMessageSpec> Definitions
        {
            get;
            set;
        }

        public DefineSqlMessages()
        {
        }

        public DefineSqlMessages(object[] items)
        {
            Definitions = (IEnumerable<SqlMessageSpec>)items[0];
        }

        public DefineSqlMessages(IEnumerable<SqlMessageSpec> Definitions)
        {
            this.Definitions = Definitions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Definitions };
        }

        public override void SetItemArray(object[] items)
        {
            Definitions = (IEnumerable<SqlMessageSpec>)items[0];
        }
    }

    [SqlProcedure("PF", "LogDacDeployFinish")]
    public partial class LogDacDeployFinish : SqlProcedureProxy
    {
        [SqlParameter("@DeploymentId", 0, false, false), SqlTypeFacets("int", true)]
        public int? DeploymentId
        {
            get;
            set;
        }

        [SqlParameter("@Succeeded", 1, false, false), SqlTypeFacets("bit", true)]
        public bool? Succeeded
        {
            get;
            set;
        }

        [SqlParameter("@Message", 2, false, false), SqlTypeFacets("nvarchar", true)]
        public string Message
        {
            get;
            set;
        }

        public LogDacDeployFinish()
        {
        }

        public LogDacDeployFinish(object[] items)
        {
            DeploymentId = (int?)items[0];
            Succeeded = (bool?)items[1];
            Message = (string)items[2];
        }

        public LogDacDeployFinish(int? DeploymentId, bool? Succeeded, string Message)
        {
            this.DeploymentId = DeploymentId;
            this.Succeeded = Succeeded;
            this.Message = Message;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DeploymentId, Succeeded, Message };
        }

        public override void SetItemArray(object[] items)
        {
            DeploymentId = (int?)items[0];
            Succeeded = (bool?)items[1];
            Message = (string)items[2];
        }
    }

    [SqlProcedure("PF", "LogDacDeployStart")]
    public partial class LogDacDeployStart : SqlProcedureProxy<LogDacDeployStart, DacDeploymentToken>
    {
        [SqlParameter("@SourceNodeId", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlParameter("@SourcePackage", 1, false, false), SqlTypeFacets("nvarchar", true)]
        public string SourcePackage
        {
            get;
            set;
        }

        [SqlParameter("@TargetNodeId", 2, false, false), SqlTypeFacets("nvarchar", true)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlParameter("@TargetDatabase", 3, false, false), SqlTypeFacets("nvarchar", true)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlParameter("@CorrelationToken", 4, false, false), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public LogDacDeployStart()
        {
        }

        public LogDacDeployStart(object[] items)
        {
            SourceNodeId = (string)items[0];
            SourcePackage = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetDatabase = (string)items[3];
            CorrelationToken = (string)items[4];
        }

        public LogDacDeployStart(string SourceNodeId, string SourcePackage, string TargetNodeId, string TargetDatabase, string CorrelationToken)
        {
            this.SourceNodeId = SourceNodeId;
            this.SourcePackage = SourcePackage;
            this.TargetNodeId = TargetNodeId;
            this.TargetDatabase = TargetDatabase;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceNodeId, SourcePackage, TargetNodeId, TargetDatabase, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            SourceNodeId = (string)items[0];
            SourcePackage = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetDatabase = (string)items[3];
            CorrelationToken = (string)items[4];
        }
    }

    [SqlProcedure("PF", "LogFileReceipt")]
    public partial class LogFileReceipt : SqlProcedureProxy
    {
        [SqlParameter("@Receipts", 0, true, false), SqlTypeFacets("[T0].[FileReceipt]", true)]
        public IEnumerable<FileReceipt> Receipts
        {
            get;
            set;
        }

        public LogFileReceipt()
        {
        }

        public LogFileReceipt(object[] items)
        {
            Receipts = (IEnumerable<FileReceipt>)items[0];
        }

        public LogFileReceipt(IEnumerable<FileReceipt> Receipts)
        {
            this.Receipts = Receipts;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Receipts };
        }

        public override void SetItemArray(object[] items)
        {
            Receipts = (IEnumerable<FileReceipt>)items[0];
        }
    }

    [SqlProcedure("PF", "RegisterHostDatabase")]
    public partial class RegisterHostDatabase : SqlProcedureProxy
    {
        [SqlParameter("@DatabaseName", 0, false, false), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlParameter("@DatabaseType", 1, false, false), SqlTypeFacets("nvarchar", true)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlParameter("@IsPrimary", 2, false, false), SqlTypeFacets("bit", true)]
        public bool? IsPrimary
        {
            get;
            set;
        }

        [SqlParameter("@IsEnabled", 3, false, false), SqlTypeFacets("bit", true)]
        public bool? IsEnabled
        {
            get;
            set;
        }

        [SqlParameter("@IsModel", 4, false, false), SqlTypeFacets("bit", true)]
        public bool? IsModel
        {
            get;
            set;
        }

        [SqlParameter("@IsRestore", 5, false, false), SqlTypeFacets("bit", true)]
        public bool? IsRestore
        {
            get;
            set;
        }

        public RegisterHostDatabase()
        {
        }

        public RegisterHostDatabase(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseType = (string)items[1];
            IsPrimary = (bool?)items[2];
            IsEnabled = (bool?)items[3];
            IsModel = (bool?)items[4];
            IsRestore = (bool?)items[5];
        }

        public RegisterHostDatabase(string DatabaseName, string DatabaseType, bool? IsPrimary, bool? IsEnabled, bool? IsModel, bool? IsRestore)
        {
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.IsPrimary = IsPrimary;
            this.IsEnabled = IsEnabled;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DatabaseName, DatabaseType, IsPrimary, IsEnabled, IsModel, IsRestore };
        }

        public override void SetItemArray(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseType = (string)items[1];
            IsPrimary = (bool?)items[2];
            IsEnabled = (bool?)items[3];
            IsModel = (bool?)items[4];
            IsRestore = (bool?)items[5];
        }
    }

    [SqlProcedure("PF", "StoreArtifactReferences")]
    public partial class StoreArtifactReferences : SqlProcedureProxy
    {
        [SqlParameter("@Specs", 0, true, false), SqlTypeFacets("[T0].[ArtifactReferenceSpec]", true)]
        public IEnumerable<ArtifactReferenceSpec> Specs
        {
            get;
            set;
        }

        public StoreArtifactReferences()
        {
        }

        public StoreArtifactReferences(object[] items)
        {
            Specs = (IEnumerable<ArtifactReferenceSpec>)items[0];
        }

        public StoreArtifactReferences(IEnumerable<ArtifactReferenceSpec> Specs)
        {
            this.Specs = Specs;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Specs };
        }

        public override void SetItemArray(object[] items)
        {
            Specs = (IEnumerable<ArtifactReferenceSpec>)items[0];
        }
    }

    [SqlProcedure("PF", "StorePlatformEntities")]
    public partial class StorePlatformEntities : SqlProcedureProxy
    {
        [SqlParameter("@Entities", 0, true, false), SqlTypeFacets("[T0].[PlatformEntity]", true)]
        public IEnumerable<PlatformEntity> Entities
        {
            get;
            set;
        }

        public StorePlatformEntities()
        {
        }

        public StorePlatformEntities(object[] items)
        {
            Entities = (IEnumerable<PlatformEntity>)items[0];
        }

        public StorePlatformEntities(IEnumerable<PlatformEntity> Entities)
        {
            this.Entities = Entities;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entities };
        }

        public override void SetItemArray(object[] items)
        {
            Entities = (IEnumerable<PlatformEntity>)items[0];
        }
    }

    [SqlProcedure("PF", "StorePlatformEntity")]
    public partial class StorePlatformEntity : SqlProcedureProxy
    {
        [SqlParameter("@EntityName", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string EntityName
        {
            get;
            set;
        }

        [SqlParameter("@TypeUri", 1, false, false), SqlTypeFacets("nvarchar", true)]
        public string TypeUri
        {
            get;
            set;
        }

        [SqlParameter("@Body", 2, false, false), SqlTypeFacets("nvarchar", true)]
        public string Body
        {
            get;
            set;
        }

        public StorePlatformEntity()
        {
        }

        public StorePlatformEntity(object[] items)
        {
            EntityName = (string)items[0];
            TypeUri = (string)items[1];
            Body = (string)items[2];
        }

        public StorePlatformEntity(string EntityName, string TypeUri, string Body)
        {
            this.EntityName = EntityName;
            this.TypeUri = TypeUri;
            this.Body = Body;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntityName, TypeUri, Body };
        }

        public override void SetItemArray(object[] items)
        {
            EntityName = (string)items[0];
            TypeUri = (string)items[1];
            Body = (string)items[2];
        }
    }

    [SqlProcedure("PF", "StorePlatformVariables")]
    public partial class StorePlatformVariables : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[T0].[PlatformVariable]", true)]
        public IEnumerable<PlatformVariable> Records
        {
            get;
            set;
        }

        public StorePlatformVariables()
        {
        }

        public StorePlatformVariables(object[] items)
        {
            Records = (IEnumerable<PlatformVariable>)items[0];
        }

        public StorePlatformVariables(IEnumerable<PlatformVariable> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<PlatformVariable>)items[0];
        }
    }

    [SqlProcedure("PF", "StoreTableMonitorLogEntries")]
    public partial class StoreTableMonitorLogEntries : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[TableMonitorLogEntry]", true)]
        public IEnumerable<TableMonitorLogEntry> Entries
        {
            get;
            set;
        }

        public StoreTableMonitorLogEntries()
        {
        }

        public StoreTableMonitorLogEntries(object[] items)
        {
            Entries = (IEnumerable<TableMonitorLogEntry>)items[0];
        }

        public StoreTableMonitorLogEntries(IEnumerable<TableMonitorLogEntry> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<TableMonitorLogEntry>)items[0];
        }
    }

    [SqlProcedure("PF", "StubMessageFormats")]
    public partial class StubMessageFormats : SqlProcedureProxy
    {
        public StubMessageFormats()
        {
        }
    }

    [SqlProcedure("PF", "SyncDacProfiles")]
    public partial class SyncDacProfiles : SqlProcedureProxy
    {
        [SqlParameter("@Profiles", 0, true, false), SqlTypeFacets("[T0].[DacProfileDefinition]", true)]
        public IEnumerable<DacProfileDefinition> Profiles
        {
            get;
            set;
        }

        public SyncDacProfiles()
        {
        }

        public SyncDacProfiles(object[] items)
        {
            Profiles = (IEnumerable<DacProfileDefinition>)items[0];
        }

        public SyncDacProfiles(IEnumerable<DacProfileDefinition> Profiles)
        {
            this.Profiles = Profiles;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Profiles };
        }

        public override void SetItemArray(object[] items)
        {
            Profiles = (IEnumerable<DacProfileDefinition>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncDatabaseServers")]
    public partial class SyncDatabaseServers : SqlProcedureProxy
    {
        [SqlParameter("@Servers", 0, true, false), SqlTypeFacets("[T0].[DatabaseServer]", true)]
        public IEnumerable<DatabaseServer> Servers
        {
            get;
            set;
        }

        public SyncDatabaseServers()
        {
        }

        public SyncDatabaseServers(object[] items)
        {
            Servers = (IEnumerable<DatabaseServer>)items[0];
        }

        public SyncDatabaseServers(IEnumerable<DatabaseServer> Servers)
        {
            this.Servers = Servers;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Servers };
        }

        public override void SetItemArray(object[] items)
        {
            Servers = (IEnumerable<DatabaseServer>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncDistributionRegistry")]
    public partial class SyncDistributionRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[DistributionDescription]", true)]
        public IEnumerable<DistributionDescription> Entries
        {
            get;
            set;
        }

        public SyncDistributionRegistry()
        {
        }

        public SyncDistributionRegistry(object[] items)
        {
            Entries = (IEnumerable<DistributionDescription>)items[0];
        }

        public SyncDistributionRegistry(IEnumerable<DistributionDescription> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<DistributionDescription>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncEventRegistry")]
    public partial class SyncEventRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[SystemEventRegistration]", true)]
        public IEnumerable<SystemEventRegistration> Entries
        {
            get;
            set;
        }

        public SyncEventRegistry()
        {
        }

        public SyncEventRegistry(object[] items)
        {
            Entries = (IEnumerable<SystemEventRegistration>)items[0];
        }

        public SyncEventRegistry(IEnumerable<SystemEventRegistration> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<SystemEventRegistration>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncMessageClasses")]
    public partial class SyncMessageClasses : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[T0].[TinyTypeTableRow]", true)]
        public IEnumerable<TinyTypeTableRow> Records
        {
            get;
            set;
        }

        public SyncMessageClasses()
        {
        }

        public SyncMessageClasses(object[] items)
        {
            Records = (IEnumerable<TinyTypeTableRow>)items[0];
        }

        public SyncMessageClasses(IEnumerable<TinyTypeTableRow> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<TinyTypeTableRow>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncMessageFormats")]
    public partial class SyncMessageFormats : SqlProcedureProxy
    {
        [SqlParameter("@Formats", 0, true, false), SqlTypeFacets("[T0].[MessageFormat]", true)]
        public IEnumerable<MessageFormat> Formats
        {
            get;
            set;
        }

        public SyncMessageFormats()
        {
        }

        public SyncMessageFormats(object[] items)
        {
            Formats = (IEnumerable<MessageFormat>)items[0];
        }

        public SyncMessageFormats(IEnumerable<MessageFormat> Formats)
        {
            this.Formats = Formats;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Formats };
        }

        public override void SetItemArray(object[] items)
        {
            Formats = (IEnumerable<MessageFormat>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncMessageTypeRegistry")]
    public partial class SyncMessageTypeRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Types", 0, true, false), SqlTypeFacets("[T0].[MessageTypeRegistration]", true)]
        public IEnumerable<MessageTypeRegistration> Types
        {
            get;
            set;
        }

        [SqlParameter("@Attributes", 1, true, false), SqlTypeFacets("[T0].[MessageAttribute]", true)]
        public IEnumerable<MessageAttribute> Attributes
        {
            get;
            set;
        }

        public SyncMessageTypeRegistry()
        {
        }

        public SyncMessageTypeRegistry(object[] items)
        {
            Types = (IEnumerable<MessageTypeRegistration>)items[0];
            Attributes = (IEnumerable<MessageAttribute>)items[1];
        }

        public SyncMessageTypeRegistry(IEnumerable<MessageTypeRegistration> Types, IEnumerable<MessageAttribute> Attributes)
        {
            this.Types = Types;
            this.Attributes = Attributes;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Types, Attributes };
        }

        public override void SetItemArray(object[] items)
        {
            Types = (IEnumerable<MessageTypeRegistration>)items[0];
            Attributes = (IEnumerable<MessageAttribute>)items[1];
        }
    }

    [SqlProcedure("PF", "SyncPlatformAgents")]
    public partial class SyncPlatformAgents : SqlProcedureProxy
    {
        [SqlParameter("@Agents", 0, true, false), SqlTypeFacets("[T0].[PlatformAgent]", true)]
        public IEnumerable<PlatformAgent> Agents
        {
            get;
            set;
        }

        public SyncPlatformAgents()
        {
        }

        public SyncPlatformAgents(object[] items)
        {
            Agents = (IEnumerable<PlatformAgent>)items[0];
        }

        public SyncPlatformAgents(IEnumerable<PlatformAgent> Agents)
        {
            this.Agents = Agents;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Agents };
        }

        public override void SetItemArray(object[] items)
        {
            Agents = (IEnumerable<PlatformAgent>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformDacRegistry")]
    public partial class SyncPlatformDacRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[PlatformDacRegistration]", true)]
        public IEnumerable<PlatformDacRegistration> Entries
        {
            get;
            set;
        }

        public SyncPlatformDacRegistry()
        {
        }

        public SyncPlatformDacRegistry(object[] items)
        {
            Entries = (IEnumerable<PlatformDacRegistration>)items[0];
        }

        public SyncPlatformDacRegistry(IEnumerable<PlatformDacRegistration> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<PlatformDacRegistration>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformDatabases")]
    public partial class SyncPlatformDatabases : SqlProcedureProxy
    {
        [SqlParameter("@Databases", 0, true, false), SqlTypeFacets("[T0].[PlatformDatabase]", true)]
        public IEnumerable<PlatformDatabase> Databases
        {
            get;
            set;
        }

        public SyncPlatformDatabases()
        {
        }

        public SyncPlatformDatabases(object[] items)
        {
            Databases = (IEnumerable<PlatformDatabase>)items[0];
        }

        public SyncPlatformDatabases(IEnumerable<PlatformDatabase> Databases)
        {
            this.Databases = Databases;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Databases };
        }

        public override void SetItemArray(object[] items)
        {
            Databases = (IEnumerable<PlatformDatabase>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformProjects")]
    public partial class SyncPlatformProjects : SqlProcedureProxy
    {
        [SqlParameter("@Projects", 0, true, false), SqlTypeFacets("[T0].[PlatformProject]", true)]
        public IEnumerable<PlatformProject> Projects
        {
            get;
            set;
        }

        public SyncPlatformProjects()
        {
        }

        public SyncPlatformProjects(object[] items)
        {
            Projects = (IEnumerable<PlatformProject>)items[0];
        }

        public SyncPlatformProjects(IEnumerable<PlatformProject> Projects)
        {
            this.Projects = Projects;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Projects };
        }

        public override void SetItemArray(object[] items)
        {
            Projects = (IEnumerable<PlatformProject>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformServerRegistry")]
    public partial class SyncPlatformServerRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Nodes", 0, true, false), SqlTypeFacets("[T0].[PlatformNode]", true)]
        public IEnumerable<PlatformNode> Nodes
        {
            get;
            set;
        }

        public SyncPlatformServerRegistry()
        {
        }

        public SyncPlatformServerRegistry(object[] items)
        {
            Nodes = (IEnumerable<PlatformNode>)items[0];
        }

        public SyncPlatformServerRegistry(IEnumerable<PlatformNode> Nodes)
        {
            this.Nodes = Nodes;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Nodes };
        }

        public override void SetItemArray(object[] items)
        {
            Nodes = (IEnumerable<PlatformNode>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformSolutions")]
    public partial class SyncPlatformSolutions : SqlProcedureProxy
    {
        [SqlParameter("@Solutions", 0, true, false), SqlTypeFacets("[T0].[PlatformSolution]", true)]
        public IEnumerable<PlatformSolution> Solutions
        {
            get;
            set;
        }

        public SyncPlatformSolutions()
        {
        }

        public SyncPlatformSolutions(object[] items)
        {
            Solutions = (IEnumerable<PlatformSolution>)items[0];
        }

        public SyncPlatformSolutions(IEnumerable<PlatformSolution> Solutions)
        {
            this.Solutions = Solutions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Solutions };
        }

        public override void SetItemArray(object[] items)
        {
            Solutions = (IEnumerable<PlatformSolution>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncPlatformSystems")]
    public partial class SyncPlatformSystems : SqlProcedureProxy
    {
        [SqlParameter("@Systems", 0, true, false), SqlTypeFacets("[T0].[PlatformSystem]", true)]
        public IEnumerable<PlatformSystem> Systems
        {
            get;
            set;
        }

        public SyncPlatformSystems()
        {
        }

        public SyncPlatformSystems(object[] items)
        {
            Systems = (IEnumerable<PlatformSystem>)items[0];
        }

        public SyncPlatformSystems(IEnumerable<PlatformSystem> Systems)
        {
            this.Systems = Systems;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Systems };
        }

        public override void SetItemArray(object[] items)
        {
            Systems = (IEnumerable<PlatformSystem>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncSqlProxyDefinitions")]
    public partial class SyncSqlProxyDefinitions : SqlProcedureProxy
    {
        [SqlParameter("@Specs", 0, true, false), SqlTypeFacets("[T0].[SqlProxyDefinition]", true)]
        public IEnumerable<SqlProxyDefinition> Specs
        {
            get;
            set;
        }

        public SyncSqlProxyDefinitions()
        {
        }

        public SyncSqlProxyDefinitions(object[] items)
        {
            Specs = (IEnumerable<SqlProxyDefinition>)items[0];
        }

        public SyncSqlProxyDefinitions(IEnumerable<SqlProxyDefinition> Specs)
        {
            this.Specs = Specs;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Specs };
        }

        public override void SetItemArray(object[] items)
        {
            Specs = (IEnumerable<SqlProxyDefinition>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncSystemCommandRegistry")]
    public partial class SyncSystemCommandRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[T0].[SystemCommandRegistration]", true)]
        public IEnumerable<SystemCommandRegistration> Entries
        {
            get;
            set;
        }

        public SyncSystemCommandRegistry()
        {
        }

        public SyncSystemCommandRegistry(object[] items)
        {
            Entries = (IEnumerable<SystemCommandRegistration>)items[0];
        }

        public SyncSystemCommandRegistry(IEnumerable<SystemCommandRegistration> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<SystemCommandRegistration>)items[0];
        }
    }

    [SqlProcedure("PF", "SyncSystemComponents")]
    public partial class SyncSystemComponents : SqlProcedureProxy
    {
        [SqlParameter("@Components", 0, true, false), SqlTypeFacets("[T0].[SystemComponent]", true)]
        public IEnumerable<SystemComponent> Components
        {
            get;
            set;
        }

        public SyncSystemComponents()
        {
        }

        public SyncSystemComponents(object[] items)
        {
            Components = (IEnumerable<SystemComponent>)items[0];
        }

        public SyncSystemComponents(IEnumerable<SystemComponent> Components)
        {
            this.Components = Components;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Components };
        }

        public override void SetItemArray(object[] items)
        {
            Components = (IEnumerable<SystemComponent>)items[0];
        }
    }

    [SqlTableFunction("PF", "UnclassifiedDatabases")]
    public partial class UnclassifiedDatabases : SqlTableFunctionProxy<UnclassifiedDatabases, UnclassifiedDatabasesResult>
    {
        public UnclassifiedDatabases()
        {
        }
    }

    [SqlTableFunctionResult("PF", "UnclassifiedDatabases")]
    public partial class UnclassifiedDatabasesResult : SqlTabularProxy
    {
        [SqlColumn("SqlNodeId", 0), SqlTypeFacets("nvarchar", false)]
        public string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 1), SqlTypeFacets("varchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 2), SqlTypeFacets("sysname", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("IsModel", 3), SqlTypeFacets("bit", true)]
        public bool? IsModel
        {
            get;
            set;
        }

        [SqlColumn("IsRestore", 4), SqlTypeFacets("bit", true)]
        public bool? IsRestore
        {
            get;
            set;
        }

        public UnclassifiedDatabasesResult()
        {
        }

        public UnclassifiedDatabasesResult(object[] items)
        {
            SqlNodeId = (string)items[0];
            DatabaseType = (string)items[1];
            DatabaseName = (string)items[2];
            IsModel = (bool?)items[3];
            IsRestore = (bool?)items[4];
        }

        public UnclassifiedDatabasesResult(string SqlNodeId, string DatabaseType, string DatabaseName, bool? IsModel, bool? IsRestore)
        {
            this.SqlNodeId = SqlNodeId;
            this.DatabaseType = DatabaseType;
            this.DatabaseName = DatabaseName;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SqlNodeId, DatabaseType, DatabaseName, IsModel, IsRestore };
        }

        public override void SetItemArray(object[] items)
        {
            SqlNodeId = (string)items[0];
            DatabaseType = (string)items[1];
            DatabaseName = (string)items[2];
            IsModel = (bool?)items[3];
            IsRestore = (bool?)items[4];
        }
    }

    [SqlTableFunction("PF", "XEventDataBlocks")]
    public partial class XEventDataBlocks : SqlTableFunctionProxy<XEventDataBlocks, XEventDataBlock>
    {
        [SqlParameter("@SrcFile", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string SrcFile
        {
            get;
            set;
        }

        [SqlParameter("@MaxCount", 1, false, false), SqlTypeFacets("int", true)]
        public int? MaxCount
        {
            get;
            set;
        }

        [SqlParameter("@MinOffset", 2, false, false), SqlTypeFacets("int", true)]
        public int? MinOffset
        {
            get;
            set;
        }

        public XEventDataBlocks()
        {
        }

        public XEventDataBlocks(object[] items)
        {
            SrcFile = (string)items[0];
            MaxCount = (int?)items[1];
            MinOffset = (int?)items[2];
        }

        public XEventDataBlocks(string SrcFile, int? MaxCount, int? MinOffset)
        {
            this.SrcFile = SrcFile;
            this.MaxCount = MaxCount;
            this.MinOffset = MinOffset;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcFile, MaxCount, MinOffset };
        }

        public override void SetItemArray(object[] items)
        {
            SrcFile = (string)items[0];
            MaxCount = (int?)items[1];
            MinOffset = (int?)items[2];
        }
    }

    [SqlTableFunction("PF", "PlatformNotifications")]
    public partial class PlatformNotifications : SqlTableFunctionProxy<PlatformNotifications, PlatformNotification>
    {
        [SqlParameter("@SrcFile", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string SrcFile
        {
            get;
            set;
        }

        [SqlParameter("@MaxCount", 1, false, false), SqlTypeFacets("int", true)]
        public int? MaxCount
        {
            get;
            set;
        }

        [SqlParameter("@MinOffset", 2, false, false), SqlTypeFacets("int", true)]
        public int? MinOffset
        {
            get;
            set;
        }

        public PlatformNotifications()
        {
        }

        public PlatformNotifications(object[] items)
        {
            SrcFile = (string)items[0];
            MaxCount = (int?)items[1];
            MinOffset = (int?)items[2];
        }

        public PlatformNotifications(string SrcFile, int? MaxCount, int? MinOffset)
        {
            this.SrcFile = SrcFile;
            this.MaxCount = MaxCount;
            this.MinOffset = MinOffset;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcFile, MaxCount, MinOffset };
        }

        public override void SetItemArray(object[] items)
        {
            SrcFile = (string)items[0];
            MaxCount = (int?)items[1];
            MinOffset = (int?)items[2];
        }
    }

    [SqlTableFunction("PF", "PlatformReleases")]
    public partial class PlatformReleases : SqlTableFunctionProxy<PlatformReleases, PlatformReleasesResult>
    {
        public PlatformReleases()
        {
        }
    }

    [SqlTableFunctionResult("PF", "PlatformReleases")]
    public partial class PlatformReleasesResult : SqlTabularProxy
    {
        [SqlColumn("StreamId", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid StreamId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 1), SqlTypeFacets("nvarchar", false)]
        public string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileType", 2), SqlTypeFacets("nvarchar", true)]
        public string FileType
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 3), SqlTypeFacets("bigint", true)]
        public long? FileSize
        {
            get;
            set;
        }

        [SqlColumn("ReceivedTime", 4), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset ReceivedTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("UncPath", 6), SqlTypeFacets("nvarchar", true)]
        public string UncPath
        {
            get;
            set;
        }

        public PlatformReleasesResult()
        {
        }

        public PlatformReleasesResult(object[] items)
        {
            StreamId = (Guid)items[0];
            FileName = (string)items[1];
            FileType = (string)items[2];
            FileSize = (long?)items[3];
            ReceivedTime = (DateTimeOffset)items[4];
            LastWriteTime = (DateTimeOffset)items[5];
            UncPath = (string)items[6];
        }

        public PlatformReleasesResult(Guid StreamId, string FileName, string FileType, long? FileSize, DateTimeOffset ReceivedTime, DateTimeOffset LastWriteTime, string UncPath)
        {
            this.StreamId = StreamId;
            this.FileName = FileName;
            this.FileType = FileType;
            this.FileSize = FileSize;
            this.ReceivedTime = ReceivedTime;
            this.LastWriteTime = LastWriteTime;
            this.UncPath = UncPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StreamId, FileName, FileType, FileSize, ReceivedTime, LastWriteTime, UncPath };
        }

        public override void SetItemArray(object[] items)
        {
            StreamId = (Guid)items[0];
            FileName = (string)items[1];
            FileType = (string)items[2];
            FileSize = (long?)items[3];
            ReceivedTime = (DateTimeOffset)items[4];
            LastWriteTime = (DateTimeOffset)items[5];
            UncPath = (string)items[6];
        }
    }

    [SqlTableFunction("PF", "DatabaseBackups")]
    public partial class DatabaseBackups : SqlTableFunctionProxy<DatabaseBackups, DatabaseBackupsResult>
    {
        public DatabaseBackups()
        {
        }
    }

    [SqlTableFunctionResult("PF", "DatabaseBackups")]
    public partial class DatabaseBackupsResult : SqlTabularProxy
    {
        [SqlColumn("StreamId", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid StreamId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 1), SqlTypeFacets("nvarchar", false)]
        public string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileType", 2), SqlTypeFacets("nvarchar", true)]
        public string FileType
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 3), SqlTypeFacets("bigint", true)]
        public long? FileSize
        {
            get;
            set;
        }

        [SqlColumn("ReceivedTime", 4), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset ReceivedTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 5), SqlTypeFacets("datetimeoffset", false)]
        public DateTimeOffset LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("UncPath", 6), SqlTypeFacets("nvarchar", true)]
        public string UncPath
        {
            get;
            set;
        }

        public DatabaseBackupsResult()
        {
        }

        public DatabaseBackupsResult(object[] items)
        {
            StreamId = (Guid)items[0];
            FileName = (string)items[1];
            FileType = (string)items[2];
            FileSize = (long?)items[3];
            ReceivedTime = (DateTimeOffset)items[4];
            LastWriteTime = (DateTimeOffset)items[5];
            UncPath = (string)items[6];
        }

        public DatabaseBackupsResult(Guid StreamId, string FileName, string FileType, long? FileSize, DateTimeOffset ReceivedTime, DateTimeOffset LastWriteTime, string UncPath)
        {
            this.StreamId = StreamId;
            this.FileName = FileName;
            this.FileType = FileType;
            this.FileSize = FileSize;
            this.ReceivedTime = ReceivedTime;
            this.LastWriteTime = LastWriteTime;
            this.UncPath = UncPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StreamId, FileName, FileType, FileSize, ReceivedTime, LastWriteTime, UncPath };
        }

        public override void SetItemArray(object[] items)
        {
            StreamId = (Guid)items[0];
            FileName = (string)items[1];
            FileType = (string)items[2];
            FileSize = (long?)items[3];
            ReceivedTime = (DateTimeOffset)items[4];
            LastWriteTime = (DateTimeOffset)items[5];
            UncPath = (string)items[6];
        }
    }

    [SqlTableFunction("PF", "DacProfiles")]
    public partial class DacProfiles : SqlTableFunctionProxy<DacProfiles, DacProfileDefinition>
    {
        public DacProfiles()
        {
        }
    }

    [SqlTableFunction("PF", "DatabaseServers")]
    public partial class DatabaseServers : SqlTableFunctionProxy<DatabaseServers, DatabaseServer>
    {
        public DatabaseServers()
        {
        }
    }

    [SqlTableFunction("PF", "FindPlatformEntity")]
    public partial class FindPlatformEntity : SqlTableFunctionProxy<FindPlatformEntity, PlatformEntity>
    {
        [SqlParameter("@EntityName", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string EntityName
        {
            get;
            set;
        }

        public FindPlatformEntity()
        {
        }

        public FindPlatformEntity(object[] items)
        {
            EntityName = (string)items[0];
        }

        public FindPlatformEntity(string EntityName)
        {
            this.EntityName = EntityName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntityName };
        }

        public override void SetItemArray(object[] items)
        {
            EntityName = (string)items[0];
        }
    }

    [SqlTableFunction("PF", "MessageAttributes")]
    public partial class MessageAttributes : SqlTableFunctionProxy<MessageAttributes, MessageAttribute>
    {
        public MessageAttributes()
        {
        }
    }

    [SqlTableFunction("PF", "MessageClasses")]
    public partial class MessageClasses : SqlTableFunctionProxy<MessageClasses, TinyTypeTable>
    {
        public MessageClasses()
        {
        }
    }

    [SqlTableFunction("PF", "MessageFormats")]
    public partial class MessageFormats : SqlTableFunctionProxy<MessageFormats, MessageFormat>
    {
        public MessageFormats()
        {
        }
    }

    [SqlTableFunction("PF", "MessageTypes")]
    public partial class MessageTypes : SqlTableFunctionProxy<MessageTypes, MessageTypeRegistration>
    {
        public MessageTypes()
        {
        }
    }

    [SqlTableFunction("PF", "MonitoredTables")]
    public partial class MonitoredTables : SqlTableFunctionProxy<MonitoredTables, MonitoredTable>
    {
        public MonitoredTables()
        {
        }
    }

    [SqlTableFunction("PF", "NavigationFolders")]
    public partial class NavigationFolders : SqlTableFunctionProxy<NavigationFolders, NavigationFoldersResult>
    {
        public NavigationFolders()
        {
        }
    }

    [SqlTableFunctionResult("PF", "NavigationFolders")]
    public partial class NavigationFoldersResult : SqlTabularProxy
    {
        [SqlColumn("FolderIdentifier", 0), SqlTypeFacets("nvarchar", false)]
        public string FolderIdentifier
        {
            get;
            set;
        }

        [SqlColumn("NavigatorType", 1), SqlTypeFacets("nvarchar", false)]
        public string NavigatorType
        {
            get;
            set;
        }

        [SqlColumn("FolderName", 2), SqlTypeFacets("nvarchar", false)]
        public string FolderName
        {
            get;
            set;
        }

        public NavigationFoldersResult()
        {
        }

        public NavigationFoldersResult(object[] items)
        {
            FolderIdentifier = (string)items[0];
            NavigatorType = (string)items[1];
            FolderName = (string)items[2];
        }

        public NavigationFoldersResult(string FolderIdentifier, string NavigatorType, string FolderName)
        {
            this.FolderIdentifier = FolderIdentifier;
            this.NavigatorType = NavigatorType;
            this.FolderName = FolderName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FolderIdentifier, NavigatorType, FolderName };
        }

        public override void SetItemArray(object[] items)
        {
            FolderIdentifier = (string)items[0];
            NavigatorType = (string)items[1];
            FolderName = (string)items[2];
        }
    }

    [SqlTableFunction("PF", "PlatformAgents")]
    public partial class PlatformAgents : SqlTableFunctionProxy<PlatformAgents, PlatformAgent>
    {
        public PlatformAgents()
        {
        }
    }

    [SqlTableFunction("PF", "PlatformDacs")]
    public partial class PlatformDacs : SqlTableFunctionProxy<PlatformDacs, PlatformDacRegistration>
    {
        public PlatformDacs()
        {
        }
    }

    [SqlTableFunction("PF", "PlatformDatabaseProfiles")]
    public partial class PlatformDatabaseProfiles : SqlTableFunctionProxy<PlatformDatabaseProfiles, PlatformDatabaseProfilesResult>
    {
        public PlatformDatabaseProfiles()
        {
        }
    }

    [SqlTableFunctionResult("PF", "PlatformDatabaseProfiles")]
    public partial class PlatformDatabaseProfilesResult : SqlTabularProxy
    {
        [SqlColumn("RowId", 0), SqlTypeFacets("bigint", true)]
        public long? RowId
        {
            get;
            set;
        }

        [SqlColumn("DupIdx", 1), SqlTypeFacets("bigint", true)]
        public long? DupIdx
        {
            get;
            set;
        }

        [SqlColumn("ServerId", 2), SqlTypeFacets("nvarchar", false)]
        public string ServerId
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 3), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 4), SqlTypeFacets("nvarchar", false)]
        public string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("ProfilePath", 5), SqlTypeFacets("nvarchar", true)]
        public string ProfilePath
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 6), SqlTypeFacets("nvarchar", true)]
        public string ProfileXml
        {
            get;
            set;
        }

        public PlatformDatabaseProfilesResult()
        {
        }

        public PlatformDatabaseProfilesResult(object[] items)
        {
            RowId = (long?)items[0];
            DupIdx = (long?)items[1];
            ServerId = (string)items[2];
            DatabaseName = (string)items[3];
            DatabaseType = (string)items[4];
            ProfilePath = (string)items[5];
            ProfileXml = (string)items[6];
        }

        public PlatformDatabaseProfilesResult(long? RowId, long? DupIdx, string ServerId, string DatabaseName, string DatabaseType, string ProfilePath, string ProfileXml)
        {
            this.RowId = RowId;
            this.DupIdx = DupIdx;
            this.ServerId = ServerId;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.ProfilePath = ProfilePath;
            this.ProfileXml = ProfileXml;
        }

        public override object[] GetItemArray()
        {
            return new object[] { RowId, DupIdx, ServerId, DatabaseName, DatabaseType, ProfilePath, ProfileXml };
        }

        public override void SetItemArray(object[] items)
        {
            RowId = (long?)items[0];
            DupIdx = (long?)items[1];
            ServerId = (string)items[2];
            DatabaseName = (string)items[3];
            DatabaseType = (string)items[4];
            ProfilePath = (string)items[5];
            ProfileXml = (string)items[6];
        }
    }

    [SqlTableFunction("PF", "PlatformDatabases")]
    public partial class PlatformDatabases : SqlTableFunctionProxy<PlatformDatabases, PlatformDatabase>
    {
        [SqlParameter("@HostId", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string HostId
        {
            get;
            set;
        }

        public PlatformDatabases()
        {
        }

        public PlatformDatabases(object[] items)
        {
            HostId = (string)items[0];
        }

        public PlatformDatabases(string HostId)
        {
            this.HostId = HostId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
        }
    }

    [SqlTableFunction("PF", "PlatformProjects")]
    public partial class PlatformProjects : SqlTableFunctionProxy<PlatformProjects, PlatformProject>
    {
        public PlatformProjects()
        {
        }
    }

    /// <summary>
    /// Registry for Windows server hosts, each of which host an arbitrary number of SQL Server instances
    /// </summary>
    [SqlTableFunction("PF", "PlatformServers")]
    public partial class PlatformServers : SqlTableFunctionProxy<PlatformServers, PlatformNode>
    {
        public PlatformServers()
        {
        }
    }

    [SqlTableFunction("PF", "PlatformSolutions")]
    public partial class PlatformSolutions : SqlTableFunctionProxy<PlatformSolutions, PlatformSolution>
    {
        public PlatformSolutions()
        {
        }
    }

    [SqlTableFunction("PF", "RegisteredDistributions")]
    public partial class RegisteredDistributions : SqlTableFunctionProxy<RegisteredDistributions, DistributionDescription>
    {
        public RegisteredDistributions()
        {
        }
    }

    [SqlTableFunction("PF", "SqlMessageDefinitions")]
    public partial class SqlMessageDefinitions : SqlTableFunctionProxy<SqlMessageDefinitions, SqlMessageSpec>
    {
        public SqlMessageDefinitions()
        {
        }
    }

    [SqlTableFunction("PF", "SqlProxyDefinitions")]
    public partial class SqlProxyDefinitions : SqlTableFunctionProxy<SqlProxyDefinitions, SqlProxyDefinition>
    {
        public SqlProxyDefinitions()
        {
        }
    }

    [SqlTableFunction("PF", "SqlProxyDefinitionsByDatabase")]
    public partial class SqlProxyDefinitionsByDatabase : SqlTableFunctionProxy<SqlProxyDefinitionsByDatabase, SqlProxyDefinition>
    {
        [SqlParameter("@DbName", 0, false, false), SqlTypeFacets("nvarchar", true)]
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

    [SqlTableFunction("PF", "SqlProxyProjects")]
    public partial class SqlProxyProjects : SqlTableFunctionProxy<SqlProxyProjects, SqlProxyProjectsResult>
    {
        public SqlProxyProjects()
        {
        }
    }

    [SqlTableFunctionResult("PF", "SqlProxyProjects")]
    public partial class SqlProxyProjectsResult : SqlTabularProxy
    {
        [SqlColumn("AssemblyDesignator", 0), SqlTypeFacets("nvarchar", false)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 3), SqlTypeFacets("nvarchar", true)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 4), SqlTypeFacets("nvarchar", true)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProjectId", 5), SqlTypeFacets("nvarchar", true)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 6), SqlTypeFacets("nvarchar", true)]
        public string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 7), SqlTypeFacets("nvarchar", true)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("ProjectSystemId", 8), SqlTypeFacets("nvarchar", true)]
        public string ProjectSystemId
        {
            get;
            set;
        }

        public SqlProxyProjectsResult()
        {
        }

        public SqlProxyProjectsResult(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            SystemId = (string)items[1];
            ProfileName = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetAssembly = (string)items[4];
            ProjectId = (string)items[5];
            ProjectName = (string)items[6];
            SolutionId = (string)items[7];
            ProjectSystemId = (string)items[8];
        }

        public SqlProxyProjectsResult(string AssemblyDesignator, string SystemId, string ProfileName, string SourceDatabase, string TargetAssembly, string ProjectId, string ProjectName, string SolutionId, string ProjectSystemId)
        {
            this.AssemblyDesignator = AssemblyDesignator;
            this.SystemId = SystemId;
            this.ProfileName = ProfileName;
            this.SourceDatabase = SourceDatabase;
            this.TargetAssembly = TargetAssembly;
            this.ProjectId = ProjectId;
            this.ProjectName = ProjectName;
            this.SolutionId = SolutionId;
            this.ProjectSystemId = ProjectSystemId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AssemblyDesignator, SystemId, ProfileName, SourceDatabase, TargetAssembly, ProjectId, ProjectName, SolutionId, ProjectSystemId };
        }

        public override void SetItemArray(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            SystemId = (string)items[1];
            ProfileName = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetAssembly = (string)items[4];
            ProjectId = (string)items[5];
            ProjectName = (string)items[6];
            SolutionId = (string)items[7];
            ProjectSystemId = (string)items[8];
        }
    }

    [SqlTableFunction("PF", "SystemCommands")]
    public partial class SystemCommands : SqlTableFunctionProxy<SystemCommands, SystemEventRegistration>
    {
        public SystemCommands()
        {
        }
    }

    [SqlTableFunction("PF", "SystemComponents")]
    public partial class SystemComponents : SqlTableFunctionProxy<SystemComponents, SystemComponent>
    {
        public SystemComponents()
        {
        }
    }

    [SqlTableFunction("PF", "SystemEvents")]
    public partial class SystemEvents : SqlTableFunctionProxy<SystemEvents, SystemEventRegistration>
    {
        public SystemEvents()
        {
        }
    }

    [SqlTableFunction("PF", "Systems")]
    public partial class Systems : SqlTableFunctionProxy<Systems, PlatformSystem>
    {
        public Systems()
        {
        }
    }

    [SqlTableFunction("PF", "TableMonitorLogEntries")]
    public partial class TableMonitorLogEntries : SqlTableFunctionProxy<TableMonitorLogEntries, TableMonitorLogEntry>
    {
        public TableMonitorLogEntries()
        {
        }
    }

    [SqlTableFunction("PF", "TypedDataFlows")]
    public partial class TypedDataFlows : SqlTableFunctionProxy<TypedDataFlows, TypedDataFlowDescriptor>
    {
        public TypedDataFlows()
        {
        }
    }

    [SqlTableFunction("PF", "FindDatabaseProfiles")]
    public partial class FindDatabaseProfiles : SqlTableFunctionProxy<FindDatabaseProfiles, PlatformDatabaseProfile>
    {
        [SqlParameter("@DatabaseName", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        public FindDatabaseProfiles()
        {
        }

        public FindDatabaseProfiles(object[] items)
        {
            DatabaseName = (string)items[0];
        }

        public FindDatabaseProfiles(string DatabaseName)
        {
            this.DatabaseName = DatabaseName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DatabaseName };
        }

        public override void SetItemArray(object[] items)
        {
            DatabaseName = (string)items[0];
        }
    }

    [SqlTableFunction("PF", "FindSqlProxyDefinition")]
    public partial class FindSqlProxyDefinition : SqlTableFunctionProxy<FindSqlProxyDefinition, SqlProxyDefinition>
    {
        [SqlParameter("@ProfileName", 0, false, false), SqlTypeFacets("nvarchar", true)]
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

    [SqlTableFunction("PF", "ProjectComponents")]
    public partial class ProjectComponents : SqlTableFunctionProxy<ProjectComponents, ProjectComponent>
    {
        public ProjectComponents()
        {
        }
    }

    [SqlTableFunction("PF", "TargetedDatabaseComponents")]
    public partial class TargetedDatabaseComponents : SqlTableFunctionProxy<TargetedDatabaseComponents, TargetedDatabaseComponent>
    {
        public TargetedDatabaseComponents()
        {
        }
    }

    [SqlTableFunction("PF", "XEventLogFiles")]
    public partial class XEventLogFiles : SqlTableFunctionProxy<XEventLogFiles, XEventLogFile>
    {
        [SqlParameter("@LogDir", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string LogDir
        {
            get;
            set;
        }

        public XEventLogFiles()
        {
        }

        public XEventLogFiles(object[] items)
        {
            LogDir = (string)items[0];
        }

        public XEventLogFiles(string LogDir)
        {
            this.LogDir = LogDir;
        }

        public override object[] GetItemArray()
        {
            return new object[] { LogDir };
        }

        public override void SetItemArray(object[] items)
        {
            LogDir = (string)items[0];
        }
    }

    [SqlTableFunction("PF", "ArchivedPlatformNotifications")]
    public partial class ArchivedPlatformNotifications : SqlTableFunctionProxy<ArchivedPlatformNotifications, ArchivedPlatformNotification>
    {
        [SqlParameter("@SrcNodeId", 0, false, false), SqlTypeFacets("varchar", true)]
        public string SrcNodeId
        {
            get;
            set;
        }

        [SqlParameter("@MaxLogCount", 1, false, false), SqlTypeFacets("int", true)]
        public int? MaxLogCount
        {
            get;
            set;
        }

        public ArchivedPlatformNotifications()
        {
        }

        public ArchivedPlatformNotifications(object[] items)
        {
            SrcNodeId = (string)items[0];
            MaxLogCount = (int?)items[1];
        }

        public ArchivedPlatformNotifications(string SrcNodeId, int? MaxLogCount)
        {
            this.SrcNodeId = SrcNodeId;
            this.MaxLogCount = MaxLogCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SrcNodeId, MaxLogCount };
        }

        public override void SetItemArray(object[] items)
        {
            SrcNodeId = (string)items[0];
            MaxLogCount = (int?)items[1];
        }
    }

    [SqlTableFunction("PF", "HostFiles")]
    public partial class HostFiles : SqlTableFunctionProxy<HostFiles, HostFileInfo>
    {
        [SqlParameter("@SrcPath", 0, false, false), SqlTypeFacets("nvarchar", true)]
        public string SrcPath
        {
            get;
            set;
        }

        [SqlParameter("@Filter", 1, false, false), SqlTypeFacets("nvarchar", true)]
        public string Filter
        {
            get;
            set;
        }

        public HostFiles()
        {
        }

        public HostFiles(object[] items)
        {
            SrcPath = (string)items[0];
            Filter = (string)items[1];
        }

        public HostFiles(string SrcPath, string Filter)
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
}
namespace MetaFlow.Core.Storage
{
    using System;
    using System.Collections.Generic;
    using SqlT.Types;
    using SqlT.Types.MC;
    using MetaFlow.Core;
    using MetaFlow.XE;
    using System.ComponentModel;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class ProxyBrokerFactory : SqlProxyBrokerFactory<ProxyBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"MetaFlow";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<ProxyBrokerFactory>)(new ProxyBrokerFactory())).CreateBroker(cs);
    }
}
// Emission concluded at 7/9/2018 7:10:11 PM
