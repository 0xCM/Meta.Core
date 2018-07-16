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
    public readonly struct CU<K, X1, X2, X3> : IEquatable<CU<K, X1, X2, X3>>, IConstrainedUnion<K,X1,X2,X3>
        where K : class
        where X1 : K
        where X2: K
        where X3: K
    {
        /// <summary>
        /// Implicitly constructs a <typeparamref name="X1"/>-valued union
        /// </summary>
        /// <param name="x1">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3>(X1 x1)
            => new CU<K, X1, X2, X3>(x1);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X2"/>-valued union
        /// </summary>
        /// <param name="x2">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3>(X2 x2)
            => new CU<K, X1, X2, X3>(x2);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X3"/>-valued union
        /// </summary>
        /// <param name="x3">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3>(X3 x3)
            => new CU<K, X1, X2, X3>(x3);

        /// <summary>
        /// Extracts the underlying <typeparamref name="K"/>-value
        /// </summary>
        /// <param name="x">The value to encapsulate</param>
        public static explicit operator K(CU<K, X1, X2, X3> x)
            => x.value;

        public static bool operator ==(CU<K, X1, X2, X3> x, CU<K, X1, X2, X3> y)
            => x.Equals(y);

        public static bool operator !=(CU<K, X1, X2, X3> x, CU<K, X1, X2, X3> y)
            => not(x.Equals(y));

        /// <summary>
        /// Initializes the union with a slot-1 value
        /// </summary>
        /// <param name="x1">The value that will occupy the first slot</param>
        public CU(X1 x1)
        {
            this.x1 = x1;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
            this.n = 1;
        }

        /// <summary>
        /// Initializes the union with a slot-2 value
        /// </summary>
        /// <param name="x2">The value that will occupy the second slot</param>
        public CU(X2 x2)
        {
            this.x1 = none<X1>();
            this.x2 = x2;
            this.x3 = none<X3>();
            this.n = 2;
        }

        /// <summary>
        /// Initializes the union with a slot-3 value
        /// </summary>
        /// <param name="x3">The value that will occupy the third slot</param>
        public CU(X3 x3)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x3;
            this.n = 3;
        }

        /// <summary>
        /// Specifies the number of the occupied slot
        /// </summary>
        public int n { get; }

        /// <summary>
        /// The first potential value
        /// </summary>
        public Option<X1> x1 { get; }

        /// <summary>
        /// The second potential value
        /// </summary>
        public Option<X2> x2 { get; }

        /// <summary>
        /// The third potential value
        /// </summary>
        public Option<X3> x3 { get; }

        /// <summary>
        /// Specifies the underlying value
        /// </summary>
        public K value 
             => Option.first<K>(x1, x2, x3);

        object IUnion.value
            => value;

        /// <summary>
        /// Applies a function to the first value if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f1">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X1, Y> f1)
            => x1.Map(x => f1(x));

        /// <summary>
        /// Applies a function to the second value if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f2">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X2, Y> f2)
            => x2.Map(x => f2(x));

        /// <summary>
        /// Applies a function to the third value if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f3">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X3, Y> f3)
            => x3.Map(x => f3(x));

        /// <summary>
        /// Applies a function to the value in the occuped slot
        /// </summary>
        /// <typeparam name="Y1">The codomain of the first function</typeparam>
        /// <typeparam name="Y2">The codomain of the second function</typeparam>
        /// <typeparam name="Y3">The codomain of the third function</typeparam>
        /// <param name="f1">The function to apply if the union is <typeparamref name="X1"/>-valued</param>
        /// <param name="f2">The function to apply if the union is <typeparamref name="X2"/>-valued</param>
        /// <param name="f3">The function to apply if the union is <typeparamref name="X3"/>-valued</param>
        /// <returns></returns>
        public U<Y1, Y2, Y3> Map<Y1, Y2, Y3>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => first(
                Match(f1).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f2).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f3).Map(x => new U<Y1, Y2, Y3>(x))
                );

        /// <summary>
        /// Applies the function to the underlying value
        /// </summary>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to apply</param>
        /// <returns></returns>
        public Y Map<Y>(Func<K, Y> f)
            => f(value);

        public override bool Equals(object obj)
            => obj is CU<K, X1, X2, X3>
            ? Equals((CU<K, X1, X2, X3>)obj) : false;

        /// <summary>
        /// Effects structural comparison via the rule:
        /// two union values are equal iff the same slots are occupied by the same values
        /// </summary>
        /// <returns></returns>
        public bool Equals(CU<K, X1, X2, X3> other)
            =>  this.x1 == other.x1            
                && this.x2 == other.x2
                && this.x3 == other.x3
            ;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2), format(x3));

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }

}