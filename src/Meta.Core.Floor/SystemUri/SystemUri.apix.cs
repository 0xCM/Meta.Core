//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

using static metacore;

using Meta.Core;

/// <summary>
/// Defines <see cref="SystemUri"/>-related extensions
/// </summary>
public static class SystemUriX
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

    /// <summary>
    /// Extracts the components of a uri part/segment
    /// </summary>
    /// <param name="part">The subject part</param>
    /// <returns></returns>
    public static IReadOnlyList<string> Components(this ISystemUriPart part)
        => part.Text.Split(part.Separator);

    /// <summary>
    /// Lifts a framework uri to a <see cref="SystemUri"/> representation
    /// </summary>
    /// <param name="uri">The uri to lift</param>
    /// <returns></returns>
    public static SystemUri ToSystemUri(this Uri uri)
        => new SystemUri(uri);

    /// <summary>
    /// Calculates a types's canonical URI
    /// </summary>
    /// <param name="m">The subject type</param>
    /// <returns></returns>
    public static SystemUri Uri(this Type t)
        => new SystemUri("clr.type", t.Assembly.GetSimpleName(), t.FullName);

    /// <summary>
    /// Calculates a method's canonical URI
    /// </summary>
    /// <param name="m">The subject method</param>
    /// <returns></returns>
    public static SystemUri Uri(this MethodInfo m)
        => m.DeclaringType.Uri().WithAppendedPathComponts(m.Name)
                                .WithNewScheme("clr.method");

    /// <summary>
    /// Converts the uri to a local file system path
    /// </summary>
    /// <param name="uri">The uri to convert</param>
    /// <returns></returns>
    public static FilePath ToLocalPath(this SystemUri uri)
        => string.Join(bslash(), uri.Path.Components());

    /// <summary>
    /// Calculates a component's <see cref="SystemUri"/> from a descriptor
    /// </summary>
    /// <param name="d">The component descriptor</param>
    /// <returns></returns>
    public static SystemUri ToSystemUri(this ComponentDescriptor d)
        => new SystemUri(scheme: "dev",
            host: SystemNodeIdentifier.Local.Identifier,
            path: $"{d.AreaId}/{d.SystemId}/{d.ComponentId}",
            query: $"{nameof(d.Classification)} = {d.Classification}"
            );

}


