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
    /// Characterizes the outcome of an HTTP request
    /// </summary>
    public class HttpReplyStatus : ValueObject<HttpReplyStatus>
    {
        public static implicit operator System.Net.HttpStatusCode(HttpReplyStatus x) 
            =>  (System.Net.HttpStatusCode)x.ProtocolCode.Value;
        
        /// <summary>
        /// The HTTP protocol result code
        /// </summary>
        public readonly HttpResultCode ProtocolCode;

        /// <summary>
        /// The result code assigned by the Core framework to describe
        /// systemic success/failure
        /// </summary>
        public readonly SystemResultCode SystemCode;
        

        public HttpReplyStatus(HttpResultCode ProtocolCode, SystemResultCode SystemCode)
        {
            this.ProtocolCode = ProtocolCode;
            this.SystemCode = SystemCode;
        }

        /// <summary>
        /// Specifies whether the system code represents success
        /// </summary>
        public bool SystemSucceeded 
            => SystemCode.Success;

        /// <summary>
        /// Specifies whether the system code represents failure
        /// </summary>
        public bool SystemFailed 
            => !SystemCode.Success;

        /// <summary>
        /// Specifies whether the protocol code represents success
        /// </summary>
        public bool ProtocolSucceeded 
            => ProtocolCode.Success;

        /// <summary>
        /// Specifies whether the protocol code represents failure
        /// </summary>
        public bool ProtocolFailed 
            => !ProtocolCode.Success;

        /// <summary>
        /// Specifies whether the result represents a success from both system and protocol POV
        /// </summary>
        public bool Succeeded 
            => ProtocolSucceeded && SystemSucceeded;


        /// <summary>
        /// Specifies whether the result represents a failure from either system or protocol POV
        /// </summary>
        public bool Failed => ProtocolFailed || SystemFailed;

        public override string ToString()
            => ProtocolCode.ToString();

    }
}
