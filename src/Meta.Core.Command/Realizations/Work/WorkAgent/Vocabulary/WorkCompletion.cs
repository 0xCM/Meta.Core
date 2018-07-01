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
    /// Encapsulates the history of a unit of work that has been enqueued, dispatched
    /// and completed
    /// </summary>
    /// <typeparam name="W">The unit of work type</typeparam>
    /// <typeparam name="TResult">The value compted by the unit of work</typeparam>
    public class WorkCompletion<W, TResult> where W : IPartitionedWork
    {
        readonly WorkDispatch<W> work;
        readonly TResult result;
        readonly DateTime timestamp;

        public WorkCompletion(WorkDispatch<W> work, TResult result)
        {
            this.work = work;
            this.result = result;
            this.timestamp = now();
        }

        public W Work
            => work.Work;

        public long WorkId
            => work.WorkId;

        public DateTime EnqueuedTime
            => work.EnqueuedTime;

        public DateTime DispatchTime
            => work.DispatchTime;

        public DateTime CompleteTime
            => timestamp;

    }

}