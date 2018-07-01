//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Meta.Core;
using static metacore;
using static Outcome;

/// <summary>
/// Represents the outcome of executing an operation
/// </summary>
/// <typeparam name="P">Tye outcome payload</typeparam>
public struct Outcome<P> : IOutcome<P>
{
    public static bool operator true(Outcome<P> x) 
        => x.Succeeded;

    public static bool operator false(Outcome<P> x)
        => not(x.Succeeded);

    public static implicit operator Outcome<P>(P x) 
        => new Outcome<P>(x);

    public static implicit operator P(Outcome<P> x) 
        => x.Payload;

    public static implicit operator Outcome<bool>(Outcome<P> x) 
        => x.Succeeded 
        ? success(true) 
        : failure<bool>(x.Description);

    bool Terminal { get; }

    P _Payload { get; }

    public bool Succeeded { get; }

    public IApplicationMessage Description { get; }

    public P Payload 
        => _Payload;

    public Outcome(P Payload)
    {
        this.Succeeded = true;

        if (Payload == null)
            throw new ArgumentNullException(nameof(Payload));
        this._Payload = Payload;

        this.Description = ApplicationMessage.Empty;
        this.Terminal = not(Succeeded);
    }

    public Outcome(bool Succeeded, IApplicationMessage Description)
    {
        this.Succeeded = false;
        if (Description == null)
            throw new ArgumentNullException(nameof(Description));
        this.Description = Description;
        this._Payload = default(P);
        this.Terminal = not(Succeeded);
    }

    public Outcome(bool Succeeded, P Payload, IApplicationMessage Description)
    {
        this.Succeeded = Succeeded;
        this._Payload = Payload;
        this.Description = Description;
        this.Terminal = not(Succeeded);
    }

    Outcome(bool Succeeded, P Payload, IApplicationMessage Description, bool Terminal)
    {
        this.Succeeded = Succeeded;
        this._Payload = Payload;
        this.Description = Description;
        this.Terminal = Terminal;
    }

    internal Outcome<P> Terminate()
        => new Outcome<P>(Succeeded, _Payload, Description, true);

    internal bool CanTransition()
        => not(Failed) && not(Terminal);


    public bool Failed 
        => not(Succeeded);

    P IOutcome<P>.Payload 
        => Payload;

    bool IOutcome.Succeeded 
        => Succeeded;

    object IOutcome.Payload 
        => Payload;

    IEnumerable<IApplicationMessage> IOutcome.Messages
        => array(Description);

    public P Require()
    {
        if (Failed)
            throw new ArgumentException("The payload does not exist");
        return Payload;
    }

    public Outcome<P> WhenFailed(Action<IApplicationMessage> f)
    {
        if (Failed)
                f(Description);

        return this;
    }

    public Outcome<P> WhenSucceeded(Action<P> f)
    {
        if (Succeeded)
            f(_Payload);

        return this;
    }

    public void Branch(Action<P> success, Action<IApplicationMessage> failure)
    {
        if (Failed)
            failure(Description);
        else
            success(_Payload);
    }

    public override string ToString() 
        => Succeeded ? Payload.ToString() : Description.ToString();
}

public static class Outcome
{
    /// <summary>
    /// Creates a failed outcome with a potential reason
    /// </summary>
    /// <typeparam name="P">The type of payload if it had existed</typeparam>
    /// <param name="notification"></param>
    /// <returns></returns>
    public static Outcome<P> failure<P>(IApplicationMessage notification)
        => Outcome.Fail<P>(notification);

    /// <summary>
    /// Creates a successful outcome using a supplied payload
    /// </summary>
    /// <typeparam name="P">The type of payload if it had existed</typeparam>
    /// <returns></returns>
    public static Outcome<P> success<P>(P payload)
        => Outcome.Lift(payload);

    /// <summary>
    /// Creates a successful outcome using a supplied payload and message
    /// </summary>
    /// <returns></returns>
    public static Outcome<P> success<P>(P payload, IApplicationMessage reason)
        => Outcome.Success(payload, reason);


    /// <summary>
    /// Invokes the supplied function and populates a <see cref="Outcome{P}"/> with the result
    /// </summary>
    /// <typeparam name="P">The function return type</typeparam>
    /// <param name="f">The function to invoke</param>
    /// <param name="h0">The handler to invoke to produce a notification when an error occurs</param>
    /// <returns></returns>
    public static Outcome<P> Try<P>(Func<P> f, Func<Exception, IApplicationMessage> h0 = null)
    {
        var payload = default(P);

        h0 = (h0 == null ? e => (ApplicationMessage)ApplicationMessage.Error(e) :  h0);

        var error = default(Exception);
        try
        {
            payload = f();
        }
        catch (Exception e)
        {
            error = e;
        }

        return isNull(error) ? new Outcome<P>(payload)
                             : new Outcome<P>(false, h0(error));
    }

