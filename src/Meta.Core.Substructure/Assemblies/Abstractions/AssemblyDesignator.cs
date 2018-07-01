//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

using Meta.Core;

public abstract class CoreModule<A> : AssemblyDesignator<A>
    where A : CoreModule<A>, new()
{
    public const string AssemblyVersion = "1.1.0";

}

/// <summary>
/// Realizations identify and describe the assemblies in which they are implemented
/// </summary>
/// <typeparam name="T">The designating type</typeparam>
public abstract class AssemblyDesignator<T> : IAssemblyDesignator
    where T : AssemblyDesignator<T>, new()
{
    /// <summary>
    /// Specifies the designated assembly
    /// </summary>
    public static readonly Assembly Assembly 
        = typeof(T).Assembly;

    /// <summary>
    /// The one and only
    /// </summary>
    public static readonly T Designator 
        = new T();

    /// <summary>
    /// Specifies the area-relative component identifier
    /// </summary>
    public static ComponentIdentifier Identifier
        => typeof(T).Assembly.Identifier();

    /// <summary>
    /// Accessor the the one and only
    /// </summary>
    /// <returns></returns>
    public static T Get()
        => Designator;

    /// <summary>
    /// Provides access to the assembly's embedded resources
    /// </summary>
    public static AssemblyResourceProvider Resources
        => AssemblyResourceProvider.Get(typeof(T).Assembly);

    /// <summary>
    /// Gets the assembly's .Net framework version
    /// </summary>
    public static Version NetFrameworkVersion { get; }
        = Assembly.GetNetFrameworkVersion();

    /// <summary>
    /// The name of the declaring component
    /// </summary>
    static string AssemblyTitle { get; }
        = typeof(T).Assembly.Title().ValueOrDefault(string.Empty);

    /// <summary>
    /// The name of the product, if any, to which the assembly belongs
    /// </summary>
    static string ProductName
       = typeof(T).Assembly.Product().ValueOrDefault(string.Empty);


    /// <summary>
    /// Hard dependency specification
    /// </summary>
    public virtual IReadOnlySet<ComponentIdentifier> IdentifiedDependencies { get; }
        = ReadOnlySet<ComponentIdentifier>.Empty;    

    /// <summary>
    /// The area-relative component identity
    /// </summary>
    public ComponentIdentifier Identity
        => Identifier;

    /// <summary>
    /// Gets the designated assembly's resource provider
    /// </summary>
    AssemblyResourceProvider IAssemblyDesignator.Resources 
        => AssemblyResourceProvider.Get(Assembly);

    /// <summary>
    /// Gets membership information for well-known categories
    /// </summary>
    public ComponentClassification Classification
        => typeof(T).Assembly.Classification();
       
    /// <summary>
    /// Overrided by subtype to explicitly specify the assemblies that are required
    /// to resolve service references
    /// </summary>
    public virtual IReadOnlyList<Assembly> ModuleDependencies
        => new Assembly[] { };

    Assembly IModuleDesignator<Assembly>.DesignatedModule 
        => Assembly;

    Version IAssemblyDesignator.NetFrameworkVersion 
        => NetFrameworkVersion;

    IReadOnlyList<Assembly> IModuleDesignator<Assembly>.ModuleDependencies 
        => ModuleDependencies;
    
    string IModuleDesignator.ModuleName 
        => AssemblyTitle;

    string IAssemblyDesignator.ProductName 
        => ProductName;

    string IModuleDesignator.ModuleVersion
        => typeof(T).Assembly.GetName().Version.ToString();

    public virtual IMutableContext CreateContext()
        => ApplicationContext.Create(ModuleDependencies);
    
    /// <summary>
    /// Specifies the area in which the module is defined
    /// </summary>
    public ModuleArea Area
        => typeof(T).Assembly.DefiningArea();
}
