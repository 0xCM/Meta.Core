//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a <see cref="IComparer{T}"/> implementation by delegating to a
    /// provided <see cref="Orderer{X}"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>This exists for compatibily with the .Net framework comparison mechanisms</remarks>
    public readonly struct Komparer<X> : IComparer<X>
    {
        public Komparer(Orderer<X> Orderer)
            => this.Orderer = Orderer;

        Orderer<X> Orderer { get; }

        /// <summary>
        /// Implements the <see cref="IComparer{T}.Compare(T, T)"/> operation
        /// </summary>
        /// <param name="x">The first value</param>
        /// <param name="y">The second value</param>
        /// <returns></returns>
        public int Compare(X x, X y)
        {
            switch (Orderer(x, y))
            {
                case Ordering.LT:
                    return -1;
                case Ordering.GT:
                    return 1;
                default:
                    return 0;
            }
        }
    }
}