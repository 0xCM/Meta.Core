//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MetaFlow.WF;

    public interface ISystemCommandRouter : INodeService
    {
        IEnumerable<SystemCommandUri> SupportedCommands { get; }

        ISystemTaskResult Route(ISystemTask task);

        ISystemTaskResult Route(ISystemTaskDefinition task);
    }
}