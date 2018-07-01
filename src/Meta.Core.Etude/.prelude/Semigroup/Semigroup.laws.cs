//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Identifies and characterizes the Semigroup typeclass
    /// </summary>
    public interface ISemigroup : IEq
    {
    }

    /// <summary>
    /// Characterizes productions of the <see cref="ISemigroup"/> typeclass and thus defines
    /// the contract for membership in same
    /// </summary>
    /// <typeparam name="X">The semigroup element type</typeparam>
    public interface ISemigroup<X> : ISemigroup, IEq<X>
    {
        /// <summary>
        /// Specifies the semigroup's canonical associative binary operation
        /// </summary>
        /// <param name="a1">The first input value</param>
        /// <param name="a2">The seond input value</param>
        /// <returns></returns>
        X combine(X a1, X a2);
    }

    partial class classops
    {

        /// <summary>
        /// Associative binary operation over a <see cref="ISemigroup"/> 
        /// </summary>
        public readonly struct plus : IClassOp<plus>
        {
            public static readonly plus op = default;
            public const string S = "<>";
        }
    }

}