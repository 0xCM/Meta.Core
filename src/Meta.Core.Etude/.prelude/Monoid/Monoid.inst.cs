//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    /// <summary>
    /// Defines a monoid over <typeparamref name="X"/> predicated on intrinsic operators
    /// </summary>
    /// <typeparam name="X"></typeparam>
    readonly struct MonoidI<X> : IMonoid<X>
    {
        public static readonly MonoidI<X> Default = default;

        static IMonoid<X> _Default
            = new Monoid<X>(operators.eq, operators.add, operators.zero<X>());

        public X zero
            => _Default.zero;            

        public X combine(X a1, X a2)
            => _Default.combine(a1, a2);

        public bool eq(X x1, X x2)
            => _Default.eq(x1, x2);

    }

    public interface IListMonoid<X> : IMonoid<Lst<X>>
    {

    }

    readonly struct ListMonoid<X> : IListMonoid<X>
    {
        public static readonly ListMonoid<X> instance = default;

        public Lst<X> zero
            => Lst<X>.Empty;

        public Lst<X> combine(Lst<X> a1, Lst<X> a2)
            => a1 + a2;

        public bool eq(Lst<X> x1, Lst<X> x2)
            => x1 == x2;
    }

    public interface ISeqMonoid<X> : IMonoid<Seq<X>>
    {

    }
    readonly struct SeqMonoid<X> : ISeqMonoid<X>
    {
        public static readonly SeqMonoid<X> instance = default;

        public Seq<X> zero
            => Seq<X>.Empty;

        public Seq<X> combine(Seq<X> a1, Seq<X> a2)
            => a1 + a2;

        public bool eq(Seq<X> x1, Seq<X> x2)
            => x1 == x2;
    }

    public interface IIndexMonoid<X> : IMonoid<Index<X>>
    {

    }

    readonly struct IndexMonoid<X> : IIndexMonoid<X>
    {
        public static readonly IndexMonoid<X> instance = default;

        public Index<X> zero
            => Index<X>.Empty;

        public Index<X> combine(Index<X> a1, Index<X> a2)
            => a1 + a2;

        public bool eq(Index<X> x1, Index<X> x2)
            => x1 == x2;
    }

}