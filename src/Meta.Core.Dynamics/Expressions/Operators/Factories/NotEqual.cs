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

    public static class NotEqual<T>
    {
        static readonly Func<T, T, bool> _OP
            = lambda<T, T, bool>(Expression.NotEqual).Compile();

        public static bool Apply(T x, T y)
            => _OP(x, y);
    }
}