//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generic specialization of the <see cref="WorkAgentConfiguration{W}"/> class for use with
    /// <see cref="WorkCommand{TSpec}"/> commands
    /// </summary>
    /// <typeparam name="TSpec"></typeparam>
    public sealed class WorkCommandAgentConfiguration<TSpec> : WorkAgentConfiguration<WorkCommand<TSpec>>
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommandAgentConfiguration
        (
            WorkAgentSettings Settings,
            Action<IAppMessage> MessageReceiver,
            Action<TSpec> DefaultWorker = null,
            IReadOnlyList<IWorkCommandAgentObserver<TSpec>> DefaultObservers = null,
            IReadOnlyList<IWorkCommandSupplier<TSpec>> DefaultSuppliers = null
           ) : base
            (
               Settings,
               MessageReceiver,
               w => DefaultWorker?.Invoke(w.Command),
               DefaultObservers,
               DefaultSuppliers
            )
        { }

    }
}