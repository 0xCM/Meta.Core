//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Defines non-generic command queue contract
/// </summary>
public interface ICommandQueue
{
    /// <summary>
    /// Places a set of commands on the queue
    /// </summary>
    /// <param name="commands">The commands to enqueue</param>
    Option<ReadOnlyList<CommandSubmission>> Enqueue(IEnumerable<ICommandSpec> commands, SystemNode target, CorrelationToken? ct = null);

    /// <summary>
    /// Enqueues a single command
    /// </summary>
    /// <param name="command">The command to enqueue</param>
    Option<CommandSubmission> Enqueue(ICommandSpec command, SystemNode target, CorrelationToken? ct = null);

    
    /// <summary>
    /// Removes a set of commands from the queue
    /// </summary>
    /// <param name="count">The maximum number of items to remove</param>
    /// <returns></returns>
    ReadOnlyList<CommandDispatch> Dispatch(int count);

    /// <summary>
    /// Dispatches a single command
    /// </summary>
    /// <returns></returns>
    Option<CommandDispatch> Dispatch();

    /// <summary>
    /// Purges any items currently in the queue
    /// </summary>
    void Empty();

    /// <summary>
    /// Determines whether any specified tasks remain to be executed
    /// </summary>
    /// <returns></returns>
    bool IsEmpty();

    /// <summary>
    /// Gets the name of the command that the queue is responsible for holding/dispening
    /// </summary>
    CommandName CommandName { get; }

    /// <summary>
    /// Gets the application task type
    /// </summary>
    Type SpecType { get; }

}


/// <summary>
/// Defines generic task queue contract
/// </summary>
public interface ICommandQueue<TSpec> : ICommandQueue
    where TSpec : CommandSpec<TSpec>, new()
{

    /// <summary>
    /// Places a set of commands on the queue
    /// </summary>
    /// <param name="commands">The commands to enqueue</param>
    Option<ReadOnlyList<CommandSubmission<TSpec>>> Enqueue(IEnumerable<TSpec> commands, SystemNode target, CorrelationToken? ct = null);

    /// <summary>
    /// Enqueues a single command
    /// </summary>
    /// <param name="command"></param>
    Option<CommandSubmission<TSpec>> Enqueue(TSpec command, SystemNode target, CorrelationToken? ct = null);

    /// <summary>
    /// Removes a set of items from the queue
    /// </summary>
    /// <param name="count">The maximum number of items to remove</param>
    /// <returns></returns>
    new ReadOnlyList<CommandDispatch<TSpec>> Dispatch(int count);

    /// <summary>
    /// Dispatches a single command
    /// </summary>
    /// <returns></returns>
    new Option<CommandDispatch<TSpec>> Dispatch();


}
