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



    /// <summary>
    /// Encapsulates the data and algorithms that are needed to instatiate a work agent
    /// </summary>
    /// <typeparam name="W">The work item type</typeparam>
    public class WorkAgentConfiguration<W> : IWorkAgentConfiguration<W> where W : IPartitionedWork
    {


        static IAppMessage EmptyWorker() => AppMessage.Warn("I do nothing");

        public WorkAgentConfiguration
        (
            WorkAgentSettings Settings,
            Action<IAppMessage> MessageReceiver,
            Action<W> DefaultWorker = null,
            IReadOnlyList<IWorkAgentObserver<W>> DefaultObservers = null,
            IReadOnlyList<IWorkSupplier<W>> DefaultSuppliers = null

        )
        {
            this.Settings = Settings;
            this.MessageReceiver = MessageReceiver;
            this.DefaultWorker = DefaultWorker ?? (w => MessageReceiver(EmptyWorker()));
        }


        public WorkAgentSettings Settings { get; }

        /// <summary>
        /// The receiver to which messages are transmitted to communicate
        /// status, error conditions, etc.
        /// </summary>
        public Action<IAppMessage> MessageReceiver { get; }


        /// <summary>
        /// The work action
        /// </summary>
        public Action<W> DefaultWorker { get; }

        /// <summary>
        /// The observer that receives agent events if no overriding observer is specified
        /// </summary>
        public IReadOnlyList<IWorkAgentObserver<W>> DefaultObservers { get; }


        /// <summary>
        /// The default suppliers, if any, from which work will be pulled
        /// </summary>
        public IReadOnlyList<IWorkSupplier<W>> DefaultSuppliers { get; }

        Action<IPartitionedWork> IWorkAgentConfiguration.DefaultWorker
            => w => DefaultWorker((W)w);

        IReadOnlyList<IWorkAgentObserver> IWorkAgentConfiguration.DefaultObservers
            => DefaultObservers;

        IReadOnlyList<IWorkSupplier> IWorkAgentConfiguration.DefaultSuppliers
            => DefaultSuppliers;

    }

    public class WorkAgentConfiguration<W, R> : IWorkAgentConfiguration<W, R>
        where W : IPartitionedWork
    {

        static IAppMessage EmptyWorker() => AppMessage.Warn("I do nothing");


        public WorkAgentConfiguration
        (
            WorkAgentSettings Settings,
            Action<IAppMessage> MessageReceiver,
            Func<W, R> DefaultWorker = null,
            IReadOnlyList<IWorkAgentObserver<W, R>> DefaultObservers = null,
            IReadOnlyList<IWorkSupplier<W>> DefaultSuppliers = null
        )

        {
            this.Settings = Settings;
            this.MessageReceiver = MessageReceiver;
            this.DefaultWorker = DefaultWorker ?? (w =>
                {
                    MessageReceiver(EmptyWorker());
                    return default(R);
                });
            this.DefaultObservers = DefaultObservers;
            this.DefaultSuppliers = DefaultSuppliers;

        }

        public WorkAgentSettings Settings { get; }

        public Action<IAppMessage> MessageReceiver { get; }

        /// <summary>
        /// The work action
        /// </summary>
        public Func<W, R> DefaultWorker { get; }

        /// <summary>
        /// The observer that receives agent events if no overriding observer is specified
        /// </summary>
        public IReadOnlyList<IWorkAgentObserver<W, R>> DefaultObservers { get; }

        public IReadOnlyList<IWorkSupplier<W>> DefaultSuppliers { get; }

        Action<W> IWorkAgentConfiguration<W>.DefaultWorker
            => w => DefaultWorker(w);

        Action<IPartitionedWork> IWorkAgentConfiguration.DefaultWorker
            => w => DefaultWorker((W)w);

        IReadOnlyList<IWorkAgentObserver> IWorkAgentConfiguration.DefaultObservers
            => DefaultObservers;

        IReadOnlyList<IWorkSupplier> IWorkAgentConfiguration.DefaultSuppliers
            => DefaultSuppliers;

        IReadOnlyList<IWorkAgentObserver<W>> IWorkAgentConfiguration<W>.DefaultObservers
            => DefaultObservers;

    }
}