//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;


/// <summary>
/// Defines a convenience adapter for <see cref="Type"/> values that describe structs
/// </summary>
public sealed class ClrStruct : ClrType
{
    public static implicit operator ClrStruct(Type x)
        => new ClrStruct(x);

    public static new ClrStruct Get(Type t)
        => new ClrStruct(t);

    public ClrStruct(Type ReflectedElement)
        : base(ReflectedElement)
    {
        if (not(ReflectedElement.IsValueType))
            throw new ArgumentException($"The {ReflectedElement} type is not a struct");
    }

    public ClrStructName StructName
        => new ClrStructName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => StructName;

    public override ClrTypeReference GetReference()
    {
        if (IsNullableType)
            return new ClrNullableTypeReference(StructName);
        else
            return new ClrTypeReference(StructName);

    }
}

