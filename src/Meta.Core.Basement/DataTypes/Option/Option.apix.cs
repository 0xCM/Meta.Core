//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Runtime.CompilerServices;

using MC = Meta.Core;

public static class OptionCondense
{

    public static Option<int> Condense<T>(this IEnumerable<Option<T>> options)
    {
        var failure = options.Any(o => o.IsNone());
        if (failure)
            return options.First(x => x.IsNone()).ToNone<int>();
        return options.Count();
    }

    /// <summary>
    /// Extracts the encapsluated value if present; otherwise reutrns the underlying value type default
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static T Value<T>(this Option<T?> x)
        where T : struct => x.ValueOrElse(() => default(T)).Value;

    /// <summary>
    /// Extracts the encapsluated value if present; otherwise returns the default value of the type
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="x">The optional value</param>
    /// <returns></returns>
    public static T Value<T>(this Option<T> x)
        where T : struct => x.ValueOrDefault();

    public static IReadOnlyList<P> Items<P>(this Option<IReadOnlyList<P>> x)
        => x.IsSome() ? ~x : new P[] { };

    public static ReadOnlyList<P> Items<P>(this Option<ReadOnlyList<P>> x)
        => x.IsSome() ? ~x : ReadOnlyList.Create(new P[] { });

    public static ReadOnlyList<P> Items<P>(this Option<ReadOnlyList<P>> x, Action<IAppMessage> error)
    {
        if (x.IsSome())
            return x.Items();
        else
        {
            var message
                = x.Message.IsEmpty
                ? AppMessage.Error("Required option has no value")
                : x.Message;
            error(message);
            return ReadOnlyList.Create(new P[] { });
        }
    }


    public static IEnumerable<T> Items<T>(this Option<IEnumerable<T>> x, Action<IAppMessage> error = null)
    {

        if (x)
        {
            return x.ValueOrDefault();
        }
        else
        {
            error?.Invoke(x.Message);
            return new T[] { };
        }
    }

    public static P First<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().First();

    public static P FirstOrDefault<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().FirstOrDefault();

    /// <summary>
    /// Extracts the encapsulated values from a sequence of optional values (where Some)
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="options">The options to examine</param>
    /// <returns></returns>
    public static IEnumerable<T> Values<T>(this IEnumerable<Option<T>> options)
        => options.WhereSome().Select(x => x.ValueOrDefault());

    public static T SingleOrDefault<T>(this Option<IEnumerable<T>> x)
        => x.MapValueOrDefault(seq => seq.SingleOrDefault());

    public static T First<T>(this Option<IEnumerable<T>> x)
        => x.MapRequired(y => y.First());

    public static T FirstOrDefault<T>(this Option<IEnumerable<T>> x)
        => x.MapValueOrDefault(seq => seq.FirstOrDefault());

    public static T Single<T>(this Option<T> x)
        where T : IEnumerable<T>
            => x.MapRequired(z => z.Single());

    public static Option<T> TryGetSingle<T>(this Option<IReadOnlyList<T>> src)
        => src.Map(x => x.SingleOrDefault());

    /// <summary>
    /// Transforms a <see cref="Option{T}"/> into a <see cref="Nullable{T}"/> when T is a CLR value type
    /// </summary>
    /// <typeparam name="T">The underlying CLR value type</typeparam>
    /// <param name="x">The potential value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ToNullable<T>(this Option<T> x) where T : struct
        => x.IsSome() ? new T?(x.ValueOrDefault()) : new T?();


    /// <summary>
    /// Returns the first valued option from those supplied, if any
    /// </summary>
    /// <typeparam name="T">The potential value type</typeparam>
    /// <param name="potentials"></param>
    /// <returns></returns>
    public static Option<T> TryGetFirst<T>(params Option<T>[] potentials)
    {
        foreach (var possibility in potentials)
            if (possibility.IsSome())
                return possibility;
        return Option.None<T>();
    }

    /// <summary>
    /// Selects subsequence for which no encapsulated value exists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IEnumerable<Option<T>> WhereNone<T>(this IEnumerable<Option<T>> options)
        => from option in options where option.IsNone() select option;

    /// <summary>
    /// Selects subsequence for which an encapsulated value exists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IEnumerable<Option<T>> WhereSome<T>(this IEnumerable<Option<T>> options)
        => from option in options where option.IsSome() select option;

    /// <summary>
    /// Applies a map to a valued option; otherwise, raises an exception
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    /// <param name="x"></param>
    /// <param name="F"></param>
    /// <returns></returns>
    public static Y MapRequired<X, Y>(this Option<X> x, Func<X, Y> F)
        => F(x.Require());

    /// <summary>
    /// Returns true if an optioal value exists an a specified predicate over the value is satisfied
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="x">The value to examine</param>
    /// <param name="predicate">The adjudicating predicate</param>
    /// <returns></returns>
    public static bool Satisfies<T>(this Option<T> x, Predicate<T> predicate)
        => x.Map(y => predicate(y)).ValueOrDefault();

    /// <summary>
    /// Bifurcates a stream of optional values into the haves/have nots
    /// </summary>
    /// <typeparam name="T">The optional value type</typeparam>
    /// <param name="options">The stream of options to evaluate</param>
    /// <returns></returns>
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
    /// Invokes an action when all supplied options have value
    /// </summary>
    /// <typeparam name="X1">The type of the first potential item</typeparam>
    /// <typeparam name="X2">The type of the second potential item</typeparam>
    /// <param name="x1">The first potential value</param>
    /// <param name="x2">The second potential value</param>
    /// <param name="f">The action to conditionally invoke</param>
    public static void WhenAll<X1, X2>(Option<X1> x1, Option<X2> x2, Action<X1, X2> f)
    {
        if (All(x1, x2))
            f(x1.Require(), x2.Require());
    }

    /// <summary>
    /// Invokes the supplied action if all values exist
    /// </summary>
    /// <typeparam name="X1">The type of the first potential value</typeparam>
    /// <typeparam name="X2">The type of the second potential value</typeparam>
    /// <typeparam name="X3">The type of the third potential value</typeparam>
    /// <param name="x1">The first potential value</param>
    /// <param name="x2">The second potential value</param>
    /// <param name="x3">The third potential value</param>
    /// <param name="f">The action to conditionally invoke</param>
    public static void WhenAll<X1, X2, X3>(Option<X1> x1, Option<X2> x2, Option<X3> x3, Action<X1, X2, X3> f)
    {
        if (All(x1, x2, x3))
            f(x1.Require(), x2.Require(), x3.Require());
    }

}
