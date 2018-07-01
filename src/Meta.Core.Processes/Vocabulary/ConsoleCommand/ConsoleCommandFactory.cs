//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;



public sealed class ConsoleCommandFactory : ConsoleCommand<ICommandSpec>
{
    public ConsoleCommandFactory(ICommandSpec prototype, int Position = 0)
        : base(prototype, $"{prototype.CommandName}-factory", Position: Position)
    { }

}