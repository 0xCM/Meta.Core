//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Non-generic contract for a value object, which is a reference type that is characterized only by the values 
/// it represents and otherwise has no identity
/// </summary>
public interface IValueObject 
{
    /// <summary>
    /// Gets the value members defined by the object
    /// </summary>
    IReadOnlyList<ValueMember> ValueMembers { get; }

    IReadOnlyList<ValueMemberValue> Destructure();
}


/// <summary>
/// Generic contract for a value object, which is a reference type that is characterized only by the values 
/// it represents and otherwise has no identity
/// </summary>
public interface IValueObject<T> : IValueObject, IEquatable<T>
{

}

