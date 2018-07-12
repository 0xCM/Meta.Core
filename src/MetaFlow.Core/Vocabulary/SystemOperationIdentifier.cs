//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Linq;

    public sealed class SystemOperationIdentifier : SemanticIdentifier<SystemOperationIdentifier, SystemUri>
    {

        public static implicit operator SystemOperationIdentifier(SystemUri x)
            => new SystemOperationIdentifier(x);

        protected override SystemOperationIdentifier New(string Representation)
            => new SystemOperationIdentifier(SystemUri.Parse(Representation));


        SystemOperationIdentifier()
            : base(SystemUri.Empty)
        { }

        public SystemOperationIdentifier(SystemUri uri)
            : base(uri)
        {

        }

        public SystemOperationIdentifier(SystemNodeIdentifier NodeId, SystemOperation Operation)
            : base(new SystemUri(new SystemUri.SchemeSegment("metaflow.sysop"), new SystemUri.HostSegment(NodeId), new SystemUri.PathSegment($"{Operation}")))
        {


        }

        public SystemNodeIdentifier NodeId
            => Identifier.Host.Text;

        public SystemIdentifier SystemId
            => Identifier.Path.Components().First();

        public string HostType
            => Identifier.Path.Components().Second();

        public CommandName LocalName
            => Identifier.Path.Components().Third();

    }


}