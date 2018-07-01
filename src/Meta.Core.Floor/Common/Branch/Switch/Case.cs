//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    public static class Case
    {
        public static Case<X, Y> Define<X, Y>(Func<X, bool> guard, Func<X, Y> f)
            => new Case<X, Y>(guard, f);

        public static IEnumerable<Case<X, Y>> Define<X, Y>(params (Func<X, bool> guard, Func<X, Y> f)[] terms)
            => terms.Map(t => Define(t.guard, t.f));
    }

    public readonly struct Case<X, Y>
    {
        public Case(Func<X, bool> guard, Func<X, Y> f)
        {
            this.Guard = guard;
            this.Expression = f;
        }

        public Func<X, bool> Guard { get; }

        public Func<X, Y> Expression { get; }

        public Option<Y> Eval(X x)
            => Guard(x) ? some(Expression(x)) : none<Y>();
    }
}