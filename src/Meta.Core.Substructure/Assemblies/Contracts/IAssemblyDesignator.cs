//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;

public interface IAssemblyDesignator : IModuleDesignator<Assembly>
{
    /// <summary>
    /// Identifies the area in which the assembly is defined
    /// </summary>
    string ProductName { get; }

    /// <summary>
    /// The .Net framework version of the assembly
    /// </summary>
    Version NetFrameworkVersion { get; }

    /// <summary>
    /// Provides access to the assembly's embedded resources
    /// </summary>
    AssemblyResourceProvider Resources { get; }

    IMutableContext CreateContext();
}

