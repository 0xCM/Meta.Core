//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Astonishingly, responsible for generating a sequence of (numeric) values
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    class SequenceGenerator<T> : ISequenceGenerator<T>
    {
        readonly int DefaultBlockSize = 100;
        readonly ISequenceProvider SourceProvider;
        Queue<T> cache = new Queue<T>();
        object lockobj = new object();

        void EnqueNew(int blockSize)
            => cache.Enqueue(SourceProvider.NextRange<T>(blockSize));

        public SequenceGenerator(ISequenceProvider sourceProvider, int defaultBlockSize = 100)
        {
            DefaultBlockSize = defaultBlockSize;
            SourceProvider = sourceProvider;
            EnqueNew(DefaultBlockSize);
        }

        public IEnumerable<T> NextRange(int count)
        {
            lock (lockobj)
            {
                if (cache.Count < count)
                {
                    EnqueNew(Math.Max(count, DefaultBlockSize));
                }
                return cache.Dequeue(count).ToList();
            }
        }

        public T NextValue()
        {
            lock (lockobj)
            {
                if (cache.Count == 0)
                    EnqueNew(DefaultBlockSize);
                return cache.Dequeue();
            }
        }

        IEnumerable<object> ISequenceGenerator.NextRange(int count)
            => NextRange(count).Cast<object>();

        object ISequenceGenerator.NextValue()
            => NextValue();
    }
}
