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

    public static class Increment<T>
    {
        static readonly Func<T, T> _OP
            = Construct();


        static Func<T, T> Construct()
        {

            switch (typecode<T>())
            {
                case TypeCode.Byte:
                    return cast<Func<T, T>>(ByteOps.Inc.Compile());
                case TypeCode.SByte:
                    return cast<Func<T, T>>(SByteOps.Inc.Compile());
                case TypeCode.UInt16:
                    return cast<Func<T, T>>(UInt16Ops.Inc.Compile());

                default:
                    return lambda<T, T>(Expression.Increment).Compile();
            }
        }


        public static T Apply(T x)
            => _OP(x);
    }
}