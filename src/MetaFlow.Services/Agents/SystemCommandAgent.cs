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
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    using SqlT.Core;
    using MetaFlow.Proxies.WF;

    using static metacore;
    using static WorkflowMessages;

    using N = SystemNodeIdentifier;
    using L = PlatformAgentLiterals;

    [ServiceAgent(L.SystemCommandAgent), ApplicationService(L.SystemCommandAgent)]
    class SystemCommandAgent : SystemAgent<SystemCommandAgent, SystemCommandAgentSettings>, ISystemCommandAgent
    {

        ISqlProxyBroker Broker { get; }

        ConcurrentDictionary<long, Task<ISystemTaskResult>> ExecutingTasks { get; }
            = new ConcurrentDictionary<long, Task<ISystemTaskResult>>();
       

        ISystemCommandRouter CommandRouter { get; }

        public SystemCommandAgent(INodeContext C)
            : base(C)
        {
            (this as IServiceAgent).NoBabble();

           
            Broker = C.WorkflowBroker(C.ExecutingNode(), C.SqlObserver);
            CommandRouter = C.SystemCommandRouter();

        }

        ISystemTaskResult Execute(SystemTask task)
        {
            try
            {
                return CommandRouter.Route(task);

            }
            catch(Exception e)
            {
                return new SystemTaskResult(
                    TaskId: task.TaskId,
                    SourceNodeId: task.SourceNodeId,
                    TargetNodeId: task.TargetNodeId,
                    Succeeded: false,
                    ResultBody: null,
                    ResultDescription: e.ToString(),
                    CorrelationToken: task.CorrelationToken
                    );
            }

        }


        Task<ISystemTaskResult> BeginInvoke(SystemTask command)
            => task(() => Execute(command));

        ISystemTaskResult CompleteInvoke(Task<ISystemTaskResult> continuation)
        {

            var outcome = continuation.Result;
            if (!ExecutingTasks.TryRemove(outcome.TaskId))
                Notify(TaskNotExecuting(outcome.TaskId));

            Broker.Call(new CompleteSystemTask
                (
                    TaskId: outcome.TaskId,
                    Succeeded: outcome.Succeeded,
                    ResultBody: outcome.ResultBody,
                    ResultDescription: outcome.ResultDescription
                    )
                 ).ToOption().OnNone(Notify);

            iter(DescribeOutcome(outcome), Notify);

            return outcome;
        }

        int Enqueue(IReadOnlyList<SystemTask> tasks)
        {
            Notify(inform($"Enqueuing {tasks.Count} tasks"));
            iter(tasks, command =>
            {
                var begin = BeginInvoke(command);
                if (ExecutingTasks.TryAdd(command.TaskId, begin))
                    begin.ContinueWith(CompleteInvoke);

            });
            Notify(inform($"Enqueued {tasks.Count} tasks"));
            return tasks.Count;
        }

        Option<IReadOnlyList<SystemTask>> DispatchTasks()
            => Broker.Get(new DispatchSystemTasks(10));



        protected override Option<int> DoWork()
        {
            try
            {
                var q = from c in DispatchTasks()
                        select Enqueue(c);

                return q.OnNone(Notify)
                        .OnSome(count => Notify(DispatchedSystemTasks(count)));

            }
            catch (Exception e)
            {
                NotifyError(e);
                return none<int>(e);
            }
        }

    }


}