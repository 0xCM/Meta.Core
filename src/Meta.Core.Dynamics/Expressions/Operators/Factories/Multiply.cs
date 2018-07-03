//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
      
    using static minicore;
    using static express;


    public static class Multiply<T>
    {
        static readonly Func<T, T, T> _OP
            = Construct();


        static Func<T, T, T> Construct()
        {

            switch (typecode<T>())
            {

                case TypeCode.String:
                    return funcx(method<T, T, T>(nameof(String.Concat)).Require().Func<T, T, T>()).Compile();
                case TypeCode.Byte:
                    return cast<Func<T, T, T>>(ByteOps.Mul.Compile());
                case TypeCode.SByte:
                    return cast<Func<T, T, T>>(SByteOps.Mul.Compile());
                case TypeCode.UInt16:
                    return cast<Func<T, T, T>>(UInt16Ops.Mul.Compile());
                default:
                    return lambda<T, T, T>(Expression.Multiply).Compile();

            }
        }

        public static T Apply(T x, T y)
            => _OP(x, y);
    }

    public static class MultiplyChecked<T>
    {
        static readonly Func<T, T, T> _OP
            = lambda<T, T, T>(Expression.MultiplyChecked).Compile();

        public static T Apply(T x, T y)
            => _OP(x, y);
    }


}