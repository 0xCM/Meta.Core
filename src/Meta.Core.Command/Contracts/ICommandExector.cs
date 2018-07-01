//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines contract executor interaction in weakly-typed contexts. 
/// </summary>
/// <remarks>
/// Executors are components that are responsible for the ceremony of executing 
/// a command that has been dispatched
/// </remarks>
public interface ICommandExecutor
{
    /// <summary>
    /// Executes a single task
    /// </summary>
    /// <param name="dispatch">The task to execute</param>
    CommandResult Execute(CommandDispatch dispatch);

    /// <summary>
    /// Executes a set of commands
    /// </summary>
    /// <param name="dispatches">The tasks to execute</param>
    IReadOnlyList<CommandResult> Execute(IEnumerable<CommandDispatch> dispatches, bool concurrent);

}

