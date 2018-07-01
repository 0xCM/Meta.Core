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

    readonly struct ListExtend<X, Y> : IExtend<X, List<X>, Y, List<Y>>
    {
        public Func<List<X>, List<Y>> extend(Func<List<X>, Y> f)
        {
            throw new NotImplementedException();
        }

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => O.fmap.list<X, Y>().fmap(f);
    }


}