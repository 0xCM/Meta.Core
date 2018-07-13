//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public class HostedFieldList<TItem, THost> : IEnumerable<TItem>
    where THost : new()
{
    static THost Host { get; }

    static IReadOnlyDictionary<string, FieldInfo> Fields { get; }

    static IReadOnlyDictionary<string, TItem> Items { get; }

    public static bool Contains(TItem item)
        => Items.Values.Any(i => Object.Equals(i, item));

    public static bool Contains(string FieldName)
        => Fields.ContainsKey(FieldName);

    public static Option<TItem> TryFind(string FieldName)
        => Items.TryFind(FieldName);

    /// <summary>
    /// Finds the first item, if any, that satisfies a supplied predicate
    /// </summary>
    /// <param name="predicate">The predicate that will be applied</param>
    /// <returns></returns>
    public static Option<TItem> TryFind(Func<TItem, bool> predicate)
        => Items.Values.FirstOrDefault(x => predicate(x));

    static HostedFieldList()
    {
        Host = new THost();
        Fields = typeof(THost).GetDeclaredPublicImmutableFields(MemberInstanceType.Static).ToDictionary(x => x.Name);
        Items = (Fields.Select(kvp => (kvp.Key, (TItem)kvp.Value.GetValue(null)))).ToReadOnlyDictionary();
    }

    public HostedFieldList()
    {

    }

    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var item in Items.Values)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}


public class Defaults : HostedFieldList<string, Defaults>
{
    public const string Name = "Default";
}
