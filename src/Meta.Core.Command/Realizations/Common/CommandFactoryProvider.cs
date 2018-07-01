//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using static metacore;

class CommandFactoryProvider : ApplicationService<CommandFactoryProvider, ICommandFactoryProvider>, ICommandFactoryProvider
{

    readonly ConcurrentDictionary<CommandFactoryIdentifier, CommandFactoryAdapter> FactoryIndex 
        = new ConcurrentDictionary<CommandFactoryIdentifier, CommandFactoryAdapter>();

    static CommandFactoryAdapter AdaptFactory<TSpec, TPayload>(CommandFactory<TSpec, TPayload> factory)
        where TSpec : CommandSpec<TSpec, TPayload>, new()
    {
        CommandFactory F0 = context
            => factory(context).Cast<ICommandSpec>();

        CommandFactory<TSpec> F1 = context
            => factory(context);

        CommandFactory<TSpec,TPayload> F2 = context
            => factory(context);

        return new CommandFactoryAdapter(F0, F1, F2);
    }

    public CommandFactoryProvider(IApplicationContext context)
        : base(context)
    {

    }

    static CommandName GetCommandName<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => CommandSpecDescriptor.FromSpecType<TSpec>().CommandName;

    Option<CommandFactoryIdentifier> ICommandFactoryProvider.RegisterFactory<TSpec, TPayload>
        (CommandFactory<TSpec, TPayload> factory, string FactoryName)
    {
        var identifier = CommandFactoryIdentifier.Create(GetCommandName<TSpec>(), FactoryName);
        var succeeded = FactoryIndex.TryAdd(identifier, AdaptFactory(factory));
        return 
            succeeded ? identifier : none<CommandFactoryIdentifier>();
    }

    Option<CommandFactory> ICommandFactoryProvider.Factory(CommandName CommandName, string FactoryName)
        =>  FactoryIndex
            .TryFind(CommandFactoryIdentifier.Create(CommandName, FactoryName))
            .MapValueOrDefault(adapter => adapter.Factory());

    Option<CommandFactory<TSpec>> ICommandFactoryProvider.Factory<TSpec>(string FactoryName)
        => FactoryIndex
            .TryFind(CommandFactoryIdentifier.Create(GetCommandName<TSpec>(), FactoryName))
            .MapValueOrDefault(adapter => adapter.Factory<TSpec>());

    Option<CommandFactory<TSpec, TPayload>> ICommandFactoryProvider.Factory<TSpec, TPayload>(string FactoryName)
        => FactoryIndex
            .TryFind(CommandFactoryIdentifier.Create(GetCommandName<TSpec>(), FactoryName))
            .MapValueOrDefault(adapter => adapter.Factory<TSpec,TPayload>());
}