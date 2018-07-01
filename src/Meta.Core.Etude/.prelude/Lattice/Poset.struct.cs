//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;

    /// <summary>
    /// Defines a partially-ordered set over <typeparamref name="X"/> values
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>
    /// https://en.wikipedia.org/wiki/Partially_ordered_set
    /// </remarks>
    public readonly struct Poset<X> : IPartialOrder<X>
    {
        public Poset(Equator<X> Equator, Orderer<X> Orderer)
        {
            this.Equator = Equator;
            this.Orderer = Orderer;
        }

        Equator<X> Equator { get; }

        Orderer<X> Orderer { get; }

        public bool eq(X a1, X a2)
            => Equator(a1, a2);

        public bool neq(X a1, X a2)
            => not(Equator(a1, a2));

        public Ordering PartialCompare(X a1, X a2)
            => Orderer(a1, a2);

        public override string ToString()
            => GetType().DisplayName();

    }
}