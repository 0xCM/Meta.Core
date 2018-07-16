//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static FuncExpression;

    public static class SByteOps
    {
        public static Expression<Func<sbyte, sbyte>> Abs
            => make((sbyte x) => x < 0 ? (sbyte) -x : x);

        public static Expression<Func<sbyte, sbyte, sbyte>> Add
            => make<sbyte>((x, y) => (sbyte)(x + y));

        public static Expression<Func<sbyte, sbyte, sbyte>> Mul
            => make<sbyte>((x, y) => (sbyte)(x * y));

        public static Expression<Func<sbyte, sbyte, sbyte>> Sub
            => make<sbyte>((x, y) => (sbyte)(x - y));

        public static Expression<Func<sbyte, sbyte>> Inc
            => make((sbyte x) => ++x);

        public static Expression<Func<sbyte, sbyte>> Dec
            => make((sbyte x) => --x);

        public static Expression<Func<sbyte, sbyte, bool>> GT
            => make((sbyte x, sbyte y) => x > y);

        public static Expression<Func<sbyte, sbyte, bool>> GTEQ
            => make((sbyte x, sbyte y) => x >= y);

        public static Expression<Func<sbyte, sbyte, bool>> LT
            => make((sbyte x, sbyte y) => x < y);

        public static Expression<Func<sbyte, sbyte, bool>> LTEQ
            => make((sbyte x, sbyte y) => x <= y);

    }


}