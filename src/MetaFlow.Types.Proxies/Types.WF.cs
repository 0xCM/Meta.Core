//This file was generated at 7/9/2018 7:22:03 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class WFTableTypeNames
    {
        public const string AgentCommand = "[WF].[AgentCommand]";
        public const string AgentConfiguration = "[WF].[AgentConfiguration]";
        public const string AgentControlCommand = "[WF].[AgentControlCommand]";
        public const string AgentStatus = "[WF].[AgentStatus]";
        public const string ArchiveOperator = "[WF].[ArchiveOperator]";
        public const string BatchCompletion = "[WF].[BatchCompletion]";
        public const string CommandSpecifier = "[WF].[CommandSpecifier]";
        public const string CommandTableEntry = "[WF].[CommandTableEntry]";
        public const string CompletionOperator = "[WF].[CompletionOperator]";
        public const string DequeueOperator = "[WF].[DequeueOperator]";
        public const string EnqueueOperator = "[WF].[EnqueueOperator]";
        public const string MergeAction = "[WF].[MergeAction]";
        public const string MergeActionCount = "[WF].[MergeActionCount]";
        public const string PeekOperator = "[WF].[PeekOperator]";
        public const string ProcessingBatch = "[WF].[ProcessingBatch]";
        public const string SystemCommand = "[WF].[SystemCommand]";
        public const string SystemCommandSubmission = "[WF].[SystemCommandSubmission]";
        public const string SystemEvent = "[WF].[SystemEvent]";
        public const string SystemEventCapture = "[WF].[SystemEventCapture]";
        public const string SystemEventIdentity = "[WF].[SystemEventIdentity]";
        public const string SystemNotification = "[WF].[SystemNotification]";
        public const string SystemReaction = "[WF].[SystemReaction]";
        public const string SystemTask = "[WF].[SystemTask]";
        public const string SystemTaskDefinition = "[WF].[SystemTaskDefinition]";
        public const string SystemTaskEvent = "[WF].[SystemTaskEvent]";
        public const string SystemTaskResult = "[WF].[SystemTaskResult]";
        public const string SystemTaskState = "[WF].[SystemTaskState]";
        public const string TaskArchive = "[WF].[TaskArchive]";
        public const string TaskQueue = "[WF].[TaskQueue]";
        public const string TaskResult = "[WF].[TaskResult]";
        public const string TaskState = "[WF].[TaskState]";
        public const string WorkflowOptions = "[WF].[WorkflowOptions]";
        public const string WorkflowTask = "[WF].[WorkflowTask]";
    }

    [SqlRecord("WF", "AgentCommand")]
    public partial class AgentCommand : SqlTableTypeProxy<AgentCommand>, IAgentCommand
    {
        [SqlColumn("CommandId", 0), SqlTypeFacets("bigint", false)]
        public long CommandId
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

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 4), SqlTypeFacets("nvarchar", false)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("CommandName", 5), SqlTypeFacets("nvarchar", false)]
        public string CommandName
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 6), SqlTypeFacets("nvarchar", true)]
        public string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 7), SqlTypeFacets("nvarchar", true)]
        public string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 8), SqlTypeFacets("nvarchar", true)]
        public string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 9), SqlTypeFacets("nvarchar", true)]
        public string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 10), SqlTypeFacets("nvarchar", true)]
        public string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 11), SqlTypeFacets("nvarchar", true)]
        public string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 12), SqlTypeFacets("nvarchar", true)]
        public string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 13), SqlTypeFacets("nvarchar", true)]
        public string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 14), SqlTypeFacets("nvarchar", true)]
        public string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 15), SqlTypeFacets("nvarchar", true)]
        public string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 16), SqlTypeFacets("nvarchar", true)]
        public string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 17), SqlTypeFacets("nvarchar", true)]
        public string Arg6Value
        {
            get;
            set;
        }

        public AgentCommand()
        {
        }

        public AgentCommand(object[] items)
        {
            CommandId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            CorrelationToken = (string)items[3];
            AgentId = (string)items[4];
            CommandName = (string)items[5];
            Arg1Name = (string)items[6];
            Arg1Value = (string)items[7];
            Arg2Name = (string)items[8];
            Arg2Value = (string)items[9];
            Arg3Name = (string)items[10];
            Arg3Value = (string)items[11];
            Arg4Name = (string)items[12];
            Arg4Value = (string)items[13];
            Arg5Name = (string)items[14];
            Arg5Value = (string)items[15];
            Arg6Name = (string)items[16];
            Arg6Value = (string)items[17];
        }

        public AgentCommand(long CommandId, string SourceNodeId, string TargetNodeId, string CorrelationToken, string AgentId, string CommandName, string Arg1Name, string Arg1Value, string Arg2Name, string Arg2Value, string Arg3Name, string Arg3Value, string Arg4Name, string Arg4Value, string Arg5Name, string Arg5Value, string Arg6Name, string Arg6Value)
        {
            this.CommandId = CommandId;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.CorrelationToken = CorrelationToken;
            this.AgentId = AgentId;
            this.CommandName = CommandName;
            this.Arg1Name = Arg1Name;
            this.Arg1Value = Arg1Value;
            this.Arg2Name = Arg2Name;
            this.Arg2Value = Arg2Value;
            this.Arg3Name = Arg3Name;
            this.Arg3Value = Arg3Value;
            this.Arg4Name = Arg4Name;
            this.Arg4Value = Arg4Value;
            this.Arg5Name = Arg5Name;
            this.Arg5Value = Arg5Value;
            this.Arg6Name = Arg6Name;
            this.Arg6Value = Arg6Value;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandId, SourceNodeId, TargetNodeId, CorrelationToken, AgentId, CommandName, Arg1Name, Arg1Value, Arg2Name, Arg2Value, Arg3Name, Arg3Value, Arg4Name, Arg4Value, Arg5Name, Arg5Value, Arg6Name, Arg6Value };
        }

        public override void SetItemArray(object[] items)
        {
            CommandId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            CorrelationToken = (string)items[3];
            AgentId = (string)items[4];
            CommandName = (string)items[5];
            Arg1Name = (string)items[6];
            Arg1Value = (string)items[7];
            Arg2Name = (string)items[8];
            Arg2Value = (string)items[9];
            Arg3Name = (string)items[10];
            Arg3Value = (string)items[11];
            Arg4Name = (string)items[12];
            Arg4Value = (string)items[13];
            Arg5Name = (string)items[14];
            Arg5Value = (string)items[15];
            Arg6Name = (string)items[16];
            Arg6Value = (string)items[17];
        }
    }

    [SqlRecord("WF", "AgentConfiguration")]
    public partial class AgentConfiguration : SqlTableTypeProxy<AgentConfiguration>, IAgentConfiguration
    {
        [SqlColumn("AgentId", 0), SqlTypeFacets("nvarchar", false)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 1), SqlTypeFacets("bit", false)]
        public bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("SpinFrequency", 2), SqlTypeFacets("int", false)]
        public int SpinFrequency
        {
            get;
            set;
        }

        public AgentConfiguration()
        {
        }

        public AgentConfiguration(object[] items)
        {
            AgentId = (string)items[0];
            IsEnabled = (bool)items[1];
            SpinFrequency = (int)items[2];
        }

        public AgentConfiguration(string AgentId, bool IsEnabled, int SpinFrequency)
        {
            this.AgentId = AgentId;
            this.IsEnabled = IsEnabled;
            this.SpinFrequency = SpinFrequency;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AgentId, IsEnabled, SpinFrequency };
        }

        public override void SetItemArray(object[] items)
        {
            AgentId = (string)items[0];
            IsEnabled = (bool)items[1];
            SpinFrequency = (int)items[2];
        }
    }

    [SqlRecord("WF", "AgentControlCommand")]
    public partial class AgentControlCommand : SqlTableTypeProxy<AgentControlCommand>, IAgentControlCommand
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

        public AgentControlCommand()
        {
        }

        public AgentControlCommand(object[] items)
        {
            CommandNode = (string)items[0];
            AgentId = (string)items[1];
        }

        public AgentControlCommand(string CommandNode, string AgentId)
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

    [SqlRecord("WF", "AgentStatus")]
    public partial class AgentStatus : SqlTableTypeProxy<AgentStatus>, IAgentStatus
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
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

        [SqlColumn("AgentState", 3), SqlTypeFacets("nvarchar", false)]
        public string AgentState
        {
            get;
            set;
        }

        [SqlColumn("StatusSummary", 4), SqlTypeFacets("nvarchar", true)]
        public string StatusSummary
        {
            get;
            set;
        }

        public AgentStatus()
        {
        }

        public AgentStatus(object[] items)
        {
            HostId = (string)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
            AgentState = (string)items[3];
            StatusSummary = (string)items[4];
        }

        public AgentStatus(string HostId, string SystemId, string AgentId, string AgentState, string StatusSummary)
        {
            this.HostId = HostId;
            this.SystemId = SystemId;
            this.AgentId = AgentId;
            this.AgentState = AgentState;
            this.StatusSummary = StatusSummary;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, SystemId, AgentId, AgentState, StatusSummary };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
            AgentState = (string)items[3];
            StatusSummary = (string)items[4];
        }
    }

    [SqlRecord("WF", "ArchiveOperator")]
    public partial class ArchiveOperator : SqlTableTypeProxy<ArchiveOperator>, IArchiveOperator
    {
        [SqlColumn("ResetOutstanding", 0), SqlTypeFacets("bit", true)]
        public bool? ResetOutstanding
        {
            get;
            set;
        }

        [SqlColumn("RetryFailures", 1), SqlTypeFacets("bit", true)]
        public bool? RetryFailures
        {
            get;
            set;
        }

        public ArchiveOperator()
        {
        }

        public ArchiveOperator(object[] items)
        {
            ResetOutstanding = (bool?)items[0];
            RetryFailures = (bool?)items[1];
        }

        public ArchiveOperator(bool? ResetOutstanding, bool? RetryFailures)
        {
            this.ResetOutstanding = ResetOutstanding;
            this.RetryFailures = RetryFailures;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ResetOutstanding, RetryFailures };
        }

        public override void SetItemArray(object[] items)
        {
            ResetOutstanding = (bool?)items[0];
            RetryFailures = (bool?)items[1];
        }
    }

    [SqlRecord("WF", "BatchCompletion")]
    public partial class BatchCompletion : SqlTableTypeProxy<BatchCompletion>, IBatchCompletion
    {
        [SqlColumn("BatchNumber", 0), SqlTypeFacets("int", false)]
        public int BatchNumber
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 1), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 2), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("BatchMessage", 3), SqlTypeFacets("nvarchar", true)]
        public string BatchMessage
        {
            get;
            set;
        }

        public BatchCompletion()
        {
        }

        public BatchCompletion(object[] items)
        {
            BatchNumber = (int)items[0];
            CompleteTS = (DateTime?)items[1];
            Succeeded = (bool)items[2];
            BatchMessage = (string)items[3];
        }

        public BatchCompletion(int BatchNumber, DateTime? CompleteTS, bool Succeeded, string BatchMessage)
        {
            this.BatchNumber = BatchNumber;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.BatchMessage = BatchMessage;
        }

        public override object[] GetItemArray()
        {
            return new object[] { BatchNumber, CompleteTS, Succeeded, BatchMessage };
        }

        public override void SetItemArray(object[] items)
        {
            BatchNumber = (int)items[0];
            CompleteTS = (DateTime?)items[1];
            Succeeded = (bool)items[2];
            BatchMessage = (string)items[3];
        }
    }

    [SqlRecord("WF", "CommandSpecifier")]
    public partial class CommandSpecifier : SqlTableTypeProxy<CommandSpecifier>, ICommandSpecifier
    {
        [SqlColumn("CommandName", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandName
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

        [SqlColumn("TargetSystem", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetSystem
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public CommandSpecifier()
        {
        }

        public CommandSpecifier(object[] items)
        {
            CommandName = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystem = (string)items[2];
            CorrelationToken = (string)items[3];
        }

        public CommandSpecifier(string CommandName, string TargetNodeId, string TargetSystem, string CorrelationToken)
        {
            this.CommandName = CommandName;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystem = TargetSystem;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandName, TargetNodeId, TargetSystem, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            CommandName = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystem = (string)items[2];
            CorrelationToken = (string)items[3];
        }
    }

    [SqlRecord("WF", "CommandTableEntry")]
    public partial class CommandTableEntry : SqlTableTypeProxy<CommandTableEntry>, ICommandTableEntry
    {
        [SqlColumn("CommandName", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandName
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

        [SqlColumn("TargetSystem", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetSystem
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 4), SqlTypeFacets("nvarchar", true)]
        public string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 5), SqlTypeFacets("nvarchar", true)]
        public string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 6), SqlTypeFacets("nvarchar", true)]
        public string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 7), SqlTypeFacets("nvarchar", true)]
        public string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 8), SqlTypeFacets("nvarchar", true)]
        public string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 9), SqlTypeFacets("nvarchar", true)]
        public string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 10), SqlTypeFacets("nvarchar", true)]
        public string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 11), SqlTypeFacets("nvarchar", true)]
        public string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 12), SqlTypeFacets("nvarchar", true)]
        public string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 13), SqlTypeFacets("nvarchar", true)]
        public string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 14), SqlTypeFacets("nvarchar", true)]
        public string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 15), SqlTypeFacets("nvarchar", true)]
        public string Arg6Value
        {
            get;
            set;
        }

        public CommandTableEntry()
        {
        }

        public CommandTableEntry(object[] items)
        {
            CommandName = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystem = (string)items[2];
            CorrelationToken = (string)items[3];
            Arg1Name = (string)items[4];
            Arg1Value = (string)items[5];
            Arg2Name = (string)items[6];
            Arg2Value = (string)items[7];
            Arg3Name = (string)items[8];
            Arg3Value = (string)items[9];
            Arg4Name = (string)items[10];
            Arg4Value = (string)items[11];
            Arg5Name = (string)items[12];
            Arg5Value = (string)items[13];
            Arg6Name = (string)items[14];
            Arg6Value = (string)items[15];
        }

        public CommandTableEntry(string CommandName, string TargetNodeId, string TargetSystem, string CorrelationToken, string Arg1Name, string Arg1Value, string Arg2Name, string Arg2Value, string Arg3Name, string Arg3Value, string Arg4Name, string Arg4Value, string Arg5Name, string Arg5Value, string Arg6Name, string Arg6Value)
        {
            this.CommandName = CommandName;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystem = TargetSystem;
            this.CorrelationToken = CorrelationToken;
            this.Arg1Name = Arg1Name;
            this.Arg1Value = Arg1Value;
            this.Arg2Name = Arg2Name;
            this.Arg2Value = Arg2Value;
            this.Arg3Name = Arg3Name;
            this.Arg3Value = Arg3Value;
            this.Arg4Name = Arg4Name;
            this.Arg4Value = Arg4Value;
            this.Arg5Name = Arg5Name;
            this.Arg5Value = Arg5Value;
            this.Arg6Name = Arg6Name;
            this.Arg6Value = Arg6Value;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandName, TargetNodeId, TargetSystem, CorrelationToken, Arg1Name, Arg1Value, Arg2Name, Arg2Value, Arg3Name, Arg3Value, Arg4Name, Arg4Value, Arg5Name, Arg5Value, Arg6Name, Arg6Value };
        }

        public override void SetItemArray(object[] items)
        {
            CommandName = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystem = (string)items[2];
            CorrelationToken = (string)items[3];
            Arg1Name = (string)items[4];
            Arg1Value = (string)items[5];
            Arg2Name = (string)items[6];
            Arg2Value = (string)items[7];
            Arg3Name = (string)items[8];
            Arg3Value = (string)items[9];
            Arg4Name = (string)items[10];
            Arg4Value = (string)items[11];
            Arg5Name = (string)items[12];
            Arg5Value = (string)items[13];
            Arg6Name = (string)items[14];
            Arg6Value = (string)items[15];
        }
    }

    [SqlRecord("WF", "CompletionOperator")]
    public partial class CompletionOperator : SqlTableTypeProxy<CompletionOperator>, ICompletionOperator
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", true)]
        public long? TaskId
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 1), SqlTypeFacets("bit", true)]
        public bool? Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 2), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        public CompletionOperator()
        {
        }

        public CompletionOperator(object[] items)
        {
            TaskId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultDescription = (string)items[2];
        }

        public CompletionOperator(long? TaskId, bool? Succeeded, string ResultDescription)
        {
            this.TaskId = TaskId;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, Succeeded, ResultDescription };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultDescription = (string)items[2];
        }
    }

    [SqlRecord("WF", "DequeueOperator")]
    public partial class DequeueOperator : SqlTableTypeProxy<DequeueOperator>, IDequeueOperator
    {
        [SqlColumn("MaxCount", 0), SqlTypeFacets("int", true)]
        public int? MaxCount
        {
            get;
            set;
        }

        public DequeueOperator()
        {
        }

        public DequeueOperator(object[] items)
        {
            MaxCount = (int?)items[0];
        }

        public DequeueOperator(int? MaxCount)
        {
            this.MaxCount = MaxCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { MaxCount };
        }

        public override void SetItemArray(object[] items)
        {
            MaxCount = (int?)items[0];
        }
    }

    [SqlRecord("WF", "EnqueueOperator")]
    public partial class EnqueueOperator : SqlTableTypeProxy<EnqueueOperator>, IEnqueueOperator
    {
        [SqlColumn("CorrelationToken", 0), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public EnqueueOperator()
        {
        }

        public EnqueueOperator(object[] items)
        {
            CorrelationToken = (string)items[0];
        }

        public EnqueueOperator(string CorrelationToken)
        {
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            CorrelationToken = (string)items[0];
        }
    }

    [SqlRecord("WF", "MergeAction")]
    public partial class MergeAction : SqlTableTypeProxy<MergeAction>, IMergeAction
    {
        [SqlColumn("ActionName", 0), SqlTypeFacets("varchar", true)]
        public string ActionName
        {
            get;
            set;
        }

        public MergeAction()
        {
        }

        public MergeAction(object[] items)
        {
            ActionName = (string)items[0];
        }

        public MergeAction(string ActionName)
        {
            this.ActionName = ActionName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ActionName };
        }

        public override void SetItemArray(object[] items)
        {
            ActionName = (string)items[0];
        }
    }

    [SqlRecord("WF", "MergeActionCount")]
    public partial class MergeActionCount : SqlTableTypeProxy<MergeActionCount>, IMergeActionCount
    {
        [SqlColumn("InsertCount", 0), SqlTypeFacets("int", false)]
        public int InsertCount
        {
            get;
            set;
        }

        [SqlColumn("UpdateCount", 1), SqlTypeFacets("int", false)]
        public int UpdateCount
        {
            get;
            set;
        }

        [SqlColumn("DeleteCount", 2), SqlTypeFacets("int", false)]
        public int DeleteCount
        {
            get;
            set;
        }

        public MergeActionCount()
        {
        }

        public MergeActionCount(object[] items)
        {
            InsertCount = (int)items[0];
            UpdateCount = (int)items[1];
            DeleteCount = (int)items[2];
        }

        public MergeActionCount(int InsertCount, int UpdateCount, int DeleteCount)
        {
            this.InsertCount = InsertCount;
            this.UpdateCount = UpdateCount;
            this.DeleteCount = DeleteCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { InsertCount, UpdateCount, DeleteCount };
        }

        public override void SetItemArray(object[] items)
        {
            InsertCount = (int)items[0];
            UpdateCount = (int)items[1];
            DeleteCount = (int)items[2];
        }
    }

    [SqlRecord("WF", "PeekOperator")]
    public partial class PeekOperator : SqlTableTypeProxy<PeekOperator>, IPeekOperator
    {
        [SqlColumn("MaxCount", 0), SqlTypeFacets("int", true)]
        public int? MaxCount
        {
            get;
            set;
        }

        public PeekOperator()
        {
        }

        public PeekOperator(object[] items)
        {
            MaxCount = (int?)items[0];
        }

        public PeekOperator(int? MaxCount)
        {
            this.MaxCount = MaxCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { MaxCount };
        }

        public override void SetItemArray(object[] items)
        {
            MaxCount = (int?)items[0];
        }
    }

    [SqlRecord("WF", "ProcessingBatch")]
    public partial class ProcessingBatch : SqlTableTypeProxy<ProcessingBatch>, IProcessingBatch
    {
        [SqlColumn("BatchNumber", 0), SqlTypeFacets("int", false)]
        public int BatchNumber
        {
            get;
            set;
        }

        [SqlColumn("MinKey", 1), SqlTypeFacets("bigint", false)]
        public long MinKey
        {
            get;
            set;
        }

        [SqlColumn("MaxKey", 2), SqlTypeFacets("bigint", false)]
        public long MaxKey
        {
            get;
            set;
        }

        [SqlColumn("EnqueuedTS", 3), SqlTypeFacets("datetime2", false)]
        public DateTime EnqueuedTS
        {
            get;
            set;
        }

        [SqlColumn("Dequeued", 4), SqlTypeFacets("bit", false)]
        public bool Dequeued
        {
            get;
            set;
        }

        [SqlColumn("DequeuedTS", 5), SqlTypeFacets("datetime2", true)]
        public DateTime? DequeuedTS
        {
            get;
            set;
        }

        [SqlColumn("Complete", 6), SqlTypeFacets("bit", false)]
        public bool Complete
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 7), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 8), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("BatchMessage", 9), SqlTypeFacets("nvarchar", true)]
        public string BatchMessage
        {
            get;
            set;
        }

        public ProcessingBatch()
        {
        }

        public ProcessingBatch(object[] items)
        {
            BatchNumber = (int)items[0];
            MinKey = (long)items[1];
            MaxKey = (long)items[2];
            EnqueuedTS = (DateTime)items[3];
            Dequeued = (bool)items[4];
            DequeuedTS = (DateTime?)items[5];
            Complete = (bool)items[6];
            CompleteTS = (DateTime?)items[7];
            Succeeded = (bool)items[8];
            BatchMessage = (string)items[9];
        }

        public ProcessingBatch(int BatchNumber, long MinKey, long MaxKey, DateTime EnqueuedTS, bool Dequeued, DateTime? DequeuedTS, bool Complete, DateTime? CompleteTS, bool Succeeded, string BatchMessage)
        {
            this.BatchNumber = BatchNumber;
            this.MinKey = MinKey;
            this.MaxKey = MaxKey;
            this.EnqueuedTS = EnqueuedTS;
            this.Dequeued = Dequeued;
            this.DequeuedTS = DequeuedTS;
            this.Complete = Complete;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.BatchMessage = BatchMessage;
        }

        public override object[] GetItemArray()
        {
            return new object[] { BatchNumber, MinKey, MaxKey, EnqueuedTS, Dequeued, DequeuedTS, Complete, CompleteTS, Succeeded, BatchMessage };
        }

        public override void SetItemArray(object[] items)
        {
            BatchNumber = (int)items[0];
            MinKey = (long)items[1];
            MaxKey = (long)items[2];
            EnqueuedTS = (DateTime)items[3];
            Dequeued = (bool)items[4];
            DequeuedTS = (DateTime?)items[5];
            Complete = (bool)items[6];
            CompleteTS = (DateTime?)items[7];
            Succeeded = (bool)items[8];
            BatchMessage = (string)items[9];
        }
    }

    [SqlRecord("WF", "SystemCommand")]
    public partial class SystemCommand : SqlTableTypeProxy<SystemCommand>, ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        public SystemCommand()
        {
        }

        public SystemCommand(object[] items)
        {
            CommandNode = (string)items[0];
        }

        public SystemCommand(string CommandNode)
        {
            this.CommandNode = CommandNode;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandNode };
        }

        public override void SetItemArray(object[] items)
        {
            CommandNode = (string)items[0];
        }
    }

    [SqlRecord("WF", "SystemCommandSubmission")]
    public partial class SystemCommandSubmission : SqlTableTypeProxy<SystemCommandSubmission>, ISystemCommand, ISystemCommandSubmission
    {
        [SqlColumn("SourceNodeId", 0), SqlTypeFacets("nvarchar", false)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("CommandNode", 1), SqlTypeFacets("nvarchar", false)]
        public string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("TargetSystemId", 2), SqlTypeFacets("nvarchar", false)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 3), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 4), SqlTypeFacets("nvarchar", true)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 5), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SystemCommandSubmission()
        {
        }

        public SystemCommandSubmission(object[] items)
        {
            SourceNodeId = (string)items[0];
            CommandNode = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }

        public SystemCommandSubmission(string SourceNodeId, string CommandNode, string TargetSystemId, string CommandUri, string CommandBody, string CorrelationToken)
        {
            this.SourceNodeId = SourceNodeId;
            this.CommandNode = CommandNode;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceNodeId, CommandNode, TargetSystemId, CommandUri, CommandBody, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            SourceNodeId = (string)items[0];
            CommandNode = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }
    }

    /// <summary>
    /// Represents something of interest that occurred on an identified host
    /// </summary>
    [SqlRecord("WF", "SystemEvent")]
    public partial class SystemEvent : SqlTableTypeProxy<SystemEvent>, ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        public string HostId
        {
            get;
            set;
        }

        public SystemEvent()
        {
        }

        public SystemEvent(object[] items)
        {
            HostId = (string)items[0];
        }

        public SystemEvent(string HostId)
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

    [SqlRecord("WF", "SystemEventCapture")]
    public partial class SystemEventCapture : SqlTableTypeProxy<SystemEventCapture>, ISystemEventCapture
    {
        [SqlColumn("EventTS", 0), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("EventId", 1), SqlTypeFacets("uniqueidentifier", false)]
        public Guid EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 2), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? PairId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 3), SqlTypeFacets("nvarchar", false)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 4), SqlTypeFacets("nvarchar", false)]
        public string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventType", 5), SqlTypeFacets("nvarchar", false)]
        public string EventType
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 6), SqlTypeFacets("nvarchar", false)]
        public string EventUri
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 7), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("SeverityLevel", 8), SqlTypeFacets("int", false)]
        public int SeverityLevel
        {
            get;
            set;
        }

        [SqlColumn("EventBody", 9), SqlTypeFacets("nvarchar", true)]
        public string EventBody
        {
            get;
            set;
        }

        public SystemEventCapture()
        {
        }

        public SystemEventCapture(object[] items)
        {
            EventTS = (DateTime)items[0];
            EventId = (Guid)items[1];
            PairId = (Guid?)items[2];
            SourceNodeId = (string)items[3];
            SourceSystemId = (string)items[4];
            EventType = (string)items[5];
            EventUri = (string)items[6];
            CorrelationToken = (string)items[7];
            SeverityLevel = (int)items[8];
            EventBody = (string)items[9];
        }

        public SystemEventCapture(DateTime EventTS, Guid EventId, Guid? PairId, string SourceNodeId, string SourceSystemId, string EventType, string EventUri, string CorrelationToken, int SeverityLevel, string EventBody)
        {
            this.EventTS = EventTS;
            this.EventId = EventId;
            this.PairId = PairId;
            this.SourceNodeId = SourceNodeId;
            this.SourceSystemId = SourceSystemId;
            this.EventType = EventType;
            this.EventUri = EventUri;
            this.CorrelationToken = CorrelationToken;
            this.SeverityLevel = SeverityLevel;
            this.EventBody = EventBody;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EventTS, EventId, PairId, SourceNodeId, SourceSystemId, EventType, EventUri, CorrelationToken, SeverityLevel, EventBody };
        }

        public override void SetItemArray(object[] items)
        {
            EventTS = (DateTime)items[0];
            EventId = (Guid)items[1];
            PairId = (Guid?)items[2];
            SourceNodeId = (string)items[3];
            SourceSystemId = (string)items[4];
            EventType = (string)items[5];
            EventUri = (string)items[6];
            CorrelationToken = (string)items[7];
            SeverityLevel = (int)items[8];
            EventBody = (string)items[9];
        }
    }

    [SqlRecord("WF", "SystemEventIdentity")]
    public partial class SystemEventIdentity : SqlTableTypeProxy<SystemEventIdentity>, ISqlTableTypeProxy, ISystemEventIdentity
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", false)]
        public Guid EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 1), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? PairId
        {
            get;
            set;
        }

        public SystemEventIdentity()
        {
        }

        public SystemEventIdentity(object[] items)
        {
            EventId = (Guid)items[0];
            PairId = (Guid?)items[1];
        }

        public SystemEventIdentity(Guid EventId, Guid? PairId)
        {
            this.EventId = EventId;
            this.PairId = PairId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EventId, PairId };
        }

        public override void SetItemArray(object[] items)
        {
            EventId = (Guid)items[0];
            PairId = (Guid?)items[1];
        }
    }

    [SqlRecord("WF", "SystemNotification")]
    public partial class SystemNotification : SqlTableTypeProxy<SystemNotification>, ISystemNotification
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 1), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? PairId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 2), SqlTypeFacets("nvarchar", false)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 3), SqlTypeFacets("nvarchar", false)]
        public string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventType", 4), SqlTypeFacets("nvarchar", false)]
        public string EventType
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 5), SqlTypeFacets("nvarchar", false)]
        public string EventUri
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 6), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("SeverityLevel", 7), SqlTypeFacets("int", false)]
        public int SeverityLevel
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 8), SqlTypeFacets("datetime2", false)]
        public DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("EventBody", 9), SqlTypeFacets("nvarchar", true)]
        public string EventBody
        {
            get;
            set;
        }

        [SqlColumn("FormattedMessage", 10), SqlTypeFacets("nvarchar", false)]
        public string FormattedMessage
        {
            get;
            set;
        }

        public SystemNotification()
        {
        }

        public SystemNotification(object[] items)
        {
            EventId = (Guid?)items[0];
            PairId = (Guid?)items[1];
            SourceNodeId = (string)items[2];
            SourceSystemId = (string)items[3];
            EventType = (string)items[4];
            EventUri = (string)items[5];
            CorrelationToken = (string)items[6];
            SeverityLevel = (int)items[7];
            EventTS = (DateTime)items[8];
            EventBody = (string)items[9];
            FormattedMessage = (string)items[10];
        }

        public SystemNotification(Guid? EventId, Guid? PairId, string SourceNodeId, string SourceSystemId, string EventType, string EventUri, string CorrelationToken, int SeverityLevel, DateTime EventTS, string EventBody, string FormattedMessage)
        {
            this.EventId = EventId;
            this.PairId = PairId;
            this.SourceNodeId = SourceNodeId;
            this.SourceSystemId = SourceSystemId;
            this.EventType = EventType;
            this.EventUri = EventUri;
            this.CorrelationToken = CorrelationToken;
            this.SeverityLevel = SeverityLevel;
            this.EventTS = EventTS;
            this.EventBody = EventBody;
            this.FormattedMessage = FormattedMessage;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EventId, PairId, SourceNodeId, SourceSystemId, EventType, EventUri, CorrelationToken, SeverityLevel, EventTS, EventBody, FormattedMessage };
        }

        public override void SetItemArray(object[] items)
        {
            EventId = (Guid?)items[0];
            PairId = (Guid?)items[1];
            SourceNodeId = (string)items[2];
            SourceSystemId = (string)items[3];
            EventType = (string)items[4];
            EventUri = (string)items[5];
            CorrelationToken = (string)items[6];
            SeverityLevel = (int)items[7];
            EventTS = (DateTime)items[8];
            EventBody = (string)items[9];
            FormattedMessage = (string)items[10];
        }
    }

    [SqlRecord("WF", "SystemReaction")]
    public partial class SystemReaction : SqlTableTypeProxy<SystemReaction>, ISystemReaction
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? EventId
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

        [SqlColumn("SourceSystemId", 2), SqlTypeFacets("nvarchar", false)]
        public string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 3), SqlTypeFacets("nvarchar", false)]
        public string EventUri
        {
            get;
            set;
        }

        [SqlColumn("StartedTS", 4), SqlTypeFacets("datetime2", false)]
        public DateTime StartedTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 5), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 6), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 7), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 8), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        public SystemReaction()
        {
        }

        public SystemReaction(object[] items)
        {
            EventId = (Guid?)items[0];
            SourceNodeId = (string)items[1];
            SourceSystemId = (string)items[2];
            EventUri = (string)items[3];
            StartedTS = (DateTime)items[4];
            Completed = (bool)items[5];
            CompleteTS = (DateTime?)items[6];
            Succeeded = (bool)items[7];
            ResultDescription = (string)items[8];
        }

        public SystemReaction(Guid? EventId, string SourceNodeId, string SourceSystemId, string EventUri, DateTime StartedTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription)
        {
            this.EventId = EventId;
            this.SourceNodeId = SourceNodeId;
            this.SourceSystemId = SourceSystemId;
            this.EventUri = EventUri;
            this.StartedTS = StartedTS;
            this.Completed = Completed;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EventId, SourceNodeId, SourceSystemId, EventUri, StartedTS, Completed, CompleteTS, Succeeded, ResultDescription };
        }

        public override void SetItemArray(object[] items)
        {
            EventId = (Guid?)items[0];
            SourceNodeId = (string)items[1];
            SourceSystemId = (string)items[2];
            EventUri = (string)items[3];
            StartedTS = (DateTime)items[4];
            Completed = (bool)items[5];
            CompleteTS = (DateTime?)items[6];
            Succeeded = (bool)items[7];
            ResultDescription = (string)items[8];
        }
    }

    [SqlRecord("WF", "SystemTask")]
    public partial class SystemTask : SqlTableTypeProxy<SystemTask>, IWorkflowTask, ISystemTask
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 7), SqlTypeFacets("datetime2", true)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SystemTask()
        {
        }

        public SystemTask(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            SubmittedTS = (DateTime)items[6];
            DispatchTS = (DateTime?)items[7];
            CorrelationToken = (string)items[8];
        }

        public SystemTask(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, DateTime SubmittedTS, DateTime? DispatchTS, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.SubmittedTS = SubmittedTS;
            this.DispatchTS = DispatchTS;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, SubmittedTS, DispatchTS, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            SubmittedTS = (DateTime)items[6];
            DispatchTS = (DateTime?)items[7];
            CorrelationToken = (string)items[8];
        }
    }

    [SqlRecord("WF", "SystemTaskDefinition")]
    public partial class SystemTaskDefinition : SqlTableTypeProxy<SystemTaskDefinition>, IWorkflowTask, ISystemTaskDefinition
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("DefinedTS", 6), SqlTypeFacets("datetime2", false)]
        public DateTime DefinedTS
        {
            get;
            set;
        }

        [SqlColumn("Enqueued", 7), SqlTypeFacets("bit", false)]
        public bool Enqueued
        {
            get;
            set;
        }

        [SqlColumn("EnqueuedTS", 8), SqlTypeFacets("datetime2", true)]
        public DateTime? EnqueuedTS
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 9), SqlTypeFacets("nvarchar", false)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SystemTaskDefinition()
        {
        }

        public SystemTaskDefinition(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            DefinedTS = (DateTime)items[6];
            Enqueued = (bool)items[7];
            EnqueuedTS = (DateTime?)items[8];
            CorrelationToken = (string)items[9];
        }

        public SystemTaskDefinition(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, DateTime DefinedTS, bool Enqueued, DateTime? EnqueuedTS, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.DefinedTS = DefinedTS;
            this.Enqueued = Enqueued;
            this.EnqueuedTS = EnqueuedTS;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, DefinedTS, Enqueued, EnqueuedTS, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            DefinedTS = (DateTime)items[6];
            Enqueued = (bool)items[7];
            EnqueuedTS = (DateTime?)items[8];
            CorrelationToken = (string)items[9];
        }
    }

    /// <summary>
    /// Represents something of interest that occurred during an identified task
    /// </summary>
    [SqlRecord("WF", "SystemTaskEvent")]
    public partial class SystemTaskEvent : SqlTableTypeProxy<SystemTaskEvent>, ISystemEvent, ISystemTaskEvent
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

        public SystemTaskEvent()
        {
        }

        public SystemTaskEvent(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
        }

        public SystemTaskEvent(string HostId, long TaskId)
        {
            this.HostId = HostId;
            this.TaskId = TaskId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, TaskId };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            TaskId = (long)items[1];
        }
    }

    [SqlRecord("WF", "SystemTaskResult")]
    public partial class SystemTaskResult : SqlTableTypeProxy<SystemTaskResult>, ITaskResult, ISystemTaskResult
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
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

        [SqlColumn("Succeeded", 3), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 4), SqlTypeFacets("nvarchar", true)]
        public string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 5), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 6), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SystemTaskResult()
        {
        }

        public SystemTaskResult(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            Succeeded = (bool)items[3];
            ResultBody = (string)items[4];
            ResultDescription = (string)items[5];
            CorrelationToken = (string)items[6];
        }

        public SystemTaskResult(long TaskId, string SourceNodeId, string TargetNodeId, bool Succeeded, string ResultBody, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.Succeeded = Succeeded;
            this.ResultBody = ResultBody;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, Succeeded, ResultBody, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            Succeeded = (bool)items[3];
            ResultBody = (string)items[4];
            ResultDescription = (string)items[5];
            CorrelationToken = (string)items[6];
        }
    }

    [SqlRecord("WF", "SystemTaskState")]
    public partial class SystemTaskState : SqlTableTypeProxy<SystemTaskState>, ITaskState, ISystemTaskState
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 6), SqlTypeFacets("nvarchar", true)]
        public string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 7), SqlTypeFacets("datetime2", false)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 8), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 9), SqlTypeFacets("datetime2", true)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 10), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 11), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 12), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 13), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 14), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SystemTaskState()
        {
        }

        public SystemTaskState(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            ResultBody = (string)items[6];
            SubmittedTS = (DateTime)items[7];
            Dispatched = (bool)items[8];
            DispatchTS = (DateTime?)items[9];
            Completed = (bool)items[10];
            CompleteTS = (DateTime?)items[11];
            Succeeded = (bool)items[12];
            ResultDescription = (string)items[13];
            CorrelationToken = (string)items[14];
        }

        public SystemTaskState(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, string ResultBody, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.ResultBody = ResultBody;
            this.SubmittedTS = SubmittedTS;
            this.Dispatched = Dispatched;
            this.DispatchTS = DispatchTS;
            this.Completed = Completed;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, ResultBody, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SourceNodeId = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystemId = (string)items[3];
            CommandUri = (string)items[4];
            CommandBody = (string)items[5];
            ResultBody = (string)items[6];
            SubmittedTS = (DateTime)items[7];
            Dispatched = (bool)items[8];
            DispatchTS = (DateTime?)items[9];
            Completed = (bool)items[10];
            CompleteTS = (DateTime?)items[11];
            Succeeded = (bool)items[12];
            ResultDescription = (string)items[13];
            CorrelationToken = (string)items[14];
        }
    }

    [SqlRecord("WF", "TaskArchive")]
    public partial class TaskArchive : SqlTableTypeProxy<TaskArchive>, ITaskArchive
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public TaskArchive()
        {
        }

        public TaskArchive(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }

        public TaskArchive(long TaskId, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SubmittedTS = SubmittedTS;
            this.Dispatched = Dispatched;
            this.DispatchTS = DispatchTS;
            this.Completed = Completed;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }
    }

    [SqlRecord("WF", "TaskQueue")]
    public partial class TaskQueue : SqlTableTypeProxy<TaskQueue>, ITaskQueue
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public TaskQueue()
        {
        }

        public TaskQueue(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }

        public TaskQueue(long TaskId, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SubmittedTS = SubmittedTS;
            this.Dispatched = Dispatched;
            this.DispatchTS = DispatchTS;
            this.Completed = Completed;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }
    }

    [SqlRecord("WF", "TaskResult")]
    public partial class TaskResult : SqlTableTypeProxy<TaskResult>, ITaskResult
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 1), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 2), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public TaskResult()
        {
        }

        public TaskResult(object[] items)
        {
            TaskId = (long)items[0];
            Succeeded = (bool)items[1];
            ResultDescription = (string)items[2];
            CorrelationToken = (string)items[3];
        }

        public TaskResult(long TaskId, bool Succeeded, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, Succeeded, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            Succeeded = (bool)items[1];
            ResultDescription = (string)items[2];
            CorrelationToken = (string)items[3];
        }
    }

    [SqlRecord("WF", "TaskState")]
    public partial class TaskState : SqlTableTypeProxy<TaskState>, ITaskState
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        public DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public TaskState()
        {
        }

        public TaskState(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }

        public TaskState(long TaskId, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.SubmittedTS = SubmittedTS;
            this.Dispatched = Dispatched;
            this.DispatchTS = DispatchTS;
            this.Completed = Completed;
            this.CompleteTS = CompleteTS;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            SubmittedTS = (DateTime)items[1];
            Dispatched = (bool)items[2];
            DispatchTS = (DateTime?)items[3];
            Completed = (bool)items[4];
            CompleteTS = (DateTime?)items[5];
            Succeeded = (bool)items[6];
            ResultDescription = (string)items[7];
            CorrelationToken = (string)items[8];
        }
    }

    [SqlRecord("WF", "WorkflowOptions")]
    public partial class WorkflowOptions : SqlTableTypeProxy<WorkflowOptions>, IWorkflowOptions
    {
        [SqlColumn("BatchSize", 0), SqlTypeFacets("int", true)]
        public int? BatchSize
        {
            get;
            set;
        }

        [SqlColumn("PLL", 1), SqlTypeFacets("bit", false)]
        public bool PLL
        {
            get;
            set;
        }

        public WorkflowOptions()
        {
        }

        public WorkflowOptions(object[] items)
        {
            BatchSize = (int?)items[0];
            PLL = (bool)items[1];
        }

        public WorkflowOptions(int? BatchSize, bool PLL)
        {
            this.BatchSize = BatchSize;
            this.PLL = PLL;
        }

        public override object[] GetItemArray()
        {
            return new object[] { BatchSize, PLL };
        }

        public override void SetItemArray(object[] items)
        {
            BatchSize = (int?)items[0];
            PLL = (bool)items[1];
        }
    }

    [SqlRecord("WF", "WorkflowTask")]
    public partial class WorkflowTask : SqlTableTypeProxy<WorkflowTask>, IWorkflowTask
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 1), SqlTypeFacets("nvarchar", true)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public WorkflowTask()
        {
        }

        public WorkflowTask(object[] items)
        {
            TaskId = (long)items[0];
            CorrelationToken = (string)items[1];
        }

        public WorkflowTask(long TaskId, string CorrelationToken)
        {
            this.TaskId = TaskId;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            CorrelationToken = (string)items[1];
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IAgentCommand
    {
        [SqlColumn("CommandId", 0), SqlTypeFacets("bigint", false)]
        long CommandId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
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

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 4), SqlTypeFacets("nvarchar", false)]
        string AgentId
        {
            get;
            set;
        }

        [SqlColumn("CommandName", 5), SqlTypeFacets("nvarchar", false)]
        string CommandName
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 6), SqlTypeFacets("nvarchar", true)]
        string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 7), SqlTypeFacets("nvarchar", true)]
        string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 8), SqlTypeFacets("nvarchar", true)]
        string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 9), SqlTypeFacets("nvarchar", true)]
        string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 10), SqlTypeFacets("nvarchar", true)]
        string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 11), SqlTypeFacets("nvarchar", true)]
        string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 12), SqlTypeFacets("nvarchar", true)]
        string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 13), SqlTypeFacets("nvarchar", true)]
        string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 14), SqlTypeFacets("nvarchar", true)]
        string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 15), SqlTypeFacets("nvarchar", true)]
        string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 16), SqlTypeFacets("nvarchar", true)]
        string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 17), SqlTypeFacets("nvarchar", true)]
        string Arg6Value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IAgentConfiguration
    {
        [SqlColumn("AgentId", 0), SqlTypeFacets("nvarchar", false)]
        string AgentId
        {
            get;
            set;
        }

        [SqlColumn("IsEnabled", 1), SqlTypeFacets("bit", false)]
        bool IsEnabled
        {
            get;
            set;
        }

        [SqlColumn("SpinFrequency", 2), SqlTypeFacets("int", false)]
        int SpinFrequency
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IAgentControlCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        string CommandNode
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
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IAgentStatus
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
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

        [SqlColumn("AgentId", 2), SqlTypeFacets("nvarchar", false)]
        string AgentId
        {
            get;
            set;
        }

        [SqlColumn("AgentState", 3), SqlTypeFacets("nvarchar", false)]
        string AgentState
        {
            get;
            set;
        }

        [SqlColumn("StatusSummary", 4), SqlTypeFacets("nvarchar", true)]
        string StatusSummary
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IArchiveOperator
    {
        [SqlColumn("ResetOutstanding", 0), SqlTypeFacets("bit", true)]
        bool? ResetOutstanding
        {
            get;
            set;
        }

        [SqlColumn("RetryFailures", 1), SqlTypeFacets("bit", true)]
        bool? RetryFailures
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IBatchCompletion
    {
        [SqlColumn("BatchNumber", 0), SqlTypeFacets("int", false)]
        int BatchNumber
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 1), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 2), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("BatchMessage", 3), SqlTypeFacets("nvarchar", true)]
        string BatchMessage
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ICommandSpecifier
    {
        [SqlColumn("CommandName", 0), SqlTypeFacets("nvarchar", false)]
        string CommandName
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystem", 2), SqlTypeFacets("nvarchar", false)]
        string TargetSystem
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ICommandTableEntry
    {
        [SqlColumn("CommandName", 0), SqlTypeFacets("nvarchar", false)]
        string CommandName
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystem", 2), SqlTypeFacets("nvarchar", false)]
        string TargetSystem
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 4), SqlTypeFacets("nvarchar", true)]
        string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 5), SqlTypeFacets("nvarchar", true)]
        string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 6), SqlTypeFacets("nvarchar", true)]
        string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 7), SqlTypeFacets("nvarchar", true)]
        string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 8), SqlTypeFacets("nvarchar", true)]
        string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 9), SqlTypeFacets("nvarchar", true)]
        string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 10), SqlTypeFacets("nvarchar", true)]
        string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 11), SqlTypeFacets("nvarchar", true)]
        string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 12), SqlTypeFacets("nvarchar", true)]
        string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 13), SqlTypeFacets("nvarchar", true)]
        string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 14), SqlTypeFacets("nvarchar", true)]
        string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 15), SqlTypeFacets("nvarchar", true)]
        string Arg6Value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ICompletionOperator
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", true)]
        long? TaskId
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 1), SqlTypeFacets("bit", true)]
        bool? Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 2), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IDequeueOperator
    {
        [SqlColumn("MaxCount", 0), SqlTypeFacets("int", true)]
        int? MaxCount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IEnqueueOperator
    {
        [SqlColumn("CorrelationToken", 0), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMergeAction
    {
        [SqlColumn("ActionName", 0), SqlTypeFacets("varchar", true)]
        string ActionName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IMergeActionCount
    {
        [SqlColumn("InsertCount", 0), SqlTypeFacets("int", false)]
        int InsertCount
        {
            get;
            set;
        }

        [SqlColumn("UpdateCount", 1), SqlTypeFacets("int", false)]
        int UpdateCount
        {
            get;
            set;
        }

        [SqlColumn("DeleteCount", 2), SqlTypeFacets("int", false)]
        int DeleteCount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPeekOperator
    {
        [SqlColumn("MaxCount", 0), SqlTypeFacets("int", true)]
        int? MaxCount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IProcessingBatch
    {
        [SqlColumn("BatchNumber", 0), SqlTypeFacets("int", false)]
        int BatchNumber
        {
            get;
            set;
        }

        [SqlColumn("MinKey", 1), SqlTypeFacets("bigint", false)]
        long MinKey
        {
            get;
            set;
        }

        [SqlColumn("MaxKey", 2), SqlTypeFacets("bigint", false)]
        long MaxKey
        {
            get;
            set;
        }

        [SqlColumn("EnqueuedTS", 3), SqlTypeFacets("datetime2", false)]
        DateTime EnqueuedTS
        {
            get;
            set;
        }

        [SqlColumn("Dequeued", 4), SqlTypeFacets("bit", false)]
        bool Dequeued
        {
            get;
            set;
        }

        [SqlColumn("DequeuedTS", 5), SqlTypeFacets("datetime2", true)]
        DateTime? DequeuedTS
        {
            get;
            set;
        }

        [SqlColumn("Complete", 6), SqlTypeFacets("bit", false)]
        bool Complete
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 7), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 8), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("BatchMessage", 9), SqlTypeFacets("nvarchar", true)]
        string BatchMessage
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemCommand
    {
        [SqlColumn("CommandNode", 0), SqlTypeFacets("nvarchar", false)]
        string CommandNode
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemCommandSubmission
    {
        [SqlColumn("SourceNodeId", 0), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("CommandNode", 1), SqlTypeFacets("nvarchar", false)]
        string CommandNode
        {
            get;
            set;
        }

        [SqlColumn("TargetSystemId", 2), SqlTypeFacets("nvarchar", false)]
        string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 3), SqlTypeFacets("nvarchar", false)]
        string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 4), SqlTypeFacets("nvarchar", true)]
        string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 5), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        string HostId
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemEventCapture
    {
        [SqlColumn("EventTS", 0), SqlTypeFacets("datetime2", false)]
        DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("EventId", 1), SqlTypeFacets("uniqueidentifier", false)]
        Guid EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 2), SqlTypeFacets("uniqueidentifier", true)]
        Guid? PairId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 3), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 4), SqlTypeFacets("nvarchar", false)]
        string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventType", 5), SqlTypeFacets("nvarchar", false)]
        string EventType
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 6), SqlTypeFacets("nvarchar", false)]
        string EventUri
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 7), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("SeverityLevel", 8), SqlTypeFacets("int", false)]
        int SeverityLevel
        {
            get;
            set;
        }

        [SqlColumn("EventBody", 9), SqlTypeFacets("nvarchar", true)]
        string EventBody
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemEventIdentity
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", false)]
        Guid EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 1), SqlTypeFacets("uniqueidentifier", true)]
        Guid? PairId
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemNotification
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", true)]
        Guid? EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 1), SqlTypeFacets("uniqueidentifier", true)]
        Guid? PairId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 2), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 3), SqlTypeFacets("nvarchar", false)]
        string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventType", 4), SqlTypeFacets("nvarchar", false)]
        string EventType
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 5), SqlTypeFacets("nvarchar", false)]
        string EventUri
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 6), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("SeverityLevel", 7), SqlTypeFacets("int", false)]
        int SeverityLevel
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 8), SqlTypeFacets("datetime2", false)]
        DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("EventBody", 9), SqlTypeFacets("nvarchar", true)]
        string EventBody
        {
            get;
            set;
        }

        [SqlColumn("FormattedMessage", 10), SqlTypeFacets("nvarchar", false)]
        string FormattedMessage
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemReaction
    {
        [SqlColumn("EventId", 0), SqlTypeFacets("uniqueidentifier", true)]
        Guid? EventId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 2), SqlTypeFacets("nvarchar", false)]
        string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 3), SqlTypeFacets("nvarchar", false)]
        string EventUri
        {
            get;
            set;
        }

        [SqlColumn("StartedTS", 4), SqlTypeFacets("datetime2", false)]
        DateTime StartedTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 5), SqlTypeFacets("bit", false)]
        bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 6), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 7), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 8), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemTask
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 6), SqlTypeFacets("datetime2", false)]
        DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 7), SqlTypeFacets("datetime2", true)]
        DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemTaskDefinition
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("DefinedTS", 6), SqlTypeFacets("datetime2", false)]
        DateTime DefinedTS
        {
            get;
            set;
        }

        [SqlColumn("Enqueued", 7), SqlTypeFacets("bit", false)]
        bool Enqueued
        {
            get;
            set;
        }

        [SqlColumn("EnqueuedTS", 8), SqlTypeFacets("datetime2", true)]
        DateTime? EnqueuedTS
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 9), SqlTypeFacets("nvarchar", false)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemTaskEvent
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false)]
        new string HostId
        {
            get;
            set;
        }

        [SqlColumn("TaskId", 1), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemTaskResult
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
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

        [SqlColumn("Succeeded", 3), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 4), SqlTypeFacets("nvarchar", true)]
        string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 5), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 6), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ISystemTaskState
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false)]
        string SourceNodeId
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

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false)]
        string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false)]
        string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true)]
        string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 6), SqlTypeFacets("nvarchar", true)]
        string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 7), SqlTypeFacets("datetime2", false)]
        DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 8), SqlTypeFacets("bit", false)]
        bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 9), SqlTypeFacets("datetime2", true)]
        DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 10), SqlTypeFacets("bit", false)]
        bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 11), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 12), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 13), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 14), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITaskArchive
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITaskQueue
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITaskResult
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 1), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 2), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface ITaskState
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 1), SqlTypeFacets("datetime2", false)]
        DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 2), SqlTypeFacets("bit", false)]
        bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 3), SqlTypeFacets("datetime2", true)]
        DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 4), SqlTypeFacets("bit", false)]
        bool Completed
        {
            get;
            set;
        }

        [SqlColumn("CompleteTS", 5), SqlTypeFacets("datetime2", true)]
        DateTime? CompleteTS
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 6), SqlTypeFacets("bit", false)]
        bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("ResultDescription", 7), SqlTypeFacets("nvarchar", true)]
        string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IWorkflowOptions
    {
        [SqlColumn("BatchSize", 0), SqlTypeFacets("int", true)]
        int? BatchSize
        {
            get;
            set;
        }

        [SqlColumn("PLL", 1), SqlTypeFacets("bit", false)]
        bool PLL
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the WF schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IWorkflowTask
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        long TaskId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 1), SqlTypeFacets("nvarchar", true)]
        string CorrelationToken
        {
            get;
            set;
        }
    }
}
// Emission concluded at 7/9/2018 7:22:03 PM
