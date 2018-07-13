//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a <see cref="IComparer{T}"/> implementation by delegating to a
    /// provided <see cref="Orderer{X}"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <remarks>This exists for compatibily with the .Net framework comparison mechanisms</remarks>
    public readonly struct OrderComparer<X> : IComparer<X>
    {
        public OrderComparer(Orderer<X> Orderer)
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