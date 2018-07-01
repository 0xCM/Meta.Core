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

    using N = SystemNodeIdentifier;

    using static metacore;

    public abstract class NodeEventObserver : NodeComponent, INodeEventObserver
    {
        protected NodeEventObserver(INodeContext C)
            : base(C)
        {

        }

        protected abstract void Observe(INodeEvent Event);

        void INodeEventObserver.Observe(INodeEvent Event)
            => Observe(Event);
    }


    public abstract class NodeEventObserver<E,R> : NodeEventObserver, INodeEventObserver<E>
        where E : INodeEvent
    {

        protected NodeEventObserver(INodeContext C)
            : base(C)
        {

        }

        protected override sealed void Observe(INodeEvent Event)
            => Observe((E)Event);

        public abstract void Observe(E Event);
    }


}