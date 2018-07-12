//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Classifies an binary order evaluation
    /// </summary>
    public enum Ordering
    {
        /// <summary>
        /// Indicates the left value was less than the right value
        /// </summary>
        LT = -1,

        /// <summary>
        /// Indcates the the left and right values were equal
        /// </summary>
        EQ = 0,

        /// <summary>
        /// Indicates the left value was greater than the right value
        /// </summary>
        GT = 1
    }

    /// <summary>
    /// Canonical signature for a function that determines whether one value is 
    /// less than, greater than or equal to another
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public delegate Ordering Orderer<in X>(X x1, X x2);


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