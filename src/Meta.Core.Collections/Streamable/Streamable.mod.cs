//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    public class Streamable 
    {
        public static Streamable<X> make<X>(Streamer<X> streamer, Cardinality cardinality)
            => new Streamable<X>(streamer, cardinality);
    }

}