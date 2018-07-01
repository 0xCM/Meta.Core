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

    public sealed class WorkCommandSupplier<TSpec> : WorkSupplier<WorkCommand<TSpec>>, IWorkCommandSupplier<TSpec>
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommandSupplier(string GroupName, string PartitionName, Func<int, IEnumerable<TSpec>> Provider)
            : base(PartitionName, n => Provider(n).Select(x => new WorkCommand<TSpec>(x, GroupName, PartitionName)))

        { }

        public WorkCommandSupplier(string PartitionName, Func<int, IEnumerable<TSpec>> Provider)
            : base(PartitionName, n => Provider(n).Select(x => new WorkCommand<TSpec>(x, String.Empty, PartitionName)))

        { }
    }
}