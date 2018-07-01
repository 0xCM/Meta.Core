//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines the contract for an agent that is responsible for coordinating
/// the execution of all commands of a specified type
/// </summary>
public interface ICommandOrchestrator : IDisposable
{

    /// <summary>
    /// Begins orchestration of the command, returns true 
    /// </summary>
    void Start();

    /// <summary>
    /// The type of command for which the orchestrator is responsible
    /// </summary>
    Type SpecType { get; }

    /// <summary>
    /// Suspends issuance of new execution requests and waits for currently executing tasks 
    /// to finish for a specified amount of time; the tasks that are still not finished
    /// are then themselves cancelled
    /// </summary>
    /// <returns>
    /// True if all commands that were executing prior to the Stop request have completed
    /// </returns>
    bool Stop(int timeout = -1);

    /// <summary>
    /// Suspends issuance of new execution requests and waits for currently executing tasks 
    /// to finish for a specified amount of time; however, does not kill/cancel currently executing tasks
    /// </summary>
    /// <returns>
    /// True if all commands that were executing prior to the Stop request have completed
    /// </returns>
    bool TryStop(int timeout = -1);

    /// <summary>
    /// Blocks until the orchestration completes or until the timeout, specified in milliseconds, is reached
    /// </summary>
    /// <returns>
    /// True if the run loop has completed
    /// </returns>
    bool Wait(int timeout = -1);

    /// <summary>
    /// Determines whether the orchestrator is currently running
    /// </summary>
    bool IsRunning { get; }

    /// <summary>
    /// Supplies an observer to which pertient events will be directed
    /// </summary>
    /// <param name="observer"></param>
    void Observe(ICommandPatternObserver observer);
}

/// <summary>
/// Generic version of the <see cref="ICommandOrchestrator"/> contract
/// </summary>
/// <typeparam name="TSpec"></typeparam>
public interface ICommandOrchestrator<TSpec> : ICommandOrchestrator
    where TSpec : CommandSpec<TSpec>, new()
{

}

/// <summary>
/// Generic version of the <see cref="ICommandOrchestrator"/> contract
/// </summary>
/// <typeparam name="TSpec"></typeparam>
/// <typeparam name="TPayload"></typeparam>
public interface ICommandOrchestrator<TSpec, TPayload> : ICommandOrchestrator<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    /// <summary>
    /// Supplies an observer to which pertient events will be directed
    /// </summary>
    /// <param name="observer"></param>
    void Observe(ICommandPatternObserver<TSpec, TPayload> observer);
}
