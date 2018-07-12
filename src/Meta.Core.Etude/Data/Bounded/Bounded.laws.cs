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
    /// Characterizes the Bounded typeclass
    /// </summary>
    public interface IBounded : ITypeClass { }

    /// <summary>
    /// Requires instances to have a specified lower and upper bound
    /// </summary>
    /// <typeparam name="X">The bounded type</typeparam>
    public interface IBounded<X> : IBounded, ITypeClass<X>
    {
        /// <summary>
        /// The type's minimum value
        /// </summary>
        X minval { get; }

        /// <summary>
        /// Type type's maximum value
        /// </summary>
        X maxval { get; }

    }
}