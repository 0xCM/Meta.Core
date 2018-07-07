//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using static minicore;

using Meta.Core;

public static class ComponentizationX
{
    public static ModuleKind ModuleClass(this Assembly a)
        => a.TryGetAttribute<ModuleClassifierAttribute>()
            .Map(attrib => attrib.Classification, () => ModuleKind.None);

    static ComponentClassification ClassificationFromProduct(this Assembly a)
        => a.Product().MapValueOrDefault(product =>
        {
            var parts = product.Split('/');
            return parts.Length >= 3
                ? parseEnum(parts[2], ComponentClassification.None)
                : ComponentClassification.None;
        }, ComponentClassification.None);

    /// <summary>
    /// Gets the classifications, if any, applied to the assembly
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static ComponentClassification Classification(this Assembly a)
        => ComponentClassification.None;

    /// <summary>
    /// Retrieves a resource provider for an assembly
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static AssemblyResourceProvider GetResourceProvider(this Assembly a)
        => AssemblyResourceProvider.Get(a);

    /// <summary>
    /// Retrieves a text resource from an assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <param name="resid">The (approximate) resource identifier</param>
    /// <returns></returns>
    public static string GetResourceText(this Assembly a, string resid)
        => AssemblyResourceProvider.Get(a).FindTextResource(resid);

    /// <summary>
    /// Retrieves the named typed from an assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetNamedTypes(this Assembly a)
        => a.GetTypes().Where(t => t.IsNamed());

    /// <summary>
    /// Gets the anonymous types declared in an assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetAnonymousTypes(this Assembly a)
        => a.GetTypes().Where(t => t.IsAnonymous());

    /// <summary>
    /// Gets the types declared in an assembly
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <param name="namedOnly">Specifies whether to include only named types</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetStaticTypes(this Assembly a, bool namedOnly = true)
        => (namedOnly ? a.GetNamedTypes() : a.GetTypes().Where(t => t.IsStatic()));

    /// <summary>
    /// Retrieves the types from an assembly that implement a specified interface
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <param name="t">The interface type</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetRealizations(this Assembly a, Type t)
        => a.GetTypes().Where(x => x.Realizes(t) && !x.IsAbstract);

    /// <summary>
    /// Retrieves the types from an assembly that implement a specified interface
    /// </summary>
    /// <typeparam name="T">The interface type</typeparam>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetRealizations<T>(this Assembly a)
        => a.GetRealizations(typeof(T));

    /// <summary>
    /// Get's the assembly designator, if present; otherwise NULL
    /// </summary>
    /// <param name="a">The assembly to examine</param>
    /// <returns></returns>
    public static IAssemblyDesignator Designator(this Assembly a)
        => a.GetRealizations<IAssemblyDesignator>()
            .SingleOrDefault()
            ?.CreateInstance<IAssemblyDesignator>();

    /// <summary>
    /// Returns the defining area as determined by convention alignment
    /// </summary>
    /// <param name="a">The assembly to evaaluate</param>
    /// <returns></returns>
    public static ModuleArea DefiningArea(this Assembly a)
        => a.Product().MapValueOrDefault(product =>
        {
            var parts = product.Split('/');
            return parts.Length >= 2
                ? ModuleArea.Parse(parts[0])
                : ModuleArea.Empty;

        }, ModuleArea.Empty);

    /// <summary>
    /// Returns the defining system as determined by convention alignment
    /// </summary>
    /// <param name="a">The assembly to evaaluate</param>
    /// <returns></returns>
    public static SystemIdentifier DefiningSystem(this Assembly a)
        => a.Product().MapValueOrDefault(product =>
        {
            var parts = product.Split('/');
            return parts.Length >= 2
                ? SystemIdentifier.Parse(parts[1])
                : SystemIdentifier.Empty;

        }, SystemIdentifier.Empty);

    /// <summary>
    /// Returns the defining system as determined by convention alignment
    /// </summary>
    /// <param name="t">A type defined in the assembly to evaluate</param>
    /// <returns></returns>
    public static SystemIdentifier DefiningSystem(this Type t)
        => t.Assembly.DefiningSystem();


    /// <summary>
    /// Returns the assembly identifier
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static ComponentIdentifier Identifier(this Assembly a)
        => a.GetSimpleName();

    /// <summary>
    /// Constructs the assembly's component descriptor
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static ComponentDescriptor ComponentDescriptor(this Assembly a)
        => Meta.Core.ComponentDescriptor.FromAssembly(a);

    /// <summary>
    /// Loads the assembly associated with a <see cref="ComponentIdentifier"/> value
    /// </summary>
    /// <param name="component">The assembly identifier</param>
    /// <returns></returns>
    public static Assembly Load(this ComponentIdentifier component)
       => Assembly.Load(component);

    /// <summary>
    /// Loads the assemblies associated with <see cref="ComponentIdentifier"/> values
    /// </summary>
    /// <param name="components">The assembly identifier</param>
    /// <returns></returns>
    public static IReadOnlyList<Assembly> Load(this IEnumerable<ComponentIdentifier> components)
        => components.Select(Load).ToReadOnlyList();

}