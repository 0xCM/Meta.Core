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

    public class CaseEnum<E, X, Y> : IEnumerable
       where E : Enum
    {
        public static void Example()
        {
            var ccc = new CaseEnum<TypeCode, int, string>
            {
                [TypeCode.Boolean] = i => $"{i}/Boolean",
                [TypeCode.Byte] = i => $"{i}/Byte",
                [TypeCode.DateTime] = i => $"{i}/DateTime"
            };
        }

        Dictionary<E, Func<X, Y>> Evaluators { get; }
            = new Dictionary<E, Func<X, Y>>();

        public void Add(E @case, Func<X, Y> whenMatched)
            => Evaluators.Add(@case, whenMatched);

        public Func<X, Y> this[E @case]
        {
            get { return Evaluators[@case]; }
            set { Add(@case, value); }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => Evaluators.GetEnumerator();

        public Y Eval(E @case, X x)
                => Evaluators.TryGetValue(@case, out Func<X, Y> f)
                ? f(x) : fail<Y>(PredicateUnsatisfied(true));

        public Option<Y> TryEval(E @case, X x)
            => Evaluators.TryGetValue(@case, out Func<X, Y> f)
            ? f(x) : none<Y>(PredicateUnsatisfied(true));
    }


}