//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static express;

    public static class Negate<T>
    {
        static readonly Func<T, T> _OP
            = lambda<T, T>(Expression.Negate).Compile();

        public static T Apply(T x)
            => _OP(x);
    }

    public static class NegateChecked<T>
    {
        static readonly Func<T, T> _OP
            = lambda<T, T>(Expression.NegateChecked).Compile();

        public static T Apply(T x)
            => _OP(x);
    }


}