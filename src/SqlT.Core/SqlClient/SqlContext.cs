//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    using System.Collections.Generic;
    using System.Text;

    using N = SystemNode;

    using Meta.Core;

    public class SqlContext : NodeContext, ISqlContext
    {
        public SqlContext(INodeContext C, SqlConnectionString Connector)
            : this(C, C.Host, Connector)
        {

        }

        public SqlContext(IApplicationContext C, N Host, SqlConnectionString Connector)
            : base(C, Host)
        {
            this.SqlConnector = Connector;
            this.DatabaseName = Connector.DatabaseName;
            this.Broker = Connector.GetClientBroker(OnSqlNotification);
        }

        protected virtual void OnSqlNotification(SqlNotification observer)
            => PostMessage(observer.ToApplicationMessage());

        public SqlDatabaseName DatabaseName { get; }

        public SqlConnectionString SqlConnector { get; }

        public ISqlClientBroker Broker { get; }
        
    }


}
