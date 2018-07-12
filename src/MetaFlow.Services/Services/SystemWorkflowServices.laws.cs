//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;

    using static metacore;

    public interface ISystemWorkflowServices : INodeService
    {
        ISystemTaskHandler TaskHandler { get; }

        ICommandSpecSerializer MessageSerializer { get; }
    }
}