//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Meta.Core;
    using Meta.Core.Workflow;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Workflow;

    using N = SystemNode;

    using static metacore;

    public static partial class SqlWorkflowX
    {
        public static void SqlObserver(this IApplicationContext C, SqlNotification n)
            => C.Notify(n.ToApplicationMessage());

        public static ISqlSessionManager SqlSessionManager(this IApplicationContext C)
            => C.Service<ISqlSessionManager>();

        public static ILinkedSqlSession SqlSession<T>(this IApplicationContext C, N Host, SqlDatabaseName DbName)
                where T : ILinkedSqlSession
            => C.SqlSessionManager().GetSession<T>(Host, DbName);

        public static LinkedSqlContext SqlContext(this IApplicationContext C, NodeLink NodeLink, Link<SqlConnectionString> ConnectorLink)
            => new LinkedSqlContext(C, NodeLink, ConnectorLink);


        public static LinkedSqlContext SqlContext(this IApplicationContext C, NodeLink NodeLink, Link<ISqlProxyBroker> BrokerLink)
            => new LinkedSqlContext(C, NodeLink, 
                link(BrokerLink.Source.ConnectionString, BrokerLink.Target.ConnectionString));

        public static Option<int> OverwriteTable<X, Y>(this ISqlProxyChannel Channel)
          where X : class, ISqlTableProxy, new()
           where Y : class, ISqlTableProxy, new()
               =>
                  from srcData in Channel.Source.Get<X>()
                  from dstPurge in Channel.Target.Table<Y>().TruncateIfExists()
                  from save in Channel.Target.Save(map(srcData, x => x.TransferArray(new Y())))
                  select save;

        public static Option<int> CopyTable<X, Y>(this ISqlProxyChannel Channel)
          where X : class, ISqlTableProxy, new()
           where Y : class, ISqlTableProxy, new()
               =>
                  from srcData in Channel.Source.Get<X>()
                  from save in Channel.Target.Save(map(srcData, x => x.TransferArray(new Y())))
                  select save;

        public static Option<int> CopyTable<X>(this ISqlProxyChannel Channel)
          where X : class, ISqlTableProxy, new()
               => from srcData in Channel.Source.Get<X>()
                  from save in Channel.Target.Save(srcData)
                  select save;

        static IEnumerable<TransformationDescription> DiscoverBuilders(Assembly a)
            => from t in a.GetTypes()
               where Attribute.IsDefined(t, typeof(WorkflowBuilderAttribute))
               let attrib = t.GetCustomAttribute<WorkflowBuilderAttribute>()
               select new TransformationDescription(t, attrib.WorkflowName, attrib.Preconditions.ToArray());

        static Option<ISqlProxyBrokerFactory> SqlBrokerFactory<T>()
            where T : class, ISqlProxy, new()
                => SqlProxyBroker.GetBrokerFactory<T>();

        public static SqlConnectionString SqlIntegratedConnector(this IApplicationContext C, 
            SystemNode Node, SqlDatabaseName Database)
                => SqlConnectionString.Build(Node.NodeServer, Database).UsingIntegratedSecurity();

        public static Option<ISqlProxyBroker> SqlIntegratedBroker<T>(this IApplicationContext C, 
            SystemNode Host, SqlDatabaseName Db)
            where T : ISqlProxy, new()
                => SqlProxyBroker.CreateBroker<T>(C.SqlIntegratedConnector(Host, Db));

        public static IEnumerable<object> ParameterValues<P>(this P proc)
            where P : class, ISqlProcedureProxy, new()
                => proc.GetItemArray();

        public static IApplicationMessage SuccessMessage<P, D>(this ISqlProxyBroker broker, P proc, D data)
            where P : class, ISqlProcedureProxy, new()
                => inform(
                    concat("Succesfully executed", 
                        broker.DatabaseName().Format(true), ".",
                        $"{SqlProxy.DescribeProcedure<P>().FullName}({string.Join(comma(), proc.ParameterValues())})"));

        public static Option<SqlWorkflowStepResult<int>> Call<P>(this SqlWorkflowProc<P> wfProc)
            where P : class, ISqlProcedureProxy, new()
                => wfProc.Broker.Call(wfProc.Proxy)
                    .ToOption().Map(x => new SqlWorkflowStepResult<int>(x, true));

        public static SqlWorkflowProcStep DefineWorkflowProcStep<P>(this P proc)
            where P : class, ISqlProcedureProxy, new()
                => new SqlWorkflowProcStep(SqlProxy.DescribeProcedure<P>());

        public static IEnumerable<TransformationDescription> DiscoverSqlTransformations(this Assembly a)
            => DiscoverBuilders(a);

        public static SqlProjection<TSrc, TDst> DefineSqlProjection<TSrc, TDst>(this Func<TSrc, TDst> F)
            where TSrc : ISqlTabularProxy, new()
            where TDst : ISqlTabularProxy, new()
                => new SqlProjection<TSrc, TDst>(new SqlInjector<TSrc, TDst>(F));

        public static SqlProjection<TSrc, TDst> DefineSqlProjection<TSrc, TDst>(this Func<IEnumerable<TSrc>, IEnumerable<TDst>> G)
            where TSrc : ISqlTabularProxy, new()
            where TDst : ISqlTabularProxy, new()
                => new SqlProjection<TSrc, TDst>(new SqlSequenceInjector<TSrc, TDst>(G));

        public static ISqlDataFlowBuilder SqlDataFowBuilder(this IApplicationContext C,
            FlowSettings settings, TransformationDescription description) 
                => (ISqlDataFlowBuilder)Activator.CreateInstance(description.BuilderType, C, settings);

        public static IEnumerable<IFlowSpec> BuildTransformations(this ISqlDataFlowBuilder builder)
            => from arg in builder.BuildArguments()
               select builder.SpecifyTransformations(arg);

        public static IEnumerable<IFlowSpec> BuildTransformations(this IEnumerable<ISqlDataFlowBuilder> builders)
        {
            foreach (var builder in builders)
                foreach (var transform in builder.BuildTransformations())
                    yield return transform;
        }

        public static Task<ReadOnlyList<Option<FlowMetrics>>> ExecWorkflowSequence(this IApplicationContext C,
                TransformationJob job, Func<bool> quit, Action<IApplicationMessage> observer)
        {
            return Task.Factory.StartNew(()
                =>
            {
                var builders = map(job.TransformationDescriptions, d => C.SqlDataFowBuilder(job.Settings, d));
                foreach (var builder in builders)
                    builder.InitializeBuilder();

                var Options = MutableList.Create<Option<FlowMetrics>>();
                var executor = new FlowExecutor(C.NodeContext(SystemNode.Local));
                foreach (var builder in builders)
                {
                    if (quit())
                        break;

                    foreach (var spec in builder.BuildTransformations())
                    {
                        if (quit())
                            break;

                         executor.Transfer(spec)
                        .OnSome(metrics => Options.Add(new Option<FlowMetrics>(metrics)))
                        .OnNone(reason =>
                            {
                                observer?.Invoke(reason);
                                Options.Add(none<FlowMetrics>(reason));
                            }                        
                        );
                    }
                }
                return ReadOnlyList.Create(Options);
            });
        }
    }
}
