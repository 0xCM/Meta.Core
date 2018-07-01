//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

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
    public static string Format(this IApplicationMessage Message, SystemNodeIdentifier Orignator)
    {
        var tsFmt = Message.Timestamp.FormatTimestamp();
        return concat(tsFmt, " ", Orignator, "> ", Message.Format(false));
    }

}

