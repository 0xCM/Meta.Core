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
    /// Represents an HTTP request that encapsulates strongly-typed content
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public class HttpRequest<C> 
    {
        /// <summary>
        /// Implicitly extracts the content of the request
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator C(HttpRequest<C> x) 
            => x.Content;

        /// <summary>
        /// Implicitly extracts the request Base URI
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator Uri(HttpRequest<C> x) 
            => x.BaseUri;

        /// <summary>
        /// The encapsulated content
        /// </summary>
        public readonly C Content;

        /// <summary>
        /// The base address of the server to which the request is destined
        /// </summary>
        public readonly Uri BaseUri;

        public HttpRequest(C Content, Uri BaseUri)
        {
            this.Content = Content;
            this.BaseUri = BaseUri;
        }
    }

    /// <summary>
    /// Defines <see cref="HttpRequest{C}"/>-related utilities
    /// </summary>
    public static class HttpRequest
    {
        /// <summary>
        /// Utility for creating <see cref="HttpRequest{C}"/> values
        /// </summary>
        /// <typeparam name="C">The content type</typeparam>
        /// <param name="content">The content</param>
        /// <param name="BaseUri"></param>
        /// <returns></returns>
        public static HttpRequest<C> Create<C>(C content, Uri BaseUri) 
            => new HttpRequest<C>(content, BaseUri);
    }

}
