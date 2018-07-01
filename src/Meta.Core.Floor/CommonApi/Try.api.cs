//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class metacore
{
    /// <summary>
    /// Evaluates a function within a try block and returns the value of the computation if 
    /// successful; otherwise, returns None together with the reported exceptions
    /// </summary>
    /// <typeparam name="T">The result type</typeparam>
    /// <param name="f">The function to evaluate</param>
    /// <returns></returns>
    public static Option<T> Try<T>(Func<T> f)
    {
        try
        {
            return f();
        }
        catch (Exception e)
        {
            return none<T>(error(e));
        }
    }

    public static Func<X,Option<Y>> Try<X,Y>(Func<X,Y> f)
        => x => Try(() => f(x));

    /// <summary>
    /// Executes an action a try block and returns the unit value, if successful;
    /// oterwise returns a descriptive None
    /// </summary>
    /// <param name="f">The function to evaluate</param>
    /// <returns></returns>
    public static Option<Unit> Try(Action f)
    {
        try
        {
            f();
            return Unit.Value;
        }
        catch (Exception e)
        {
            return none<Unit>(e);
        }
    }
}