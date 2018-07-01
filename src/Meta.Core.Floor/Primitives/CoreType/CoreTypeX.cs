//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


using static metacore;

using C = CoreDataTypes;

/// <summary>
/// Defines operations for manipulating <see cref="CoreDataType"/> types and values
/// </summary>
public static class CoreTypeX
{
    /// <summary>
    /// Interprets a <see cref="string"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this string x) 
        => C.UnicodeTextVariable.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets and <see cref="Enum"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Enum x)
    {
        var tc = Type.GetTypeCode(x.GetType().GetEnumUnderlyingType());
        switch(tc)
        {
            case TypeCode.Byte:
                return C.UInt8Enum.CreateReference().CreateValue(x);
            case TypeCode.SByte:
                return C.Int8Enum.CreateReference().CreateValue(x); 
            case TypeCode.Int16:
                return C.Int16Enum.CreateReference().CreateValue(x); 
            case TypeCode.UInt16:
                return C.UInt16Enum.CreateReference().CreateValue(x); 
            case TypeCode.Int32:
                return C.Int32Enum.CreateReference().CreateValue(x); 
            case TypeCode.UInt32:
                return C.UInt32Enum.CreateReference().CreateValue(x);
            case TypeCode.Int64:
                return C.Int64Enum.CreateReference().CreateValue(x);
            case TypeCode.UInt64:
                return C.UInt64Enum.CreateReference().CreateValue(x);
        }
        return C.Unspecified.CreateReference().CreateValue(x);


    }

    /// <summary>
    /// Interprets a <see cref="int"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this int x) 
        => C.Int32.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="int"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this int? x)
        => C.Int32.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="uint"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this uint x)
        => C.UInt32.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="uint"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this uint? x)
        => C.UInt32.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="long"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this long x)
        => C.Int64.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="long"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this long? x)
        => C.Int64.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="ulong"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this ulong x)
        => C.UInt64.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="ulong"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this ulong? x)
        => C.UInt64.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="bool"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this bool x) 
        => C.Bit.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="bool"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this bool? x)
        => C.Bit.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="decimal"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this decimal x)
        => C.Decimal.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="decimal"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this decimal? x)
        => C.Decimal.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="float"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this float x)
        => C.Float32.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="float"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this float? x)
        => C.Float32.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="double"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this double x)
        => C.Float64.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="double"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this double? x)
        => C.Float64.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="Guid"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Guid x)
        => C.Guid.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="Guid"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Guid? x)
        => C.Guid.CreateReference(false).CreateValue(x);


    /// <summary>
    /// Interprets a <see cref="System.Date"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Date x)
        => C.Date.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="System.Date"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Date? x)
        => C.Date.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="DateTime"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this DateTime x)
        => C.DateTime.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="DateTime"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this DateTime? x)
        => C.DateTime.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="byte"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this byte x)
        => C.UInt8.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="byte"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this byte? x)
        => C.UInt8.CreateReference(false).CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="short"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this short x)
        => C.Int16.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a potential <see cref="short"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this short? x)
        => C.Int16.CreateReference(false).CreateValue(x);


    /// <summary>
    /// Interprets a <see cref="byte"/> array value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this byte[] x)
        => C.BinaryMax.CreateReference().CreateValue(x);

    /// <summary>
    /// Interprets a <see cref="Type"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    public static CoreDataValue AsCoreValue(this Type x)
        => C.RuntimeType.CreateReference().CreateValue(x);

    /// <summary>
    /// Converts a CLR type to a <see cref="CoreDataType"/> if possible
    /// </summary>         
    public static Option<CoreDataType> ToCoreType(this Type type)
    {
        if (type == typeof(Type))
            return C.RuntimeType;

        else if (type == typeof(byte[]))
            return C.BinaryVariable;

        else if (type == typeof(short?) || type == typeof(short))
            return C.Int16;

        else if (type == typeof(Guid?) || type == typeof(Guid))
            return C.Guid;

        else if (type == typeof(byte?) || type == typeof(byte))
            return C.UInt8;

        else if (type == typeof(int?) || type == typeof(int))
            return C.Int32;

        else if (type == typeof(long?) || type == typeof(long))
            return C.Int64;

        else if (type == typeof(uint?) || type == typeof(uint))
            return C.UInt32;

        else if (type == typeof(ulong?) || type == typeof(ulong))
            return C.UInt64;

        else if (type == typeof(DateTime?) || type == typeof(DateTime))
            return C.DateTime;

        else if (type == typeof(Date?) || type == typeof(Date))
            return C.Date;

        else if (type == typeof(double?) || type == typeof(double))
            return C.Float64;

        else if (type == typeof(float?) || type == typeof(float))
            return C.Float32;

        else if (type == typeof(decimal?) || type == typeof(decimal))
            return C.Decimal;

        else if (type == typeof(bool?) || type == typeof(bool))
            return C.Bit;

        else if (type == typeof(string))
            return C.UnicodeTextVariable;

        else if (type.IsEnum)
            return type.GetNonNullableType().GetUnderlyingType().ToCoreType();

        else if (type.Name == "SqlRowVersion")
            return C.BinaryFixed;

        return none<CoreDataType>(error($"No conversion from {type} to a core type is defined"));

    }

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="System.Date"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDate(this ICoreType t)
        => t.ClrType.IsDate();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="System.DateTime"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDateTime(this ICoreType t)
        => t.ClrType.IsDateTime();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="System.Decimal"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDecimal(this ICoreType t)
        => t.ClrType.IsDecimal();

    /// <summary>
    /// Determines whether the core type corresponds to a <see cref="System.Enum"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsEnum(this ICoreType t)
        => t.ClrType.IsEnum;

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="sbyte"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt8(this ICoreType t)
        => t.ClrType.IsInt8();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="short"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt16(this ICoreType t)
        => t.ClrType.IsInt16();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="int"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt32(this ICoreType t)
        => t.ClrType.IsInt32();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="long"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt64(this ICoreType t)
        => t.ClrType.IsInt64();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="byte"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt8(this ICoreType t)
        => t.ClrType.IsUInt8();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="ushort"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt16(this ICoreType t)
        => t.ClrType.IsUInt16();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="uint"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt32(this ICoreType t)
        => t.ClrType.IsUInt32();

    /// <summary>
    /// Determines whether the core type corresponds to the <see cref="ulong"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt64(this ICoreType t)
        => t.ClrType.IsUInt64();

    /// <summary>
    /// Determines whether the core type corresponds to a primtive numeric type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsNumber(this ICoreType t)
        => t.ClrType.IsNumber();

    //============================

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="System.Date"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDate(this CoreTypeReference t)
        => t.ReferencedType.IsDate();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="System.DateTime"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDateTime(this CoreTypeReference t)
        => t.ReferencedType.IsDateTime();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="decimal"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDecimal(this CoreTypeReference t)
        => t.ReferencedType.IsDecimal();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="System.Enum"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsEnum(this CoreTypeReference t)
        => t.ReferencedType.IsEnum();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="sbyte"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt8(this CoreTypeReference t)
        => t.ReferencedType.IsInt8();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="short"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt16(this CoreTypeReference t)
        => t.ReferencedType.IsInt16();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="int"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt32(this CoreTypeReference t)
        => t.ReferencedType.IsInt32();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="long"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsInt64(this CoreTypeReference t)
        => t.ReferencedType.IsInt64();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="byte"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt8(this CoreTypeReference t)
        => t.ReferencedType.IsUInt8();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="ushort"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt16(this CoreTypeReference t)
        => t.ReferencedType.IsUInt16();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="uint"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt32(this CoreTypeReference t)
        => t.ReferencedType.IsUInt32();

    /// <summary>
    /// Determines whether the referenced type corresponds to the <see cref="ulong"/> type
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsUInt64(this CoreTypeReference t)
        => t.ReferencedType.IsUInt64();

    /// <summary>
    /// Determines whether the referenced type corresponds to a numeric primitive
    /// or nullable of same
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsNumber(this CoreTypeReference t)
        => t.ReferencedType.IsNumber();

    //-------------------------------------
    public static bool IsDate(this CoreDataValue v)
        => v.DataType.IsDate();

    public static bool IsDateTime(this CoreDataValue v)
        => v.DataType.IsDateTime();

    public static bool IsDecimal(this CoreDataValue v)
        => v.DataType.IsDecimal();

    public static bool IsEnum(this CoreDataValue v)
        => v.DataType.IsEnum();

    public static bool IsInt8(this CoreDataValue v)
        => v.DataType.IsInt8();

    public static bool IsInt16(this CoreDataValue v)
        => v.DataType.IsInt16();

    public static bool IsInt32(this CoreDataValue v)
        => v.DataType.IsInt32();

    public static bool IsInt64(this CoreDataValue v)
        => v.DataType.IsInt64();

    public static bool IsUInt8(this CoreDataValue v)
        => v.DataType.IsUInt8();

    public static bool IsUInt16(this CoreDataValue v)
        => v.DataType.IsUInt16();

    public static bool IsUInt32(this CoreDataValue v)
        => v.DataType.IsUInt32();

    public static bool IsUInt64(this CoreDataValue v)
        => v.DataType.IsUInt64();

    public static bool IsNumber(this CoreDataValue v)
        => v.DataType.IsNumber();

    /// <summary>
    /// Specicifies the <see cref="ICoreEnumType"/> classification for a given kind
    /// </summary>
    /// <param name="EnumKind"></param>
    /// <returns></returns>
    public static ICoreEnumType CoreEnumType(this CoreEnumKind EnumKind)
    {
        switch (EnumKind)
        {
            case CoreEnumKind.UInt8:
                return C.UInt8Enum;

            case CoreEnumKind.Int8:
                return C.Int8Enum;

            case CoreEnumKind.Int16:
                return C.Int16Enum;

            case CoreEnumKind.UInt16:
                return C.UInt16Enum;

            case CoreEnumKind.Int32:
                return C.Int32Enum;

            case CoreEnumKind.UInt32:
                return C.UInt32Enum;

            case CoreEnumKind.UInt64:
                return C.UInt64Enum;

            case CoreEnumKind.Int64:
                return C.Int64Enum;

            default:
                throw new NotSupportedException();
        }
    }
}

