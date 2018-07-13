//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


/// <summary>
/// Represents a data slot in the declaring type and may
/// correspond to either a field or property
/// </summary>
public readonly struct ValueMember
{    
    public static IReadOnlyList<ValueMember> Get<T>()
        => (typeof(T)).GetValueMembers();

    public static implicit operator ValueMember(PropertyInfo Member) 
        => new ValueMember(Member);

    public static implicit operator ValueMember(FieldInfo Member) 
        => new ValueMember(Member);


    public ValueMember(PropertyInfo Member)
    {
        this.Member = Member;
        this.IsField = false;
        this.BackingField = null;
    }

    public ValueMember(FieldInfo Member)
    {
        this.Member = Member;
        this.IsField = true;
        this.BackingField = null;
    }

    public ValueMember(PropertyInfo Member, FieldInfo BackingField)
    {
        this.Member = Member;
        this.IsField = false;
        this.BackingField = BackingField;
    }

    MemberInfo Member { get; }

    bool IsField { get; }

    FieldInfo BackingField { get; }

    public object GetValue(object o)
    {
        var objType = o.GetType();
        var declarer = Member.DeclaringType;
        return IsField ? (Member as FieldInfo).GetValue(o)
            : (Member as PropertyInfo).GetValue(o);
    }

    public T GetValue<T>(object o)
        => (T)( IsField ? (Member as FieldInfo).GetValue(o) 
            : (Member as PropertyInfo).GetValue(o));

    public Option<A> GetAttribute<A>() where A : Attribute
        => Member.GetCustomAttribute<A>();

    public void SetValue(object o, object value)
    {
        if (IsField)
            (Member as FieldInfo).SetValue(o, value);
        else
        {
            //A property with no setter but with a backing field
            if (BackingField != null)
                BackingField.SetValue(o, value);
            else
                (Member as PropertyInfo).SetValue(o, value);
        }
    }

    /// <summary>
    /// The member name
    /// </summary>
    public string Name
        => Member.Name;

    /// <summary>
    /// The value type that defines the member
    /// </summary>
    public Type ValueType
        => IsField ? (Member as FieldInfo).FieldType : (Member as PropertyInfo).PropertyType;

    /// <summary>
    /// Provides access to the represented member
    /// </summary>
    public MemberInfo MemberInfo
        => Member;

    public override string ToString()
        => Member.ToString();
}
