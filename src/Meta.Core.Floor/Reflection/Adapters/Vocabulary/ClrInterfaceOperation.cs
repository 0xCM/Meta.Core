//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;

using static minicore;
using Meta.Core;

/// <summary>
/// Models an operation declared by an interface as determined by reflected metadata
/// </summary>
public sealed class ClrInterfaceOperation : ClrMethod<ClrInterfaceOperation>
{
    public static implicit operator ClrInterfaceOperation(MethodInfo m)
        => new ClrInterfaceOperation(m);

    public static ClrInterfaceOperation Get(MethodInfo x)
        => new ClrInterfaceOperation(x);

    public ClrInterfaceOperation(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {
        if (not(ReflectedElement.DeclaringType.IsInterface))
            throw new ArgumentException($"The {ReflectedElement} type is not an interface operation");
    }

    public object Invoke(object instance, object[] args)
        => ReflectedElement.Invoke(instance, args);

    public TResult Invoke<TResult>(object instance, object[] args)
        => (TResult)ReflectedElement.Invoke(instance, args);

    public ClrInterface DeclaringInterface
        => ClrInterface.Get(DeclaringType.ReflectedElement);

    public override bool IsAbstract
        => true;

    public override bool IsPrivate
        => false;

    public override bool IsPublic
        => true;

    public override bool IsStatic
        => false;
}

/// <summary>
/// Typed <see cref="ClrInterfaceOperation"/> collection
/// </summary>
public sealed class ClrInterfaceOperations : TypedItemList<ClrInterfaceOperations, ClrInterfaceOperation>
{
    public static implicit operator ClrInterfaceOperations(ClrInterfaceOperation[] items)
        => Create(items);

    public static implicit operator ClrInterfaceOperations(ReadOnlyList<ClrInterfaceOperation> items)
        => Create(items);

    public static implicit operator ClrInterfaceOperations(Seq<ClrInterfaceOperation> items)
        => Create(items.Stream());

}