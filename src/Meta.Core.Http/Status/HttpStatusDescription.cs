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
    /// Describes the status of an HTTP operation
    /// </summary>
    public class HttpStatusDescription
    {
        public HttpStatusDescription(HttpReplyStatus Status, string ErrorResponse)
        {
            this.SystemResult = Status.SystemCode;
            this.ProtocolResult = Status.ProtocolCode;
            this.ErrorResponse = ErrorResponse;
        }

        /// <summary>
        /// Specifies the overall system result that indicates systemic success/failure
        /// </summary>
        public string SystemResult { get; private set; }

        /// <summary>
        /// Describres the result according to the HTTP protocol
        /// </summary>
        public string ProtocolResult { get; private set; }

        /// <summary>
        /// Details of the error response, if applicable
        /// </summary>
        public string ErrorResponse { get; private set; }

    }


}
