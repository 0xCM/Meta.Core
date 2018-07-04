//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;

    /// <summary>
    /// Binds a CLR enum type to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public abstract class SqlEnumBinding<T, B> : SqlProxyTypeBinding
        where T : class, ISqlTabularProxy, new()

    {
        protected SqlEnumBinding(Type UnderlyingType)
            : base(typeof(T), typeof(B))
        {
            this.EnumUnderlyingType = UnderlyingType;
        }

        public Type EnumUnderlyingType { get; }           
    }

    /// <summary>
    /// Binds a CLR enum type to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    /// <typeparam name="U">The underlying enumeration type</typeparam>
    public abstract class SqlEnumBinding<T, B, U> : SqlEnumBinding<T,B>
        where T : class, ISqlTabularProxy, new()
    {
        public SqlEnumBinding()
            : base(typeof(U))
        {

        }
    }

    /// <summary>
    /// Binds a CLR byte enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlUInt8EnumBinding<T,B> : SqlEnumBinding<T,B,byte>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR sbyte enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlInt8EnumBinding<T, B> : SqlEnumBinding<T, B, sbyte>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR ushort enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlUInt16EnumBinding<T, B> : SqlEnumBinding<T, B, ushort>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR short enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlInt16EnumBinding<T, B> : SqlEnumBinding<T, B, short>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR int enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlInt32EnumBinding<T, B> : SqlEnumBinding<T, B, int>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR uint enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlUInt32EnumBinding<T, B> : SqlEnumBinding<T, B, uint>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR long enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlInt64EnumBinding<T, B> : SqlEnumBinding<T, B, long>
        where T : class, ISqlTabularProxy, new()
    {

    }

    /// <summary>
    /// Binds a CLR ulong enum to a table proxy where each row in the proxied table corresponds to an enumeration literal
    /// </summary>
    /// <typeparam name="T">The table proxy type</typeparam>
    /// <typeparam name="B">The enumeration type</typeparam>
    public sealed class SqlUInt64EnumBinding<T, B> : SqlEnumBinding<T, B, ulong>
        where T : class, ISqlTabularProxy, new()
    {

    }
}