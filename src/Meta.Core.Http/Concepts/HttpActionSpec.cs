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
    /// Defines the contract for an HTTP action
    /// </summary>
    public sealed class HttpActionSpec : ValueObject<HttpActionSpec>
    {
        /// <summary>
        /// The service-specific action name
        /// </summary>
        public readonly string ActionName;

        /// <summary>
        /// The HTTP method
        /// </summary>
        public readonly HttpMethod HttpMethod;

        /// <summary>
        /// The host-relative URI
        /// </summary>
        public readonly string UriPath;

        /// <summary>
        /// The MIME type of the encapsulated content
        /// </summary>
        public readonly HttpMediaType ContentType;

        public HttpActionSpec(string ActionName, HttpMethod HttpMethod, string UriPath, HttpMediaType ContentType)
        {
            this.ActionName = ActionName;
            this.HttpMethod = HttpMethod;
            this.UriPath = UriPath;
            this.ContentType = ContentType;

        }

        public override string ToString() 
            => $"{ActionName} => HTTP {HttpMethod} {UriPath}";
    }
}
