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
    using System.Net;
    using System.Net.Http;
    using System.Configuration;
    
    public static class HttpBasicClient
    {

        const string JsonMediaType = "application/json";

        public static Uri HostAddress = SystemUri.Empty;
            //=> new Uri(ConfigurationManager.AppSettings[nameof(HostAddress)]);

        public static HttpClient Client()
            => new HttpClient() { BaseAddress = HostAddress }.AcceptJson();

        public static HttpClient Client(Uri BaseAddress)
            => new HttpClient() { BaseAddress = BaseAddress };

        public static StringContent EncodeJsonContent(this object o)
            => new StringContent(JsonServices.ToJson(o), Encoding.UTF8, JsonMediaType); 

        static string EncodeQueryString(this object o)
        {
            var parameters = from p in o.GetType().GetProperties()
                             let v = p.GetValue(o) ?? String.Empty
                             let s = v.ToString()
                             where s != String.Empty
                             select Tuple.Create(p.Name, s);
            return "?" + Uri.EscapeUriString(string.Join("&", parameters.Select(x => $"{x.Item1}={x.Item2}")));
        }


        public static async Task<(HttpResponseMessage, string)> POST(string path, string json)
        {
            var encoding = EncodeJsonContent(json);
            using (var client = Client())
            {
                var response = await client.PostAsync(path, encoding);
                var content = await response.Content.ReadAsStringAsync();
                return (response, content);
            }

        }
        public static async Task<(HttpResponseMessage, string)> POST<TRequest>(string path, TRequest request)
        {
            var encoding = request.EncodeJsonContent();
            using (var client = Client())
            {
                var response = await client.PostAsync(path, encoding);
                var content = await response.Content.ReadAsStringAsync();
                return (response, content);
            }
        }

        public static async Task<(HttpResponseMessage, string)> PUT<TRequest>(string path, TRequest request)
        {
            var encoding = request.EncodeJsonContent();
            using (var client = Client())
            {
                var response = await client.PutAsync(path, encoding);
                var content = await response.Content.ReadAsStringAsync();
                return (response, content);
            }
        }

        public static async Task<(HttpResponseMessage, string)> DELETE<TRequest>(string path, TRequest request)
        {
            var query = request.EncodeQueryString();
            using (var client = Client())
            {
                var response = await client.DeleteAsync(path + query);
                var content = await response.Content.ReadAsStringAsync();
                return (response, content);
            }
        }

        public static async Task<(HttpResponseMessage, string)> GET<TRequest>(string path, TRequest request)
        {

            var query = request.EncodeQueryString();
            using (var client = Client())
            {
                var response = await client.GetAsync(path + query);
                var content = await response.Content.ReadAsStringAsync();
                return (response, content);
            }

        }

    }


}
