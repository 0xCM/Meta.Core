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

    using static metacore;

    public class Async<X>
    {
        readonly Func<X> worker;
        readonly Action<X> receiver;

        public Async(Func<X> worker, Action<X> receiver, bool start)
        {
            this.worker = worker;
            this.receiver = receiver;
            if (start)
                Start();
        }

        public void Start()
            => task(() => receiver(worker()));
    }

    public class Async<X1, X2>
    {
        readonly Func<X1, X2> worker;
        readonly Action<X2> receiver;

        public Async(Func<X1, X2> worker, Action<X2> receiver)
        {
            this.worker = worker;
            this.receiver = receiver;
        }

        public Async(Func<X1, X2> worker, Action<X2> receiver, X1 x1)
            : this(worker, receiver)
                => task(() => receiver(worker(x1)));

        public Task Start(X1 x1)
            => task(() => receiver(worker(x1)));


    }


    public readonly struct Async<X1, X2, X3>
    {
        public Async(Func<X1, X2, X3> worker, X1 x0, X2 x1, Action<X3> receiver)        
            => task(() => receiver(worker(x0, x1)));        

        public Async(Func<X1, X2> worker1, Func<X2, X3> worker2, X1 x0, Action<X3> receiver)
            => task(() => receiver(worker2(worker1(x0))));
    }

}