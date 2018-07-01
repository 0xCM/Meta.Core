//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface ICommandSubmitter
{
    Option<ReadOnlyList<CommandSubmission>> Submit(IEnumerable<ICommandSpec> Commands, SystemNode DstNode,  CorrelationToken? ct);

    Option<CommandSubmission> Submit(ICommandSpec Command, SystemNode DstNode, CorrelationToken? ct);

    Option<ReadOnlyList<CommandSubmission<TSpec>>> Submit<TSpec>(IEnumerable<TSpec> Commands, SystemNode DstNode, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec>, new();

}
