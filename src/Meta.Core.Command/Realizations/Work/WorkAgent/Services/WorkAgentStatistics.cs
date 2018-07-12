//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Encapsulates a set of statistics that reflect the current state of a queue
    /// </summary>
    public class WorkAgentStatistics : ValueObject<WorkAgentStatistics>
    {

        /// <summary>
        /// Initializes a new <see cref="WorkAgentStatistics"/> instance
        /// </summary>
        /// <param name="TotalPartitionCount">The number of partitions in the queue</param>
        /// <param name="NonemptyPartitionCount">The number of partitions that have work assigned</param>
        /// <param name="PendingTaskCount">The number of tasks in the queue awaiting execution</param>
        /// <param name="ExecutingTaskCount">The number of tasks currently executing</param>
        /// <param name="ExecutedTaskCount">The number of tasks that have been executed since the queue was instantiated</param>
        /// <param name="SpinnerCount">The number of tasks spun-up by the spin-loop that are currently executing</param>
        public WorkAgentStatistics
            (
                int TotalPartitionCount,
                int NonemptyPartitionCount,
                int PendingTaskCount,
                int ExecutingTaskCount,
                int ExecutedTaskCount,
                int SpinnerCount,
                int RevolutionCount,
                int LastSubmissionCount
            )
        {
            this.TotalPartitionCount = TotalPartitionCount;
            this.NonemptyPartitionCount = NonemptyPartitionCount;
            this.PendingTaskCount = PendingTaskCount;
            this.ExecutingTaskCount = ExecutingTaskCount;
            this.ExecutedTaskCount = ExecutedTaskCount;
            this.SpinnerCount = SpinnerCount;
            this.RevolutionCount = RevolutionCount;
            this.LastSubmissionCount = LastSubmissionCount;

        }

        /// <summary>
        /// The number of partitions in the queue
        /// </summary>
        public readonly int TotalPartitionCount;

        /// <summary>
        /// The number of partitions that have work assigned
        /// </summary>
        public int NonemptyPartitionCount { get; }

        /// <summary>
        /// The number of tasks in the queue awaiting execution
        /// </summary>
        public int PendingTaskCount { get; }

        /// <summary>
        /// The number of tasks currently executing
        /// </summary>
        public int ExecutingTaskCount { get; }

        /// <summary>
        /// The number of tasks that have been executed since the queue was instantiated
        /// </summary>
        public int ExecutedTaskCount { get; }

        /// <summary>
        /// The number of tasks spun-up by the spin-loop that are currently executing
        /// </summary>
        public int SpinnerCount { get; }

        /// <summary>
        /// The total number of executed spinner loops
        /// </summary>
        public int RevolutionCount { get; }

        /// <summary>
        /// The number of subbmissions enqueued during the last spinner loop
        /// </summary>
        public int LastSubmissionCount { get; }

        public IAppMessage ToMessage()
            => AppMessage.Inform(
                    "Pending:@PendingTaskCount Executing:@ExecutingTaskCount Executed:@ExecutedTaskCount Spinners:@SpinnerCount Revolutions:@RevolutionCount Last Submitted: @LastSubmissionCount", this);


        public override string ToString()
            => ToMessage().Format();

    }


}