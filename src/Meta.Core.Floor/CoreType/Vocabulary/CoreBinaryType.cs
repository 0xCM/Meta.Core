//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public sealed class CoreBinaryType : CoreDataType<byte[]>
{
    internal CoreBinaryType(string DataTypeName)
        : base
        (
            DataTypeName,
            DataTypeName != CoreDataTypeNames.BinaryMax
        )
    {

    }

    public override string CreateValueText(byte[] value)
        => System.Convert.ToBase64String(value);

    public override byte[] ParseTypedValue(string text)
        => System.Convert.FromBase64String(text);
}
