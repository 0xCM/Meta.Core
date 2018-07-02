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


    public interface IProduct<X> : IEquatable<Product<X>>, IContainer<X>
    {


    }

    /// <summary>
    /// Represents an alegraic product of two types
    /// </summary>
    /// <typeparam name="X">The underlying type</typeparam>
    public readonly struct Product<X> : IProduct<X>
    {
        public static implicit operator Product<X>(X x)
            => new Product<X>(x);

        public static implicit operator X(Product<X> x)
            => x;

        public static bool operator ==(Product<X> x, Product<X> y)
            => x.Equals(y);

        public static bool operator !=(Product<X> x, Product<X> y)
            => not(x.Equals(y));

        public Product(X x)
        {
            this.x = x;
        }

        X x { get; }


        public Y Map<Y>(Func<X, Y> f)
            => f(x);

        object[] components
            => array<object>(x);

        public Cardinality Cardinality
            => Cardinality.Finite;

        public ContainerFactory<X> Factory
            => stream => new Product<X>(stream.Single());


        public override bool Equals(object obj)
            => obj is Product<X>
                ? Equals((Product<X>)obj) : false;

        public bool Equals(Product<X> other)
            => object.Equals(this.x, other.x);

        public override string ToString()
            => string.Join(Symbol.and.Spaced(), component(x));

        public override int GetHashCode()
            => x.GetHashCode();

        public Seq<X> Contained()
            => Seq.singleton(x);

        public IContainer<Y> Recontain<Y>(Func<X, Y> map)
            => Seq.singleton(map(x));


        public IEnumerable<X> Stream()
            => Contained().Stream();

    }

}

