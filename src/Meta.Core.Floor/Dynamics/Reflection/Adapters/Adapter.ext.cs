//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

using static metacore;
using static CommonBindingFlags;

using Meta.Core;

public static class ClrX
{
    /// <summary>
    /// Creates a <see cref="global::ClrAssembly"/> adapter from a reflected assembly
    /// </summary>
    /// <param name="a">The assembly to adapt</param>
    /// <returns></returns>
    public static ClrAssembly ClrAssembly(this Assembly a)
        => global::ClrAssembly.Get(a);

    /// <summary>
    /// Creates a <see cref="global::ClrType"/> adapter from a system type
    /// </summary>
    /// <param name="t">The type to adapt</param>
    /// <returns></returns>
    public static Option<ClrType> ClrType(this Type t)
        => global::ClrType.Get(t);

    /// <summary>
    /// Derives a method's <see cref="global::ClrMethodSignature"/>
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public static ClrMethodSignature ClrMethodSignature(this MethodInfo m)
        => ClrMethod.Get(m);
}