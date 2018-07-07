//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public abstract class CoreRealType<T> : CoreDataType<T>
{
    internal CoreRealType(string DataTypeName)
        : base(DataTypeName)
    {

    }

}

public sealed class CoreFloat32Type : CoreRealType<float>
{
    internal CoreFloat32Type()
        : base(CoreDataTypeNames.Float32)
    {

    }

    public override float ParseTypedValue(string text) 
        => float.Parse(text);
}

public sealed class CoreFloat64Type : CoreRealType<Double>
{
    internal CoreFloat64Type()
        : base(CoreDataTypeNames.Float64)
    {

    }

    public override double ParseTypedValue(string text) 
        => double.Parse(text);
}
