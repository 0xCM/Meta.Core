//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

public sealed class CoreBitDataType : CoreDataType<bool>
{
    internal CoreBitDataType()
        : base(CoreDataTypeNames.Bit)
    {

    }

    public override bool ParseTypedValue(string value)
        => Boolean.Parse(value);

    public override bool IsBoolean
        => true;
}
