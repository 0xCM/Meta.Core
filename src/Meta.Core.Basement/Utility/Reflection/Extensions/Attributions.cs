//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;

using static CommonBindingFlags;

using Meta.Core;

partial class Reflections
{
    /// <summary>
    /// Gets the type attributions for the specified assembly
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="a">The assembly to search</param>
    /// <returns></returns>
    public static IDictionary<Type, A> GetTypeAttributions<A>(this Assembly a)
        where A : Attribute
    {
        var q = from t in a.GetTypes()
                where Attribute.IsDefined(t, typeof(A))
                let attrib = t.GetCustomAttribute<A>()
                select new
                {
                    Type = t,
                    Attribute = attrib
                };
        return q.ToDictionary(x => x.Type, x => x.Attribute);
    }

    /// <summary>
    /// Gets the type attributions for the specified assembly
    /// </summary>
    /// <param name="a">The assembly to search</param>
    /// <param name="fullAttributeTypeName">The full type name of the attribute</param>
    /// <returns></returns>
    public static IDictionary<Type, dynamic> GetTypeAttributions(this Assembly a, string fullAttributeTypeName)
    {
        var attributions = new Dictionary<Type, dynamic>();
        foreach (var t in a.GetTypes())
        {
            foreach (var attrib in t.GetCustomAttributes())
            {
                if (attrib.GetType().FullName == fullAttributeTypeName)
                {
                    attributions[t] = attrib;
                    continue;
                }
            }
        }
        return attributions;
    }


    /// <summary>
    /// Retrieves type attribution values from a stream of types
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <param name="types"></param>
    /// <returns></returns>
    public static IReadOnlyDictionary<Type, Option<A>> GetTypeAttributions<A>(this IEnumerable<Type> types)
        where A : Attribute
        => (from type in types
            let attrib = type.GetCustomAttribute<A>(true)
            select (type, attrib != null
                    ? Option.Some(attrib)
                    : Option.None<A>())).ToReadOnlyDictionary();

    /// <summary>
    /// Retrieves the type's properties together with applied attributes
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<PropertyInfo, A> GetPropertyAttributions<A>(this Type t) where A : Attribute
    {
        var q = from p in t.GetProperties(BF_Instance)
                where Attribute.IsDefined(p, typeof(A))
                let attrib = p.GetCustomAttribute<A>()
                select new
                {
                    Member = p,
                    Attribute = attrib
                };
        return q.ToDictionary(x => x.Member, x => x.Attribute);
    }

    /// <summary>
    /// Retrieves the type's fields together with applied attributes
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IDictionary<FieldInfo, A> GetFieldAttributions<A>(this Type t)
        where A : Attribute
    {
        var q = from p in t.GetFields(BF_Instance)
                where Attribute.IsDefined(p, typeof(A))
                let attrib = p.GetCustomAttribute<A>()
                select new
                {
                    Member = p,
                    Attribute = attrib
                };
        return q.ToDictionary(x => x.Member, x => x.Attribute);
    }

    /// <summary>
    /// Retrieves the attribution index for the identified methods declared by the type
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">The member instance type</param>
    /// <returns></returns>
    public static IDictionary<MethodInfo, A> GetMethodAttributions<A>(this Type t,
            MemberInstanceType InstanceType = MemberInstanceType.Instance)
                where A : Attribute
    {
        var q = from m in t.GetDeclaredMethods(InstanceType)
                where Attribute.IsDefined(m, typeof(A))
                let attrib = m.GetCustomAttribute<A>()
                select new
                {
                    Member = m,
                    Attribute = attrib
                };
        return q.ToDictionary(x => x.Member, x => x.Attribute);
    }

    /// <summary>
    /// Gets the value of a member attribute if it exists 
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="m">The member</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static Option<A> GetOptionalAttribute<A>(this MemberInfo m) where A : Attribute
        => m.GetCustomAttribute<A>();


}