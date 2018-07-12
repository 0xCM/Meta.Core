//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;

    public interface ISystemContext : INodeContext
    {
        SystemIdentifier ExecutingSystem { get; }
    }

}