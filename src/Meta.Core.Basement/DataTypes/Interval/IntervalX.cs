//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using Meta.Core;

public static class IntervalX
{
    public static IEnumerable<Date> Points(this Interval<Date> I, int increment = 1)
    {
        for (var i = I.Min; i <= I.Max; i = i.AddDays(increment))
            yield return i;
    }


}
