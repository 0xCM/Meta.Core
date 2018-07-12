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

    public interface ISystemEventCapture<TBody> : ISystemEventCapture, ICorrelated
        where TBody : class, ISystemEvent, new()
    {

        new TBody EventBody { get; }
    }
}