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
    /// Encapsulates response received from an HTTP service request parameterized by the content/payload type
    /// </summary>
    /// <typeparam name="TContent">The content payload</typeparam>
    public class HttpServiceResponse<TContent> : ValueObject<HttpServiceResponse<TContent>>
    {
        /// <summary>
        /// The HTTP status code as defined and interpreted by the system and the HTTP protocol
        /// </summary>
        public readonly HttpReplyStatus ResultDescriptor;

        /// <summary>
        /// The response body
        /// </summary>
        public readonly TContent Content;

        public HttpServiceResponse(HttpReplyStatus ResultDescriptor, TContent Content)
        {
            this.ResultDescriptor = ResultDescriptor;
            this.Content = Content;
        }

        public override string ToString() 
            => ResultDescriptor.ToString();
    }


    /// <summary>
    /// Encapsulates response received from an HTTP service request where the payload type is uninterpreted
    /// and represented simply as a string
    /// </summary>
    public class HttpServiceResponse : HttpServiceResponse<string>
    {
        public HttpServiceResponse(HttpReplyStatus ResultDescriptor, string Content)
            : base(ResultDescriptor, Content)
        {
        }

    }
}