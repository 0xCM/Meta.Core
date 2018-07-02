//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public abstract class ModuleExport
    {

        protected ModuleExport(Type ModuleType)
        {
            this.ModuleType = ModuleType;
        }

        public Type ModuleType { get; }
    }

}