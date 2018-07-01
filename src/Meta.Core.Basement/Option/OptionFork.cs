//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


public static class OptionFork
{
    public static (IEnumerable<Option<T>> Left, IEnumerable<T> Right) Split<T>(this IEnumerable<Option<T>> options)
        => (options.WhereNone(), options.WhereSome().Select(x => x.ValueOrDefault()));

    /// <summary>
    /// Evaluates to true iff all options have values
    /// </summary>
    /// <param name="options">The options to evaluate</param>
    /// <returns></returns>
    public static bool All(params IOption[] options)
        => options.All(o => o.IsSome);

    /// <summary>
    /// Evaluates to true if the option has a value and and the encapsulated list is nonempty
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static bool Any<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().Any();

    public static bool Any<P>(this Option<IReadOnlyList<P>> x, Func<P, bool> predicate)
        => x.Items().Any(predicate);

    /// <summary>
    /// Applies the predicate to the supplied value, yielding Some if the value is valid
    /// and None otherwise
    /// </summary>
    /// <typeparam name="T">The type of value being validated</typeparam>
    /// <param name="x">The value to validate</param>
    /// <param name="predicate">The adjudicating predicate</param>
    /// <returns></returns>
    public static bool Satisfies<T>(this Option<T> x, Predicate<T> predicate)
        => x ? predicate(~x) : false;

    /// <summary>
    /// Applies an action to a value when it exists
    /// </summary>
    /// <param name="option">The potential value</param>
    /// <param name="A">The action to apply when a value exists</param>
    /// <returns></returns>
    public static IOption OnSome(this IOption option, Action<object> A)
    {
        if (option.IsSome)
            A(option.Value);
        return option;
    }

    /// <summary>
    /// Applies an action to an option message when no value exists
    /// </summary>
    /// <param name="option">The potential value</param>
    /// <param name="A">The action to apply when no value exists</param>
    /// <returns></returns>
    public static IOption OnNone(this IOption option, Action<IApplicationMessage> A)
    {
        if (option.IsNone)
            A(option.Message);
        return option;
    }

    /// <summary>
    /// Invokes an action when all supplied options have value
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="f"></param>
    public static void WhenAll<T1, T2>(Option<T1> t1, Option<T2> t2, Action<T1, T2> f)
    {
        if (All(t1, t2))
            f(t1.Require(), t2.Require());
    }

    /// <summary>
    /// Invokes the supplied action if all values are specified
    /// </summary>
    /// <typeparam name="T1">The type of the first value</typeparam>
    /// <typeparam name="T2">The type of the second value</typeparam>
    /// <typeparam name="T3">The type of the third value</typeparam>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="t3"></param>
    /// <param name="f">The action to conditionally invoke</param>
    public static void WhenAll<T1, T2, T3>(Option<T1> t1, Option<T2> t2, Option<T3> t3, Action<T1, T2, T3> f)
    {
        if (All(t1, t2, t3))
            f(t1.Require(), t2.Require(), t3.Require());
    }



}