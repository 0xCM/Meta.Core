//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

using static metacore;

using Meta.Core;

public static class UriX
{
    private static readonly Regex _regex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)");

    /// <summary>
    /// Implemented here to avoid a dependency ot *.Net assemlies just for uri manipulation!
    /// </summary>
    /// <param name="uri"></param>
    /// <remarks>
    /// Taken from https://stackoverflow.com/questions/2884551/get-individual-query-parameters-from-uri
    /// </remarks>
    public static IReadOnlyDictionary<string, string> ParseQueryString(this Uri uri)
    {
        var match = _regex.Match(uri.PathAndQuery);
        var paramaters = new Dictionary<string, string>();
        while (match.Success)
        {
            paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
            match = match.NextMatch();
        }
        return paramaters;
    }

    public static IReadOnlyList<string> Components(this ISystemUriPart part)
        => part.Text.Split(part.Separator);

    public static SystemUri ToSystemUri(this Uri uri)
        => new SystemUri(uri);

    public static SystemUri Uri(this Type t)
        => new SystemUri("clr.type", t.Assembly.GetSimpleName(), t.FullName);

    public static SystemUri Uri(this MethodInfo m)
        => m.DeclaringType.Uri().WithAppendedPathComponts(m.Name)
                                .WithNewScheme("clr.method");

    public static SystemUri ToSystemUri(this ComponentDescriptor d)
        => new SystemUri(scheme: "dev",
            host: SystemNodeIdentifier.Local.Identifier,
            path: $"{d.AreaId}/{d.SystemId}/{d.ComponentId}",
            query: $"{nameof(d.Classification)} = {d.Classification}"
            );

}


