//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public sealed class CoreDurationType : CoreDataType<TimeSpan>
{
    internal CoreDurationType()
        : base(CoreDataTypeNames.Duration)
    { }
    public override bool IsTemporal
        => true;

    public override TimeSpan ParseTypedValue(string text) 
        => TimeSpan.Parse(text);
}
