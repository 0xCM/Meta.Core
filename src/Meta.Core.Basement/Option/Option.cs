//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public static class Option
{
    internal static Option<T> None<T>(IApplicationMessage message = null)
        => Option<T>.None(message);

    internal static Option<T> Some<T>(T value, IApplicationMessage message = null)
        => Option<T>.Some(value, message);

    /// <summary>
    /// Implements the canonical join operation that reduces the monadic depth by one level
    /// </summary>
    /// <typeparam name="T">The encapsulated value</typeparam>
    /// <param name="option"></param>
    /// <returns></returns>
    public static Option<T> collapse<T>(Option<Option<T>> option)
        => option.ValueOrDefault(None<T>());

    /// <summary>
    /// Classifies the value as some or none and manufactures the appropriate option encapsulation
    /// </summary>
    /// <typeparam name="T">The type of value</typeparam>
    /// <param name="value">The value to lift into option-space</param>
    /// <returns></returns>
    public static Option<T> eval<T>(T value)
        where T : class
            => value is null ? None<T>()  : Some(value);

    /// <summary>
    /// Defines canonical functor for <see cref="Option{T}"/>
    /// </summary>
    /// <typeparam name="A">The source type</typeparam>
    /// <typeparam name="B">The target type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Func<Option<A>, Option<B>> fmap<A, B>(Func<A, B> f)
        => x => x.Map(a => f(a));

    /// <summary>
    /// Implements the canonical bind operation
    /// </summary>
    /// <typeparam name="X">The source domain type</typeparam>
    /// <typeparam name="Y">The target domain type</typeparam>
    /// <param name="x">The point in the monadic space over X</param>
    /// <param name="f">The function to apply to effect the bind</param>
    /// <returns></returns>
    public static Option<Y> bind<X, Y>(Option<X> x, Func<X, Option<Y>> f)
    {
        if (x)
        {
            var y = f(x.ValueOrDefault());
            var m = ApplicationMessage.Combine(x.Message, y.Message);
            return y.WithMessage(m);
        }
        else
            return None<Y>(x.Message);
    }

    /// <summary>
    /// Defines equality between 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static bool eq<T>(Option<T> x, Option<T> y)
    {
        if (!x.Exists && !y.Exists)
            return true;

        if (x.Exists && y.Exists)
            return  Object.Equals(x.ValueOrDefault(), y.ValueOrDefault());

        return false;
    }

    public static string render<X>(Option<X> x)
        => x.MapValueOrElse(value => value?.ToString() ?? string.Empty, 
            message => message.ToOption().Map(m => m.Format(), 
                () => string.Empty));
}
