//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface ICommandFactoryProvider
{
    Option<CommandFactory> Factory(CommandName CommandName, string FactoryName = null);

    Option<CommandFactory<TSpec>> Factory<TSpec>(string FactoryName = null)
        where TSpec : CommandSpec<TSpec>, new();

    Option<CommandFactory<TSpec, TPayload>> Factory<TSpec, TPayload>(string FactoryName = null)
        where TSpec : CommandSpec<TSpec, TPayload>, new();

    Option<CommandFactoryIdentifier> RegisterFactory<TSpec, TPayload>(CommandFactory<TSpec, TPayload> factory, string FactoryName = null)
        where TSpec : CommandSpec<TSpec, TPayload>, new();

}
