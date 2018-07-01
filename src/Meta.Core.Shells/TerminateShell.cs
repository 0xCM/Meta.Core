//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

[CommandSpec]
public class TerminateShell : CommandSpec<TerminateShell, int>
{

    public TerminateShell()
    {

    }

    public TerminateShell(SystemNodeIdentifier Host, string ShellName)
    {
        this.Host = Host;
        this.ShellName = ShellName;
        this.SpecName = concat($"{Host}/terminate-{ShellName}");
    }

    [CommandParameter]
    public SystemNodeIdentifier Host { get; set; }

    [CommandParameter]
    public string ShellName { get; set; }

    public override string ToString()
        => concat($"Terminating the {ShellName} shell on {Host}");
}

