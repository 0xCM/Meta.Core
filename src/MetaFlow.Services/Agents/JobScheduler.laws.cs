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
    
    public interface IJobScheduler : IServiceAgent
    {
        void ScheduleJob(ScheduledJob Operation);

        void CancelJob(JobIdentifier Operation);

        void PauseJob(JobIdentifier Operation);

        void ResumeJob(JobIdentifier operation);
    }
}