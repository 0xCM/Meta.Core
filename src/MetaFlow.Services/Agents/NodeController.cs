//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Collections.Concurrent;

    using MetaFlow.Core;
    using WF = MetaFlow.Proxies.WF;

    using SqlT.Core;

    using static NodeControllerMessages;

    using static metacore;

    [ServiceAgent(nameof(NodeController)), ApplicationService(nameof(NodeController))]
    class NodeController : SystemAgent<NodeController, NodeControllerSettings>, INodeController
    {
        IReadOnlyDictionary<AgentIdentifier, IServiceAgent> ManagedAgents { get; set; }

        Dictionary<AgentIdentifier, ConcurrentQueue<AgentStatus>> AgentStatusQueues { get; }
            = new Dictionary<AgentIdentifier, ConcurrentQueue<AgentStatus>>();

        Option<IServiceAgent> LookupAgent(AgentIdentifier AgentId)
            => ManagedAgents.TryFind(AgentId, () => AgentNotFound(AgentId));

        ISqlProxyBroker WorkflowBroker { get; }

        public NodeController(INodeContext C)
            : base(C)
        {

            WorkflowBroker = C.WorkflowBroker(C.Host);
        }

        IEnumerable<AgentConfiguration> AgentConfigurations
            => WorkflowBroker.Get(new WF.AgentConfigurations()).OnNone(Notify).Items();

        public IEnumerable<AgentRuntimeStatus> AgentStatusReport()
            => from agent in ManagedAgents.Values
               select new AgentRuntimeStatus(agent.AgentName, agent.AgentState);

        Option<IServiceAgent> GetAgent(AgentIdentifier AgentId)
        {
            try
            {
                var agent = C.HostContext().Agent(AgentId);
                if (agent != null)
                    return some(agent);
                else
                    return none<IServiceAgent>(AgentNotFound(AgentId));
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is ReflectionTypeLoadException)
                {
                    iter((e.InnerException as ReflectionTypeLoadException).LoaderExceptions, le => Notify(le.DefineExceptionMessage()));
                    return none<IServiceAgent>(AgentStartError(AgentId));
                }
                return none<IServiceAgent>(e);
            }
            catch (ReflectionTypeLoadException e)
            {

                iter(e.LoaderExceptions, le => Notify(le.DefineExceptionMessage()));
                return none<IServiceAgent>(AgentStartError(AgentId));
            }
            catch (Exception e)
            {

                return none<IServiceAgent>(UnanticipatedError(AgentId, e));
            }

        }

        protected override ServiceAgentState HandleInitialize()
        {
            var agents = new List<(AgentIdentifier, IServiceAgent)>();
            var configs = AgentConfigurations.ToDictionary(x => x.AgentId);
            foreach (var agent in new PlatformAgents())
            {
                var config = configs.TryFind(agent).ValueOrDefault(new AgentConfiguration(agent, true, 5000));
                if (config.IsEnabled)
                    GetAgent(agent).OnNone(Notify).OnSome(a => agents.Add((a.AgentName, a)));
            }

            ManagedAgents = dict(agents);

            iter(ManagedAgents.Keys, agentId => AgentStatusQueues.Add(agentId, new ConcurrentQueue<AgentStatus>()));

            StartAgents();

            return ServiceAgentStates.Initialized;
        }

        AgentStatus ToStatus(IAgentNotification n)
            => new AgentStatus
            (
                 HostId: n.Host,
                 SystemId: n.System,
                 AgentId: n.Agent,
                 AgentState: n.State.StateName,
                 StatusSummary: n.Message.IsEmpty ? null : n.Message.Format(false)
             );

        void NotificationQueue(IAgentNotification n)
            => AgentStatusQueues[n.Agent].Enqueue(ToStatus(n));


        IServiceAgent SetChannel(IServiceAgent agent)
        {
            agent.UseChannel(NotificationQueue);
            return agent;
        }


        public void StartAgents()
            => iter(ManagedAgents.Values, agent => StartAgent(agent.AgentName));

        public void StopAgents()
            => iter(ManagedAgents.Values, agent => StopAgent(agent.AgentName));


        public void StartAgent(AgentIdentifier AgentId)
            => (from agent in LookupAgent(AgentId)
                from start in agent.StartIfNotRunning()
                select SetChannel(start)).OnMessage(Notify);

        public void StopAgent(AgentIdentifier AgentId)
            => (from agent in LookupAgent(AgentId)
                from start in agent.StopIfRunning()
                select start).OnMessage(Notify);

        public void PauseAgent(AgentIdentifier AgentId)
            => (from agent in LookupAgent(AgentId)
                from start in agent.PauseIfRunning()
                select start).OnMessage(Notify);

        public void ResumeAgent(AgentIdentifier AgentId)
            => (from agent in LookupAgent(AgentId)
                from start in agent.ResumeIfPaused()
                select start).OnMessage(Notify);

        IReadOnlyList<AgentStatus> DequeueAgentStatus()
            => rolist(AgentStatusQueues.Values.SelectMany(q => q.Dequeue(1)));

        void StatusLogFailure(IReadOnlyList<AgentStatus> status, IAppMessage message)
        {
            Notify(error($"Unable to persist agent status : {message.Format(false)}"));
        }

        void PersistAgentStatus()
        {
            var status = DequeueAgentStatus();
            while (status.Count != 0)
            {
                var result = WorkflowBroker.Call(new WF.LogAgentStatus(status)).ToOption();
                if (!result)
                    result.OnNone(message => StatusLogFailure(status, result.Message));
                else
                    status = DequeueAgentStatus();
            }
        }

        Option<IAgentControlCommand> MapControlCommand(AgentCommand command)
        {
            switch (command.CommandName)
            {
                case nameof(C0.PauseAgent):
                    return new C0.PauseAgent(command.TargetNodeId, command.AgentId);
                case nameof(C0.ResumeAgent):
                    return new C0.ResumeAgent(command.TargetNodeId, command.AgentId);
                case nameof(C0.StopAgent):
                    return new C0.StopAgent(command.TargetNodeId, command.AgentId);
                case nameof(C0.StartAgent):
                    return new C0.StartAgent(command.TargetNodeId, command.AgentId);
                case nameof(C0.DisableAgent):
                    return new C0.DisableAgent(command.TargetNodeId, command.AgentId);
                case nameof(C0.EnableAgent):
                    return new C0.EnableAgent(command.TargetNodeId, command.AgentId);
            }
            return none<IAgentControlCommand>(warn($"Command {command.CommandName} for {command.AgentId} unrecognized"));
        }

        void ExecuteControlCommand(C0.PauseAgent command)
            => PauseAgent(command.AgentId);

        void ExecuteControlCommand(C0.ResumeAgent command)
            => ResumeAgent(command.AgentId);

        void ExecuteControlCommand(C0.StartAgent command)
            => StartAgent(command.AgentId);

        void ExecuteControlCommand(C0.StopAgent command)
            => StopAgent(command.AgentId);

        void RouteControlCommand(long commandId, IAgentControlCommand command)
        {

            try
            {
                ExecuteControlCommand((dynamic)command);
                WorkflowBroker.Call(new WF.CompleteAgentCommand(commandId, true, null))
                    .ToOption().OnNone(Notify);
            }
            catch (Exception e)
            {
                WorkflowBroker.Call(new WF.CompleteAgentCommand(commandId, false, error(e).Format(false)))
                    .ToOption().OnNone(Notify);
            }
        }

        void ExecuteAgentCommand(AgentCommand command)
        {
            Notify(inform($"Executing {command.CommandName} command for {command.AgentId} agent"));

            MapControlCommand(command)
                .OnNone(reason =>
                {
                    Notify(reason);
                    WorkflowBroker.Call(new WF.CompleteAgentCommand(command.CommandId, false, reason.Format(false)))
                        .ToOption().OnNone(Notify);

                }).OnSome(control => RouteControlCommand(command.CommandId, control));
        }

        void ExecuteAgentCommands()
        {
            iter(WorkflowBroker.Get(new WF.DispatchAgentCommands(Host, 500)).ToOption().OnNone(Notify).Items(),
                    command => ExecuteAgentCommand(command));
        }

        protected override Option<int> DoWork()
        {
            PersistAgentStatus();
            ExecuteAgentCommands();
            return 0;
        }
    }
}