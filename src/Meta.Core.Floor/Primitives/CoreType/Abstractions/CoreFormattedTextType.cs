//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public abstract class CoreFormattedTextType : CoreDataType<string>
{
    internal CoreFormattedTextType(string DataTypeName)
        : base(DataTypeName)
    {

    }

    public override string ParseTypedValue(string text)
        => text;
}
