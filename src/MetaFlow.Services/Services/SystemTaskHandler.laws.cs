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

    using static metacore;

    public interface ISystemTaskHandler : INodeService
    {
        IEnumerable<SystemCommandUri> SupportedCommands { get; }

        ISystemTaskResult ExecuteTask(ISystemTask task);

        ISystemTaskResult ExecuteTask(ISystemTaskDefinition task);

    }    
}
