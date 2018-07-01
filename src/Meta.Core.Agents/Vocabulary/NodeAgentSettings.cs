//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class NodeAgentSettings<S> : ServiceAgentSettings<S>
        where S : NodeAgentSettings<S>
    {

        public NodeAgentSettings(IConfigurationProvider configure, AgentIdentifier AgentId)
            : base(configure, AgentId)
        {

        }

        public override int SpinFrequency
            => 1000;

    }


    public sealed class NodeAgentSettings : NodeAgentSettings<NodeAgentSettings>
    {
        public NodeAgentSettings(IConfigurationProvider configure, AgentIdentifier AgentId)
            : base(configure, AgentId)
        {

        }
    }


}