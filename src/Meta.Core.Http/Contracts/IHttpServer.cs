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
    using System.Net.Http;


    /// <summary>
    /// Defines a server abstraction for client consumption
    /// </summary>
    public interface IHttpServer : IDisposable
    {
        /// <summary>
        /// Gets the client used for interacting with the server
        /// </summary>
        HttpClient Client { get; }
    }
}
