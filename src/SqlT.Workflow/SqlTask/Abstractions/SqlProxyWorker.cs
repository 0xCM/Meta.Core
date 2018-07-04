//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;


    public abstract class SqlProxyWorker<A> : SqlWorker
       where A : class, ISqlProxyAssembly, new()
    {
        protected SqlProxyWorker(ISqlContext Context)
            : base(Context)

        {
            Broker = new A().CreateBroker(Context.SqlConnector, OnSqlNotification);
        }


        protected new ISqlProxyBroker Broker { get; }

        protected IEnumerable<T> Pull<T>()
            where T : class, ISqlTabularProxy, new()
                => Broker.Stream<T>();

        protected IEnumerable<R> Pull<F, R>(ISqlTableFunctionProxy<F, R> f)
            where F : class, ISqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Broker.Stream<F, R>((F)f);

        protected void Push<T>(IEnumerable<T> items, int? timeout = null, int? batchSize = null)
            where T : class, ISqlTabularProxy, new()
                => Broker.Save<T>(items,
                    new SqlSaveOptions(timeout, batchSize),
                        savedCount => Notify(inform($"Saved {savedCount} {PXM.TabularName<T>()} records")));

        protected Option<int> Exec<P>(P proc = null)
            where P : class, ISqlProcedureProxy, new()
        {
            return Broker.Call(proc ?? new P(), Notify);

        }

        protected void Transform<X, Y>(Func<X, Y> F, int? timeout = null, int? batchSize = null)
            where X : class, ISqlTabularProxy, new()
            where Y : class, ISqlTabularProxy, new()
                => Push(Pull<X>().Select(F), timeout, batchSize);


    }




}