﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    public interface ISqlScriptIndex
    {
        IEnumerable<ISqlElementSpecScript> All { get; }

        ISqlElementSpecScript FindByName(IName name);
    }
}
