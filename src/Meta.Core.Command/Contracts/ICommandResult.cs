//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Defines contract for non-generic command execution result values
/// </summary>
public interface ICommandResult
{
    /// <summary>
    /// The specification that was executed
    /// </summary>
    ICommandSpec Spec { get; }

    /// <summary>
    /// The value computed by the command when executed, if successful
    /// </summary>
    object Payload { get; }

    /// <summary>
    /// Specifies whether the command executed successfully
    /// </summary>
    bool Succeeded { get; }

    /// <summary>
    /// A message describing the command execution outcome
    /// </summary>
    IAppMessage Message { get; }

    /// <summary>
    /// The identifier that was assigned when the command was submitted for execution
    /// </summary>
    long SubmissionId { get; }

    /// <summary>
    /// The correlation token, if any, that allows the represented execution to be
    /// associated with other command executions
    /// </summary>
    CorrelationToken? CorrelationToken { get; }
}


/// <summary>
/// Defines contract for command results, generic with respect to specification
/// </summary>
public interface ICommandResult<out TSpec> : ICommandResult
    where TSpec : CommandSpec<TSpec>, new()
{
    /// <summary>
    /// The value computed by the command when executed, if successful
    /// </summary>
    new TSpec Spec { get; }

}

/// <summary>
/// Defines contract for command results, generic with respect to specification and payload
/// </summary>
public interface ICommandResult<out TSpec, out TPayload> : ICommandResult<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    /// <summary>
    /// The value computed by the command when executed, if successful
    /// </summary>
    new TPayload Payload { get; }
}
