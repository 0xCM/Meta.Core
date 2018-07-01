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
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enumerates the methods available in the HTTP protocol
    /// </summary>
    public class HttpMethods : HostedFieldList<HttpMethod, HttpMethods>
    {
        /// <summary>
        /// Identifies the HTTP POST method
        /// </summary>
        public static readonly HttpMethod POST = new HttpMethod(nameof(POST));
        
        /// <summary>
        /// Identifies the HTTP GET method
        /// </summary>
        public static readonly HttpMethod GET = new HttpMethod(nameof(GET));

        /// <summary>
        /// Identifies the HTTP PUT method
        /// </summary>
        public static readonly HttpMethod PUT = new HttpMethod(nameof(PUT));

        /// <summary>
        /// Identifies the HTTP PATCH method
        /// </summary>
        public static readonly HttpMethod PATCH = new HttpMethod(nameof(PATCH));

        /// <summary>
        /// Identifies the HTTP DELETE method
        /// </summary>
        public static readonly HttpMethod DELETE = new HttpMethod(nameof(DELETE));
    }
}
