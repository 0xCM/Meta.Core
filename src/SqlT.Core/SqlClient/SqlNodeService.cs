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


    public abstract class SqlNodeService<T, I> : NodeService<T, I>
       where T : SqlNodeService<T, I>
       where I : ISqlNodeService
    {

        protected SqlNodeService(ISqlContext C)
            : base(C)
        {
            this.Broker = new SqlClientBroker(C.SqlConnector, OnSqlNotification);
        }

        protected ISqlClientBroker Broker { get; }

        protected new ISqlContext C
            => base.C as ISqlContext;


        protected virtual void OnSqlNotification(SqlNotification message)
            => C.Notify(message.ToApplicationMessage());

    }


}