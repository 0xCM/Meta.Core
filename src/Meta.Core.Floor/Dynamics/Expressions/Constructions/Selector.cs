//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Selector<T, Y>
    {
        IReadOnlyDictionary<T, Func<Y>> functions { get; }

        public static SelectionBuilder<T, Y> Define()
            => new SelectionBuilder<T, Y>();

        public Selector(IEnumerable<KeyValuePair<T, Func<Y>>> choices)
            => functions = choices.ToDictionary(x => x.Key, x => x.Value);
        
        public Y Select(T t)
            => functions[t]();
    }

    public class Selector<TCriterion, TInput, TResult>
    {
        IReadOnlyDictionary<TCriterion, Func<TInput, TResult>> functions { get; }

        public static SelectionBuilder<TCriterion, TInput, TResult> Define()
            => new SelectionBuilder<TCriterion, TInput, TResult>();

        public Selector(IEnumerable<KeyValuePair<TCriterion, Func<TInput, TResult>>> choices)
            => functions = choices.ToDictionary(x => x.Key, x => x.Value);

        public TResult Select(TCriterion t, TInput x) => functions[t](x);
    }
}