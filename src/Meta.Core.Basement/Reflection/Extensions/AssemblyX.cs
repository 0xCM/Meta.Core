//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System.Runtime.CompilerServices;

/// <summary>
/// Defines extensions to <see cref="Assembly"/> type 
/// </summary>
public static partial class Reflections
{

    /// <summary>
    /// Determines the version of the .Net framework targeted by the assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static Version GetNetFrameworkVersion(this Assembly a)
        =>
        (
            from attrib in a.GetCustomAttributes<TargetFrameworkAttribute>()
            let vName = attrib.FrameworkName.Substring(attrib.FrameworkName.IndexOf("=v") + 2)
            select Version.Parse(vName)
        ).Single();

    /// <summary>
    /// Convenience accessor for the assembly's version
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Version AssemblyVersion(this Assembly a)
        => a.GetName().Version;

    /// <summary>
    /// Determines whether an assembly has an attribute of a given type
    /// </summary>
    /// <typeparam name="T">The attribute type</typeparam>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static bool HasAttribute<T>(this Assembly a) where T : Attribute
        => Attribute.IsDefined(a, typeof(T));

    /// <summary>
    /// Gets the identified assembly attribute if present, otherwise NULL
    /// </summary>
    /// <typeparam name="A">The type of attribute for which to search</typeparam>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static A GetAttribute<A>(this Assembly a) where A : Attribute
        => (A)Attribute.GetCustomAttribute(a, typeof(A));

    /// <summary>
    /// Determines the assembly's 3-part semantic version
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static SemanticVersion GetSemanticVersion(this Assembly a)
    {
        var version = a.GetName().Version;
        return string.Join(".", version.Major, version.Minor, version.Build);
    }

    /// <summary>
    /// Gets the identified assembly attribute if present, otherwise None
    /// </summary>
    /// <typeparam name="A">The type of attribute for which to search</typeparam>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static Option<A> TryGetAttribute<A>(this Assembly a) 
        where A : Attribute
            =>  a.GetAttribute<A>();

    /// <summary>
    /// Gets the value of <see cref="AssemblyProductAttribute"/> if it exists
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Option<string> Product(this Assembly a)
        => from x in a.TryGetAttribute<AssemblyProductAttribute>()
           select x.Product;

    /// <summary>
    /// Gets the value of <see cref="AssemblyTitleAttribute"/> if it exists
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Option<string> Title(this Assembly a)
        => from x in a.TryGetAttribute<AssemblyTitleAttribute>()
           select x.Title;

    /// <summary>
    /// Gets the value of <see cref="AssemblyCompanyAttribute"/> if it exists
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Option<string> Company(this Assembly a)
        => from x in a.TryGetAttribute<AssemblyCompanyAttribute>()
           select x.Company;

    /// <summary>
    /// Gets the value of <see cref="AssemblyDefaultAliasAttribute"/> if it exists
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Option<string> DefaultAlias(this Assembly a)
        => from x in a.TryGetAttribute<AssemblyDefaultAliasAttribute>()
           select x.DefaultAlias;

    /// <summary>
    /// Gets the simple name of an assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static string GetSimpleName(this Assembly a)
        => a?.GetName()?.Name ?? string.Empty;


}