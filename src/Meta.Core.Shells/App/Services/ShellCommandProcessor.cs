//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Collections.Concurrent;
using Meta.Core;

using static metacore;

class ShellCommandProcessor : IShellCommandProcessor
{

    ConcurrentQueue<ICommandSpec> CommandQueue { get; }
        = new ConcurrentQueue<ICommandSpec>();

    IShellConsole Console { get; }

    Func<bool> Cancel { get; }

    public ShellCommandProcessor(IShellConsole Console, Func<bool> Cancel)
    {

        this.Console = Console;
        this.Cancel = Cancel;
    }


    public void PostCommand(ICommandSpec Command)
        => CommandQueue.Enqueue(Command);

    public Option<ICommandSpec> NextCommand()
    {

        ICommandSpec command = null;
        while (!Cancel())
        {
            if (CommandQueue.TryDequeue(out command))
                break;

            Task.Delay(250).Wait();
        }

        return isNull(command)
            ? none<ICommandSpec>()
            : some(command);

    }

}
