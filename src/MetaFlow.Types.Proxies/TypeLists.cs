//This file was generated at 7/9/2018 7:13:10 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public class PlatformDatabaseServers : TypedItemList<PlatformDatabaseServers, DatabaseServer>
    {
        public readonly static DatabaseServer Node00 = new DatabaseServer("n00", "n00", "Node00", "Node00", "localhost", "localhost", "127.0.0.1", "mssqlserver", null, "mssqlserver", "C:\\SqlData\\Disk00\\MSSQL14.MSSQLSERVER\\MSSQL\\DATA", "C:\\SqlData\\Disk00\\MSSQL14.MSSQLSERVER\\MSSQL\\DATA", "C:\\SqlData\\Disk00\\MSSQL14.MSSQLSERVER\\MSSQL\\Backup", "C:\\SqlData\\Disk00\\MSSQL14.MSSQLSERVER\\MSSQL\\Log", "sqladmin", "diatribe", "pdmsadmin", "pass@word9");
        public readonly static DatabaseServer Node50 = new DatabaseServer("n50", "n50", "Node50", "Node50", "exacore03", "Node50", "192.168.0.10", "mssqlserver", null, "mssqlserver", "H:\\SQL00\\udb\\", "H:\\SQL00\\udb\\", "H:\\SQL00\\bak", "?", "sqladmin", "diatribe", "pdmsadmin", "pass@word9");
    }

    public class PlatformAgents : TypedItemList<PlatformAgents, AgentIdentifier>
    {
        public const string DocumentImporter = "DocumentImporter";
        public const string FtpAgent = "FtpAgent";
        public const string ProfileCaptureAgent = "ProfileCaptureAgent";
        public const string DataFileAgent = "DataFileAgent";
        public const string JobScheduler = "JobScheduler";
        public const string EventCaptureAgent = "EventCaptureAgent";
        public const string CommandDispatcher = "CommandDispatcher";
        public const string SystemCommandAgent = "SystemCommandAgent";
        public const string TableMonitor = "TableMonitor";
    }

    public class PlatformDatabaseTypes : TypedItemList<PlatformDatabaseTypes, Classifier>
    {
        public readonly static Classifier AC = new Classifier(19, "AC");
        public readonly static Classifier ACWF = new Classifier(20, "ACWF");
        public readonly static Classifier Command = new Classifier(8, "Command");
        public readonly static Classifier DF = new Classifier(4, "DF");
        public readonly static Classifier DS = new Classifier(3, "DS");
        public readonly static Classifier ET = new Classifier(18, "ET");
        public readonly static Classifier Hive = new Classifier(1, "Hive");
        public readonly static Classifier ID = new Classifier(31, "ID");
        public readonly static Classifier JHCA = new Classifier(21, "JHCA");
        public readonly static Classifier JHCU = new Classifier(24, "JHCU");
        public readonly static Classifier JHEV = new Classifier(22, "JHEV");
        public readonly static Classifier JHSG = new Classifier(26, "JHSG");
        public readonly static Classifier JHTX = new Classifier(23, "JHTX");
        public readonly static Classifier JHWF = new Classifier(25, "JHWF");
        public readonly static Classifier LG = new Classifier(17, "LG");
        public readonly static Classifier LU = new Classifier(32, "LU");
        public readonly static Classifier ML = new Classifier(5, "ML");
        public readonly static Classifier MLWF = new Classifier(6, "MLWF");
        public readonly static Classifier MX = new Classifier(34, "MX");
        public readonly static Classifier None = new Classifier(0, "None");
        public readonly static Classifier OS = new Classifier(30, "OS");
        public readonly static Classifier PF = new Classifier(2, "PF");
        public readonly static Classifier QA = new Classifier(12, "QA");
        public readonly static Classifier QC = new Classifier(13, "QC");
        public readonly static Classifier QD = new Classifier(14, "QD");
        public readonly static Classifier QE = new Classifier(11, "QE");
        public readonly static Classifier QF = new Classifier(15, "QF");
        public readonly static Classifier QP = new Classifier(10, "QP");
        public readonly static Classifier QR = new Classifier(9, "QR");
        public readonly static Classifier RD = new Classifier(29, "RD");
        public readonly static Classifier RF = new Classifier(16, "RF");
        public readonly static Classifier RP = new Classifier(28, "RP");
        public readonly static Classifier Settings = new Classifier(7, "Settings");
        public readonly static Classifier WF = new Classifier(33, "WF");
        public readonly static Classifier WS = new Classifier(27, "WS");
    }

    public class PlatformSystems : TypedItemList<PlatformSystems, SystemIdentifier>
    {
        public const string None = "None";
        public const string PF = "PF";
        public const string WF = "WF";
        public const string DS = "DS";
        public const string DF = "DF";
        public const string ML = "ML";
        public const string QD = "QD";
        public const string QF = "QF";
        public const string AG = "AG";
    }

    public class ComponentTypes : TypedItemList<ComponentTypes, Classifier>
    {
    }

    public class PlatformShareTypes : TypedItemList<PlatformShareTypes, Classifier>
    {
        public readonly static Classifier APL = new Classifier(9, "APL");
        public readonly static Classifier BAK = new Classifier(6, "BAK");
        public readonly static Classifier DAT = new Classifier(7, "DAT");
        public readonly static Classifier DFA = new Classifier(3, "DFA");
        public readonly static Classifier DFR = new Classifier(2, "DFR");
        public readonly static Classifier FTR = new Classifier(10, "FTR");
        public readonly static Classifier LOG = new Classifier(8, "LOG");
        public readonly static Classifier None = new Classifier(0, "None");
        public readonly static Classifier PDR = new Classifier(1, "PDR");
        public readonly static Classifier VHD = new Classifier(4, "VHD");
        public readonly static Classifier XEV = new Classifier(5, "XEV");
    }

    public class NavigationFolders : TypedItemList<NavigationFolders, NavigationFolder>
    {
        public readonly static NavigationFolder PlatformDistributions = new NavigationFolder("PlatformDistributions", "Platform", "distributions");
        public readonly static NavigationFolder PlatformTools = new NavigationFolder("PlatformTools", "Platform", "tools");
        public readonly static NavigationFolder VirtualDrives = new NavigationFolder("VirtualDrives", "Platform", "vhdx");
        public readonly static NavigationFolder PublishedBackups = new NavigationFolder("PublishedBackups", "Platform", "backups");
        public readonly static NavigationFolder PdrAdmin = new NavigationFolder("PdrAdmin", "PDR", "admin");
        public readonly static NavigationFolder PdrAssets = new NavigationFolder("PdrAssets", "PDR", "assets");
        public readonly static NavigationFolder PdrLogs = new NavigationFolder("PdrLogs", "PDR", "logs");
        public readonly static NavigationFolder PdrShells = new NavigationFolder("PdrShells", "PDR", "shells");
        public readonly static NavigationFolder PdrTools = new NavigationFolder("PdrTools", "PDR", "tools");
        public readonly static NavigationFolder PdrUnc = new NavigationFolder("PdrUnc", "PDR", "unc");
        public readonly static NavigationFolder PdrDist = new NavigationFolder("PdrDist", "PDR", "dist");
        public readonly static NavigationFolder PdrDistArchive = new NavigationFolder("PdrDistArchive", "PDR", "dist.a");
        public readonly static NavigationFolder BackupArchives = new NavigationFolder("BackupArchives", "PDR", "backups.a");
    }
}
// Emission concluded at 7/9/2018 7:13:12 PM
