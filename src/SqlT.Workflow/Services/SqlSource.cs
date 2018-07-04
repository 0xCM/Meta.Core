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

    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Services;

    using N = SystemNode;
    using static metacore;



    public sealed class SqlSource<Src> : SqlDataJunction<Src>, ISqlSource<Src>  
       where Src : class, ISqlTabularProxy, new()
    {
        public SqlSource(ISqlProxyBroker Broker)
            : base(PXM.TabularName<Src>(), Broker)
        {
            
        }


        IEnumerable<Src> ISqlSource<Src>.Pull()
            => Broker.Stream<Src>();
    }




}