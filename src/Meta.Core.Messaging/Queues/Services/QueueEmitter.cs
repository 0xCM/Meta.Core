//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;

    using Meta.Core.Messaging;

    using static metacore;


    public class QueueEmitter<M> : IMessageEmitter<M>
        where M: new()
    {

        AutoResetEvent ThreadEvent { get; }
            = new AutoResetEvent(false);

        bool Finished { get; set; }
            = false;

        ConcurrentQueue<M> MemoryQueue { get; }
            = new ConcurrentQueue<M>();


        CorrelationToken SubscriptionId { get; }

        void OnMessage(M message)
        {
            MemoryQueue.Enqueue(message);
            ThreadEvent.Set();
        }

        void OnFinshed()
        {
            Finished = true;
        }

        public QueueEmitter(IQueueReceiver Receiver)
        {
            SubscriptionId = Receiver.Subscribe(QueueSubscriber.Define<M>(OnMessage, OnFinshed));
            
        }

        public IEnumerable<M> Emit(Func<bool> Cancel = null)
        {
            var cancel = Cancel ?? new Func<bool>(() => false);
            while (!Finished && !Cancel())
            {
                ThreadEvent.WaitOne(1000);
                while(MemoryQueue.TryDequeue(out M message))
                    yield return message;

            }

        }
    }
}