//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Meta.Core;
using static metacore;

partial class adt
{


    /// <summary>
    /// Represents an alegraic product of two types
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    public readonly struct Product<X1, X2, X3, X4> : IEquatable<Product<X1, X2, X3, X4>>
    {
        public static implicit operator Product<X1, X2, X3, X4>((X1, X2, X3, X4) x)
            => new Product<X1, X2, X3, X4>(x);

        public static implicit operator (X1, X2, X3, X4)(Product<X1, X2, X3, X4> x)
            => (x.x1,x.x2, x.x3, x.x4);


        public static bool operator ==(Product<X1, X2, X3, X4> x, Product<X1, X2, X3, X4> y)
            => x.Equals(y);

        public static bool operator !=(Product<X1, X2, X3, X4> x, Product<X1, X2, X3, X4> y)
            => not(x.Equals(y));

        public Product((X1 x1, X2 x2) x1, (X3 x3, X4 x4) x2)
        {
            this.x1 = x1.x1;
            this.x2 = x1.x2;
            this.x3 = x2.x3;
            this.x4 = x2.x4;

        }

        public Product((X1 x1, X2 x2, X3 x3, X4 x4) x)
        {
            this.x1 = x.x1;
            this.x2 = x.x2;
            this.x3 = x.x3;
            this.x4 = x.x4;
            
        }

        public Product(X1 x1, X2 x2, X3 x3, X4 x4)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }

        X1 x1 { get; }

        X2 x2 { get; }

        X3 x3 { get; }

        X4 x4 { get; }

        public Cardinality Cardinality
            => Cardinality.Finite;

        public Y Map<Y>(Func<X1, X2, X3, X4, Y> f)
            => f(x1, x2, x3, x4);

        public Y Map<Y>(Func<(X1, X2, X3, X4), Y> f)
            => f((x1, x2, x3, x4));

        public override bool Equals(object obj)
            => obj is Product<X1, X2, X3, X4>
                ? Equals((Product<X1, X2, X3, X4>)obj) : false;

        public bool Equals(Product<X1, X2, X3, X4> other)
            => object.Equals(this.x1, other.x1)
            && object.Equals(this.x2, other.x2)
            && object.Equals(this.x3, other.x3)
            && object.Equals(this.x4, other.x4)
            ;

        public override string ToString()
            => string.Join(Symbol.and.Spaced(), 
                component(x1), component(x2), component(x3),
                component(x4)
                );

        public override int GetHashCode()
            => (x1, x2).GetHashCode();

        object[] components
            => array<object>(x1,x2,x3,x4);

    }
}