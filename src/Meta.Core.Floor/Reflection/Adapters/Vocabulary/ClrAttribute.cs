//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;

using static minicore;

/// <summary>
/// Models an attribute as determined by reflection metadata
/// </summary>
public sealed class ClrAttribute : ClrType
{
    public static implicit operator ClrAttribute(Type x)
        => new ClrAttribute(x);

    public static new ClrAttribute Get(Type x)
        => new ClrAttribute(x);

    public ClrAttribute(Type ReflectedElement)
        : base(ReflectedElement)
    {
        if (not(ReflectedElement.IsSubclassOf(typeof(Attribute))))
            throw new ArgumentException($"The {ReflectedElement} type is not a Attribute");
    }

    public ClrAttributeName AttributeName
        => new ClrAttributeName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => AttributeName;

    public override ClrTypeReference GetReference()
        => new ClrTypeReference(AttributeName);
}
