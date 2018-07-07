//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public abstract class CustomPrimitive<TValue, TBase> : CoreDataType<TBase>
    where TBase : ICoreType
    
{
    protected CustomPrimitive(string DataTypeName)
        : base(DataTypeName)
    {
    }

    protected CustomPrimitive(string DataTypeName, bool CanSpecifyLength)
        : base(DataTypeName, CanSpecifyLength)
    {

    }

    protected CustomPrimitive(string DataTypeName, bool CanSpecifyPrecision, bool CanSpecifyScale)
        : base(DataTypeName, CanSpecifyPrecision, CanSpecifyScale)
    {

    }
}

