//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;


using static minicore;

/// <summary>
/// Encapsulates a function, the value returned from its invocation and the time
/// elapsed during the invocation
/// </summary>
/// <typeparam name="TResult">The function result type</typeparam>
public sealed class TimedFunction<TResult>
{
    public TimedFunction(Delegate Function, TResult Result, TimeSpan Duration, string Title = null)
    {
        this.Function = Function;
        this.Result = Result;
        this.Duration = Duration;
        this.Title = Title ?? String.Empty;
    }

    /// <summary>
    /// The function measures with respect to execution time
    /// </summary>
    public Delegate Function { get; }

    /// <summary>
    /// The function result
    /// </summary>
    public TResult Result { get; }

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

