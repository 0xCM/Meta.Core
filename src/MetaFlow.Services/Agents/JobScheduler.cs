//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    using static metacore;
    using static JobSchedulerMessages;
    using L = PlatformAgentLiterals;



    [ServiceAgent(L.JobScheduler), ApplicationService(L.JobScheduler)]
    public class JobScheduler : SystemAgent<JobScheduler, JobSchedulerSettings>, IJobScheduler

    {        
        ConcurrentDictionary<JobIdentifier, ScheduledJob> ScheduledJobs { get; }
            = new ConcurrentDictionary<JobIdentifier, ScheduledJob>();

        ConcurrentDictionary<JobIdentifier, Task> ExecutingJobs { get; }
            = new ConcurrentDictionary<JobIdentifier, Task>();

        public JobScheduler(INodeContext C)
            : base(C)
        {

        }

        ScheduledJobStatus CalcStatus(ScheduledJob Op)
        {
            if (ExecutingJobs.ContainsKey(Op.OpId))
                return ScheduledJobStatus.Running;

            if (!Op.IsActive)
                return ScheduledJobStatus.Paused;


            if (!Op.HasExecuted)
                return ScheduledJobStatus.ReadyForFirst;

            if (now() >= Op.NextAttempt)
                return ScheduledJobStatus.ReadyForNext;

            return ScheduledJobStatus.Sleeping;

        }


        void Invoke(ScheduledJob Op)
        {
            try
            {                
                Notify(ExecutingJob(Op));

                var result = Op.Op();
                var doneTS = now();
                Notify(ExecutedJob(Op));

                if (!ScheduledJobs.TryRemove(Op, out ScheduledJob old))
                    Notify(JobNotFound(Op));
                else
                {
                    var nextTS = result.MapValueOrDefault(frequency => doneTS + frequency, doneTS);
                    if(result)
                    {
                        var update = Op.RescheduleAfterSuccess(doneTS, nextTS);
                        if (ScheduledJobs.TryAdd(Op, update))
                            Notify(RescheduledAfterSuccess(Op, nextTS));
                        else
                            Notify(CouldNotReschedule(Op));
                    }
                    else
                    {
                        var update = Op.RescheduleAfterFailure(doneTS, nextTS);
                        if (ScheduledJobs.TryAdd(Op, update))
                            Notify(RescheduledAfterFailure(Op, nextTS));
                        else
                            Notify(CouldNotReschedule(Op));
                    }
                }

            }
            catch(Exception e)
            {
                Notify(JobAbended(Op.OpId, e));
            }
        }

        void BeginInvoke(ScheduledJob job)
        {
            var task = Task.Factory.StartNew(() => Invoke(job));
            ExecutingJobs.TryAdd(job, task);
            task.ContinueWith(t => ExecutingJobs.TryRemove(job));
        }
       
        protected override Option<int> DoWork()
        {

            int count = 0;

            if (ScheduledJobs.Count == 0)
            {
                Notify(NoEnlistedJobs());
                return count;
            }


            Notify(ExaminingJobs(ScheduledJobs.Count));

            foreach (var Op in ScheduledJobs.Values)
            {
                var opStatus = CalcStatus(Op);
                if(opStatus == ScheduledJobStatus.ReadyForNext || opStatus == ScheduledJobStatus.ReadyForFirst)
                {
                    Notify(JobReady(Op, opStatus));
                    BeginInvoke(Op);
                    count++;
                }
                else
                    Notify(JobNotReady(Op, opStatus));
            }

            if (count != 0)
                Notify(ScheduledBatch(count));
            else
                Notify(OperationsNotReady());

            return count;
        }

        void IJobScheduler.ScheduleJob(ScheduledJob job)
        {
            if (ScheduledJobs.ContainsKey(job))
                Notify(OperationAlreadyScheduled(job));
            else
            {
                if (ScheduledJobs.TryAdd(job, job.ScheduleFirst()))
                    Notify(ScheduledJob(job));
                else
                    Notify(CouldNotSchedule(job));               
            }

        }

        void IJobScheduler.CancelJob(JobIdentifier job)
        {
            if (ScheduledJobs.TryRemove(job))
                Notify(RemovedJob(job));
        }

        void IJobScheduler.PauseJob(JobIdentifier Op)
        {
            if (ScheduledJobs.TryRemove(Op, out ScheduledJob Pausing))
                ScheduledJobs.TryAdd(Op, Pausing.Deactivate());
            else
                Notify(JobNotFound(Op));
                
        }
        void IJobScheduler.ResumeJob(JobIdentifier Op)
        {
            if (ScheduledJobs.TryRemove(Op, out ScheduledJob Resuming))
                ScheduledJobs.TryAdd(Op, Resuming.Reactivate());
            else
                Notify(JobNotFound(Op));

        }
    }
}