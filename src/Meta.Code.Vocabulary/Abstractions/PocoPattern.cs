//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class PocoPattern<P> : Pattern<P>
        where P : PocoPattern<P>, new()
    {

        protected PocoPattern()
        {
        }

        public string Namespace { get; }
            = string.Empty;

        public IReadOnlyList<PocoSpec> Pocos { get; }
            = new List<PocoSpec>();
    }

}