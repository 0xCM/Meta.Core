//Generated at 5/12/2016 10:46:37 AM
using System;

namespace Meta.Core.Http
{
    public partial class HttpResultCodes : HostedFieldList<HttpResultCode, HttpResultCodes>
    {
            
        /// <Summary>
        /// Continue indicates that the client can continue with its request.
        /// </Summary>
        public static readonly HttpResultCode Continue = new HttpResultCode("Continue",100);
        
        /// <Summary>
        /// SwitchingProtocols indicates that the protocol version or protocol is being changed.
        /// </Summary>
        public static readonly HttpResultCode SwitchingProtocols = new HttpResultCode("SwitchingProtocols",101);
        
        /// <Summary>
        /// OK indicates that the request succeeded and that the requested information is in the response. This is the most common status code to receive.
        /// </Summary>
        public static readonly HttpResultCode OK = new HttpResultCode("OK",200);
        
        /// <Summary>
        /// Created indicates that the request resulted in a new resource created before the response was sent.
        /// </Summary>
        public static readonly HttpResultCode Created = new HttpResultCode("Created",201);
        
        /// <Summary>
        /// Accepted indicates that the request has been accepted for further processing.
        /// </Summary>
        public static readonly HttpResultCode Accepted = new HttpResultCode("Accepted",202);
        
        /// <Summary>
        /// NonAuthoritativeInformation indicates that the returned metainformation is from a cached copy instead of the origin server and therefore may be incorrect.
        /// </Summary>
        public static readonly HttpResultCode NonAuthoritativeInformation = new HttpResultCode("NonAuthoritativeInformation",203);
        
        /// <Summary>
        /// NoContent indicates that the request has been successfully processed and that the response is intentionally blank.
        /// </Summary>
        public static readonly HttpResultCode NoContent = new HttpResultCode("NoContent",204);
        
        /// <Summary>
        /// ResetContent indicates that the client should reset (not reload) the current resource.
        /// </Summary>
        public static readonly HttpResultCode ResetContent = new HttpResultCode("ResetContent",205);
        
        /// <Summary>
        /// PartialContent indicates that the response is a partial response as requested by a GET request that includes a byte range.
        /// </Summary>
        public static readonly HttpResultCode PartialContent = new HttpResultCode("PartialContent",206);
        
        /// <Summary>
        /// Ambiguous indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response.
        /// </Summary>
        public static readonly HttpResultCode Ambiguous = new HttpResultCode("Ambiguous",300);
        
        /// <Summary>
        /// Moved indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method
        /// </Summary>
        public static readonly HttpResultCode Moved = new HttpResultCode("Moved",301);
        
        /// <Summary>
        /// Found indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST
        /// </Summary>
        public static readonly HttpResultCode Found = new HttpResultCode("Found",302);
        
        /// <Summary>
        /// RedirectMethod automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET.
        /// </Summary>
        public static readonly HttpResultCode RedirectMethod = new HttpResultCode("RedirectMethod",303);
        
        /// <Summary>
        /// NotModified indicates that the client's cached copy is up to date. The contents of the resource are not transferred.
        /// </Summary>
        public static readonly HttpResultCode NotModified = new HttpResultCode("NotModified",304);
        
        /// <Summary>
        /// UseProxy indicates that the request should use the proxy server at the URI specified in the Location header.
        /// </Summary>
        public static readonly HttpResultCode UseProxy = new HttpResultCode("UseProxy",305);
        
        /// <Summary>
        /// Unused is a proposed extension to the HTTP/1.1 specification that is not fully specified.
        /// </Summary>
        public static readonly HttpResultCode Unused = new HttpResultCode("Unused",306);
        
        /// <Summary>
        /// RedirectKeepVerb indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request m
        /// </Summary>
        public static readonly HttpResultCode RedirectKeepVerb = new HttpResultCode("RedirectKeepVerb",307);
        
        /// <Summary>
        /// BadRequest indicates that the request could not be understood by the server. BadRequest is sent when no other error is applicable, or if the exact error is unknown or does not have its own error code.
        /// </Summary>
        public static readonly HttpResultCode BadRequest = new HttpResultCode("BadRequest",400);
        
        /// <Summary>
        /// Unauthorized indicates that the requested resource requires authentication. The WWW-Authenticate header contains the details of how to perform the authentication.
        /// </Summary>
        public static readonly HttpResultCode Unauthorized = new HttpResultCode("Unauthorized",401);
        
        /// <Summary>
        /// PaymentRequired is reserved for future use.
        /// </Summary>
        public static readonly HttpResultCode PaymentRequired = new HttpResultCode("PaymentRequired",402);
        
        /// <Summary>
        /// Forbidden indicates that the server refuses to fulfill the request.
        /// </Summary>
        public static readonly HttpResultCode Forbidden = new HttpResultCode("Forbidden",403);
        
        /// <Summary>
        /// NotFound indicates that the requested resource does not exist on the server.
        /// </Summary>
        public static readonly HttpResultCode NotFound = new HttpResultCode("NotFound",404);
        
