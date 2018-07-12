//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using MetaFlow.WF;

    public interface ISystemEventHub : INodeService
    {
        void RaiseEvent<TBody>(ISystemEventCapture<TBody> @event)
            where TBody : class, ISystemEvent, new();

        
    }
}