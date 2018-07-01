//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

using static metacore;

public sealed class ClrTypeArgument : ClrElement<Type, ClrTypeArgument>
{
    public static implicit operator Type(ClrTypeArgument a)
        => a.ReflectedElement;

    public static ClrTypeArgument Get(Type a, int pos)
        => new ClrTypeArgument(a, pos);

    ClrTypeArgument(Type a, int pos)
        : base(a)
    {
        this.Position = pos;
    }

    public override string Name
        => ReflectedElement.Name;

    public ClrType ArgumentType
        => ReflectedElement.ClrType().Require();

    public int Position { get; }

    public IClrTypeName TypeName
        => ClrType.Get(ReflectedElement).TypeName;

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => ReflectedElement.HasAttribute<A>();
}