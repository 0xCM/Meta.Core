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


    public static class GreaterThanOrEqual<T>
    {
        static readonly Func<T, T, bool> _OP
            = Construct();

        static Func<T, T, bool> Construct()
        {

            switch (typecode<T>())
            {
                case TypeCode.Byte:
                    return cast<Func<T, T, bool>>(ByteOps.GTEQ.Compile());
                case TypeCode.SByte:
                    return cast<Func<T, T, bool>>(SByteOps.GTEQ.Compile());
                case TypeCode.UInt16:
                    return cast<Func<T, T, bool>>(UInt16Ops.GTEQ.Compile());

                default:
                    return lambda<T, T, bool>(Expression.GreaterThanOrEqual).Compile();
            }
        }


        public static bool Apply(T x, T y)
            => _OP(x, y);
    }


}