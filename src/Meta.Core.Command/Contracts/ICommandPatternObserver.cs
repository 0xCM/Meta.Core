//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines the available non-generic operations for a pattern observer
/// </summary>
public interface ICommandPatternObserver
{
    /// <summary>
    /// Invoked when a command has been specified
    /// </summary>
    /// <param name="spec">The command specification</param>
    void OnCommandSpecified(ICommandSpec spec);

    /// <summary>
    /// Invoked when a command has been submitted
    /// </summary>
    /// <param name="submission">The command submission</param>
    void OnCommandSubmitted(ICommandSubmission submission);

    /// <summary>
    /// Invoked when a command has been dispatched
    /// </summary>
    /// <param name="dispatch">The command dispatch</param>
    void OnCommandDispatched(ICommandDispatch dispatch);

    /// <summary>
    /// Invoked when a command has been executed
    /// </summary>
    /// <param name="result">The result of executing the command</param>
    void OnCommandExecuted(ICommandResult result);

    /// <summary>
    /// Invoked when a command has completes is journey through the orchestration process
    /// </summary>
    /// <param name="completion"></param>
    void OnCommandCompletion(ICommandCompletion completion);
}


public interface ICommandPatternObserver<TSpec> : ICommandPatternObserver
where TSpec : CommandSpec<TSpec>, new()
{
    /// <summary>
    /// Invoked when a command has been specified
    /// </summary>
    /// <param name="spec">The command specification</param>
    void OnCommandSpecified(TSpec spec);

    /// <summary>
    /// Invoked when a command has been submitted
    /// </summary>
    /// <param name="submission">The command submission</param>
    void OnCommandSubmitted(ICommandSubmission<TSpec> submission);

    /// <summary>
    /// Invoked when a command has been dispatched
    /// </summary>
    /// <param name="dispatch">The command dispatch</param>
    void OnCommandDispatched(ICommandDispatch<TSpec> dispatch);

    /// <summary>
    /// Invoked when a command has been executed
    /// </summary>
    /// <param name="result">The result of executing the command</param>
    void OnCommandExecuted(ICommandResult<TSpec> result);

    /// <summary>
    /// Invoked when a command has completes is journey through the orchestration process
    /// </summary>
    /// <param name="completion"></param>
    void OnCommandCompletion(ICommandCompletion<TSpec> completion);

}

/// <summary>
/// Defines the available generic operations for a pattern observer
/// </summary>
public interface ICommandPatternObserver<TSpec, TPayload> : ICommandPatternObserver<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{

    /// <summary>
    /// Invoked when a command has been executed
    /// </summary>
    /// <param name="result">The result of executing the command</param>
    void OnCommandExecuted(ICommandResult<TSpec, TPayload> result);

}

