//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Invokes a function periodically, passing the result of the previous call 
    /// as an argument in the next call
    /// </summary>
    /// <typeparam name="T">The result type</typeparam>
    public class PeriodicFunctionChain<T> : PeriodicInvocation
    {
        T result;

        /// <summary>
        /// Initializes a new <see cref="PeriodicFunctionChain{T}"/> instance
        /// </summary>
        /// <param name="function"></param>
        /// <param name="frequency"></param>
        /// <param name="input"></param>
        public PeriodicFunctionChain(Func<T, T> function, int frequency, T input)
            : base(frequency)
        {
            result = input;
            Start(Guard(() =>
            {
                result = function(result);
            }));
        }

        public PeriodicFunctionChain(Func<object, T, T> function, Func<object> context, int frequency, T input)
            : base(frequency)
        {
            result = input;
            Start(Guard(() =>
            {
                result = function(context(), result);
            }));

        }

        /// <summary>
        /// The result at a given instant
        /// </summary>
        public T Result
            => result;
    }

    public class PeriodicFunctionChain<T, C> : PeriodicFunctionChain<T>
    {
        public PeriodicFunctionChain(Func<C, T, T> function, Func<C> context, int frequency, T input)
            : base((c, t) => function((C)c, (T)t), () => context(), frequency, input)
        {

        }

    }

}