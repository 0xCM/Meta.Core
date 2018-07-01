//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;


public interface IAssemblyRegistrar
{
    void RegisterAssemblies(params Assembly[] assemblies);

    IReadOnlyList<Assembly> GetRegisteredAssemblies();

    void UnregisterAssemblies(params Assembly[] assemblies);

    /// <summary>
    /// Retrieves all types in all registered assemblies
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<Type> GetAssemblyTypes();

    /// <summary>
    /// Retrieves all types in all registered assemblies that satisfy a specified predicate
    /// </summary>
    /// <param name="IfSatisfied">The filtering predicate</param>
    /// <returns></returns>
    IEnumerable<Type> Types(Predicate<Type> IfSatisfied);
}

