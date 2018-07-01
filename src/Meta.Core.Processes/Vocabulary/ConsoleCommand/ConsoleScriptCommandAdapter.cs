//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;


public sealed class ConsoleScriptCommandAdapter : ConsoleCommand<ScriptCommand>
{
    public ConsoleScriptCommandAdapter(ScriptCommand command, int Position = 0)
        : base(command, command.Name, command.ToString(), Position)
    { }

    public override string ToString()
        => $"Adapted Script Command: {Subject}";
}
