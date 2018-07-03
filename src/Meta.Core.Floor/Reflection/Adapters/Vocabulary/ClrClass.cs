//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

/// <summary>
/// Defines a convenience adapter for class types
/// </summary>
public sealed class ClrClass : ClrType
{
    public static implicit operator ClrClass(Type x)
        => new ClrClass(x);

    public static new ClrClass Get(Type x)
        => new ClrClass(x);

    public static new ClrClass Get<T>()
        => Get(typeof(T));

    public ClrClass(Type ReflectedElement)
        : base(ReflectedElement)
    {
        if (not(ReflectedElement.IsClass))
            throw new ArgumentException($"The {ReflectedElement} type is not a class");
    }

    /// <summary>
    /// Gets the type's immediate ancestor, if any
    /// </summary>
    public new ClrClass BaseType
        => ReflectedElement.BaseType is null
        ? null 
        : new ClrClass(ReflectedElement.BaseType);

    public ClrClassName ClassName
        => new ClrClassName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => ClassName;

    public override ClrTypeReference GetReference()
        => new ClrTypeReference(ClassName);

    /// <summary>
    /// Determines whether the class is a subclass of another
    /// </summary>
    /// <param name="candidate">The supertype to test</param>
    /// <returns></returns>
    public bool IsSublcassOf(ClrClass candidate)
        => ReflectedElement.IsSubclassOf(candidate);

    /// <summary>
    /// Determines whether the class is a subclass of another
    /// </summary>
    /// <typeparam name="T">The supertype to test</typeparam>
    /// <returns></returns>
    public bool IsSublcassOf<T>()
        => ReflectedElement.IsSubclassOf(typeof(T));
}
