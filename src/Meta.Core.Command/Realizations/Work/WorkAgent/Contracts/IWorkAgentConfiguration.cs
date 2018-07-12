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

    using static metacore;


    public interface IWorkAgentConfiguration
    {
        WorkAgentSettings Settings { get; }

        /// <summary>
        /// The receiver to which messages are transmitted to communicate
        /// status, error conditions, etc.
        /// </summary>
        Action<IAppMessage> MessageReceiver { get; }


        /// <summary>
        /// The work action
        /// </summary>
        Action<IPartitionedWork> DefaultWorker { get; }

        /// <summary>
        /// The observer that receives agent events if no overriding observer is specified
        /// </summary>
        IReadOnlyList<IWorkAgentObserver> DefaultObservers { get; }

        /// <summary>
        /// The default suppliers, if any, from which work will be pulled
        /// </summary>
        IReadOnlyList<IWorkSupplier> DefaultSuppliers { get; }

    }

    public interface IWorkAgentConfiguration<W> : IWorkAgentConfiguration
        where W : IPartitionedWork
    {
        new Action<W> DefaultWorker { get; }

        new IReadOnlyList<IWorkAgentObserver<W>> DefaultObservers { get; }

        new IReadOnlyList<IWorkSupplier<W>> DefaultSuppliers { get; }

    }

    public interface IWorkAgentConfiguration<W, out R> : IWorkAgentConfiguration<W>
        where W : IPartitionedWork
    {
        new Func<W, R> DefaultWorker { get; }

    }

}