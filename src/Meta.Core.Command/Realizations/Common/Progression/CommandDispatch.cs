//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;
public class CommandDispatch<TSpec> : CommandSubmission<TSpec>, ICommandDispatch<TSpec>
    where TSpec : CommandSpec<TSpec>, new()

{
    readonly DateTime ts;

    public CommandDispatch(ICommandDispatch src)
        : this(new CommandDispatch(src))
    { }

    public CommandDispatch(CommandDispatch src)
        : base(new CommandSubmission<TSpec>((TSpec)src.Spec, src.SubmissionId, src.CommandJson, src.CorrelationToken, src.EnqueuedTime))
    {
        this.ts = src.DispatchTime;
    }

    public CommandDispatch(CommandSubmission<TSpec> src, DateTime? ts = null)
        : base(src)
    {
        this.ts = ts ?? now();
    }

    public CommandDispatch(CommandDispatch<TSpec> src)
        : base(src)
    {
        this.ts = src.ts;
    }

    public DateTime DispatchTime
        => ts;

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Dispatched;
}

public class CommandDispatch : CommandSubmission, ICommandDispatch
{
    readonly DateTime ts;

    public static ICommandDispatch Create(CommandSubmission submission, DateTime? ts = null)
        => new CommandDispatch(submission, ts);

    public static CommandDispatch<TSpec> Create<TSpec>(CommandSubmission<TSpec> submission, DateTime? ts = null)
            where TSpec : CommandSpec<TSpec>, new()
                => new CommandDispatch<TSpec>(submission, ts);


    public CommandDispatch(ICommandSubmission src, DateTime? ts = null)
        : base(src)
    {
        this.ts = ts ?? now();
    }

    public CommandDispatch(ICommandDispatch src)
        : base(src)
    {
        this.ts = src.DispatchTime;
    }


    public DateTime DispatchTime
        => ts;

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Dispatched;

}
