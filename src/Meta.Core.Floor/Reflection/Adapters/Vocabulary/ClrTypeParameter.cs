//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;


public class ClrTypeParameter : ClrElement<Type, ClrTypeParameter>
{
    public static ClrTypeParameter Get(Type t)
        => new ClrTypeParameter(t, t.Name);


    public ClrTypeParameter(Type ReflectedElement, string ParameterName)
        : base(ReflectedElement)
    {
        if (!ReflectedElement.IsGenericParameter)
            throw new ArgumentException($"Expected a generic parameter but {ReflectedElement} is not");

        this.Name = ParameterName;
    }

    public override string Name { get; }

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => ReflectedElement.HasAttribute<A>();
}