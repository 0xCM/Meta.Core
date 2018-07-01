//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Base type for reflective member adapters
/// </summary>
/// <typeparam name="T">The member type</typeparam>
/// <typeparam name="E">The derived subtype</typeparam>
public abstract class ClrMember<T, E> : ClrElement<T, E>
    where E : ClrMember<T,E>
    where T : MemberInfo

{
    protected ClrMember(T ReflectedElement)
        : base(ReflectedElement)
    { }

    public abstract bool IsGeneric { get; }

    public virtual bool HasAttribute<A>(bool inherit = false)
        where A : Attribute => System.Attribute.IsDefined(ReflectedElement, typeof(A), inherit);

    public ClrType DeclaringType
        => ClrType.Get(ReflectedElement.DeclaringType);

    public abstract bool IsStatic { get; }

    public abstract bool IsAbstract { get; }

    public abstract bool IsPublic { get; }

    public abstract bool IsPrivate { get; }

}
