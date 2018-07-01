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
    /// Represents an HTTP request that encapsulates strongly-typed content
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public class HttpResponse<C> 
    {
        public HttpResponse(HttpReplyStatus Result, C Content)
        {
            this.Result = Result;
            this.Content = Content;
        }

        public HttpResponse(HttpReplyStatus Result)
        {
            this.Result = Result;
            this.Content = none<C>();
        }

        /// <summary>
        /// When applicable, contains the response content
        /// </summary>
        public Option<C> Content { get; }

        /// <summary>
        /// The status of the response
        /// </summary>
        public HttpReplyStatus Result { get; }


    }

    /// <summary>
    /// Defines <see cref="HttpResponse{C}"/>-related utilities
    /// </summary>
    public static class HttpResponse
    {
        public static HttpResponse<C> Create<C>(C r, HttpReplyStatus Result)
            where C : Representation<C> 
                => new HttpResponse<C>(Result, r);

        public static HttpResponse<C> Create<C>(HttpReplyStatus Result)
            where C : Representation<C> 
                => new HttpResponse<C>(Result);
    }

}
