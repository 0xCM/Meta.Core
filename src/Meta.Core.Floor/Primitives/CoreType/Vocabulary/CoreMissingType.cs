//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public sealed class CoreMissingType : CoreDataType<object>
{
    internal CoreMissingType()
        : base(CoreDataTypeNames.Unspecified)
    {

    }

    public override object ParseTypedValue(string text)
        => text;
}
