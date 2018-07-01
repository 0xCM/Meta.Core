//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;

    /// <summary>
    /// Represents a unit of work that has been liberated from the work queue
    /// and is in the process of being routed to a handler or is being executed
    /// </summary>
    /// <typeparam name="W">The work unit type</typeparam>
    public class WorkDispatch<W> where W : IPartitionedWork
    {
        private readonly WorkSubmission<W> work;
        private readonly DateTime timestamp;

        public WorkDispatch(WorkSubmission<W> work)
        {
            this.work = work;
            this.timestamp = now();
        }

        public W Work
            => work.Work;

        public long WorkId
            => work.WorkId;

        public DateTime EnqueuedTime
            => work.EnqueuedTime;

        public DateTime DispatchTime
            => timestamp;

    }

}