//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

using Meta.Core;
/// <summary>
/// Defines a convenience adapter for <see cref="Type"/> values that describe interfaces
/// </summary>
public sealed class ClrInterface : ClrType
{
    public static implicit operator ClrInterface(Type x)
        => new ClrInterface(x);

    public static new ClrInterface Get(Type x)
        => new ClrInterface(x);

    public static new ClrInterface Get<T>()
        => Get(typeof(T));

    public ClrInterface(Type ReflectedElement)
        : base(ReflectedElement)
    {
        if (metacore.not(ReflectedElement.IsInterface))
            throw new ArgumentException($"The {ReflectedElement} type is not an interface");
    }

    public ClrInterfaceName InterfaceName
        => new ClrInterfaceName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => InterfaceName;

    public override ClrTypeReference GetReference()
        => new ClrTypeReference(InterfaceName);

    /// <summary>
    /// Gets the methods declared by the interface
    /// </summary>
    public ClrInterfaceOperations DeclaredOperations
        => DeclaredInstanceMethods.Select(m => new ClrInterfaceOperation(m));
}

public sealed class ClrInterfaces : TypedItemList<ClrInterfaces, ClrInterface>
{
    public static implicit operator ClrInterfaces(ClrInterface[] items)
        => Create(items);

}