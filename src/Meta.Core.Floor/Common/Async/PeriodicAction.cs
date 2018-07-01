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
    /// Invokes an action periodically until disposed
    /// </summary>
    public class PeriodicAction : PeriodicInvocation
    {
        /// <summary>
        /// Initializes a new <see cref="PeriodicAction"/> instance
        /// </summary>
        /// <param name="action">The action that will be invoked</param>
        /// <param name="frequency">The frequency (in milliseconds) with which invocation will occur</param>
        public PeriodicAction(Action action, int frequency)
            : base(frequency)
        {
            Start(Guard(action));
        }

        /// <summary>
        /// Initializes a new <see cref="PeriodicAction"/> instance
        /// </summary>
        /// <param name="action">The action that will be invoked</param>
        /// <param name="context">The function that will supply the context for the action</param>
        /// <param name="frequency"></param>
        public PeriodicAction(Action<object> action, Func<object> context, int frequency)
            : base(frequency)
        {
            Start(Guard(action, context));
        }
    }

    /// <summary>
    /// Invokes an action periodically until disposed
    /// </summary>
    public class PeriodicAction<T> : PeriodicAction
    {
        public PeriodicAction(Action<T> action, Func<T> context, int frequency)
            : base((object ctx) => action((T)ctx), () => context(), frequency)
        {

        }
    }


}