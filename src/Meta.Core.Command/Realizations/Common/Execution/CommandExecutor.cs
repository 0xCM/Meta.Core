//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;

using static CommandStatusMessages;

/// <summary>
/// Responsible for executing application commands
/// </summary>
/// <typeparam name="TSpec">The application Command type</typeparam>
/// <typeparam name="TPayload">The value computed by the command, or reference to this value, upon successful execution</typeparam>
public sealed class CommandExecutor<TSpec,TPayload> 
    :   ApplicationService<CommandExecutor<TSpec,TPayload>, ICommandExecutor<TSpec,TPayload>>, 
        ICommandExecutor<TSpec,TPayload>
        where TSpec : CommandSpec<TSpec,TPayload>, new()
{
    static CommandSpecDescriptor SpecDescriptor { get; }        
        = CommandSpecDescriptor.FromSpecType<TSpec>();

    public CommandExecutor(IApplicationContext context, ICommandExecutionService<TSpec,TPayload> Pattern)
        : base(context)
    {
        this.Pattern = Pattern;
    }

    ICommandExecutionService<TSpec, TPayload> Pattern { get; }

    public Type SpecType
        => typeof(TSpec);

    ICommandExecStore ExecStore
        => Context.Service<ICommandExecStore>();

    static IAppMessage CompletedCommand(ICommandResult result, Option<CommandCompletion<TSpec, TPayload>> completion)
    {
        return completion.Map(
            c => CommandStatusMessages.CompletedCommand(c), 
            () =>
            {
                if (result.Succeeded)
                    return CommandCompletionError(result, completion.Message);

                if (!result.Succeeded)
                    return CommandExecutionAndCompletionError(result, completion.Message);

                return AppMessage.Error("My logic is broken");
            });
    }

    CommandResult<TSpec, TPayload> ICommandExecutor<TSpec,TPayload>.Execute(CommandDispatch<TSpec> dispatch)
    {
        try
        {
            var spec = dispatch.Spec;
            Notify(ExecutingCommand(spec));
            var execution = Pattern.TryExecute(dispatch);
            var message = execution.Message;
            var payload = execution.ValueOrDefault();
            var success = execution.Exists;
            var result = new CommandResult<TSpec, TPayload>(spec, payload, success, message,  
                dispatch.SubmissionId, dispatch.CorrelationToken);
            Notify(CommandResultComputed(result));
            return result;
        }
        catch (Exception e)
        {
            var errorResult = new CommandResult<TSpec,TPayload>
            (
                dispatch.Spec, default, false, AppMessage.Error(e), 
                dispatch.SubmissionId, dispatch.CorrelationToken
            );
            Notify(errorResult.Message);
            return errorResult;
        }
    }

    IReadOnlyList<CommandResult<TSpec, TPayload>> ICommandExecutor<TSpec, TPayload>.Execute(
        IEnumerable<CommandDispatch<TSpec>> dispatches, bool concurrent)        
        => concurrent
        ? dispatches.AsParallel().Select(d => Self.Execute(d)).ToList()
        : dispatches.Select(d => Self.Execute(d)).ToList();

    CommandResult ICommandExecutor.Execute(CommandDispatch dispatch)
        => (this as ICommandExecutor<TSpec, TPayload>).Execute(new CommandDispatch<TSpec>(dispatch));

    IReadOnlyList<CommandResult> ICommandExecutor.Execute(IEnumerable<CommandDispatch> dispatches, bool concurrent)
        => (this as ICommandExecutor<TSpec, TPayload>)
            .Execute(dispatches.Select(
               d => new CommandDispatch<TSpec>(d)), concurrent)
                            .Map(x => x.Degrade().Degrade());

    CommandResult<TSpec> ICommandExecutor<TSpec>.Execute(CommandDispatch<TSpec> dispatch)
        => (this as ICommandExecutor<TSpec, TPayload>).Execute(dispatch);

    IReadOnlyList<CommandResult<TSpec>> ICommandExecutor<TSpec>.Execute(IEnumerable<CommandDispatch<TSpec>> dispatches, bool concurrent)
        => (this as ICommandExecutor<TSpec, TPayload>)
            .Execute(dispatches, concurrent).Map(x => x.Degrade());
}


