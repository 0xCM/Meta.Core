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
    using System.Reflection;

    /// <summary>
    /// Implementation responsible for producing an <see cref="HttpRequestSpec"/> from a description expressed
    /// in a specialized service domain vocabulary. Note that it is called a "Request Specifier"
    /// instead of a "Request Builder" because it doesn't actually build an HTTP request but,
    /// rather, constructs a <see cref="HttpRequestSpec"/> that characterizes a request
    /// </summary>
    public interface IHttpRequestSpecifier
    {
        /// <summary>
        /// Creates a request specification using the supplied information
        /// </summary>
        /// <param name="baseAddress">The base address of the server to which the request will be directed</param>
        /// <param name="m">The method that defines the contract for a request/reply exchange for a specific message</param>
        /// <param name="paramValues">The values by which the request is parameterized and which correspond to the method argument list</param>
        /// <returns></returns>
        HttpRequestSpec SpecifyRequest(Uri baseAddress, MethodInfo m, params object[] paramValues);
    }
}
