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

    public static class Decrement<T>
    {
        static readonly Option<Func<T, T>> _OPSafe
            = TryConstruct();

        static Func<T, T> _OP
            => _OPSafe.Require();


        static Option<Func<T, T>> TryConstruct()
            => Try(() =>
            {

                switch (typecode<T>())
                {
                    case TypeCode.Byte:
                        return cast<Func<T, T>>(ByteOps.Dec.Compile());
                    case TypeCode.SByte:
                        return cast<Func<T, T>>(SByteOps.Dec.Compile());
                    case TypeCode.UInt16:
                        return cast<Func<T, T>>(UInt16Ops.Dec.Compile());

                    default:
                        return lambda<T, T>(Expression.Decrement).Compile();
                }
            });

        /// <summary>
        /// Specifies whether the operator exists for <typeparamref name="T"/>
        /// </summary>
        public static bool Exists
            => _OPSafe.IsSome();

        public static T Apply(T x)
            => _OP(x);
    }
}