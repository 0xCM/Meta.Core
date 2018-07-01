//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MutableList
    {
        public static MutableList<T> Create<T>()
            => MutableList<T>.Empty;

        public static MutableList<T> Create<T>(int Capacity)
            => new MutableList<T>(Capacity);

        public static MutableList<T> Create<T>(T item, params T[] more)
            => new MutableList<T>(new []{item}.Concat(more));

        public static MutableList<T> FromItems<T>(IEnumerable<T> items)
            => new MutableList<T>(items);
    }
}