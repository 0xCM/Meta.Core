//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines a pseudo-random collection of utility methods
    /// </summary>
    static class CoreExtensions
    {
        static ConcurrentDictionary<Type, Type> _nnTypeCache = new ConcurrentDictionary<Type, Type>();

        public static string GroupValue(this Match m, string name)
        {
            if (!m.Groups[name].Success)
                throw new ArgumentException($"The group {name} was not matched successfully");

            return m.Groups[name].Value;
        }

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Type _GetNonNullableType(this Type t)
            => t.IsNullableType() ? Nullable.GetUnderlyingType(t) : t;

        /// <summary>
        /// If non-nullable, returns the supplied type. If nullable, returns the underlying type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static Type GetNonNullableType(this Type t)
            => _nnTypeCache.GetOrAdd(t, x => x._GetNonNullableType());

        //public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> items)
        //    => items.ToList();


    }


}
