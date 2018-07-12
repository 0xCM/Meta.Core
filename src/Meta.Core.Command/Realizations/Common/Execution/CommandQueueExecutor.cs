//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;


public class CommandQueueExecutor<TSpec>
    : ApplicationService<CommandQueueExecutor<TSpec>, ICommandQueueExecutor<TSpec>>, ICommandQueueExecutor<TSpec>
        where TSpec : CommandSpec<TSpec>, new()
{
    CommandOrchestrationSettings Settings
        => Context.Settings<CommandOrchestrationSettings>();


    private readonly ICommandExecutionService<TSpec> Pattern;

    public CommandQueueExecutor(IApplicationContext context, ICommandExecutionService<TSpec> Pattern)
        : base(context)
    {
        this.Pattern = Pattern;
    }



    Type ICommandQueueExecutor.SpecType
        => typeof(TSpec);


    /// <summary>
    /// Executes a set of commands
    /// </summary>
    /// <param name="commands">The tasks to execute</param>
    IReadOnlyList<ICommandResult<TSpec>> Execute(IReadOnlyList<CommandDispatch<TSpec>> commands)
        => Pattern.Executor.Execute(commands, Settings.ConcurrentProcessing);


    /// <summary>
    /// Allocates a block of scheduled tasks for execution
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<CommandDispatch<TSpec>> Dispatch()
        => Pattern.Queue.Dispatch(Settings.CommandBatchSize);


    public void ExecuteQueue(Action<ICommandResult<TSpec>> observer)
    {

        try
        {
            var commands = Dispatch();
            while (commands.Count != 0)
            {
                Execute(commands).Iterate(observer);
                commands = Dispatch();
            }

        }
        catch (Exception e)
        {
            Notify(AppMessage.Error(e));
            throw;
        }

    }

    /// <summary>
    /// Executes enqueued commands until there are no more
    /// </summary>
    public void ExecuteQueue()
        => ExecuteQueue(result => { });

}




public sealed class CommandQueueExecutor<TSpec,TPayload> : CommandQueueExecutor<TSpec>, ICommandQueueExecutor<TSpec,TPayload>
        where TSpec : CommandSpec<TSpec,TPayload>, new()
{
    CommandOrchestrationSettings Settings
        => Context.Settings<CommandOrchestrationSettings>();


    private readonly ICommandExecutionService<TSpec,TPayload> Pattern;

    public CommandQueueExecutor(IApplicationContext context, ICommandExecutionService<TSpec,TPayload> Pattern)
        : base(context, Pattern)
    {
        this.Pattern = Pattern;
    }


    public void ExecuteQueue(Action<ICommandResult<TSpec, TPayload>> observer)
       => base.ExecuteQueue(result =>
                observer(new CommandResult<TSpec, TPayload>(
                    result.Spec, (TPayload)result.Payload, result.Succeeded, result.Message, result.SubmissionId, result.CorrelationToken)));
}


