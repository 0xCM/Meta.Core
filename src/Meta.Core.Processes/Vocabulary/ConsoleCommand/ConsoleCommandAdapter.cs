//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

public abstract class ConsoleCommand<C> : IConsoleCommand
{
    public int Position { get; }

    public C Subject { get; }

    public CommandName CommandName { get; }

    public string DisplayName { get;  }

    protected ConsoleCommand(C Subject, CommandName CommandName, string DisplayName = null, int Position = 0)
    {
        this.Subject = Subject;
        this.CommandName = CommandName;
        this.DisplayName = ifBlank(DisplayName, CommandName);
        this.Position = Position;
    }

    dynamic IConsoleCommand.Subject 
        => Subject;
}

public sealed class ConsoleCommand : ConsoleCommand<ICommandSpec>
{
    public ConsoleCommand(ICommandSpec command, int Position = 0)
        : base(command, command.CommandName, command.SpecName, Position)
    { }

    public override string ToString()
        => $"Adapted Command Spec: {Subject}";
}

