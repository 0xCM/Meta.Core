//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;

    using SqlT.Core;
    using SqlT.Models;
    using Meta.Core.Workflow;



    public class SqlWorkflowProc<P> : SqlWorkflowProcStep, ISqlProcedureProxy, ISqlWorkflowProc<P>
       where P : class, ISqlProcedureProxy, new()

    {

        public SqlWorkflowProc(ISqlProxyBroker Broker, P Proxy)
            : base(SqlProxy.DescribeProcedure<P>())
        {
            this.Proxy = Proxy;
            this.Broker = Broker;
        }

        public P Proxy { get; }
            = new P();

        public ISqlProxyBroker Broker { get; }

        object[] ISqlProxy.GetItemArray()
            => Proxy.GetItemArray();

        void ISqlProxy.SetItemArray(object[] items)
            => Proxy.SetItemArray(items);
    }

    


}