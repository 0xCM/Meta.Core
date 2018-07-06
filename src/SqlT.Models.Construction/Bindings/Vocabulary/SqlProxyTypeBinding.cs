//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;

    public class SqlProxyTypeBinding : ISqlProxyTypeBinding
    {
        public static SqlProxyTypeBinding<P, B> Define<P, B>()
            where P : class, ISqlProxy, new()
                => new SqlProxyTypeBinding<P, B>();

        public static SqlMessageFormatBinding<P> BindFormat<P>(TypedMessageFormat Format)
            where P : class, ISqlProxy, new()
            => new SqlMessageFormatBinding<P>(Format);

        public static SqlEnumBinding<T,E> BindEnum<T,E>()
            where T : class, ISqlTabularProxy, new()
        {
            switch (Type.GetTypeCode(typeof(E).GetEnumUnderlyingType()))
            {
                case TypeCode.Byte:
                    return new SqlUInt8EnumBinding<T, E>();
                case TypeCode.SByte:
                    return new SqlInt8EnumBinding<T, E>();
                case TypeCode.Int16:
                    return new SqlInt16EnumBinding<T, E>();
                case TypeCode.UInt16:
                    return new SqlUInt16EnumBinding<T, E>();
                case TypeCode.Int32:
                    return new SqlInt32EnumBinding<T, E>();
                case TypeCode.UInt32:
                    return new SqlUInt32EnumBinding<T, E>();
                case TypeCode.Int64:
                    return new SqlInt64EnumBinding<T, E>();
                case TypeCode.UInt64:
                    return new SqlUInt64EnumBinding<T, E>();
                default:
                    throw new NotSupportedException();
            }            

        }

        public SqlProxyTypeBinding(Type ProxyType, Type BoundType)
        {
            this.ProxyType = ProxyType;
            this.BoundType = BoundType;
        }

        public Type ProxyType { get; }

        public Type BoundType { get; }

        public override string ToString()
            => $"${ProxyType} <=> {BoundType}";
    }

    public class SqlProxyTypeBinding<P> : SqlProxyTypeBinding
        where P : class, ISqlProxy, new()
    {
        public SqlProxyTypeBinding(Type BoundType)
            : base(typeof(P), BoundType)
        {

        }
    }

    public class SqlProxyTypeBinding<P, B> : SqlProxyTypeBinding
        where P : class, ISqlProxy, new()
    {
        public SqlProxyTypeBinding()
            : base(typeof(P), typeof(B))
        {

        }
    }
}
