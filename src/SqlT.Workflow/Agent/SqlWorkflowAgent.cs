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
    using System.Threading;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;

    using static metacore;
    using static Meta.Core.WorkflowMessages;

    public abstract class SqlWorkflowAgent<A, TSrc, TDst> : ServiceAgent<A, SqlWorkflowAgentSettings>, ISqlWorkflowAgent
        where A : SqlWorkflowAgent<A, TSrc, TDst>
        where TSrc : class, ISqlTabularProxy, new()
        where TDst : class, ISqlTabularProxy, new()
    {
        protected SqlWorkflowAgent(IApplicationContext C, ISqlProxyChannel Channel)
            : base(C)
        {
            this.Channel = Channel;                        
        }
        
        ISqlProxyChannel Channel { get; }

        ISqlProxyBroker SourceBroker
            => Channel.Source;

        ISqlProxyBroker TargetBroker
            => Channel.Target;

        IReadOnlyList<TSrc> Evaluate(Option<IReadOnlyList<TSrc>> src)
        {
            if (src)
                return ~src;
            else
            {
                Notify(src.Message);
                return rolist<TSrc>();
            }
        }

        bool Skip(TSrc item)
            => false;

        IEnumerable<TDst> TransformSources(IEnumerable<TSrc> src)
            => from item in src where not(Skip(item)) select TransformSource(item);


        Queue<TSrc> records;

        protected virtual Option<IReadOnlyList<TSrc>> NextBatch()
        {
            if(records == null)
            {

                var all = SourceBroker.Get<TSrc>();
                if (!all)
                    return all;
                records = new Queue<TSrc>(all.Items());
            }

            return some((IReadOnlyList<TSrc>)(records.Dequeue(BatchSize).ToList()));
        }

        readonly object locker = new object();
        int totalCount;

        protected virtual Option<int> Publish(IEnumerable<TDst> dst)
        {
            lock (locker)
            {
                var exclusions = map(ExcludedColumns, e => SqlColumnName.Parse(e.GetValueMemberName()));
                return TargetBroker.BulkCopy(dst, BatchSize, exclusions);
            }
        }

        protected virtual IEnumerable<Expression<Func<TDst, object>>> ExcludedColumns
            => stream<Expression<Func<TDst, object>>>();

        TDst TransformSource(TSrc src)
            => new TDst();

        IReadOnlyList<SqlWorkflowTable<TDst>> Publish(IReadOnlyList<TSrc> next)
        {
            var dst = rolist(TransformSources(next));
            
            var result = Publish(dst).OnNone(Notify);
            if (!result)
                return rolist<SqlWorkflowTable<TDst>>();

            var published = map(dst, item 
                => new SqlWorkflowTable<TDst>(item, SqlWorkflowStates.Populated, result.IsSome()));

            var thisCount = published.Count;
            Interlocked.Add(ref totalCount, thisCount);
            Notify(PublicationSucceeded<TSrc, TDst>(thisCount, totalCount));

            return published;
        }

        public IEnumerable<ISqlWorkflowTable<TDst>> ExecuteWorkflow()
        {
            var src = Evaluate(NextBatch());
            while (src.Count != 0)
            {
                var dst = Publish(src);
                foreach (var item in dst)
                    yield return item;

                src = Evaluate(NextBatch());
            }
        }

        IEnumerable<ISqlWorkflowTable> ISqlWorkflowAgent.ExecuteWorkflow()
            => (this as ISqlWorkflowAgent).ExecuteWorkflow();

        void Executed(ISqlWorkflowTable<TDst> Dst)
        {

        }

        protected override Option<int> DoWork()
        {
            iter(ExecuteWorkflow(), Executed);

            return 0;
        }

    }
}
