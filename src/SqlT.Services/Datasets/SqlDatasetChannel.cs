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

    using SqlT.Core;
    using static metacore;
    
    public abstract class SqlDatasetChannel<M,R> : ApplicationComponent, ISqlDatasetChannel<R>
        where M : SqlDatasetChannel<M, R>
        where R : class, ISqlTabularProxy, new()
    {
        public static readonly SqlContentType ContentType = new SqlContentType(typeof(M).Name);

        Option<ISqlDataset> ISqlDatasetChannel.PullDataset(SystemNode SourceNode, object Criteria)
            => from ds in PullDataset(SourceNode, Criteria)
               select ds as ISqlDataset;

        Option<ISqlDataset> ISqlDatasetChannel.PullDataset(SystemNode SourceNode)
            => from ds in PullDataset(SourceNode)
               select ds as ISqlDataset;

        public SqlDatasetDesignator Designate(Date? ProductionDate = null, DateRange? ContentPeriod = null)
            => new SqlDatasetDesignator(ContentType, ProductionDate, ContentPeriod);

        Option<SqlDataset<R>> ISqlDatasetChannel<R>.PullDataset(SystemNode SourceNode, object Criteria)
            => PullDataset(SourceNode, Criteria);

        Option<int> ISqlDatasetChannel.PushDataset(SystemNode TargetNode, ISqlDataset Dataset, SqlProxyEncodingOptions Options)
            => PushDataset(TargetNode, (SqlDataset<R>)Dataset);

        Option<int> ISqlDatasetChannel.TransferDataset(SystemNode Source, SystemNode Target, object Criteria, SqlProxyEncodingOptions Options)
            => from dataset in PullDataset(Source, Criteria)
               from push in PushDataset(Target, dataset)
               select push;

        public Option<int> TransferDataset(SystemNode Source, SystemNode Target, SqlProxyEncodingOptions Options = null)
            => from dataset in PullDataset(Source)
               from push in PushDataset(Target, dataset)
               select push;

        protected ISqlProxyEncoder ProxyEncoder { get; }
            

        protected SqlDatasetChannel(IApplicationContext C)
            : base(C)
        {
            ProxyEncoder = SqlProxyEncoder.Create();
        }

        protected abstract ISqlProxyBroker SourceBroker(SystemNode SourceNode);

        protected abstract ISqlProxyBroker TargetBroker(SystemNode TargetNode);

        public abstract Option<int> PushDataset(SystemNode TargetNode, SqlDataset<R> Dataset, SqlProxyEncodingOptions Options = null);

        public abstract Option<SqlDataset<R>> PullDataset(SystemNode SourceNode, object Criteria);

        public abstract Option<SqlDataset<R>> PullDataset(SystemNode SourceNode);
    }

    public abstract class SqlDatasetChannel<M, C, R> : SqlDatasetChannel<M,R>, ISqlDatasetChannel<C, R>
        where M : SqlDatasetChannel<M, C, R>
        where C : class, new()
        where R : class, ISqlTabularProxy, new()
    {
        protected SqlDatasetChannel(IApplicationContext C)
            : base(C)
        {
            
        }
        
        public abstract Option<SqlDataset<R>> PullDataset(SystemNode SourceNode, C Criteria);

        public override sealed Option<SqlDataset<R>> PullDataset(SystemNode SourceNode, object Criteria)
            => PullDataset(SourceNode, (C)Criteria);

        public override sealed Option<SqlDataset<R>> PullDataset(SystemNode SourceNode)
            => PullDataset(SourceNode, new C());

        public Option<int> TransferDataset(SystemNode Source, SystemNode Target, C Criteria, SqlProxyEncodingOptions Options = null)
            => from dataset in PullDataset(Source, Criteria)
               from push in PushDataset(Target, dataset)
               select push;
    }
}