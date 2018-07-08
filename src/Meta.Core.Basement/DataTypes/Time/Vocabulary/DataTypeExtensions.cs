//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;

using System.Runtime.CompilerServices;
using Meta.Core;

public static class DataTypeExtensions
{
    /// <summary>
    /// Renders a string in a more rational manner than the default behavior
    /// </summary>
    /// <param name="t">The instant to render</param>
    /// <param name="accuracy">The accuracy with which to render the instant</param>
    /// <returns></returns>
    public static string ToLexicalString(this DateTime t, DateTimeAccuracy accuracy = DateTimeAccuracy.Millisecond)
    {
        var format = String.Empty;
        var date = t.ToString("yyyy-MM-dd");
        var hour = t.Hour.ToString().PadLeft(2, '0');
        var minute = t.Minute.ToString().PadLeft(2, '0');
        var second = t.Second.ToString().PadLeft(2, '0');
        var ms = t.Millisecond.ToString().PadLeft(3, '0');
        switch (accuracy)
        {
            case DateTimeAccuracy.Date:
                format = date;
                break;
            case DateTimeAccuracy.Hour:
                format = String.Format("{0} {1}:00:00:000", date, hour);
                break;
            case DateTimeAccuracy.Minute:
                format = String.Format("{0} {1}:{2}:00:000", date, hour, minute);
                break;
            case DateTimeAccuracy.Second:
                format = String.Format("{0} {1}:{2}:{3}:000", date, hour, minute, second);
                break;
            case DateTimeAccuracy.Millisecond:
                format = String.Format("{0} {1}:{2}:{3}:{4}", date, hour, minute, second, ms);
                break;
            default:
                throw new NotSupportedException();
        }
        return format;
    }

    /// <summary>
    /// Determines whether a supplied type is either a Date or Nullable Date
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDate(this Type t)
        => t == typeof(Date);

}