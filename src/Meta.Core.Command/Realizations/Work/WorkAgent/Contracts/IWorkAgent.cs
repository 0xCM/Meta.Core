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


    /// <summary>
    /// Defines non-generic queue contract
    /// </summary>
    public interface IWorkAgent : IDisposable
    {
        /// <summary>
        /// Computes a snapshot of work statistics
        /// </summary>
        /// <returns></returns>
        WorkAgentStatistics ComputeStats();

        /// <summary>
        /// Initiates agent execution
        /// </summary>
        void Start();

        /// <summary>
        /// Executes available work items
        /// </summary>
        IEnumerable<WorkPartition> ExecuteQueue();

        /// <summary>
        /// Explicitly submits work to the agent along with a worker that knows how to carry it out and an observer that receives 
        /// messages from the agent as the work is submitted, dispatched and completed
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        WorkPartition Submit(IPartitionedWork work, Action<IPartitionedWork> worker, IReadOnlyList<IWorkAgentObserver> observers);

        /// <summary>
        /// Enqueues a collection of work items wherein the collection of items will be 
        /// partitioned by group and and each such partition will be executed as a block
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        ReadOnlyList<Task<ReadOnlyList<WorkPartition>>> Submit(
            IReadOnlyList<IPartitionedWork> work,
            Action<IPartitionedWork> worker,
            IReadOnlyList<IWorkAgentObserver> observers
            );
    }

    /// <summary>
    /// Defines generic queue contract
    /// </summary>
    public interface IWorkAgent<W> : IWorkAgent where W : IPartitionedWork
    {
        /// <summary>
        /// Explicitly submits work to the agent along with a worker that knows how to carry it out and an observer that receives 
        /// messages from the agent as the work is submitted, dispatched and completed
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        WorkPartition<W> Submit(W work, Action<W> worker = null, IReadOnlyList<IWorkAgentObserver<W>> observers = null);

        /// <summary>
        /// Enqueues a collection of work items wherein the collection of items will be 
        /// partitioned by group and and eqch such partition will be executed as a block
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        void Submit(IReadOnlyList<W> work, Action<W> worker = null, IReadOnlyList<IWorkAgentObserver<W>> observers = null);

        /// <summary>
        /// Executes available work items
        /// </summary>
        new IEnumerable<WorkPartition<W>> ExecuteQueue();
    }

    public interface IWorkAgent<W, R> : IWorkAgent<W>
        where W : IPartitionedWork
    {
        /// <summary>
        /// Explicitly submits work to the agent along with a worker that knows how to carry it out and an observer that receives 
        /// messages from the agent as the work is submitted, dispatched and completed
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        WorkPartition<W, R> Submit(W work, Func<W, R> worker = null, IReadOnlyList<IWorkAgentObserver<W, R>> observers = null);

        /// <summary>
        /// Enqueues a collection of work items wherein the collection of items will be 
        /// partitioned by group and and eqch such partition will be executed as a block
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">Listeners that will receive work-related events as they occur</param>
        /// <returns></returns>
        void Submit(IReadOnlyList<W> work, Func<W, R> worker = null, IReadOnlyList<IWorkAgentObserver<W, R>> observers = null);

        /// <summary>
        /// Executes available work items
        /// </summary>
        new IEnumerable<WorkPartition<W, R>> ExecuteQueue();
    }
}