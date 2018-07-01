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

    using static metacore;

    /// <summary>
    /// Represents an HTTP status code defined by the HTTP protocol
    /// </summary>
    /// <remarks>
    /// See: https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
    /// </remarks>
    public sealed class HttpResultCode : ValueObject<HttpResultCode>
    {
        /// <summary>
        /// Implicitly converts the subject to its numeric code
        /// </summary>
        /// <param name="x">The result code to convert</param>
        public static implicit operator int(HttpResultCode x) 
            => x.Value;

        /// <summary>
        /// Implicitly converts the subject to its identifying name
        /// </summary>
        /// <param name="x">The result code to convert</param>
        public static implicit operator string(HttpResultCode x) 
            => x.Name;

        /// <summary>
        /// Whenever an HTTP result code is received, that is considered as "success" by the system
        /// irrespective of whether the protocol reported success
        /// </summary>
        /// <param name="x">The result code to convert</param>
        public static implicit operator HttpReplyStatus(HttpResultCode x) 
            =>  new HttpReplyStatus(x, SystemResultCodes.Success); 

        internal const int SystemErrorCode = 9999;

        static Range<int> SuccessRange = new Range<int>(200, 299);
        static Range<int> ClientErrorRange = new Range<int>(400, 499);
        static Range<int> ServerErrorRange = new Range<int>(500, 599);
        
        
        /// <summary>
        /// The common name used to indicate the status code
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The code value
        /// </summary>
        public readonly int Value;

        public HttpResultCode(string Name, int Value)
        {
            this.Name = Name;
            if (Value < 0 || (Value > 999 && Value != SystemErrorCode))
                throw new ArgumentException($"The error code value {Value} is not within an acceptable range");
            this.Value = Value;
        }


        /// <summary>
        /// Specifies whether the code indicates a successfully completed operation
        /// </summary>
        public bool Success 
            => SuccessRange.In(Value);

        /// <summary>
        /// Specifies whether the code indicates an error that occurred on the client
        /// </summary>
        public bool ClientError 
            => ClientErrorRange.In(Value);

        /// <summary>
        /// Specifies whether the code indicates an error that occurred on the server
        /// </summary>
        public bool ServerError 
            => ServerErrorRange.In(Value);

        /// <summary>
        /// Specifies whether the code indicates an error condition
        /// </summary>
        public bool Error 
            => ClientError || ServerError;

        public override string ToString()
            => $"{Value} {Name}";

    }
}
