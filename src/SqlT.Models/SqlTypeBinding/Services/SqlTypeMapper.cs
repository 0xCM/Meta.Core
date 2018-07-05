//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;

    using sxc = Syntax.contracts;
   
    public static class SqlTypeMapper
    {
        /// <summary>
        /// Defines projections from SQL data types to CLR types that correspond to the type used by
        /// ado.net to transport the data between client/server
        /// </summary>
        class SqlToTransportTypeMap
        {
            static Dictionary<sxc.ISqlType, Type> Index;

            static SqlToTransportTypeMap()
            {
                Index = new Dictionary<sxc.ISqlType, Type>
                {
                    [SqlNativeTypes.bigint] = typeof(long),
                    [SqlNativeTypes.binary] = typeof(byte[]),
                    [SqlNativeTypes.bit] = typeof(bool),
                    [SqlNativeTypes.sqlchar] = typeof(string),
                    [SqlNativeTypes.date] = typeof(DateTime),
                    [SqlNativeTypes.datetime] = typeof(DateTime),
                    [SqlNativeTypes.datetime2] = typeof(DateTime),
                    [SqlNativeTypes.datetimeoffset] = typeof(DateTimeOffset),
                    [SqlNativeTypes.sqldecimal] = typeof(decimal),
                    [SqlNativeTypes.sqlfloat] = typeof(float),
                    [SqlNativeTypes.geography] = typeof(object),
                    [SqlNativeTypes.geometry] = typeof(object),
                    [SqlNativeTypes.hierarchy] = typeof(object),
                    [SqlNativeTypes.image] = typeof(byte[]),
                    [SqlNativeTypes.sqlint] = typeof(int),
                    [SqlNativeTypes.money] = typeof(decimal),
                    [SqlNativeTypes.nchar] = typeof(string),
                    [SqlNativeTypes.ntext] = typeof(string),
                    [SqlNativeTypes.numeric] = typeof(decimal),
                    [SqlNativeTypes.nvarchar] = typeof(string),
                    [SqlNativeTypes.real] = typeof(float),
                    [SqlNativeTypes.rowversion] = typeof(byte[]),
                    [SqlNativeTypes.smalldatetime] = typeof(DateTime),
                    [SqlNativeTypes.smallint] = typeof(short),
                    [SqlNativeTypes.smallmoney] = typeof(decimal),
                    [SqlNativeTypes.sql_variant] = typeof(object),
                    [SqlNativeTypes.sysname] = typeof(string),
                    [SqlNativeTypes.text] = typeof(string),
                    [SqlNativeTypes.time] = typeof(TimeSpan),
                    [SqlNativeTypes.timestamp] = typeof(byte),
                    [SqlNativeTypes.tinyint] = typeof(byte),
                    [SqlNativeTypes.uniqueidentifier] = typeof(Guid),
                    [SqlNativeTypes.varbinary] = typeof(byte[]),
                    [SqlNativeTypes.varchar] = typeof(string),
                    [SqlNativeTypes.xml] = typeof(string),

                };
            }

            public static Type Map(sxc.ISqlType src)
            {
                if (!Index.ContainsKey(src))
                {
                    throw new ArgumentException($"There is no mapping from the SQL type system to the Core type system for the {src} type");
                }

                return Index[src];
            }

        }

        class SqlToCoreTypeMap
        {
            static Dictionary<sxc.ISqlType, CoreDataType> Index;

            static SqlToCoreTypeMap()
            {
                Index = new Dictionary<sxc.ISqlType, CoreDataType>
                {
                    [SqlNativeTypes.bigint] = CoreDataTypes.Int64,
                    [SqlNativeTypes.binary] = CoreDataTypes.BinaryVariable,
                    [SqlNativeTypes.bit] = CoreDataTypes.Bit,
                    [SqlNativeTypes.sqlchar] = CoreDataTypes.AnsiTextVariable,
                    [SqlNativeTypes.date] = CoreDataTypes.Date,
                    [SqlNativeTypes.datetime] = CoreDataTypes.LegacyDateTime,
                    [SqlNativeTypes.datetime2] = CoreDataTypes.DateTime,
                    [SqlNativeTypes.datetimeoffset] = CoreDataTypes.DateTimeOffset,
                    [SqlNativeTypes.sqldecimal] = CoreDataTypes.Decimal,
                    [SqlNativeTypes.sqlfloat] = CoreDataTypes.Float64,
                    [SqlNativeTypes.geography] = CoreDataTypes.Unspecified,
                    [SqlNativeTypes.geometry] = CoreDataTypes.Unspecified,
                    [SqlNativeTypes.hierarchy] = CoreDataTypes.Unspecified,
                    [SqlNativeTypes.image] = CoreDataTypes.BinaryVariable,
                    [SqlNativeTypes.sqlint] = CoreDataTypes.Int32,
                    [SqlNativeTypes.money] = CoreDataTypes.Money,
                    [SqlNativeTypes.nchar] = CoreDataTypes.UnicodeTextVariable,
                    [SqlNativeTypes.ntext] = CoreDataTypes.UnicodeTextVariable,
                    [SqlNativeTypes.numeric] = CoreDataTypes.Decimal,
                    [SqlNativeTypes.nvarchar] = CoreDataTypes.UnicodeTextVariable,
                    [SqlNativeTypes.real] = CoreDataTypes.Float32,
                    [SqlNativeTypes.rowversion] = CoreDataTypes.BinaryVariable,
                    [SqlNativeTypes.smalldatetime] = CoreDataTypes.LegacySmallDateTime,
                    [SqlNativeTypes.smallint] = CoreDataTypes.Int16,
                    [SqlNativeTypes.smallmoney] = CoreDataTypes.SmallMoney,
                    [SqlNativeTypes.sql_variant] = CoreDataTypes.Variant,
                    [SqlNativeTypes.sysname] = CoreDataTypes.UnicodeTextVariable,
                    [SqlNativeTypes.text] = CoreDataTypes.AnsiTextVariable,
                    [SqlNativeTypes.time] = CoreDataTypes.TimeOfDay,
                    [SqlNativeTypes.timestamp] = CoreDataTypes.BinaryVariable,
                    [SqlNativeTypes.tinyint] = CoreDataTypes.UInt8,
                    [SqlNativeTypes.uniqueidentifier] = CoreDataTypes.Guid,
                    [SqlNativeTypes.varbinary] = CoreDataTypes.BinaryVariable,
                    [SqlNativeTypes.varchar] = CoreDataTypes.AnsiTextVariable,
                    [SqlNativeTypes.xml] = CoreDataTypes.Xml,

                };
            }

            public static CoreDataType Map(sxc.ISqlType src) => Index[src];
        }

        class CoreToSqlTypeMap
        {
            private static Dictionary<CoreDataType, sxc.ISqlType> Index;

            static CoreToSqlTypeMap()
            {
                Index = new Dictionary<CoreDataType, sxc.ISqlType>
                {
                    [CoreDataTypes.AnsiTextFixed] = SqlNativeTypes.sqlchar,
                    [CoreDataTypes.AnsiTextMax] = SqlNativeTypes.varchar,
                    [CoreDataTypes.AnsiTextVariable] = SqlNativeTypes.varchar,
                    [CoreDataTypes.BinaryFixed] = SqlNativeTypes.binary,
                    [CoreDataTypes.BinaryMax] = SqlNativeTypes.binary,
                    [CoreDataTypes.BinaryVariable] = SqlNativeTypes.varbinary,
                    [CoreDataTypes.Bit] = SqlNativeTypes.bit,
                    [CoreDataTypes.Date] = SqlNativeTypes.date,
                    [CoreDataTypes.DateTime] = SqlNativeTypes.datetime2,
                    [CoreDataTypes.DateTimeOffset] = SqlNativeTypes.datetimeoffset,
                    [CoreDataTypes.Decimal] = SqlNativeTypes.sqldecimal,
                    [CoreDataTypes.Duration] = SqlNativeTypes.bigint,
                    [CoreDataTypes.Float32] = SqlNativeTypes.real,
                    [CoreDataTypes.Float64] = SqlNativeTypes.sqlfloat,
                    [CoreDataTypes.Guid] = SqlNativeTypes.uniqueidentifier,
                    [CoreDataTypes.Int16] = SqlNativeTypes.smallint,
                    [CoreDataTypes.Int32] = SqlNativeTypes.sqlint,
                    [CoreDataTypes.Int64] = SqlNativeTypes.bigint,
                    [CoreDataTypes.Int8] = SqlNativeTypes.smallint,
                    [CoreDataTypes.Json] = SqlNativeTypes.varchar,
                    [CoreDataTypes.LegacyDateTime] = SqlNativeTypes.datetime,
                    [CoreDataTypes.LegacySmallDateTime] = SqlNativeTypes.smalldatetime,
                    [CoreDataTypes.Money] = SqlNativeTypes.money,
                    [CoreDataTypes.SmallMoney] = SqlNativeTypes.smallmoney,
                    [CoreDataTypes.TimeOfDay] = SqlNativeTypes.time,
                    [CoreDataTypes.UInt16] = SqlNativeTypes.sqlint,
                    [CoreDataTypes.UInt32] = SqlNativeTypes.bigint,
                    [CoreDataTypes.UInt8] = SqlNativeTypes.tinyint,
                    [CoreDataTypes.UnicodeTextFixed] = SqlNativeTypes.nchar,
                    [CoreDataTypes.UnicodeTextMax] = SqlNativeTypes.nvarchar,
                    [CoreDataTypes.UnicodeTextVariable] = SqlNativeTypes.nvarchar,
                    [CoreDataTypes.Variant] = SqlNativeTypes.sql_variant,
                    [CoreDataTypes.Xml] = SqlNativeTypes.xml,
                };

            }

            public static bool CanMap(CoreDataType src)
                => Index.ContainsKey(src);

            public static sxc.ISqlType Map(CoreDataType src)
            {
                if (!CanMap(src))
                {
                    throw new ArgumentException($"No mapping from the core {src} type to a SQL type exists");
                }
                return Index[src];
            }
        }

        static readonly SqlNativeTypes SqlTypes = new SqlNativeTypes();

        public static sxc.ISqlType MapToSqlType(this CoreDataType src)
            => CoreToSqlTypeMap.Map(src);

        public static bool CanMapToSqlType(this CoreDataType src)
            => CoreToSqlTypeMap.CanMap(src);

        static sxc.ISqlType GetSqlType(this SqlTypeName typeName)
            => SqlNativeTypes.TryFind(p => p.Name == typeName).Require();

        public static ICoreType<ICoreType> MapToCoreType(this SqlTypeName typeName)
            => typeName.GetSqlType().MapToCoreType();

        public static ICoreType<ICoreType> MapToCoreType(this sxc.ISqlType src)
        {
            if (src is sxc.ISqlType p)
            {
                if (p is sxc.native_type)
                    return SqlToCoreTypeMap.Map(p);
                else if (p is sxc.ISqlDataType d)
                    return (d.BaseType.value.Name).MapToCoreType();
                else
                    throw new NotSupportedException();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public static ClrType MapToClrType(this sxc.ISqlType src)
            => ClrType.Get(src.MapToCoreType().ClrType);

        public static ClrType MapToTransportType(this sxc.ISqlType src)
            => ClrType.Get(SqlToTransportTypeMap.Map(src));

        public static object ConvertToTransportValue(this sxc.ISqlType srcType, object srcValue)
        {
            if (srcValue == null)
                return DBNull.Value;

            var dstType = srcType.MapToTransportType();
            var srcValueType = srcValue.GetType();

            if (srcValueType == dstType)
                return srcValue;

            if (Object.ReferenceEquals(srcType, SqlNativeTypes.date) && srcValueType == typeof(Date))
                return ((Date)srcValue).ToDateTimeAtMidnight();
            else
                return Convert.ChangeType(srcValue, dstType);
        }

        public static Option<sxc.ISqlType> GetSqlType(this Type clrType)
            => from t in clrType.ToCoreType()
               select t.MapToSqlType();

        public static object ConvertToTransportValue(this CoreDataType srcType, object srcValue)
            => srcType.MapToSqlType().ConvertToTransportValue(srcValue);

    }
}
