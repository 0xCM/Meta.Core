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
            => new MutableList<T>(10);

        public static MutableList<T> Create<T>(int Capacity)
            => new MutableList<T>(Capacity);

        public static MutableList<T> FromItems<T>(IEnumerable<T> items)
            => new MutableList<T>(items);
    }
}