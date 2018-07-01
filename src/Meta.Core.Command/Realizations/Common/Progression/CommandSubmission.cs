//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;
public class CommandSubmission<TSpec> : CommandProgression<TSpec>, ICommandSubmission<TSpec>
    where TSpec : CommandSpec<TSpec>, new()

{
    

    readonly long subid;
    readonly DateTime ts;

    public CommandSubmission(ICommandSubmission src)
        : base(src)
    {
        this.subid = src.SubmissionId;
        this.ts = src.EnqueuedTime;

    }

    public CommandSubmission(CommandSubmission<TSpec> src)
        : base(src)
    {
        this.subid = src.subid;
        this.ts = src.ts;

    }

    public CommandSubmission(TSpec spec, long subid, string json, CorrelationToken? ct = null, DateTime? ts = null)
        : base(spec, json, ct)
    {
        this.subid = subid;
        this.ts = ts ?? now();
    }

    public long SubmissionId
        => subid;

    public DateTime EnqueuedTime
        => ts;

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Submitted;
}


public class CommandSubmission : CommandProgression, ICommandSubmission
{

    readonly long subid;
    readonly DateTime ts;

    /// <summary>
    /// Submission constructor function
    /// </summary>
    /// <typeparam name="TSpec">The command type</typeparam>
    /// <param name="spec">The command</param>
    /// <param name="subid">The submission id</param>
    /// <param name="json">The comand body formatted as json</param>
    /// <param name="ct">The correlation token</param>
    /// <param name="ts">The submission timestamp</param>
    /// <returns></returns>
    public static CommandSubmission<TSpec> Create<TSpec>(TSpec spec, long subid, string json, 
        CorrelationToken? ct = null, DateTime? ts = null)
            where TSpec : CommandSpec<TSpec>, new()
                => new CommandSubmission<TSpec>(spec, subid, json, ct, ts ?? now());


    public CommandSubmission(ICommandSubmission src)
    : base(src)
    {
        this.subid = src.SubmissionId;
        this.ts = src.EnqueuedTime;
    }

    public CommandSubmission(CommandSubmission src)
        : base(src)
    {
        this.subid = src.subid;
        this.ts = src.ts;
    }

    public CommandSubmission(ICommandSpec spec, long subid, string json, CorrelationToken? ct = null, DateTime? ts = null)
        : base(spec, json, ct)
    {
        this.subid = subid;
        this.ts = ts ?? now();
    }


    public long SubmissionId
        => subid;


    public DateTime EnqueuedTime
        => ts;

    public override CommandExecutionStatus Status
        => CommandExecutionStatus.Submitted;
}
