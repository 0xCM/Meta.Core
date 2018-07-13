//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Text.RegularExpressions;

    using static minicore;

    /// <summary>
    /// Defines contract for producing a string from a value
    /// </summary>
    public interface IValueFormatter<in V>
    {
        string Format(V value);
    }

    public delegate string ValueFormatter<in V>(V value);

}