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
    /// Encodes aspects of an HTTP service definition and connects these aspects to source code elements
    /// </summary>
    public class HttpServiceSpec : ValueObject<HttpServiceSpec>
    {
                
       
        public HttpServiceSpec(IEnumerable<HttpActionSpec> Actions, IEnumerable<HttpParameterSpec> Parameters)
        {
            this.Actions = rolist(Actions);
            this.Parameters = rolist(Parameters);
        }

        /// <summary>
        /// The actions defined by the service
        /// </summary>
        public IReadOnlyList<HttpActionSpec> Actions { get; }

        /// <summary>
        /// The parameters recognized by the service
        /// </summary>
        public IReadOnlyList<HttpParameterSpec> Parameters { get; }

    }
}
