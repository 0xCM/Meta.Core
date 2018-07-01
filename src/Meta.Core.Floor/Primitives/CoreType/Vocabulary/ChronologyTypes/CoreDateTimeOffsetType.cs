//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public sealed class CoreDateTimeOffsetType : CoreDataType<DateTimeOffset>
{
    internal CoreDateTimeOffsetType()
        : base(CoreDataTypeNames.DateTimeOffset)
    {

    }

    public override bool IsTemporal
        => true;

    public override DateTimeOffset ParseTypedValue(string text)
        => DateTimeOffset.Parse(text);
}
