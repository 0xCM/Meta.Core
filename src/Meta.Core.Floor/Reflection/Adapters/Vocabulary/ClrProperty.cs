//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

/// <summary>
/// Defines a convenience adapter for <see cref="PropertyInfo"/> values
/// </summary>
public sealed class ClrProperty : ClrMember<PropertyInfo, ClrProperty>
{
    /// <summary>
    /// Obtains a <see cref="ClrProperty"/> given a <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static ClrProperty Get(PropertyInfo x)
        => new ClrProperty(x);

    /// <summary>
    /// Converts a <see cref="ClrProperty"/> representation to the underlying
    /// <see cref="PropertyInfo"/> value it encapsualtes
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator PropertyInfo(ClrProperty x) 
        => x.ReflectedElement;

    /// <summary>
    /// Converts a <see cref="PropertyInfo"/> value to a <see cref="ClrProperty"/> representation
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator ClrProperty(PropertyInfo x) 
        => new ClrProperty(x);

    public ClrProperty(PropertyInfo ReflectedElement)
        : base(ReflectedElement)
    { }

    /// <summary>
    /// Specifies the name of the property
    /// </summary>
    public override string Name 
        => ReflectedElement.Name;

    /// <summary>
    /// Retrives the value of an attached attribute
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public override A GetCustomAttribute<A>() 
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    /// <summary>
    /// Determines whether an attribute is applied to the property
    /// </summary>
    /// <typeparam name="A">The attribute type to check</typeparam>
    /// <returns></returns>
    public override bool HasAttribute<A>() 
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    /// <summary>
    /// Specifies the property's type
    /// </summary>
    public ClrType PropertyType
        => ClrType.Get(ReflectedElement.PropertyType);

    /// <summary>
    /// Specifies the deduced multiplicity of the property
    /// </summary>
    public Multiplicity Multiplicity
    {
        get
        {
            if (PropertyType.IsEnumerableType)
                return Multiplicity.MoreThanOne;
            else
                if(PropertyType.IsStructType)
                    if (PropertyType.IsNullableType)
                        return Multiplicity.ZeroOrOne;
                    else
                        return Multiplicity.One;
                else
                    if (PropertyType.BaseTypes.Contains(ClrType.Get<System.Collections.IEnumerable>()))
                        return Multiplicity.MoreThanOne;
                    else
                        return Multiplicity.ZeroOrOne;
        }
    }

    /// <summary>
    /// Specifies whether the property is static
    /// </summary>
    public override bool IsStatic 
        => ReflectedElement.GetMethod != null
         ? ReflectedElement.GetMethod.IsStatic
         : ReflectedElement.SetMethod.IsStatic;

    /// <summary>
    /// Specifies that properties are always non-generic
    /// </summary>
    public override bool IsGeneric 
        => false;

    /// <summary>
    /// Specifies whether the property is abstract
    /// </summary>
    public override bool IsAbstract 
        => ReflectedElement.GetMethod.IsAbstract;

    /// <summary>
    /// Specifies whether the property is an indexer
    /// </summary>
    public bool IsIndexer
        => ReflectedElement.IsIndexer();

    /// <summary>
    /// Specifies whether a setter is defined for the property
    /// </summary>
    public bool HasSetter
        => ReflectedElement.HasSetter();

    /// <summary>
    /// Gets the value of the property
    /// </summary>
    /// <param name="o">The object instance to query, if specified</param>
    /// <returns></returns>
    public object GetValue(object o = null) 
        => ReflectedElement.GetValue(o);    

    /// <summary>
    /// Gets the value of the property and converts the value to the supplied type
    /// </summary>
    public object GetValue(object o, Type conversionType)
        => Convert.ChangeType(ReflectedElement.GetValue(o), conversionType);

    /// <summary>
    /// Gets the value of the property and either casts or converts the value to the supplied type
    /// </summary>
    /// <typeparam name="V">The value's type</typeparam>
    /// <param name="o">The defining object</param>
    /// <param name="convert"></param>
    /// <returns></returns>
    public V GetValue<V>(object o, bool convert = false)
        => convert 
        ? (V)Convert.ChangeType(ReflectedElement.GetValue(o),typeof(V)) 
        : (V)ReflectedElement.GetValue(o);

    /// <summary>
    /// Manipulates the property's value
    /// </summary>
    /// <param name="o"></param>
    /// <param name="value"></param>
    public void SetValue(object o, object value)
        => ReflectedElement.SetValue(o, value);

    /// <summary>
    /// Specifies whether a public setting is defined for the property
    /// </summary>
    public bool HasPublicSetter
        => ReflectedElement.TryGetSetter().MapValueOrDefault(x => x.IsPublic);

    /// <summary>
    /// Specifies whether all accessors defined for the property are public
    /// </summary>
    public override bool IsPublic 
        => ReflectedElement.GetAccessors(true).All(x => x.IsPublic);

    /// <summary>
    /// Specifies whether all accessors defined for the property are private
    /// </summary>
    public override bool IsPrivate 
        => ReflectedElement.GetAccessors(true).All(x => x.IsPrivate);

    /// <summary>
    /// Specifies whether the property has been declared as virtual
    /// </summary>
    public bool IsVirtual
        => ReflectedElement.GetAccessors(true).All(x => x.IsVirtual);

    /// <summary>
    /// Specifies whether the property is an override of a property declared in an ancestor
    /// </summary>
    public bool IsOverride
        => ReflectedElement.GetAccessors(true).Where(m
            => m.GetBaseDefinition().DeclaringType != m.DeclaringType).Count() > 0;       
}

