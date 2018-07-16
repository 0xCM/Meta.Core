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
    /// Identifies and characterizes the Eq typeclass
    /// </summary>
    public interface IEq : ITypeClass
    {

    }

    /// <summary>
    /// Characterizes productions of the <see cref="IEq"/> typeclass and thus defines
    /// the contract for membership in same
    /// </summary>
    /// <typeparam name="X">The type of element for which equality is defined</typeparam>
    public interface IEq<X> : IEq,  ITypeClass<X>
    {
        /// <summary>
        /// Determines whether two <typeparamref name="X"/> values are the same
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        bool eq(X x1, X x2);
    }


}