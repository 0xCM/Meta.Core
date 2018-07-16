//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using static minicore;


partial class Union
{
    /// <summary>
    /// A labled heterogenous union with 2 potential slots where exactly one will be populated
    /// </summary>
    /// <typeparam name="K">The constraint type</typeparam>
    /// <typeparam name="X1">The type of the first slot</typeparam>
    public readonly struct CU<K, X1> : IEquatable<CU<K, X1>>, IConstrainedUnion<K,X1>
        where K : class
        where X1 : K
    {
        /// <summary>
        /// Implicitly constructs a <typeparamref name="X1"/>-valued union
        /// </summary>
        /// <param name="x1">The value to encapsulate</param>
        public static implicit operator CU<K, X1>(X1 x1)
            => new CU<K, X1>(x1);

        /// <summary>
        /// Extracts the underlying <typeparamref name="K"/>-value
        /// </summary>
        /// <param name="x">The value to encapsulate</param>
        public static explicit operator K(CU<K, X1> x)
            => x.value;

        public static bool operator ==(CU<K, X1> x, CU<K, X1> y)
            => x.Equals(y);

        public static bool operator !=(CU<K, X1> x, CU<K, X1> y)
            => not(x.Equals(y));

        /// <summary>
        /// Initializes the union with a slot-1 value
        /// </summary>
        /// <param name="x1">The value that will occupy the first slot</param>
        public CU(X1 x1)
        {
            this.x1 = x1;
            this.n = 1;
        }

        /// <summary>
        /// Species the number of the occupied slot
        /// </summary>
        public int n { get; }

        /// <summary>
        /// The first slot
        /// </summary>
        public Option<X1> x1 { get; }

        /// <summary>
        /// Specifies the underlying value
        /// </summary>
        public K value
             => x1.ValueOrDefault();

        object IUnion.value
            => value;

        /// <summary>
        /// Applies a function to the value in the first slot
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f1">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X1, Y> f1)
            => x1.Map(x => f1(x));

        /// <summary>
        /// Applies a function to the value in the occuped slot
        /// </summary>
        /// <typeparam name="Y1">The codomain of the first function</typeparam>
        /// <typeparam name="Y2">The codomain of the second function</typeparam>
        /// <param name="f1">The function to apply to the value in the first slot</param>
        /// <returns></returns>
        public U<Y1> Map<Y1>(Func<X1, Y1> f1)
            =>first(Match(f1).Map(x => new U<Y1>(x)));
        
        /// <summary>
        /// Effects structural comparison via the rule:
        /// two union values are equal iff the same slots are occupied by the same values
        /// </summary>
        /// <param name="x">The first union value</param>
        /// <param name="y">The second union value</param>
        /// <returns></returns>
        public bool Equals(CU<K, X1> other)
            => this.x1 == other.x1;

        public override bool Equals(object obj)
            => obj is CU<K, X1> x ? Equals(x) : false;

        public override int GetHashCode()
            => x1.GetHashCode();
        public override string ToString()
            => string.Join(Symbol.or.Spaced(), format(x1));

    }

}