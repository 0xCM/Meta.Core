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
    using System.Collections.Concurrent;

    using static metacore;

    public class MemoryQueueSystem<W, TResult> : IWorkQueueSystem<W, TResult>
        where W : IPartitionedWork

    {
        long lastid;

        readonly ConcurrentQueue<WorkSubmission<W>> enqueued = new ConcurrentQueue<WorkSubmission<W>>();
        readonly ConcurrentDictionary<long, WorkDispatch<W>> dispatched = new ConcurrentDictionary<long, WorkDispatch<W>>();
        readonly ConcurrentQueue<WorkCompletion<W, TResult>> completed = new ConcurrentQueue<WorkCompletion<W, TResult>>();


        public Option<WorkSubmission<W>> Submit(W work)
        {
            var submission = new WorkSubmission<W>(Interlocked.Increment(ref lastid), work);
            enqueued.Enqueue(submission);
            return submission;
        }

        public Option<WorkDispatch<W>> Dispatch()
        {
            var work = default(WorkSubmission<W>);
            if (enqueued.TryDequeue(out work))
            {
                var item = new WorkDispatch<W>(work);
                if (dispatched.TryAdd(item.WorkId, item))
                {
                    return item;
                }

            }
            return none<WorkDispatch<W>>();
        }

        public Option<WorkCompletion<W, TResult>> Complete(long workId, TResult result)
        {
            var work = default(WorkDispatch<W>);
            if (dispatched.TryRemove(workId, out work))
            {
                var completion = new WorkCompletion<W, TResult>(work, result);
                completed.Enqueue(completion);
                return completion;
            }
            return null;
        }
    }
}
