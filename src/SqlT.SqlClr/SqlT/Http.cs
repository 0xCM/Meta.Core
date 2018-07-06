using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Net;
using System.Text;


public static class Http
{
    [SqlProcedure]
    public static int HttpPost(string url, string json)
    {
        return POST(url, json).Length;
    }

    const string JsonMediaType = "application/json";

    public static string POST(string url, string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var req = WebRequest.Create(Convert.ToString(url));
        req.Method = "POST";
        req.ContentType = JsonMediaType;

        using (var stream = req.GetRequestStream())
            stream.Write(bytes, 0, bytes.Length);

        using (var resp = req.GetResponse())
        {
            using (var responseStream = resp.GetResponseStream())
            {
                using (var rdr = new StreamReader(responseStream))
                {
                    var content = rdr.ReadToEnd();
                    return content;
                }

            }
        }
    }


}
