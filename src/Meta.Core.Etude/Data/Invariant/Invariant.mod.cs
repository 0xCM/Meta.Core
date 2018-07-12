//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    public class Invariant : ClassModule<Invariant, IInvariant>
    {
        public Invariant()
            : base(typeof(Invariant<,,,>))
        { }        
    }
}