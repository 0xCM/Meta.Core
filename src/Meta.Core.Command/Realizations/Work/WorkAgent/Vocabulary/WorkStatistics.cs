//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using static metacore;

    public class WorkStatistics
    {
        int submitted;
        int dispatched;
        int completed;
        bool isSealed = false;
        DateTime startTime = now();
        DateTime? endTime;

        public int UpdateSubmissionCount(int NewSubmissions = 1)
            => Interlocked.Add(ref submitted, NewSubmissions);

        public int UpdateDipatchedCount(int NewDispatches = 1)
            => Interlocked.Add(ref dispatched, NewDispatches);

        public int UpdateCompletedCount(int NewCompletions = 1)
            => Interlocked.Add(ref completed, NewCompletions);

        public int TotalSubmissions
            => submitted;

        public int TotalDispatches
            => dispatched;

        public int TotalCompletions
            => completed;

        public int Duration
            => (int)((endTime ?? now()) - startTime).TotalSeconds;

        public void Include(WorkStatus status)
        {

            if (!isSealed)
            {
                switch (status)
                {
                    case WorkStatus.Submitted: UpdateSubmissionCount(); break;
                    case WorkStatus.Dispatched: UpdateDipatchedCount(); break;
                    case WorkStatus.Completed: UpdateCompletedCount(); break;
                }
            }
        }

        public void Seal()
        {
            endTime = now();
            isSealed = true;
        }

        public IAppMessage ToMessage()
            => AppMessage.Inform(
                $"{nameof(TotalSubmissions)}: @{nameof(TotalSubmissions)}, "
             + $"{nameof(TotalDispatches)}: @{nameof(TotalDispatches)}, " +
                $"{nameof(TotalCompletions)}: @{nameof(TotalCompletions)} " +
                $"{nameof(Duration)}: @{nameof(Duration)}s", this);
    }
}