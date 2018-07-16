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

    public class UInt16Ops
    {
        public static Expression<Func<ushort, ushort>> Abs
            => make((ushort x) => x);

        public static Expression<Func<ushort, ushort, ushort>> Add
            => make<ushort>((x, y) => (ushort)(x + y));

        public static Expression<Func<ushort, ushort, ushort>> Mul
            => make<ushort>((x, y) => (ushort)(x * y));

        public static Expression<Func<ushort, ushort, ushort>> Sub
            => make<ushort>((x, y) => (ushort)(x - y));

        public static Expression<Func<ushort, ushort>> Inc
            => make((ushort x) => ++x);

        public static Expression<Func<ushort, ushort>> Dec
            => make((ushort x) => --x);

        public static Expression<Func<ushort, ushort, bool>> LT
            => make((ushort x, ushort y) => x < y);

        public static Expression<Func<ushort, ushort, bool>> LTEQ
            => make((ushort x, ushort y) => x <= y);

        public static Expression<Func<ushort, ushort, bool>> GT
            => make((ushort x, ushort y) => x > y);

        public static Expression<Func<ushort, ushort, bool>> GTEQ
            => make((ushort x, ushort y) => x >= y);

    }
}