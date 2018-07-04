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

    public abstract class SqlContext<A> : SqlContext, ISqlContext<A>
       where A : SqlProxyAssembly<A>, new()
    {

        protected SqlContext(INodeContext C, SqlConnectionString Connector)
            : base(C, Connector)
        {
            this.Metadata = SqlProxyAssembly<A>.Metadata();
            this.Broker = SqlProxyAssembly<A>.Broker(Connector, OnSqlNotification);
        }


        protected ISqlProxyMetadataIndex Metadata { get; }


        public new ISqlProxyBroker Broker { get; }

        protected O Operations<O>()
            => Broker.Operations<O>().Require();



    }


}