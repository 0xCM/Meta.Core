//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Modules;
    using static metacore;
    using static Product;


    /// <summary>
    /// Represents an alegraic product of two types
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">Tht second type</typeparam>
    /// <typeparam name="X3">Tht third type</typeparam>
    public readonly struct Product<X1, X2, X3> : IEquatable<Product<X1, X2, X3>>, IFactoredContainer<X1,X2,X3>
    {
        public static implicit operator Product<X1, X2, X3>((X1, X2, X3) x)
            => new Product<X1, X2, X3>(x);

        public static explicit operator (X1, X2) (Product<X1, X2, X3> x)
            => (x.x1, x.x2);

        public static implicit operator (X1, X2, X3)(Product<X1, X2, X3> x)
            => (x.x1,x.x2, x.x3);

        public static bool operator ==(Product<X1, X2, X3> x, Product<X1, X2, X3> y)
            => x.Equals(y);

        public static bool operator !=(Product<X1, X2, X3> x, Product<X1, X2, X3> y)
            => not(x.Equals(y));

        public Product((X1 x1, X2 x2, X3 x3) x)
        {
            this.x1 = x.x1;
            this.x2 = x.x2;
            this.x3 = x.x3;
            
        }

        public Product(X1 x1, X2 x2, X3 x3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }

        X1 x1 { get; }

        X2 x2 { get; }

        X3 x3 { get; }

        public Cardinality Cardinality
            => Cardinality.Finite;

        public Y Map<Y>(Func<X1, X2, X3, Y> f)
            => f(x1, x2, x3);

        public Y Map<Y>(Func<(X1, X2, X3), Y> f)
            => f((x1, x2, x3));

        public override bool Equals(object obj)
            => obj is Product<X1, X2, X3>
                ? Equals((Product<X1, X2, X3>)obj) : false;

        public bool Equals(Product<X1, X2, X3> other)
            => object.Equals(this.x1, other.x1)
            && object.Equals(this.x2, other.x2)
            && object.Equals(this.x3, other.x3)
            ;

        public override string ToString()
            => string.Join(Symbol.and.Spaced(), 
                component(x1), component(x2), component(x3));

        public override int GetHashCode()
            => (x1, x2).GetHashCode();

        public IFactoredContainer<Y1, Y2, Y3> Recontain<Y1, Y2, Y3>(Func<(X1, X2, X3), (Y1, Y2, Y3)> map)
            => new Product<Y1, Y2, Y3>(map(this));

        public Seq<(X1, X2, X3)> Contained()
            => Seq.cons((x1,x2,x3));

        public IEnumerable<(X1, X2, X3)> Stream()
            => Contained().Stream();

        public IEnumerator GetEnumerator()
            => Stream().GetEnumerator();


        object[] components
            => array<object>(x1, x2, x3);



    }

}

