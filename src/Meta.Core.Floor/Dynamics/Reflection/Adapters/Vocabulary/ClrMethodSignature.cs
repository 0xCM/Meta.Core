//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;

/// <summary>
/// Characterizes a method signature
/// </summary>
public sealed class ClrMethodSignature : ClrMember<MethodInfo, ClrMethodSignature>
{
    public ClrMethodSignature(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }

    /// <summary>
    /// Specifies whether the method is generic
    /// </summary>
    public override bool IsGeneric
        => ReflectedElement.IsGenericMethod;

    /// <summary>
    /// Specifies whether the method is static
    /// </summary>
    public override bool IsStatic
        => ReflectedElement.IsStatic;

    /// <summary>
    /// Specifies whether the method is abstract
    /// </summary>
    public override bool IsAbstract
        => ReflectedElement.IsAbstract;

    /// <summary>
    /// Specifies whether the method is public
    /// </summary>
    public override bool IsPublic
        => ReflectedElement.IsPublic;

    /// <summary>
    /// Specifies whether the method is private
    /// </summary>
    public override bool IsPrivate
        => ReflectedElement.IsPrivate;

    /// <summary>
    /// Specifies the name of the method
    /// </summary>
    public override string Name
        => ReflectedElement.Name;

    /// <summary>
    /// Specifies the method's return type, if any
    /// </summary>
    public Option<ClrType> ReturnType
        => ClrMethod.Get(ReflectedElement).ReturnType;

    /// <summary>
    /// Specifies the method's parameters
    /// </summary>
    public IEnumerable<ClrMethodParameter> Parameters
        => from p in ReflectedElement.GetParameters() select new ClrMethodParameter(p);

    /// <summary>
    /// Specifies the methods' generic parameters
    /// </summary>
    public IEnumerable<ClrTypeParameter> TypeParameters
        => ClrMethod.Get(ReflectedElement).TypeParameters;

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));
}