//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    

    public class SelectionBuilder<T, X, Y>
    {
        public static implicit operator Selector<T, X, Y>(SelectionBuilder<T, X, Y> builder)
            => builder.Finish();

        private Dictionary<T, Func<X, Y>> functions = new Dictionary<T, Func<X, Y>>();
        private readonly T t;
        private readonly X x;

        public SelectionBuilder()
        {

        }

        public SelectionBuilder(T t, X x)
        {
            this.t = t;
            this.x = x;
        }

        public SelectionBuilder<T, X, Y> When(T t, Func<X, Y> f)
        {
            functions[t] = f;
            return this;
        }

        public Selector<T, X, Y> Finish()
            => new Selector<T, X, Y>(functions);

        public Y Eval(T t, X x)
            => Finish().Select(t, x);

        public Y Eval() => Finish().Select(t, x);


    }

    public class SelectionBuilder<TCriterion, TResult>
    {
        public static implicit operator Selector<TCriterion, TResult>(SelectionBuilder<TCriterion, TResult> builder) => builder.Finish();

        private Dictionary<TCriterion, Func<TResult>> functions = new Dictionary<TCriterion, Func<TResult>>();
        private readonly TCriterion t;

        public SelectionBuilder()
        {

        }

        public SelectionBuilder(TCriterion t)
        {
            this.t = t;
        }

        public SelectionBuilder<TCriterion, TResult> When(TCriterion t, Func<TResult> f)
        {
            functions[t] = f;
            return this;
        }

        public Selector<TCriterion, TResult> Finish()
            => new Selector<TCriterion, TResult>(functions);

        public TResult Eval(TCriterion t)
            => Finish().Select(t);

        public TResult Eval()
            => Finish().Select(t);

    }





}