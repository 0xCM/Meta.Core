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
    using Meta.Core.Workflow;

    public sealed class SqlTarget<Dst> : SqlDataJunction<Dst>, ISqlTarget<Dst>
        where Dst : class, ISqlTabularProxy, new()
    {
        public SqlTarget(ISqlProxyBroker Broker)
            : base(PXM.TabularName<Dst>(), Broker)
        {
        
        }

        Option<int> ISqlTarget<Dst>.Push<Src>(ISqlSource<Src> Source, Func<Src, Dst> F)
            => Broker.Save(Source.Pull().Select(F), new SqlSaveOptions());

        Option<int> ISqlTarget<Dst>.Push(ISqlSource<Dst> Source)
            => Broker.Save(Source.Pull(), new SqlSaveOptions());
    }






}