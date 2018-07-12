//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public class CommandEmission
{
    public static CommandEmission Create(ICommandSpec command, Option<FilePath> OutputPath)
        => new CommandEmission(command, OutputPath);

    public CommandEmission(ICommandSpec CommandSpec, Option<FilePath> OutputPath)
    {
        this.CommandSpec = CommandSpec;
        this.OutputPath = OutputPath;
        this.Description = Succeeded
            ? AppMessage.Inform($"Emitted {CommandSpec.SpecName}")
            : OutputPath.Message;
    }

    public ICommandSpec CommandSpec { get; }

    public Option<FilePath> OutputPath { get; }

    public bool Succeeded
        => OutputPath.Exists;

    public IAppMessage Description { get; }

    public override string ToString()
        => Description.Format(false);

}

public class CommandEmission<TSpec> : CommandEmission
    where TSpec : CommandSpec<TSpec>, new()
{
    public CommandEmission(CommandSpec<TSpec> CommandSpec, Option<FilePath> OutputPath)
        : base(CommandSpec, OutputPath)
    {

    }

    public new TSpec CommandSpec
        => (TSpec)base.CommandSpec;
}