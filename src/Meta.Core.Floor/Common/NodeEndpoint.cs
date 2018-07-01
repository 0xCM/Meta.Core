﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using N = SystemNodeIdentifier;

    

    public interface INodeEndpoint
    {
        /// <summary>
        /// The hosting node
        /// </summary>
        SystemNodeIdentifier Node { get; }

        /// <summary>
        /// The hosting system
        /// </summary>
        SystemUri Identifier { get; }

        /// <summary>
        /// Covariance/contravariance
        /// </summary>
        EndpointRole Role { get; }

    }

    public interface INodeEndpoint<X> : INodeEndpoint
    {

    }


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