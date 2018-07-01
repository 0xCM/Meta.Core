//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

partial class metacore
{
    /// <summary>
    /// Thread-safe increment mutator
    /// </summary>
    /// <param name="i">The reference to increment</param>
    public static long increment(ref long i)
        => Interlocked.Increment(ref i);

    /// <summary>
    /// Thread-safe increment mutator
    /// </summary>
    /// <param name="i">The reference to increment</param>
    public static int increment(ref int i)
        => Interlocked.Increment(ref i);

    /// <summary>
    /// Thread-safe increment mutator
    /// </summary>
    /// <param name="i">The reference to increment</param>
    public static long decrement(ref long i)
        => Interlocked.Decrement(ref i);

    /// <summary>
    /// Thread-safe increment mutator
    /// </summary>
    /// <param name="i">The reference to increment</param>
    public static int decrement(ref int i)
        => Interlocked.Decrement(ref i);

    /// <summary>
    /// Starts a new task that invokes a supplied action
    /// </summary>
    /// <param name="worker">The action invoked by the task</param>
    /// <returns></returns>
    public static Task task(Action worker)
        => Task.Factory.StartNew(worker);

    /// <summary>
    /// Starts a new task that computes a value returned by a supplied funtion
    /// </summary>
    /// <param name="worker">The computation function</param>
    /// <returns></returns>
    public static Task<T> task<T>(Func<T> worker)
        => Task.Factory.StartNew(worker);

    /// <summary>
    /// Waits indefinitely for all specified tasks to complete
    /// </summary>
    /// <param name="tasks"></param>
    public static void wait(params Task[] tasks)
        => Task.WaitAll(tasks);

    /// <summary>
    /// Waits until either all tasks complete or until a timeout period elapses;
    /// Returns true if all tasks completed prior to timeout and false otherwise
    /// </summary>
    /// <param name="timeout"></param>
    /// <param name="tasks"></param>
    public static bool wait(int timeout, params Task[] tasks)
        => Task.WaitAll(tasks,timeout);


}