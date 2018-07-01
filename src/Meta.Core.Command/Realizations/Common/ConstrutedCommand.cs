public sealed class ConstructedCommand : IEmittedCommand
{
    public static ConstructedCommand<TSpec> Create<TSpec>(TSpec command, RelativePath OutputLocation = null)
        where TSpec : CommandSpec<TSpec>, new()
        => new ConstructedCommand<TSpec>(command, OutputLocation);

    readonly ICommandSpec Command;

    public ConstructedCommand(ICommandSpec Command, RelativePath OutputLocation = null)
    {
        this.Command = Command;
        this.OutputLocation = OutputLocation ?? string.Empty;
    }

    public RelativePath OutputLocation { get; }


    ICommandSpec IEmittedCommand.Command
        => Command;

    public override string ToString()
        => Command.ToString();

}

public sealed class ConstructedCommand<TSpec> : ValueObject<ConstructedCommand<TSpec>>, IEmittedCommand
    where TSpec : CommandSpec<TSpec>, new()
{

    public static implicit operator ConstructedCommand<TSpec>(TSpec command)
        => new ConstructedCommand<TSpec>(command);

    public ConstructedCommand(TSpec Command, RelativePath OutputLocation = null)
    {
        this.Command = Command;
        this.OutputLocation = OutputLocation ?? string.Empty;
    }

    public TSpec Command { get; }

    public RelativePath OutputLocation { get; }

    ICommandSpec IEmittedCommand.Command
        => Command;
}
