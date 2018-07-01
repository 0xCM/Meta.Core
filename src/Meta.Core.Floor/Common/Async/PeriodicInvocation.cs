//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Threading;

    using static metacore;

    /// <summary>
    /// Periodically (and serially) invokes an operation until disposed
    /// </summary>
    /// <remarks>
    /// The key feature of the realizations of this wrapper, is to execute a method
    /// in a periodic fashion while preventing it from being executed if the previous invocation.
    /// has not completed. The timer event will simply be ignored if the prior invocation
    /// has not completed. There is no explicit means of cancellation as it is canceled
    /// upon disposal
    /// </remarks>
    public abstract class PeriodicInvocation : IDisposable
    {
        readonly object alock = new object();
        Timer timer;
        EventWaitHandle finished;
        readonly int frequency;

        /// <summary>
        /// Initializes a new <see cref="PeriodicInvocation"/> instance
        /// </summary>
        /// <param name="frequency"></param>
        protected PeriodicInvocation(int frequency)
        {
            this.frequency = frequency;
        }

        /// <summary>
        /// Cancels the timer and waits for any currently executing action to complete
        /// </summary>
        public void Dispose()
        {
            using (finished = new ManualResetEvent(false))
            {
                timer.Change(0, 1);
                finished.WaitOne();
                timer.Dispose();
            }
        }

        private void TrySignalFinish()
        {
            if
            (
                    not(finished is null)
                && not(finished.SafeWaitHandle.IsClosed)
                && not(finished.SafeWaitHandle.IsInvalid)
            )
                finished.Set();
        }

        protected Action Guard(Action<object> action, Func<object> context)
        {
            return () =>
            {
                if (Monitor.TryEnter(alock, frequency))
                {
                    try
                    {
                        action(context());
                        TrySignalFinish();
                    }
                    finally
                    {
                        Monitor.Exit(alock);
                    }
                }
            };
        }

        /// <summary>
        /// Prevents execution if the previous call hasn't finished
        /// </summary>
        /// <param name="action">The action to guard</param>
        protected Action Guard(Action action)
        {

            return () =>
            {
                if (Monitor.TryEnter(alock, frequency))
                {
                    try
                    {
                        action();

                        TrySignalFinish();
                    }
                    finally
                    {
                        Monitor.Exit(alock);
                    }
                }
            };
        }

        /// <summary>
        /// Begins execution of the action
        /// </summary>
        /// <param name="action">The action to be periodically executed</param>
        protected void Start(Action action)
            => this.timer = new Timer(new TimerCallback(x => action()), null, 0, frequency);

    }

}