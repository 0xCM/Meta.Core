//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface ICommandExecutor<TSpec> : ICommandExecutor
    where TSpec : CommandSpec<TSpec>, new()
{
    CommandResult<TSpec> Execute(CommandDispatch<TSpec> dispatch);

    IReadOnlyList<CommandResult<TSpec>> Execute(IEnumerable<CommandDispatch<TSpec>> dispatches, bool concurrent);

    Type SpecType { get; }
}

public interface ICommandExecutor<TSpec, TPayload> : ICommandExecutor<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    new CommandResult<TSpec, TPayload> Execute(CommandDispatch<TSpec> dispatch);
    new IReadOnlyList<CommandResult<TSpec, TPayload>> Execute(IEnumerable<CommandDispatch<TSpec>> dispatches, bool concurrent);
}


