//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Meta.Core.Workflow;
using SqlT.Core;
using SqlT.Models;
using SqlT.Services;
using SqlT.Workflow;

using static metacore;

public static partial class sqlwf
{


    public static SqlProjection<TSrc, TDst> wfProject<TSrc, TDst>(Func<TSrc, TDst> F)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()
            => F.DefineSqlProjection();

    public static SqlProjection<TSrc, TDst> wfProject<TSrc, TDst>(Func<IEnumerable<TSrc>, IEnumerable<TDst>> G)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()
            => G.DefineSqlProjection();


}

