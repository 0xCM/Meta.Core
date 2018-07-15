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

    public abstract class NodeEventHandler : NodeComponent, INodeEventHandler
    {
        protected NodeEventHandler(INodeContext C)
            : base(C)
        {

        }

        protected abstract Option<object> Handle(INodeEvent Event);

        Option<object> INodeEventHandler.Handle(INodeEvent Event)
            => Handle(Event);
    }


    public abstract class NodeEventHandler<E,R> : NodeEventHandler, INodeEventHandler<E,R>
        where E : INodeEvent
    {

        protected NodeEventHandler(INodeContext C)
            : base(C)
        {

        }

        protected override sealed Option<object> Handle(INodeEvent Event)
            => Handle((E)Event);

        public abstract Option<R> Handle(E Event);
    }


}