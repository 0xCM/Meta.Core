//This file was generated at 7/9/2018 7:10:57 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.C0
{
    using System;
    using System.Collections.Generic;
    using MetaFlow.Core;
    using MetaFlow.WF;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class C0TableTypeNames
    {
        public const string CopyDataset = "[C0].[CopyDataset]";
        public const string CopyFile = "[C0].[CopyFile]";
        public const string DefineVariable = "[C0].[DefineVariable]";
        public const string DeployDatabase = "[C0].[DeployDatabase]";
        public const string DeploySqlDac = "[C0].[DeploySqlDac]";
        public const string DescribeBackup = "[C0].[DescribeBackup]";
        public const string DisableAgent = "[C0].[DisableAgent]";
        public const string DistributePackage = "[C0].[DistributePackage]";
        public const string EnableAgent = "[C0].[EnableAgent]";
        public const string ExecuteTypedDataFlow = "[C0].[ExecuteTypedDataFlow]";
        public const string ExtractArchive = "[C0].[ExtractArchive]";
        public const string GenerateProxies = "[C0].[GenerateProxies]";
        public const string PauseAgent = "[C0].[PauseAgent]";
        public const string ResumeAgent = "[C0].[ResumeAgent]";
        public const string StartAgent = "[C0].[StartAgent]";
        public const string StopAgent = "[C0].[StopAgent]";
    }

    [SqlRecord("C0", "CopyDataset")]
    public partial class CopyDataset : SqlTableTypeProxy<CopyDataset>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("DatasetName", 3), SqlTypeFacets("nvarchar", false)]
        public string DatasetName
        {
            get;
            set;
        }

        public CopyDataset()
        {
        }

        public CopyDataset(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            DatasetName = (string)items[3];
        }

        public CopyDataset(string CommandNode, string SourceNodeId, string TargetNodeId, string DatasetName)
        {
            this.CommandNode = CommandNode;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.DatasetName = DatasetName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, SourceNodeId, TargetNodeId, DatasetName };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            DatasetName = (string)items[3];
        }
    }

    [SqlRecord("C0", "CopyFile")]
    public partial class CopyFile : SqlTableTypeProxy<CopyFile>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourcePath", 3), SqlTypeFacets("nvarchar", false)]
        public string SourcePath
        {
            get;
            set;
        }

        [SqlColumn("TargetPath", 4), SqlTypeFacets("nvarchar", false)]
        public string TargetPath
        {
            get;
            set;
        }

        public CopyFile()
        {
        }

        public CopyFile(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            SourcePath = (string)items[3];
            TargetPath = (string)items[4];
        }

        public CopyFile(string CommandNode, string SourceNodeId, string TargetNodeId, string SourcePath, string TargetPath)
        {
            this.CommandNode = CommandNode;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.SourcePath = SourcePath;
            this.TargetPath = TargetPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, SourceNodeId, TargetNodeId, SourcePath, TargetPath };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            SourcePath = (string)items[3];
            TargetPath = (string)items[4];
        }
    }

    [SqlRecord("C0", "DefineVariable")]
    public partial class DefineVariable : SqlTableTypeProxy<DefineVariable>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public DefineVariable()
        {
        }

        public DefineVariable(object[] items)
        {
            CommandNode = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }

        public DefineVariable(string CommandNode, string VariableName, string VariableValue)
        {
            this.CommandNode = CommandNode;
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, VariableName, VariableValue };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }
    }

    [SqlRecord("C0", "DeployDatabase")]
    public partial class DeployDatabase : SqlTableTypeProxy<DeployDatabase>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("DatabaseServer", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseServer
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

        public DeployDatabase()
        {
        }

        public DeployDatabase(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            DatabaseName = (string)items[2];
        }

        public DeployDatabase(string CommandNode, string DatabaseServer, string DatabaseName)
        {
            this.CommandNode = CommandNode;
            this.DatabaseServer = DatabaseServer;
            this.DatabaseName = DatabaseName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, DatabaseServer, DatabaseName };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            DatabaseName = (string)items[2];
        }
    }

    [SqlRecord("C0", "DeploySqlDac")]
    public partial class DeploySqlDac : SqlTableTypeProxy<DeploySqlDac>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("DatabaseServer", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseServer
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

        public DeploySqlDac()
        {
        }

        public DeploySqlDac(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            PackageName = (string)items[2];
        }

        public DeploySqlDac(string CommandNode, string DatabaseServer, string PackageName)
        {
            this.CommandNode = CommandNode;
            this.DatabaseServer = DatabaseServer;
            this.PackageName = PackageName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, DatabaseServer, PackageName };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            PackageName = (string)items[2];
        }
    }

    [SqlRecord("C0", "DescribeBackup")]
    public partial class DescribeBackup : SqlTableTypeProxy<DescribeBackup>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("DatabaseServer", 1), SqlTypeFacets("nvarchar", false)]
        public string DatabaseServer
        {
            get;
            set;
        }

        [SqlColumn("HostBackupPath", 2), SqlTypeFacets("nvarchar", true)]
        public string HostBackupPath
        {
            get;
            set;
        }

        public DescribeBackup()
        {
        }

        public DescribeBackup(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            HostBackupPath = (string)items[2];
        }

        public DescribeBackup(string CommandNode, string DatabaseServer, string HostBackupPath)
        {
            this.CommandNode = CommandNode;
            this.DatabaseServer = DatabaseServer;
            this.HostBackupPath = HostBackupPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, DatabaseServer, HostBackupPath };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            DatabaseServer = (string)items[1];
            HostBackupPath = (string)items[2];
        }
    }

    [SqlRecord("C0", "DisableAgent")]
    public partial class DisableAgent : SqlTableTypeProxy<DisableAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public DisableAgent()
        {
        }

        public DisableAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public DisableAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    /// <summary>
    /// Publishes most recent distribution version of a distribution to an identified node
    /// </summary>
    [SqlRecord("C0", "DistributePackage")]
    public partial class DistributePackage : SqlTableTypeProxy<DistributePackage>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 1), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("DistributionId", 2), SqlTypeFacets("nvarchar", false)]
        public string DistributionId
        {
            get;
            set;
        }

        public DistributePackage()
        {
        }

        public DistributePackage(object[] items)
        {
            CommandNode = (string)items[0];
            TargetNodeId = (string)items[1];
            DistributionId = (string)items[2];
        }

        public DistributePackage(string CommandNode, string TargetNodeId, string DistributionId)
        {
            this.CommandNode = CommandNode;
            this.TargetNodeId = TargetNodeId;
            this.DistributionId = DistributionId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, TargetNodeId, DistributionId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            TargetNodeId = (string)items[1];
            DistributionId = (string)items[2];
        }
    }

    [SqlRecord("C0", "EnableAgent")]
    public partial class EnableAgent : SqlTableTypeProxy<EnableAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public EnableAgent()
        {
        }

        public EnableAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public EnableAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    [SqlRecord("C0", "ExecuteTypedDataFlow")]
    public partial class ExecuteTypedDataFlow : SqlTableTypeProxy<ExecuteTypedDataFlow>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        [SqlColumn("SourceAssembly", 2), SqlTypeFacets("nvarchar", false)]
        public string SourceAssembly
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 3), SqlTypeFacets("nvarchar", false)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 4), SqlTypeFacets("nvarchar", false)]
        public string TargetNodeId
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

        [SqlColumn("TargetDatabase", 6), SqlTypeFacets("nvarchar", false)]
        public string TargetDatabase
        {
            get;
            set;
        }

        [SqlColumn("DataFlowName", 7), SqlTypeFacets("nvarchar", false)]
        public string DataFlowName
        {
            get;
            set;
        }

        public ExecuteTypedDataFlow()
        {
        }

        public ExecuteTypedDataFlow(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            SourceAssembly = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetNodeId = (string)items[4];
            TargetAssembly = (string)items[5];
            TargetDatabase = (string)items[6];
            DataFlowName = (string)items[7];
        }

        public ExecuteTypedDataFlow(string CommandNode, string SourceNodeId, string SourceAssembly, string SourceDatabase, string TargetNodeId, string TargetAssembly, string TargetDatabase, string DataFlowName)
        {
            this.CommandNode = CommandNode;
            this.SourceNodeId = SourceNodeId;
            this.SourceAssembly = SourceAssembly;
            this.SourceDatabase = SourceDatabase;
            this.TargetNodeId = TargetNodeId;
            this.TargetAssembly = TargetAssembly;
            this.TargetDatabase = TargetDatabase;
            this.DataFlowName = DataFlowName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, SourceNodeId, SourceAssembly, SourceDatabase, TargetNodeId, TargetAssembly, TargetDatabase, DataFlowName };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            SourceNodeId = (string)items[1];
            SourceAssembly = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetNodeId = (string)items[4];
            TargetAssembly = (string)items[5];
            TargetDatabase = (string)items[6];
            DataFlowName = (string)items[7];
        }
    }

    [SqlRecord("C0", "ExtractArchive")]
    public partial class ExtractArchive : SqlTableTypeProxy<ExtractArchive>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("ArchivePath", 1), SqlTypeFacets("nvarchar", false)]
        public string ArchivePath
        {
            get;
            set;
        }

        [SqlColumn("TargetFolder", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetFolder
        {
            get;
            set;
        }

        public ExtractArchive()
        {
        }

        public ExtractArchive(object[] items)
        {
            CommandNode = (string)items[0];
            ArchivePath = (string)items[1];
            TargetFolder = (string)items[2];
        }

        public ExtractArchive(string CommandNode, string ArchivePath, string TargetFolder)
        {
            this.CommandNode = CommandNode;
            this.ArchivePath = ArchivePath;
            this.TargetFolder = TargetFolder;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, ArchivePath, TargetFolder };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            ArchivePath = (string)items[1];
            TargetFolder = (string)items[2];
        }
    }

    [SqlRecord("C0", "GenerateProxies")]
    public partial class GenerateProxies : SqlTableTypeProxy<GenerateProxies>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("GenerationProfilePath", 1), SqlTypeFacets("nvarchar", false)]
        public string GenerationProfilePath
        {
            get;
            set;
        }

        [SqlColumn("PLL", 2), SqlTypeFacets("bit", false)]
        public bool PLL
        {
            get;
            set;
        }

        public GenerateProxies()
        {
        }

        public GenerateProxies(object[] items)
        {
            CommandNode = (string)items[0];
            GenerationProfilePath = (string)items[1];
            PLL = (bool)items[2];
        }

        public GenerateProxies(string CommandNode, string GenerationProfilePath, bool PLL)
        {
            this.CommandNode = CommandNode;
            this.GenerationProfilePath = GenerationProfilePath;
            this.PLL = PLL;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, GenerationProfilePath, PLL };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            GenerationProfilePath = (string)items[1];
            PLL = (bool)items[2];
        }
    }

    [SqlRecord("C0", "PauseAgent")]
    public partial class PauseAgent : SqlTableTypeProxy<PauseAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public PauseAgent()
        {
        }

        public PauseAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public PauseAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    [SqlRecord("C0", "ResumeAgent")]
    public partial class ResumeAgent : SqlTableTypeProxy<ResumeAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public ResumeAgent()
        {
        }

        public ResumeAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public ResumeAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    [SqlRecord("C0", "StartAgent")]
    public partial class StartAgent : SqlTableTypeProxy<StartAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public StartAgent()
        {
        }

        public StartAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public StartAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }

    [SqlRecord("C0", "StopAgent")]
    public partial class StopAgent : SqlTableTypeProxy<StopAgent>, IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
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

        public StopAgent()
        {
        }

        public StopAgent(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public StopAgent(string CommandNode, string AgentId)
        {
            this.CommandNode = CommandNode;
            this.AgentId = AgentId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode, AgentId };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }
    }
}
//This file was generated at 7/9/2018 7:10:57 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.E0
{
    using System;
    using System.Collections.Generic;
    using MetaFlow.Core;
    using MetaFlow.WF;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class E0TableTypeNames
    {
        public const string BackupDescriptionCaptured = "[E0].[BackupDescriptionCaptured]";
        public const string CommandExecuted = "[E0].[CommandExecuted]";
        public const string CommandExecuting = "[E0].[CommandExecuting]";
        public const string DatabaseBackupArchiveReceived = "[E0].[DatabaseBackupArchiveReceived]";
        public const string DatabaseBackupReceived = "[E0].[DatabaseBackupReceived]";
        public const string DatabaseDeployed = "[E0].[DatabaseDeployed]";
        public const string DistributionReceived = "[E0].[DistributionReceived]";
        public const string ExchangeConnected = "[E0].[ExchangeConnected]";
        public const string FileReceived = "[E0].[FileReceived]";
        public const string PlatformEntityUpdated = "[E0].[PlatformEntityUpdated]";
        public const string VariableDefined = "[E0].[VariableDefined]";
    }

    [SqlRecord("E0", "BackupDescriptionCaptured")]
    public partial class BackupDescriptionCaptured : SqlTableTypeProxy<BackupDescriptionCaptured>
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("HostBackupPath", 1), SqlTypeFacets("nvarchar", false)]
        public string HostBackupPath
        {
            get;
            set;
        }

        [SqlColumn("LogicalFileName", 2), SqlTypeFacets("nvarchar", false)]
        public string LogicalFileName
        {
            get;
            set;
        }

        [SqlColumn("BackupFileType", 3), SqlTypeFacets("char", false)]
        public string BackupFileType
        {
            get;
            set;
        }

        public BackupDescriptionCaptured()
        {
        }

        public BackupDescriptionCaptured(object[] items)
        {
            HostId = (string)items[0];
            HostBackupPath = (string)items[1];
            LogicalFileName = (string)items[2];
            BackupFileType = (string)items[3];
        }

        public BackupDescriptionCaptured(string HostId, string HostBackupPath, string LogicalFileName, string BackupFileType)
        {
            this.HostId = HostId;
            this.HostBackupPath = HostBackupPath;
            this.LogicalFileName = LogicalFileName;
            this.BackupFileType = BackupFileType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, HostBackupPath, LogicalFileName, BackupFileType };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            HostBackupPath = (string)items[1];
            LogicalFileName = (string)items[2];
            BackupFileType = (string)items[3];
        }
    }

    [SqlRecord("E0", "CommandExecuted")]
    public partial class CommandExecuted : SqlTableTypeProxy<CommandExecuted>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("TaskId", 1), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 2), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 3), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        public CommandExecuted()
        {
        }

        public CommandExecuted(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
            CommandUri = (string)items[2];
            Succeeded = (bool)items[3];
        }

        public CommandExecuted(string HostId, long TaskId, string CommandUri, bool Succeeded)
        {
            this.HostId = HostId;
            this.TaskId = TaskId;
            this.CommandUri = CommandUri;
            this.Succeeded = Succeeded;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, TaskId, CommandUri, Succeeded };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
            CommandUri = (string)items[2];
            Succeeded = (bool)items[3];
        }
    }

    [SqlRecord("E0", "CommandExecuting")]
    public partial class CommandExecuting : SqlTableTypeProxy<CommandExecuting>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("TaskId", 1), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 2), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        public CommandExecuting()
        {
        }

        public CommandExecuting(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
            CommandUri = (string)items[2];
        }

        public CommandExecuting(string HostId, long TaskId, string CommandUri)
        {
            this.HostId = HostId;
            this.TaskId = TaskId;
            this.CommandUri = CommandUri;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, TaskId, CommandUri };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
            CommandUri = (string)items[2];
        }
    }

    [SqlRecord("E0", "DatabaseBackupArchiveReceived")]
    public partial class DatabaseBackupArchiveReceived : SqlTableTypeProxy<DatabaseBackupArchiveReceived>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 1), SqlTypeFacets("nvarchar", false)]
        public string ReceiptPath
        {
            get;
            set;
        }

        public DatabaseBackupArchiveReceived()
        {
        }

        public DatabaseBackupArchiveReceived(object[] items)
        {
            HostId = (string)items[0];
            ReceiptPath = (string)items[1];
        }

        public DatabaseBackupArchiveReceived(string HostId, string ReceiptPath)
        {
            this.HostId = HostId;
            this.ReceiptPath = ReceiptPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, ReceiptPath };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            ReceiptPath = (string)items[1];
        }
    }

    [SqlRecord("E0", "DatabaseBackupReceived")]
    public partial class DatabaseBackupReceived : SqlTableTypeProxy<DatabaseBackupReceived>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("ReceiptPath", 1), SqlTypeFacets("nvarchar", false)]
        public string ReceiptPath
        {
            get;
            set;
        }

        public DatabaseBackupReceived()
        {
        }

        public DatabaseBackupReceived(object[] items)
        {
            HostId = (string)items[0];
            ReceiptPath = (string)items[1];
        }

        public DatabaseBackupReceived(string HostId, string ReceiptPath)
        {
            this.HostId = HostId;
            this.ReceiptPath = ReceiptPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, ReceiptPath };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            ReceiptPath = (string)items[1];
        }
    }

    [SqlRecord("E0", "DatabaseDeployed")]
    public partial class DatabaseDeployed : SqlTableTypeProxy<DatabaseDeployed>, ISystemEvent
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

        [SqlColumn("DatabaseVersion", 2), SqlTypeFacets("nvarchar", false)]
        public string DatabaseVersion
        {
            get;
            set;
        }

        public DatabaseDeployed()
        {
        }

        public DatabaseDeployed(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseVersion = (string)items[2];
        }

        public DatabaseDeployed(string HostId, string DatabaseName, string DatabaseVersion)
        {
            this.HostId = HostId;
            this.DatabaseName = DatabaseName;
            this.DatabaseVersion = DatabaseVersion;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, DatabaseName, DatabaseVersion };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseVersion = (string)items[2];
        }
    }

    [SqlRecord("E0", "DistributionReceived")]
    public partial class DistributionReceived : SqlTableTypeProxy<DistributionReceived>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("DistributionId", 1), SqlTypeFacets("nvarchar", false)]
        public string DistributionId
        {
            get;
            set;
        }

        [SqlColumn("DistributionVersion", 2), SqlTypeFacets("nvarchar", false)]
        public string DistributionVersion
        {
            get;
            set;
        }

        [SqlColumn("DistributionPath", 3), SqlTypeFacets("nvarchar", false)]
        public string DistributionPath
        {
            get;
            set;
        }

        public DistributionReceived()
        {
        }

        public DistributionReceived(object[] items)
        {
            HostId = (string)items[0];
            DistributionId = (string)items[1];
            DistributionVersion = (string)items[2];
            DistributionPath = (string)items[3];
        }

        public DistributionReceived(string HostId, string DistributionId, string DistributionVersion, string DistributionPath)
        {
            this.HostId = HostId;
            this.DistributionId = DistributionId;
            this.DistributionVersion = DistributionVersion;
            this.DistributionPath = DistributionPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, DistributionId, DistributionVersion, DistributionPath };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            DistributionId = (string)items[1];
            DistributionVersion = (string)items[2];
            DistributionPath = (string)items[3];
        }
    }

    [SqlRecord("E0", "ExchangeConnected")]
    public partial class ExchangeConnected : SqlTableTypeProxy<ExchangeConnected>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("ExchangeName", 1), SqlTypeFacets("nvarchar", false)]
        public string ExchangeName
        {
            get;
            set;
        }

        public ExchangeConnected()
        {
        }

        public ExchangeConnected(object[] items)
        {
            HostId = (string)items[0];
            ExchangeName = (string)items[1];
        }

        public ExchangeConnected(string HostId, string ExchangeName)
        {
            this.HostId = HostId;
            this.ExchangeName = ExchangeName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, ExchangeName };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            ExchangeName = (string)items[1];
        }
    }

    [SqlRecord("E0", "FileReceived")]
    public partial class FileReceived : SqlTableTypeProxy<FileReceived>, ISystemEvent
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

        [SqlColumn("ReceiptTS", 5), SqlTypeFacets("datetime2", false)]
        public DateTime ReceiptTS
        {
            get;
            set;
        }

        [SqlColumn("UpdatedTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime UpdatedTS
        {
            get;
            set;
        }

        public FileReceived()
        {
        }

        public FileReceived(object[] items)
        {
            HostId = (string)items[0];
            FileId = (Guid)items[1];
            FileName = (string)items[2];
            FileType = (string)items[3];
            ReceiptPath = (string)items[4];
            ReceiptTS = (DateTime)items[5];
            UpdatedTS = (DateTime)items[6];
        }

        public FileReceived(string HostId, Guid FileId, string FileName, string FileType, string ReceiptPath, DateTime ReceiptTS, DateTime UpdatedTS)
        {
            this.HostId = HostId;
            this.FileId = FileId;
            this.FileName = FileName;
            this.FileType = FileType;
            this.ReceiptPath = ReceiptPath;
            this.ReceiptTS = ReceiptTS;
            this.UpdatedTS = UpdatedTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, FileId, FileName, FileType, ReceiptPath, ReceiptTS, UpdatedTS };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            FileId = (Guid)items[1];
            FileName = (string)items[2];
            FileType = (string)items[3];
            ReceiptPath = (string)items[4];
            ReceiptTS = (DateTime)items[5];
            UpdatedTS = (DateTime)items[6];
        }
    }

    [SqlRecord("E0", "PlatformEntityUpdated")]
    public partial class PlatformEntityUpdated : SqlTableTypeProxy<PlatformEntityUpdated>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
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

        public PlatformEntityUpdated()
        {
        }

        public PlatformEntityUpdated(object[] items)
        {
            HostId = (string)items[0];
            EntityName = (string)items[1];
        }

        public PlatformEntityUpdated(string HostId, string EntityName)
        {
            this.HostId = HostId;
            this.EntityName = EntityName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, EntityName };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            EntityName = (string)items[1];
        }
    }

    [SqlRecord("E0", "VariableDefined")]
    public partial class VariableDefined : SqlTableTypeProxy<VariableDefined>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
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

        public VariableDefined()
        {
        }

        public VariableDefined(object[] items)
        {
            HostId = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }

        public VariableDefined(string HostId, string VariableName, string VariableValue)
        {
            this.HostId = HostId;
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, VariableName, VariableValue };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }
    }
}
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using MetaFlow.Core;
    using MetaFlow.WF;
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
// Emission concluded at 7/9/2018 7:10:59 PM
