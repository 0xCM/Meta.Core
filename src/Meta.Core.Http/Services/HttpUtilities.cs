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

    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using static metacore;


    /// <summary>
    /// Defines basic utilities for working with HTTP services
    /// </summary>
    public static class HttpUtilities
    {
        /// <summary>
        /// Produces encoded text from the supplied parameters
        /// </summary>
        /// <param name="parameters">The parameters to be encoded</param>
        /// <param name="uriAppend">Specifies whether the parameters are being appended to a URL (as opposed to being sent via the request body)</param>
        /// <returns></returns>
        public static string Render(this IEnumerable<HttpRequestParameter> parameters, bool uriAppend = true)
        {
            var sb = new StringBuilder();
            iteri(parameters, (i, p) =>
            {
                on(i == 0 && uriAppend, () => sb.Append('?'));
                on(i != 0, () => sb.Append('&'));
                sb.Append($"{p.ParameterName}={p.ParameterValue}");
            });
            var data = sb.ToString();
            return Uri.EscapeUriString(data);

        }

        /// <summary>
        /// Retrieves a strongly-typed <see cref="HttpWebResponse"/> from a <see cref="WebRequest"/>
        /// </summary>
        /// <param name="r">The request from which a response will be retrieved</param>
        /// <returns></returns>
        public static HttpWebResponse GetHttpResponse(this WebRequest r) 
            =>  (HttpWebResponse)r.GetResponse();

        /// <summary>
        /// Translates a CLR response status code to a <see cref="HttpResultCode"/>
        /// </summary>
        /// <param name="r">The response that specifies the status code</param>
        /// <returns></returns>
        public static HttpResultCode GetHttpStatusCode(this WebResponse r) 
            => HttpResultCodes.Find(cast<int>(cast<HttpWebResponse>(r).StatusCode));

        /// <summary>
        /// Adds JSON media type to the accept headers
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static HttpClient AcceptJson(this HttpClient c)
        {
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpMediaTypes.Json));
            return c;
        }

        public static HttpClient AcceptAll(this HttpClient c)
        {
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*"));
            return c;
        }

        /// <summary>
        /// Specifies the timeout
        /// </summary>
        /// <param name="this"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static HttpClient WithTimeout(this HttpClient@this, int seconds)
        {
            @this.Timeout = TimeSpan.FromSeconds(seconds);
            return @this;
        }
    }
}
