//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


/// <summary>
/// Defines utility methods for working with integer representations of dates
/// </summary>
public static class IntegerDate
{
    /// <summary>
    /// Creates a date from an integer in the form YYYYMMDD
    /// </summary>
    /// <param name="d">The integer representing the date</param>
    /// <returns></returns>
    public static DateTime FromInteger(int d) 
        => DateTime.ParseExact(d.ToString(), "yyyyMMdd", CultureInfo.CurrentCulture);


}




