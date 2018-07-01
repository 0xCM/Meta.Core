//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;

public abstract class HostedFunctionList<THost> : IEnumerable<MethodInfo>
    where THost : new()
{
    static readonly THost Host;
    static readonly IReadOnlyList<MethodInfo> Items;

    static HostedFunctionList()
    {
        Host = new THost();
        Items = typeof(THost).GetStaticMethods().ToList();

    }

    protected HostedFunctionList()
    {

    }

    public IEnumerator<MethodInfo> GetEnumerator()
    {
        foreach (var item in Items)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();
}
