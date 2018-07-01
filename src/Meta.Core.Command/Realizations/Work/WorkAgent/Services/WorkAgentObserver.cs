//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;



    public class WorkAgentObserver : IWorkAgentObserver
    {
        public WorkAgentObserver
        (
            WorkSubmitted WorkSubmitted,
            WorkDispatched WorkDispatched,
            WorkCompleted WorkCompleted
        )
        {
            this.WorkSubmitted = WorkSubmitted;
            this.WorkDispatched = WorkDispatched;
            this.WorkCompleted = WorkCompleted;
        }

        public WorkAgentObserver
        (
            WorkGroupSubmitted GroupSubmitted = null,
            WorkGroupCompleted GroupCompleted = null,
            WorkSubmitted WorkSubmitted = null,
            WorkDispatched WorkDispatched = null,
            WorkCompleted WorkCompleted = null
        )
        {
            this.GroupSubmitted = GroupSubmitted;
            this.GroupCompleted = GroupCompleted;
            this.WorkSubmitted = WorkSubmitted;
            this.WorkDispatched = WorkDispatched;
            this.WorkCompleted = WorkCompleted;
        }


        public WorkGroupSubmitted GroupSubmitted { get; }
        public WorkGroupCompleted GroupCompleted { get; }
        WorkSubmitted WorkSubmitted { get; }
        WorkDispatched WorkDispatched { get; }
        WorkCompleted WorkCompleted { get; }

        protected virtual void OnGroupSubmitted(string groupName)
            => GroupSubmitted?.Invoke(groupName);

        protected virtual void OnGroupCompleted(string groupName)
            => GroupCompleted?.Invoke(groupName);

        public void RaiseGroupSubmitted(string groupName)
            => OnGroupSubmitted(groupName);

        public void RaiseGroupCompleted(string groupName)
            => OnGroupCompleted(groupName);

        public void RaiseWorkSubmitted(IPartitionedWork work)
           => WorkSubmitted?.Invoke(work);

        public void RaiseWorkDispatched(IPartitionedWork work)
            => WorkDispatched?.Invoke(work);

        public void RaiseWorkCompleted(IPartitionedWork work)
            => WorkCompleted?.Invoke(work);
    }

    /// <summary>
    /// Receives messages from the agent during the course of executing a work unit
    /// </summary>
    /// <typeparam name="W"></typeparam>
    public class WorkAgentObserver<W> : WorkAgentObserver, IWorkAgentObserver<W>
        where W : IPartitionedWork
    {

        public WorkAgentObserver
        (
            WorkSubmitted<W> WorkSubmitted,
            WorkDispatched<W> WorkDispatched,
            WorkCompleted<W> WorkCompleted
        ) : base(w => WorkSubmitted((W)w), w => WorkDispatched((W)w), w => WorkCompleted((W)w))
        {
            this.WorkSubmitted = WorkSubmitted;
            this.WorkDispatched = WorkDispatched;
            this.WorkCompleted = WorkCompleted;
        }

        public WorkAgentObserver
        (
            WorkGroupSubmitted GroupSubmitted = null,
            WorkGroupCompleted GroupCompleted = null,
            WorkSubmitted<W> WorkSubmitted = null,
            WorkDispatched<W> WorkDispatched = null,
            WorkCompleted<W> WorkCompleted = null
        ) : base
        (
            GroupSubmitted,
            GroupCompleted,
            w => WorkSubmitted?.Invoke((W)w),
            w => WorkDispatched?.Invoke((W)w),
            w => WorkCompleted?.Invoke((W)w))
        {
            this.WorkSubmitted = WorkSubmitted;
            this.WorkDispatched = WorkDispatched;
            this.WorkCompleted = WorkCompleted;
        }


        WorkSubmitted<W> WorkSubmitted { get; }
        WorkDispatched<W> WorkDispatched { get; }
        WorkCompleted<W> WorkCompleted { get; }

        public void RaiseWorkSubmitted(W work)
            => OnWorkSubmitted(work);

        public void RaiseWorkDispatched(W work)
            => OnWorkDispatched(work);

        public void RaiseWorkCompleted(W work)
            => OnWorkCompleted(work);

        protected virtual void OnWorkSubmitted(W work)
            => WorkSubmitted?.Invoke(work);

        protected virtual void OnWorkDispatched(W Work)
            => WorkDispatched?.Invoke(Work);

        protected virtual void OnWorkCompleted(W work)
            => WorkCompleted?.Invoke(work);

        void IWorkAgentObserver.RaiseWorkSubmitted(IPartitionedWork work)
            => RaiseWorkSubmitted((W)work);

        void IWorkAgentObserver.RaiseWorkDispatched(IPartitionedWork work)
            => RaiseWorkDispatched((W)work);

        void IWorkAgentObserver.RaiseWorkCompleted(IPartitionedWork work)
            => RaiseWorkCompleted((W)work);

    }

    public class WorkAgentObserver<W, R> : WorkAgentObserver<W>, IWorkAgentObserver<W, R>
        where W : IPartitionedWork
    {


        public WorkAgentObserver
        (
            WorkGroupSubmitted GroupSubmitted = null,
            WorkGroupCompleted GroupCompleted = null,
            WorkSubmitted<W> WorkSubmitted = null,
            WorkDispatched<W> WorkDispatched = null,
            WorkCompleted<W, R> WorkCompleted = null
        ) : base(GroupSubmitted, GroupCompleted, WorkSubmitted, WorkDispatched)

        {
            this.WorkCompleted = WorkCompleted;
        }

        WorkCompleted<W, R> WorkCompleted { get; }

        public void RaiseWorkCompleted(W work, R result)
            => OnWorkCompleted(work, result);

        protected virtual void OnWorkCompleted(W work, R result)
            => WorkCompleted?.Invoke(work, result);

        protected override void OnWorkCompleted(W work)
            => WorkCompleted?.Invoke(work, default(R));


    }
}