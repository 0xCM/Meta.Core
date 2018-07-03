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
    using System.Reflection;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines utility methods that facilitate efficient dynamic method invocation without
    /// the overhead of reflection
    /// </summary>
    public static class Conversion
    {
        /// <summary>
        /// Creates non-contextual projector from a function
        /// </summary>
        /// <typeparam name="TSrc">The function domain type</typeparam>
        /// <typeparam name="TDst">The function codomain type</typeparam>
        /// <param name="f">The function</param>
        /// <returns></returns>
        public static Converter FromFunction<TSrc, TDst>(Func<TSrc, TDst> f)
            => new Converter(o => f((TSrc)o));

        /// <summary>
        /// Creates a weakly-typed and non-generic static projection delegate from a method
        /// defining two parameters such that:
        /// 1. The first parameter is an instance of the type <paramref name="contextType"/>
        /// 2. The second paramter is the conversion source type
        /// </summary>
        /// <param name="m">The method for which a projector will be created</param>
        /// <returns></returns>
        internal static ContextualConverter ToContextualConverter(this MethodInfo m, Type contextType)
        {
            var ctx = Expression.Parameter(contextType, "context");
            var src = Expression.Parameter(typeof(object), "src");
            var convert = Expression.Convert(src, m.GetParameters()[1].ParameterType);
            var callResult = Expression.Call(null, m, ctx, convert);
            var result = Expression.Convert(callResult, typeof(object));
            return Expression.Lambda<ContextualConverter>(result, ctx, src).Compile();
        }

        /// <summary>
        /// Creates a weakly-typed and non-generic static projection delegate from a method
        /// defining two parameters such that:
        /// 1. The first parameter is an instance of a type that realizes the <see cref="IApplicationContext"/> interface
        /// 2. The second paramter is the conversion source type
        /// </summary>
        /// <param name="m">The method for which a projector will be created</param>
        /// <returns></returns>
        internal static ContextualConverter ToContextualConverter(this MethodInfo m)
        {
            var ctx = Expression.Parameter(typeof(IApplicationContext), "ctx");
            var src = Expression.Parameter(typeof(object), "src");
            var convert = Expression.Convert(src, m.GetParameters()[1].ParameterType);
            var callResult = Expression.Call(null, m, ctx, convert);
            var result = Expression.Convert(callResult, typeof(object));
            return Expression.Lambda<ContextualConverter>(result, ctx, src).Compile();
        }

        /// <summary>
        /// Creates a strongly-typed contextual projector
        /// </summary>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        /// <param name="m">The method on which the projector will be based</param>
        /// <returns></returns>
        internal static ContextualConverter<X, Y> ToContextualConverter<X, Y>(this MethodInfo m)
        {
            var ctx = Expression.Parameter(typeof(IApplicationContext), "ctx");
            var src = Expression.Parameter(typeof(X), "src");
            var callResult = Expression.Call(null, m, ctx, src);
            return Expression.Lambda<ContextualConverter<X, Y>>(callResult, ctx, src).Compile();
        }


    }

}