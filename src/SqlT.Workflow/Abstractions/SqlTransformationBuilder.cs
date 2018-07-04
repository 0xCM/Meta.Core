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
    using System.Reflection;

    using Meta.Core;
    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Models;

    using static Meta.Core.FlowTypes;
    using static metacore;
    using sxc = SqlT.Syntax.contracts;


    public abstract class SqlTransformationBuilder<TArgs> : LinkedComponent
        where TArgs : ISqlDataFlowArgs, new()
    {
        protected static readonly DateTime MinTimestamp = new DateTime(2000, 1, 1);
        

        protected SqlTransformationBuilder(ILinkedSqlContext C)
            : base(new LinkedContext(C.SourceContext, C.TargetContext))
        {
        
        }

    }


    public abstract class SqlTransformationBuilder<TSrc, TDst, TArg> : SqlTransformationBuilder<TArg>, ISqlDataFlowBuilder
       where TSrc : class, ISqlTabularProxy, new()
       where TDst : class, ISqlTabularProxy, new()
       where TArg : ISqlDataFlowArgs, new()

    {

        protected SqlTransformationBuilder(ILinkedSqlContext C)
            : base(C)
        {

        }

        protected SqlTransformationBuilder(ILinkedSqlContext C, SqlConnectionString SourceConnection,
            SqlConnectionString TargetConnection, FlowSettings Settings,
                sxc.tabular_name SourceTable, sxc.tabular_name TargetTable)
                    : base(C)
        {
            this.Settings = Settings;
            this.TargetTable = TargetTable;

            if (SourceTable != null)
                this.SourceTable = some(SourceTable);
            this.SourceConnection = SourceConnection;
            this.TargetConnection = TargetConnection;
        }

        protected SqlTransformationBuilder(ILinkedSqlContext C, SqlConnectionString SourceConnection,
            SqlConnectionString TargetConnection, FlowSettings Settings, 
                sxc.tabular_name TargetTable) 
                    : base(C)
        {
            this.Settings = Settings;
            this.TargetTable = TargetTable;
            this.SourceConnection = SourceConnection;
            this.TargetConnection = TargetConnection;
        }

        protected Option<sxc.tabular_name> SourceTable { get; }

        protected sxc.tabular_name TargetTable { get; }

        protected FlowSettings Settings { get; }

        protected SqlConnectionString SourceConnection { get; }

        protected SqlConnectionString TargetConnection { get; }

        IEnumerable<ISqlDataFlowArgs> ISqlDataFlowBuilder.BuildArguments()
            => BuildArguments().Cast<ISqlDataFlowArgs>();

        protected static ISqlProxyBroker SourceBroker(SqlConnectionString cs)
            => SqlProxyBroker.CreateBroker<TSrc>(cs).Require();


        protected IEnumerable<Source<TSrc>> DefaultSources(SqlConnectionString cs, SqlObjectName selector)
        {
            var outcome = SourceBroker(cs).Select<TSrc>($"select * from {selector}()");
            if (outcome)
                return array(new Source<TSrc>(() =>  seq<TSrc>(outcome.ValueOrDefault())));
            throw new Exception(outcome.Message.Format(false));
        }


        public abstract IEnumerable<TArg> BuildArguments();

        public void InitializeBuilder()
        {
            CreateInitializer()(Settings);
        }

        protected abstract Projector<TSrc, TDst> CreateTransformer(SqlConnectionString csDst, TArg args);

        protected virtual IEnumerable<Source<TSrc>> CreateSources(SqlConnectionString csSrc, TArg args)
            => DefaultSources(csSrc, GetSelectorName().Require());

        protected virtual IEnumerable<Source<TSrc>> CreateUpdateSources(SqlConnectionString csSrc, TArg args)
            => new Source<TSrc>[] { };

        protected virtual IEnumerable<Source<TSrc>> CreateInsertSources(SqlConnectionString csSrc, TArg args)
            => new Source<TSrc>[] { };

        protected abstract ISqlProxyBroker TargetBroker(SqlConnectionString csTarget);

        protected virtual Target<TDst> CreateSink(SqlConnectionString csTarget, TArg args)
            => (src) =>
            {
                var options = SqlCopyOptions.Create(csTarget, TargetTable.AsTableName(), true, Timeout: Settings.EmitTimeout);
                var result = TargetBroker(csTarget).BulkCopy(src.Stream(), options);
                return result;
            };

        protected virtual FlowInitializer CreateInitializer()
            => s => 0;

        protected string WorkflowName
            => GetType().GetCustomAttribute<WorkflowBuilderAttribute>().WorkflowName;

        public void InitalizeBuilder()
        {
            CreateInitializer()(Settings);
        }


        IFlowSpec ISqlDataFlowBuilder.SpecifyTransformations(ISqlDataFlowArgs args)
            => SpecifyTransformation((TArg)args);

        public abstract IFlowSpec SpecifyTransformation(SqlConnectionString csSrc, SqlConnectionString csDst, TArg args);

        public IFlowSpec SpecifyTransformation(TArg args)
            => SpecifyTransformation(SourceConnection, TargetConnection, args);

        protected virtual Option<string> GetSelectorName()
            => none<string>();

    }

    public abstract class SqlEndomorphismBuilder<T, A>
        where T : class, ISqlTabularProxy, new()
    {
        protected IApplicationContext C { get; }

        public SqlEndomorphismBuilder(IApplicationContext C)
        {
            this.C = C;
        }

        protected abstract Projector<T, T> CreateTransformer(A Args);

    }


}