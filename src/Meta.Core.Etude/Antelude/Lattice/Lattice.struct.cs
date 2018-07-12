//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;

    /// <summary>
    /// Defines a meet-semilattice over <typeparamref name="X"/> values
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>
    /// A Meet-semilattice is a poset if ever two-element subset has a greatest lower bound
    /// (otherwise known as a Meet)
    /// See https://en.wikipedia.org/wiki/Lattice_(order)
    /// </remarks>
    public readonly struct MeetSemilattice<X> : IMeetSemilattice<X>
    {
        public MeetSemilattice(Equator<X> Equator, Orderer<X> Orderer)
        {
            this.Equator = Equator;
            this.Orderer = Orderer;
        }

        Equator<X> Equator { get; }

        Orderer<X> Orderer { get; }

        public bool eq(X x1, X x2)
            => Orderer(x1, x2) == Ordering.EQ;

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));

        public Ordering PartialCompare(X x1, X x2)
            => Orderer(x1, x2);
        public override string ToString()
            => GetType().DisplayName();

    }

    /// <summary>
    /// Defines a join-semilattice over <typeparamref name="X"/> values
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>
    /// A join-semilattice is a poset if ever two-element subset has a least upper bound
    /// (otherwise known as a join)
    /// See https://en.wikipedia.org/wiki/Lattice_(order)
    /// </remarks>
    public readonly struct JoinSemilattice<X> : IJoinSemilattice<X>
    {
        public JoinSemilattice(Equator<X> Equator, Orderer<X> Orderer)
        {
            this.Equator = Equator;
            this.Orderer = Orderer;

        }

        Equator<X> Equator { get; }

        Orderer<X> Orderer { get; }

        public bool eq(X x1, X x2)
            => Orderer(x1, x2) == Ordering.EQ;

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));

        public Ordering PartialCompare(X x1, X x2)
            => Orderer(x1, x2);
    }

    /// <summary>
    /// Defines a latice over <typeparamref name="X"/> values
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>
    /// A lattice is a poset that satisfies the criteria for both meet and join semilattices
    /// See https://en.wikipedia.org/wiki/Lattice_(order)
    /// </remarks>
    public readonly struct Lattice<X> : ILattice<X>
    {
        public Lattice(Equator<X> Equator, Orderer<X> Orderer)
        {
            this.Equator = Equator;
            this.Orderer = Orderer;
        }

        Equator<X> Equator { get; }

        Orderer<X> Orderer { get; }

        public bool eq(X x1, X x2)
            => Orderer(x1, x2) == Ordering.EQ;

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));

        public Ordering PartialCompare(X x1, X x2)
            => Orderer(x1, x2);
    }
}
