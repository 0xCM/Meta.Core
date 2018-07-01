//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;
    public static class PartitionedWorkIndex
    {
        public static PartitionedWorkIndex<W> Create<W>(IReadOnlyList<W> items)
            where W : IPartitionedWork => new PartitionedWorkIndex<W>(items);
    }


    public class PartitionedWorkIndex<W> where W : IPartitionedWork
    {
        public PartitionedWorkIndex(IReadOnlyList<W> items)
        {
            iter(items, item => Enqueue(item.PartitionName, item));
        }

        static IEnumerable<T> Dequeue<T>(int Max, ConcurrentQueue<T> Q)
        {
            for (int i = 0; i < Max; i++)
            {
                var item = default(T);
                if (Q.TryDequeue(out item))
                    yield return item;
                else
                    break;
            }
        }

        readonly ConcurrentDictionary<string, ConcurrentQueue<W>> Queues
            = new ConcurrentDictionary<string, ConcurrentQueue<W>>();

        void Enqueue(string Partition, W Work)
            => Queues.GetOrAdd(Partition, _ => new ConcurrentQueue<W>()).Enqueue(Work);


        public WorkSupplier<W> CreateSupplier(string Partition)
        {
            var Q = default(ConcurrentQueue<W>);
            if (Queues.TryGetValue(Partition, out Q))
                return new WorkSupplier<W>(Partition, max => Dequeue(max, Q));
            else
                return new WorkSupplier<W>(Partition, max => new W[] { });
        }

        public IReadOnlyList<WorkSupplier<W>> CreateSuppliers()
            => map(Queues.Keys, partition => CreateSupplier(partition));

    }
}