//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

public class CommandCompletion<TSpec> : CommandDispatch<TSpec>, ICommandCompletion<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{



    readonly DateTime ts;

    public CommandCompletion(ICommandDispatch src, ICommandResult result, DateTime? ts = null)
        : base(src)
    {
        this.Result = new CommandResult<TSpec>(result);
        this.ts = ts ?? now();

    }

    public CommandCompletion(CommandDispatch<TSpec> src, CommandResult<TSpec> result, DateTime? ts = null)
        : base(src)
    {
        this.Result = result;
        this.ts = ts ?? now();

    }

    public DateTime CompleteTime
        => ts;

    public CommandResult<TSpec> Result { get; }

    public bool Succeeded
        => Result.Succeeded;

    public string CompleteMessage
        => Result.Message.Format();

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Completed;

    ICommandResult ICommandCompletion.Result
        => Result;

    ICommandResult<TSpec> ICommandCompletion<TSpec>.Result
        => Result;
}


public class CommandCompletion<TSpec, TPayload> : CommandCompletion<TSpec>, ICommandCompletion<TSpec, TPayload>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{


    public CommandCompletion(CommandDispatch<TSpec> src, CommandResult<TSpec, TPayload> result, DateTime? ts = null)
        : base(src, result, ts)
    {
        this.Result = result;
    }

    public new CommandResult<TSpec, TPayload> Result { get; }

    ICommandResult<TSpec, TPayload> ICommandCompletion<TSpec, TPayload>.Result
        => Result;

}

public class CommandCompletion : CommandDispatch, ICommandCompletion
{

    public static CommandCompletion<TSpec> Create<TSpec>(CommandDispatch<TSpec> src, CommandResult<TSpec> result, DateTime? ts = null)
        where TSpec : CommandSpec<TSpec>, new()
                => new CommandCompletion<TSpec>(src, result, ts);

    public static CommandCompletion<TSpec, TPayload> Create<TSpec, TPayload>(CommandDispatch<TSpec> src, CommandResult<TSpec, TPayload> result, DateTime? ts = null)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
                => new CommandCompletion<TSpec, TPayload>(src, result, ts);

    readonly DateTime ts;

    public CommandCompletion(ICommandDispatch src, ICommandResult result, DateTime? ts = null)
        : base(src)
    {
        this.ts = ts ?? now();
        this.Result = result;
    }

    public DateTime CompleteTime
        => ts;

    public bool Succeeded
        => Result.Succeeded;

    public string CompleteMessage
        => Result.Message.Format();

    public ICommandResult Result { get; }

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Completed;

}
