//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using Meta.Core;


partial class etude
{

    /// <summary>
    /// Constructs a <see cref="IOrdered"/> instance over <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The type whose values are to be ordered</typeparam>
    /// <returns></returns>
    public static Option<IOrdered<X>> order<X>()
        => Ordered.make<X>();
        
    /// <summary>
    /// Retrieves an identified <see cref="IOrdered"/> instance
    /// </summary>
    /// <typeparam name="X">The type over which an order is constructed</typeparam>
    /// <returns></returns>
    public static IOrderOperators<X> orderops<X>()
        => Ordered.orderops<X>().Require();

    /// <summary>
    /// Returns true if the first value is less than the second value
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public static bool lt<X>(X x1, X x2)
        => orderops<X>().lt(x1, x2);

    /// <summary>
    /// Returns true if the first value is less than or equal to the second value
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public static bool lteq<X>(X x1, X x2)
        => orderops<X>().lteq(x1, x2);

    /// <summary>
    /// Returns true if the first value is greater than the second value
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public static bool gt<X>(X x1, X x2)
        => orderops<X>().gt(x1, x2);

    /// <summary>
    /// Returns true if the first value is greater than or equal the second value
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public static bool gteq<X>(X x1, X x2)
        => orderops<X>().gteq(x1, x2);

    /// <summary>
    /// Returns the maximum of two values
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first test value</param>
    /// <param name="x2">The second test value</param>
    /// <returns></returns>
    public static X min<X>(X x1, X x2)
        => orderops<X>().min(x1, x2);

    /// <summary>
    /// Returns the maximum of two values
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first test value</param>
    /// <param name="x2">The second test value</param>
    /// <returns></returns>
    public static X max<X>(X x1, X x2)
        => orderops<X>().max(x1, x2);

    /// <summary>
    /// Returns true if a value falls within a specified range
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x">The test value</param>
    /// <param name="x1">The minimum value</param>
    /// <param name="x2">The maximum value</param>
    /// <returns></returns>
    public static bool between<X>(X x, X x1, X x2)
        => orderops<X>().between(x, x1, x2);

    /// <summary>
    /// Returns true if a test value falls within a <see cref="Interval{X}"/>
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x">The test value</param>
    /// <param name="interval">The bounds</param>
    /// <returns></returns>
    public static bool within<X>(X x, Interval<X> interval)
        => interval.MinIncluded ? lteq(x, interval.Min) : lt(x, interval.Min)
            && interval.MaxIncluded ? gteq(x, interval.Max) : gt(x, interval.Max);
}
