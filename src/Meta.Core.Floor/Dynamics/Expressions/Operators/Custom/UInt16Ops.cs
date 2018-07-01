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
        public static Expression<Func<ushort, ushort, ushort>> Add
            => make<ushort>((x, y) => (ushort)(x + y));

        public static Expression<Func<ushort, ushort, ushort>> Mul
            => make<ushort>((x, y) => (ushort)(x * y));

        public static Expression<Func<ushort, ushort, ushort>> Sub
            => make<ushort>((x, y) => (ushort)(x - y));
    }
}