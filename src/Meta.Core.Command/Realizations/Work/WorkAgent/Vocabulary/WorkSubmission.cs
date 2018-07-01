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

    using static metacore;

    public class WorkSubmission<W> where W : IPartitionedWork

    {
        readonly long workId;
        readonly W work;
        readonly DateTime timestamp;

        public WorkSubmission(long WorkId, W work)
        {
            this.workId = WorkId;
            this.work = work;
            this.timestamp = now();
        }

        public W Work
            => work;

        public long WorkId
            => workId;

        public DateTime EnqueuedTime
            => timestamp;

        public override string ToString()
            => $"WorkId {workId}: {Work}";

    }
}
