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
    /// Defines utility methods related to partitioned commands
    /// </summary>
    public static class WorkCommand
    {

        public static WorkCommandManager<TSpec> Manage<TSpec>()
            where TSpec : CommandSpec<TSpec>, new()
                => new WorkCommandManager<TSpec>();

        public static WorkCommandAgent<TSpec>
            CreateAgent<TSpec>(WorkCommandAgentConfiguration<TSpec> AgentConfiguration)
                where TSpec : CommandSpec<TSpec>, new()
                    => new WorkCommandAgent<TSpec>(AgentConfiguration);

        public static WorkCommandSupplier<TSpec>
            CreateSupplier<TSpec>(string partition, Func<int, IEnumerable<TSpec>> Provider)
                where TSpec : CommandSpec<TSpec>, new()
                => new WorkCommandSupplier<TSpec>(partition, Provider);

        public static WorkCommandAgentObserver<TSpec>
            CreateObserver<TSpec>()
                where TSpec : CommandSpec<TSpec>, new() => new WorkCommandAgentObserver<TSpec>();



    }


    /// <summary>
    /// Defines a command specification that associates a command specification with 
    /// a partition and/or group
    /// </summary>
    /// <typeparam name="TSpec">The specification that is subject to partitioning</typeparam>
    public sealed class WorkCommand<TSpec> : CommandSpec<TSpec>, IPartitionedWork
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommand()
        { }

        public WorkCommand(TSpec Command, string PartitionName)
        {
            this.Command = Command;
            this.GroupName = String.Empty;
            this.PartitionName = PartitionName;
        }

        public WorkCommand(TSpec Command, string GroupName, string PartitionName)
        {
            this.Command = Command;
            this.GroupName = GroupName;
            this.PartitionName = PartitionName;
        }

        /// <summary>
        /// The command specification assigned to the partition
        /// </summary>
        public TSpec Command { get; set; }

        /// <summary>
        /// The name of the group, if any
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The name of the partition to which the spec is assigned
        /// </summary>
        public string PartitionName { get; set; }
    }


    /// <summary>
    /// Defines a command specification that associates a command specification with 
    /// a partition and/or group
    /// </summary>
    /// <typeparam name="TSpec">The specification that is subject to partitioning</typeparam>
    /// <typeparam name="TResult">The command result type</typeparam>
    public sealed class WorkCommand<TSpec, TResult> : CommandSpec<TSpec, TResult>, IPartitionedWork
        where TSpec : CommandSpec<TSpec, TResult>, new()
    {
        public WorkCommand()
        { }

        public WorkCommand(TSpec Command, string PartitionName)
        {
            this.Command = Command;
            this.GroupName = String.Empty;
            this.PartitionName = PartitionName;
        }

        public WorkCommand(TSpec Command, string GroupName, string PartitionName)
        {
            this.Command = Command;
            this.GroupName = GroupName;
            this.PartitionName = PartitionName;
        }

        /// <summary>
        /// The command specification assigned to the partition
        /// </summary>
        public TSpec Command { get; set; }

        /// <summary>
        /// The name of the group, if any
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The name of the partition to which the spec is assigned
        /// </summary>
        public string PartitionName { get; set; }
    }


}