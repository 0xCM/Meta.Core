//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public sealed class CoreTimeOfDayType : CoreRealType<TimeOfDay>
{
    internal CoreTimeOfDayType()
        : base(CoreDataTypeNames.TimeOfDay)
    { }

    public override bool IsTemporal
        => true;

    public override TimeOfDay ParseTypedValue(string text) 
        => TimeOfDay.Parse(text);
}
