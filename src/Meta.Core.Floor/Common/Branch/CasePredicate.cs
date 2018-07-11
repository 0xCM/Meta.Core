//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    public class CasePredecate<X,Y> : IEnumerable
    {
        public int Example(int i)
            => (new CasePredecate<int, int>
            {
                [x => x % 2 == 0] = x => x * 2,
                [x => x % 3 == 0] = x => x * 3,
                [x => x % 5 == 0] = x => x * 5
            }).Evaluate(i);
        

        Dictionary<Func<X, bool>, Func<X, Y>> Evaluators { get; }
            = new Dictionary<Func<X, bool>, Func<X, Y>>();

        Dictionary<int, Func<X, bool>> Predicates { get; }
            = new Dictionary<int, Func<X, bool>>();

        int Next  = 0;

        public CasePredecate()
        {
            
        }

        public Func<X,Y> this[Func<X,bool> idx]
        {
            get { return Evaluators[idx]; }
            set { Add(idx, value); }
        }

        public void Add(Func<X,bool> predicate, Func<X,Y> whenTrue)
        {
            Evaluators.Add(predicate, whenTrue);
            Predicates[Next++] = predicate;
        }

        public Y Evaluate(X x)
        {
            for(var i=0; i< Next; i++)
            {
                var predicate = Predicates[i];
                if (predicate(x))
                    return Evaluators[predicate](x);
            }
            return fail<Y>(PredicateUnsatisfied(true));
        }

        public IEnumerator GetEnumerator()
            => Evaluators.GetEnumerator();
    }
}