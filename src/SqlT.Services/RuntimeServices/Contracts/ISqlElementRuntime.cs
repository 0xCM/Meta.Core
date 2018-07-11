//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;

    using SqlT.Core;

    /// <summary>
    /// Base interface for live/runtime database element representations
    /// </summary>
    public interface ISqlElementRuntime
    {
        /// <summary>
        /// The facilitating broker
        /// </summary>
        ISqlClientBroker Broker { get; }
    }

}