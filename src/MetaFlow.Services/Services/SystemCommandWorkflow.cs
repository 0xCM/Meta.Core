//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Meta.Core;

    using SqlT.Core;
    using SqlT.Services;

    using MetaFlow.Proxies.WF;
    
    using static metacore;

    [ApplicationService(nameof(SystemCommand))]
    class SystemCommandWorkflow : TaskQueueWorkflow
        <
            SystemCommandWorkflow,
            SystemCommandSubmission,
            SystemTask,
            SystemTaskResult,
            SystemTaskQueue,
            SystemTaskArchive,
            SystemTaskState,
            WorkflowOptions,
            ISystemCommandWorkflow            
        >, ISystemCommandWorkflow
    {
        Option<ICommandSpec> GetSpec(string Body)
            => MessageSerializer.Decode(Body);

        Option<TSpec> GetSpec<TSpec>(string Body)
            where TSpec : CommandSpec<TSpec>, new()
            => GetSpec(Body).Map(spec => (TSpec)spec);

        Json GetJson(object o)
            => C.JsonSerializer().ObjectToJson(o);

        public SystemCommandWorkflow(INodeContext C)
            : base(C)
        {
            this.WorkflowServices = C.Service<ISystemWorkflowServices>();
            this.CPS = C.CPS();
        }

        ICommandPatternSystem CPS { get; }

        public ISystemWorkflowServices WorkflowServices { get; }

        ICommandSpecSerializer MessageSerializer
            => WorkflowServices.MessageSerializer;
      
        Option<CommandCompletion> Complete(ICommandResult result)
            => from c in WorkflowBroker.Get(new CompleteSystemTask(result.SubmissionId, result.Succeeded, GetJson(result.Payload), result.Message.Format(false)))
                    .TryMapValue(x => x.FirstOrDefault()).ToOption()
               from spec in GetSpec(c.CommandBody)
               select c.DeriveCompletion(spec, result);

        public ReadOnlyList<Option<CommandCompletion>> Complete(IEnumerable<ICommandResult> results)
            => results.Select(Complete).ToReadOnlyList();

        public override IEnumerable<SystemCommandSubmission> DefineCommands(WorkflowOptions options)
            => stream<SystemCommandSubmission>();

        public override SystemTaskResult ExecuteTask(SystemTask task)
        {
            var spec = GetSpec(task.CommandBody);
            var exec = spec.IsSome() 
                ? spec.Map(s => CPS.ExecuteCommand(s)) 
                : spec;

            var result = new SystemTaskResult
                        (
                          TaskId: task.TaskId,
                          SourceNodeId: task.SourceNodeId,
                          TargetNodeId: task.TargetNodeId,
                          ResultBody: null,
                          Succeeded: exec.IsSome(),
                          ResultDescription: exec.Message.IsEmpty ? null : exec.Message.Format(null),
                          CorrelationToken: task.CorrelationToken
                        );
            return result;                                       
        }
        
        protected override Option<int> ArchiveTasks(bool ResetOutstanding, bool RetryFailures)
            => WorkflowBroker.Call(new ArchiveSystemTasks(ResetOutstanding, RetryFailures));

        protected override Option<int> CompleteTask(SystemTaskResult result)
            => WorkflowBroker.Call(new CompleteSystemTask(result.TaskId, result.Succeeded, result.ResultBody, result.ResultDescription));

        protected override IReadOnlyList<SystemTask> DequeueTasks(int batch)
            => WorkflowBroker.Get(new DispatchSystemTasks(batch)).ToOption()
                .OnNone(Notify).Items();

        public override IEnumerable<SystemTask> PendingTasks
            => WorkflowBroker.Get(new PendingSystemTasks()).OnNone(Notify).Items();
               
        public Option<IReadOnlyList<SystemTask>> Submit(IEnumerable<ISystemCommand> commands, CorrelationToken? CT)
        {
            var submissions = from command in commands
                              let uri = command.TargetedUri()
                              let system = command.GetType().DefiningSystem()
                              let body = Serializer.ObjectToJson(command)
                              select new SystemCommandSubmission
                              (
                                  SourceNodeId: Host.NodeIdentifier,
                                  CommandNode: command.CommandNode,
                                  TargetSystemId: system,
                                  CommandUri: uri,
                                  CommandBody: body,
                                  CorrelationToken: CT

                               );
            return WorkflowBroker.Get(new SubmitSystemCommands(submissions.ToList()));
        }

        Option<SystemTask> Submit(ISystemCommand command, CorrelationToken? CT)
        {
            var uri = command.TargetedUri();
            var system = command.GetType().DefiningSystem();
            var body = Serializer.ObjectToJson(command);
            return from submission in WorkflowBroker.Get(new SubmitSystemCommand
                   (
                        SourceNodeId: Host.NodeIdentifier,
                        TargetNodeId: command.CommandNode,
                        TargetSystemId: system,
                        CommandUri: uri,
                        CommandBody: body,
                        CorrelationToken: CT)
                   ).ToOption()
                   from one in submission.TryGetFirst()
                   select one;
        }

        Option<SystemTask> ISystemCommandWorkflow.Submit(ISystemCommand command, CorrelationToken? CT)
            => Submit(command, CT);

        protected override IEnumerable<SystemTask> EnqueueCommands(IEnumerable<SystemCommandSubmission> Commands)        
          =>   WorkflowBroker.Get(new SubmitSystemCommands(Commands.ToList())).ToOption().OnNone(Notify).Items();

        Option<SystemTask> ISystemCommandWorkflow.Submit<K>(K command, CorrelationToken? CT)
            => Submit(command, CT);

        public Option<SystemTaskDefinition> DefineTask(ISystemCommand command, CorrelationToken? CT)
        {
            var uri = command.TargetedUri();
            var system = command.GetType().DefiningSystem();
            var body = Serializer.ObjectToJson(command);
            return from submission in WorkflowBroker.Get(new DefineSystemTask
                   (
                        SourceNodeId: Host.NodeIdentifier,
                        TargetNodeId: command.CommandNode,
                        TargetSystemId: system,
                        CommandUri: uri,
                        CommandBody: body,
                        CorrelationToken: CT)
                   ).ToOption()
                   from one in submission.TryGetFirst()
                   select one;
        }
    }
}