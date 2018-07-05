//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

using static minicore;

/// <summary>
/// Defines a convenience adapter for enum types
/// </summary>
public sealed class ClrEnum : ClrType
{

    public static new ClrEnum Get<T>() 
        where T : Enum
            => new ClrEnum(typeof(T));

    public static new ClrEnum Get(Type enumType)    
        => new ClrEnum(enumType);

    public static implicit operator ClrEnum(Type x)
        => new ClrEnum(x);
    
    public ClrEnum(Type ReflectedElement)
        : base(ReflectedElement)
    {        
        if (not(ReflectedElement.IsEnum))
            throw new ArgumentException($"The {ReflectedElement} type is not an enum");
    }

    public ClrEnumName EnumName
        => new ClrEnumName(ReflectedElement.Name);

    public override IClrTypeName TypeName
        => EnumName;

    public ClrType GetLiteralType()
        => ClrType.Get(ReflectedElement.GetEnumUnderlyingType());

    public override ClrTypeReference GetReference()
    {
        if (IsNullableType)
            return new ClrNullableTypeReference(EnumName);
        else
            return new ClrTypeReference(EnumName);
    }


    /// <summary>
    /// Specifies the values defined by the enumeration
    /// </summary>
    /// <typeparam name="E">The enum type</typeparam>
    /// <returns></returns>
    public Lst<E> Values<E>()
        where E : Enum 
            => Lst.make(Enum.GetValues(typeof(E)).Cast<E>());

    /// <summary>
    /// Specifies the literals defined by the enumeration
    /// </summary>
    /// <returns></returns>
    public Lst<ClrEnumLiteral> Literals
        => Lst.make(ReflectedElement.GetFields().Where(
            f => not(f.IsSpecialName)).Select(f => new ClrEnumLiteral(f)));


    /// <summary>
    /// Returns the identifiers as determined by defined literals and/or attributions
    /// </summary>
    public Seq<string> Identifiers
        =>  from l in Literals
           select l.TryGetCustomAttribute<IdentifierAttribute>()
                    .Map(a => a.Identifier, () => l.Name);

}

