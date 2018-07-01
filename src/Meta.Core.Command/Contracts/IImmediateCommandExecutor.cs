//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Contract for executor that elides/bypasses the submit and dispatch phases
/// </summary>
public interface IImmediateCommandExecutor
{
    CommandResult Execute(ICommandSpec spec);

    IReadOnlyList<CommandResult> Execute(IEnumerable<ICommandSpec> specs, bool concurrent);

}
