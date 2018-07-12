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

    public interface ISystemEventReactor : INodeService
    {
        IEnumerable<SystemEventUri> SupportedEvents { get; }

        ISystemEventReaction React(ISystemEventCapture @event);
    }
}
