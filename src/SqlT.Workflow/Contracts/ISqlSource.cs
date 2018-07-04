//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Services;

    using N = SystemNode;
    using static metacore;

    public interface ISqlSource<out Src> : ISqlDataJunction
        where Src : class, ISqlTabularProxy, new()

    {
        IEnumerable<Src> Pull();

    }


}