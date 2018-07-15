//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;    

    public sealed class NodePipeline : NodePipeline<object,object>
    {
        class ChannelAdapter : IPipeline<object, object>
        {

            IPipeline Pipeline { get; }

            public ChannelAdapter(IPipeline Channel)
            {
                this.Pipeline = Pipeline;
            }
            object IPipeline<object, object>.Flow(object item)
                => Pipeline.Flow(item);

            Seq<object> IPipeline<object, object>.Flow(Seq<object> items)
                => Pipeline.Flow(items);

            object IPipeline.Flow(object item)
                => Pipeline.Flow(item);

            Seq<object> IPipeline.Flow(Seq<object> items)
                => Pipeline.Flow(items);
        }

        public NodePipeline(INodeEndpoint Source, INodeEndpoint Target, IPipeline Channel)
            : base(Source,Target, new ChannelAdapter(Channel))
        {

        }

    }
}