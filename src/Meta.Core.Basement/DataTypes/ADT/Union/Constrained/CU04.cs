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
    /// <typeparam name="X3">The type of the third slot</typeparam>
    /// <typeparam name="X4">The type of the fourth slot</typeparam>
    public readonly struct CU<K, X1, X2, X3, X4> : IEquatable<CU<K, X1, X2, X3, X4>>, IConstrainedUnion<K,X1,X2,X3,X4>
        where X1: K
        where X2: K
        where X3 : K
        where X4 : K
        where K : class
    {
        /// <summary>
        /// Implicitly constructs a <typeparamref name="X1"/>-valued union
        /// </summary>
        /// <param name="x1">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3, X4>(X1 x1)
            => new CU<K, X1, X2, X3, X4>(x1);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X2"/>-valued union
        /// </summary>
        /// <param name="x2">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3, X4>(X2 x2)
            => new CU<K, X1, X2, X3, X4>(x2);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X3"/>-valued union
        /// </summary>
        /// <param name="x3">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3, X4>(X3 x3)
            => new CU<K, X1, X2, X3, X4>(x3);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X4"/>-valued union
        /// </summary>
        /// <param name="x4">The value to encapsulate</param>
        public static implicit operator CU<K, X1, X2, X3, X4>(X4 x4)
            => new CU<K, X1, X2, X3, X4>(x4);

        /// <summary>
        /// Extracts the underlying <typeparamref name="K"/>-value
        /// </summary>
        /// <param name="x">The value to encapsulate</param>
        public static explicit operator K(CU<K, X1, X2, X3, X4> x)
            => x.value;

        public static bool operator ==(CU<K, X1, X2, X3, X4> x, CU<K, X1, X2, X3, X4> y)
            => x.Equals(y);

        public static bool operator !=(CU<K, X1, X2, X3, X4> x, CU<K, X1, X2, X3, X4> y)
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
            this.x4 = none<X4>();
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
            this.x4 = none<X4>();
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
            this.x4 = none<X4>();
            this.n = 3;
        }

        /// <summary>
        /// Initializes the union with a slot-4 value
        /// </summary>
        /// <param name="x4">The value that will occupy the third slot</param>
        public CU(X4 x4)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = none<X3>();
            this.x4 = x4;
            this.n = 4;
        }

        /// <summary>
        /// Species the 1-based number of the slot that is occupied
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
        /// The third slot
        /// </summary>
        public Option<X3> x3 { get; }

        /// <summary>
        /// The fourth slot
        /// </summary>
        public Option<X4> x4 { get; }

        /// <summary>
        /// Specifies the underlying value
        /// </summary>
        public K value 
             => Option.first<K>(x1, x2, x3, x4);

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
        /// Applies a function to the value in the third slot if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f3">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X3, Y> f3)
            => x3.Map(x => f3(x));

        /// <summary>
        /// Applies a function to the value in the fourth slot if it exists
        /// </summary>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f4">The function to apply</param>
        /// <returns></returns>
        public Option<Y> Match<Y>(Func<X4, Y> f4)
            => x4.Map(x => f4(x));

        /// <summary>
        /// Applies a function to the value in the occuped slot
        /// </summary>
        /// <typeparam name="Y1">The codomain of the first function</typeparam>
        /// <typeparam name="Y2">The codomain of the second function</typeparam>
        /// <param name="f1">The function to apply if the union is <typeparamref name="X1"/>-valued</param>
        /// <param name="f2">The function to apply if the union is <typeparamref name="X2"/>-valued</param>
        /// <param name="f3">The function to apply if the union is <typeparamref name="X3"/>-valued</param>
        /// <param name="f4">The function to apply if the union is <typeparamref name="X4"/>-valued</param>
        /// <returns></returns>
        public U<Y1, Y2, Y3, Y4> Map<Y1, Y2, Y3, Y4>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4)
            => first(
                n is 1 ? Match(f1).Map(x => new U<Y1, Y2, Y3, Y4>(x)) :
                n is 2 ? Match(f2).Map(x => new U<Y1, Y2, Y3, Y4>(x)) :
                n is 3 ? Match(f3).Map(x => new U<Y1, Y2, Y3, Y4>(x)) :
                         Match(f4).Map(x => new U<Y1, Y2, Y3, Y4>(x)));

        /// <summary>
        /// Applies a function to the value in the slot that is occupied
        /// </summary>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function to apply</param>
        /// <returns></returns>
        public Y Map<Y>(Func<K, Y> f)
            => f(value);

        /// <summary>
        /// Effects structural comparison via the rule:
        /// two union values are equal iff the same slots are occupied by the same values
        /// </summary>
        public bool Equals(CU<K, X1, X2, X3, X4> other)
            =>  this.x1 == other.x1            
                && this.x2 == other.x2
                && this.x3 == other.x3
                && this.x4 == other.x4;

        public override bool Equals(object obj)
            => obj is CU<K, X1, X2, X3, X4> x ? Equals(x) : false;

        public override int GetHashCode()
            => Map(x => x.GetHashCode());

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2), format(x3), format(x4));
    }

}