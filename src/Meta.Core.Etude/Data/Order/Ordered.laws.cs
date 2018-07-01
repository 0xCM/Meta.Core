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

    public interface IOrdered : IEq
    {

    }

    /// <summary>
    /// A mathematical total order
    /// </summary>
    /// <typeparam name="X">The type over which a total order is defined</typeparam>
    /// <remarks>See http://hackage.haskell.org/package/base-4.11.1.0/docs/Data-Ord.html </remarks>
    public interface IOrdered<X> : IEq<X>
    {
        /// <summary>
        /// Returns true if the first value is less than the second
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        bool lt(X x1, X x2);

        /// <summary>
        /// Returns true if the first value is less than or equql to the second
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        bool lteq(X x1, X x2);

        /// <summary>
        /// Returns true if the first value is greater than the second
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        bool gt(X x1, X x2);

        /// <summary>
        /// Returns true if the first value is greater than or equal to than the second
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        bool gteq(X x1, X x2);

        /// <summary>
        /// Returns the lesser of two values
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        X min(X x1, X x2);

        /// <summary>
        /// Returns the greater of two values
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        X max(X x1, X x2);

        /// <summary>
        /// Returns true if the first value is within the closed interval determined by
        /// <paramref name="x1"/> and <paramref name="x2"/> respectively
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        bool between(X x, X x1, X x2);

        /// <summary>
        /// Determines the <see cref="Ordering"/> classification for a pair of values
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        Ordering compare(X x1, X x2);
    }

}