//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Namescope for algebraic data types
/// </summary>
public static partial class adt
{
    internal static string component<X>(X x)
        => $"{typeof(X).DisplayName()}:{x}";

    internal static string format<T>(Option<T> option)
        => option.Map(value => $"{typeof(T).DisplayName()}:{value}", () => typeof(T).DisplayName());

}

