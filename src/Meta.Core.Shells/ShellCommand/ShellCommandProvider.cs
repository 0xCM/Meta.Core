//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

public class ShellCommandProvider : IShellCommandProvider
{
    
    public static void InjectProviders(IMutableContext Context, bool injectDefaultFactories)
    {
        var idx = 0;
        var commands = MutableList.Create<IConsoleCommand>();        
        var scp = Context.Service<IScriptCommandProvider>();
        if(scp != null)
        {
            var hostCommands = scp.GetCommands().Map(x => x.Adapt(idx++));
            commands.AddRange(hostCommands);
        }

        var cps = Context.Service<ICommandPatternSystem>();
        if(cps != null)
        {
            if (injectDefaultFactories)
            {
                var factorySpecs = cps.AvailableCommands().Map(x => x.ToShellCommandFactory(idx++));
                commands.AddRange(factorySpecs);
            }

            var storedSpecs = cps.StoredSpecs().Map(x => x.ToShellCommand(idx++)); ;
            commands.AddRange(storedSpecs);
        }
        Context.InjectService<IShellCommandProvider>(new ShellCommandProvider(commands));

    }

    readonly IEnumerable<IConsoleCommand> commands;

    public ShellCommandProvider(IEnumerable<IConsoleCommand> commands)
    {
        this.commands = commands;
    }

    public IEnumerable<IConsoleCommand> GetCommands()
        => commands;
}
