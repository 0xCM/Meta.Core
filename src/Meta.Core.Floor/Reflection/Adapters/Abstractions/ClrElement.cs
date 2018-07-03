//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

using static minicore;

/// <summary>
/// Ultimate base type for reflective element adapters
/// </summary>
/// <typeparam name="T">The element type</typeparam>
/// <typeparam name="E">The derived subtype</typeparam>
public abstract class ClrElement<T, E> : IClrElement
    where E : ClrElement<T,E>
    where T : class

{
    public static bool operator ==(ClrElement<T, E> x, ClrElement<T, E> y)
        => x.Equals(y);

    public static bool operator !=(ClrElement<T, E> x, ClrElement<T, E> y)
        => not(x.Equals(y));

    protected ClrElement(T ReflectedElement)
    {        
        this.ReflectedElement = shameIfNull(ReflectedElement);
    }

    public T ReflectedElement { get; private set; }

    object IClrElement.ReflectedElement
        => ReflectedElement;

    public Option<A> TryGetCustomAttribute<A>() 
        where A : Attribute
            => HasAttribute<A>()  ? GetCustomAttribute<A>()  : none<A>();

    public override string ToString()
        => ReflectedElement.ToString();

    /// <summary>
    /// Attemps to get the value of a specified attribute
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public abstract Option<A> Attribute<A>()
        where A : Attribute;

    public abstract A GetCustomAttribute<A>()
        where A : Attribute;

    public abstract bool HasAttribute<A>()
        where A : Attribute;    

    public abstract string Name { get; }

    public override bool Equals(object obj)
        => ReflectedElement.Equals(obj);

    public override int GetHashCode()
        => ReflectedElement.GetHashCode();
}
