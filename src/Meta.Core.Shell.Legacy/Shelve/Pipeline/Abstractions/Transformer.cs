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

    public abstract class Transformer<X,Y>  : ITransformer<X,Y>
    {
        public abstract Y Transform(X item);

        public virtual Seq<Y> Transform(Seq<X> items)
            => from item in items
               select Transform(item);

        object ITransformer.Transform(object item)
            => Transform((X)item);

        Seq<object> ITransformer.Transform(Seq<object> items)
           => from item in items
              select Transform((X)item) as object;
    }
}
