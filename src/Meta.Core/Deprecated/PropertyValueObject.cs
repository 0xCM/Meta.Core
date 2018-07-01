//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Diagnostics;

using static metacore;

/// <summary>
/// Base class for objects that are identified only by the properties they encapsulate
/// </summary>
/// <typeparam name="T">The concrete value object type</typeparam>
/// <remarks>
/// Provides basic facility for representing values to compensate for the fact 
/// that, regrettably, C# does not have a record type, comparable to that of F# for instance
/// Value objects should normally be immutable and composed only of primitives, value types
/// and collections of other value objects
/// </remarks>
public abstract class PropertyValueObject<T> : Representation<T>, IValueObject<T> where T : PropertyValueObject<T>
{
    static Func<T> CreateFactory() 
        =>  () => (T)FormatterServices.GetUninitializedObject(typeof(T));

    static Func<T> Factory = CreateFactory();

    /// <summary>
    /// Determines whether two objects represent the same value
    /// </summary>
    /// <param name="lhs">The first object</param>
    /// <param name="rhs">The second object</param>
    /// <returns></returns>
    public static bool operator ==(PropertyValueObject<T> lhs, PropertyValueObject<T> rhs)
    {
        if (System.Object.ReferenceEquals(lhs, rhs))
            return true;

        if (((object)lhs == null) || ((object)rhs == null))
            return false;

        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Determines whether two objects represent different values
    /// </summary>
    /// <param name="lhs">The first object</param>
    /// <param name="rhs">The second object</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool operator !=(PropertyValueObject<T> lhs, PropertyValueObject<T> rhs) => !(lhs == rhs);

    static readonly IReadOnlyList<PropertyInfo> properties;

    static PropertyValueObject()
    {
        properties = typeof(T).GetProperties().Where(x => x.CanRead && x.CanWrite).ToReadOnlyList();
    }

    const int P1 = 17;
    const int P2 = 23;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IReadOnlyList<ValueMember> IValueObject.ValueMembers
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    
    IReadOnlyList<ValueMemberValue> IValueObject.Destructure()
    {
        throw new NotSupportedException();
    }


    /// <summary>
    /// If the member-wise clone is sufficient, no need to explicitly implement in subclass
    /// </summary>
    /// <returns></returns>
    public virtual T Clone() 
        =>(T)this.MemberwiseClone();

    /// <summary>
    /// Creates a copy and applies the supplied function to yield a transformed value
    /// </summary>
    /// <param name="transformer">The transformation function to apply</param>
    /// <returns></returns>
    public T Transform(Func<T, T> transformer) =>
        transformer(Clone());

    /// <summary>
    /// Adjudicates value equality
    /// </summary>
    /// <param name="obj">The object to compare this object to</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public sealed override bool Equals(object obj)
    {
        var other = obj as T;
        return other != null ? Equals(other) : false;
    }
    /// <summary>
    /// Calculates hash code based on value
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough]
    public sealed override int GetHashCode()
    {
        unchecked
        {
            return GetHashCode(P1, P2);
        }
    }


    /// <summary>
    /// Calculates hash code for value object
    /// </summary>
    /// <param name="p1">The first factor</param>
    /// <param name="p2">The second factor</param>
    /// <remarks>
    /// If usage context is performance sensitive, then override and implement without reflection!
    /// See http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
    /// </remarks>
    [DebuggerStepThrough]
    protected virtual int GetHashCode(int p1, int p2)
    {
        var hash = P1 * P2;
        foreach (var p in this.GetType().GetProperties())
        {
            var pVal = p.GetValue(this);
            hash = hash * P2 + (pVal != null ? pVal.GetHashCode() : 0);
        }
        return hash;
    }

    /// <summary>
    /// Determine whether two value objects have identical values and are thus equal
    /// </summary>
    /// <param name="other">The other value object</param>
    /// <returns></returns>
    public virtual bool Equals(T other)
    {
        if (GetType() != typeof(T))
            return false;

        bool result = true;
        foreach (var p in GetType().GetProperties())
        {
            var xVal = p.GetValue(this);
            var yVal = p.GetValue(other);

            if (xVal == null && yVal != null)
                return false;                    

            if (xVal != null && yVal == null)
                return false;

            if (yVal == null && yVal == null)
                continue;
            else if (xVal != null)
                result &= xVal.Equals(yVal);
            else
                result &= yVal.Equals(xVal);

            if (!result)
                break;

        }
        return result;
    }

    /// <summary>
    /// Formats a supplied object by rendering it as a collection of key-value pairs
    /// Obviously, this will work for any type but, in the case of an object that is fully-characterized
    /// by its public properties, the formatted string will represent the total state of the object
    /// </summary>
    public virtual string Format()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < properties.Count; i++)
        {
            var property = properties[i];
            sb.AppendFormat("{0}={1}", property.Name, property.GetValue(this));
            if (i < properties.Count - 1)
                sb.Append(";");
        }
        return sb.ToString();

    }

    /// <summary>
    /// Returns the objects' property values as a KVP map
    /// </summary>
    /// <returns></returns>
    public IDictionary<string,object> ToValueMap() =>
        properties.Select(p => new
        {
            Name = p.Name,
            Value = p.GetValue(this)
        }).ToDictionary(x => x.Name, x => x.Value);


    public override DestructuredRepresentation Destructure()
    {
        var attributions = GetPropertyAttributions();
        if (attributions.Count != 0)
            return base.Destructure();
        else
            return new DestructuredRepresentation(
                typeof(T).FullName, mapi(properties, (i, p) => new RepresentationAttributeValue(i, p.Name, p.GetValue(this))));
    }


}



