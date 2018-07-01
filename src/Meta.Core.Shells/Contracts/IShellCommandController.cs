//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

public interface IShellCommandController
{
    IOption ExecuteCommand(ICommandSpec spec, CorrelationToken? ct);

    Task<IOption> ExecuteCommandAsync(ICommandSpec path, CorrelationToken? ct);

    IOption ExecuteCommand(FilePath path, CorrelationToken? ct);

    Task<IOption> ExecuteCommandAsync(FilePath path, CorrelationToken? ct);

    IOption SubmitCommand(ICommandSpec command, SystemNode target, CorrelationToken? ct);

    IOption SubmitCommand(FilePath path, SystemNode target, CorrelationToken? ct);
}

