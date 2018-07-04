//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Meta.Core.Workflow;

    using SqlT;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.SqlSystem;
    using SqlT.Templates;

    using N = SystemNode;

    using static metacore;
    using static SqlT.Core.SqlChannelMessages;



    public class SqlProxyChannel : SqlChannel<ISqlProxyBroker>, ISqlProxyChannel
    {

        public SqlProxyChannel(ILinkedContext C, ISqlProxyBroker Source, ISqlProxyBroker Target)
            : base(C, Source,Target)
        {
            

        }

        Option<T> Witness<T>(Option<T> Outcome, [CallerMemberName] string caller = null)
        {
            if (not(Outcome.Message.IsEmpty))
                Notify(Outcome.Message);
            else
                Outcome.OnNone(message => Notify(error($"Operation {caller} on channel {this} failed: {message.Format(false)}")))
                                      .OnSome(payload => Notify(inform($"Operation {caller} on channel {this} succeeded")));
            return Outcome;
        }

        WorkFlowed<T> Witness<T>(WorkFlowed<T> Outcome, [CallerMemberName] string caller = null)
        {
            Notify(Outcome.Description);
            return Outcome;

        }

        public O SourceOps<O>()
            => Source.Operations<O>().Require();

        public O TargetOps<O>()
            => Target.Operations<O>().Require();

        protected WorkFlowed<T> LiftOption<T>(Option<T> option, Func<T, IApplicationMessage> success)
            => option.MapValueOrElse
                        (count => wf.flowed<T>(stream(count), success(count)),
                        message => wf.failed<T>(message));

        protected WorkFlowed<IReadOnlyList<T>> PullAll<T>()
            where T : class, ISqlTabularProxy, new()
                => Witness(LiftOption(Source.Get<T>().ToOption(),
                        records => Loaded<T>(records.Count)));

            
        protected WorkFlowed<IReadOnlyList<R>> PullAll<F, R>(F f)
            where F : SqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Witness(LiftOption(Source.Select(f), records => FunctionLoaded<F,R>(records.Count)));


        protected WorkFlowed<int> PushAll<T>(IReadOnlyList<T> Data,int? BatchSize)
            where T : class, ISqlTabularProxy, new()
            => Witness(LiftOption(Target.Save(Data,new SqlSaveOptions(BatchSize: BatchSize)),
                    count => Saved<T>(count)));


        public WorkFlowed<int> Push<T>(IEnumerable<T> Data, int? BatchSize)
            where T : class, ISqlTabularProxy, new()
            => LiftOption(Target.Save(Data,
                new SqlSaveOptions(BatchSize: BatchSize),
                    count => Notify(Saved<T>(count))), count => Loaded<T>(count));

        public IEnumerable<T> Pull<T>()
            where T : class, ISqlTabularProxy, new()
                => Source.Stream<T>();

        public IEnumerable<T> Pull<T>(ISqlFilter<T> Filter)
            where T : class, ISqlTabularProxy, new()
                => Source.Stream(Filter);

        public IEnumerable<R> Pull<F, R>(F f)
            where F : class, ISqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Source.Stream<F, R>(f);

        public WorkFlowed<int> Transfer<T>(int? BatchSize)
            where T : class, ISqlTabularProxy, new()
            => Push(Pull<T>(), BatchSize);

        public WorkFlowed<int> Transfer<T>(ISqlFilter<T> Filter, int? BatchSize)
            where T : class, ISqlTabularProxy, new()
            => Push(Pull(Filter), BatchSize);


        protected WorkFlowed<int> Truncate<T>()
            where T : class, ISqlTableProxy, new()
            => Witness(LiftOption(Target.Table<T>().TruncateIfExists(),
                _ => Truncated<T>()));

        protected WorkFlowed<int> Delete<T>()
            where T : class, ISqlTableProxy, new()
                => Witness(LiftOption(Target.Table<T>().Delete(),
                        count => Deleted<T>(count)));

        public  WorkFlowed<int>  Purge<T>(SqlPurgeOption? option = null)
            where T : class, ISqlTableProxy, new()
                => option == SqlPurgeOption.Delete
                    ? Delete<T>()
                    : Truncate<T>();

        WorkFlowed<int> ISqlProxyChannel.Overwrite<T>(int? BatchSize, SqlPurgeOption? PurgeOption)
                => from srcData in PullAll<T>()
                   from dstPurge in Purge<T>(PurgeOption)
                   from save in PushAll(srcData, BatchSize)
                   select save;

        WorkFlowed<int> ISqlProxyChannel.Append<T>(int? BatchSize)
                => from pulled in PullAll<T>()
                   from pushed in Push(pulled, BatchSize)
                   select pushed;


        WorkFlowed<int> ISqlProxyChannel.Overwrite<X, Y>(int? BatchSize, SqlPurgeOption? PurgeOption)
                => from srcData in PullAll<X>()
                   from dstPurge in Purge<Y>(PurgeOption)
                   from save in Push(map(srcData, x => x.TransferArray(new Y())), BatchSize)
                   select save;

        WorkFlowed<int> ISqlProxyChannel.Append<X, Y>(int? BatchSize)
                => from srcData in PullAll<X>()
                   from save in Push(map(srcData, x => x.TransferArray(new Y())), BatchSize)
                   select save;
    }

}