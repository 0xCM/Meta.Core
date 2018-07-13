//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    /// <summary>
    /// Represents a source-code level module (as opposed to a .net module, an assembly, etc.)
    /// </summary>
    public interface ICodeModule
    {
        Option<TypeConstruction> ConstructType(params Type[] args);

    }


}