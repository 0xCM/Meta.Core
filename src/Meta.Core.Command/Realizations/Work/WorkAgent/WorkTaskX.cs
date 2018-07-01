//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;




    public static class WorkTaskExtensions
    {
        /// <summary>
        /// Waits on a set of supplied tasks to complete
        /// </summary>
        /// <param name="tasks">The tasks on which to wait</param>
        /// <param name="cancel">Cancellation token that allows an external context to cancel the wait</param>
        public static void WaitOn(this IEnumerable<WorkPartition> tasks, CancellationToken cancel)
            => Task.WaitAll(tasks.Select(x => x.ClrTask).ToArray(), cancel);
    }
}