//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;

    public class SystemContext : NodeContext, ISystemContext
    {
        public SystemContext(INodeContext C, SystemIdentifier ExecutingSystem)
            : base(C, C.Host)
        {
            this.ExecutingSystem = ExecutingSystem;
        }


        public SystemIdentifier ExecutingSystem { get; }

        public override string ToString()
            => $"{Host}/{ExecutingSystem}";
    }


}