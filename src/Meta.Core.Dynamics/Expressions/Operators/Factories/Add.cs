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

    using static minicore;
    using static express;

    public static class Add<T>
    {

        static readonly Option<Func<T, T, T>> _OPSafe
            = TryConstruct();

        static Func<T, T, T> _OP
            => _OPSafe.Require();

        static Option<Func<T, T, T>> TryConstruct()
            => Try(() =>
            {
                switch (typecode<T>())
                {

                    case TypeCode.String:
                        return funcx(method<T, T, T>(nameof(String.Concat)).Require().Func<T, T, T>()).Compile();
                    case TypeCode.Byte:
                        return cast<Func<T, T, T>>(ByteOps.Add.Compile());
                    case TypeCode.SByte:
                        return cast<Func<T, T, T>>(SByteOps.Add.Compile());
                    case TypeCode.UInt16:
                        return cast<Func<T, T, T>>(UInt16Ops.Add.Compile());
                    default:
                        return lambda<T, T, T>(Expression.Add).Compile();
                }
            });


        /// <summary>
        /// Specifies whether the operator exists for <typeparamref name="T"/>
        /// </summary>
        public static bool Exists
            => _OPSafe.IsSome();

        public static T Apply(T x, T y)
            => _OP(x, y);
    }

    public static class AddChecked<T>
    {
        static readonly Func<T, T, T> _OP
            = lambda<T, T, T>(Expression.AddChecked).Compile();

        public static T Apply(T x, T y)
            => _OP(x, y);
    }
}