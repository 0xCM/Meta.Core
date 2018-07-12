//This file was generated at 4/23/2018 10:03:17 PM using version 1.2018.3.36060 the SqT data access toolset.
namespace MetaFlow.Proxies.WF
{
    using MetaFlow.Core;
    using MetaFlow.WF;
    using SqlT.Types;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class WFTableFunctionNames
    {
        public readonly static SqlFunctionName AgentConfigurations = "[WF].[AgentConfigurations]";
        public readonly static SqlFunctionName ParseCommandArgument = "[WF].[ParseCommandArgument]";
        public readonly static SqlFunctionName ParseCommandBody = "[WF].[ParseCommandBody]";
        public readonly static SqlFunctionName PendingSystemTasks = "[WF].[PendingSystemTasks]";
        public readonly static SqlFunctionName SystemTaskStates = "[WF].[SystemTaskStates]";
    }

    public sealed class WFTableNames
    {
        public readonly static SqlTableName AgentCommandArchive = "[WF].[AgentCommandArchive]";
        public readonly static SqlTableName AgentCommandQueue = "[WF].[AgentCommandQueue]";
        public readonly static SqlTableName AgentConfigurationStore = "[WF].[AgentConfigurationStore]";
        public readonly static SqlTableName AgentStatusHistory = "[WF].[AgentStatusHistory]";
        public readonly static SqlTableName AgentStatusLog = "[WF].[AgentStatusLog]";
        public readonly static SqlTableName CommandTable = "[WF].[CommandTable]";
        public readonly static SqlTableName ControlFlow = "[WF].[ControlFlow]";
        public readonly static SqlTableName ControlOperationType = "[WF].[ControlOperationType]";
        public readonly static SqlTableName EvaulatorType = "[WF].[EvaulatorType]";
        public readonly static SqlTableName StepDefinition = "[WF].[StepDefinition]";
        public readonly static SqlTableName StepType = "[WF].[StepType]";
        public readonly static SqlTableName SystemEventStore = "[WF].[SystemEventStore]";
        public readonly static SqlTableName SystemTaskArchive = "[WF].[SystemTaskArchive]";
        public readonly static SqlTableName SystemTaskDefinitionStore = "[WF].[SystemTaskDefinitionStore]";
        public readonly static SqlTableName SystemTaskQueue = "[WF].[SystemTaskQueue]";
        public readonly static SqlTableName WorkflowDefinition = "[WF].[WorkflowDefinition]";
    }

    public sealed class WFViewNames
    {
        public readonly static SqlViewName AgentStatusSummary = "[WF].[AgentStatusSummary]";
    }

    public sealed class WFProcedureNames
    {
        public readonly static SqlProcedureName ArchiveSystemTasks = "[WF].[ArchiveSystemTasks]";
        public readonly static SqlProcedureName CompleteAgentCommand = "[WF].[CompleteAgentCommand]";
        public readonly static SqlProcedureName CompleteSystemTask = "[WF].[CompleteSystemTask]";
        public readonly static SqlProcedureName DefineSystemTask = "[WF].[DefineSystemTask]";
        public readonly static SqlProcedureName DispatchAgentCommands = "[WF].[DispatchAgentCommands]";
        public readonly static SqlProcedureName DispatchSystemTasks = "[WF].[DispatchSystemTasks]";
        public readonly static SqlProcedureName DispatchSystemTasksByName = "[WF].[DispatchSystemTasksByName]";
        public readonly static SqlProcedureName LogAgentStatus = "[WF].[LogAgentStatus]";
        public readonly static SqlProcedureName RaiseSystemEvent = "[WF].[RaiseSystemEvent]";
        public readonly static SqlProcedureName StoreAgentConfigurations = "[WF].[StoreAgentConfigurations]";
        public readonly static SqlProcedureName SubmitAgentCommand = "[WF].[SubmitAgentCommand]";
        public readonly static SqlProcedureName SubmitSystemCommand = "[WF].[SubmitSystemCommand]";
        public readonly static SqlProcedureName SubmitSystemCommands = "[WF].[SubmitSystemCommands]";
    }

    [SqlTableFunction("WF", "AgentConfigurations")]
    public partial class AgentConfigurations : SqlTableFunctionProxy<AgentConfigurations, AgentConfiguration>
    {
        public AgentConfigurations()
        {
        }
    }

