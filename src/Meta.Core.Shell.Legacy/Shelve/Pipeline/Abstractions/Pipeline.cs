//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;
    

    public abstract class Pipeline<X,Y>  : ApplicationComponent, IPipeline<X,Y>
    {

        ITransformer<X,Y> TypedTransformer { get; }

        ITransformer UntypedTransformer { get; }

        public Pipeline(IApplicationContext C, ITransformer<X,Y> Transformer)
            : base(C)
        {
            this.TypedTransformer = Transformer;
            this.UntypedTransformer = Transformer;
        }

        public Pipeline(IApplicationContext C, ITransformer Transformer)
            : base(C)
        {
            this.UntypedTransformer = Transformer;
        }

        public Y Flow(X item)
            => Transform(item);

        public Seq<Y> Flow(Seq<X> items)
            => Transform(items);               

        object IPipeline.Flow(object item)
            => Transform(item);

        Seq<object> IPipeline.Flow(Seq<object> items)
           => Transform(items);

        Y Transform(X item)
            => isNull(TypedTransformer) 
            ? (Y)UntypedTransformer.Transform(item) 
            : TypedTransformer.Transform(item);

        Seq<Y> Transform(Seq<X> items)
            => isNull(TypedTransformer)             
            ? from y in UntypedTransformer.Transform(from i in items select cast<object>(i))
              select cast<Y>(y)            
             : TypedTransformer.Transform(items);

        object Transform(object item)
            => UntypedTransformer.Transform(item);

        Seq<object> Transform(Seq<object> items)
            => UntypedTransformer.Transform(items);
    }



}
