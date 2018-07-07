//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

partial class metacore
{
    public static Date date(string text)
        => Date.Parse(text);

    public static Date date(int year, byte month, byte day)
        => new Date(year, month, day);


}
