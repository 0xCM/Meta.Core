//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using static minicore;


    /// <summary>
    /// Wraps a stream that will compute at most once
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    public readonly struct Deferred<T> : IEnumerable<T>
    {
        public static implicit operator ReadOnlyList<T>(Deferred<T> defer)
            => defer.Evaluate();

        Lazy<ReadOnlyList<T>> Values { get; }

        public Deferred(IEnumerable<T> Values)
            => this.Values = lazy(() => Values.ToReadOnlyList());

        public IEnumerator<T> GetEnumerator()
            => Values.Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool Evaluated
            => Values.IsValueCreated;

        public ReadOnlyList<T> Evaluate()
            => Values.Value;
    }


}