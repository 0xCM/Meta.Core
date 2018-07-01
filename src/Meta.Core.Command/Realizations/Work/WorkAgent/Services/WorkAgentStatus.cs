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

    public class WorkAgentStatus : ValueObject<WorkAgentStatus>
    {

        public WorkAgentStatus()
        {

        }

        /// <summary>
        /// Initializes a new <see cref="WorkAgentStatus"/> notification
        /// </summary>
        /// <param name="stats">The statistic the notification will reflect</param>
        public WorkAgentStatus(WorkAgentStatistics stats)
        {
            TotalPartitionCount = stats.TotalPartitionCount;
            NonemptyPartitionCount = stats.NonemptyPartitionCount;
            PendingTaskCount = stats.PendingTaskCount;
            ExecutingCount = stats.ExecutingTaskCount;
            ExecutedCount = stats.ExecutedTaskCount;
        }

        /// <summary>
        /// The number of partitions in the queue
        /// </summary>
        public int TotalPartitionCount { get; }

        /// <summary>
        /// The number of partitions that have work assigned
        /// </summary>
        public int NonemptyPartitionCount { get; }

        /// <summary>
        /// The number of tasks in the queue awaiting execution
        /// </summary>
        public int PendingTaskCount { get; }

        /// <summary>
        /// The number of tasks that have been executed since the queue was instantiated"
        /// </summary>
        public int ExecutedCount { get; }

        /// <summary>
        /// The number of tasks currently executing
        /// </summary>
        public int ExecutingCount { get; }


        public override string ToString()
            => $"Queue -  Pending: {PendingTaskCount}, Executing: {ExecutingCount}, Executed: {ExecutedCount}";
    }

}