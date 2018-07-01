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
    /// Enumerates common/useful media types
    /// </summary>
    /// <remarks>
    /// This will by hydrated from the database in a manner similar to the HTTP status codes
    /// </remarks>
    public class HttpMediaTypes : HostedFieldList<HttpMediaType, HttpMediaTypes>
    {
        /// <summary>
        /// Identifies JSON content
        /// </summary>
        public static readonly HttpMediaType Json = new HttpMediaType("application/json");

        /// <summary>
        /// Identifies URL-encoded content
        /// </summary>
        public static readonly HttpMediaType UrlEncoded = new HttpMediaType("application/x-www-form-urlencoded");

        /// <summary>
        /// Identifies text/html content
        /// </summary>
        public static readonly HttpMediaType TextHtml = new HttpMediaType("text/html");
    }
}
