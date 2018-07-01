//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Meta.Core.Http;

    using static metacore;

    public static class http
    {
        public static Option<string> get(SystemUri query)
            => Use(HttpBasicClient.Client(uri(query)), client =>
                {
                    var response = client.GetAsync(string.Empty).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                        return content;

                    throw new Exception(($"{response.StatusCode} {content}"));
                });
        
     }
            
}