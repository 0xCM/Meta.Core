//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    
    public enum ScheduledJobStatus
    {
        None = 0,
        Running,
        Paused,
        Sleeping,
        ReadyForNext,
        ReadyForFirst
    }
}