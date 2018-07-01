//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// Produces a sequence of work items 
    /// </summary>
    /// <typeparam name="W">The work item type</typeparam>
    public class WorkSupplier<W> : IWorkSupplier<W> where W : IPartitionedWork
    {

        readonly Func<int, IEnumerable<W>> WorkRetriever;

        public WorkSupplier(string PartitionName, Func<int, IEnumerable<W>> WorkRetriever)
        {
            this.PartitionName = PartitionName;
            this.WorkRetriever = WorkRetriever;
        }

        public IEnumerable<W> Next(int MaxCount)
            => WorkRetriever(MaxCount);

        /// <summary>
        /// The name of the partitioned to which the produced work items are assigned
        /// </summary>
        public string PartitionName { get; }

        IEnumerable<IPartitionedWork> IWorkSupplier.Next(int MaxCount)
            => Next(MaxCount).Cast<IPartitionedWork>();
    }


}