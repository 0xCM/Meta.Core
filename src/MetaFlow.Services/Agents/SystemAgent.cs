//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using SqlT.Core;

    /// <summary>
    /// Base type for agents that are identified with a specific subsystem
    /// </summary>
    /// <typeparam name="A">The specialized agent subtype</typeparam>
    /// <typeparam name="S">The specialized settings subtype</typeparam>
    public abstract class SystemAgent<A,S> : ServiceAgent<A,S>, INodeService
        where A : SystemAgent<A,S>
        where S : SystemAgentSettings<S>
    {
        new INodeContext C { get; }

        public SystemAgent(INodeContext C)
            : base(C)
        {
            this.C = C;
        }

        protected override SystemIdentifier System
            => GetType().DefiningSystem();


        protected ISqlProxyBroker PlatformBroker
            => C.PlatformBroker(C.Host);

        SystemNode INodeComponent.Host
            => C.Host;
    }

}