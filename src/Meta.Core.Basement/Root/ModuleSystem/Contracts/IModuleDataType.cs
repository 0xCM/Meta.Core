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
    public interface IModuleDataType<A> : IModuleDataType
    {

    }

    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system that has two or more
    /// generic parameters
    /// </summary>
    public interface IModuleDataType<A, B> : IModuleDataType<A>
    {

    }


    /// <summary>
    /// Identifies and characterizes a type defined within
    /// the context of the module system that has three or more
    /// generic parameters
    /// </summary>
    public interface IModuleDataType<A, B, C> : IModuleDataType<B, C>
    {

    }
}