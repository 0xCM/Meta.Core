//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public sealed class CommandResult<TSpec> : ICommandResult<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    public static implicit operator CommandResult(CommandResult<TSpec> result)
        => result.Degrade();

    public CommandResult(ICommandResult src)
    {
        this.Spec = (TSpec)src.Spec;
        this.Payload = src.Payload;
        this.Succeeded = src.Succeeded;
        this.Message = src.Message;
        this.SubmissionId = src.SubmissionId;
        this.CorrelationToken = src.CorrelationToken;
    }

    public CommandResult(TSpec spec, object payload, bool succeeded, IAppMessage message, long subid, CorrelationToken? ct = null)
    {
        this.Spec = spec;
        this.Payload = payload;
        this.Succeeded = succeeded;
        this.Message = message;
        this.SubmissionId = subid;
        this.CorrelationToken = ct;
    }

    public TSpec Spec { get; private set; }

    public object Payload { get; private set; }

    public bool Succeeded { get; private set; }

    public IAppMessage Message { get; private set; }

    public long SubmissionId { get; private set; }

    public CorrelationToken? CorrelationToken { get; private set; }

    object ICommandResult.Payload 
        => Payload;

    ICommandSpec ICommandResult.Spec 
        => Spec;

    public CommandResult Degrade()
        => new CommandResult(Spec, Payload, Succeeded, Message, SubmissionId, CorrelationToken);
}

public sealed class CommandResult<TSpec, TPayload> : ICommandResult<TSpec,TPayload>
    where TSpec : CommandSpec<TSpec,TPayload>, new()
{
    public static implicit operator CommandResult(CommandResult<TSpec,TPayload> result)
        => result.Degrade();

    public static implicit operator CommandResult<TSpec>(CommandResult<TSpec, TPayload> result)
        => result.Degrade();

    public CommandResult(TSpec spec, TPayload payload, bool succeeded, IAppMessage message, 
        long subid, CorrelationToken? ct = null)
    {
        this.Spec = spec;
        this.Payload = payload;
        this.Succeeded = succeeded;
        this.Message = message ?? AppMessage.Empty;
        this.SubmissionId = subid;
        this.CorrelationToken = ct;
    }

    public TSpec Spec { get; private set; }

    public TPayload Payload { get; private set; }

    public bool Succeeded { get; private set; }

    public IAppMessage Message { get; private set; }

    public long SubmissionId { get; private set; }

    public CorrelationToken? CorrelationToken { get; private set; }

    object ICommandResult.Payload 
        => Payload;

    ICommandSpec ICommandResult.Spec 
        => Spec;

    public CommandResult<TSpec> Degrade()
        => new CommandResult<TSpec>(Spec, Payload, Succeeded, Message, SubmissionId, CorrelationToken);
}

public sealed class CommandResult : ICommandResult
{
    public static CommandResult Failure(ICommandSpec spec, IAppMessage message = null, 
        long? subid = null, CorrelationToken? ct = null)
            => new CommandResult(spec, null, false, message, subid ?? 0, ct);

    public static CommandResult<TSpec, TPayload> Failure<TSpec, TPayload>(TSpec spec,
        IAppMessage message = null, long? subid = null, CorrelationToken? ct = null)
            where TSpec : CommandSpec<TSpec, TPayload>, new()
                => new CommandResult<TSpec, TPayload>(spec, default, false, message, subid ?? 0, ct);

    public static CommandResult FromOption<TSpec, TResult>(TSpec spec, Option<TResult> result)
        where TSpec : CommandSpec<TSpec>, new()
            => result.MapValueOrElse(
                    (payload, message) => new CommandResult(spec, payload, true, message, 0, null),
                    (message) => new CommandResult(spec, default(TResult),  false, message, 0, null)
                    );
               
    public CommandResult(ICommandSpec spec, object payload, bool succeeded, IAppMessage message = null, 
        long subid = 0, CorrelationToken? ct = null)
    {
        this.Spec = spec;
        this.Payload = payload;
        this.Succeeded = succeeded;
        this.SubmissionId = subid;
        this.CorrelationToken = ct;
        this.Message = message ??
            (
                succeeded 
                ? CommandStatusMessages.CommandSucceeded(this)
                : CommandStatusMessages.CommandFailed(this)
            );
    }

    public long SubmissionId { get; private set; }

    public CorrelationToken? CorrelationToken { get; private set; }

    /// <summary>
    /// The value that represents or otherwise identifies the result computed by the command
    /// </summary>
    public object Payload { get; private set; }

    /// <summary>
    /// Specifies whether the command successfully executed which, by definition, means that
    /// a payload was successfully computed
    /// </summary>
    public bool Succeeded { get; private set; }

    public ICommandSpec Spec { get; private set; }

    public IAppMessage Message { get; private set; }

    public string CommandName
        => Spec.CommandName;

    public string CommandSpecName
        => Spec.SpecName;

    public override string ToString()
        => $"{CommandName} command " + (Succeeded 
            ? "succeeded" : "failed") + $": {Message}";
}

