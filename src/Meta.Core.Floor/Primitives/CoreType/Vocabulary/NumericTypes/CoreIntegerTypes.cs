//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public sealed class CoreInt8Type : CoreIntegerType<sbyte>
{
    internal CoreInt8Type()
        : base(CoreDataTypeNames.Int8)
    {

    }

    public override sbyte ParseTypedValue(string text)
        => sbyte.Parse(text);
}

public sealed class CoreInt16Type : CoreIntegerType<Int16>
{
    internal CoreInt16Type()
        : base(CoreDataTypeNames.Int16)
    {

    }

    public override short ParseTypedValue(string text)
        => short.Parse(text);
}

public sealed class CoreInt32Type : CoreIntegerType<Int32>
{
    internal CoreInt32Type()
        : base(CoreDataTypeNames.Int32)
    {

    }

    public override int ParseTypedValue(string text)
        => int.Parse(text);

}

public sealed class CoreInt64Type : CoreIntegerType<Int64>
{
    internal CoreInt64Type()
        : base(CoreDataTypeNames.Int64)
    {

    }

    public override long ParseTypedValue(string text) 
        => long.Parse(text);
}

public sealed class CoreUInt8Type : CoreIntegerType<byte>
{
    internal CoreUInt8Type()
        : base(CoreDataTypeNames.UInt8)
    {

    }

    public override byte ParseTypedValue(string text) 
        => byte.Parse(text);

}

public sealed class CoreUInt16Type : CoreIntegerType<UInt16>
{
    internal CoreUInt16Type()
        : base(CoreDataTypeNames.UInt16)
    {

    }

    public override ushort ParseTypedValue(string text) 
        => ushort.Parse(text);
}

public sealed class CoreUInt32Type : CoreIntegerType<UInt32>
{
    internal CoreUInt32Type()
        : base(CoreDataTypeNames.UInt32)
    {

    }

    public override uint ParseTypedValue(string text) 
        => uint.Parse(text);

}

public sealed class CoreUInt64Type : CoreIntegerType<UInt64>
{
    internal CoreUInt64Type()
        : base(CoreDataTypeNames.UInt64)
    {

    }

    public override ulong ParseTypedValue(string text) 
        => ulong.Parse(text);
}
