//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using X = System.Linq.Expressions;


    public abstract class ModelQueryProvider : IModelQueryProvider
    {

        static Type GetElementType(Type stype)
            => stype.CloseEnumerableType().Map(                
                    t => t.GetGenericArguments()[0], () => stype);

        protected ModelQueryProvider()
        {

        }

        protected abstract IQueryable<T> CreateQuery<T>(Expression X);

        IQueryable<T> IQueryProvider.CreateQuery<T>(Expression X) 
            => CreateQuery<T>(X);

        IQueryable IQueryProvider.CreateQuery(Expression X)
        {
            try
            {
                var et = GetElementType(X.Type);
                var specifierType = typeof(ModelSpecifier<,>).MakeGenericType(et, ModelType);
                return (IQueryable)Activator.CreateInstance(specifierType, new object[] { this, X });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        M IQueryProvider.Execute<M>(Expression X)
            => (M)Execute(X);

        object IQueryProvider.Execute(Expression X)
            => Execute(X);

        public M CreateModel<M>(Expression X, params SelectionFacet[] facets)
            => (M)Execute(X);

        protected abstract object Execute(Expression X, params SelectionFacet[] facets);

        public abstract Type ModelType { get; }

    }

    public class ModelQueryProvider<M> : ModelQueryProvider
    {
        protected readonly ExpressionModelFactory<M> F;

        public override Type ModelType => typeof(M);

        public ModelQueryProvider(ExpressionModelFactory<M> F)
        {
            this.F = F;
        }

        protected override IQueryable<T> CreateQuery<T>(Expression X)
            => new ModelSpecifier<M, T>(this, X);

        protected override object Execute(Expression X, params SelectionFacet[] facets)
            => F(X,facets);

    }
}