//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using static CommonBindingFlags;

using static metacore;

public static class ReflectiveFloor
{
    /// <summary>
    /// Attempts to retrieve the value of an instance or static property
    /// </summary>
    /// <param name="prop">The property</param>
    /// <param name="instance">The object instance, if applicable</param>
    /// <returns></returns>
    public static Option<object> TryGetValue(this PropertyInfo prop, object instance = null)
        => Try(() => prop.GetValue(instance));


    /// <summary>
    /// Attempts to retrieve the value of an instance or static field
    /// </summary>
    /// <param name="field">The field</param>
    /// <param name="instance">The object instance, if applicable</param>
    /// <returns></returns>
    public static Option<object> TryGetValue(this FieldInfo field, object instance = null)
        => Try(() => field.GetValue(instance));

    /// <summary>
    /// Retrieves the values of a type's public instance properties
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="o">The type instance</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<string, object> GetPropertyValues(this Type t, object o)
        => dict(map(props(o), p => (p.Name, p.GetValue(o))));

    //public static string DisplayName(this Type t)
    //{
    //    var attrib = t.GetCustomAttribute<DisplayNameAttribute>();
    //    if (attrib != null)
    //        return attrib.DisplayName;

    //    if (!t.IsGenericType)
    //        return t.Name;

    //    if (t.IsConstructedGenericType)
    //    {
    //        var typeArgs = t.GenericTypeArguments;
    //        var argFmt = string.Join(",", map(typeArgs, DisplayName));
    //        var typeName = t.Name.Replace($"`{typeArgs.Length}", string.Empty);
    //        return concat(typeName, "<", argFmt, ">");
    //    }
    //    else
    //    {
    //        var typeArgs = t.GetGenericTypeDefinition().GetGenericArguments();
    //        var argFmt = string.Join(",", map(typeArgs, DisplayName));
    //        var typeName = t.Name.Replace($"`{typeArgs.Length}", string.Empty);
    //        return concat(typeName, "<", argFmt, ">");
    //    }
    //}

    /// <summary>
    /// If non-nullable, returns the supplied type. If nullable, returns the underlying type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static Type GetNonNullableType(this Type t)
        => nonNullable(t);

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