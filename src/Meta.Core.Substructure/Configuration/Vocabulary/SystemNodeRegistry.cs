//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Concurrent;

    using static minicore;


   class SystemNodeRegistry : ApplicationService<SystemNodeRegistry, ISystemNodeRegistry>, ISystemNodeRegistry
    {
        public SystemNodeRegistry(IApplicationContext C)
            : base(C)
        {

            RegisterNodes(SystemNode.Local);
        }

        ConcurrentDictionary<SystemNodeIdentifier, SystemNode> index { get; }
            = new ConcurrentDictionary<SystemNodeIdentifier, SystemNode>();

        public Option<SystemNode> LookupNode(SystemNodeIdentifier identifier)
            => index.TryGetValue(identifier, out SystemNode node) ?
                node : none<SystemNode>();

        public Option<SystemNode> LookupNode(string name)
            => index.Values.FirstOrDefault(x => string.Compare(x.NodeName, name, true) == 0);

        public void RegisterNodes(params SystemNode[] nodes)
            => iter(nodes, node => index.TryAdd(node.NodeIdentifier, node));
    }
}