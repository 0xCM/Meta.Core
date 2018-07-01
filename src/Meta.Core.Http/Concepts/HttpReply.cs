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
    /// Lowest-level abstraction that encapsulates the response to an HTTP request
    /// </summary>
    public class HttpReply : ValueObject<HttpReply>
    {
        /// <summary>
        /// Characterizes the outcome of the request
        /// </summary>
        public readonly HttpReplyStatus Status;
        
        /// <summary>
        /// The received data, if any
        /// </summary>
        public readonly string Data;

        public HttpReply(HttpReplyStatus Status, string Data)
        {
            this.Status = Status;
            this.Data = Data;
        }


    }
}
