//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public interface IWorkAgentObserver
    {
        void RaiseGroupSubmitted(string groupName);

        void RaiseGroupCompleted(string groupName);

        void RaiseWorkSubmitted(IPartitionedWork work);

        void RaiseWorkDispatched(IPartitionedWork Work);

        void RaiseWorkCompleted(IPartitionedWork work);
    }

    public interface IWorkAgentObserver<W> : IWorkAgentObserver where W : IPartitionedWork
    {

        void RaiseWorkSubmitted(W work);

        void RaiseWorkDispatched(W Work);

        void RaiseWorkCompleted(W work);
    }

    public interface IWorkAgentObserver<W, R> : IWorkAgentObserver<W> where W : IPartitionedWork

    {
        void RaiseWorkCompleted(W work, R result);
    }


}