        /// <Summary>
        /// MethodNotAllowed indicates that the request method (POST or GET) is not allowed on the requested resource.
        /// </Summary>
        public static readonly HttpResultCode MethodNotAllowed = new HttpResultCode("MethodNotAllowed",405);
        
        /// <Summary>
        /// NotAcceptable indicates that the client has indicated with Accept headers that it will not accept any of the available representations of the resource.
        /// </Summary>
        public static readonly HttpResultCode NotAcceptable = new HttpResultCode("NotAcceptable",406);
        
        /// <Summary>
        /// ProxyAuthenticationRequired indicates that the requested proxy requires authentication. The Proxy-authenticate header contains the details of how to perform the authentication.
        /// </Summary>
        public static readonly HttpResultCode ProxyAuthenticationRequired = new HttpResultCode("ProxyAuthenticationRequired",407);
        
        /// <Summary>
        /// RequestTimeout indicates that the client did not send a request within the time the server was expecting the request.
        /// </Summary>
        public static readonly HttpResultCode RequestTimeout = new HttpResultCode("RequestTimeout",408);
        
        /// <Summary>
        /// Conflict indicates that the request could not be carried out because of a conflict on the server.
        /// </Summary>
        public static readonly HttpResultCode Conflict = new HttpResultCode("Conflict",409);
        
        /// <Summary>
        /// Gone indicates that the requested resource is no longer available.
        /// </Summary>
        public static readonly HttpResultCode Gone = new HttpResultCode("Gone",410);
        
        /// <Summary>
        /// LengthRequired indicates that the required Content-length header is missing.
        /// </Summary>
        public static readonly HttpResultCode LengthRequired = new HttpResultCode("LengthRequired",411);
        
        /// <Summary>
        /// PreconditionFailed indicates that a condition set for this request failed, and the request cannot be carried out. Conditions are set with conditional request headers like If-Match, If-None-Match, or If-Unmodified-Since.
        /// </Summary>
        public static readonly HttpResultCode PreconditionFailed = new HttpResultCode("PreconditionFailed",412);
        
        /// <Summary>
        /// RequestEntityTooLarge indicates that the request is too large for the server to process.
        /// </Summary>
        public static readonly HttpResultCode RequestEntityTooLarge = new HttpResultCode("RequestEntityTooLarge",413);
        
        /// <Summary>
        /// RequestUriTooLong indicates that the URI is too long.
        /// </Summary>
        public static readonly HttpResultCode RequestUriTooLong = new HttpResultCode("RequestUriTooLong",414);
        
        /// <Summary>
        /// UnsupportedMediaType indicates that the request is an unsupported type.
        /// </Summary>
        public static readonly HttpResultCode UnsupportedMediaType = new HttpResultCode("UnsupportedMediaType",415);
        
        /// <Summary>
        /// RequestedRangeNotSatisfiable indicates that the range of data requested from the resource cannot be returned, either because the beginning of the range is before the beginning of the resource, or the end of the range is after the end of the resource.
        /// </Summary>
        public static readonly HttpResultCode RequestedRangeNotSatisfiable = new HttpResultCode("RequestedRangeNotSatisfiable",416);
        
        /// <Summary>
        /// ExpectationFailed indicates that an expectation given in an Expect header could not be met by the server.
        /// </Summary>
        public static readonly HttpResultCode ExpectationFailed = new HttpResultCode("ExpectationFailed",417);
        
        /// <Summary>
        /// UpgradeRequired indicates that the client should switch to a different protocol such as TLS/1.0.
        /// </Summary>
        public static readonly HttpResultCode UpgradeRequired = new HttpResultCode("UpgradeRequired",426);
        
        /// <Summary>
        /// InternalServerError indicates that a generic error has occurred on the server.
        /// </Summary>
        public static readonly HttpResultCode InternalServerError = new HttpResultCode("InternalServerError",500);
        
        /// <Summary>
        /// NotImplemented indicates that the server does not support the requested function.
        /// </Summary>
        public static readonly HttpResultCode NotImplemented = new HttpResultCode("NotImplemented",501);
        
        /// <Summary>
        /// BadGateway indicates that an intermediate proxy server received a bad response from another proxy or the origin server.
        /// </Summary>
        public static readonly HttpResultCode BadGateway = new HttpResultCode("BadGateway",502);
        
        /// <Summary>
        /// ServiceUnavailable indicates that the server is temporarily unavailable, usually due to high load or maintenance.
        /// </Summary>
        public static readonly HttpResultCode ServiceUnavailable = new HttpResultCode("ServiceUnavailable",503);
        
        /// <Summary>
        /// GatewayTimeout indicates that an intermediate proxy server timed out while waiting for a response from another proxy or the origin server.
        /// </Summary>
        public static readonly HttpResultCode GatewayTimeout = new HttpResultCode("GatewayTimeout",504);
        
        /// <Summary>
        /// HttpVersionNotSupported indicates that the requested HTTP version is not supported by the server.
        /// </Summary>
        public static readonly HttpResultCode HttpVersionNotSupported = new HttpResultCode("HttpVersionNotSupported",505);

    }

}
