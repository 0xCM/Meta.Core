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
    /// Identifies the Monoid
    /// </summary>
    public interface IMonoid : ISemigroup
    {

    }

    /// <summary>
    /// Characterizes productions of the <see cref="IMonoid"/> typeclass and thus defines
    /// the contract for membership in same
    /// </summary>
    /// <typeparam name="X">The monoid element type</typeparam>
    public interface IMonoid<X> : IMonoid, ISemigroup<X>
    {
        /// <summary>
        /// Specifies the monoid's additive identity
        /// </summary>
        X zero { get; }

    }
    
}