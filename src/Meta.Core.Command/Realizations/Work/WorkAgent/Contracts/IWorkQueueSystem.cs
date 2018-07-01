//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Defines the queuing pattern contract for the work queue system
    /// </summary>
    /// <typeparam name="W">The work type</typeparam>
    /// <typeparam name="TResult">The type of result computed by executing the work unit</typeparam>
    public interface IWorkQueueSystem<W, TResult> where W : IPartitionedWork
    {
        Option<WorkSubmission<W>> Submit(W work);

        Option<WorkDispatch<W>> Dispatch();

        Option<WorkCompletion<W, TResult>> Complete(long workId, TResult result);
    }
}