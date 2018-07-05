//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT;
    using SqlT.Core;
    using static metacore;


    public abstract class SqlNodeService<T, I, A> : SqlNodeService<T, I>
       where T : SqlNodeService<T, I, A>
       where A : class, ISqlProxyAssembly, new()
    {

        protected SqlNodeService(ISqlContext C)
            : base(C)
        {
            this.Broker = new A().CreateBroker(C.SqlConnector);
        }
        protected new ISqlClientBroker Broker { get; }

    }
}