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
    /// <typeparam name="X2">The type of the second slot</typeparam>
    public readonly struct CU<K, X1, X2> : IEquatable<CU<K, X1, X2>>, IConstrainedUnion<K, X1, X2>
        where X1: K
        where X2: K
        where K : class
    {
        /// <summary>
        /// Implicitly constructs a <typeparamref name="X1"/>-valued union
        /// </summary>
        /// <param name="x1">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2>(X1 x1)
            => new CU<K, X1, X2>(x1);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X2"/>-valued union
        /// </summary>
        /// <param name="x2">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2>(X2 x2)
            => new CU<K, X1, X2>(x2);

        /// <summary>
        /// Extracts the underlying <typeparamref name="K"/>-value
        /// </summary>
        /// <param name="x">The value to encapsulate</param>
        public static explicit operator K(CU<K, X1, X2> x)
            => x.value;

        public static bool operator ==(CU<K, X1, X2> x, CU<K, X1, X2> y)
            => x.Equals(y);

        public static bool operator !=(CU<K, X1, X2> x, CU<K, X1, X2> y)
            => not(x.Equals(y));


        public CU(X1 x1)
        {
            this.x1 = x1;
            this.x2 = none<X2>();
            this.n = 1;
        }

        public CU(X2 x2)
        {
            this.x1 = none<X1>();
            this.x2 = x2;
            this.n = 2;
        }

        /// <summary>
        /// Specifies the number of the occupied slot
        /// </summary>
        public int n { get; }

        /// <summary>
        /// The first slot
        /// </summary>
        public Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        public Option<X2> x2 { get; }

        /// <summary>
        /// Specifies the underlying value
        /// </summary>
        public K value 
             => Option.first<K>(x1, x2);

        object IUnion.value
            => value;

        /// <summary>
        /// Applies a function to the value in the first slot if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f1">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X1, Y> f1)
            => x1.Map(x => f1(x));

        /// <summary>
        /// Applies a function to the value in the second slot if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f2">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X2, Y> f2)
            => x2.Map(x => f2(x));

        /// <summary>
        /// Applies a function to the value in the occupied slot
        /// </summary>
        /// <typeparam name="Y1">The codomain of the first function</typeparam>
        /// <typeparam name="Y2">The codomain of the second function</typeparam>
        /// <param name="f1">The function to apply if the union is <typeparamref name="X1"/>-valued</param>
        /// <param name="f2">The function to apply if the union is <typeparamref name="X2"/>-valued</param>
        /// <returns></returns>
        public U<Y1, Y2> Map<Y1, Y2>(Func<X1, Y1> f1, Func<X2, Y2> f2)
            => first(
                Match(f1).Map(x => new U<Y1, Y2>(x)),
                Match(f2).Map(x => new U<Y1, Y2>(x))
                );

        /// <summary>
        /// Applies a function to the underlying value
        /// </summary>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to apply</param>
        /// <returns></returns>
        public Y Map<Y>(Func<K, Y> f)
            => f(value);

        public override bool Equals(object obj)
            => obj is CU<K, X1, X2>
            ? Equals((CU<K, X1, X2>)obj) : false;

        public bool Equals(CU<K, X1, X2> other)
            =>  this.x1 == other.x1            
                && this.x2 == other.x2;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2));

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }

}