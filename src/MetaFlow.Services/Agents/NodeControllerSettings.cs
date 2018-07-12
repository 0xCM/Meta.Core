//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;

    using static metacore;

    public class NodeControllerSettings : SystemAgentSettings<NodeControllerSettings>
    {

        public NodeControllerSettings(IConfigurationProvider configure)
            : base(configure, PlatformAgentLiterals.NodeController)
        {

        }

        public override int SpinFrequency
            => 5000;

        public bool AutoStart
            => true;
    }

}