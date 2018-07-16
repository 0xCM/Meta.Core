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
    /// Canonical signature for group inverter: a function that carries each element of a group to its inverse <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="a">The value to invert</param>
    /// <returns></returns>
    public delegate X Inverter<X>(X a);

    /// <summary>
    /// Identifies the Group typeclass
    /// </summary>
    public interface IGroup : IMonoid
    {

    }

    /// <summary>
    /// Defines contract for membership in the <see cref="IGroup"/> typeclass
    /// </summary>
    /// <typeparam name="X">The group element type</typeparam>
    public interface IGroup<X> : IMonoid<X>
    {
        X Invert(X a);
    }
}