//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    using static metacore;

    public class DelegatedTransformer<X, Y> : ITransformer<X, Y>
    {
        Func<X,Y> Effector { get; }

        Func<Seq<X>, Seq<Y>> MultiEffector { get; }

        public DelegatedTransformer(Func<X,Y> Effector)
        {
            this.Effector = Effector;
            this.MultiEffector = x => Seq.map(Effector, x);
        }

        public DelegatedTransformer(Func<Seq<X>, Seq<Y>> MultiEffector)
        {
            this.MultiEffector = MultiEffector;
            this.Effector = x => MultiEffector(Seq.cons(x)).Stream().First();
        }

        public Y Transform(X item)
            => Effector(item);

        public Seq<Y> Transform(Seq<X> items)
            => MultiEffector(items); 

        object ITransformer. Transform(object item)
            => Transform((X)item);

        Seq<object> ITransformer.Transform(Seq<object> items)
            => from y in Seq.map(x => Transform((X)x), items)
               select (object)y;
               
    }
}
