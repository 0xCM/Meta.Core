//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    using MetaFlow.Core;
    using MetaFlow.WF;

    public interface ISystemMessageConverter : INodeService
    {
        IAppMessage ToApplicationMessage<TBody>(ISystemEventCapture<TBody> @event)
            where TBody : class, ISystemEvent, new()
            ;

    }


}