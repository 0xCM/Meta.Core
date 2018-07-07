//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The canonical set of core data types which, admittedly, is skewed toward SQL Server
/// but is theoretically type-system agnostic
/// </summary>
public class CoreDataTypes : TypedItemList<CoreDataTypes, CoreDataType>
{
    public static readonly CoreMissingType Unspecified = new CoreMissingType();

    public static readonly CoreBitDataType Bit = new CoreBitDataType();

    public static readonly CoreUInt8Type UInt8 = new CoreUInt8Type();
    public static readonly CoreUInt16Type UInt16 = new CoreUInt16Type();
    public static readonly CoreUInt32Type UInt32 = new CoreUInt32Type();
    public static readonly CoreUInt64Type UInt64 = new CoreUInt64Type();
    public static readonly CoreInt8Type Int8 = new CoreInt8Type();
    public static readonly CoreInt16Type Int16 = new CoreInt16Type();
    public static readonly CoreInt32Type Int32 = new CoreInt32Type();
    public static readonly CoreInt64Type Int64 = new CoreInt64Type();

    public static readonly CoreBinaryType BinaryFixed = new CoreBinaryType(CoreDataTypeNames.BinaryFixed);
    public static readonly CoreBinaryType BinaryVariable = new CoreBinaryType(CoreDataTypeNames.BinaryVariable);
    public static readonly CoreBinaryType BinaryMax = new CoreBinaryType(CoreDataTypeNames.BinaryMax);

    public static readonly CoreTextType AnsiTextFixed = new CoreTextType(CoreDataTypeNames.AnsiTextFixed);
    public static readonly CoreTextType AnsiTextVariable = new CoreTextType(CoreDataTypeNames.AnsiTextVariable);
    public static readonly CoreTextType AnsiTextMax = new CoreTextType(CoreDataTypeNames.AnsiTextMax);
    public static readonly CoreTextType UnicodeTextFixed = new CoreTextType(CoreDataTypeNames.UnicodeTextFixed);
    public static readonly CoreTextType UnicodeTextVariable = new CoreTextType(CoreDataTypeNames.UnicodeTextVariable);
    public static readonly CoreTextType UnicodeTextMax = new CoreTextType(CoreDataTypeNames.UnicodeTextMax);

    public static readonly CoreXmlType Xml = new CoreXmlType();
    public static readonly CoreJsonType Json = new CoreJsonType();

    public static readonly CoreDateType Date = new CoreDateType();

    public static readonly CoreDateTimeType DateTime = new CoreDateTimeType();
    public static readonly CoreDateTimeType LegacyDateTime = new CoreDateTimeType(true);
    public static readonly CoreDateTimeType LegacySmallDateTime = new CoreDateTimeType(true, true);

    public static readonly CoreFloat32Type Float32 = new CoreFloat32Type();
    public static readonly CoreFloat64Type Float64 = new CoreFloat64Type();

    public static readonly CoreDecimalType Decimal = new CoreDecimalType();
    public static readonly CoreMoneyType Money = new CoreMoneyType();
    public static readonly CoreMoneyType SmallMoney = new CoreMoneyType(true);

    public static readonly CoreTimeOfDayType TimeOfDay = new CoreTimeOfDayType();
    public static readonly CoreDurationType Duration = new CoreDurationType();

    public static readonly CoreDateTimeOffsetType DateTimeOffset = new CoreDateTimeOffsetType();

    public static readonly CoreGuidType Guid = new CoreGuidType();

    public static readonly CoreVariantType Variant = new CoreVariantType();

    public static readonly CoreUInt8EnumType UInt8Enum = new CoreUInt8EnumType();
    public static readonly CoreInt8EnumType Int8Enum = new CoreInt8EnumType();
    public static readonly CoreUInt16EnumType UInt16Enum = new CoreUInt16EnumType();
    public static readonly CoreInt16EnumType Int16Enum = new CoreInt16EnumType();
    public static readonly CoreUInt32EnumType UInt32Enum = new CoreUInt32EnumType();
    public static readonly CoreInt32EnumType Int32Enum = new CoreInt32EnumType();
    public static readonly CoreUInt64EnumType UInt64Enum = new CoreUInt64EnumType();
    public static readonly CoreInt64EnumType Int64Enum = new CoreInt64EnumType();

    public static readonly CoreRuntimeType RuntimeType = new CoreRuntimeType();
   
        
}


