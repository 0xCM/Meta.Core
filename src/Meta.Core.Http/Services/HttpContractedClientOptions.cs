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
    /// Encapsulates settings for the <see cref="HttpContractedClient"/> realization
    /// of the <see cref="IDynamicContract"/>
    /// </summary>
    public class HttpContractedClientOptions
    {
        public HttpContractedClientOptions(IHttpRequestSpecifier RequestSpecifier, IHttpChannel Channel)
        {
            this.RequestSpecifier = RequestSpecifier;
            this.Channel = Channel;
        }

        /// <summary>
        /// The component used to construction <see cref="HttpRequestSpec"/> values
        /// </summary>
        public IHttpRequestSpecifier RequestSpecifier { get; private set; }

        /// <summary>
        /// The channel over which communication will occur
        /// </summary>
        public IHttpChannel Channel { get; private set; }
    }
}
