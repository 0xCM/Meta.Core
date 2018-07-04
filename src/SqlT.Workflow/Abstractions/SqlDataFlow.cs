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
    using System.Runtime.CompilerServices;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using N = SystemNode;
    using static metacore;
    using static SqlT.Core.SqlChannelMessages;

    public abstract class SqlDataFlow : LinkedComponent, ISqlDataFlow
    {

        public static IEnumerable<SqlDataFlowDescriptor> Search(ClrAssembly a)
            => from t in a.Types.Where(t => t.Realizes<ISqlDataFlow>() && t.IsSealed)
               let b = t.BaseTypes.FirstOrDefault(x => x.GenericTypeArguments.Count() > 1)
               where b != null
               let assemblyTypes = b.GenericTypeArguments.Skip(1)
               select new SqlDataFlowDescriptor
               (
                 t,
                 b.GenericTypeArguments.First().ReflectedElement,
                 SourceAssembly: (Activator.CreateInstance(assemblyTypes.First().ReflectedElement) as ISqlProxyAssembly),
                 TargetAssembly: (Activator.CreateInstance(assemblyTypes.Last().ReflectedElement) as ISqlProxyAssembly)
               );


        protected static Option<X> opt<X>(SqlOutcome<X> x)
            => x.ToOption();


        protected virtual WorkFlowed<T> Witness<T>(Option<T> Outcome, [CallerMemberName] string caller = null)
        {
            var wf = LiftOption(Outcome, _ => inform($"Operation {caller} on channel {Channel} succeeded"));

            if (not(Outcome.Message.IsEmpty))
                Notify(Outcome.Message);
            else
                Outcome.OnNone(message => Notify(error($"Channel {Channel} operation {caller} failed: {message.Format(false)}")))
                    .OnSome(payload => Notify(inform($"Channel {Channel} operation {caller} succeeded")));

            return wf;
                   
        }

        protected virtual void OnSqlNotification(SqlNotification notification)
            => Notify(notification.ToApplicationMessage());


        protected virtual WorkFlowed<T> Witness<T>(WorkFlowed<T> Outcome, [CallerMemberName] string caller = null)
        {

            Notify(Outcome.Description);
            return Outcome;

        }

        public SqlDataFlow(ISqlProxyChannelFactory ChannelFactory)
            : base(new LinkedContext(ChannelFactory.SourceContext, ChannelFactory.TargetContext))
        {
            this.ChannelFactory = ChannelFactory;
        }

        ISqlProxyChannelFactory ChannelFactory { get; }

        protected ISqlProxyChannel Channel
            => ChannelFactory.ProxyChannel();

        public ISqlProxyBroker SourceBroker
            => Channel.Source;

        public ISqlProxyBroker TargetBroker
            => Channel.Target;
      
        protected WorkFlowed<IReadOnlyList<T>> PullAll<T>()
            where T : class, ISqlTabularProxy, new()
                => Witness(LiftOption(Channel.Source.Get<T>().ToOption(), 
                        records => Loaded<T>(records.Count)));

        protected WorkFlowed<IReadOnlyList<R>> PullAll<F, R>(F f)
            where F : SqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Witness(Channel.Source.Select(f));

        protected IEnumerable<T> Pull<T>()
            where T : class, ISqlTabularProxy, new()
                => Channel.Source.Stream<T>();

        protected IEnumerable<R> Pull<F, R>(ISqlTableFunctionProxy<F, R> f)
            where F : class, ISqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Channel.Source.Stream<F, R>((F)f);

        protected WorkFlowed<int> PushAll<T>(IReadOnlyList<T> Data)
            where T : class, ISqlTabularProxy, new()
            => Witness(LiftOption(Channel.Target.Save(Data), 
                    count => Saved<T>(count)));

        protected WorkFlowed<int> Push<T>(IEnumerable<T> Data, int? BatchSize = 5000, int? Timeout = null)
            where T : class, ISqlTabularProxy, new()
            => Witness(Channel.Target.Save(Data,
                new SqlSaveOptions(BatchSize: BatchSize, Timeout : Timeout),
                    count => Notify(C.SavedRowsToTarget<T>(count))));


        protected WorkFlowed<int> PurgeTarget<T>()
            where T : class, ISqlTableProxy, new()
            => from purge in Witness(Channel.Target.Table<T>().TruncateIfExists()
                    .OnNone(Notify)
                    .OnSome(_ => Notify(Truncated<T>())))
               select purge;

        protected WorkFlowed<T> LiftOption<T>(Option<T> option, Func<T, IApplicationMessage> success)
            => option.MapValueOrElse(value => wf.lift(stream(value)),        
                message => wf.failed<T>(message));
       
        protected WorkFlowed<int> Truncate<T>()
            where T : class, ISqlTableProxy, new()
            =>  Witness(LiftOption(Channel.Target.Table<T>().TruncateIfExists(), 
                _ => Truncated<T>()));

        protected WorkFlowed<int> Delete<T>()
            where T : class, ISqlTableProxy, new()
                => Witness(LiftOption(Channel.Target.Table<T>().Delete(), 
                        count => Deleted<T>(count)));

        protected WorkFlowed<int> CountDistinct<T>(SqlColumnName col)
            where T : class, ISqlTabularProxy, new()
                => LiftOption(
                    Channel.Target.Tabular<T>().CountDistinct(col).TryMapValue(x => x), 
                        value => CountedDistinct<T>(value,col)
                        );

        protected WorkFlowed<int> Count<T>()
            where T : class, ISqlTabularProxy, new()
                => LiftOption(
                    Channel.Target.Count<T>().TryMapValue(x => x), 
                        value => Counted<T>(value));
                    
        protected WorkFlowed<int> Purge<T>(SqlPurgeOption? option = null)
            where T : class, ISqlTableProxy, new()
            => Channel.Purge<T>(option);

        protected WorkFlowed<int> Overwrite<T>(int? BatchSize = null, SqlPurgeOption? PurgeOption = null)
           where T : class, ISqlTableProxy, new()
                => Channel.Overwrite<T>(BatchSize, PurgeOption);

        protected WorkFlowed<int> Overwrite<X, Y>(int? BatchSize = null, SqlPurgeOption? PurgeOption = null)
           where X : class, ISqlTableProxy, new()
            where Y : class, ISqlTableProxy, new()
            => Channel.Overwrite<X, Y>(BatchSize, PurgeOption);

        protected WorkFlowed<int> Append<T>(int? BatchSize = null)
           where T : class, ISqlTableProxy, new()
                => Channel.Append<T>(BatchSize);

        protected WorkFlowed<int> Append<X, Y>(int? BatchSize = null)
           where X : class, ISqlTableProxy, new()
            where Y : class, ISqlTableProxy, new()
            => Channel.Append<X, Y>(BatchSize);

        protected WorkFlowed<int> Transfer<T>(int? BatchSize = null)
            where T : class, ISqlTabularProxy, new()
            => Channel.Transfer<T>(BatchSize);

        protected WorkFlowed<int> Transfer<T>(ISqlFilter<T> Filter, int? BatchSize = null)
            where T : class, ISqlTabularProxy, new()
            => Channel.Transfer<T>(Filter, BatchSize);

        public O SourceOps<O>()
            => Channel.Source.Operations<O>().Require();

        public O TargetOps<O>()
            => Channel.Target.Operations<O>().Require();

        WorkFlowed<int> TargetExec<P>(P proc = null)
            where P : class, ISqlProcedureProxy, new()
            => LiftOption(TargetBroker.Call(proc ?? new P(), Notify),
                    _ => inform($"Executed {PXM.ProcedureName<P>()} on target"));

        WorkFlowed<int> SourceExec<P>(P proc = null)
            where P : class, ISqlProcedureProxy, new()
            => LiftOption(SourceBroker.Call(proc ?? new P(), Notify),
                    _ => inform($"Executed {PXM.ProcedureName<P>()} on source"));

        protected WorkFlowed<CorrelationToken> FlowBegin([CallerMemberName] string caller = null)
        {
            var ct = CorrelationToken.Create();
            Notify(inform($"Starting workflow {caller}/{ct}"));
            return  wf.flowed(stream(ct));
        }

        protected WorkFlowed<CorrelationToken> FlowEnd(CorrelationToken ct, [CallerMemberName] string caller = null)
        {

            Notify(inform($"Comleting workflow {caller}/{ct}"));

            return wf.flowed(stream(ct));

        }

        protected WorkFlowed<CorrelationToken> StepBegin([CallerMemberName] string caller = null)
        {
            var ct = CorrelationToken.Create();
            Notify(inform($"Executing step {caller}/{ct}"));

            return wf.flowed(stream(ct));
        }

        protected WorkFlowed<CorrelationToken> StepEnd(CorrelationToken ct, [CallerMemberName] string caller = null)
        {
            Notify(inform($"Executed step {caller}/{ct}"));

            return wf.flowed(stream(ct));
        }

        public abstract WorkFlowed<int> Execute(ISqlDataFlowArgs args);

    }

    public abstract class SqlDataFlow<A> : SqlDataFlow, ISqlDataFlow<A>
        where A : ISqlDataFlowArgs
    {
        protected SqlDataFlow(ISqlProxyChannelFactory ChannelFactory)
            : base(ChannelFactory)
        {
            
        }

        public abstract WorkFlowed<int> Execute(A args);

        public override WorkFlowed<int> Execute(ISqlDataFlowArgs args)
            => Execute((A)args);

    }

    public abstract class SqlDataFlow<A, X> : SqlDataFlow<A>, ISqlDataFlow<A,X>
        where A : ISqlDataFlowArgs
       where X : class, ISqlProxyAssembly, new()
    {
        protected SqlDataFlow(ISqlProxyChannelFactory ChannelFactory)
            : base(ChannelFactory)
        {


        }

    }


    public abstract class SqlDataFlow<A,X,Y> : SqlDataFlow<A>, ISqlDataFlow<A,X,Y>
        where A : ISqlDataFlowArgs
       where X : class, ISqlProxyAssembly, new()
        where Y : class, ISqlProxyAssembly, new()
    {
        protected SqlDataFlow(ISqlProxyChannelFactory ChannelFactory)
            : base(ChannelFactory)
        {


        }

    }

}