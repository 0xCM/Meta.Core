//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Identifies and describes a system module, commonly realized as a .Net assembly
/// but can represent any well-defined artifact that supports a system
/// implementation
/// </summary>
public interface IModuleDesignator
{
    /// <summary>
    /// The name of the module
    /// </summary>
    string ModuleName { get; }

    /// <summary>
    /// The textual representation of the module's version
    /// </summary>
    string ModuleVersion { get; }

    /// <summary>
    /// Identifies the area to which the module belongs
    /// </summary>
    ModuleArea Area { get; }

    /// <summary>
    /// Identifies a module within a given context
    /// </summary>
    ComponentIdentifier Identity { get; }
    
    /// <summary>
    /// Identifies the set of components on which hard dependencies exist
    /// </summary>
    IReadOnlySet<ComponentIdentifier> IdentifiedDependencies { get; }

}

public interface IModuleDesignator<M> : IModuleDesignator
{
    /// <summary>
    /// Specifies the identified module
    /// </summary>
    M DesignatedModule { get; }

    /// <summary>
    /// Specifies the modules on which the designated module depends
    /// </summary>
    IReadOnlyList<M> ModuleDependencies { get; }


}