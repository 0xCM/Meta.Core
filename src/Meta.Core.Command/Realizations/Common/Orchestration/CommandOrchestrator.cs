//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using Meta.Core;

using static CommandStatusMessages;

using static metacore;

/// <summary>
/// Manages task orchestrations
/// </summary>
public sealed class CommandOrchestrator<TSpec,TPayload> 
    : ApplicationService<CommandOrchestrator<TSpec,TPayload>, ICommandOrchestrator<TSpec,TPayload>>, ICommandOrchestrator<TSpec,TPayload>
        where TSpec : CommandSpec<TSpec,TPayload>, new()
{
    static readonly CommandSpecDescriptor SpecDescriptor = CommandSpecDescriptor.FromSpecType<TSpec>();
    static readonly string CommandName = SpecDescriptor.CommandName;

    readonly CancellationTokenSource cts;
    readonly CancellationToken ct;
    readonly ICommandExecutionService<TSpec,TPayload> CommandPattern;
    Task systask = null;
    readonly CommandOrchestrationSettings Settings;
    MutableList<ICommandPatternObserver> observers = MutableList.Create<ICommandPatternObserver>();
    
    void OnCommandsSpecified(IEnumerable<TSpec> specs)
        => iter(specs, spec =>
                    iter(observers, observer => observer.OnCommandSpecified(spec)));

    void OnCommandsSubmitted(IEnumerable<CommandSubmission<TSpec>> submissions)
        => iter(submissions, submission =>
                    iter(observers, observer => observer.OnCommandSubmitted(submission)));

    void OnCommandsDispatched(IEnumerable<CommandDispatch<TSpec>> dispatches)
        => iter(dispatches, dispatch => 
                    iter(observers, observer => observer.OnCommandDispatched(dispatch)));


    void OnCommandsExecuted(IEnumerable<CommandResult<TSpec,TPayload>> results)
        => iter(results, result =>
                    iter(observers, observer => observer.OnCommandExecuted(result)));

    void OnCommandsCompleted(IEnumerable<CommandCompletion<TSpec, TPayload>> completions)
        => iter(completions, completion =>
                    iter(observers, observer => observer.OnCommandCompletion(completion)));
   
    /// <summary>
    /// Initializes a new orchestrator
    /// </summary>
    /// <param name="context">The orchestation context</param>
    public CommandOrchestrator(IApplicationContext context, ICommandExecutionService<TSpec,TPayload> CommandPattern, CommandOrchestrationSettings Settings)
        : base(context)
    {

        this.CommandPattern = CommandPattern;
        this.cts = new CancellationTokenSource();
        this.ct = cts.Token;
        this.Settings = Settings;
    }

    bool IsCancellationRequested() 
        => ct.IsCancellationRequested;

    /// <summary>
    /// Signals a cancellation request
    /// </summary>
    bool Cancel(int timeout = 120000)
    {
        if (systask == null)
            return true;

        cts.Cancel();
        var finished = systask.Wait(timeout);
        if(finished)
            systask = null;
        return finished;
    }
    
    bool ICommandOrchestrator.IsRunning 
        => systask != null;

    bool ICommandOrchestrator.Stop(int timeout)
    {
        Notify(CancelingOrchestration(SpecDescriptor));
        bool finished = Cancel();
        if (finished)
            Notify(CancelledOrchestration(SpecDescriptor));
        else
        {
            Notify(CapabilityNotImplemented("force command execution cancellation"));           
        }
        return finished;
    }

    bool ICommandOrchestrator.TryStop(int timeout)
    {
        Notify(CancelingOrchestration(SpecDescriptor));

        bool finished = Cancel();
        if (finished)
            Notify(CancelledOrchestration(SpecDescriptor));
        else
            Notify(OrchestratedTasksStillExecuting(SpecDescriptor));
        return finished;
    }

    Type ICommandOrchestrator.SpecType
        => typeof(TSpec);

    ICommandQueue<TSpec> SubmissionQueue 
        => CommandPattern.Queue;

    ICommandExecutor<TSpec,TPayload> Executor 
        => CommandPattern.Executor;

    ICommandExecStore ExecStore
        => Context.Service<ICommandExecStore>();

    IEnumerable<IAppMessage> Dispatch()
    {
        var doWork = true;
        while (doWork)
        {
            var dispatched = SubmissionQueue.Dispatch(Settings.CommandBatchSize);

            if (dispatched.Count != 0)
            {
                OnCommandsDispatched(dispatched);

                yield return DispatchedCommands(CommandName, dispatched.Count);

                var results = Executor.Execute(dispatched, Settings.ConcurrentProcessing);
                OnCommandsExecuted(results);

                var completions = ExecStore.Complete(results);
                if (completions.IsNone())
                    Notify(completions.Message);
                else
                    OnCommandsCompleted(completions.Items());

                doWork = !ct.IsCancellationRequested;
            }
            else
            {
                yield return CommandQueueIsEmpty(CommandName);
                doWork = false;
            }
        }

    }

    IEnumerable<IAppMessage> Enqueue()
    {
        if (Settings.ScheduleCommands)
        {
            yield return CalculatingNewCommands(CommandName);

            var factories = Context.TryGetService<ICommandFactoryProvider>();
            if (factories)
            {
                var factory = factories.Require().Factory<TSpec>();

                var commands = factory.MapValueOrDefault(f => f(Context));
                OnCommandsSpecified(commands);

                var submissions = CommandPattern.Queue.Enqueue(commands, SystemNode.Local).OnNone(m => Notify(m)).Items();
                OnCommandsSubmitted(submissions);

                if (submissions.Count == 0)
                    yield return NoCommandsAvailable(CommandName);
                else
                    yield return EnqueuedNewCommands(SpecDescriptor, submissions.Count);
            }
        }
        else
            yield return OrchestrationDisabled(CommandName);
    }

    IEnumerable<IAppMessage> Run()
    {
        yield return OrchestrationStarted(CommandName);

        while (!IsCancellationRequested())
        {
            if (Settings.ScheduleCommands)
            {
                foreach (var message in Enqueue())
                    yield return message;
            }

            if (IsCancellationRequested())
            {
                yield return OrchestrationCancellationRequestReceived(CommandName);
                break;
            }                

            if(Settings.DispatchCommands)
            {
                foreach (var message in Dispatch())
                    yield return message;
            }

            if (IsCancellationRequested())
            {
                yield return OrchestrationCancellationRequestReceived(CommandName);
                break;
            }

            if (!Settings.Cycle)
                break;

            var pause = Settings.Cycle ? Settings.CyclePauseDuration : 0;
            if (pause != 0)
            {
                yield return OrchestrationPausing(CommandName, pause);
                Task.Delay(pause).Wait(pause * 2);
            }
        }

        systask = null;
    }

    Task Start()
    {        
        if (systask != null)
            throw new ArgumentException();

        systask = Task.Run(() =>
        {
            try
            {
                iter(Run(), Notify);
            }
            catch (Exception e)
            {

                Notify(OrchestrationStartError(typeof(TSpec).Name, e));
            }
        });

        return systask;
    }


    void ICommandOrchestrator.Start()
    {
        if (Self.IsRunning)
        {
            Notify(OrchestratorAlreadyRunning(CommandName));
            return;
        }


        Notify(StartingOrchestration(CommandName));   

        Start();
    }

    void ICommandOrchestrator.Observe(ICommandPatternObserver observer)
        => observers.Add(observer);

    void ICommandOrchestrator<TSpec, TPayload>.Observe(ICommandPatternObserver<TSpec, TPayload> observer)
        => observers.Add(observer);

    bool ICommandOrchestrator.Wait(int timeout)
    {
        //returns true if the task is finished (or unspecified)
        if (systask != null)
            return systask.Wait(timeout);
        else
            return true;
    }

    /// <summary>
    /// Implements the <see cref="IDisposable.Dispose"/> operation
    /// </summary>
    protected override void Dispose()
    {
        if (systask != null)
            Cancel();
    }


}


