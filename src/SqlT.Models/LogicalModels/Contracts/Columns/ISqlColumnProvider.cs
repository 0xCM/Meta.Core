//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    public interface ISqlColumnProvider : sxc.column_name_provider
    {
        IReadOnlyList<ISqlColumn> Columns { get; }
    }

}
