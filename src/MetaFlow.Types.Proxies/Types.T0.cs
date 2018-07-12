//This file was generated at 7/9/2018 7:22:00 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class PFTableTypeNames
    {
        public const string DatabaseCreateEventData = "[PF].[DatabaseCreateEventData]";
        public const string DatabaseDropEventData = "[PF].[DatabaseDropEventData]";
    }

    [SqlRecord("PF", "DatabaseDropEventData")]
    public partial class DatabaseDropEventData : SqlTableTypeProxy<DatabaseDropEventData>, IDatabaseDropEventData
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false)]
        public string ServerName
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

        [SqlColumn("LoginName", 2), SqlTypeFacets("nvarchar", false)]
        public string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        public DatabaseDropEventData()
        {
        }

        public DatabaseDropEventData(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            LoginName = (string)items[2];
            EventTS = (DateTime)items[3];
        }

        public DatabaseDropEventData(string ServerName, string DatabaseName, string LoginName, DateTime EventTS)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.LoginName = LoginName;
            this.EventTS = EventTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, LoginName, EventTS };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            LoginName = (string)items[2];
            EventTS = (DateTime)items[3];
        }
    }

    [SqlRecord("PF", "DatabaseCreateEventData")]
    public partial class DatabaseCreateEventData : SqlTableTypeProxy<DatabaseCreateEventData>, IDatabaseCreateEventData
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false)]
        public string ServerName
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

        [SqlColumn("LoginName", 2), SqlTypeFacets("nvarchar", false)]
        public string LoginName
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        public DatabaseCreateEventData()
        {
        }

        public DatabaseCreateEventData(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            LoginName = (string)items[2];
            EventTS = (DateTime)items[3];
        }

        public DatabaseCreateEventData(string ServerName, string DatabaseName, string LoginName, DateTime EventTS)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.LoginName = LoginName;
            this.EventTS = EventTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, LoginName, EventTS };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            LoginName = (string)items[2];
            EventTS = (DateTime)items[3];
        }
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

    public enum PlatformArtifactKind : byte
    {
    }

    public enum PlatformChannelKind : byte
    {
    }

    public enum PlatformDatabaseKind : int
    {
        /// <summary>
        /// Signifies the absence of a platform database classification
        /// </summary>
        [Description("Signifies the absence of a platform database classification")]
        None = 0,
        /// <summary>
        /// MetaFlow Platform Database
        /// </summary>
        [Description("MetaFlow Platform Database")]
        MetaFlow = 1,
        /// <summary>
        /// Shared datasets
        /// </summary>
        [Description("Shared datasets")]
        DS = 3,
        /// <summary>
        /// Maintains dataset shares for fixed formats
        /// </summary>
        [Description("Maintains dataset shares for fixed formats")]
        DF = 4,
        /// <summary>
        /// Metadata catalog
        /// </summary>
        [Description("Metadata catalog")]
        ML = 5,
        /// <summary>
        /// Reference Database
        /// </summary>
        [Description("Reference Database")]
        RF = 16,
        /// <summary>
        /// Workspace Database
        /// </summary>
        [Description("Workspace Database")]
        WS = 27,
        /// <summary>
        /// Reporting infrastructure support
        /// </summary>
        [Description("Reporting infrastructure support")]
        RP = 28,
        /// <summary>
        /// Workflow instance database
        /// </summary>
        [Description("Workflow instance database")]
        WF = 33
    }

    public enum PlatformFileKind : int
    {
        None = 0,
        /// <summary>
        /// A database backup 
        /// </summary>
        [Description("A database backup ")]
        DatabaseBackup = 1,
        /// <summary>
        /// A platform distribution package
        /// </summary>
        [Description("A platform distribution package")]
        Distribution = 2,
        /// <summary>
        /// A zip file containing a database backup
        /// </summary>
        [Description("A zip file containing a database backup")]
        DatabaseBackupArchive = 3
    }

    public enum PlatformNavigatorKind : byte
    {
        /// <summary>
        /// Indicates the absence of a classification
        /// </summary>
        [Description("Indicates the absence of a classification")]
        None = 0,
        /// <summary>
        /// PDMS Runtime Navigator
        /// </summary>
        [Description("PDMS Runtime Navigator")]
        PDR = 1,
        /// <summary>
        /// Application Log Navigator
        /// </summary>
        [Description("Application Log Navigator")]
        AppLog = 2,
        /// <summary>
        /// Asset Navigator
        /// </summary>
        [Description("Asset Navigator")]
        Assets = 3,
        /// <summary>
        /// Dataset Share Navigator
        /// </summary>
        [Description("Dataset Share Navigator")]
        Datasets = 4,
        /// <summary>
        /// Platform Share Navigator
        /// </summary>
        [Description("Platform Share Navigator")]
        Platform = 5,
        /// <summary>
        /// XEvent Log Navigator
        /// </summary>
        [Description("XEvent Log Navigator")]
        XEventLog = 6
    }

    public enum PlatformShareKind : byte
    {
        /// <summary>
        /// Indicates the absence of a share classification
        /// </summary>
        [Description("Indicates the absence of a share classification")]
        None = 0,
        /// <summary>
        /// The PDMS operational root
        /// </summary>
        [Description("The PDMS operational root")]
        PDR = 1,
        /// <summary>
        /// The DFR navigation root
        /// </summary>
        [Description("The DFR navigation root")]
        DFR = 2,
        /// <summary>
        /// The DFA navigation root
        /// </summary>
        [Description("The DFA navigation root")]
        DFA = 3,
        /// <summary>
        /// A share rooted at a VHD mount
        /// </summary>
        [Description("A share rooted at a VHD mount")]
        VHD = 4,
        /// <summary>
        /// Sql XEvent log files
        /// </summary>
        [Description("Sql XEvent log files")]
        XEV = 5,
        /// <summary>
        /// Default Sql database backup Folder
        /// </summary>
        [Description("Default Sql database backup Folder")]
        BAK = 6,
        /// <summary>
        /// Default Sql database data Folder
        /// </summary>
        [Description("Default Sql database data Folder")]
        DAT = 7,
        /// <summary>
        /// Default Sql database log Folder
        /// </summary>
        [Description("Default Sql database log Folder")]
        LOG = 8,
        /// <summary>
        /// Default Application log Folder
        /// </summary>
        [Description("Default Application log Folder")]
        APL = 9,
        /// <summary>
        /// File table root
        /// </summary>
        [Description("File table root")]
        FTR = 10
    }

    public enum PlatformSystemKind : byte
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        [Description("Unspecified")]
        None = 0,
        /// <summary>
        /// System Core
        /// </summary>
        [Description("System Core")]
        PF = 1,
        /// <summary>
        /// Workflow Services
        /// </summary>
        [Description("Workflow Services")]
        WF = 40,
        /// <summary>
        /// Dataset Services
        /// </summary>
        [Description("Dataset Services")]
        DS = 50,
        /// <summary>
        /// Data File System
        /// </summary>
        [Description("Data File System")]
        DF = 70,
        /// <summary>
        /// Metadata Catalog System
        /// </summary>
        [Description("Metadata Catalog System")]
        ML = 100,
        /// <summary>
        /// Query Distribution System
        /// </summary>
        [Description("Query Distribution System")]
        QD = 110,
        /// <summary>
        /// Query Flow System
        /// </summary>
        [Description("Query Flow System")]
        QF = 120,
        /// <summary>
        /// Agent Control
        /// </summary>
        [Description("Agent Control")]
        AG = 150
    }

    public enum EnterpriseDatabaseKind : int
    {
    }

    public enum MessageClassKind : byte
    {
        /// <summary>
        /// Indicates that no classificaiton has been assigned
        /// </summary>
        [Description("Indicates that no classificaiton has been assigned")]
        None = 0,
        /// <summary>
        /// A declarative specification of a task that needs to be carried out
        /// </summary>
        [Description("A declarative specification of a task that needs to be carried out")]
        Command = 1,
        /// <summary>
        /// A description of something of interest that occurred within the system
        /// </summary>
        [Description("A description of something of interest that occurred within the system")]
        Event = 2,
        /// <summary>
        /// An event coupled with a formatted message intended for display or historization
        /// </summary>
        [Description("An event coupled with a formatted message intended for display or historization")]
        Notification = 3
    }
}
//This file was generated at 7/9/2018 7:22:00 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class T0TableTypeNames
    {
        public const string ArtifactReferenceSpec = "[T0].[ArtifactReferenceSpec]";
        public const string Classifier = "[T0].[Classifier]";
        public const string DacDeploymentToken = "[T0].[DacDeploymentToken]";
        public const string DacProfileDefinition = "[T0].[DacProfileDefinition]";
        public const string DatabaseServer = "[T0].[DatabaseServer]";
        public const string DatabaseVersion = "[T0].[DatabaseVersion]";
        public const string DistributionDescription = "[T0].[DistributionDescription]";
        public const string FileReceipt = "[T0].[FileReceipt]";
        public const string FileStreamIdentifier = "[T0].[FileStreamIdentifier]";
        public const string HostFileInfo = "[T0].[HostFileInfo]";
        public const string LargeTypeTableRow = "[T0].[LargeTypeTableRow]";
        public const string MediumTypeTableRow = "[T0].[MediumTypeTableRow]";
        public const string MessageAttribute = "[T0].[MessageAttribute]";
        public const string MessageFormat = "[T0].[MessageFormat]";
        public const string MessageTypeRegistration = "[T0].[MessageTypeRegistration]";
        public const string MonitoredTable = "[T0].[MonitoredTable]";
        public const string NavigationFolder = "[T0].[NavigationFolder]";
        public const string PlatformAgent = "[T0].[PlatformAgent]";
        public const string PlatformComponent = "[T0].[PlatformComponent]";
        public const string PlatformDacRegistration = "[T0].[PlatformDacRegistration]";
        public const string PlatformDatabase = "[T0].[PlatformDatabase]";
        public const string PlatformDatabaseProfile = "[T0].[PlatformDatabaseProfile]";
        public const string PlatformEntity = "[T0].[PlatformEntity]";
        public const string PlatformNode = "[T0].[PlatformNode]";
        public const string PlatformProject = "[T0].[PlatformProject]";
        public const string PlatformSolution = "[T0].[PlatformSolution]";
        public const string PlatformStoreChange = "[T0].[PlatformStoreChange]";
        public const string PlatformSystem = "[T0].[PlatformSystem]";
        public const string PlatformVariable = "[T0].[PlatformVariable]";
        public const string ProjectComponent = "[T0].[ProjectComponent]";
        public const string QueueRecord = "[T0].[QueueRecord]";
        public const string SqlMessageSpec = "[T0].[SqlMessageSpec]";
        public const string SqlProxyDefinition = "[T0].[SqlProxyDefinition]";
        public const string SystemArtifact = "[T0].[SystemArtifact]";
        public const string SystemCommandRegistration = "[T0].[SystemCommandRegistration]";
        public const string SystemComponent = "[T0].[SystemComponent]";
        public const string SystemEventRegistration = "[T0].[SystemEventRegistration]";
        public const string SystemSetting = "[T0].[SystemSetting]";
        public const string TableMonitorLogEntry = "[T0].[TableMonitorLogEntry]";
        public const string TargetedDatabaseComponent = "[T0].[TargetedDatabaseComponent]";
        public const string TinyTypeTableRow = "[T0].[TinyTypeTableRow]";
        public const string TypedDataFlowDescriptor = "[T0].[TypedDataFlowDescriptor]";
        public const string TypedDataFlowIdentifier = "[T0].[TypedDataFlowIdentifier]";
    }

    [SqlRecord("T0", "ArtifactReferenceSpec")]
    public partial class ArtifactReferenceSpec : SqlTableTypeProxy<ArtifactReferenceSpec>, IArtifactReferenceSpec
    {
        [SqlColumn("SpecFileName", 0), SqlTypeFacets("nvarchar", false)]
        public string SpecFileName
        {
            get;
            set;
        }

        [SqlColumn("SpecLabel", 1), SqlTypeFacets("nvarchar", false)]
        public string SpecLabel
        {
            get;
            set;
        }

        [SqlColumn("AreaName", 2), SqlTypeFacets("nvarchar", false)]
        public string AreaName
        {
            get;
            set;
        }

        [SqlColumn("SectionName", 3), SqlTypeFacets("nvarchar", false)]
        public string SectionName
        {
            get;
            set;
        }

        [SqlColumn("ReferenceType", 4), SqlTypeFacets("nvarchar", false)]
        public string ReferenceType
        {
            get;
            set;
        }

        [SqlColumn("SpecContent", 5), SqlTypeFacets("nvarchar", false)]
        public string SpecContent
        {
            get;
            set;
        }

        public ArtifactReferenceSpec()
        {
        }

        public ArtifactReferenceSpec(object[] items)
        {
            SpecFileName = (string)items[0];
            SpecLabel = (string)items[1];
            AreaName = (string)items[2];
            SectionName = (string)items[3];
            ReferenceType = (string)items[4];
            SpecContent = (string)items[5];
        }

        public ArtifactReferenceSpec(string SpecFileName, string SpecLabel, string AreaName, string SectionName, string ReferenceType, string SpecContent)
        {
            this.SpecFileName = SpecFileName;
            this.SpecLabel = SpecLabel;
            this.AreaName = AreaName;
            this.SectionName = SectionName;
            this.ReferenceType = ReferenceType;
            this.SpecContent = SpecContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SpecFileName, SpecLabel, AreaName, SectionName, ReferenceType, SpecContent };
        }

        public override void SetItemArray(object[] items)
        {
            SpecFileName = (string)items[0];
            SpecLabel = (string)items[1];
            AreaName = (string)items[2];
            SectionName = (string)items[3];
            ReferenceType = (string)items[4];
            SpecContent = (string)items[5];
        }
    }

    [SqlRecord("T0", "Classifier")]
    public partial class Classifier : SqlTableTypeProxy<Classifier>, IClassifier
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

        public Classifier()
        {
        }

        public Classifier(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
        }

        public Classifier(int TypeCode, string Identifier)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
        }
    }

    [SqlRecord("T0", "DacDeploymentToken")]
    public partial class DacDeploymentToken : SqlTableTypeProxy<DacDeploymentToken>, IDacDeploymentToken
    {
        [SqlColumn("DeploymentId", 0), SqlTypeFacets("int", false)]
        public int DeploymentId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 1), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public DacDeploymentToken()
        {
        }

        public DacDeploymentToken(object[] items)
        {
            DeploymentId = (int)items[0];
            CorrelationToken = (string)items[1];
        }

        public DacDeploymentToken(int DeploymentId, string CorrelationToken)
        {
            this.DeploymentId = DeploymentId;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DeploymentId, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            DeploymentId = (int)items[0];
            CorrelationToken = (string)items[1];
        }
    }

    [SqlRecord("T0", "DatabaseServer")]
    public partial class DatabaseServer : SqlTableTypeProxy<DatabaseServer>, IDatabaseServer
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

        [SqlColumn("SqlAlias", 2), SqlTypeFacets("nvarchar", true)]
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

        [SqlColumn("HostIP", 6), SqlTypeFacets("nvarchar", true)]
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

        [SqlColumn("DefaultLogDir", 11), SqlTypeFacets("nvarchar", true)]
        public string DefaultLogDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultBackupDir", 12), SqlTypeFacets("nvarchar", true)]
        public string DefaultBackupDir
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

        public DatabaseServer()
        {
        }

        public DatabaseServer(object[] items)
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
            DefaultLogDir = (string)items[11];
            DefaultBackupDir = (string)items[12];
            AdminLogDir = (string)items[13];
            SqlOperatorName = (string)items[14];
            SqlOperatorPass = (string)items[15];
            WinOperatorName = (string)items[16];
            WinOperatorPass = (string)items[17];
        }

        public DatabaseServer(string HostId, string SqlNodeId, string SqlAlias, string NodeName, string HostName, string HostNetworkName, string HostIP, string SqlInstanceName, int? SqlInstancePort, string FileStreamRoot, string DefaultDataDir, string DefaultLogDir, string DefaultBackupDir, string AdminLogDir, string SqlOperatorName, string SqlOperatorPass, string WinOperatorName, string WinOperatorPass)
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
            this.DefaultLogDir = DefaultLogDir;
            this.DefaultBackupDir = DefaultBackupDir;
            this.AdminLogDir = AdminLogDir;
            this.SqlOperatorName = SqlOperatorName;
            this.SqlOperatorPass = SqlOperatorPass;
            this.WinOperatorName = WinOperatorName;
            this.WinOperatorPass = WinOperatorPass;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, SqlNodeId, SqlAlias, NodeName, HostName, HostNetworkName, HostIP, SqlInstanceName, SqlInstancePort, FileStreamRoot, DefaultDataDir, DefaultLogDir, DefaultBackupDir, AdminLogDir, SqlOperatorName, SqlOperatorPass, WinOperatorName, WinOperatorPass };
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
            DefaultLogDir = (string)items[11];
            DefaultBackupDir = (string)items[12];
            AdminLogDir = (string)items[13];
            SqlOperatorName = (string)items[14];
            SqlOperatorPass = (string)items[15];
            WinOperatorName = (string)items[16];
            WinOperatorPass = (string)items[17];
        }
    }

    [SqlRecord("T0", "DatabaseVersion")]
    public partial class DatabaseVersion : SqlTableTypeProxy<DatabaseVersion>, IDatabaseVersion
    {
        [SqlColumn("DatabaseName", 0), SqlTypeFacets("nvarchar", false)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("MajorVersion", 1), SqlTypeFacets("int", false)]
        public int MajorVersion
        {
            get;
            set;
        }

        [SqlColumn("MinorVersion", 2), SqlTypeFacets("int", false)]
        public int MinorVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildVersion", 3), SqlTypeFacets("int", false)]
        public int BuildVersion
        {
            get;
            set;
        }

        [SqlColumn("RevisionVersion", 4), SqlTypeFacets("int", false)]
        public int RevisionVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildTS", 5), SqlTypeFacets("datetime2", false)]
        public DateTime BuildTS
        {
            get;
            set;
        }

        public DatabaseVersion()
        {
        }

        public DatabaseVersion(object[] items)
        {
            DatabaseName = (string)items[0];
            MajorVersion = (int)items[1];
            MinorVersion = (int)items[2];
            BuildVersion = (int)items[3];
            RevisionVersion = (int)items[4];
            BuildTS = (DateTime)items[5];
        }

        public DatabaseVersion(string DatabaseName, int MajorVersion, int MinorVersion, int BuildVersion, int RevisionVersion, DateTime BuildTS)
        {
            this.DatabaseName = DatabaseName;
            this.MajorVersion = MajorVersion;
            this.MinorVersion = MinorVersion;
            this.BuildVersion = BuildVersion;
            this.RevisionVersion = RevisionVersion;
            this.BuildTS = BuildTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DatabaseName, MajorVersion, MinorVersion, BuildVersion, RevisionVersion, BuildTS };
        }

        public override void SetItemArray(object[] items)
        {
            DatabaseName = (string)items[0];
            MajorVersion = (int)items[1];
            MinorVersion = (int)items[2];
            BuildVersion = (int)items[3];
            RevisionVersion = (int)items[4];
            BuildTS = (DateTime)items[5];
        }
    }

    [SqlRecord("T0", "DistributionDescription")]
    public partial class DistributionDescription : SqlTableTypeProxy<DistributionDescription>, IDistributionDescription
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

        public DistributionDescription()
        {
        }

        public DistributionDescription(object[] items)
        {
            DistributionId = (string)items[0];
            Description = (string)items[1];
        }

        public DistributionDescription(string DistributionId, string Description)
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

    [SqlRecord("T0", "FileReceipt")]
    public partial class FileReceipt : SqlTableTypeProxy<FileReceipt>, IFileReceipt
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("FileId", 1), SqlTypeFacets("uniqueidentifier", false)]
        public Guid FileId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 2), SqlTypeFacets("nvarchar", false)]
        public string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileType", 3), SqlTypeFacets("nvarchar", false)]
        public string FileType
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 4), SqlTypeFacets("nvarchar", false)]
        public string ReceiptPath
        {
            get;
            set;
        }

        [SqlColumn("WrittenTS", 5), SqlTypeFacets("datetime2", false)]
        public DateTime WrittenTS
        {
            get;
            set;
        }

        [SqlColumn("ReceiptTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime ReceiptTS
        {
            get;
            set;
        }

        public FileReceipt()
        {
        }

        public FileReceipt(object[] items)
        {
            HostId = (string)items[0];
            FileId = (Guid)items[1];
            FileName = (string)items[2];
            FileType = (string)items[3];
            ReceiptPath = (string)items[4];
            WrittenTS = (DateTime)items[5];
            ReceiptTS = (DateTime)items[6];
        }

        public FileReceipt(string HostId, Guid FileId, string FileName, string FileType, string ReceiptPath, DateTime WrittenTS, DateTime ReceiptTS)
        {
            this.HostId = HostId;
            this.FileId = FileId;
            this.FileName = FileName;
            this.FileType = FileType;
            this.ReceiptPath = ReceiptPath;
            this.WrittenTS = WrittenTS;
            this.ReceiptTS = ReceiptTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, FileId, FileName, FileType, ReceiptPath, WrittenTS, ReceiptTS };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            FileId = (Guid)items[1];
            FileName = (string)items[2];
            FileType = (string)items[3];
            ReceiptPath = (string)items[4];
            WrittenTS = (DateTime)items[5];
            ReceiptTS = (DateTime)items[6];
        }
    }

    [SqlRecord("T0", "FileStreamIdentifier")]
    public partial class FileStreamIdentifier : SqlTableTypeProxy<FileStreamIdentifier>, IFileStreamIdentifier
    {
        [SqlColumn("row_id", 0), SqlTypeFacets("int", false)]
        public int row_id
        {
            get;
            set;
        }

        [SqlColumn("stream_id", 1), SqlTypeFacets("uniqueidentifier", false)]
        public Guid stream_id
        {
            get;
            set;
        }

        public FileStreamIdentifier()
        {
        }

        public FileStreamIdentifier(object[] items)
        {
            row_id = (int)items[0];
            stream_id = (Guid)items[1];
        }

        public FileStreamIdentifier(int row_id, Guid stream_id)
        {
            this.row_id = row_id;
            this.stream_id = stream_id;
        }

        public override object[] GetItemArray()
        {
            return new object[] { row_id, stream_id };
        }

        public override void SetItemArray(object[] items)
        {
            row_id = (int)items[0];
            stream_id = (Guid)items[1];
        }
    }

    [SqlRecord("T0", "HostFileInfo")]
    public partial class HostFileInfo : SqlTableTypeProxy<HostFileInfo>, IHostFileInfo
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("FilePath", 1), SqlTypeFacets("nvarchar", false)]
        public string FilePath
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 2), SqlTypeFacets("datetime2", false)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime UpdateTS
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 4), SqlTypeFacets("bigint", false)]
        public long FileSize
        {
            get;
            set;
        }

        [SqlColumn("FileSizeMB", 5), SqlTypeFacets("decimal", false)]
        public decimal FileSizeMB
        {
            get;
            set;
        }

        [SqlColumn("FileSizeGB", 6), SqlTypeFacets("decimal", false)]
        public decimal FileSizeGB
        {
            get;
            set;
        }

        public HostFileInfo()
        {
        }

        public HostFileInfo(object[] items)
        {
            HostId = (string)items[0];
            FilePath = (string)items[1];
            CreateTS = (DateTime)items[2];
            UpdateTS = (DateTime)items[3];
            FileSize = (long)items[4];
            FileSizeMB = (decimal)items[5];
            FileSizeGB = (decimal)items[6];
        }

        public HostFileInfo(string HostId, string FilePath, DateTime CreateTS, DateTime UpdateTS, long FileSize, decimal FileSizeMB, decimal FileSizeGB)
        {
            this.HostId = HostId;
            this.FilePath = FilePath;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
            this.FileSize = FileSize;
            this.FileSizeMB = FileSizeMB;
            this.FileSizeGB = FileSizeGB;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, FilePath, CreateTS, UpdateTS, FileSize, FileSizeMB, FileSizeGB };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            FilePath = (string)items[1];
            CreateTS = (DateTime)items[2];
            UpdateTS = (DateTime)items[3];
            FileSize = (long)items[4];
            FileSizeMB = (decimal)items[5];
            FileSizeGB = (decimal)items[6];
        }
    }

    [SqlRecord("T0", "LargeTypeTableRow")]
    public partial class LargeTypeTableRow : SqlTableTypeProxy<LargeTypeTableRow>, ILargeTypeTableRow
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

        public LargeTypeTableRow()
        {
        }

        public LargeTypeTableRow(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public LargeTypeTableRow(int TypeCode, string Identifier, string Label, string Description)
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

    [SqlRecord("T0", "MediumTypeTableRow")]
    public partial class MediumTypeTableRow : SqlTableTypeProxy<MediumTypeTableRow>, IMediumTypeTableRow
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("smallint", false)]
        public short TypeCode
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

        public MediumTypeTableRow()
        {
        }

        public MediumTypeTableRow(object[] items)
        {
            TypeCode = (short)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public MediumTypeTableRow(short TypeCode, string Identifier, string Label, string Description)
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
            TypeCode = (short)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlRecord("T0", "MessageAttribute")]
    public partial class MessageAttribute : SqlTableTypeProxy<MessageAttribute>, IMessageAttribute
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
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

        [SqlColumn("ColumnName", 3), SqlTypeFacets("nvarchar", false)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 4), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 5), SqlTypeFacets("nvarchar", false)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 6), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("Length", 7), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 8), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 9), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("Description", 10), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public MessageAttribute()
        {
        }

        public MessageAttribute(object[] items)
        {
            SystemId = (string)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            ColumnName = (string)items[3];
            ColumnPosition = (int)items[4];
            DataTypeName = (string)items[5];
            IsNullable = (bool)items[6];
            Length = (int?)items[7];
            Precision = (byte?)items[8];
            Scale = (byte?)items[9];
            Description = (string)items[10];
        }

        public MessageAttribute(string SystemId, string SchemaName, string TypeName, string ColumnName, int ColumnPosition, string DataTypeName, bool IsNullable, int? Length, byte? Precision, byte? Scale, string Description)
        {
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
            return new object[] { SystemId, SchemaName, TypeName, ColumnName, ColumnPosition, DataTypeName, IsNullable, Length, Precision, Scale, Description };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            ColumnName = (string)items[3];
            ColumnPosition = (int)items[4];
            DataTypeName = (string)items[5];
            IsNullable = (bool)items[6];
            Length = (int?)items[7];
            Precision = (byte?)items[8];
            Scale = (byte?)items[9];
            Description = (string)items[10];
        }
    }

    [SqlRecord("T0", "MessageFormat")]
    public partial class MessageFormat : SqlTableTypeProxy<MessageFormat>, IMessageFormat
    {
        [SqlColumn("SchemaName", 0), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 1), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("FormatTemplate", 2), SqlTypeFacets("nvarchar", false)]
        public string FormatTemplate
        {
            get;
            set;
        }

        [SqlColumn("P1", 3), SqlTypeFacets("nvarchar", true)]
        public string P1
        {
            get;
            set;
        }

        [SqlColumn("P2", 4), SqlTypeFacets("nvarchar", true)]
        public string P2
        {
            get;
            set;
        }

        [SqlColumn("P3", 5), SqlTypeFacets("nvarchar", true)]
        public string P3
        {
            get;
            set;
        }

        [SqlColumn("P4", 6), SqlTypeFacets("nvarchar", true)]
        public string P4
        {
            get;
            set;
        }

        [SqlColumn("P5", 7), SqlTypeFacets("nvarchar", true)]
        public string P5
        {
            get;
            set;
        }

        [SqlColumn("P6", 8), SqlTypeFacets("nvarchar", true)]
        public string P6
        {
            get;
            set;
        }

        [SqlColumn("P7", 9), SqlTypeFacets("nvarchar", true)]
        public string P7
        {
            get;
            set;
        }

        [SqlColumn("P8", 10), SqlTypeFacets("nvarchar", true)]
        public string P8
        {
            get;
            set;
        }

        [SqlColumn("P9", 11), SqlTypeFacets("nvarchar", true)]
        public string P9
        {
            get;
            set;
        }

        public MessageFormat()
        {
        }

        public MessageFormat(object[] items)
        {
            SchemaName = (string)items[0];
            TypeName = (string)items[1];
            FormatTemplate = (string)items[2];
            P1 = (string)items[3];
            P2 = (string)items[4];
            P3 = (string)items[5];
            P4 = (string)items[6];
            P5 = (string)items[7];
            P6 = (string)items[8];
            P7 = (string)items[9];
            P8 = (string)items[10];
            P9 = (string)items[11];
        }

        public MessageFormat(string SchemaName, string TypeName, string FormatTemplate, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
        {
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
            return new object[] { SchemaName, TypeName, FormatTemplate, P1, P2, P3, P4, P5, P6, P7, P8, P9 };
        }

        public override void SetItemArray(object[] items)
        {
            SchemaName = (string)items[0];
            TypeName = (string)items[1];
            FormatTemplate = (string)items[2];
            P1 = (string)items[3];
            P2 = (string)items[4];
            P3 = (string)items[5];
            P4 = (string)items[6];
            P5 = (string)items[7];
            P6 = (string)items[8];
            P7 = (string)items[9];
            P8 = (string)items[10];
            P9 = (string)items[11];
        }
    }

    [SqlRecord("T0", "MessageTypeRegistration")]
    public partial class MessageTypeRegistration : SqlTableTypeProxy<MessageTypeRegistration>, IMessageTypeRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
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

        [SqlColumn("MessageClass", 3), SqlTypeFacets("nvarchar", false)]
        public string MessageClass
        {
            get;
            set;
        }

        [SqlColumn("Description", 4), SqlTypeFacets("nvarchar", true)]
        public string Description
        {
            get;
            set;
        }

        public MessageTypeRegistration()
        {
        }

        public MessageTypeRegistration(object[] items)
        {
            SystemId = (string)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            MessageClass = (string)items[3];
            Description = (string)items[4];
        }

        public MessageTypeRegistration(string SystemId, string SchemaName, string TypeName, string MessageClass, string Description)
        {
            this.SystemId = SystemId;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.MessageClass = MessageClass;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, SchemaName, TypeName, MessageClass, Description };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            SchemaName = (string)items[1];
            TypeName = (string)items[2];
            MessageClass = (string)items[3];
            Description = (string)items[4];
        }
    }

    [SqlRecord("T0", "MonitoredTable")]
    public partial class MonitoredTable : SqlTableTypeProxy<MonitoredTable>, IMonitoredTable
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
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

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("MonitorEnabled", 4), SqlTypeFacets("bit", false)]
        public bool MonitorEnabled
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

        public MonitoredTable()
        {
        }

        public MonitoredTable(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            MonitorEnabled = (bool)items[4];
            MonitorFrequency = (int)items[5];
        }

        public MonitoredTable(string HostId, string DatabaseName, string SchemaName, string TableName, bool MonitorEnabled, int MonitorFrequency)
        {
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.MonitorEnabled = MonitorEnabled;
            this.MonitorFrequency = MonitorFrequency;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, DatabaseName, SchemaName, TableName, MonitorEnabled, MonitorFrequency };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            MonitorEnabled = (bool)items[4];
            MonitorFrequency = (int)items[5];
        }
    }

    [SqlRecord("T0", "NavigationFolder")]
    public partial class NavigationFolder : SqlTableTypeProxy<NavigationFolder>, INavigationFolder
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

        public NavigationFolder()
        {
        }

        public NavigationFolder(object[] items)
        {
            FolderIdentifier = (string)items[0];
            NavigatorType = (string)items[1];
            FolderName = (string)items[2];
        }

        public NavigationFolder(string FolderIdentifier, string NavigatorType, string FolderName)
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

    [SqlRecord("T0", "PlatformAgent")]
    public partial class PlatformAgent : SqlTableTypeProxy<PlatformAgent>, IPlatformAgent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 1), SqlTypeFacets("nvarchar", false)]
        public string AgentId
        {
            get;
            set;
        }

        public PlatformAgent()
        {
        }

        public PlatformAgent(object[] items)
        {
            SystemId = (string)items[0];
            AgentId = (string)items[1];
        }

        public PlatformAgent(string SystemId, string AgentId)
        {
            this.SystemId = SystemId;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    [SqlRecord("T0", "PlatformComponent")]
    public partial class PlatformComponent : SqlTableTypeProxy<PlatformComponent>, IPlatformComponent
    {
        [SqlColumn("ComponentId", 0), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
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

        [SqlColumn("ClassifierId", 2), SqlTypeFacets("nvarchar", false)]
        public string ClassifierId
        {
            get;
            set;
        }

        public PlatformComponent()
        {
        }

        public PlatformComponent(object[] items)
        {
            ComponentId = (string)items[0];
            SystemId = (string)items[1];
            ClassifierId = (string)items[2];
        }

        public PlatformComponent(string ComponentId, string SystemId, string ClassifierId)
        {
            this.ComponentId = ComponentId;
            this.SystemId = SystemId;
            this.ClassifierId = ClassifierId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ComponentId, SystemId, ClassifierId };
        }

        public override void SetItemArray(object[] items)
        {
            ComponentId = (string)items[0];
            SystemId = (string)items[1];
            ClassifierId = (string)items[2];
        }
    }

    [SqlRecord("T0", "DacProfileDefinition")]
    public partial class DacProfileDefinition : SqlTableTypeProxy<DacProfileDefinition>, IDacProfileDefinition
    {
        [SqlColumn("ProfileFileName", 0), SqlTypeFacets("nvarchar", false)]
        public string ProfileFileName
        {
            get;
            set;
        }

        [SqlColumn("SourcePackage", 1), SqlTypeFacets("nvarchar", false)]
        public string SourcePackage
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 4), SqlTypeFacets("nvarchar", false)]
        public string ProfileXml
        {
            get;
            set;
        }

        [SqlColumn("ProfileSourcePath", 5), SqlTypeFacets("nvarchar", true)]
        public string ProfileSourcePath
        {
            get;
            set;
        }

        public DacProfileDefinition()
        {
        }

        public DacProfileDefinition(object[] items)
        {
            ProfileFileName = (string)items[0];
            SourcePackage = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetDatabase = (string)items[3];
            ProfileXml = (string)items[4];
            ProfileSourcePath = (string)items[5];
        }

        public DacProfileDefinition(string ProfileFileName, string SourcePackage, string TargetNodeId, string TargetDatabase, string ProfileXml, string ProfileSourcePath)
        {
            this.ProfileFileName = ProfileFileName;
            this.SourcePackage = SourcePackage;
            this.TargetNodeId = TargetNodeId;
            this.TargetDatabase = TargetDatabase;
            this.ProfileXml = ProfileXml;
            this.ProfileSourcePath = ProfileSourcePath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ProfileFileName, SourcePackage, TargetNodeId, TargetDatabase, ProfileXml, ProfileSourcePath };
        }

        public override void SetItemArray(object[] items)
        {
            ProfileFileName = (string)items[0];
            SourcePackage = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetDatabase = (string)items[3];
            ProfileXml = (string)items[4];
            ProfileSourcePath = (string)items[5];
        }
    }

    [SqlRecord("T0", "PlatformDacRegistration")]
    public partial class PlatformDacRegistration : SqlTableTypeProxy<PlatformDacRegistration>, IPlatformDacRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("PackageName", 1), SqlTypeFacets("nvarchar", false)]
        public string PackageName
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        public PlatformDacRegistration()
        {
        }

        public PlatformDacRegistration(object[] items)
        {
            SystemId = (string)items[0];
            PackageName = (string)items[1];
            ComponentId = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
        }

        public PlatformDacRegistration(string SystemId, string PackageName, string ComponentId, string ComponentVersion, DateTime ComponentTS)
        {
            this.SystemId = SystemId;
            this.PackageName = PackageName;
            this.ComponentId = ComponentId;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, PackageName, ComponentId, ComponentVersion, ComponentTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            PackageName = (string)items[1];
            ComponentId = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
        }
    }

    [SqlRecord("T0", "PlatformDatabase")]
    public partial class PlatformDatabase : SqlTableTypeProxy<PlatformDatabase>, IPlatformDatabase
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

        public PlatformDatabase()
        {
        }

        public PlatformDatabase(object[] items)
        {
            ServerId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
            IsPrimary = (bool)items[3];
            IsEnabled = (bool)items[4];
            IsModel = (bool)items[5];
            IsRestore = (bool)items[6];
        }

        public PlatformDatabase(string ServerId, string DatabaseName, string DatabaseType, bool IsPrimary, bool IsEnabled, bool IsModel, bool IsRestore)
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

    [SqlRecord("T0", "PlatformDatabaseProfile")]
    public partial class PlatformDatabaseProfile : SqlTableTypeProxy<PlatformDatabaseProfile>, IPlatformDatabaseProfile
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

        [SqlColumn("ProfilePath", 3), SqlTypeFacets("nvarchar", true)]
        public string ProfilePath
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 4), SqlTypeFacets("nvarchar", true)]
        public string ProfileXml
        {
            get;
            set;
        }

        public PlatformDatabaseProfile()
        {
        }

        public PlatformDatabaseProfile(object[] items)
        {
            ServerId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
            ProfilePath = (string)items[3];
            ProfileXml = (string)items[4];
        }

        public PlatformDatabaseProfile(string ServerId, string DatabaseName, string DatabaseType, string ProfilePath, string ProfileXml)
        {
            this.ServerId = ServerId;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.ProfilePath = ProfilePath;
            this.ProfileXml = ProfileXml;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerId, DatabaseName, DatabaseType, ProfilePath, ProfileXml };
        }

        public override void SetItemArray(object[] items)
        {
            ServerId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
            ProfilePath = (string)items[3];
            ProfileXml = (string)items[4];
        }
    }

    [SqlRecord("T0", "PlatformEntity")]
    public partial class PlatformEntity : SqlTableTypeProxy<PlatformEntity>, IPlatformEntity
    {
        [SqlColumn("EntityName", 0), SqlTypeFacets("nvarchar", false)]
        public string EntityName
        {
            get;
            set;
        }

        [SqlColumn("TypeUri", 1), SqlTypeFacets("nvarchar", false)]
        public string TypeUri
        {
            get;
            set;
        }

        [SqlColumn("Body", 2), SqlTypeFacets("nvarchar", false)]
        public string Body
        {
            get;
            set;
        }

        public PlatformEntity()
        {
        }

        public PlatformEntity(object[] items)
        {
            EntityName = (string)items[0];
            TypeUri = (string)items[1];
            Body = (string)items[2];
        }

        public PlatformEntity(string EntityName, string TypeUri, string Body)
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

    [SqlRecord("T0", "PlatformNode")]
    public partial class PlatformNode : SqlTableTypeProxy<PlatformNode>, IPlatformNode
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

        [SqlColumn("NetworkName", 4), SqlTypeFacets("varchar", true)]
        public string NetworkName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorName", 5), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorPass", 6), SqlTypeFacets("nvarchar", true)]
        public string WinOperatorPass
        {
            get;
            set;
        }

        public PlatformNode()
        {
        }

        public PlatformNode(object[] items)
        {
            NodeId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
            NetworkName = (string)items[4];
            WinOperatorName = (string)items[5];
            WinOperatorPass = (string)items[6];
        }

        public PlatformNode(string NodeId, string NodeName, string HostName, string HostIP, string NetworkName, string WinOperatorName, string WinOperatorPass)
        {
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
            return new object[] { NodeId, NodeName, HostName, HostIP, NetworkName, WinOperatorName, WinOperatorPass };
        }

        public override void SetItemArray(object[] items)
        {
            NodeId = (string)items[0];
            NodeName = (string)items[1];
            HostName = (string)items[2];
            HostIP = (string)items[3];
            NetworkName = (string)items[4];
            WinOperatorName = (string)items[5];
            WinOperatorPass = (string)items[6];
        }
    }

    [SqlRecord("T0", "PlatformProject")]
    public partial class PlatformProject : SqlTableTypeProxy<PlatformProject>, IPlatformProject
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 1), SqlTypeFacets("nvarchar", false)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("ProjectId", 2), SqlTypeFacets("nvarchar", false)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 3), SqlTypeFacets("nvarchar", false)]
        public string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 4), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("IsSqlProject", 5), SqlTypeFacets("bit", false)]
        public bool IsSqlProject
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 6), SqlTypeFacets("nvarchar", true)]
        public string TargetDatabase
        {
            get;
            set;
        }

        public PlatformProject()
        {
        }

        public PlatformProject(object[] items)
        {
            SystemId = (string)items[0];
            SolutionId = (string)items[1];
            ProjectId = (string)items[2];
            ProjectName = (string)items[3];
            TargetAssembly = (string)items[4];
            IsSqlProject = (bool)items[5];
            TargetDatabase = (string)items[6];
        }

        public PlatformProject(string SystemId, string SolutionId, string ProjectId, string ProjectName, string TargetAssembly, bool IsSqlProject, string TargetDatabase)
        {
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
            return new object[] { SystemId, SolutionId, ProjectId, ProjectName, TargetAssembly, IsSqlProject, TargetDatabase };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            SolutionId = (string)items[1];
            ProjectId = (string)items[2];
            ProjectName = (string)items[3];
            TargetAssembly = (string)items[4];
            IsSqlProject = (bool)items[5];
            TargetDatabase = (string)items[6];
        }
    }

    [SqlRecord("T0", "PlatformSolution")]
    public partial class PlatformSolution : SqlTableTypeProxy<PlatformSolution>, IPlatformSolution
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 1), SqlTypeFacets("nvarchar", false)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("SolutionName", 2), SqlTypeFacets("nvarchar", false)]
        public string SolutionName
        {
            get;
            set;
        }

        public PlatformSolution()
        {
        }

        public PlatformSolution(object[] items)
        {
            SystemId = (string)items[0];
            SolutionId = (string)items[1];
            SolutionName = (string)items[2];
        }

        public PlatformSolution(string SystemId, string SolutionId, string SolutionName)
        {
            this.SystemId = SystemId;
            this.SolutionId = SolutionId;
            this.SolutionName = SolutionName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, SolutionId, SolutionName };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            SolutionId = (string)items[1];
            SolutionName = (string)items[2];
        }
    }

    [SqlRecord("T0", "PlatformStoreChange")]
    public partial class PlatformStoreChange : SqlTableTypeProxy<PlatformStoreChange>, IPlatformStoreChange
    {
        [SqlColumn("StoreName", 0), SqlTypeFacets("nvarchar", false)]
        public string StoreName
        {
            get;
            set;
        }

        [SqlColumn("SystemKey", 1), SqlTypeFacets("bigint", false)]
        public long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ChangeType", 2), SqlTypeFacets("char", false)]
        public string ChangeType
        {
            get;
            set;
        }

        [SqlColumn("ChangeTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime ChangeTS
        {
            get;
            set;
        }

        public PlatformStoreChange()
        {
        }

        public PlatformStoreChange(object[] items)
        {
            StoreName = (string)items[0];
            SystemKey = (long)items[1];
            ChangeType = (string)items[2];
            ChangeTS = (DateTime)items[3];
        }

        public PlatformStoreChange(string StoreName, long SystemKey, string ChangeType, DateTime ChangeTS)
        {
            this.StoreName = StoreName;
            this.SystemKey = SystemKey;
            this.ChangeType = ChangeType;
            this.ChangeTS = ChangeTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StoreName, SystemKey, ChangeType, ChangeTS };
        }

        public override void SetItemArray(object[] items)
        {
            StoreName = (string)items[0];
            SystemKey = (long)items[1];
            ChangeType = (string)items[2];
            ChangeTS = (DateTime)items[3];
        }
    }

    [SqlRecord("T0", "PlatformSystem")]
    public partial class PlatformSystem : SqlTableTypeProxy<PlatformSystem>, IPlatformSystem
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

        public PlatformSystem()
        {
        }

        public PlatformSystem(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public PlatformSystem(byte TypeCode, string Identifier, string Label, string Description)
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

    [SqlRecord("T0", "PlatformVariable")]
    public partial class PlatformVariable : SqlTableTypeProxy<PlatformVariable>, IPlatformVariable
    {
        [SqlColumn("VariableName", 0), SqlTypeFacets("nvarchar", false)]
        public string VariableName
        {
            get;
            set;
        }

        [SqlColumn("VariableValue", 1), SqlTypeFacets("nvarchar", false)]
        public string VariableValue
        {
            get;
            set;
        }

        public PlatformVariable()
        {
        }

        public PlatformVariable(object[] items)
        {
            VariableName = (string)items[0];
            VariableValue = (string)items[1];
        }

        public PlatformVariable(string VariableName, string VariableValue)
        {
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { VariableName, VariableValue };
        }

        public override void SetItemArray(object[] items)
        {
            VariableName = (string)items[0];
            VariableValue = (string)items[1];
        }
    }

    [SqlRecord("T0", "ProjectComponent")]
    public partial class ProjectComponent : SqlTableTypeProxy<ProjectComponent>, IProjectComponent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 1), SqlTypeFacets("nvarchar", false)]
        public string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ComponentType", 4), SqlTypeFacets("nvarchar", false)]
        public string ComponentType
        {
            get;
            set;
        }

        [SqlColumn("IsSqlProject", 5), SqlTypeFacets("bit", false)]
        public bool IsSqlProject
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 6), SqlTypeFacets("nvarchar", true)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 7), SqlTypeFacets("nvarchar", true)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 8), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        public ProjectComponent()
        {
        }

        public ProjectComponent(object[] items)
        {
            SystemId = (string)items[0];
            ProjectName = (string)items[1];
            ComponentId = (string)items[2];
            TargetAssembly = (string)items[3];
            ComponentType = (string)items[4];
            IsSqlProject = (bool)items[5];
            TargetDatabase = (string)items[6];
            ComponentVersion = (string)items[7];
            ComponentTS = (DateTime)items[8];
        }

        public ProjectComponent(string SystemId, string ProjectName, string ComponentId, string TargetAssembly, string ComponentType, bool IsSqlProject, string TargetDatabase, string ComponentVersion, DateTime ComponentTS)
        {
            this.SystemId = SystemId;
            this.ProjectName = ProjectName;
            this.ComponentId = ComponentId;
            this.TargetAssembly = TargetAssembly;
            this.ComponentType = ComponentType;
            this.IsSqlProject = IsSqlProject;
            this.TargetDatabase = TargetDatabase;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, ProjectName, ComponentId, TargetAssembly, ComponentType, IsSqlProject, TargetDatabase, ComponentVersion, ComponentTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            ProjectName = (string)items[1];
            ComponentId = (string)items[2];
            TargetAssembly = (string)items[3];
            ComponentType = (string)items[4];
            IsSqlProject = (bool)items[5];
            TargetDatabase = (string)items[6];
            ComponentVersion = (string)items[7];
            ComponentTS = (DateTime)items[8];
        }
    }

    [SqlRecord("T0", "QueueRecord")]
    public partial class QueueRecord : SqlTableTypeProxy<QueueRecord>, IQueueRecord
    {
        [SqlColumn("ConversationId", 0), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? ConversationId
        {
            get;
            set;
        }

        [SqlColumn("MessageType", 1), SqlTypeFacets("sysname", true)]
        public string MessageType
        {
            get;
            set;
        }

        [SqlColumn("MessageBody", 2), SqlTypeFacets("varbinary", true)]
        public Byte[] MessageBody
        {
            get;
            set;
        }

        public QueueRecord()
        {
        }

        public QueueRecord(object[] items)
        {
            ConversationId = (Guid?)items[0];
            MessageType = (string)items[1];
            MessageBody = (Byte[])items[2];
        }

        public QueueRecord(Guid? ConversationId, string MessageType, Byte[] MessageBody)
        {
            this.ConversationId = ConversationId;
            this.MessageType = MessageType;
            this.MessageBody = MessageBody;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ConversationId, MessageType, MessageBody };
        }

        public override void SetItemArray(object[] items)
        {
            ConversationId = (Guid?)items[0];
            MessageType = (string)items[1];
            MessageBody = (Byte[])items[2];
        }
    }

    [SqlRecord("T0", "SqlMessageSpec")]
    public partial class SqlMessageSpec : SqlTableTypeProxy<SqlMessageSpec>, ISqlMessageSpec
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

        public SqlMessageSpec()
        {
        }

        public SqlMessageSpec(object[] items)
        {
            MessageNumber = (int)items[0];
            SystemId = (string)items[1];
            MessageName = (string)items[2];
            Severity = (int)items[3];
            FormatString = (string)items[4];
        }

        public SqlMessageSpec(int MessageNumber, string SystemId, string MessageName, int Severity, string FormatString)
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

    [SqlRecord("T0", "SqlProxyDefinition")]
    public partial class SqlProxyDefinition : SqlTableTypeProxy<SqlProxyDefinition>, ISqlProxyDefinition
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

        [SqlColumn("SourceNode", 3), SqlTypeFacets("nvarchar", false)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 4), SqlTypeFacets("nvarchar", true)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 5), SqlTypeFacets("nvarchar", true)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 6), SqlTypeFacets("nvarchar", false)]
        public string ProfileText
        {
            get;
            set;
        }

        public SqlProxyDefinition()
        {
        }

        public SqlProxyDefinition(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            SystemId = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }

        public SqlProxyDefinition(string AssemblyDesignator, string SystemId, string ProfileName, string SourceNode, string SourceDatabase, string TargetAssembly, string ProfileText)
        {
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
            return new object[] { AssemblyDesignator, SystemId, ProfileName, SourceNode, SourceDatabase, TargetAssembly, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            SystemId = (string)items[1];
            ProfileName = (string)items[2];
            SourceNode = (string)items[3];
            SourceDatabase = (string)items[4];
            TargetAssembly = (string)items[5];
            ProfileText = (string)items[6];
        }
    }

    [SqlRecord("T0", "SystemArtifact")]
    public partial class SystemArtifact : SqlTableTypeProxy<SystemArtifact>, ISystemArtifact
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ArtifactId", 1), SqlTypeFacets("nvarchar", false)]
        public string ArtifactId
        {
            get;
            set;
        }

        [SqlColumn("ArtifactType", 2), SqlTypeFacets("nvarchar", false)]
        public string ArtifactType
        {
            get;
            set;
        }

        public SystemArtifact()
        {
        }

        public SystemArtifact(object[] items)
        {
            SystemId = (string)items[0];
            ArtifactId = (string)items[1];
            ArtifactType = (string)items[2];
        }

        public SystemArtifact(string SystemId, string ArtifactId, string ArtifactType)
        {
            this.SystemId = SystemId;
            this.ArtifactId = ArtifactId;
            this.ArtifactType = ArtifactType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, ArtifactId, ArtifactType };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            ArtifactId = (string)items[1];
            ArtifactType = (string)items[2];
        }
    }

    [SqlRecord("T0", "SystemCommandRegistration")]
    public partial class SystemCommandRegistration : SqlTableTypeProxy<SystemCommandRegistration>, ISystemCommandRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 1), SqlTypeFacets("nvarchar", false)]
        public string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 2), SqlTypeFacets("nvarchar", true)]
        public string Purpose
        {
            get;
            set;
        }

        public SystemCommandRegistration()
        {
        }

        public SystemCommandRegistration(object[] items)
        {
            SystemId = (string)items[0];
            MessageName = (string)items[1];
            Purpose = (string)items[2];
        }

        public SystemCommandRegistration(string SystemId, string MessageName, string Purpose)
        {
            this.SystemId = SystemId;
            this.MessageName = MessageName;
            this.Purpose = Purpose;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, MessageName, Purpose };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            MessageName = (string)items[1];
            Purpose = (string)items[2];
        }
    }

    [SqlRecord("T0", "SystemComponent")]
    public partial class SystemComponent : SqlTableTypeProxy<SystemComponent>, ISystemComponent
    {
        [SqlColumn("ComponentId", 0), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
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

        [SqlColumn("ComponentType", 2), SqlTypeFacets("nvarchar", false)]
        public string ComponentType
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        public SystemComponent()
        {
        }

        public SystemComponent(object[] items)
        {
            ComponentId = (string)items[0];
            SystemId = (string)items[1];
            ComponentType = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
        }

        public SystemComponent(string ComponentId, string SystemId, string ComponentType, string ComponentVersion, DateTime ComponentTS)
        {
            this.ComponentId = ComponentId;
            this.SystemId = SystemId;
            this.ComponentType = ComponentType;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ComponentId, SystemId, ComponentType, ComponentVersion, ComponentTS };
        }

        public override void SetItemArray(object[] items)
        {
            ComponentId = (string)items[0];
            SystemId = (string)items[1];
            ComponentType = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
        }
    }

    [SqlRecord("T0", "SystemEventRegistration")]
    public partial class SystemEventRegistration : SqlTableTypeProxy<SystemEventRegistration>, ISystemEventRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 1), SqlTypeFacets("nvarchar", false)]
        public string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 2), SqlTypeFacets("nvarchar", true)]
        public string Purpose
        {
            get;
            set;
        }

        public SystemEventRegistration()
        {
        }

        public SystemEventRegistration(object[] items)
        {
            SystemId = (string)items[0];
            MessageName = (string)items[1];
            Purpose = (string)items[2];
        }

        public SystemEventRegistration(string SystemId, string MessageName, string Purpose)
        {
            this.SystemId = SystemId;
            this.MessageName = MessageName;
            this.Purpose = Purpose;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, MessageName, Purpose };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            MessageName = (string)items[1];
            Purpose = (string)items[2];
        }
    }

    [SqlRecord("T0", "SystemSetting")]
    public partial class SystemSetting : SqlTableTypeProxy<SystemSetting>, ISystemSetting
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SettingName", 1), SqlTypeFacets("nvarchar", false)]
        public string SettingName
        {
            get;
            set;
        }

        [SqlColumn("SettingValue", 2), SqlTypeFacets("nvarchar", false)]
        public string SettingValue
        {
            get;
            set;
        }

        [SqlColumn("ChangeTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime ChangeTS
        {
            get;
            set;
        }

        public SystemSetting()
        {
        }

        public SystemSetting(object[] items)
        {
            SystemId = (string)items[0];
            SettingName = (string)items[1];
            SettingValue = (string)items[2];
            ChangeTS = (DateTime)items[3];
        }

        public SystemSetting(string SystemId, string SettingName, string SettingValue, DateTime ChangeTS)
        {
            this.SystemId = SystemId;
            this.SettingName = SettingName;
            this.SettingValue = SettingValue;
            this.ChangeTS = ChangeTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, SettingName, SettingValue, ChangeTS };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            SettingName = (string)items[1];
            SettingValue = (string)items[2];
            ChangeTS = (DateTime)items[3];
        }
    }

    [SqlRecord("T0", "TableMonitorLogEntry")]
    public partial class TableMonitorLogEntry : SqlTableTypeProxy<TableMonitorLogEntry>, ITableMonitorLogEntry
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
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

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("LastObservedVersion", 4), SqlTypeFacets("varbinary", true)]
        public Byte[] LastObservedVersion
        {
            get;
            set;
        }

        [SqlColumn("ObservationTS", 5), SqlTypeFacets("datetime2", true)]
        public DateTime? ObservationTS
        {
            get;
            set;
        }

        [SqlColumn("LastProcessedVersion", 6), SqlTypeFacets("varbinary", true)]
        public Byte[] LastProcessedVersion
        {
            get;
            set;
        }

        [SqlColumn("ProcessedTS", 7), SqlTypeFacets("datetime2", true)]
        public DateTime? ProcessedTS
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

        public TableMonitorLogEntry()
        {
        }

        public TableMonitorLogEntry(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            LastObservedVersion = (Byte[])items[4];
            ObservationTS = (DateTime?)items[5];
            LastProcessedVersion = (Byte[])items[6];
            ProcessedTS = (DateTime?)items[7];
            LoggedTS = (DateTime)items[8];
        }

        public TableMonitorLogEntry(string HostId, string DatabaseName, string SchemaName, string TableName, Byte[] LastObservedVersion, DateTime? ObservationTS, Byte[] LastProcessedVersion, DateTime? ProcessedTS, DateTime LoggedTS)
        {
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.LastObservedVersion = LastObservedVersion;
            this.ObservationTS = ObservationTS;
            this.LastProcessedVersion = LastProcessedVersion;
            this.ProcessedTS = ProcessedTS;
            this.LoggedTS = LoggedTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, DatabaseName, SchemaName, TableName, LastObservedVersion, ObservationTS, LastProcessedVersion, ProcessedTS, LoggedTS };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            LastObservedVersion = (Byte[])items[4];
            ObservationTS = (DateTime?)items[5];
            LastProcessedVersion = (Byte[])items[6];
            ProcessedTS = (DateTime?)items[7];
            LoggedTS = (DateTime)items[8];
        }
    }

    [SqlRecord("T0", "TargetedDatabaseComponent")]
    public partial class TargetedDatabaseComponent : SqlTableTypeProxy<TargetedDatabaseComponent>, ITargetedDatabaseComponent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("TargetedDatabase", 1), SqlTypeFacets("nvarchar", false)]
        public string TargetedDatabase
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        public string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        public string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime ComponentTS
        {
            get;
            set;
        }

        [SqlColumn("SqlPackageName", 5), SqlTypeFacets("nvarchar", false)]
        public string SqlPackageName
        {
            get;
            set;
        }

        public TargetedDatabaseComponent()
        {
        }

        public TargetedDatabaseComponent(object[] items)
        {
            SystemId = (string)items[0];
            TargetedDatabase = (string)items[1];
            ComponentId = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
            SqlPackageName = (string)items[5];
        }

        public TargetedDatabaseComponent(string SystemId, string TargetedDatabase, string ComponentId, string ComponentVersion, DateTime ComponentTS, string SqlPackageName)
        {
            this.SystemId = SystemId;
            this.TargetedDatabase = TargetedDatabase;
            this.ComponentId = ComponentId;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;
            this.SqlPackageName = SqlPackageName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SystemId, TargetedDatabase, ComponentId, ComponentVersion, ComponentTS, SqlPackageName };
        }

        public override void SetItemArray(object[] items)
        {
            SystemId = (string)items[0];
            TargetedDatabase = (string)items[1];
            ComponentId = (string)items[2];
            ComponentVersion = (string)items[3];
            ComponentTS = (DateTime)items[4];
            SqlPackageName = (string)items[5];
        }
    }

    [SqlRecord("T0", "TinyTypeTableRow")]
    public partial class TinyTypeTableRow : SqlTableTypeProxy<TinyTypeTableRow>, ITinyTypeTableRow
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

        public TinyTypeTableRow()
        {
        }

        public TinyTypeTableRow(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public TinyTypeTableRow(byte TypeCode, string Identifier, string Label, string Description)
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

    [SqlRecord("T0", "TypedDataFlowDescriptor")]
    public partial class TypedDataFlowDescriptor : SqlTableTypeProxy<TypedDataFlowDescriptor>, ITypedDataFlowDescriptor
    {
        [SqlColumn("SourceAssembly", 0), SqlTypeFacets("nvarchar", false)]
        public string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 1), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 2), SqlTypeFacets("nvarchar", false)]
        public string DataFlowName
        {
            get;
            set;
        }

        [SqlColumn("WorkflowTypeUri", 3), SqlTypeFacets("nvarchar", false)]
        public string WorkflowTypeUri
        {
            get;
            set;
        }

        [SqlColumn("ArgumentTypeUri", 4), SqlTypeFacets("nvarchar", true)]
        public string ArgumentTypeUri
        {
            get;
            set;
        }

        public TypedDataFlowDescriptor()
        {
        }

        public TypedDataFlowDescriptor(object[] items)
        {
            SourceAssembly = (string)items[0];
            TargetAssembly = (string)items[1];
            DataFlowName = (string)items[2];
            WorkflowTypeUri = (string)items[3];
            ArgumentTypeUri = (string)items[4];
        }

        public TypedDataFlowDescriptor(string SourceAssembly, string TargetAssembly, string DataFlowName, string WorkflowTypeUri, string ArgumentTypeUri)
        {
            this.SourceAssembly = SourceAssembly;
            this.TargetAssembly = TargetAssembly;
            this.DataFlowName = DataFlowName;
            this.WorkflowTypeUri = WorkflowTypeUri;
            this.ArgumentTypeUri = ArgumentTypeUri;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceAssembly, TargetAssembly, DataFlowName, WorkflowTypeUri, ArgumentTypeUri };
        }

        public override void SetItemArray(object[] items)
        {
            SourceAssembly = (string)items[0];
            TargetAssembly = (string)items[1];
            DataFlowName = (string)items[2];
            WorkflowTypeUri = (string)items[3];
            ArgumentTypeUri = (string)items[4];
        }
    }

    [SqlRecord("T0", "TypedDataFlowIdentifier")]
    public partial class TypedDataFlowIdentifier : SqlTableTypeProxy<TypedDataFlowIdentifier>, ITypedDataFlowIdentifier
    {
        [SqlColumn("SourceAssembly", 0), SqlTypeFacets("nvarchar", false)]
        public string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 1), SqlTypeFacets("nvarchar", false)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 2), SqlTypeFacets("nvarchar", false)]
        public string DataFlowName
        {
            get;
            set;
        }

        public TypedDataFlowIdentifier()
        {
        }

        public TypedDataFlowIdentifier(object[] items)
        {
            SourceAssembly = (string)items[0];
            TargetAssembly = (string)items[1];
            DataFlowName = (string)items[2];
        }

        public TypedDataFlowIdentifier(string SourceAssembly, string TargetAssembly, string DataFlowName)
        {
            this.SourceAssembly = SourceAssembly;
            this.TargetAssembly = TargetAssembly;
            this.DataFlowName = DataFlowName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceAssembly, TargetAssembly, DataFlowName };
        }

        public override void SetItemArray(object[] items)
        {
            SourceAssembly = (string)items[0];
            TargetAssembly = (string)items[1];
            DataFlowName = (string)items[2];
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IArtifactReferenceSpec
    {
        [SqlColumn("SpecFileName", 0), SqlTypeFacets("nvarchar", false)]
        string SpecFileName
        {
            get;
            set;
        }

        [SqlColumn("SpecLabel", 1), SqlTypeFacets("nvarchar", false)]
        string SpecLabel
        {
            get;
            set;
        }

        [SqlColumn("AreaName", 2), SqlTypeFacets("nvarchar", false)]
        string AreaName
        {
            get;
            set;
        }

        [SqlColumn("SectionName", 3), SqlTypeFacets("nvarchar", false)]
        string SectionName
        {
            get;
            set;
        }

        [SqlColumn("ReferenceType", 4), SqlTypeFacets("nvarchar", false)]
        string ReferenceType
        {
            get;
            set;
        }

        [SqlColumn("SpecContent", 5), SqlTypeFacets("nvarchar", false)]
        string SpecContent
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IClassifier
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        string Identifier
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDacDeploymentToken
    {
        [SqlColumn("DeploymentId", 0), SqlTypeFacets("int", false)]
        int DeploymentId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 1), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDatabaseServer
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
        {
            get;
            set;
        }

        [SqlColumn("SqlNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SqlNodeId
        {
            get;
            set;
        }

        [SqlColumn("SqlAlias", 2), SqlTypeFacets("nvarchar", true)]
        string SqlAlias
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 3), SqlTypeFacets("nvarchar", false)]
        string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 4), SqlTypeFacets("nvarchar", false)]
        string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostNetworkName", 5), SqlTypeFacets("varchar", true)]
        string HostNetworkName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 6), SqlTypeFacets("nvarchar", true)]
        string HostIP
        {
            get;
            set;
        }

        [SqlColumn("SqlInstanceName", 7), SqlTypeFacets("nvarchar", false)]
        string SqlInstanceName
        {
            get;
            set;
        }

        [SqlColumn("SqlInstancePort", 8), SqlTypeFacets("int", true)]
        int? SqlInstancePort
        {
            get;
            set;
        }

        [SqlColumn("FileStreamRoot", 9), SqlTypeFacets("nvarchar", true)]
        string FileStreamRoot
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataDir", 10), SqlTypeFacets("nvarchar", true)]
        string DefaultDataDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogDir", 11), SqlTypeFacets("nvarchar", true)]
        string DefaultLogDir
        {
            get;
            set;
        }

        [SqlColumn("DefaultBackupDir", 12), SqlTypeFacets("nvarchar", true)]
        string DefaultBackupDir
        {
            get;
            set;
        }

        [SqlColumn("AdminLogDir", 13), SqlTypeFacets("nvarchar", true)]
        string AdminLogDir
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorName", 14), SqlTypeFacets("nvarchar", true)]
        string SqlOperatorName
        {
            get;
            set;
        }

        [SqlColumn("SqlOperatorPass", 15), SqlTypeFacets("nvarchar", true)]
        string SqlOperatorPass
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorName", 16), SqlTypeFacets("nvarchar", true)]
        string WinOperatorName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorPass", 17), SqlTypeFacets("nvarchar", true)]
        string WinOperatorPass
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDatabaseVersion
    {
        [SqlColumn("DatabaseName", 0), SqlTypeFacets("nvarchar", false)]
        string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("MajorVersion", 1), SqlTypeFacets("int", false)]
        int MajorVersion
        {
            get;
            set;
        }

        [SqlColumn("MinorVersion", 2), SqlTypeFacets("int", false)]
        int MinorVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildVersion", 3), SqlTypeFacets("int", false)]
        int BuildVersion
        {
            get;
            set;
        }

        [SqlColumn("RevisionVersion", 4), SqlTypeFacets("int", false)]
        int RevisionVersion
        {
            get;
            set;
        }

        [SqlColumn("BuildTS", 5), SqlTypeFacets("datetime2", false)]
        DateTime BuildTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDistributionDescription
    {
        [SqlColumn("DistributionId", 0), SqlTypeFacets("nvarchar", false)]
        string DistributionId
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IFileReceipt
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
        {
            get;
            set;
        }

        [SqlColumn("FileId", 1), SqlTypeFacets("uniqueidentifier", false)]
        Guid FileId
        {
            get;
            set;
        }

        [SqlColumn("FileName", 2), SqlTypeFacets("nvarchar", false)]
        string FileName
        {
            get;
            set;
        }

        [SqlColumn("FileType", 3), SqlTypeFacets("nvarchar", false)]
        string FileType
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 4), SqlTypeFacets("nvarchar", false)]
        string ReceiptPath
        {
            get;
            set;
        }

        [SqlColumn("WrittenTS", 5), SqlTypeFacets("datetime2", false)]
        DateTime WrittenTS
        {
            get;
            set;
        }

        [SqlColumn("ReceiptTS", 6), SqlTypeFacets("datetime2", false)]
        DateTime ReceiptTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IFileStreamIdentifier
    {
        [SqlColumn("row_id", 0), SqlTypeFacets("int", false)]
        int row_id
        {
            get;
            set;
        }

        [SqlColumn("stream_id", 1), SqlTypeFacets("uniqueidentifier", false)]
        Guid stream_id
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IHostFileInfo
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
        {
            get;
            set;
        }

        [SqlColumn("FilePath", 1), SqlTypeFacets("nvarchar", false)]
        string FilePath
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 2), SqlTypeFacets("datetime2", false)]
        DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime UpdateTS
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 4), SqlTypeFacets("bigint", false)]
        long FileSize
        {
            get;
            set;
        }

        [SqlColumn("FileSizeMB", 5), SqlTypeFacets("decimal", false)]
        decimal FileSizeMB
        {
            get;
            set;
        }

        [SqlColumn("FileSizeGB", 6), SqlTypeFacets("decimal", false)]
        decimal FileSizeGB
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ILargeTypeTableRow
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMediumTypeTableRow
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("smallint", false)]
        short TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMessageAttribute
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 1), SqlTypeFacets("nvarchar", false)]
        string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 2), SqlTypeFacets("nvarchar", false)]
        string TypeName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 3), SqlTypeFacets("nvarchar", false)]
        string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 4), SqlTypeFacets("int", false)]
        int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 5), SqlTypeFacets("nvarchar", false)]
        string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 6), SqlTypeFacets("bit", false)]
        bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("Length", 7), SqlTypeFacets("int", true)]
        int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 8), SqlTypeFacets("tinyint", true)]
        byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 9), SqlTypeFacets("tinyint", true)]
        byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("Description", 10), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMessageFormat
    {
        [SqlColumn("SchemaName", 0), SqlTypeFacets("nvarchar", false)]
        string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 1), SqlTypeFacets("nvarchar", false)]
        string TypeName
        {
            get;
            set;
        }

        [SqlColumn("FormatTemplate", 2), SqlTypeFacets("nvarchar", false)]
        string FormatTemplate
        {
            get;
            set;
        }

        [SqlColumn("P1", 3), SqlTypeFacets("nvarchar", true)]
        string P1
        {
            get;
            set;
        }

        [SqlColumn("P2", 4), SqlTypeFacets("nvarchar", true)]
        string P2
        {
            get;
            set;
        }

        [SqlColumn("P3", 5), SqlTypeFacets("nvarchar", true)]
        string P3
        {
            get;
            set;
        }

        [SqlColumn("P4", 6), SqlTypeFacets("nvarchar", true)]
        string P4
        {
            get;
            set;
        }

        [SqlColumn("P5", 7), SqlTypeFacets("nvarchar", true)]
        string P5
        {
            get;
            set;
        }

        [SqlColumn("P6", 8), SqlTypeFacets("nvarchar", true)]
        string P6
        {
            get;
            set;
        }

        [SqlColumn("P7", 9), SqlTypeFacets("nvarchar", true)]
        string P7
        {
            get;
            set;
        }

        [SqlColumn("P8", 10), SqlTypeFacets("nvarchar", true)]
        string P8
        {
            get;
            set;
        }

        [SqlColumn("P9", 11), SqlTypeFacets("nvarchar", true)]
        string P9
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMessageTypeRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 1), SqlTypeFacets("nvarchar", false)]
        string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 2), SqlTypeFacets("nvarchar", false)]
        string TypeName
        {
            get;
            set;
        }

        [SqlColumn("MessageClass", 3), SqlTypeFacets("nvarchar", false)]
        string MessageClass
        {
            get;
            set;
        }

        [SqlColumn("Description", 4), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMonitoredTable
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
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

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false)]
        string TableName
        {
            get;
            set;
        }

        [SqlColumn("MonitorEnabled", 4), SqlTypeFacets("bit", false)]
        bool MonitorEnabled
        {
            get;
            set;
        }

        [SqlColumn("MonitorFrequency", 5), SqlTypeFacets("int", false)]
        int MonitorFrequency
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface INavigationFolder
    {
        [SqlColumn("FolderIdentifier", 0), SqlTypeFacets("nvarchar", false)]
        string FolderIdentifier
        {
            get;
            set;
        }

        [SqlColumn("NavigatorType", 1), SqlTypeFacets("nvarchar", false)]
        string NavigatorType
        {
            get;
            set;
        }

        [SqlColumn("FolderName", 2), SqlTypeFacets("nvarchar", false)]
        string FolderName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformAgent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 1), SqlTypeFacets("nvarchar", false)]
        string AgentId
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformComponent
    {
        [SqlColumn("ComponentId", 0), SqlTypeFacets("nvarchar", false)]
        string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ClassifierId", 2), SqlTypeFacets("nvarchar", false)]
        string ClassifierId
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDacProfileDefinition
    {
        [SqlColumn("ProfileFileName", 0), SqlTypeFacets("nvarchar", false)]
        string ProfileFileName
        {
            get;
            set;
        }

        [SqlColumn("SourcePackage", 1), SqlTypeFacets("nvarchar", false)]
        string SourcePackage
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false)]
        string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 3), SqlTypeFacets("nvarchar", false)]
        string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 4), SqlTypeFacets("nvarchar", false)]
        string ProfileXml
        {
            get;
            set;
        }

        [SqlColumn("ProfileSourcePath", 5), SqlTypeFacets("nvarchar", true)]
        string ProfileSourcePath
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformDacRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("PackageName", 1), SqlTypeFacets("nvarchar", false)]
        string PackageName
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        DateTime ComponentTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformDatabase
    {
        [SqlColumn("ServerId", 0), SqlTypeFacets("nvarchar", false)]
        string ServerId
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

        [SqlColumn("DatabaseType", 2), SqlTypeFacets("nvarchar", false)]
        string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("IsPrimary", 3), SqlTypeFacets("bit", false)]
        bool IsPrimary
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 4), SqlTypeFacets("bit", false)]
        bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("IsModel", 5), SqlTypeFacets("bit", false)]
        bool IsModel
        {
            get;
            set;
        }

        [SqlColumn("IsRestore", 6), SqlTypeFacets("bit", false)]
        bool IsRestore
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformDatabaseProfile
    {
        [SqlColumn("ServerId", 0), SqlTypeFacets("nvarchar", false)]
        string ServerId
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

        [SqlColumn("DatabaseType", 2), SqlTypeFacets("nvarchar", false)]
        string DatabaseType
        {
            get;
            set;
        }

        [SqlColumn("ProfilePath", 3), SqlTypeFacets("nvarchar", true)]
        string ProfilePath
        {
            get;
            set;
        }

        [SqlColumn("ProfileXml", 4), SqlTypeFacets("nvarchar", true)]
        string ProfileXml
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformEntity
    {
        [SqlColumn("EntityName", 0), SqlTypeFacets("nvarchar", false)]
        string EntityName
        {
            get;
            set;
        }

        [SqlColumn("TypeUri", 1), SqlTypeFacets("nvarchar", false)]
        string TypeUri
        {
            get;
            set;
        }

        [SqlColumn("Body", 2), SqlTypeFacets("nvarchar", false)]
        string Body
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformNode
    {
        [SqlColumn("NodeId", 0), SqlTypeFacets("nvarchar", false)]
        string NodeId
        {
            get;
            set;
        }

        [SqlColumn("NodeName", 1), SqlTypeFacets("nvarchar", false)]
        string NodeName
        {
            get;
            set;
        }

        [SqlColumn("HostName", 2), SqlTypeFacets("nvarchar", false)]
        string HostName
        {
            get;
            set;
        }

        [SqlColumn("HostIP", 3), SqlTypeFacets("varchar", true)]
        string HostIP
        {
            get;
            set;
        }

        [SqlColumn("NetworkName", 4), SqlTypeFacets("varchar", true)]
        string NetworkName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorName", 5), SqlTypeFacets("nvarchar", true)]
        string WinOperatorName
        {
            get;
            set;
        }

        [SqlColumn("WinOperatorPass", 6), SqlTypeFacets("nvarchar", true)]
        string WinOperatorPass
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformProject
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 1), SqlTypeFacets("nvarchar", false)]
        string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("ProjectId", 2), SqlTypeFacets("nvarchar", false)]
        string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 3), SqlTypeFacets("nvarchar", false)]
        string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 4), SqlTypeFacets("nvarchar", false)]
        string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("IsSqlProject", 5), SqlTypeFacets("bit", false)]
        bool IsSqlProject
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 6), SqlTypeFacets("nvarchar", true)]
        string TargetDatabase
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformSolution
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 1), SqlTypeFacets("nvarchar", false)]
        string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("SolutionName", 2), SqlTypeFacets("nvarchar", false)]
        string SolutionName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformStoreChange
    {
        [SqlColumn("StoreName", 0), SqlTypeFacets("nvarchar", false)]
        string StoreName
        {
            get;
            set;
        }

        [SqlColumn("SystemKey", 1), SqlTypeFacets("bigint", false)]
        long SystemKey
        {
            get;
            set;
        }

        [SqlColumn("ChangeType", 2), SqlTypeFacets("char", false)]
        string ChangeType
        {
            get;
            set;
        }

        [SqlColumn("ChangeTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime ChangeTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformSystem
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformVariable
    {
        [SqlColumn("VariableName", 0), SqlTypeFacets("nvarchar", false)]
        string VariableName
        {
            get;
            set;
        }

        [SqlColumn("VariableValue", 1), SqlTypeFacets("nvarchar", false)]
        string VariableValue
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IProjectComponent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 1), SqlTypeFacets("nvarchar", false)]
        string ProjectName
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 3), SqlTypeFacets("nvarchar", false)]
        string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ComponentType", 4), SqlTypeFacets("nvarchar", false)]
        string ComponentType
        {
            get;
            set;
        }

        [SqlColumn("IsSqlProject", 5), SqlTypeFacets("bit", false)]
        bool IsSqlProject
        {
            get;
            set;
        }

        [SqlColumn("TargetDatabase", 6), SqlTypeFacets("nvarchar", true)]
        string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 7), SqlTypeFacets("nvarchar", true)]
        string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 8), SqlTypeFacets("datetime2", false)]
        DateTime ComponentTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IQueueRecord
    {
        [SqlColumn("ConversationId", 0), SqlTypeFacets("uniqueidentifier", true)]
        Guid? ConversationId
        {
            get;
            set;
        }

        [SqlColumn("MessageType", 1), SqlTypeFacets("sysname", true)]
        string MessageType
        {
            get;
            set;
        }

        [SqlColumn("MessageBody", 2), SqlTypeFacets("varbinary", true)]
        Byte[] MessageBody
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISqlMessageSpec
    {
        [SqlColumn("MessageNumber", 0), SqlTypeFacets("int", false)]
        int MessageNumber
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 2), SqlTypeFacets("nvarchar", false)]
        string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Severity", 3), SqlTypeFacets("int", false)]
        int Severity
        {
            get;
            set;
        }

        [SqlColumn("FormatString", 4), SqlTypeFacets("nvarchar", false)]
        string FormatString
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISqlProxyDefinition
    {
        [SqlColumn("AssemblyDesignator", 0), SqlTypeFacets("nvarchar", false)]
        string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false)]
        string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceNode", 3), SqlTypeFacets("nvarchar", false)]
        string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 4), SqlTypeFacets("nvarchar", true)]
        string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 5), SqlTypeFacets("nvarchar", true)]
        string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 6), SqlTypeFacets("nvarchar", false)]
        string ProfileText
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemArtifact
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ArtifactId", 1), SqlTypeFacets("nvarchar", false)]
        string ArtifactId
        {
            get;
            set;
        }

        [SqlColumn("ArtifactType", 2), SqlTypeFacets("nvarchar", false)]
        string ArtifactType
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemCommandRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 1), SqlTypeFacets("nvarchar", false)]
        string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 2), SqlTypeFacets("nvarchar", true)]
        string Purpose
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemComponent
    {
        [SqlColumn("ComponentId", 0), SqlTypeFacets("nvarchar", false)]
        string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ComponentType", 2), SqlTypeFacets("nvarchar", false)]
        string ComponentType
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        DateTime ComponentTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemEventRegistration
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("MessageName", 1), SqlTypeFacets("nvarchar", false)]
        string MessageName
        {
            get;
            set;
        }

        [SqlColumn("Purpose", 2), SqlTypeFacets("nvarchar", true)]
        string Purpose
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemSetting
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SettingName", 1), SqlTypeFacets("nvarchar", false)]
        string SettingName
        {
            get;
            set;
        }

        [SqlColumn("SettingValue", 2), SqlTypeFacets("nvarchar", false)]
        string SettingValue
        {
            get;
            set;
        }

        [SqlColumn("ChangeTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime ChangeTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITableMonitorLogEntry
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
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

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false)]
        string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false)]
        string TableName
        {
            get;
            set;
        }

        [SqlColumn("LastObservedVersion", 4), SqlTypeFacets("varbinary", true)]
        Byte[] LastObservedVersion
        {
            get;
            set;
        }

        [SqlColumn("ObservationTS", 5), SqlTypeFacets("datetime2", true)]
        DateTime? ObservationTS
        {
            get;
            set;
        }

        [SqlColumn("LastProcessedVersion", 6), SqlTypeFacets("varbinary", true)]
        Byte[] LastProcessedVersion
        {
            get;
            set;
        }

        [SqlColumn("ProcessedTS", 7), SqlTypeFacets("datetime2", true)]
        DateTime? ProcessedTS
        {
            get;
            set;
        }

        [SqlColumn("LoggedTS", 8), SqlTypeFacets("datetime2", false)]
        DateTime LoggedTS
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITargetedDatabaseComponent
    {
        [SqlColumn("SystemId", 0), SqlTypeFacets("nvarchar", false)]
        string SystemId
        {
            get;
            set;
        }

        [SqlColumn("TargetedDatabase", 1), SqlTypeFacets("nvarchar", false)]
        string TargetedDatabase
        {
            get;
            set;
        }

        [SqlColumn("ComponentId", 2), SqlTypeFacets("nvarchar", false)]
        string ComponentId
        {
            get;
            set;
        }

        [SqlColumn("ComponentVersion", 3), SqlTypeFacets("nvarchar", false)]
        string ComponentVersion
        {
            get;
            set;
        }

        [SqlColumn("ComponentTS", 4), SqlTypeFacets("datetime2", false)]
        DateTime ComponentTS
        {
            get;
            set;
        }

        [SqlColumn("SqlPackageName", 5), SqlTypeFacets("nvarchar", false)]
        string SqlPackageName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITinyTypeTableRow
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITypedDataFlowDescriptor
    {
        [SqlColumn("SourceAssembly", 0), SqlTypeFacets("nvarchar", false)]
        string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 1), SqlTypeFacets("nvarchar", false)]
        string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 2), SqlTypeFacets("nvarchar", false)]
        string DataFlowName
        {
            get;
            set;
        }

        [SqlColumn("WorkflowTypeUri", 3), SqlTypeFacets("nvarchar", false)]
        string WorkflowTypeUri
        {
            get;
            set;
        }

        [SqlColumn("ArgumentTypeUri", 4), SqlTypeFacets("nvarchar", true)]
        string ArgumentTypeUri
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the T0 schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITypedDataFlowIdentifier
    {
        [SqlColumn("SourceAssembly", 0), SqlTypeFacets("nvarchar", false)]
        string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 1), SqlTypeFacets("nvarchar", false)]
        string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 2), SqlTypeFacets("nvarchar", false)]
        string DataFlowName
        {
            get;
            set;
        }
    }
}
namespace MetaFlow.Core
{
    using System;
    using System.Collections.Generic;
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
// Emission concluded at 7/9/2018 7:22:02 PM
