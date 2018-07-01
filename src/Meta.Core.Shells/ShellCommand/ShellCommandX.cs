//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public static class ShellCommandX
{
    public static IConsoleCommand ToShellCommand(this ICommandSpec command, int pos = 0)
        => new ConsoleCommand(command, pos);

    public static IConsoleCommand ToShellCommandFactory(this ICommandSpec prototype, int pos = 0)
        => new ConsoleCommandFactory(prototype, pos);

}