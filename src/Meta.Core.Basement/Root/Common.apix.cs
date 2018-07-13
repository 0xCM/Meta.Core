//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Text.RegularExpressions;

using static minicore;

public static class CommonExtensions
{
    public static string FormatTimestamp(this DateTimeOffset Timestamp)
        => Timestamp.ToLocalTime().ToString("hh:mm:ss tt");

    public static string FormatTimestamp(this DateTime Timestamp)
        => Timestamp.ToLocalTime().ToString("hh:mm:ss tt");

    /// <summary>
    /// Renders a message for display
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="Orignator"></param>
    /// <returns></returns>
    public static string Format(this IAppMessage Message, SystemNodeIdentifier Orignator)
    {
        var tsFmt = Message.Timestamp.FormatTimestamp();
        return concat(tsFmt, " ", Orignator, "> ", Message.Format(false));
    }

    /// <summary>
    /// Gets the value of a regular expression group
    /// </summary>
    /// <param name="m"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GroupValue(this Match m, string name)
    {
        if (!m.Groups[name].Success)
            throw new ArgumentException($"The group {name} was not matched successfully");

        return m.Groups[name].Value;
    }


}

