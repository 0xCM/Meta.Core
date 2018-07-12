//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public class Traversable : ClassModule<Traversable, ITraversable>
    {
        public Traversable()
            : base(typeof(Traversable<,,,>))
        { }           
    }
}