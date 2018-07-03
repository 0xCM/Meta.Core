//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


/// <summary>
/// Defines a convenience adapter for <see cref="ConstructorInfo"/> values
/// </summary>
public sealed class ClrConstructor : ClrConstructor<ClrConstructor>
{

    public ClrConstructor(ConstructorInfo RefelectedElement)
        : base(RefelectedElement)
    { }


    public override bool IsGeneric 
        => false;

    public override bool IsStatic 
        => ReflectedElement.IsStatic;

    public override string Name 
        => ReflectedElement.Name;

    public override bool IsAbstract
        => false;

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    public IEnumerable<ClrMethodParameter> Parameters
        => from p in ReflectedElement.GetParameters() select new ClrMethodParameter(p);

    public override bool IsPublic 
        => ReflectedElement.IsPublic;

    public override bool IsPrivate 
        => ReflectedElement.IsPrivate;

}
