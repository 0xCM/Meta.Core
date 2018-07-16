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

    public static class ByteOps
    {
        public static Expression<Func<byte, byte>> Abs
            => make((byte x) => x);

        public static Expression<Func<byte, byte, byte>> Add
            => make<byte>((x, y) => (byte)(x + y));

        public static Expression<Func<byte, byte, byte>> Sub
            => make<byte>((x, y) => (byte)(x - y));

        public static Expression<Func<byte, byte, byte>> Mul
            => make<byte>((x, y) => (byte)(x * y));

        public static Expression<Func<byte, byte>> Inc
            => make((byte x) => ++x);

        public static Expression<Func<byte, byte>> Dec
            => make((byte x) => --x);

        public static Expression<Func<byte, byte, bool>> LT
            => make((byte x, byte y) => x < y);

        public static Expression<Func<byte, byte, bool>> LTEQ
            => make((byte x, byte y) => x <= y);

        public static Expression<Func<byte, byte, bool>> GT
            => make((byte x, byte y) => x > y);

        public static Expression<Func<byte, byte, bool>> GTEQ
            => make((byte x, byte y) => x >= y);
    }

}