//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;


/// <summary>
/// Base class for objects that are identified only by the fields they encapsulate
/// </summary>
/// <typeparam name="T">The concrete value object type</typeparam>
/// <remarks>
/// Provides basic facility for representing values to compensate for the fact 
/// that, regrettably, C# does not have a record type, comparable to that of F# for instance
/// Value objects should normally be immutable and composed only of primitives, value types
/// and collections of other value objects
/// </remarks>
public abstract class ValueObject<T> : IValueObject<T>, IEquatable<T> 
    where T : ValueObject<T>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    static readonly Lazy<IReadOnlyList<ValueMember>> _ValueMembers
        = new Lazy<IReadOnlyList<ValueMember>>(() => ValueMember.Get<T>());

    static Func<T> Factory = CreateFactory();

    const int P1 = 17;
    const int P2 = 23;

    static Func<T> CreateFactory()
        => () => (T)FormatterServices.GetUninitializedObject(typeof(T));


    static IReadOnlyList<ValueMemberValue> Destructure(ValueObject<T> x)
        => (from m in ValueMembers
            let value = m.GetValue(x)
            select new ValueMemberValue(typeof(T), m.Name, value)
                    ).ToList();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static IReadOnlyList<ValueMember> ValueMembers 
        => _ValueMembers.Value;


    /// <summary>
    /// The object equality operator
    /// </summary>
    /// <param name="lhs">The first object</param>
    /// <param name="rhs">The second object</param>
    /// <returns></returns>
    public static bool operator ==(ValueObject<T> lhs, ValueObject<T> rhs)
    {
        if (object.ReferenceEquals(lhs, rhs))
            return true;

        if (((object)lhs == null) || ((object)rhs == null))
            return false;

        return lhs.Equals(rhs);        
    }

    /// <summary>
    /// The object not equal operator
    /// </summary>
    /// <param name="lhs">The first object</param>
    /// <param name="rhs">The second object</param>
    /// <returns></returns>
    public static bool operator !=(ValueObject<T> lhs, ValueObject<T> rhs) 
        => !(lhs == rhs);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Lazy<IReadOnlyList<ValueMemberValue>> _MemberValues { get; }

    protected ValueObject()
        => _MemberValues = new Lazy<IReadOnlyList<ValueMemberValue>>(() => Destructure(this));

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IReadOnlyList<ValueMember> IValueObject.ValueMembers 
        => ValueMembers;

    /// <summary>
    /// Adjudicates value equality
    /// </summary>
    /// <param name="obj">The object to compare this object to</param>
    /// <returns></returns>
    public sealed override bool Equals(object obj)
        => (obj as T) != null ? Equals(obj as T) : false;

    /// <summary>
    /// Calculates hash code based on value
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough]
    public override int GetHashCode()
        { unchecked { return GetHashCode(P1, P2); } }


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

        foreach (var m in ValueMembers)
        {
            var fval = m.GetValue(this);
            hash = hash * P2 + (fval != null ? fval.GetHashCode() : 0);
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
        if (other == null)
            return false;

        if (GetType() != other.GetType())
            return false;

        bool result = true;
        foreach (var m in ValueMembers)
        {
            var xVal = m.GetValue(this);
            var yVal = m.GetValue(other);

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
    public virtual string FormatValue()
    {
        var sb = new StringBuilder();
        var count = ValueMembers.Count;
        for (int i = 0; i < count; i++)
        {
            var field = ValueMembers[i];
            sb.AppendFormat("{0}={1}", field.Name, field.GetValue(this));
            if (i < count - 1)
                sb.Append(";");
        }
        return sb.ToString();
    }

    public IReadOnlyList<ValueMemberValue> Destructure()
        => _MemberValues.Value;

    public IReadOnlyList<(ValueMemberValue, ValueMemberValue)> Delta(T other)
        => (Destructure().Zip(other.Destructure(),
            (x, y) => new
            {
                x.MemberName,
                First = x,
                Second = y
            }).Where(x => !(object.Equals(x.First.Value, x.Second.Value)))
              .Select(x => (x.First, x.Second))).ToReadOnlyList();
    
                 
    public virtual Option<TKey> GetKey<TKey>()
        => Option.None<TKey>();

    protected static void SetMemberValue(T ValueObject, string MemberName, object MemberValue)
    {
        var member = ValueMembers.Single(f => f.Name == MemberName);
        member.SetValue(ValueObject, MemberValue);
        member.SetValue(ValueObject, Convert.ChangeType(MemberValue, member.ValueType));
    }

    public static T FromMemberValues(IEnumerable<ValueMemberValue> values)
    {
        var ValueObject = Factory();
        values.Iterate(value => SetMemberValue(ValueObject, value.MemberName, value.Value));
        return ValueObject;
    }

    public override string ToString()
        => FormatValue();
}


/// <summary>
/// Base type for keyed value objects
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TKey"></typeparam>
public abstract class ValueObject<T, TKey> : ValueObject<T>
    where T : ValueObject<T>
{
    public TKey Key { get; }

    public ValueObject(TKey Key)
        => this.Key = Key;

    public override sealed Option<K> GetKey<K>()
        => (K)(object)Key;
}
