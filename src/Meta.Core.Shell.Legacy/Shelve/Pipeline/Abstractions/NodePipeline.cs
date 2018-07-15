//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public class NodePipeline<X, Y> : INodePipeline<X, Y>
    {
        IPipeline<X,Y> Channel { get; }


        INodeEndpoint<X> TypedSource { get; }

        INodeEndpoint<Y> TypedTarget { get; }

        public NodePipeline(INodeEndpoint Source, INodeEndpoint Target, IPipeline<X,Y> Channel)
        {
            this.UntypedSource = Source;
            this.UntypedTarget = Target;
            this.Channel = Channel;

        }

        public NodePipeline(INodeEndpoint<X> Source, INodeEndpoint<Y> Target, IPipeline<X, Y> Channel)
        {
            this.TypedSource = Source;
            this.UntypedSource = Source;
            this.TypedTarget = Target;
            this.UntypedTarget = TypedTarget;
            this.Channel = Channel;

        }

        INodeEndpoint UntypedSource { get; }

        INodeEndpoint UntypedTarget { get; }

        INodeEndpoint INodePipeline.Source
            => UntypedSource;

        INodeEndpoint INodePipeline.Target
            => UntypedTarget;

        Seq<object> IPipeline.Flow(Seq<object> items)
            => Channel.Flow(items);

        public Y Flow(X item)
            => Channel.Flow(item);

        public Seq<Y> Flow(Seq<X> items)
            => Channel.Flow(items);

        object IPipeline.Flow(object item)
            => Channel.Flow(item);
    }

}
