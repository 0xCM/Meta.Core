//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using G = System.Collections.Generic;
    using System.Reflection;
    using Modules;

    using static metacore;

    public static class Switch
    {
        public static Builder<SwitchBuilder<X, Y>> build<X, Y>()
            => new SwitchBuilder<X, Y>();

        public static Builder<Switch<X, Y, Z>> build<X, Y, Z>()
            => new Switch<X, Y, Z>();

    }

    public readonly struct Switch<X,Y>
    {            
        Lst<Case<X,Y>> Cases { get; }

        public Switch(G.IEnumerable<Case<X, Y>> Cases)
        {
            this.Cases = Lst.make(Cases);
        }
       
        public Option<Y> Eval(X x)
        {
            foreach(var c in Cases.Stream())
            {
                var eval = c.Eval(x);
                if (eval)
                    return eval;
            }
            return none<Y>();
        }

    }

    public readonly struct SwitchD<X,Y>
    {
        Lst<Case<X, Y>> Cases { get; }

        Func<X, Y> Default { get; }

        public SwitchD(G.IEnumerable<Case<X, Y>> Cases, Func<X, Y> @default)
        {
            this.Cases = Lst.make(Cases);
            this.Default = @default;
        }

        public Y Eval(X x)
        {
            foreach(var c in Cases.Stream())
            {
                var eval = c.Eval(x);
                if (eval)
                    return eval.Require();
            }
            return Default(x);            
        }

    }

    public class Switch<X, Y, Z>
    {
        G.Dictionary<(X x, Y y), Func<X, Y, Z>> Cases { get; }
            = new G.Dictionary<(X x, Y y), Func<X, Y, Z>>();

        public Builder<Switch<X, Y, Z>> Case((X x, Y y) guard, Func<X, Y, Z> f)
        {
            Cases.Add(guard, f);
            return this;
        }

        public Func<X, Y, Option<Z>> Evaluator()
            => (x, y) => from c in Cases.TryFind((x, y))
                         select c(x, y);

        public Func<X, Y, Z> Evaluator(Func<X, Y, Z> @default)
            => (x, y) => Cases.TryFind((x, y)).Map(c => c(x, y), () => @default(x, y));

    }


}