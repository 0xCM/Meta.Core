//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.Commands
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Meta.Core;

    using static metacore;

    using static CommandDispatcherMessages;
    using L = PlatformAgentLiterals;

    [ApplicationService(L.CommandDispatcher), ServiceAgent(L.CommandDispatcher)]
    class CommandDispatcher : SystemAgent<CommandDispatcher, CommandDispatcherSettings>
    {

        int CycleCount;

        ICommandExecStore ExecStore { get; }

        ConcurrentSet<Task> ExecutingTasks { get; }
            = new ConcurrentSet<Task>();


        public CommandDispatcher(INodeContext C)
            : base(C)
        {
            
            this.CPS = C.CPS();
            this.ExecStore = CPS.ExecStore;

        }

        ICommandPatternSystem CPS { get; }

        void Dispatch()
        {
            
            var store = CPS.ExecStore;
            var MaxCount = 20;
            var host = SystemNode.Local;

            var dispatches = store.Dispatch(MaxCount).OnNone(Notify);
            foreach (var dispatch in dispatches.Items())
            {
                Notify(DispatchingCommand(host, dispatch));

                var exec = CPS.ExecuteCommand(dispatch.Spec);
                var completion = exec.IsSome
                    ? store.Complete(new CommandResult
                    (
                        dispatch.Spec,
                        exec.Value,
                        true,
                        exec.Message,
                        dispatch.SubmissionId,
                        dispatch.CorrelationToken)
                      )
                    : store.Complete(new CommandResult
                    (
                        dispatch.Spec,
                        null,
                        false,
                        exec.Message,
                        dispatch.SubmissionId,
                        dispatch.CorrelationToken)
                    );

                completion.OnSome(m => CompletedCommand(host, m))
                          .OnNone(Notify);

            }
        }

        protected override Option<int> DoWork()
        {

            try
            {
                Interlocked.Increment(ref CycleCount);

                ExecStore.GetCurrentSubmissionCount()
                    .OnNone(Notify)
                    .OnSome(submissionCount =>
                    {
                        if (submissionCount != 0)
                        {
                            Notify(ReceivedNewSubmissions(SystemNode.Local, submissionCount));

                            Task.Factory.StartNew(Dispatch).ContinueWith(t => 
                               {
                                   ExecutingTasks.Remove(t);        
                               });
                        }
                        else
                            Notify(ListeningForNewSubmissions(SystemNode.Local, CycleCount));
                    });

                    
            }
            catch (Exception e)
            {
                NotifyError(e);
                return none<int>(e);
            }
            return CycleCount;
        }

        
    }



}