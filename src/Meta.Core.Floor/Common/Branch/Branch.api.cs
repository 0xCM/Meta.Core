//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using Meta.Core;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class metacore
{
    /// <summary>
    /// Applies f(v) if v is of type X otherwise applies unmatched(v)
    /// </summary>
    /// <typeparam name="X">The match type</typeparam>
    /// <typeparam name="Y">The evaluation type</typeparam>
    /// <param name="v">The candidate value</param>
    /// <param name="f">The function to apply if matched</param>
    /// <param name="u">The function to apply if unmatched</param>
    /// <returns></returns>
    public static Y ifType<X, Y>(object v, Func<X, Y> f, Func<object, Y> u)
    {
        switch (v)
        {
            case X x:
                return f(x);
            default:
                return u(v);
        }
    }

    /// <summary>
    /// Applies f(v) if v is of type X otherwise returns None
    /// </summary>
    /// <typeparam name="X">The match type</typeparam>
    /// <typeparam name="Y">The evaluation type</typeparam>
    /// <param name="v">The candidate value</param>
    /// <param name="f">The function to apply if matched</param>
    /// <returns></returns>
    public static Option<Y> ifType<X, Y>(object v, Func<X, Y> f)
    {
        switch (v)
        {
            case X x:
                return f(x);
            default:
                return none<Y>();
        }
    }

    /// <summary>
    /// Applies f(X left, X right) if possible, otherwise returns None
    /// </summary>
    /// <typeparam name="X">The right input type</typeparam>
    /// <typeparam name="Y">The output type</typeparam>
    /// <param name="v">The value to be evaluated </param>
    /// <param name="f">The function to apply</param>
    /// <returns></returns>
    public static Option<Y> ifType<X, Y>((object candididate, X right) v, Func<(X left, X right), Y> f)
    {
        switch (v.candididate)
        {
            case X x:
                return f((x, v.right));
            default:
                return none<Y>();
        }
    }

    /// <summary>
    /// Applies f(X left, X right) if possible, otherwise applies f(candidate)
    /// </summary>
    /// <typeparam name="X">The right input type</typeparam>
    /// <typeparam name="Y">The output type</typeparam>
    /// <param name="v">The value to be evaluated </param>
    /// <param name="f">The function to apply</param>
    /// <param name="else">The alternate</param>
    /// <returns></returns>
    public static Y ifType<X, Y>((object candididate, X right) v, Func<(X left, X right), Y> f, Func<object, Y> @else)
    {
        switch (v.candididate)
        {
            case X x:
                return f((x, v.right));
            default:
                return @else(v.candididate);
        }
    }

    /// <summary>
    /// Invokes an action if the supplied value is not null
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="value">The potentially null value</param>
    /// <param name="a">The action to invoke if possible</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit onValue<V>(V value, Action<V> a)
    {
        if (value != null)
            a(value);

        return Unit.Value;
    }

    /// <summary>
    /// Executes one action if a condition is true and another should it be false
    /// </summary>
    /// <param name="condition">Specifies whether some condition is true</param>
    /// <param name="true">The action to invoke when condition is true</param>
    /// <param name="false">The action to invoke when condition is false</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit on(bool condition, Action @true, Action @false = null)
    {
        if (condition)
            @true();
        else
            @false?.Invoke();

        return Unit.Value;
    }

    /// <summary>
    /// Evaluates a function over a value if the value is not null; otherwise,
    /// returns the default result value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="x"></param>
    /// <param name="f1"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult ifNotNull<T, TResult>(T x, Func<T, TResult> f1, TResult @default = default)
        => x != null ? f1(x) : @default;

    /// <summary>
    /// Evaluates a function over a value if the value is not null; otherwise invokes
    /// a function that will produce a value that is within the expected range
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <typeparam name="TResult">The function result type</typeparam>
    /// <param name="x">The object to test</param>
    /// <param name="f1">The non-null evaluator</param>
    /// <param name="f2">The null evaluator</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult ifNotNull<T, TResult>(T x, Func<T, TResult> f1, Func<TResult> f2)
        where T : class => (x != null) ? f1(x) : f2();

    /// <summary>
    /// Evaluates a predicate and then brances based on the outcome of the evaluation
    /// </summary>
    /// <typeparam name="X">The type of value to evaluate and subsequently process</typeparam>
    /// <typeparam name="Y">The output type</typeparam>
    /// <param name="test">The input value</param>
    /// <param name="predicate">The predicate that will determine the branch to invoke</param>
    /// <param name="whenTrue">The function to execute when the predicate evaulates to true</param>
    /// <param name="whenFalse">The function to evaluate when the predicate evaluates to false</param>
    /// <returns></returns>
    public static Y when<X, Y>(X test, Predicate<X> predicate, Func<X, Y> whenTrue, Func<X, Y> whenFalse)
        => predicate(test) ? whenTrue(test) : whenFalse(test);

    /// <summary>
    /// Executes one of two functions depending on the evaulation criterion
    /// </summary>
    /// <typeparam name="X">The function input type</typeparam>
    /// <typeparam name="Y">The function output type</typeparam>
    /// <param name="criterion">The criterion on which to branch</param>
    /// <param name="value">The value to supply to the chosen function</param>
    /// <param name="onTrue">The function to evaulate when the criterion is true</param>
    /// <param name="onFalse">The function to evaulate when the criterion is false</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y ifElse<X, Y>(bool criterion, X value, Func<X, Y> onTrue, Func<X, Y> onFalse)
        => criterion ? onTrue(value) : onFalse(value);

    /// <summary>
    /// Executes one of two functions depending on the evaulation criterion
    /// </summary>
    /// <typeparam name="X">The function input type</typeparam>
    /// <param name="criterion">The criterion on which to branch</param>
    /// <param name="onTrue">The function to evaulate when the criterion is true</param>
    /// <param name="onFalse">The function to evaulate when the criterion is false</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X ifElse<X>(bool criterion, Func<X> onTrue, Func<X> onFalse)
        => criterion ? onTrue() : onFalse();

    /// <summary>
    /// Executes a function if the criterion is true, otherwise returns the supplied value
    /// </summary>
    /// <typeparam name="X">The function input/output type</typeparam>
    /// <param name="criterion">The criterion on which to branch</param>
    /// <param name="value">The value to supply to the chosen function</param>
    /// <param name="onTrue">The function to evaulate when the criterion is true</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X ifTrue<X>(bool criterion, X value, Func<X, X> onTrue)
        => criterion ? onTrue(value) : value;

    /// <summary>
    /// Returns the supplied value if not null, otherwise invokes a function to provide
    /// a non-null value as a replacement
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="x">The object to test</param>
    /// <param name="replace">The function that yields a replacement value in the event that the supplied value is null</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ifNull<T>(T x, Func<T> replace)
        where T : class => x ?? replace();

    /// <summary>
    /// Maps the source <paramref name="x"/> to a value in the target space <typeparamref name="Y"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="x"></param>
    /// <param name="null"></param>
    /// <param name="else"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y ifNull<X, Y>(X x, Func<Y> @null, Func<X, Y> @else)
        => isNull(x) ? @null() : @else(x);

    /// <summary>
    /// Returns the source <paramref name="x"/> if not null; otherwise returns <paramref name="replacement"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <param name="replacement"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X ifNullValue<X>(X? x, X replacement)
        where X : struct
            => x == null ? replacement : (X)x;

    /// <summary>
    /// Evaluates a function if a predicate is satisfied; otherwise, returns None
    /// </summary>
    /// <typeparam name="X">The type of value to evaluate</typeparam>
    /// <typeparam name="Y">The evaluation type</typeparam>
    /// <param name="x">The point of evaluation</param>
    /// <param name="predicate">A precondition for evaulation to proceed</param>
    /// <param name="f">The evaluation function</param>
    /// <returns></returns>
    public static Option<Y> guard<X, Y>(X x, Func<X, bool> predicate, Func<X, Option<Y>> f)
        => predicate(x) ? f(x) : none<Y>(GuardUnsatisfied());

    /// <summary>
    /// Evaluates a function within a try block and returns the value of the computation if 
    /// successful; otherwise, returns None together with the reported exception
    /// </summary>
    /// <typeparam name="X">The input type</typeparam>
    /// <typeparam name="Y">The output type</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The function to evaluate</param>
    /// <returns></returns>
    public static Option<Y> Try<X, Y>(X x, Func<X, Y> f)
    {
        try
        {
            return f(x);
        }
        catch (Exception e)
        {
            return none<Y>(e);
        }
    }

    /// <summary>
    /// Evaluates a function within a try block and returns the value of the computation if 
    /// successful; otherwise, returns None together with the reported exception
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="F"></param>
    /// <returns></returns>
    public static Option<T> Try<T>(Func<Option<T>> F)
    {
        try
        {
            return F();
        }
        catch (Exception e)
        {
            return none<T>(e);
        }
    }

    /// <summary>
    /// Evaulates a function within a try + using block
    /// </summary>
    /// <typeparam name="X">The input value type</typeparam>
    /// <typeparam name="Y">The function output type</typeparam>
    /// <param name="resource"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Option<Y> Use<X, Y>(X resource, Func<X, Y> f)
        where X : IDisposable
    {
        try
        {
            using (resource)
            {
                return f(resource);
            }
        }
        catch (Exception e)
        {
            return none<Y>(e);
        }
    }


    /// <summary>
    /// Evaluates a predicate over an input value and executes one of two supplied functions
    /// depending on whether the predicate evaluates to true or false
    /// </summary>
    /// <typeparam name="T">The input type</typeparam>
    /// <typeparam name="S">The output type</typeparam>
    /// <param name="input">The input value</param>
    /// <param name="predicate">The predicate that will accept the input value</param>
    /// <param name="ifTrue">The function to apply if the predicate evaluates to true</param>
    /// <param name="ifFalse">The function to apply if the predicate evaluates to false</param>
    /// <returns></returns>
    public static S eval<T, S>(T input, Func<T, bool> predicate, Func<T, S> ifTrue, Func<T, S> ifFalse)
        => predicate(input) ? ifTrue(input) : ifFalse(input);

}

