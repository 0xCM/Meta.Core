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
    /// Defines root contract for a server-side component that receives a request
    /// and replies with a response
    /// </summary>
    /// <typeparam name="TRequest">The request type</typeparam>
    /// <typeparam name="TResponse">The response type</typeparam>
    public interface IHttpHandler<in TRequest, out TResponse>
    {
        /// <summary>
        /// Accepts an incoming request and replies with a response
        /// </summary>
        /// <param name="request">The request to process</param>
        /// <returns></returns>
        TResponse Process(TRequest request);
    }

}
