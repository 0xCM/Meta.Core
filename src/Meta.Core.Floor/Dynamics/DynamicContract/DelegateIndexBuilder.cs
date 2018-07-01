//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

/// <summary>
/// Implementation of a builder pattern that constructs <see cref="DelegateIndex"/> instances
/// based on supplied expressions and upon completion emits an implementation of the specified 
/// contract type, returning an instance to this implementation to the caller
/// </summary>
/// <typeparam name="TContract">The contract type</typeparam>
public class DelegateIndexBuilder<TContract>
{

    readonly DelegateIndex delegates;

    internal DelegateIndexBuilder()
    {
        delegates = new DelegateIndex();
    }

    public DelegateIndexBuilder<TContract> WithFunction<TResult>(string selector, Func<TResult> f)
    {
        delegates.Action(typeof(TContract).GetMethod(selector).Name, f);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithGet<TResult>
        (Expression<Func<TContract, TResult>> selector, Func<TResult> f)
    {
        delegates.Getter(selector.GetProperty().GetMethod.Name, f);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithFunction<TResult>
        (Expression<Func<TResult>> selector, Func<TResult> f)
    {
        delegates.Function(selector.GetMethod().Name, f);
        return this;
    }

    /// <summary>
    /// Creates an array of <see cref="Type"/> references from the supplied type parameters
    /// </summary>
    /// <typeparam name="T1">The first type parameter</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough]
    static Type[] type_array<T1>()
        => new Type[] { typeof(T1) };

    /// <summary>
    /// Creates an array of <see cref="Type"/> references from the supplied type parameters
    /// </summary>
    /// <typeparam name="T1">The first type parameter</typeparam>
    /// <typeparam name="T2">The second type parameter</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough]
    static Type[] type_array<T1, T2>()
        => new Type[] { typeof(T1), typeof(T2) };

    /// <summary>
    /// Creates an array of <see cref="Type"/> references from the supplied type parameters
    /// </summary>
    /// <typeparam name="T1">The first type parameter</typeparam>
    /// <typeparam name="T2">The second type parameter</typeparam>
    /// <typeparam name="T3">The third type parameter</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough]
    static Type[] type_array<T1, T2, T3>()
        => new Type[] { typeof(T1), typeof(T2), typeof(T3) };


    /// <summary>
    /// Creates an array of <see cref="Type"/> references from the supplied type parameters
    /// </summary>
    /// <typeparam name="T1">The first type parameter</typeparam>
    /// <typeparam name="T2">The second type parameter</typeparam>
    /// <typeparam name="T3">The third type parameter</typeparam>
    /// <typeparam name="T4">The fourth type parameter</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static Type[] type_array<T1, T2, T3, T4>()
        => new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };

    public DelegateIndexBuilder<TContract> WithFunction<T1, TResult>
        (string selector, Func<T1, TResult> f)
    {
        delegates.Function(typeof(TContract).GetMethod(selector, type_array<T1>()).Name, f);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithFunction<T1, TResult>
        (Expression<Func<TContract, T1, TResult>> selector, Func<T1, TResult> function)
    {
        delegates.Function(selector.GetMethod().Name, function);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithFunction<T1, T2, TResult>
        (string selector, Func<T1, T2, TResult> f)
    {
        delegates.Function(typeof(TContract).GetMethod(selector, type_array<T1, T2>()).Name, f);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithFunction<T1, T2, TResult>
        (Expression<Func<TContract, T1, T2, TResult>> selector, Func<T1, T2, TResult> function)
    {
        delegates.Function(selector.GetMethod().Name, function);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2>
        (string selector, Action<T1, T2> action)
    {
        delegates.Action(typeof(TContract).GetMethod(selector, type_array<T1, T2>()).Name, action);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2>
        (Expression<Action<T1, T2>> selector, Action<T1, T2> action)
    {
        delegates.Action(selector.GetMethod().Name, action);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2, T3>
        (string selector, Action<T1, T2, T3> action)
    {
        delegates.Action(typeof(TContract).GetMethod(selector, type_array<T1, T2, T3>()).Name, action);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2, T3>
        (Expression<Action<T1, T2, T3>> selector, Action<T1, T2, T3> action)
    {
        delegates.Action(selector.GetMethod().Name, action);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2, T3, T4>
        (string selector, Action<T1, T2, T3, T4> action)
    {
        delegates.Action(typeof(TContract).GetMethod(selector, type_array<T1, T2, T3, T4>()).Name, action);
        return this;
    }

    public DelegateIndexBuilder<TContract> WithAction<T1, T2, T3, T4>
        (Expression<Action<T1, T2, T3, T4>> selector, Action<T1, T2, T3, T4> action)
    {
        delegates.Action(selector.GetMethod().Name, action);
        return this;
    }

    /// <summary>
    /// Emits the implementation defined by the builder and returns an intance of this implementation
    /// to the caller
    /// </summary>
    /// <returns></returns>
    public TContract Realize() 
        => DelegatedContract.Realize<TContract>(typeof(TContract).Name + "Implementation", delegates);

}

