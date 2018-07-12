//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using static metacore;

    static class JobSchedulerMessages
    {
        public static IAppMessage CouldNotReschedule(JobIdentifier job)
            => error($"Could not reschedule {job}");

        public static IAppMessage CouldNotSchedule(JobIdentifier job)
            => error($"Unable to schedule {job}");

        public static IAppMessage JobNotFound(JobIdentifier job)
            => error($"Could not find {job}");

        public static IAppMessage JobAbended(JobIdentifier job, Exception e)
            => error($"Execution of {job} abended and will not be rescheduled: {e}");

        public static IAppMessage ScheduledJob(JobIdentifier job)
            => inform($"Scheduled {job}");

        public static IAppMessage ExecutingJob(JobIdentifier job)
            => inform($"Invoking scheduled job {job}");

        public static IAppMessage ExecutedJob(JobIdentifier job)
            => inform($"The scheduled job {job} completed");

        public static IAppMessage JobNotReady(JobIdentifier job, ScheduledJobStatus status)
            => babble($"The scheduled job {job} is not available for execution. Status: {status}");

        public static IAppMessage JobReady(JobIdentifier job, ScheduledJobStatus status)
            => babble($"The scheduled job {job} is ready for execution. Status: {status}");

        public static IAppMessage RemovedJob(JobIdentifier job)
            => inform($"Removed {job} from the schedule");

        public static IAppMessage RescheduledAfterSuccess(JobIdentifier job, DateTime next)
            => inform($"Rescheduled {job} to execute at {next} after successful completion");

        public static IAppMessage RescheduledAfterFailure(JobIdentifier job, DateTime next)
            => inform($"Rescheduled {job} to execute at {next} after failed completion");

        public static IAppMessage NoEnlistedJobs()
            => babble($"There are no jobs enlisted for scheduling");

        public static IAppMessage ExaminingJobs(int count)
            => inform($"Examining {count} jobs for potential execution");

        public static IAppMessage ScheduledBatch(int count)
            => inform($"Scheduled {count} jobs to execute");

        public static IAppMessage OperationsNotReady()
            => inform($"None of the registered jobs are ready to execute");

        public static IAppMessage OperationAlreadyScheduled(JobIdentifier job)
            => warn($"The job {job} has already been scheduled");

        public static IAppMessage OperationAlreadyExecuting(JobIdentifier job)
            => inform($"The {job} job is already executing");

    }


}