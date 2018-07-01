//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static metacore;

public class CommandPatternObserver<TSpec> : ICommandPatternObserver<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    public CommandPatternObserver
        (
            CommandSpecifiedObserver<TSpec> Specified = null,
            CommandSubmissionObserver<TSpec> Submitted = null,
            CommandDispatchObserver<TSpec> Dispatched = null,
            CommandExecutionObserver<TSpec> Executed = null,
            CommandCompletionObserver<TSpec> Completed = null
        )
    {
        this.Specified = Specified;
        this.Submitted = Submitted;
        this.Dispatched = Dispatched;
        this.Executed = Executed;
        this.Completed = Completed;
    }

    public CommandSpecifiedObserver<TSpec> Specified { get; }

    public CommandSubmissionObserver<TSpec> Submitted { get; }

    public CommandDispatchObserver<TSpec> Dispatched { get; }

    public CommandExecutionObserver<TSpec> Executed { get; }

    public CommandCompletionObserver<TSpec> Completed { get; }

    void ICommandPatternObserver<TSpec>.OnCommandSpecified(TSpec spec)
        => Specified?.Invoke(spec);

    void ICommandPatternObserver<TSpec>.OnCommandSubmitted(ICommandSubmission<TSpec> submission)
        => Submitted?.Invoke(submission);

    void ICommandPatternObserver<TSpec>.OnCommandDispatched(ICommandDispatch<TSpec> dispatch)
        => Dispatched?.Invoke(dispatch);

    void ICommandPatternObserver<TSpec>.OnCommandExecuted(ICommandResult<TSpec> result)
        => Executed?.Invoke(result);

    void ICommandPatternObserver<TSpec>.OnCommandCompletion(ICommandCompletion<TSpec> completion)
        => Completed?.Invoke(completion);

    void ICommandPatternObserver.OnCommandSpecified(ICommandSpec spec)
        => Specified?.Invoke((TSpec)spec);

    void ICommandPatternObserver.OnCommandSubmitted(ICommandSubmission submission)
        => Submitted?.Invoke((ICommandSubmission<TSpec>)submission);

    void ICommandPatternObserver.OnCommandDispatched(ICommandDispatch dispatch)
        => Dispatched?.Invoke((ICommandDispatch<TSpec>)dispatch);

    void ICommandPatternObserver.OnCommandExecuted(ICommandResult result)
        => Executed?.Invoke((ICommandResult<TSpec>)result);

    void ICommandPatternObserver.OnCommandCompletion(ICommandCompletion completion)
        => Completed?.Invoke((ICommandCompletion<TSpec>)completion);

}

public class CommandPatternObserver
{
    public static CommandPatternObserver<TSpec, TPayload> Observe<TSpec, TPayload>(CommandExecutionObserver<TSpec, TPayload> Executed)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
        => new CommandPatternObserver<TSpec, TPayload>(Executed: Executed);
}

public sealed class CommandPatternObserver<TSpec, TPayload> : CommandPatternObserver<TSpec>, ICommandPatternObserver<TSpec, TPayload>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    public CommandPatternObserver
        (
            CommandSpecifiedObserver<TSpec> Specified = null,
            CommandSubmissionObserver<TSpec> Submitted = null,
            CommandDispatchObserver<TSpec> Dispatched = null,
            CommandExecutionObserver<TSpec, TPayload> Executed = null,
            CommandCompletionObserver<TSpec> Completed = null
        ) : base(Specified, Submitted, Dispatched, z => Executed((ICommandResult<TSpec, TPayload>)z), Completed)
    {
        this.Executed = Executed;
    }

    public new CommandExecutionObserver<TSpec, TPayload> Executed { get; }

    void ICommandPatternObserver<TSpec, TPayload>.OnCommandExecuted(ICommandResult<TSpec, TPayload> result)
        => Executed?.Invoke(result);
}
