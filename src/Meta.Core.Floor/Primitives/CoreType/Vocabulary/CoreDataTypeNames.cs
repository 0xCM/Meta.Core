//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using Meta.Core;

/// <summary>
/// Lists the names of the available <see cref="CoreDataType"/> values
/// </summary>
public class CoreDataTypeNames : ImmutableFieldIndex<string, CoreDataTypeNames>
{
    public const string Unspecified = nameof(Unspecified);
    public const string Bit = nameof(Bit);
    public const string UInt8 = nameof(UInt8);
    public const string UInt16 = nameof(UInt16);
    public const string UInt32 = nameof(UInt32);
    public const string UInt64 = nameof(UInt64);
    public const string Int8 = nameof(Int8);
    public const string Int16 = nameof(Int16);
    public const string Int32 = nameof(Int32);
    public const string Int64 = nameof(Int64);
    public const string BinaryFixed = nameof(BinaryFixed);
    public const string BinaryVariable = nameof(BinaryVariable);
    public const string BinaryMax = nameof(BinaryMax);
    public const string AnsiTextFixed = nameof(AnsiTextFixed);
    public const string AnsiTextVariable = nameof(AnsiTextVariable);
    public const string AnsiTextMax = nameof(AnsiTextMax);
    public const string UnicodeTextFixed = nameof(UnicodeTextFixed);
    public const string UnicodeTextVariable = nameof(UnicodeTextVariable);
    public const string UnicodeTextMax = nameof(UnicodeTextMax);
    public const string DateTime = nameof(DateTime);
    public const string DateTimeOffset = nameof(DateTimeOffset);
    public const string TimeOfDay = nameof(TimeOfDay);
    public const string Date = nameof(Date);
    public const string Duration = nameof(Duration);
    public const string LegacyDateTime = nameof(LegacyDateTime);
    public const string LegacySmallDateTime = nameof(LegacySmallDateTime);
    public const string Float32 = nameof(Float32);
    public const string Float64 = nameof(Float64);
    public const string Decimal = nameof(Decimal);
    public const string Money = nameof(Money);
    public const string SmallMoney = nameof(SmallMoney);
    public const string Guid = nameof(Guid);
    public const string Xml = nameof(Xml);
    public const string Json = nameof(Json);
    public const string Variant = nameof(Variant);
    public const string Geography = nameof(Geography);
    public const string Geometry = nameof(Geometry);
    public const string Hierarchy = nameof(Hierarchy);
    public const string CustomTable = nameof(CustomTable);
    public const string CustomObject = nameof(CustomObject);
    public const string CustomPrimitive = nameof(CustomPrimitive);

    public const string UInt8Enum = nameof(UInt8Enum);
    public const string Int8Enum = nameof(Int8Enum);
    public const string UInt16Enum = nameof(UInt16Enum);
    public const string Int16Enum = nameof(Int16Enum);
    public const string UInt32Enum = nameof(UInt32Enum);
    public const string Int32Enum = nameof(Int32Enum);
    public const string UInt64Enum = nameof(UInt64Enum);
    public const string Int64Enum = nameof(Int64Enum);

    public const string RuntimeType = nameof(RuntimeType);
}

