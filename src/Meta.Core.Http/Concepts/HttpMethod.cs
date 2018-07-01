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

    using BclHttpMethod = System.Net.Http.HttpMethod;

    /// <summary>
    /// Identifies an HTTP method
    /// </summary>
    public class HttpMethod : ValueObject<HttpMethod>
    {
        public static implicit operator string(HttpMethod x) 
            => x.Name;

        public static implicit operator BclHttpMethod(HttpMethod x)
        {
            if (x == HttpMethods.DELETE)
                return BclHttpMethod.Delete;
            if (x == HttpMethods.GET)
                return BclHttpMethod.Get;
            if (x == HttpMethods.POST)
                return BclHttpMethod.Post;
            if (x == HttpMethods.PUT)
                return BclHttpMethod.Put;

            throw new NotSupportedException();
        }

        /// <summary>
        /// The name of the HTTP method, e.g., POST, GET, etc
        /// </summary>
        public readonly string Name;

        public HttpMethod(string Name)
        {
            this.Name = Name;
        }
    }
}
