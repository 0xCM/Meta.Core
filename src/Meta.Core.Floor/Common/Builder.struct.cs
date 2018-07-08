//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Defines a monad to facilitate an expressive builder pattern
/// </summary>
/// <typeparam name="X">The base space over which the monad is defined</typeparam>
public readonly struct Builder<X> : IBuilder<X>
{
    /// <summary>
    /// Creates a builder initialized with the supplied value
    /// </summary>
    /// <param name="Value">The initial vlue</param>
    /// <returns></returns>
    public static Builder<X> Build(X Value)
        => new Builder<X>(Value);

    /// <summary>
    /// Implicitly lifts a value from the base space X into the construction space
    /// </summary>
    /// <param name="x">The value to lift</param>
    public static implicit operator Builder<X>(X x)
        => new Builder<X>(x);

    /// <summary>
    /// Drops a value from the construction space to the base space
    /// </summary>
    /// <param name="x">The value to lift</param>
    public static implicit operator X(Builder<X> x)
        => x.Value;

    /// <summary>
    /// Drops a value from the construction space to the base space
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static X operator ~(Builder<X> x) 
        => x.Value;

    /// <summary>
    /// Initalizes the builder
    /// </summary>
    /// <param name="Value"></param>
    public Builder(X Value)
        => this.Value = Value;

    /// <summary>
    /// The encapsulated value
    /// </summary>
    X Value { get; }

    /// <summary>
    /// Canonical bind
    /// </summary>
    /// <typeparam name="Y">The base space fro the range of the bound function</typeparam>
    public Builder<Y> Bind<Y>(Func<X, Builder<Y>> f)
        => f(Value);

    /// <summary>
    /// Canonical select
    /// </summary>
    /// <typeparam name="Y">The target base space</typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    public Builder<Y> Select<Y>(Func<X, Y> selector)
            => selector(Value);

    /// <summary>
    /// Canonical select many
    /// </summary>
    /// <typeparam name="Y">The intermediate base space</typeparam>
    /// <typeparam name="Z">The target base space</typeparam>
    /// <param name="select"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public Builder<Z> SelectMany<Y, Z>(Func<X, Builder<Y>> select, Func<X, Y, Z> project)
    {
        var x = Value;
        return select(x).Bind<Z>(y => project(x, y));
    }
}

