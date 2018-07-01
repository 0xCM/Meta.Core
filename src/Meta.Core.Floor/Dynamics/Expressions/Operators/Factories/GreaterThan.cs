﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq.Expressions;

    using static metacore;

    public static class GreaterThan<T>
    {

        static Func<T, T, bool> Construct()
        {

            switch (typecode<T>())
            {
                case TypeCode.Byte:
                    return cast<Func<T, T, bool>>(ByteOps.GT.Compile());
                case TypeCode.SByte:
                    return cast<Func<T, T, bool>>(SByteOps.GT.Compile());
                default:
                    return lambda<T, T, bool>(Expression.GreaterThan).Compile();
            }
        }

        static readonly Func<T, T, bool> _OP
            = Construct();

        public static bool Apply(T x, T y)
            => _OP(x, y);
    }


}