//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    public abstract class SystemAgentSettings<S> : ServiceAgentSettings<S>
        where S : SystemAgentSettings<S>
    {

        public SystemAgentSettings(IConfigurationProvider configure, AgentIdentifier AgentId)
            : base(configure, AgentId)
        {

        }

        public override int SpinFrequency
            => 1000;

    }


    public sealed class SystemAgentSettings : SystemAgentSettings<SystemAgentSettings>
    {
        public SystemAgentSettings(IConfigurationProvider configure, AgentIdentifier AgentId)
            : base(configure, AgentId)
        {

        }
    }





}