//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    using static metacore;

    public sealed class MessagePump : IMessagePump
    {


        readonly Task RunLoopTask;
        readonly ConcurrentQueue<object> MemoryQueue;
        readonly ConcurrentBag<IMessageReceiver> Targets;
        readonly ConcurrentBag<IMessageEmitter> Sources;

        bool IsStopping;
        bool HasStopped;
        int BatchSize = 10;
        int Frequency = 1000;

        void Enqueue(IEnumerable<object> messages)
        {
            foreach (var message in messages)
                MemoryQueue.Enqueue(message);
        }

        IEnumerable<object> Dequeue(int maxCount)
        {
            for (var i = 0; i < maxCount; i++)
            {
                if (MemoryQueue.TryDequeue(out object message))
                    yield return message;
                else
                    break;
            }
        }

        MessagePump()
        {
            MemoryQueue = new ConcurrentQueue<object>();
            Targets = new ConcurrentBag<IMessageReceiver>();
            Sources = new ConcurrentBag<IMessageEmitter>();
            RunLoopTask = new Task(PumpIt);
            RunLoopTask.ContinueWith(_ => HasStopped = true);
        }

        void DequeueBatch()
        {
            var messages = Dequeue(BatchSize);
            Task.Factory.StartNew(() =>
                Targets.AsParallel().ForAll(target =>
                    iter(messages, m => target.Receive(m))));

        }

        void EnqueueBatch()
        {
            Enqueue(from source in Sources
                    from message in source.Emit().Take(BatchSize)
                    select message);

        }

        bool KeepPumping
            => !IsStopping && !HasStopped;

        void Pause()
        {
            if (KeepPumping)
                Task.Delay(Frequency).Wait();
        }

        void PumpBatch()
        {
            EnqueueBatch();
            DequeueBatch();
            Pause();

        }


        void PumpIt()
        {
            while (KeepPumping)
                PumpBatch();
        }

        /// <summary>
        /// Turns on the pump but does not begin pumping, which is the purpose of the <see cref="Pump"/> method
        /// </summary>
        /// <returns></returns>
        public static MessagePump TurnOn()
            => new MessagePump();

        /// <summary>
        /// Submits pump start request
        /// </summary>
        public void Pump()
           => RunLoopTask.Start();

        /// <summary>
        /// Submit pump shutdown request
        /// </summary>
        public void TurnOff()
            => IsStopping = true;

        /// <summary>
        /// Adds a message emitter
        /// </summary>
        /// <param name="source"></param>
        public void EnlistSource(IMessageEmitter source)
            => Sources.Add(source);

        /// <summary>
        /// Adds a message receiver
        /// </summary>
        /// <param name="target"></param>
        public void EnlistTarget(IMessageReceiver target)
            => Targets.Add(target);


        /// <summary>
        /// True if the pump is in any non-end state
        /// </summary>
        public bool On
            => !Off;

        /// <summary>
        /// True if the pump has been turned on but has not yet started
        /// flowing messages, false otherwise
        /// </summary>
        public bool Priming
            => RunLoopTask.Pending();

        /// <summary>
        /// True if the pump is flowing messages, false otherwise
        /// </summary>
        public bool Pumping
            => RunLoopTask.Running();

        /// <summary>
        /// True if the pump has reached an end state
        /// </summary>
        public bool Off
            => RunLoopTask.Finished();

        /// <summary>
        /// True if stop has been requested but not fulfilled
        /// </summary>
        public bool Stopping
            => IsStopping;


    }

    public sealed class MessagePump<I, O> : IMessagePump<I, O>
        where I : new()
        where O : new()
    {
        public IEnumerable<O> Emit()
        {
            return new O[] { };
        }

        public void EnlistSource(IMessageEmitter<I> source)
        {

        }

        public void EnlistTarget(IMessageReceiver<O> target)
        {

        }

        public void Receive(IEnumerable<I> messages)
        {

        }
    }


}