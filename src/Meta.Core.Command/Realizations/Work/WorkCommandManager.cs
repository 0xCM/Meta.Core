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


    public sealed class WorkCommandManager<TSpec>
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommandAgent<TSpec> CreateAgent(WorkCommandAgentConfiguration<TSpec> AgentConfiguration)
            => WorkCommand.CreateAgent(AgentConfiguration);

        public WorkCommandSupplier<TSpec>
            CreateSupplier(string partition, Func<int, IEnumerable<TSpec>> Provider)
                => WorkCommand.CreateSupplier(partition, Provider);

        public WorkCommandAgentObserver<TSpec> CreateObserver()
            => WorkCommand.CreateObserver<TSpec>();

        public WorkCommandAgentConfiguration<TSpec> Configure
            (
                WorkAgentSettings Settings,
                Action<IAppMessage> MessageReceiver,
                Action<TSpec> DefaultWorker = null,
                IReadOnlyList<IWorkCommandAgentObserver<TSpec>> DefaultObservers = null,
                IReadOnlyList<IWorkCommandSupplier<TSpec>> DefaultSuppliers = null

            )
            => new WorkCommandAgentConfiguration<TSpec>
            (
                Settings,
                MessageReceiver,
                DefaultWorker,
                DefaultObservers,
                DefaultSuppliers
            );

    }
}