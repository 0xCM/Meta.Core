//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static FlowTypes;

    /// <summary>
    /// Contract for operational workflow
    /// </summary>
    /// <typeparam name="TSrc">The type of the source item</typeparam>
    /// <typeparam name="TDst">The type of the target item</typeparam>
    /// <returns></returns>
    public delegate Task<Option<FlowSummary>> FlowTask<TSrc, TDst>(IFlowSpec<TSrc, TDst> wf);

    /// <summary>
    /// Contract for function that is called prior to workflow commencement to execute any prerequisite steps
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    public delegate Option<int> FlowInitializer(FlowSettings settings);

    /// <summary>
    /// Weakly-typed Contract for ETL transformation workflows that select records from a source,
    /// apply a transformation and pushes the result to a target
    /// </summary>
    public interface IFlowSpec  
    {
        /// <summary>
        /// Proxy type of the source record
        /// </summary>
        Type SrcType { get; }

        /// <summary>
        /// Proxy type of the target record
        /// </summary>
        Type DstType { get; }

        /// <summary>
        /// The function applied to source values to yield target values
        /// </summary>
        Projector Projector { get; }

        /// <summary>
        /// The sources that will feed into the transformation
        /// </summary>
        IEnumerable<Source> Sources { get; }

        /// <summary>
        /// Receives transformed values
        /// </summary>
        Target Sink { get; }

        /// <summary>
        /// Arguments supplied to the transformation
        /// </summary>
        IFlowArgs Arguments { get; }

        /// <summary>
        /// Gets the transformation initializer
        /// </summary>
        FlowInitializer Initializer { get; }
    }

    /// <summary>
    /// Defines the workflow contract which specifies the operations to invoke to 
    /// pull from the source and push to the target
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    public interface IFlowSpec<S, T> : IFlowSpec
    {
        /// <summary>
        /// The sources that will feed into the transformation
        /// </summary>
        new IEnumerable<Source<S>> Sources { get; }

        /// <summary>
        /// The function applied to source values to yield target values
        /// </summary>
        new Projector<S, T> Projector { get; }

        /// <summary>
        /// Receives transformed values
        /// </summary>
        Target<T> Target { get; }
    }
}