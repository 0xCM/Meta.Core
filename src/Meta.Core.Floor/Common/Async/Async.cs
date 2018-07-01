//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class Async
    {
        public static Async Start(Action worker, Action observer)
            => new Async(worker, observer);

        public static Async<T0, T1> Create<T0, T1>(Func<T0, T1> worker, Action<T1> observer)
            => new Async<T0, T1>(worker, observer);

        public static Async<T0, T1> Start<T0, T1>(Func<T0, T1> worker, Action<T1> observer, T0 x0)
            => new Async<T0, T1>(worker, observer, x0);

        public static Async<T> Start<T>(Func<T> worker, Action<T> observer)
            => new Async<T>(worker, observer, true);

        public Async(Action worker, Action receiver)
        {
            this.Worker = worker;
            this.Receiver = receiver;
            this.Task = Task.Factory.StartNew(() =>
            {
                Worker();
                Receiver();
            });
        }

        public Action Worker { get; }

        public Action Receiver { get; }

        public Task Task { get; }
    }
}