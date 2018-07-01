//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;

/// <summary>
/// Defines contract for a weakly-typed command processor
/// </summary>
public interface ICommandProcessor
{
    CommandResult ProcessCommand(ICommandSpec command);
    IEnumerable<CommandResult> ProcessCommands(IEnumerable<ICommandSpec> commands);
}

/// <summary>
/// Defines contract for a strongly-typed command processor that yields a weakly-typed payload
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
public interface ICommandProcessor<TSpec> : ICommandProcessor
    where TSpec : CommandSpec<TSpec>, new()
{
    CommandResult<TSpec> ProcessCommand(TSpec command);

    IEnumerable<CommandResult<TSpec>> ProcessCommands(IEnumerable<TSpec> commands);
}


/// <summary>
/// Defines contract for a fully-generic command processor
/// </summary>
/// <typeparam name="TSpec">The command specification type</typeparam>
/// <typeparam name="TPayload">The type of value computed by a successfully executed command</typeparam>
public interface ICommandProcessor<TSpec, TPayload> : ICommandProcessor<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    new CommandResult<TSpec, TPayload> ProcessCommand(TSpec command);

    new IEnumerable<CommandResult<TSpec, TPayload>> ProcessCommands(IEnumerable<TSpec> commands);
}

