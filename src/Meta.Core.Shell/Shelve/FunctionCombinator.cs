//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    

    public static class FunctionCombinator
    {
        public static Func<X, Z> Pipeline<X, Y, Z>(Func<X, Y> f, Func<Y, Z> g)
            => x => g(f(x));

        public static Func<X,Y> Pipeline<X,Y>(Func<X,X> f, Func<X,Y> g)
            => x => g(f(x));

        public static Func<X, Y> Pipeline<X, Y>(Func<X, Y> f, Func<Y, Y> g)
            => x => g(f(x));

        public static Func<X, Y> Branch<X, Y>(Func<X, bool> predicate, Func<X, Y> f, Func<X, Y> g)
            => x => predicate(x) ? f(x) : g(x);    

        public static Func<X, Y> Observe<X, Y>(Action<X> before, Func<X, Y> f, Action<Y> after)
            => x =>
            {
                before(x);
                var result = f(x);
                after(f(x));
                return result;
            };
            

    }


}