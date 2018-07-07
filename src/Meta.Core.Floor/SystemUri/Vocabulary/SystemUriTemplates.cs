//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


static class SytemUriTemplates
{
    static readonly string scheme_marker = "scheme";
    static readonly string host_marker = "host";
    static readonly string path_marker = "path";

    public static Uri StandardUri(string scheme = null, string host = null, string path = null, string query = null)
    {
        var schemePart = $"{scheme ?? scheme_marker}";
        var hostPart = $"{host ?? host_marker}";
        var pathPart = $"{path ?? path_marker}";

        var baseFormat =
             $"{scheme ?? scheme_marker}://{host ?? host_marker}/{path ?? path_marker}";

        var format = string.IsNullOrEmpty(query) ? baseFormat : $"{baseFormat}?{query}";

        return new Uri(format);

    }


}
