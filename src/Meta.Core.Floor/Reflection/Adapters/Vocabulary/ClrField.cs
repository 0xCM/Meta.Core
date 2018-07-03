//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Defines a convenience adapter for <see cref="FieldInfo"/> values
/// </summary>
public sealed class ClrField : ClrMember<FieldInfo, ClrField>
{
    public static ClrField Get(FieldInfo x)
        => new ClrField(x);

    public static implicit operator FieldInfo(ClrField x) 
        => x.ReflectedElement;
    public static implicit operator ClrField(FieldInfo x) 
        => new ClrField(x);

    public ClrField(FieldInfo ReflectedElement)
        : base(ReflectedElement)
    { }

    public override string Name 
        => ReflectedElement.Name;

    public override A GetCustomAttribute<A>() 
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>() 
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    public ClrType FieldType
        => ClrType.Get(ReflectedElement.FieldType);

    public override bool IsStatic
        => ReflectedElement.IsStatic;

    public override bool IsGeneric 
        => false;

    public override bool IsAbstract
        => false;

    public object GetValue(object o) 
        => ReflectedElement.GetValue(o);

    public void SetValue(object o, object value) 
        => ReflectedElement.SetValue(o, value);

    public override bool IsPublic
        => ReflectedElement.IsPublic;

    public override bool IsPrivate
        => ReflectedElement.IsPrivate;

}

