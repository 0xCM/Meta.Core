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


public static class OptionExtraction
{
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

    public static IEnumerable<P> Items<P>(this Option<IEnumerable<P>> x)
        => x.IsSome() ? ~x : new P[] { };

    public static IReadOnlyList<P> Items<P>(this Option<IReadOnlyList<P>> x)
        => x.IsSome() ? ~x : new P[] { };

    public static ReadOnlyList<P> Items<P>(this Option<ReadOnlyList<P>> x)
        => x.IsSome() ? ~x : ReadOnlyList.Create(new P[] { });

    public static ReadOnlyList<P> Items<P>(this Option<ReadOnlyList<P>> x, Action<IApplicationMessage> error)
    {
        if (x.IsSome())
            return x.Items();
        else
        {
            var message
                = x.Message.IsEmpty
                ? ApplicationMessage.Error("Required option has no value")
                : x.Message;
            error(message);
            return ReadOnlyList.Create(new P[] { });
        }
    }

    public static IReadOnlyList<P> Items<P>(this Option<IReadOnlyList<P>> x, Action<IApplicationMessage> error)
    {
        if (x)
            return x.Require();
        else
        {
            error(x.Message);
            return new P[] { };
        }
    }

    public static IEnumerable<X> ToSequence<X>(this Option<IEnumerable<X>> x)
    {
        var src = x.ValueOrDefault(new X[] { });
        foreach (var item in src)
            yield return item;
    }

    public static IReadOnlyList<X> ToList<X>(this Option<IReadOnlyList<X>> x)
    {
        return x.ValueOrDefault(new X[] { });
    }

    public static ISet<P> Items<P>(this Option<ISet<P>> x)
        => x.ValueOrDefault(new HashSet<P>());

    public static ISet<P> Items<P>(this Option<ISet<P>> x, Action<IApplicationMessage> error)
        => x.ValueOrDefault();

    public static IEnumerable<T> Items<T>(this Option<IEnumerable<T>> x, Action<IApplicationMessage> error = null)
    {

        if (x)
        {
            return x.Items();
        }
        else
        {
            error?.Invoke(x.Message);
            return new T[] { };
        }
    }

    public static MC.MutableSet<P> Set<P>(this Option<IReadOnlyList<P>> x)
    {
        if (x.IsSome())
            return new MC.MutableSet<P>(x.Items());
        else
            throw new Exception();
    }

    public static MC.MutableSet<P> Set<P>(this Option<ReadOnlyList<P>> x)
    {
        if (x.IsSome())
            return new MC.MutableSet<P>(x.Items());
        else
            throw new Exception();
    }

    public static P First<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().First();

    public static P FirstOrDefault<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().FirstOrDefault();

    public static P Single<P>(this Option<IReadOnlyList<P>> x)
        => x.Items().Single();

    public static P SingleOrDefault<P>(this Option<IReadOnlyList<P>> x, Action<IApplicationMessage> error)
        => x.Items(error).SingleOrDefault();

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
        => x.MapValue(y => y.First());

    public static T FirstOrDefault<T>(this Option<IEnumerable<T>> x)
        => x.MapValueOrDefault(seq => seq.FirstOrDefault());

    public static T Single<T>(this Option<T> x)
        where T : IEnumerable<T>
            => x.MapValue(z => z.Single());

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

}