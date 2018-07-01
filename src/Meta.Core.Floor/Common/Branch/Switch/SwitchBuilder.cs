//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public class SwitchBuilder<X, Y>
    {
        public static implicit operator Switch<X, Y>(SwitchBuilder<X, Y> builder)
            => builder.Complete();

        MutableList<Case<X, Y>> Cases { get; }
           = MutableList.Create<Case<X, Y>>();
        

        public Builder<SwitchBuilder<X, Y>> Case(Func<X, bool> guard, Func<X, Y> f)
        {
            Cases.Add(new Case<X, Y>(guard, f));
            return this;
        }

        public Func<X, Y> Evaluator(Func<X, Y> Default)
            => x => Complete(Default).Eval(x);

        public SwitchD<X, Y> Complete(Func<X, Y> Default)
            => new SwitchD<X, Y>(Cases, Default);

        public Switch<X, Y> Complete()
            => new Switch<X, Y>(Cases);
    }

}