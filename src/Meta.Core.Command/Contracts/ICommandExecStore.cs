//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;



/// <summary>
/// Defines contract for command execution queue repository
/// </summary>
public interface ICommandExecStore : ICommandSubmitter
{


    Option<CommandDispatch<TSpec>> Dispatch<TSpec>()
        where TSpec : CommandSpec<TSpec>, new();

    Option<ReadOnlyList<CommandDispatch<TSpec>>> Dispatch<TSpec>(int MaxCount)
        where TSpec : CommandSpec<TSpec>, new();

    Option<ReadOnlyList<ICommandDispatch>> Dispatch(int MaxCount);

    Option<ReadOnlyList<ICommandCompletion>> Complete(IEnumerable<ICommandResult> results);

    Option<ICommandCompletion> Complete(ICommandResult result);    

    Option<ReadOnlyList<CommandCompletion<TSpec, TPayload>>> Complete<TSpec, TPayload>
        (IEnumerable<CommandResult<TSpec, TPayload>> results) where TSpec : CommandSpec<TSpec, TPayload>, new();

    Option<CommandCompletion<TSpec>> Complete<TSpec>
        (CommandResult<TSpec> result) where TSpec : CommandSpec<TSpec>, new();

    Option<CommandCompletion<TSpec, TPayload>> Complete<TSpec, TPayload>
        (CommandResult<TSpec, TPayload> result) where TSpec : CommandSpec<TSpec, TPayload>, new();

    Option<int> GetCurrentSubmissionCount();

    Option<int> PurgeSubmissions(Option<CommandName> CommandName);

    Option<int> PurgeDispatches(Option<CommandName> CommandName);

    Option<int> PurgeCompletions(Option<CommandName> CommandName);

    /// <summary>
    /// Purges the queues for a specific command, if supplied. Otherwise, purges all queues
    /// </summary>
    /// <param name="CommandName">The name of the command for which the queues will be purged</param>
    /// <returns></returns>
    Option<int> PurgeQueues(Option<CommandName> CommandName);


}
