//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Meta.Core;

    public interface ITransformationManager : IDisposable
    {

        Task<ReadOnlyList<Option<FlowMetrics>>> RunSequential(ReadOnlyList<TransformationDescription> descriptions);

        Task<Option<FlowSummary>> RunConcurrent(IEnumerable<TransformationDescription> descriptions);

        Task<Option<FlowSummary>> Run(IFlowSpec workflow);

        Task<Option<FlowSummary>> RunSequential(IEnumerable<IFlowSpec> transformations);

        Task<Option<FlowSummary>> RunConcurrent(IEnumerable<IFlowSpec> transformations);

        Option<FlowSummary> RunDirect(IEnumerable<IFlowSpec> transformations);
    }
}