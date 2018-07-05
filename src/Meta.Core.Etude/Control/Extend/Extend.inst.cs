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

    readonly struct ListExtend<X, Y> : IExtend<X, Lst<X>, Y, Lst<Y>>
    {
        public Func<Lst<X>, Lst<Y>> extend(Func<Lst<X>, Y> f)
        {
            throw new NotImplementedException();
        }

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => List.Functor<X,Y>().fmap(f);
    }


}