    public static Outcome<P> Try<P, E1>(Func<P> f, Func<E1, IApplicationMessage> h1, Func<Exception, IApplicationMessage> h0 = null)
        where E1 : Exception
    {
        var payload = default(P);
        var e0 = default(Exception);
        var e1 = default(E1);
        var n = ApplicationMessage.Empty;

        h0 = (h0 == null ? e => (ApplicationMessage)ApplicationMessage.Error(e) : h0);

        try
        {
            payload = f();
        }
        catch (Exception e)
        {
            e0 = e;
            e1 = e0 as E1;
            if (isNotNull(e1))
                n = h1(cast<E1>(e1));
            else
                n = h0(e0);
        }

        return isNull(e0) ? new Outcome<P>(payload)
                          : new Outcome<P>(false, n);
    }

    /// <summary>
    /// Invokes the supplied action and returns an outcome value as appropriate
    /// </summary>
    /// <param name="f">The function to invoke</param>
    /// <param name="h0">The handler to invoke to produce a notification when an error occurs</param>
    /// <returns></returns>
    public static Outcome<bool> Try(Action f, Func<Exception, IApplicationMessage> h0 = null)
    {
        var error = default(Exception);

        var handler = h0;
        if (handler == null)
            handler = e => (ApplicationMessage) ApplicationMessage.Error(e);

        try
        {
            f();
        }
        catch (Exception e)
        {
            error = e;
        }
        return isNull(error) 
            ? new Outcome<bool>(true)
            : new Outcome<bool>(false, handler(error));
    }

    private static Outcome<P> Create<P>(P payload, bool succeeded, IApplicationMessage description) 
        => new Outcome<P>(succeeded, payload, description);

    public static Outcome<P> Lift<P>(Func<P> f)
        => f();

    public static Outcome<P> Lift<P>(P payload)
        => payload;

    static IApplicationMessage coalesce<T>(params IApplicationMessage[] x)
        => x.FirstOrDefault(z => !z.IsEmpty) ?? ApplicationMessage.Empty;

    public static Outcome<P> WithReaon<P>(this Outcome<P> x, IApplicationMessage reason)
        => new Outcome<P>(x.Succeeded, x.Payload, reason.IsEmpty ? x.Description : reason);

    public static Outcome<P> Success<P>(P payload, IApplicationMessage reason)
        => new Outcome<P>(true, payload, reason);

    public static Outcome<P> Fail<P>(IApplicationMessage reason) 
        => new Outcome<P>(false, reason);

    [DebuggerStepThrough]
    public static Outcome<P> Bind<X, P>(this Outcome<X> x, Func<X, Outcome<P>> f) 
        => x.Succeeded ? f(x.Payload).WithReaon(x.Description) : Fail<P>(x.Description);

    [DebuggerStepThrough]
    public static Outcome<P> SelectMany<X, Y, P>(
        this Outcome<X> x,
        Func<X, Outcome<Y>> select,
        Func<X, Y, P> project)
    {
        if (x)
        {
            var y = select(x.Payload);
            var z = y.Bind(yVal => Success(project(x.Payload, yVal), y.Description));
            return z;
        }
        else
        {
            return Fail<P>(x.Description);
        }
    }

    [DebuggerStepThrough]
    public static Outcome<P> Select<X, P>(this Outcome<X> x, Func<X, P> selector)
    {
        if (x.Succeeded)
            return selector(x.Payload);
        else
            return Fail<P>(x.Description);
    }

    public static Outcome<P> Select<X, P>(this Outcome<X> x, Func<X, Outcome<P>> f) =>
        x.Bind(f);

    public static Outcome<P> Where<P>(this Outcome<P> x, Func<P, bool> predicate) =>
        x.Succeeded && predicate(x.Payload) ? x : x.Terminate();

    public static Outcome<P1> Success<P0, P1>(this Outcome<P0> outcome, Func<P0, Outcome<P1>> success)
    {
        if (outcome)
            return success(outcome.Payload);
        else
            return new Outcome<P1>(false, outcome.Description);
    }

    public static Outcome<IReadOnlyList<X>> Where<X>(this Outcome<IReadOnlyList<X>> x, Func<X, bool> predicate)
    {
        var items = MutableList.Create<X>();
        if (x)
        {
            foreach (var item in x.Payload)
                if (predicate(item))
                    items.Add(item);
            return items;
        }
        else
            return x;
    }

    public static IReadOnlyList<P> Items<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Succeeded ? x.Payload : new P[] { };

    public static P First<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Items().First();

    public static P FirstOrDefault<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Items().FirstOrDefault();

    public static P Single<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Items().Single();

    public static P SingleOrDefault<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Items().SingleOrDefault();

    public static bool Any<P>(this Outcome<IReadOnlyList<P>> x)
        => x.Items().Any();

    public static bool Any<P>(this Outcome<IReadOnlyList<P>> x, Func<P, bool> predicate)
        => x.Items().Any(predicate);
}

