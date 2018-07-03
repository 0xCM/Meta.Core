//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

public class ClrEnumLiteral : ClrMember<FieldInfo, ClrEnumLiteral>
{
    static CoreDataValue GetLiteralValue(FieldInfo ReflectedElement)
            => ~CoreDataValue.FromObject(Convert.ChangeType(
                ReflectedElement.GetValue(null),
                Enum.GetUnderlyingType(ReflectedElement.DeclaringType)
                ));

    public ClrEnumLiteral(FieldInfo ReflectedElement)
        : base(ReflectedElement)
    {

        var value = Convert.ChangeType(
            ReflectedElement.GetValue(null),
            Enum.GetUnderlyingType(ReflectedElement.DeclaringType)
            );
    }

    /// <summary>
    /// Specifies the name of the defining enumeration
    /// </summary>
    public ClrEnumName EnumName
        => ReflectedElement.DeclaringType.Name;

    /// <summary>
    /// Specifies the integral value
    /// </summary>
    public CoreDataValue LiteralValue
        => GetLiteralValue(ReflectedElement);

    /// <summary>
    /// Specifies the literal name
    /// </summary>
    public ClrEnumLiteralName LiteralName
        => new ClrEnumLiteralName(Name);

    public override string Name
        => ReflectedElement.Name;

    /// <summary>
    /// Specifies the value of the label attribute, if available; otherwise the literal name
    /// </summary>
    public string Label
        => ReflectedElement.GetCustomAttribute<LabelAttribute>()?.LabelText ?? Name;

    /// <summary>
    /// Describes the enum literal as specified via an applied <see cref="DescriptionAttribute"/>
    /// </summary>
    public string Description
        => TryGetCustomAttribute<DescriptionAttribute>().MapValueOrDefault(d => d.Description, String.Empty);

    public override bool IsAbstract 
        => false;

    public override bool IsGeneric 
        => false;

    public override bool IsPrivate 
        => false;

    public override bool IsPublic 
        => true;

    public override bool IsStatic 
        => false;

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => ReflectedElement.HasAttribute<A>();

    public override string ToString()
        => $"{LiteralValue}";


}
