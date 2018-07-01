//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Defines a synchronous communication pipe/pathway to communicate via HTTP
    /// </summary>
    public interface IHttpChannel
    {
        /// <summary>
        /// Sends a message via HTTP to the server identified by the <see cref="BaseAddress"/>
        /// </summary>
        /// <param name="spec">Characterizes the request to send</param>
        /// <returns></returns>
        Outcome<HttpReply> Send(HttpRequestSpec spec);

        /// <summary>
        /// The base address of the receiving server
        /// </summary>
        Uri BaseAddress { get; }
    }
}
