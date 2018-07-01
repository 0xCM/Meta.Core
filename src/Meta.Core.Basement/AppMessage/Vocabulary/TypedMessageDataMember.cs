//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;

class TypedMessageDataMember
{
    static ConcurrentDictionary<Type, IReadOnlyDictionary<string, TypedMessageDataMember>> cache
        = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, TypedMessageDataMember>>();

    public static IReadOnlyDictionary<string, TypedMessageDataMember> Get(Type type)
        => cache.GetOrAdd(type, t => (from p in t.GetProperties()
                                        where p.GetIndexParameters().Length == 0 && p.GetMethod != null
                                        select new TypedMessageDataMember(p)).Union(
            from f in t.GetFields()
            select new TypedMessageDataMember(f)).ToDictionary(x => x.Member.Name));

    public readonly MemberInfo Member;

    public TypedMessageDataMember(MemberInfo member)
    {
        this.Member = member;
    }

    public string Name
        => Member.Name;

    public object GetValue(object instance)
        => (Member as PropertyInfo)?.GetValue(instance)
        ?? (Member as FieldInfo)?.GetValue(instance);

}


