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
    using sxc = SqlT.Syntax.contracts;

    using N = SystemNode;
    using static metacore;
    using Meta.Core.Workflow;

    public abstract class SqlDataJunction<T> : ISqlDataJunction
        where T : class, ISqlTabularProxy, new()

    {
        protected SqlDataJunction(sxc.tabular_name Conduit, ISqlProxyBroker Broker)
        {
            this.Broker = Broker;
            this.Conduit = Conduit;

        }

        public sxc.tabular_name Conduit { get; }

        protected ISqlProxyBroker Broker { get; }

        DataJunctionName IDataJunction.Name
            => new DataJunctionName(Conduit.Format(true));

        Type IDataJunction.NodeType
            => GetType();
    }


}