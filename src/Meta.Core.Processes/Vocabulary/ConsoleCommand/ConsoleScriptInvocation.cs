//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

public sealed class ConsoleScriptInvocation : ConsoleCommand<ScriptCommandInvocation>
{
    public ConsoleScriptInvocation(ScriptCommandInvocation command)
        : base(command, command.Command.Name, command.Command.Name)
    { }

    public override string ToString()
        => $"Script Command Invocation: {Subject}";

}
