//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

/// <summary>
/// Defines a convenience adapter for delegate types
/// </summary>
public sealed class ClrDelegate : ClrType
{
    public static implicit operator ClrDelegate(Type x)
        => new ClrDelegate(x);

    public ClrDelegate(Type ReflectedElement)
        : base(ReflectedElement)
    {
        if (not(ReflectedElement.IsDelegate()))
            throw new ArgumentException($"The {ReflectedElement} type is not a class");
    }

    public ClrDelegateName DelegateName
        => new ClrDelegateName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => DelegateName;

    public override ClrTypeReference GetReference()
        => new ClrTypeReference(DelegateName);
}
