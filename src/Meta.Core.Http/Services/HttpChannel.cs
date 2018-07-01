//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Http;
    using System.IO;

    using static metacore;
    using static Outcome;


    /// <summary>
    /// Realizes a <see cref="IHttpChannel"/>, an abstraction of a communication pathway between client and server
    /// </summary>
    public class HttpChannel : IHttpChannel
    {
        static Outcome<HttpReply> SystemFailed(Exception e, HttpRequestSpec spec) 
            => Outcome.Fail<HttpReply>(HttpStatusMessages.SystemError(e.ToString()));        

        static Outcome<HttpReply> InterpretWebException(WebException we, HttpRequestSpec spec)
        {
            try
            {
                //If we can successfully retrieve an error response, then whatever
                //happened is not considered a systemic failure
                var response = we.Response;
                if (response == null)
                    return SystemFailed(we, spec);

                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var data = reader.ReadToEnd();
                    var descriptor = new HttpReplyStatus
                            (
                                ProtocolCode: response.GetHttpStatusCode(),
                                SystemCode: SystemResultCodes.Success
                            );


                    return new Outcome<HttpReply>(true, new HttpReply(descriptor, data),
                        HttpStatusMessages.ErrorStatus(descriptor, data));

                }

            }
            catch (Exception e)
            {
                return SystemFailed(e, spec);
            }

        }

        static Outcome<HttpReply> InterpretError(Exception e, HttpRequestSpec spec) 
            => e is WebException ? InterpretWebException(e as WebException, spec)
                              : SystemFailed(e, spec);


        readonly HttpClient client;

        public HttpChannel(HttpClient client)
        {
            this.client = client;
        }

        public Uri BaseAddress 
            => client.BaseAddress;

        private static HttpRequestMessage CreateRequest(HttpRequestSpec spec)
        {
            var message = new HttpRequestMessage(spec.Method, spec.RequestUri.PathAndQuery);
            if(spec.Method != HttpMethods.DELETE)
            {
                var parameters = spec.Parameters.Render(false);
                message.Content = new StringContent(parameters, Encoding.UTF8, HttpMediaTypes.UrlEncoded);                                      
            }
            return message;
        }

        public Outcome<HttpReply> Send(HttpRequestSpec spec)
        {
            try
            {
                var request = CreateRequest(spec);
                var response = client.SendAsync(request).Result;

                var descriptor = new HttpReplyStatus
                (
                    ProtocolCode: HttpResultCodes.Find((int)response.StatusCode),
                    SystemCode: SystemResultCodes.Success
                );

                var data = response.Content.ReadAsStringAsync().Result;
                var notification = response.IsSuccessStatusCode 
                                 ? none<IApplicationMessage>() 
                                 : some(HttpStatusMessages.ErrorStatus(descriptor, data));
                return success(
                    new HttpReply(descriptor, data), 
                    notification.ValueOrDefault(ApplicationMessage.Empty)
                    );

            }
            catch (Exception e)
            {
                return InterpretError(e, spec);
            }

        }
    }

}
