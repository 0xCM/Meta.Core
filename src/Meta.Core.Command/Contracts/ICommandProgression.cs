//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface ICommandProgression
{
    CommandExecutionStatus Status { get; }

    ICommandSpec Spec { get; }

    string CommandJson { get; }

    CommandName CommandName { get; }

    CorrelationToken? CorrelationToken { get; }
}

public interface ICommandProgression<TSpec> : ICommandProgression
    where TSpec : CommandSpec<TSpec>, new()
{
    new TSpec Spec { get; }

}

