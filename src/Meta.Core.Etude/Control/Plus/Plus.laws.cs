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
    /// Identifies the Plus typeclass
    /// </summary>
    public interface IPlus : IAlt
    {

    }

    /// <summary>
    /// Embellishes the IAlt container with an additive identity
    /// </summary>
    /// <typeparam name="X">The contained element type</typeparam>
    /// <typeparam name="CX">The container type</typeparam>
    public interface IPlus<X, CX> : IPlus, IAlt<X, CX>
        where CX : IContainer<X>
    {
        /// <summary>
        /// The container's additive identity
        /// </summary>
        CX empty { get; }
    }

}