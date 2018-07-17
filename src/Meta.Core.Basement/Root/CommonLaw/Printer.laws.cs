//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    /// <summary>
    /// Contract for a function that accepts a value and renders it in a canonical
    /// display format
    /// </summary>
    /// <typeparam name="A">The input value type</typeparam>
    /// <param name="value">The input value</param>
    /// <returns></returns>
    public delegate string Printer<A>(A value);
}