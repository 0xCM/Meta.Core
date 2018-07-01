//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;


public abstract class CoreEnumType<T> : CoreDataType<T>, ICoreEnumType<T>
{
    protected CoreEnumType(string DataTypeName)
        : base(DataTypeName)
    {

    }

    public override T ParseTypedValue(string text)
        => parseEnum<T>(text);

    public ClrStruct UnderlyingType
        => typeof(T);
}








