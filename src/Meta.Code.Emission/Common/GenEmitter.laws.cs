//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Collections.Generic;

    public interface IGenEmitter
    {
        IEnumerable<string> Emit(GenContext context, GenSpec spec);
        bool CanEmit(Type specType);
    }
}