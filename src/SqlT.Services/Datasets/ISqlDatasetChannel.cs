//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using SqlT.Core;
    using SqlT.Models;
   
    public interface ISqlDatasetChannel
    {
        Option<ISqlDataset> PullDataset(SystemNode SourceNode, object Criteria);

        Option<ISqlDataset> PullDataset(SystemNode SourceNode);

        Option<int> PushDataset(SystemNode TargetNode, ISqlDataset Dataset, SqlProxyEncodingOptions Options = null);

        Option<int> TransferDataset(SystemNode Source, SystemNode Target, object Criteria, SqlProxyEncodingOptions Options = null);

        Option<int> TransferDataset(SystemNode Source, SystemNode Target, SqlProxyEncodingOptions Options = null);

    }

    public interface ISqlDatasetChannel<T> : ISqlDatasetChannel
        where T : class, ISqlTabularProxy, new()
    {
        new Option<SqlDataset<T>> PullDataset(SystemNode SourceNode, object Criteria);

        new Option<SqlDataset<T>> PullDataset(SystemNode SourceNodeSql);

        Option<int> PushDataset(SystemNode TargetNode, SqlDataset<T> Dataset, SqlProxyEncodingOptions Options = null);
    }

    public interface ISqlDatasetChannel<C,T> : ISqlDatasetChannel<T>
        where T : class, ISqlTabularProxy, new()
        where C : class, new()
    {
        Option<SqlDataset<T>> PullDataset(SystemNode SourceNode, C Criteria);

        Option<int> TransferDataset(SystemNode Source, SystemNode Target, C Criteria, SqlProxyEncodingOptions Options = null);
    }


}