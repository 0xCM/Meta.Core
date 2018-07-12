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

    public class JobSchedulerSettings : SystemAgentSettings<JobSchedulerSettings>
    {

        public JobSchedulerSettings(IConfigurationProvider configure)
            : base(configure, JobScheduler.AgentIdentifier)
        {
            
        }

        public override int SpinFrequency
            => 1000;
    }
}