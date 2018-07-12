//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;
    using MetaFlow.Core;

    public class SystemCommandAgentSettings : SystemAgentSettings<SystemCommandAgentSettings>
    {
        public SystemCommandAgentSettings(IConfigurationProvider configure)
            : base(configure, PlatformAgents.SystemCommandAgent)
        {

        }

        public override int SpinFrequency
            => 1000;
    }
}