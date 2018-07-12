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

