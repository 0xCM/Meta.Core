//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using N = SystemNodeIdentifier;

    public class NodeEndpoint : INodeEndpoint
    {

        protected NodeEndpoint(N Node, SystemUri Identifier, Type EndpointType, EndpointRole Role)
        {
            this.Node = Node;
            this.Identifier = Identifier;
            this.Role = Role;
            this.EndpointType = EndpointType;
        }

        public N Node { get; }

        public EndpointRole Role { get; }

        public SystemUri Identifier { get; }

        public Type EndpointType { get; }

        public override string ToString()
            => Identifier.ToString();
    }


    public class NodeEndpoint<X> : NodeEndpoint, INodeEndpoint<X>
    {
        public NodeEndpoint(N Node, SystemUri Identifier, EndpointRole Role)
            : base(Node, Identifier, typeof(X), Role)
        {
        }
    }
}
