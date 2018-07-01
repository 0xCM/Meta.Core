//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public interface ICommandQueueController<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    Option<IReadOnlyList<CommandSubmission<TSpec>>> Submit(IEnumerable<TSpec> commands, CorrelationToken? ct);

    Option<IReadOnlyList<CommandDispatch<TSpec>>> Dispatch(int MaxCount);

    Option<IReadOnlyList<CommandCompletion>> Complete(IEnumerable<CommandResult> results);

    Option<int> PurgeDispatches();

    Option<int> PurgeCompletions();

    Option<int> PurgeQueues();

    Option<int> PurgeAll();
}
