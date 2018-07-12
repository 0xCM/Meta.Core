//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using static metacore;

    public sealed class ScheduledJob
    {
        public static implicit operator JobIdentifier(ScheduledJob o)
            => o.OpId;

        public ScheduledJob
        (
            JobIdentifier OpId, 
            Func<Option<TimeSpan>> F, 
            DateTime? LastSuccess = null, 
            DateTime? LastFailure = null, 
            DateTime? NextAttempt = null
        )
        {
            this.OpId = OpId;
            this.Op = F;
            this.LastSuccess = LastSuccess;
            this.NextAttempt = NextAttempt;
            this.LastFailure = LastFailure;
        }

        public JobIdentifier OpId { get; }

        public Func<Option<TimeSpan>> Op { get; }

        public DateTime? LastSuccess { get; }

        public DateTime? LastFailure { get; }

        public DateTime? NextAttempt { get; }

        public override string ToString()
            => OpId;

        public bool HasExecuted
            => LastFailure == null 
            || LastSuccess == null;

        public bool IsActive
            => NextAttempt != null;

        public ScheduledJob Deactivate()
            => new ScheduledJob(OpId, Op, LastSuccess, LastFailure, null);

        public ScheduledJob Reactivate()
            => new ScheduledJob(OpId, Op, LastSuccess, LastFailure, now());

        public ScheduledJob ScheduleFirst()
            => new ScheduledJob(OpId, Op, NextAttempt: now());

        public ScheduledJob RescheduleAfterSuccess(DateTime LastSuccess, DateTime NextAttempt)
            => new ScheduledJob(OpId, Op, LastSuccess, LastFailure, NextAttempt);

        public ScheduledJob RescheduleAfterFailure(DateTime LastFailure, DateTime NextAttempt)
            => new ScheduledJob(OpId, Op, LastSuccess, LastFailure, NextAttempt);
    }
}