//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;

using static metacore;

/// <summary>
/// Models a method parameter as determined by reflected metadata
/// </summary>
public sealed class ClrMethodParameter : ClrElement<ParameterInfo, ClrMethodParameter>
{
    public static implicit operator ParameterInfo(ClrMethodParameter x)
        => x.ReflectedElement;

    public static implicit operator ClrMethodParameter(ParameterInfo x)
        => new ClrMethodParameter(x);

    public ClrMethodParameter(ParameterInfo ReflectedElement)
        : base(ReflectedElement)
    {
    }

    public override string Name
        => ReflectedElement.Name;

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public int Position
        => ReflectedElement.Position;


    public ClrType ParameterType
        => ClrType.Get(ReflectedElement.ParameterType);


    public ClrMethod DeclaringMethod
        => ClrMethod.Get((MethodInfo)ReflectedElement.Member);
}


public sealed class ClrMethodParameters : TypedItemList<ClrMethodParameters, ClrMethodParameter>
{
    public static implicit operator ClrMethodParameters(ClrMethodParameter[] parameters)
        => Create(parameters);

    public static implicit operator ClrMethodParameters(ReadOnlyList<ClrMethodParameter> parameters)
        => Create(parameters);

}