//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    using Meta.Core;


    /// <summary>
    /// Weakly-typed Contract for ETL transformation workflows that select records from a source,
    /// apply a transformation and pushes the result to a target
    /// </summary>
    public interface ISqlWorkflowTransformation : IFlowSpec
    {

        /// <summary>
        /// The function applied to source values to yield target values
        /// </summary>
        new SqlSequenceTransformer Projector { get; }

        /// <summary>
        /// The sources that will feed into the transformation
        /// </summary>
        new IEnumerable<SqlDataSource> Sources { get; }

        /// <summary>
        /// Receives transformed values
        /// </summary>
        new SqlDataSink Sink { get; }

    }

    /// <summary>
    /// Defines the workflow contract which specifies the operations to invoke to 
    /// pull from the source and push to the target
    /// </summary>
    public interface ISqlWorkflowTransformation<TSrc, TDst> : ISqlWorkflowTransformation
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()
        
    {
        /// <summary>
        /// The sources that will feed into the transformation
        /// </summary>
        new IEnumerable<SqlDataSource<TSrc>> Sources { get; }

        /// <summary>
        /// The function applied to source values to yield target values
        /// </summary>
        SqlSequenceTransformer<TSrc, TDst> Transformer { get; }

        /// <summary>
        /// Receives transformed values
        /// </summary>
        new SqlDataSink<TDst> Sink { get; }
    }
}