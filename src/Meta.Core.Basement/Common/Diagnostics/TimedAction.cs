//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;

using static minicore;

/// <summary>
/// Encapsulates an action and the time required to execute it
/// </summary>
public sealed class TimedAction
{
    public static TimedFunction<TResult> Measure<TResult>(Func<TResult> f, string Title = null)
    {        
        var sw = Stopwatch.StartNew();
        var result = f();
        return new TimedFunction<TResult>(f, result, sw.Elapsed, Title ?? String.Empty);
    }

    public static TimedAction Measure(Action f, string Title = null)
    {
        var sw = Stopwatch.StartNew();
        f();
        return new TimedAction(f, sw.Elapsed, Title ?? String.Empty);
    }

    public TimedAction(Delegate Action, TimeSpan Duration, string Title = null)
    {
        this.Action = Action;
        this.Duration = Duration;
        this.Title = Title ?? String.Empty;
    }

    /// <summary>
    /// The invoked action
    /// </summary>
    public Delegate Action { get; }

    /// <summary>
    /// The time required for execution
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// An optional title used when rendering descriptive text
    /// </summary>
    public string Title { get; }

    public override string ToString()
        => (isBlank(Title) 
            ? String.Empty 
            : $"{Title}:") + $"{(int)Duration.TotalMilliseconds} ms";
}
