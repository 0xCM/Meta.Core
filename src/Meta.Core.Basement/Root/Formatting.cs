//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static minicore;

    /// <summary>
    /// Defines contract for producing a string from a value
    /// </summary>
    public interface IValueFormatter<in V>
    {
        string Format(V value);
    }

    public delegate string ValueFormatter<in V>(V value);

    public static class FormattingX
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

    }
}