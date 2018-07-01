//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines the non-generic contract for queue executors
/// </summary>
public interface ICommandQueueExecutor
{

    /// <summary>
    /// Executes the orchestrator
    /// </summary>
    void ExecuteQueue();


    /// <summary>
    /// Tye type of task being orchestated
    /// </summary>
    Type SpecType { get; }

}
/// <summary>
/// Defines the contract for queue executors, generic with respect to command specification
/// </summary>
/// <typeparam name="TSpec">The type of task that will be orchestrated</typeparam>
public interface ICommandQueueExecutor<TSpec> : ICommandQueueExecutor
    where TSpec : CommandSpec<TSpec>, new()
{

}

/// <summary>
/// Defines the contract for queue executors, generic in both specification and payload
/// </summary>
/// <typeparam name="TSpec"></typeparam>
/// <typeparam name="TPayload"></typeparam>
public interface ICommandQueueExecutor<TSpec, TPayload> : ICommandQueueExecutor
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    void ExecuteQueue(Action<ICommandResult<TSpec, TPayload>> observer);
}

