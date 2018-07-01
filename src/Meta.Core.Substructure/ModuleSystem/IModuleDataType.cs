//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system
    /// </summary>
    public interface IModuleDataType
    {

    }

    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system that has one or more
    /// generic parameters
    /// </summary>
    public interface IModuleDataType<X> : IModuleDataType
    {

    }

    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system that has two or more
    /// generic parameters
    /// </summary>
    public interface IModuleDataType<X1, X2> : IModuleDataType<X1>
    {

    }


    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system that has three or more
    /// generic parameters
    /// </summary>
    public interface IModuleDataType<X1, X2, X3> : IModuleDataType<X2, X3>
    {

    }
}