//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using static metacore;


    public static class PipelineX
    {
        public static ITransformer<X, Y> ToTransformer<X, Y>(this Func<X, Y> Effector)
               => new DelegatedTransformer<X, Y>(Effector);

        public static ITransformer<X, Y> ToTransformer<X, Y>(this Func<Seq<X>, Seq<Y>> Effector)
               => new DelegatedTransformer<X, Y>(Effector);

        public static Func<X, Y> ToEffector<X, Y>(ITransformer<X, Y> Transformer)
            => x => Transformer.Transform(x);

        public static IPipeline Pipeline(this IApplicationContext C, ITransformer Transformer)
                => new PipelineService(C, Transformer);

        public static IPipeline<X, Y> Pipeline<X, Y>(this IApplicationContext C, Func<X, Y> Effector)
            => new PipelineService<X, Y>(C, Effector.ToTransformer());

        public static IPipeline<X, Y> Pipeline<X, Y>(this IApplicationContext C, ITransformer<X, Y> Transformer)
            => new PipelineService<X, Y>(C, Transformer);
    }


}