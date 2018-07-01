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
    /// Characterizes an HTTP request
    /// </summary>
    /// <remarks>
    /// An instance of this type contains the necessary and sufficient data to submit the represented subject to
    /// an HTTP server.
    /// </remarks>
    public sealed class HttpRequestSpec : ValueObject<HttpRequestSpec>
    {
        /// <summary>
        /// The HTTP method to use 
        /// </summary>
        public readonly HttpMethod Method;

        /// <summary>
        /// The (full) URI to which the request will be directed
        /// </summary>
        public readonly Uri RequestUri;

        /// <summary>
        /// The MIME type of the request
        /// </summary>
        public readonly HttpMediaType ContentType;

        /// <summary>
        /// The attributes/parameters of the request
        /// </summary>
        public readonly IReadOnlyList<HttpRequestParameter> Parameters;

        public HttpRequestSpec(HttpMethod Method, Uri RequestUri, HttpMediaType ContentType, 
                IEnumerable<HttpRequestParameter> Parameters)
        {
            this.Method = Method;
            this.RequestUri = RequestUri;
            this.ContentType = ContentType;
            this.Parameters = rovalues(Parameters);
        }

        public HttpRequestSpec
            (
                HttpMethod Method,
                Uri RequestUri,
                HttpMediaType ContentType,
                params HttpRequestParameter[] Parameters
            ) : this(Method, RequestUri, ContentType, Parameters.ToList())
        {
        }

        public override string ToString() 
            => $"{Method} {RequestUri}";
    }
}
