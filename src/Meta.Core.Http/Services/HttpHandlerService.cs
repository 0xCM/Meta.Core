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
    /// Defines base type for HTTP handler services that translate between domain-level and
    /// http-level vocabularies
    /// </summary>
    /// <typeparam name="DRequest">The domain request type</typeparam>
    /// <typeparam name="PRequest">The http proxy request type</typeparam>
    /// <typeparam name="PResponse">The http proxy response type</typeparam>
    /// <typeparam name="DResponse">The domain response type</typeparam>
    /// <remarks>
    /// This supports the request/response pattern where client code communicates
    /// in terms of the domain vocabulary while the lower-level communication between
    /// client and server uses the http proxy vocabulary. The purpose here is 
    /// to abstract the physical communication details from most aspects so the
    /// logical domain concepts are used; so, dependency on the lower-level
    /// request semantics is reduced. The basic flow supported is:
    ///     => DomainRequest 
    ///         => ToProxy(DomainRequest) 
    ///         => Submit(ProxyRequest)
    ///         => Receive(ProxyResponse)
    ///         => ToDomain(ProxyResponse) 
    ///     => DomainResponse
    /// Where the client is blissfully unaware of the mediating workflow
    /// </remarks>
    public abstract class HttpHandlerService<DRequest, PRequest, PResponse, DResponse>  : 
        Service<IHttpHandler<PRequest, HttpResponse<PResponse>>>,  IHttpHandler<PRequest, HttpResponse<PResponse>>
        where PResponse : ResponseProxy<PResponse>
        where PRequest : RequestProxy<PRequest>
        where DRequest : DomainRequest<DRequest>
        where DResponse : DomainResponse<DResponse>
    {
        public HttpHandlerService(IApplicationContext C)
            : base(C)
        {

        }

        /// <summary>
        /// Processes a domain-level request to yield a domain-level response
        /// </summary>
        /// <param name="request">The request to process</param>
        /// <returns></returns>
        protected abstract DResponse Process(DRequest request);

        /// <summary>
        /// Processes a proxy-level request to yield a proxy-level response
        /// </summary>
        /// <param name="request">The request to process</param>
        /// <returns></returns>
        public abstract HttpResponse<PResponse> Process(PRequest request);

        HttpResponse<PResponse> IHttpHandler<PRequest, HttpResponse<PResponse>>.Process(PRequest request) 
            => Process(request);

    }

}
