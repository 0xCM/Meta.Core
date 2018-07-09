//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using Meta.Models;

    using SqlT.Core;
    using SqlT.Models;

    /// <summary>
    /// Defines contract for SQL model script generation
    /// </summary>
    public interface ISqlGenerator
    {
        SqlModelScript GenerateScript(IModel syntax);

    }
}
