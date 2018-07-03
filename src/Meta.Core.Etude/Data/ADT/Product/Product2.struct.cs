//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using static metacore;
using Meta.Core;
partial class adt
{ 

    /// <summary>
    /// Represents an alegraic product of two types
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">Tht second type</typeparam>
    public readonly struct Product<X1, X2> : IEquatable<Product<X1, X2>>, IFactoredContainer<X1,X2>
    {
        public static implicit operator Product<X1,X2>((X1,X2) x)
            => new Product<X1, X2>(x);

        public static implicit operator (X1, X2)(Product<X1,X2> x)
            => (x.x1,x.x2);

        public static bool operator ==(Product<X1, X2> x, Product<X1, X2> y)
            => x.Equals(y);

        public static bool operator !=(Product<X1, X2> x, Product<X1, X2> y)
            => not(x.Equals(y));

        public Product((X1 x1, X2 x2) x)
        {
            this.x1 = x.x1;
            this.x2 = x.x2;
        }

        public Product(X1 x1, X2 x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        X1 x1 { get; }

        X2 x2 { get; }

        public Y Map<Y>(Func<X1, X2, Y> f)
            => f(x1, x2);

        object[] components
            => array<object>(x1, x2);

        public Cardinality Cardinality
            => Cardinality.Finite;

        public override bool Equals(object obj)
            => obj is Product<X1, X2>
                ? Equals((Product<X1, X2>)obj) : false;

        public bool Equals(Product<X1, X2> other)
            => object.Equals(this.x1, other.x1)
            && object.Equals(this.x2, other.x2);

        public override string ToString()
            => string.Join(Symbol.and.Spaced(), component(x1), component(x2));

        public override int GetHashCode()
            => (x1, x2).GetHashCode();

        public IFactoredContainer<Y1, Y2> Recontain<Y1, Y2>(Func<(X1, X2), (Y1, Y2)> map)
            => new Product<Y1, Y2>(map(this));

        public Seq<(X1, X2)> Contained()
            => Seq.cons((x1, x2));

        public IEnumerable<(X1, X2)> Stream()
            => Contained().Stream();
    }
}