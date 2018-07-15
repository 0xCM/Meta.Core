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
    public readonly struct CDU<K, X1, X2, X3> : IEquatable<CDU<K, X1, X2, X3>>
        where X1: K
        where X2: K
        where K : class
    {
        /// <summary>
        /// Implicitly constructs a <typeparamref name="X1"/>-valued union
        /// </summary>
        /// <param name="x1">The value to encapsulate</param>
        public static implicit operator CDU<K, X1, X2, X3>(X1 x1)
            => new CDU<K, X1, X2, X3>(x1);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X2"/>-valued union
        /// </summary>
        /// <param name="x2">The value to encapsulate</param>
        public static implicit operator CDU<K, X1, X2, X3>(X2 x2)
            => new CDU<K, X1, X2, X3>(x2);

        /// <summary>
        /// Implicitly constructs a <typeparamref name="X3"/>-valued union
        /// </summary>
        /// <param name="x3">The value to encapsulate</param>
        public static implicit operator CDU<K, X1, X2, X3>(X3 x3)
            => new CDU<K, X1, X2, X3>(x3);

        /// <summary>
        /// Extracts the underlying <typeparamref name="K"/>-value
        /// </summary>
        /// <param name="x">The value to encapsulate</param>
        public static explicit operator K(CDU<K, X1, X2, X3> x)
            => x.Value;

        public static bool operator ==(CDU<K, X1, X2, X3> x, CDU<K, X1, X2, X3> y)
            => x.Equals(y);

        public static bool operator !=(CDU<K, X1, X2, X3> x, CDU<K, X1, X2, X3> y)
            => not(x.Equals(y));


        public CDU(X1 x1)
        {
            this.x1 = x1;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
        }

        public CDU(X2 x2)
        {
            this.x1 = none<X1>();
            this.x2 = x2;
            this.x3 = none<X3>();
        }

        public CDU(X3 x3)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x3;
        }

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
        public K Value 
             => Option.first<K>(x1, x2, x3);

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
        /// Applies the matching function
        /// </summary>
        /// <typeparam name="Y1">The codomain of the first function</typeparam>
        /// <typeparam name="Y2">The codomain of the second function</typeparam>
        /// <param name="f1">The function to apply if the union is <typeparamref name="X1"/>-valued</param>
        /// <param name="f2">The function to apply if the union is <typeparamref name="X2"/>-valued</param>
        /// <param name="f3">The function to apply if the union is <typeparamref name="X3"/>-valued</param>
        /// <returns></returns>
        public U<Y1, Y2, Y3> Match<Y1, Y2, Y3>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => first(
                Match(f1).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f2).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f3).Map(x => new U<Y1, Y2, Y3>(x))
                );

        /// <summary>
        /// Applies the function to the underlying value
        /// </summary>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public Y Map<Y>(Func<K, Y> f)
            => f(Value);

        public override bool Equals(object obj)
            => obj is CDU<K, X1, X2, X3>
            ? Equals((CDU<K, X1, X2, X3>)obj) : false;

        public bool Equals(CDU<K, X1, X2, X3> other)
            =>  this.x1 == other.x1            
                && this.x2 == other.x2;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2));

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }

}