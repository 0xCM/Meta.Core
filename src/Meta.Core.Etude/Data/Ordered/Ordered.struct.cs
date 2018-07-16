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
    /// Defines a <see cref="IOrdered{X}"/> instance predicated on a supplied <see cref="Orderer{X}"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct Ordered<X> : IOrdered<X>
    {        
        public Ordered(Orderer<X> Orderer)
            => this.Orderer = Orderer;

        Orderer<X> Orderer { get; }

        public Ordering compare(X x1, X x2)
            => Orderer(x1, x2);

        public bool eq(X x1, X x2)
             => Orderer(x1, x2) == Ordering.EQ;

    }

}