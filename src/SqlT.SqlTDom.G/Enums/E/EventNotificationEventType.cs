////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum EventNotificationEventType : int
    {
        Unknown = 0,
        CreateTable = 21,
        AlterTable = 22,
        DropTable = 23,
        CreateIndex = 24,
        AlterIndex = 25,
        DropIndex = 26,
        CreateStatistics = 27,
        UpdateStatistics = 28,
        DropStatistics = 29,
        CreateSynonym = 34,
        DropSynonym = 36,
        CreateView = 41,
        AlterView = 42,
        DropView = 43,
        CreateProcedure = 51,
        AlterProcedure = 52,
        DropProcedure = 53,
        CreateFunction = 61,
        AlterFunction = 62,
        DropFunction = 63,
        CreateTrigger = 71,
        AlterTrigger = 72,
        DropTrigger = 73,
        CreateEventNotification = 74,
        DropEventNotification = 76,
        CreateType = 91,
        DropType = 93,
        CreateAssembly = 101,
        AlterAssembly = 102,
        DropAssembly = 103,
        CreateUser = 131,
        AlterUser = 132,
        DropUser = 133,
        CreateRole = 134,
        AlterRole = 135,
        DropRole = 136,
        CreateApplicationRole = 137,
        AlterApplicationRole = 138,
        DropApplicationRole = 139,
        CreateSchema = 141,
        AlterSchema = 142,
        DropSchema = 143,
        CreateLogin = 144,
        AlterLogin = 145,
        DropLogin = 146,
        CreateMessageType = 151,
        AlterMessageType = 152,
        DropMessageType = 153,
        CreateContract = 154,
        DropContract = 156,
        CreateQueue = 157,
        AlterQueue = 158,
        DropQueue = 159,
        BrokerQueueDisabled = 160,
        CreateService = 161,
        AlterService = 162,
        DropService = 163,
        CreateRoute = 164,
        AlterRoute = 165,
        DropRoute = 166,
        GrantServer = 167,
        DenyServer = 168,
        RevokeServer = 169,
        GrantDatabase = 170,
        DenyDatabase = 171,
        RevokeDatabase = 172,
        QueueActivation = 173,
        CreateRemoteServiceBinding = 174,
        AlterRemoteServiceBinding = 175,
        DropRemoteServiceBinding = 176,
        CreateXmlSchemaCollection = 177,
        AlterXmlSchemaCollection = 178,
        DropXmlSchemaCollection = 179,
        CreateEndpoint = 181,
        AlterEndpoint = 182,
        DropEndpoint = 183,
        CreatePartitionFunction = 191,
        AlterPartitionFunction = 192,
        DropPartitionFunction = 193,
        CreatePartitionScheme = 194,
        AlterPartitionScheme = 195,
        DropPartitionScheme = 196,
        CreateCertificate = 197,
        AlterCertificate = 198,
        DropCertificate = 199,
        CreateDatabase = 201,
        AlterDatabase = 202,
        DropDatabase = 203,
        AlterAuthorizationServer = 204,
        AlterAuthorizationDatabase = 205,
        CreateXmlIndex = 206,
        AddRoleMember = 207,
        DropRoleMember = 208,
        AddServerRoleMember = 209,
        DropServerRoleMember = 210,
        AlterExtendedProperty = 211,
        AlterFullTextCatalog = 212,
        AlterFullTextIndex = 213,
        AlterInstance = 214,
        AlterMessage = 215,
        AlterPlanGuide = 216,
        AlterRemoteServer = 217,
        BindDefault = 218,
        BindRule = 219,
        CreateDefault = 220,
        CreateExtendedProcedure = 221,
        CreateExtendedProperty = 222,
        CreateFullTextCatalog = 223,
        CreateFullTextIndex = 224,
        CreateLinkedServer = 225,
        CreateLinkedServerLogin = 226,
        CreateMessage = 227,
        CreatePlanGuide = 228,
        CreateRule = 229,
        CreateRemoteServer = 230,
        DropDefault = 231,
        DropExtendedProcedure = 232,
        DropExtendedProperty = 233,
        DropFullTextCatalog = 234,
        DropFullTextIndex = 235,
        DropLinkedServerLogin = 236,
        DropMessage = 237,
        DropPlanGuide = 238,
        DropRule = 239,
        DropRemoteServer = 240,
        Rename = 241,
        UnbindDefault = 242,
        UnbindRule = 243,
        CreateSymmetricKey = 244,
        AlterSymmetricKey = 245,
        DropSymmetricKey = 246,
        CreateAsymmetricKey = 247,
        AlterAsymmetricKey = 248,
        DropAsymmetricKey = 249,
        AlterServiceMasterKey = 251,
        CreateMasterKey = 252,
        AlterMasterKey = 253,
        DropMasterKey = 254,
        AddSignatureSchemaObject = 255,
        DropSignatureSchemaObject = 256,
        AddSignature = 257,
        DropSignature = 258,
        CreateCredential = 259,
        AlterCredential = 260,
        DropCredential = 261,
        DropLinkedServer = 262,
        AlterLinkedServer = 263,
        CreateEventSession = 264,
        AlterEventSession = 265,
        DropEventSession = 266,
        CreateResourcePool = 267,
        AlterResourcePool = 268,
        DropResourcePool = 269,
        CreateWorkloadGroup = 270,
        AlterWorkloadGroup = 271,
        DropWorkloadGroup = 272,
        AlterResourceGovernorConfig = 273,
        CreateSpatialIndex = 274,
        CreateCryptographicProvider = 275,
        AlterCryptographicProvider = 276,
        DropCryptographicProvider = 277,
        CreateDatabaseEncryptionKey = 278,
        AlterDatabaseEncryptionKey = 279,
        DropDatabaseEncryptionKey = 280,
        CreateBrokerPriority = 281,
        AlterBrokerPriority = 282,
        DropBrokerPriority = 283,
        CreateServerAudit = 284,
        AlterServerAudit = 285,
        DropServerAudit = 286,
        CreateServerAuditSpecification = 287,
        AlterServerAuditSpecification = 288,
        DropServerAuditSpecification = 289,
        CreateDatabaseAuditSpecification = 290,
        AlterDatabaseAuditSpecification = 291,
        DropDatabaseAuditSpecification = 292,
        CreateFullTextStopList = 293,
        AlterFullTextStopList = 294,
        DropFullTextStopList = 295,
        AlterServerConfiguration = 296,
        CreateSearchPropertyList = 297,
        AlterSearchPropertyList = 298,
        DropSearchPropertyList = 299,
        CreateServerRole = 300,
        AlterServerRole = 301,
        DropServerRole = 302,
        CreateSequence = 303,
        AlterSequence = 304,
        DropSequence = 305,
        CreateAvailabilityGroup = 306,
        AlterAvailabilityGroup = 307,
        DropAvailabilityGroup = 308,
        CreateDatabaseAudit = 309,
        DropDatabaseAudit = 310,
        AlterDatabaseAudit = 311,
        CreateSecurityPolicy = 312,
        AlterSecurityPolicy = 313,
        DropSecurityPolicy = 314,
        CreateColumnMasterKey = 315,
        DropColumnMasterKey = 316,
        CreateColumnEncryptionKey = 317,
        AlterColumnEncryptionKey = 318,
        DropColumnEncryptionKey = 319,
        AlterDatabaseScopedConfiguration = 320,
        CreateExternalResourcePool = 321,
        AlterExternalResourcePool = 322,
        DropExternalResourcePool = 323,
        AuditLogin = 1014,
        AuditLogout = 1015,
        AuditLoginFailed = 1020,
        EventLog = 1021,
        ErrorLog = 1022,
        LockDeadlock = 1025,
        Exception = 1033,
        SpCacheMiss = 1034,
        SpCacheInsert = 1035,
        SpCacheRemove = 1036,
        SpRecompile = 1037,
        ObjectCreated = 1046,
        ObjectDeleted = 1047,
        HashWarning = 1055,
        LockDeadlockChain = 1059,
        LockEscalation = 1060,
        OledbErrors = 1061,
        ExecutionWarnings = 1067,
        SortWarnings = 1069,
        MissingColumnStatistics = 1079,
        MissingJoinPredicate = 1080,
        ServerMemoryChange = 1081,
        UserConfigurable0 = 1082,
        UserConfigurable1 = 1083,
        UserConfigurable2 = 1084,
        UserConfigurable3 = 1085,
        UserConfigurable4 = 1086,
        UserConfigurable5 = 1087,
        UserConfigurable6 = 1088,
        UserConfigurable7 = 1089,
        UserConfigurable8 = 1090,
        UserConfigurable9 = 1091,
        DataFileAutoGrow = 1092,
        LogFileAutoGrow = 1093,
        DataFileAutoShrink = 1094,
        LogFileAutoShrink = 1095,
        AuditDatabaseScopeGdrEvent = 1102,
        AuditSchemaObjectGdrEvent = 1103,
        AuditAddLoginEvent = 1104,
        AuditLoginGdrEvent = 1105,
        AuditLoginChangePropertyEvent = 1106,
        AuditLoginChangePasswordEvent = 1107,
        AuditAddLoginToServerRoleEvent = 1108,
        AuditAddDBUserEvent = 1109,
        AuditAddMemberToDBRoleEvent = 1110,
        AuditAddRoleEvent = 1111,
        AuditAppRoleChangePasswordEvent = 1112,
        AuditSchemaObjectAccessEvent = 1114,
        AuditBackupRestoreEvent = 1115,
        AuditDbccEvent = 1116,
        AuditChangeAuditEvent = 1117,
        OledbCallEvent = 1119,
        OledbQueryInterfaceEvent = 1120,
        OledbDataReadEvent = 1121,
        ShowPlanXml = 1122,
        DeprecationAnnouncement = 1125,
        DeprecationFinalSupport = 1126,
        ExchangeSpillEvent = 1127,
        AuditDatabaseManagementEvent = 1128,
        AuditDatabaseObjectManagementEvent = 1129,
        AuditDatabasePrincipalManagementEvent = 1130,
        AuditSchemaObjectManagementEvent = 1131,
        AuditServerPrincipalImpersonationEvent = 1132,
        AuditDatabasePrincipalImpersonationEvent = 1133,
        AuditServerObjectTakeOwnershipEvent = 1134,
        AuditDatabaseObjectTakeOwnershipEvent = 1135,
        BlockedProcessReport = 1137,
        ShowPlanXmlStatisticsProfile = 1146,
        DeadlockGraph = 1148,
        TraceFileClose = 1150,
        AuditChangeDatabaseOwner = 1152,
        AuditSchemaObjectTakeOwnershipEvent = 1153,
        FtCrawlStarted = 1155,
        FtCrawlStopped = 1156,
        FtCrawlAborted = 1157,
        UserErrorMessage = 1162,
        ObjectAltered = 1164,
        SqlStmtRecompile = 1166,
        DatabaseMirroringStateChange = 1167,
        ShowPlanXmlForQueryCompile = 1168,
        ShowPlanAllForQueryCompile = 1169,
        AuditServerScopeGdrEvent = 1170,
        AuditServerObjectGdrEvent = 1171,
        AuditDatabaseObjectGdrEvent = 1172,
        AuditServerOperationEvent = 1173,
        AuditServerAlterTraceEvent = 1175,
        AuditServerObjectManagementEvent = 1176,
        AuditServerPrincipalManagementEvent = 1177,
        AuditDatabaseOperationEvent = 1178,
        AuditDatabaseObjectAccessEvent = 1180,
        OledbProviderInformation = 1194,
        MountTape = 1195,
        AssemblyLoad = 1196,
        XQueryStaticType = 1198,
        QnSubscription = 1199,
        QnParameterTable = 1200,
        QnTemplate = 1201,
        QnDynamics = 1202,
        BitmapWarning = 1212,
        DatabaseSuspectDataPage = 1213,
        CpuThresholdExceeded = 1214,
        AuditFullText = 1235
    }
}