//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

/// <summary>
/// Base type for classes that consist of an explicit set of constant or static readonly public fields
/// </summary>
/// <typeparam name="TField">The field type</typeparam>
/// <typeparam name="TSet">The derived subtype</typeparam>
public abstract class ImmutableFieldIndex<TField, TSet> 
    where TSet : ImmutableFieldIndex<TField, TSet>
    where TField : IEquatable<TField>
{
    static IReadOnlyDictionary<string, TField> index =
        (typeof(TSet).GetDeclaredPublicReadonlyFieldIndex<TField>()
                .Select(x => (x.Key.ToUpper(), x.Value)))
                .ToReadOnlyDictionary();

    /// <summary>
    /// Finds the field in the index with the given name
    /// </summary>
    /// <param name="name">The name of the field</param>
    /// <returns></returns>
    public static TField Find(string name) 
        =>  index[name.ToUpper()];

    /// <summary>
    /// Specifies whether the identified field exists in the index
    /// </summary>
    /// <param name="name">The name of the field to look for</param>
    /// <returns></returns>
    public static bool Exists(string name) 
        => index.ContainsKey(name.ToUpper());

    public IEnumerator<TField> GetEnumerator() 
        => index.Values.GetEnumerator();


    public static Option<TField> TryFind(string name)
        => index.TryFind(name);
}

