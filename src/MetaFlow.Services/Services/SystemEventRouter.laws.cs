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


    public interface ISystemEventRouter : INodeService
    {
        IEnumerable<SystemEventUri> SupportedEvents { get; }

        ISystemEventReaction Route(ISystemEventCapture @event);

    }
}