    [SqlTableFunctionResult("WF", "ParseCommandBody")]
    public partial class ParseCommandBodyResult : SqlTabularProxy
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("ArgName", 1), SqlTypeFacets("nvarchar", true, 150)]
        public string ArgName
        {
            get;
            set;
        }

        [SqlColumn("ArgValue", 2), SqlTypeFacets("nvarchar", true, 500)]
        public string ArgValue
        {
            get;
            set;
        }

        public ParseCommandBodyResult()
        {
        }

        public ParseCommandBodyResult(object[] items)
        {
            TaskId = (long)items[0];
            ArgName = (string)items[1];
            ArgValue = (string)items[2];
        }

        public ParseCommandBodyResult(long TaskId, string ArgName, string ArgValue)
        {
            this.TaskId = TaskId;
            this.ArgName = ArgName;
            this.ArgValue = ArgValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, ArgName, ArgValue };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long)items[0];
            ArgName = (string)items[1];
            ArgValue = (string)items[2];
        }
    }

    [SqlTableFunction("WF", "ParseCommandBody")]
    public partial class ParseCommandBody : SqlTableFunctionProxy<ParseCommandBody, ParseCommandBodyResult>
    {
        [SqlParameter("@TaskId", 0, false, false), SqlTypeFacets("bigint", true)]
        public long? TaskId
        {
            get;
            set;
        }

        public ParseCommandBody()
        {
        }

        public ParseCommandBody(object[] items)
        {
            TaskId = (long?)items[0];
        }

        public ParseCommandBody(long? TaskId)
        {
            this.TaskId = TaskId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long?)items[0];
        }
    }

    [SqlTableFunctionResult("WF", "ParseCommandArgument")]
    public partial class ParseCommandArgumentResult : SqlTabularProxy
    {
        [SqlColumn("ArgName", 0), SqlTypeFacets("nvarchar", true, 150)]
        public string ArgName
        {
            get;
            set;
        }

        [SqlColumn("ArgValue", 1), SqlTypeFacets("nvarchar", true, 500)]
        public string ArgValue
        {
            get;
            set;
        }

        public ParseCommandArgumentResult()
        {
        }

        public ParseCommandArgumentResult(object[] items)
        {
            ArgName = (string)items[0];
            ArgValue = (string)items[1];
        }

        public ParseCommandArgumentResult(string ArgName, string ArgValue)
        {
            this.ArgName = ArgName;
            this.ArgValue = ArgValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ArgName, ArgValue };
        }

        public override void SetItemArray(object[] items)
        {
            ArgName = (string)items[0];
            ArgValue = (string)items[1];
        }
    }

    [SqlTableFunction("WF", "ParseCommandArgument")]
    public partial class ParseCommandArgument : SqlTableFunctionProxy<ParseCommandArgument, ParseCommandArgumentResult>
    {
        [SqlParameter("@ArgumentJson", 0, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string ArgumentJson
        {
            get;
            set;
        }

        public ParseCommandArgument()
        {
        }

        public ParseCommandArgument(object[] items)
        {
            ArgumentJson = (string)items[0];
        }

        public ParseCommandArgument(string ArgumentJson)
        {
            this.ArgumentJson = ArgumentJson;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ArgumentJson };
        }

        public override void SetItemArray(object[] items)
        {
            ArgumentJson = (string)items[0];
        }
    }

    [SqlTableFunction("WF", "SystemTaskStates")]
    public partial class SystemTaskStates : SqlTableFunctionProxy<SystemTaskStates, SystemTaskState>
    {
        public SystemTaskStates()
        {
        }
    }

    [SqlTableFunction("WF", "PendingSystemTasks")]
    public partial class PendingSystemTasks : SqlTableFunctionProxy<PendingSystemTasks, SystemTask>
    {
        public PendingSystemTasks()
        {
        }
    }

    [SqlView("WF", "AgentStatusSummary")]
    public partial class AgentStatusSummary : SqlViewProxy
    {
        [SqlColumn("HostId", 0), SqlTypeFacets("nvarchar", false, 150)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("AgentState", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentState
        {
            get;
            set;
        }

        [SqlColumn("StatusSummary", 4), SqlTypeFacets("nvarchar", true, 8000)]
        public string StatusSummary
        {
            get;
            set;
        }

        [SqlColumn("AsOfTS", 5), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime AsOfTS
        {
            get;
            set;
        }

        [SqlColumn("Pulse", 6), SqlTypeFacets("int", true)]
        public int? Pulse
        {
            get;
            set;
        }

        public AgentStatusSummary()
        {
        }

        public AgentStatusSummary(object[] items)
        {
            HostId = (string)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
            AgentState = (string)items[3];
            StatusSummary = (string)items[4];
            AsOfTS = (DateTime)items[5];
            Pulse = (int?)items[6];
        }

        public AgentStatusSummary(string HostId, string SystemId, string AgentId, string AgentState, string StatusSummary, DateTime AsOfTS, int? Pulse)
        {
            this.HostId = HostId;
            this.SystemId = SystemId;
            this.AgentId = AgentId;
            this.AgentState = AgentState;
            this.StatusSummary = StatusSummary;
            this.AsOfTS = AsOfTS;
            this.Pulse = Pulse;
        }

        public override object[] GetItemArray()
        {
            return new object[] { HostId, SystemId, AgentId, AgentState, StatusSummary, AsOfTS, Pulse };
        }

        public override void SetItemArray(object[] items)
        {
            HostId = (string)items[0];
            SystemId = (string)items[1];
            AgentId = (string)items[2];
            AgentState = (string)items[3];
            StatusSummary = (string)items[4];
            AsOfTS = (DateTime)items[5];
            Pulse = (int?)items[6];
        }
    }

    [SqlProcedure("WF", "SubmitAgentCommand")]
    public partial class SubmitAgentCommand : SqlProcedureProxy<SubmitAgentCommand, AgentCommand>
    {
        [SqlParameter("@SourceNode", 0, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlParameter("@TargetNode", 1, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetNode
        {
            get;
            set;
        }

        [SqlParameter("@AgentId", 2, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlParameter("@CommandName", 3, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string CommandName
        {
            get;
            set;
        }

        [SqlParameter("@CorrelationToken", 4, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SubmitAgentCommand()
        {
        }

        public SubmitAgentCommand(object[] items)
        {
            SourceNode = (string)items[0];
            TargetNode = (string)items[1];
            AgentId = (string)items[2];
            CommandName = (string)items[3];
            CorrelationToken = (string)items[4];
        }

        public SubmitAgentCommand(string SourceNode, string TargetNode, string AgentId, string CommandName, string CorrelationToken)
        {
            this.SourceNode = SourceNode;
            this.TargetNode = TargetNode;
            this.AgentId = AgentId;
            this.CommandName = CommandName;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceNode, TargetNode, AgentId, CommandName, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            SourceNode = (string)items[0];
            TargetNode = (string)items[1];
            AgentId = (string)items[2];
            CommandName = (string)items[3];
            CorrelationToken = (string)items[4];
        }
    }

    [SqlProcedure("WF", "StoreAgentConfigurations")]
    public partial class StoreAgentConfigurations : SqlProcedureProxy
    {
        [SqlParameter("@Configs", 0, true, false), SqlTypeFacets("[WF].[AgentConfiguration]", true)]
        public IEnumerable<AgentConfiguration> Configs
        {
            get;
            set;
        }

        public StoreAgentConfigurations()
        {
        }

        public StoreAgentConfigurations(object[] items)
        {
            Configs = (IEnumerable<AgentConfiguration>)items[0];
        }

        public StoreAgentConfigurations(IEnumerable<AgentConfiguration> Configs)
        {
            this.Configs = Configs;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Configs };
        }

        public override void SetItemArray(object[] items)
        {
            Configs = (IEnumerable<AgentConfiguration>)items[0];
        }
    }

    [SqlProcedure("WF", "SubmitSystemCommands")]
    public partial class SubmitSystemCommands : SqlProcedureProxy<SubmitSystemCommands, SystemTask>
    {
        [SqlParameter("@Commands", 0, true, false), SqlTypeFacets("[WF].[SystemCommandSubmission]", true)]
        public IEnumerable<SystemCommandSubmission> Commands
        {
            get;
            set;
        }

        public SubmitSystemCommands()
        {
        }

        public SubmitSystemCommands(object[] items)
        {
            Commands = (IEnumerable<SystemCommandSubmission>)items[0];
        }

        public SubmitSystemCommands(IEnumerable<SystemCommandSubmission> Commands)
        {
            this.Commands = Commands;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Commands };
        }

        public override void SetItemArray(object[] items)
        {
            Commands = (IEnumerable<SystemCommandSubmission>)items[0];
        }
    }

    [SqlProcedure("WF", "CompleteAgentCommand")]
    public partial class CompleteAgentCommand : SqlProcedureProxy
    {
        [SqlParameter("@CommandId", 0, false, false), SqlTypeFacets("bigint", true)]
        public long? CommandId
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

        [SqlParameter("@ResultDescription", 2, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultDescription
        {
            get;
            set;
        }

        public CompleteAgentCommand()
        {
        }

        public CompleteAgentCommand(object[] items)
        {
            CommandId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultDescription = (string)items[2];
        }

        public CompleteAgentCommand(long? CommandId, bool? Succeeded, string ResultDescription)
        {
            this.CommandId = CommandId;
            this.Succeeded = Succeeded;
            this.ResultDescription = ResultDescription;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandId, Succeeded, ResultDescription };
        }

        public override void SetItemArray(object[] items)
        {
            CommandId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultDescription = (string)items[2];
        }
    }

    [SqlProcedure("WF", "LogAgentStatus")]
    public partial class LogAgentStatus : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[WF].[AgentStatus]", true)]
        public IEnumerable<AgentStatus> Records
        {
            get;
            set;
        }

        public LogAgentStatus()
        {
        }

        public LogAgentStatus(object[] items)
        {
            Records = (IEnumerable<AgentStatus>)items[0];
        }

        public LogAgentStatus(IEnumerable<AgentStatus> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<AgentStatus>)items[0];
        }
    }

    [SqlProcedure("WF", "RaiseSystemEvent")]
    public partial class RaiseSystemEvent : SqlProcedureProxy
    {
        [SqlParameter("@EventId", 0, false, false), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? EventId
        {
            get;
            set;
        }

        [SqlParameter("@PairId", 1, false, false), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? PairId
        {
            get;
            set;
        }

        [SqlParameter("@SourceNodeId", 2, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlParameter("@SourceSystemId", 3, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string SourceSystemId
        {
            get;
            set;
        }

        [SqlParameter("@EventType", 4, false, false), SqlTypeFacets("nvarchar", true, 256)]
        public string EventType
        {
            get;
            set;
        }

        [SqlParameter("@EventUri", 5, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string EventUri
        {
            get;
            set;
        }

        [SqlParameter("@CorrelationToken", 6, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlParameter("@SeverityLevel", 7, false, false), SqlTypeFacets("int", true)]
        public int? SeverityLevel
        {
            get;
            set;
        }

        [SqlParameter("@EventBody", 8, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string EventBody
        {
            get;
            set;
        }

        [SqlParameter("@EventTS", 9, false, false), SqlTypeFacets("datetime2", true, -1, 7)]
        public DateTime? EventTS
        {
            get;
            set;
        }

        public RaiseSystemEvent()
        {
        }

        public RaiseSystemEvent(object[] items)
        {
            EventId = (Guid?)items[0];
            PairId = (Guid?)items[1];
            SourceNodeId = (string)items[2];
            SourceSystemId = (string)items[3];
            EventType = (string)items[4];
            EventUri = (string)items[5];
            CorrelationToken = (string)items[6];
            SeverityLevel = (int?)items[7];
            EventBody = (string)items[8];
            EventTS = (DateTime?)items[9];
        }

        public RaiseSystemEvent(Guid? EventId, Guid? PairId, string SourceNodeId, string SourceSystemId, string EventType, string EventUri, string CorrelationToken, int? SeverityLevel, string EventBody, DateTime? EventTS)
        {
            this.EventId = EventId;
            this.PairId = PairId;
            this.SourceNodeId = SourceNodeId;
            this.SourceSystemId = SourceSystemId;
            this.EventType = EventType;
            this.EventUri = EventUri;
            this.CorrelationToken = CorrelationToken;
            this.SeverityLevel = SeverityLevel;
            this.EventBody = EventBody;
            this.EventTS = EventTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EventId, PairId, SourceNodeId, SourceSystemId, EventType, EventUri, CorrelationToken, SeverityLevel, EventBody, EventTS };
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
            SeverityLevel = (int?)items[7];
            EventBody = (string)items[8];
            EventTS = (DateTime?)items[9];
        }
    }

    [SqlProcedure("WF", "DispatchAgentCommands")]
    public partial class DispatchAgentCommands : SqlProcedureProxy<DispatchAgentCommands, AgentCommand>
    {
        [SqlParameter("@TargetNode", 0, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetNode
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

        public DispatchAgentCommands()
        {
        }

        public DispatchAgentCommands(object[] items)
        {
            TargetNode = (string)items[0];
            MaxCount = (int?)items[1];
        }

        public DispatchAgentCommands(string TargetNode, int? MaxCount)
        {
            this.TargetNode = TargetNode;
            this.MaxCount = MaxCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TargetNode, MaxCount };
        }

        public override void SetItemArray(object[] items)
        {
            TargetNode = (string)items[0];
            MaxCount = (int?)items[1];
        }
    }

    [SqlProcedure("WF", "DispatchSystemTasksByName")]
    public partial class DispatchSystemTasksByName : SqlProcedureProxy<DispatchSystemTasksByName, SystemTask>, IDequeueOperator
    {
        [SqlParameter("@CommandName", 0, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string CommandName
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

        public DispatchSystemTasksByName()
        {
        }

        public DispatchSystemTasksByName(object[] items)
        {
            CommandName = (string)items[0];
            MaxCount = (int?)items[1];
        }

        public DispatchSystemTasksByName(string CommandName, int? MaxCount)
        {
            this.CommandName = CommandName;
            this.MaxCount = MaxCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandName, MaxCount };
        }

        public override void SetItemArray(object[] items)
        {
            CommandName = (string)items[0];
            MaxCount = (int?)items[1];
        }
    }

    [SqlProcedure("WF", "ArchiveSystemTasks")]
    public partial class ArchiveSystemTasks : SqlProcedureProxy, IArchiveOperator
    {
        [SqlParameter("@ResetOutstanding", 0, false, false), SqlTypeFacets("bit", true)]
        public bool? ResetOutstanding
        {
            get;
            set;
        }

        [SqlParameter("@RetryFailures", 1, false, false), SqlTypeFacets("bit", true)]
        public bool? RetryFailures
        {
            get;
            set;
        }

        public ArchiveSystemTasks()
        {
        }

        public ArchiveSystemTasks(object[] items)
        {
            ResetOutstanding = (bool?)items[0];
            RetryFailures = (bool?)items[1];
        }

        public ArchiveSystemTasks(bool? ResetOutstanding, bool? RetryFailures)
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

    [SqlProcedure("WF", "SubmitSystemCommand")]
    public partial class SubmitSystemCommand : SqlProcedureProxy<SubmitSystemCommand, SystemTask>, IEnqueueOperator
    {
        [SqlParameter("@SourceNodeId", 0, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlParameter("@TargetNodeId", 1, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlParameter("@TargetSystemId", 2, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlParameter("@CommandUri", 3, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlParameter("@CommandBody", 4, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlParameter("@CorrelationToken", 5, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public SubmitSystemCommand()
        {
        }

        public SubmitSystemCommand(object[] items)
        {
            SourceNodeId = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }

        public SubmitSystemCommand(string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, string CorrelationToken)
        {
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            SourceNodeId = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }
    }

    [SqlProcedure("WF", "DispatchSystemTasks")]
    public partial class DispatchSystemTasks : SqlProcedureProxy<DispatchSystemTasks, SystemTask>, IDequeueOperator
    {
        [SqlParameter("@MaxCount", 0, false, false), SqlTypeFacets("int", true)]
        public int? MaxCount
        {
            get;
            set;
        }

        public DispatchSystemTasks()
        {
        }

        public DispatchSystemTasks(object[] items)
        {
            MaxCount = (int?)items[0];
        }

        public DispatchSystemTasks(int? MaxCount)
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

    [SqlProcedure("WF", "CompleteSystemTask")]
    public partial class CompleteSystemTask : SqlProcedureProxy<CompleteSystemTask, SystemTaskState>, ICompletionOperator
    {
        [SqlParameter("@TaskId", 0, false, false), SqlTypeFacets("bigint", true)]
        public long? TaskId
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

        [SqlParameter("@ResultBody", 2, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultBody
        {
            get;
            set;
        }

        [SqlParameter("@ResultDescription", 3, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultDescription
        {
            get;
            set;
        }

        public CompleteSystemTask()
        {
        }

        public CompleteSystemTask(object[] items)
        {
            TaskId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultBody = (string)items[2];
            ResultDescription = (string)items[3];
        }

        public CompleteSystemTask(long? TaskId, bool? Succeeded, string ResultBody, string ResultDescription)
        {
            this.TaskId = TaskId;
            this.Succeeded = Succeeded;
            this.ResultBody = ResultBody;
            this.ResultDescription = ResultDescription;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, Succeeded, ResultBody, ResultDescription };
        }

        public override void SetItemArray(object[] items)
        {
            TaskId = (long?)items[0];
            Succeeded = (bool?)items[1];
            ResultBody = (string)items[2];
            ResultDescription = (string)items[3];
        }
    }

    [SqlProcedure("WF", "DefineSystemTask")]
    public partial class DefineSystemTask : SqlProcedureProxy<DefineSystemTask, SystemTaskDefinition>
    {
        [SqlParameter("@SourceNodeId", 0, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlParameter("@TargetNodeId", 1, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlParameter("@TargetSystemId", 2, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlParameter("@CommandUri", 3, false, false), SqlTypeFacets("nvarchar", true, 150)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlParameter("@CommandBody", 4, false, false), SqlTypeFacets("nvarchar", true, -1)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlParameter("@CorrelationToken", 5, false, false), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        public DefineSystemTask()
        {
        }

        public DefineSystemTask(object[] items)
        {
            SourceNodeId = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }

        public DefineSystemTask(string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, string CorrelationToken)
        {
            this.SourceNodeId = SourceNodeId;
            this.TargetNodeId = TargetNodeId;
            this.TargetSystemId = TargetSystemId;
            this.CommandUri = CommandUri;
            this.CommandBody = CommandBody;
            this.CorrelationToken = CorrelationToken;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, CorrelationToken };
        }

        public override void SetItemArray(object[] items)
        {
            SourceNodeId = (string)items[0];
            TargetNodeId = (string)items[1];
            TargetSystemId = (string)items[2];
            CommandUri = (string)items[3];
            CommandBody = (string)items[4];
            CorrelationToken = (string)items[5];
        }
    }

    [SqlTable("WF", "CommandTable")]
    public partial class CommandTable : SqlTableProxy, ICommandTableEntry
    {
        [SqlColumn("CommandTableId", 0), SqlTypeFacets("int", false)]
        public int CommandTableId
        {
            get;
            set;
        }

        [SqlColumn("CommandName", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string CommandName
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystem", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetSystem
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 4), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 5), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 6), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 7), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 8), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 9), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 10), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 11), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 12), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 13), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 14), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 15), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 16), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg6Value
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 17), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        public CommandTable()
        {
        }

        public CommandTable(object[] items)
        {
            CommandTableId = (int)items[0];
            CommandName = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystem = (string)items[3];
            CorrelationToken = (string)items[4];
            Arg1Name = (string)items[5];
            Arg1Value = (string)items[6];
            Arg2Name = (string)items[7];
            Arg2Value = (string)items[8];
            Arg3Name = (string)items[9];
            Arg3Value = (string)items[10];
            Arg4Name = (string)items[11];
            Arg4Value = (string)items[12];
            Arg5Name = (string)items[13];
            Arg5Value = (string)items[14];
            Arg6Name = (string)items[15];
            Arg6Value = (string)items[16];
            CreateTS = (DateTime)items[17];
        }

        public CommandTable(int CommandTableId, string CommandName, string TargetNodeId, string TargetSystem, string CorrelationToken, string Arg1Name, string Arg1Value, string Arg2Name, string Arg2Value, string Arg3Name, string Arg3Value, string Arg4Name, string Arg4Value, string Arg5Name, string Arg5Value, string Arg6Name, string Arg6Value, DateTime CreateTS)
        {
            this.CommandTableId = CommandTableId;
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
            this.CreateTS = CreateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandTableId, CommandName, TargetNodeId, TargetSystem, CorrelationToken, Arg1Name, Arg1Value, Arg2Name, Arg2Value, Arg3Name, Arg3Value, Arg4Name, Arg4Value, Arg5Name, Arg5Value, Arg6Name, Arg6Value, CreateTS };
        }

        public override void SetItemArray(object[] items)
        {
            CommandTableId = (int)items[0];
            CommandName = (string)items[1];
            TargetNodeId = (string)items[2];
            TargetSystem = (string)items[3];
            CorrelationToken = (string)items[4];
            Arg1Name = (string)items[5];
            Arg1Value = (string)items[6];
            Arg2Name = (string)items[7];
            Arg2Value = (string)items[8];
            Arg3Name = (string)items[9];
            Arg3Value = (string)items[10];
            Arg4Name = (string)items[11];
            Arg4Value = (string)items[12];
            Arg5Name = (string)items[13];
            Arg5Value = (string)items[14];
            Arg6Name = (string)items[15];
            Arg6Value = (string)items[16];
            CreateTS = (DateTime)items[17];
        }
    }

    [SqlTable("WF", "AgentConfigurationStore")]
    public partial class AgentConfigurationStore : SqlTableProxy
    {
        [SqlColumn("AgentId", 0), SqlTypeFacets("nvarchar", false, 150)]
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

        [SqlColumn("CreateTS", 3), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 4), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        [SqlColumn("SystemRV", 5), SqlTypeFacets("timestamp", false)]
        public SqlRowVersion SystemRV
        {
            get;
            set;
        }

        public AgentConfigurationStore()
        {
        }

        public AgentConfigurationStore(object[] items)
        {
            AgentId = (string)items[0];
            IsEnabled = (bool)items[1];
            SpinFrequency = (int)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
            SystemRV = (SqlRowVersion)items[5];
        }

        public AgentConfigurationStore(string AgentId, bool IsEnabled, int SpinFrequency, DateTime CreateTS, DateTime? UpdateTS, SqlRowVersion SystemRV)
        {
            this.AgentId = AgentId;
            this.IsEnabled = IsEnabled;
            this.SpinFrequency = SpinFrequency;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
            this.SystemRV = SystemRV;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AgentId, IsEnabled, SpinFrequency, CreateTS, UpdateTS, SystemRV };
        }

        public override void SetItemArray(object[] items)
        {
            AgentId = (string)items[0];
            IsEnabled = (bool)items[1];
            SpinFrequency = (int)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
            SystemRV = (SqlRowVersion)items[5];
        }
    }

    [SqlTable("WF", "AgentStatusHistory")]
    public partial class AgentStatusHistory : SqlTableProxy
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("AgentState", 4), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentState
        {
            get;
            set;
        }

        [SqlColumn("StatusSummary", 5), SqlTypeFacets("nvarchar", true, 8000)]
        public string StatusSummary
        {
            get;
            set;
        }

        [SqlColumn("AsOfTS", 6), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime AsOfTS
        {
            get;
            set;
        }

        [SqlColumn("EndTS", 7), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime EndTS
        {
            get;
            set;
        }

        public AgentStatusHistory()
        {
        }

        public AgentStatusHistory(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            SystemId = (string)items[2];
            AgentId = (string)items[3];
            AgentState = (string)items[4];
            StatusSummary = (string)items[5];
            AsOfTS = (DateTime)items[6];
            EndTS = (DateTime)items[7];
        }

        public AgentStatusHistory(long EntryId, string HostId, string SystemId, string AgentId, string AgentState, string StatusSummary, DateTime AsOfTS, DateTime EndTS)
        {
            this.EntryId = EntryId;
            this.HostId = HostId;
            this.SystemId = SystemId;
            this.AgentId = AgentId;
            this.AgentState = AgentState;
            this.StatusSummary = StatusSummary;
            this.AsOfTS = AsOfTS;
            this.EndTS = EndTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, HostId, SystemId, AgentId, AgentState, StatusSummary, AsOfTS, EndTS };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            SystemId = (string)items[2];
            AgentId = (string)items[3];
            AgentState = (string)items[4];
            StatusSummary = (string)items[5];
            AsOfTS = (DateTime)items[6];
            EndTS = (DateTime)items[7];
        }
    }

    [SqlTable("WF", "AgentStatusLog")]
    public partial class AgentStatusLog : SqlTableProxy
    {
        [SqlColumn("EntryId", 0), SqlTypeFacets("bigint", false)]
        public long EntryId
        {
            get;
            set;
        }

        [SqlColumn("HostId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string HostId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("AgentState", 4), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentState
        {
            get;
            set;
        }

        [SqlColumn("StatusSummary", 5), SqlTypeFacets("nvarchar", true, 8000)]
        public string StatusSummary
        {
            get;
            set;
        }

        [SqlColumn("AsOfTS", 6), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime AsOfTS
        {
            get;
            set;
        }

        [SqlColumn("EndTS", 7), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime EndTS
        {
            get;
            set;
        }

        public AgentStatusLog()
        {
        }

        public AgentStatusLog(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            SystemId = (string)items[2];
            AgentId = (string)items[3];
            AgentState = (string)items[4];
            StatusSummary = (string)items[5];
            AsOfTS = (DateTime)items[6];
            EndTS = (DateTime)items[7];
        }

        public AgentStatusLog(long EntryId, string HostId, string SystemId, string AgentId, string AgentState, string StatusSummary, DateTime AsOfTS, DateTime EndTS)
        {
            this.EntryId = EntryId;
            this.HostId = HostId;
            this.SystemId = SystemId;
            this.AgentId = AgentId;
            this.AgentState = AgentState;
            this.StatusSummary = StatusSummary;
            this.AsOfTS = AsOfTS;
            this.EndTS = EndTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EntryId, HostId, SystemId, AgentId, AgentState, StatusSummary, AsOfTS, EndTS };
        }

        public override void SetItemArray(object[] items)
        {
            EntryId = (long)items[0];
            HostId = (string)items[1];
            SystemId = (string)items[2];
            AgentId = (string)items[3];
            AgentState = (string)items[4];
            StatusSummary = (string)items[5];
            AsOfTS = (DateTime)items[6];
            EndTS = (DateTime)items[7];
        }
    }

    [SqlTable("WF", "EvaulatorType")]
    public partial class EvaulatorType : SqlTableProxy, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        public string Description
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 4), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 5), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public EvaulatorType()
        {
        }

        public EvaulatorType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }

        public EvaulatorType(byte TypeCode, string Identifier, string Label, string Description, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }
    }

    [SqlTable("WF", "SystemTaskArchive")]
    public partial class SystemTaskArchive : SqlTableProxy, ITaskArchive
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false, 500)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true, -1)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 6), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 7), SqlTypeFacets("datetime2", false, -1, 0)]
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

        [SqlColumn("DispatchTS", 9), SqlTypeFacets("datetime2", true, -1, 0)]
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

        [SqlColumn("CompleteTS", 11), SqlTypeFacets("datetime2", true, -1, 0)]
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

        [SqlColumn("ResultDescription", 13), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 14), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("ArchivedTS", 15), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime ArchivedTS
        {
            get;
            set;
        }

        public SystemTaskArchive()
        {
        }

        public SystemTaskArchive(object[] items)
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
            ArchivedTS = (DateTime)items[15];
        }

        public SystemTaskArchive(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, string ResultBody, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken, DateTime ArchivedTS)
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
            this.ArchivedTS = ArchivedTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, ResultBody, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken, ArchivedTS };
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
            ArchivedTS = (DateTime)items[15];
        }
    }

    [SqlTable("WF", "WorkflowDefinition")]
    public partial class WorkflowDefinition : SqlTableProxy
    {
        [SqlColumn("WorkflowId", 0), SqlTypeFacets("int", false)]
        public int WorkflowId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("WorkflowName", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string WorkflowName
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 3), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 4), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public WorkflowDefinition()
        {
        }

        public WorkflowDefinition(object[] items)
        {
            WorkflowId = (int)items[0];
            SystemId = (string)items[1];
            WorkflowName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }

        public WorkflowDefinition(int WorkflowId, string SystemId, string WorkflowName, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.WorkflowId = WorkflowId;
            this.SystemId = SystemId;
            this.WorkflowName = WorkflowName;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { WorkflowId, SystemId, WorkflowName, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            WorkflowId = (int)items[0];
            SystemId = (string)items[1];
            WorkflowName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }
    }

    [SqlTable("WF", "StepType")]
    public partial class StepType : SqlTableProxy, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        public string Description
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 4), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 5), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public StepType()
        {
        }

        public StepType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }

        public StepType(byte TypeCode, string Identifier, string Label, string Description, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }
    }

    [SqlTable("WF", "StepDefinition")]
    public partial class StepDefinition : SqlTableProxy
    {
        [SqlColumn("StepId", 0), SqlTypeFacets("int", false)]
        public int StepId
        {
            get;
            set;
        }

        [SqlColumn("WorkflowName", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string WorkflowName
        {
            get;
            set;
        }

        [SqlColumn("StepName", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string StepName
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 3), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 4), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public StepDefinition()
        {
        }

        public StepDefinition(object[] items)
        {
            StepId = (int)items[0];
            WorkflowName = (string)items[1];
            StepName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }

        public StepDefinition(int StepId, string WorkflowName, string StepName, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.StepId = StepId;
            this.WorkflowName = WorkflowName;
            this.StepName = StepName;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { StepId, WorkflowName, StepName, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            StepId = (int)items[0];
            WorkflowName = (string)items[1];
            StepName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }
    }

    [SqlTable("WF", "ControlOperationType")]
    public partial class ControlOperationType : SqlTableProxy, ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        public string Description
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 4), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 5), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public ControlOperationType()
        {
        }

        public ControlOperationType(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }

        public ControlOperationType(byte TypeCode, string Identifier, string Label, string Description, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
            CreateTS = (DateTime)items[4];
            UpdateTS = (DateTime?)items[5];
        }
    }

    [SqlTable("WF", "ControlFlow")]
    public partial class ControlFlow : SqlTableProxy
    {
        [SqlColumn("WorkflowName", 0), SqlTypeFacets("nvarchar", false, 150)]
        public string WorkflowName
        {
            get;
            set;
        }

        [SqlColumn("OperationType", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string OperationType
        {
            get;
            set;
        }

        [SqlColumn("StepName", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string StepName
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 3), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 4), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public ControlFlow()
        {
        }

        public ControlFlow(object[] items)
        {
            WorkflowName = (string)items[0];
            OperationType = (string)items[1];
            StepName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }

        public ControlFlow(string WorkflowName, string OperationType, string StepName, DateTime CreateTS, DateTime? UpdateTS)
        {
            this.WorkflowName = WorkflowName;
            this.OperationType = OperationType;
            this.StepName = StepName;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { WorkflowName, OperationType, StepName, CreateTS, UpdateTS };
        }

        public override void SetItemArray(object[] items)
        {
            WorkflowName = (string)items[0];
            OperationType = (string)items[1];
            StepName = (string)items[2];
            CreateTS = (DateTime)items[3];
            UpdateTS = (DateTime?)items[4];
        }
    }

    [SqlTable("WF", "AgentCommandQueue")]
    public partial class AgentCommandQueue : SqlTableProxy
    {
        [SqlColumn("CommandId", 0), SqlTypeFacets("bigint", false)]
        public long CommandId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", false, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 4), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("CommandName", 5), SqlTypeFacets("nvarchar", false, 150)]
        public string CommandName
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 6), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 7), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 8), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 9), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 10), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 11), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 12), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 13), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 14), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 15), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 16), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 17), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg6Value
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 18), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime SubmittedTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 19), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchTS", 20), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? DispatchTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 21), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 22), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("CompletionTS", 23), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? CompletionTS
        {
            get;
            set;
        }

        [SqlColumn("CompletionMessage", 24), SqlTypeFacets("nvarchar", true, 2048)]
        public string CompletionMessage
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 25), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 26), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public AgentCommandQueue()
        {
        }

        public AgentCommandQueue(object[] items)
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
            SubmittedTS = (DateTime)items[18];
            Dispatched = (bool)items[19];
            DispatchTS = (DateTime?)items[20];
            Completed = (bool)items[21];
            Succeeded = (bool)items[22];
            CompletionTS = (DateTime?)items[23];
            CompletionMessage = (string)items[24];
            CreateTS = (DateTime)items[25];
            UpdateTS = (DateTime?)items[26];
        }

        public AgentCommandQueue(long CommandId, string SourceNodeId, string TargetNodeId, string CorrelationToken, string AgentId, string CommandName, string Arg1Name, string Arg1Value, string Arg2Name, string Arg2Value, string Arg3Name, string Arg3Value, string Arg4Name, string Arg4Value, string Arg5Name, string Arg5Value, string Arg6Name, string Arg6Value, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, bool Succeeded, DateTime? CompletionTS, string CompletionMessage, DateTime CreateTS, DateTime? UpdateTS)
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
            this.SubmittedTS = SubmittedTS;
            this.Dispatched = Dispatched;
            this.DispatchTS = DispatchTS;
            this.Completed = Completed;
            this.Succeeded = Succeeded;
            this.CompletionTS = CompletionTS;
            this.CompletionMessage = CompletionMessage;
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandId, SourceNodeId, TargetNodeId, CorrelationToken, AgentId, CommandName, Arg1Name, Arg1Value, Arg2Name, Arg2Value, Arg3Name, Arg3Value, Arg4Name, Arg4Value, Arg5Name, Arg5Value, Arg6Name, Arg6Value, SubmittedTS, Dispatched, DispatchTS, Completed, Succeeded, CompletionTS, CompletionMessage, CreateTS, UpdateTS };
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
            SubmittedTS = (DateTime)items[18];
            Dispatched = (bool)items[19];
            DispatchTS = (DateTime?)items[20];
            Completed = (bool)items[21];
            Succeeded = (bool)items[22];
            CompletionTS = (DateTime?)items[23];
            CompletionMessage = (string)items[24];
            CreateTS = (DateTime)items[25];
            UpdateTS = (DateTime?)items[26];
        }
    }

    [SqlTable("WF", "AgentCommandArchive")]
    public partial class AgentCommandArchive : SqlTableProxy
    {
        [SqlColumn("CommandId", 0), SqlTypeFacets("bigint", false)]
        public long CommandId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 3), SqlTypeFacets("nvarchar", false, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("AgentId", 4), SqlTypeFacets("nvarchar", false, 150)]
        public string AgentId
        {
            get;
            set;
        }

        [SqlColumn("CommandName", 5), SqlTypeFacets("nvarchar", false, 150)]
        public string CommandName
        {
            get;
            set;
        }

        [SqlColumn("Arg1Name", 6), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg1Name
        {
            get;
            set;
        }

        [SqlColumn("Arg1Value", 7), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg1Value
        {
            get;
            set;
        }

        [SqlColumn("Arg2Name", 8), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg2Name
        {
            get;
            set;
        }

        [SqlColumn("Arg2Value", 9), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg2Value
        {
            get;
            set;
        }

        [SqlColumn("Arg3Name", 10), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg3Name
        {
            get;
            set;
        }

        [SqlColumn("Arg3Value", 11), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg3Value
        {
            get;
            set;
        }

        [SqlColumn("Arg4Name", 12), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg4Name
        {
            get;
            set;
        }

        [SqlColumn("Arg4Value", 13), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg4Value
        {
            get;
            set;
        }

        [SqlColumn("Arg5Name", 14), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg5Name
        {
            get;
            set;
        }

        [SqlColumn("Arg5Value", 15), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg5Value
        {
            get;
            set;
        }

        [SqlColumn("Arg6Name", 16), SqlTypeFacets("nvarchar", true, 150)]
        public string Arg6Name
        {
            get;
            set;
        }

        [SqlColumn("Arg6Value", 17), SqlTypeFacets("nvarchar", true, 500)]
        public string Arg6Value
        {
            get;
            set;
        }

        [SqlColumn("SubmissionTS", 18), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime SubmissionTS
        {
            get;
            set;
        }

        [SqlColumn("Dispatched", 19), SqlTypeFacets("bit", false)]
        public bool Dispatched
        {
            get;
            set;
        }

        [SqlColumn("DispatchedTS", 20), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? DispatchedTS
        {
            get;
            set;
        }

        [SqlColumn("Completed", 21), SqlTypeFacets("bit", false)]
        public bool Completed
        {
            get;
            set;
        }

        [SqlColumn("Succeeded", 22), SqlTypeFacets("bit", false)]
        public bool Succeeded
        {
            get;
            set;
        }

        [SqlColumn("CompletionTS", 23), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? CompletionTS
        {
            get;
            set;
        }

        [SqlColumn("OutcomeDescription", 24), SqlTypeFacets("nvarchar", true, 2048)]
        public string OutcomeDescription
        {
            get;
            set;
        }

        [SqlColumn("ArchiveTS", 25), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime ArchiveTS
        {
            get;
            set;
        }

        public AgentCommandArchive()
        {
        }

        public AgentCommandArchive(object[] items)
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
            SubmissionTS = (DateTime)items[18];
            Dispatched = (bool)items[19];
            DispatchedTS = (DateTime?)items[20];
            Completed = (bool)items[21];
            Succeeded = (bool)items[22];
            CompletionTS = (DateTime?)items[23];
            OutcomeDescription = (string)items[24];
            ArchiveTS = (DateTime)items[25];
        }

        public AgentCommandArchive(long CommandId, string SourceNodeId, string TargetNodeId, string CorrelationToken, string AgentId, string CommandName, string Arg1Name, string Arg1Value, string Arg2Name, string Arg2Value, string Arg3Name, string Arg3Value, string Arg4Name, string Arg4Value, string Arg5Name, string Arg5Value, string Arg6Name, string Arg6Value, DateTime SubmissionTS, bool Dispatched, DateTime? DispatchedTS, bool Completed, bool Succeeded, DateTime? CompletionTS, string OutcomeDescription, DateTime ArchiveTS)
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
            this.SubmissionTS = SubmissionTS;
            this.Dispatched = Dispatched;
            this.DispatchedTS = DispatchedTS;
            this.Completed = Completed;
            this.Succeeded = Succeeded;
            this.CompletionTS = CompletionTS;
            this.OutcomeDescription = OutcomeDescription;
            this.ArchiveTS = ArchiveTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CommandId, SourceNodeId, TargetNodeId, CorrelationToken, AgentId, CommandName, Arg1Name, Arg1Value, Arg2Name, Arg2Value, Arg3Name, Arg3Value, Arg4Name, Arg4Value, Arg5Name, Arg5Value, Arg6Name, Arg6Value, SubmissionTS, Dispatched, DispatchedTS, Completed, Succeeded, CompletionTS, OutcomeDescription, ArchiveTS };
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
            SubmissionTS = (DateTime)items[18];
            Dispatched = (bool)items[19];
            DispatchedTS = (DateTime?)items[20];
            Completed = (bool)items[21];
            Succeeded = (bool)items[22];
            CompletionTS = (DateTime?)items[23];
            OutcomeDescription = (string)items[24];
            ArchiveTS = (DateTime)items[25];
        }
    }

    [SqlTable("WF", "SystemTaskQueue")]
    public partial class SystemTaskQueue : SqlTableProxy, ITaskQueue
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false, 500)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true, -1)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("ResultBody", 6), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultBody
        {
            get;
            set;
        }

        [SqlColumn("SubmittedTS", 7), SqlTypeFacets("datetime2", false, -1, 0)]
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

        [SqlColumn("DispatchTS", 9), SqlTypeFacets("datetime2", true, -1, 0)]
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

        [SqlColumn("CompleteTS", 11), SqlTypeFacets("datetime2", true, -1, 0)]
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

        [SqlColumn("ResultDescription", 13), SqlTypeFacets("nvarchar", true, -1)]
        public string ResultDescription
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 14), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 15), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 16), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public SystemTaskQueue()
        {
        }

        public SystemTaskQueue(object[] items)
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
            CreateTS = (DateTime)items[15];
            UpdateTS = (DateTime?)items[16];
        }

        public SystemTaskQueue(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, string ResultBody, DateTime SubmittedTS, bool Dispatched, DateTime? DispatchTS, bool Completed, DateTime? CompleteTS, bool Succeeded, string ResultDescription, string CorrelationToken, DateTime CreateTS, DateTime? UpdateTS)
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
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, ResultBody, SubmittedTS, Dispatched, DispatchTS, Completed, CompleteTS, Succeeded, ResultDescription, CorrelationToken, CreateTS, UpdateTS };
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
            CreateTS = (DateTime)items[15];
            UpdateTS = (DateTime?)items[16];
        }
    }

    [SqlTable("WF", "SystemTaskDefinitionStore")]
    public partial class SystemTaskDefinitionStore : SqlTableProxy
    {
        [SqlColumn("TaskId", 0), SqlTypeFacets("bigint", false)]
        public long TaskId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetNodeId", 2), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetNodeId
        {
            get;
            set;
        }

        [SqlColumn("TargetSystemId", 3), SqlTypeFacets("nvarchar", false, 150)]
        public string TargetSystemId
        {
            get;
            set;
        }

        [SqlColumn("CommandUri", 4), SqlTypeFacets("nvarchar", false, 500)]
        public string CommandUri
        {
            get;
            set;
        }

        [SqlColumn("CommandBody", 5), SqlTypeFacets("nvarchar", true, -1)]
        public string CommandBody
        {
            get;
            set;
        }

        [SqlColumn("DefinedTS", 6), SqlTypeFacets("datetime2", false, -1, 0)]
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

        [SqlColumn("EnqueuedTS", 8), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? EnqueuedTS
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 9), SqlTypeFacets("nvarchar", true, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("CreateTS", 10), SqlTypeFacets("datetime2", false, -1, 0)]
        public DateTime CreateTS
        {
            get;
            set;
        }

        [SqlColumn("UpdateTS", 11), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? UpdateTS
        {
            get;
            set;
        }

        public SystemTaskDefinitionStore()
        {
        }

        public SystemTaskDefinitionStore(object[] items)
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
            CreateTS = (DateTime)items[10];
            UpdateTS = (DateTime?)items[11];
        }

        public SystemTaskDefinitionStore(long TaskId, string SourceNodeId, string TargetNodeId, string TargetSystemId, string CommandUri, string CommandBody, DateTime DefinedTS, bool Enqueued, DateTime? EnqueuedTS, string CorrelationToken, DateTime CreateTS, DateTime? UpdateTS)
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
            this.CreateTS = CreateTS;
            this.UpdateTS = UpdateTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TaskId, SourceNodeId, TargetNodeId, TargetSystemId, CommandUri, CommandBody, DefinedTS, Enqueued, EnqueuedTS, CorrelationToken, CreateTS, UpdateTS };
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
            CreateTS = (DateTime)items[10];
            UpdateTS = (DateTime?)items[11];
        }
    }

    [SqlTable("WF", "SystemEventStore")]
    public partial class SystemEventStore : SqlTableProxy
    {
        [SqlColumn("EventRV", 0), SqlTypeFacets("timestamp", false)]
        public SqlRowVersion EventRV
        {
            get;
            set;
        }

        [SqlColumn("EventTS", 1), SqlTypeFacets("datetime2", false, -1, 7)]
        public DateTime EventTS
        {
            get;
            set;
        }

        [SqlColumn("EventId", 2), SqlTypeFacets("uniqueidentifier", false)]
        public Guid EventId
        {
            get;
            set;
        }

        [SqlColumn("PairId", 3), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? PairId
        {
            get;
            set;
        }

        [SqlColumn("SourceNodeId", 4), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceNodeId
        {
            get;
            set;
        }

        [SqlColumn("SourceSystemId", 5), SqlTypeFacets("nvarchar", false, 150)]
        public string SourceSystemId
        {
            get;
            set;
        }

        [SqlColumn("EventType", 6), SqlTypeFacets("nvarchar", false, 256)]
        public string EventType
        {
            get;
            set;
        }

        [SqlColumn("EventUri", 7), SqlTypeFacets("nvarchar", false, 500)]
        public string EventUri
        {
            get;
            set;
        }

        [SqlColumn("CorrelationToken", 8), SqlTypeFacets("nvarchar", false, 500)]
        public string CorrelationToken
        {
            get;
            set;
        }

        [SqlColumn("SeverityLevel", 9), SqlTypeFacets("int", false)]
        public int SeverityLevel
        {
            get;
            set;
        }

        [SqlColumn("EventBody", 10), SqlTypeFacets("varchar", true, -1)]
        public string EventBody
        {
            get;
            set;
        }

        public SystemEventStore()
        {
        }

        public SystemEventStore(object[] items)
        {
            EventRV = (SqlRowVersion)items[0];
            EventTS = (DateTime)items[1];
            EventId = (Guid)items[2];
            PairId = (Guid?)items[3];
            SourceNodeId = (string)items[4];
            SourceSystemId = (string)items[5];
            EventType = (string)items[6];
            EventUri = (string)items[7];
            CorrelationToken = (string)items[8];
            SeverityLevel = (int)items[9];
            EventBody = (string)items[10];
        }

        public SystemEventStore(SqlRowVersion EventRV, DateTime EventTS, Guid EventId, Guid? PairId, string SourceNodeId, string SourceSystemId, string EventType, string EventUri, string CorrelationToken, int SeverityLevel, string EventBody)
        {
            this.EventRV = EventRV;
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
            return new object[] { EventRV, EventTS, EventId, PairId, SourceNodeId, SourceSystemId, EventType, EventUri, CorrelationToken, SeverityLevel, EventBody };
        }

        public override void SetItemArray(object[] items)
        {
            EventRV = (SqlRowVersion)items[0];
            EventTS = (DateTime)items[1];
            EventId = (Guid)items[2];
            PairId = (Guid?)items[3];
            SourceNodeId = (string)items[4];
            SourceSystemId = (string)items[5];
            EventType = (string)items[6];
            EventUri = (string)items[7];
            CorrelationToken = (string)items[8];
            SeverityLevel = (int)items[9];
            EventBody = (string)items[10];
        }
    }
}