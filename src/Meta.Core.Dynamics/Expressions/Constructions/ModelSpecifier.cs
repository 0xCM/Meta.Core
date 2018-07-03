//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using X = System.Linq.Expressions;

    public class ModelSpecifier<T> : IModelSpecifier,
        IQueryable<T>, IQueryable,
        IEnumerable<T>, IEnumerable,
        IOrderedQueryable<T>, IOrderedQueryable
    {
        protected readonly IQueryProvider Provider;
        protected readonly Expression X;

        public ModelSpecifier(ModelQueryProvider Provider)
        {
            if (Provider == null)
                throw new ArgumentNullException("provider");

            this.Provider = Provider;
            this.X = Expression.Constant(this);
        }

        public ModelSpecifier(ModelQueryProvider Provider, Expression X)
        {
            if (X == null)
                throw new ArgumentNullException("expression");

            if (!typeof(IQueryable<T>).IsAssignableFrom(X.Type))
                throw new ArgumentOutOfRangeException("expression");

            this.Provider = Provider ?? throw new ArgumentNullException("provider");
            this.X = X;
        }

        Expression IQueryable.Expression
            => X;

        Type IQueryable.ElementType
            => typeof(T);

        IQueryProvider IQueryable.Provider
            => Provider;

        public IEnumerator<T> GetEnumerator()
            => ((IEnumerable<T>)Provider.Execute(X)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Provider.Execute(X)).GetEnumerator();

        object IModelSpecifier.SpecifyModel()
            => Provider.Execute(X);

        public override string ToString()
            => Provider.Execute(X).ToString();
    }

    public class ModelSpecifier<M, T> : ModelSpecifier<T>, IModelSpecifier<M>
    {
        public ModelSpecifier(ModelQueryProvider<M> provider)
            : base(provider)
        { }

        public ModelSpecifier(ModelQueryProvider<M> provider, Expression X)
            : base(provider, X)
        { }

        public M SpecifyModel()
            => (M)Provider.Execute(X);
    }

    public static class ModelSpecifier
    {
        public static ModelSpecifier<M, T> Create<M, T>(ModelQueryProvider<M> provider)
            => new ModelSpecifier<M, T>(provider);
    }
}