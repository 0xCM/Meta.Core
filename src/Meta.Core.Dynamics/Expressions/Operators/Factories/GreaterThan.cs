//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq.Expressions;

    using static minicore;
    using static express;

    public static class GreaterThan<T>
    {
        static readonly Option<Func<T, T, bool>> _OPSafe
            = TryConstruct();

        static Func<T, T, bool> _OP
            => _OPSafe.Require();


        static Option<Func<T, T, bool>> TryConstruct()
            => Try(() =>
            {
                switch (typecode<T>())
                {
                    case TypeCode.Byte:
                        return cast<Func<T, T, bool>>(ByteOps.GT.Compile());
                    case TypeCode.SByte:
                        return cast<Func<T, T, bool>>(SByteOps.GT.Compile());
                    case TypeCode.UInt16:
                        return cast<Func<T, T, bool>>(UInt16Ops.GT.Compile());
                    default:
                        return lambda<T, T, bool>(Expression.GreaterThan).Compile();
                }
            });


        /// <summary>
        /// Specifies whether the operator exists for <typeparamref name="T"/>
        /// </summary>
        public static bool Exists
            => _OPSafe.IsSome();

        public static bool Apply(T x, T y)
            => _OP(x, y);
    }
}