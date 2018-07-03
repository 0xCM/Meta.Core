//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq.Expressions;

    using static minicore;
    using static express;

    public static class Decrement<T>
    {
        static readonly Func<T, T> _OP
            = Construct();


        static Func<T, T> Construct()
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
        }


        public static T Apply(T x)
            => _OP(x);
    }
}