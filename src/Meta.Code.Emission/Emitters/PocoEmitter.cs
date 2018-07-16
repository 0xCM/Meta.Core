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


    sealed class PocoPropertyEmitter : GenEmitter<PocoPropertyEmitter, PocoPropertySpec>
    {
        public override IEnumerable<string> Emit(GenContext context, PocoPropertySpec spec)
        {
            yield return $"{spec.PropertyType} {spec.TargetName} " + "{get;set;}";
        }
    }

}