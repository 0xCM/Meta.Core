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


using Meta.Core;

using static CommonBindingFlags;

partial class Reflections
{
    static readonly ConcurrentDictionary<Type, ReadOnlyList<ValueMember>> ValueMemberCache
       = new ConcurrentDictionary<Type, ReadOnlyList<ValueMember>>();

    /// <summary>
    /// If a reference type, returns the type; if a value type and not an enum, returns 
    /// the type; if an enum returns the unerlying integral type; if a nullable value type
    /// that is not an enum, returns the underlying type; if anullable enum returns the 
    /// non-nullable underlying integral type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static Type GetUnderlyingType(this Type t)
    {
        if (t.IsNullableType())
        {
            var _t = Nullable.GetUnderlyingType(t);
            return _t.IsEnum ? _t.GetEnumUnderlyingType() : _t;
        }
        else
            return t.IsEnum ? t.GetEnumUnderlyingType() : t;
    }

    /// <summary>
    /// Gets the binding flag that corresponds to the member instance type
    /// </summary>
    /// <param name="mit">The member instance type</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BindingFlags GetBindingFlag(this MemberInstanceType mit)
        => mit.IsStaticType() ? BindingFlags.Static : BindingFlags.Instance;

    /// <summary>
    /// Retrieves a public or non-public setter for a property if it exists
    /// </summary>
    /// <param name="p">The property to examine</param>
    /// <returns></returns>
    public static Option<MethodInfo> TryGetSetter(this PropertyInfo p)
        => p.GetSetMethod() ?? p.GetSetMethod(true);

    /// <summary>
    /// Retrieves a public or non-public getter for a property if it exists
    /// </summary>
    /// <param name="p">The property to examine</param>
    /// <returns></returns>
    public static Option<MethodInfo> TryGetGetter(this PropertyInfo p)
        => p.GetGetMethod() ?? p.GetGetMethod(true);

    /// <summary>
    /// Retrieves the public immutable  fields defined by he type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetDeclaredPublicImmutableFields(this Type t, MemberInstanceType mit)
        => from f in (mit.IsStaticType() 
                ? t.GetFields(BF_DeclaredPublicStatic) 
                : t.GetFields(BF_DeclaredPublicInstance))
           where f.IsInitOnly || f.IsLiteral
           select f;

    /// <summary>
    /// Retrieves the nonpublic immutable fields defined by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="mit"></param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetDeclaredNonPublicImmutableFields(this Type t, MemberInstanceType mit)
            => from f in (mit == MemberInstanceType.Instance
                ? t.GetFields(BF_DeclaredNonPublicInstance)
                : t.GetFields(BF_DeclaredNonPublicStatic))
               where f.IsInitOnly || f.IsLiteral
               select f;

    /// <summary>
    /// Retrieves the public and nonpublic immutable fields defined by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="mit"></param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetDeclaredImmutableFields(this Type t, MemberInstanceType mit)
            => t.GetDeclaredPublicImmutableFields(mit).Union(t.GetDeclaredNonPublicImmutableFields(mit));
    
    /// <summary>
    /// Retrieves the type's public inherited immutable instance fields
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetInheritedPublicImmutableFields(this Type t, MemberInstanceType mit)
        => from f in ((
                mit.IsStaticType() 
               ? t.BaseType?.GetFields(BF_AllPublicStatic) 
               : t.BaseType?.GetFields(BF_AllPublicInstance)) 
               ?? new FieldInfo[] { }
               )
           where f.IsInitOnly || f.IsLiteral
           select f;

    /// <summary>
    /// Retrieves the type's non-public fields
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetPublicImmutableFields(this Type t, MemberInstanceType mit)
        => t.GetInheritedPublicImmutableFields(mit).Union(t.GetDeclaredPublicImmutableFields(mit));

    /// <summary>
    /// Retrieves the non-public immutable instance fields declared by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetDeclaredRestrictedImmutableFields(this Type t)
        => t.GetFields(BF_DeclaredRestrictedInstance).Where(f => f.IsInitOnly || f.IsLiteral);

    /// <summary>
    /// Retrieves the non-public immutable instance fields inherited by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetInheritedRestrictedImmutableFields(this Type t)
        => t.BaseType?.GetFields(BF_AllRestrictedInstance)
                     ?.Where(f => f.IsInitOnly || f.IsLiteral) ?? new FieldInfo[] { };

    /// <summary>
    /// Retrieves the immutable instance fields inherited and declared by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetRestrictedImmutableFields(this Type t)
        => t.GetInheritedRestrictedImmutableFields().Union(t.GetDeclaredRestrictedImmutableFields());

    /// <summary>
    /// Retrieves the public properties declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="mit">The instance type</param>
    /// <param name="requireSetters">Whether the existence of setters are requied to satisfy matches</param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetDeclaredPublicProperties(this Type t, 
        MemberInstanceType mit,  bool requireSetters = false)
            => (mit == MemberInstanceType.Instance 
                ? t.GetProperties(BF_DeclaredPublicInstance) 
                : t.GetProperties(BF_DeclaredPublicStatic)
                ).Where(p => !p.IsIndexer() && (requireSetters ? p.HasSetter() : true));


    /// <summary>
    /// Retrieves the public instance properties declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="mit">The instance type</param>
    /// <param name="requireSetters">Whether the existence of setters are requied to satisfy matches</param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetDeclaredPublicInstanceProperties(this Type t, bool requireSetters = false)
        => t.GetDeclaredPublicProperties(MemberInstanceType.Instance, requireSetters);
    
    /// <summary>
    /// Retrieves the non-public properties declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="mit">The instance type</param>
    /// <param name="requireSetters">Whether the existence of setters are requied to satisfy matches</param>
    /// <returns></returns>

    public static IEnumerable<PropertyInfo> GetDeclaredNonPublicProperties(this Type t, 
        MemberInstanceType mit, bool requireSetters = false)
            => (mit == MemberInstanceType.Instance
                ? t.GetProperties(BF_DeclaredNonPublicInstance)
                : t.GetProperties(BF_DeclaredNonPublicStatic)
                ).Where(p => !p.IsIndexer() && (requireSetters ? p.HasSetter() : true));

    /// <summary>
    /// Retrieves all properties declared by the type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="requireSetters">Whether yielded properties must have setters</param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetDeclaredProperties(this Type t, bool requireSetters = false)
        => t.GetDeclaredNonPublicProperties(MemberInstanceType.Instance, requireSetters)
            .Concat(t.GetDeclaredNonPublicProperties(MemberInstanceType.Static, requireSetters))
            .Concat(t.GetDeclaredPublicProperties(MemberInstanceType.Instance, requireSetters))
            .Concat(t.GetDeclaredPublicProperties(MemberInstanceType.Static, requireSetters));
        


    /// <summary>
    /// Searches for non-public methods delcared by the type
    /// </summary>
    /// <param name="t">The type to search</param>
    /// <param name="mit">The instance type</param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredNonPublicMethods(this Type t,
        MemberInstanceType mit)
            => (mit == MemberInstanceType.Instance
                ? t.GetMethods(BF_DeclaredNonPublicInstance)
                : t.GetMethods(BF_DeclaredNonPublicStatic)
                );


    /// <summary>
    /// Retrieves the public instance properties declared by a supertype
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetInheritedPublicProperties(this Type t, bool requireSetters = false)
        => t.BaseType?.GetProperties(BF_AllPublicInstance)
                      .Where(p => !p.IsIndexer() && (requireSetters ? p.HasSetter() : true))
                      ?? new PropertyInfo[] { };

    /// <summary>
    /// Retrieves the inheritance chain for a specifed type, up to, but not including, <see cref="object"/>
    /// </summary>
    /// <param name="child">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<Type> BaseTypes(this Type child)
    {
        if (child.BaseType != null && child.BaseType != typeof(object))
        {
            var parent = child.BaseType;
            yield return parent;

            foreach (var grandfather in BaseTypes(parent))
                yield return grandfather;
        }
    }

    /// <summary>
    /// Retrieves all public instance properties declared or inherited by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="requireSetters"></param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetPublicProperties(this Type t, bool deduplicate, bool requireSetters = false)
    {
        //TODO: this approach is good enough for most cases but fails miserably in the general 
        //case because it doesn't deal with properties declared with new nor does it deal
        //properly with properties that have been overridden
        var props = MutableList.Create<PropertyInfo>();
        var types = MutableList.FromItems(t.BaseTypes());
        types.Add(t);
        foreach (var type in types)
        {
            type.GetDeclaredPublicProperties(MemberInstanceType.Instance, requireSetters).Iterate(
                p =>
                {
                    if (deduplicate)
                    {
                        var duplicate = props.FirstOrDefault(x => x.Name == p.Name);
                        if (duplicate != null)
                            props.Remove(duplicate);
                    }
                    props.Add(p);
                });
        }

        if (deduplicate && props.Count != props.Distinct().Count())
            throw new Exception($"Deduplication of the properties of type {t} was requested but deduplication failed");
        return props;
    }

    /// <summary>
    /// Retrieves the public instance Fields declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetDeclaredPublicFields(this Type t)
        => t.GetFields();

    /// <summary>
    /// Retrieves the public instance Fields declared by a supertype
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetInheritedPublicFields(this Type t)
        => t.BaseType?.GetFields(BF_AllPublicInstance) ?? new FieldInfo[] { };

    /// <summary>
    /// Retrieves all public instance Fields declared or inherited by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<FieldInfo> GetPublicFields(this Type t)
        => t.GetInheritedPublicFields().Union(t.GetFields());

    /// <summary>
    /// Gets the public methods inherited by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">The instance type classification</param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetInheritedPublicMethods(this Type t, MemberInstanceType InstanceType)
        => (InstanceType.IsStaticType()
            ? t.BaseType?.GetMethods(BF_PublicStatic)
            : t.BaseType?.GetMethods(BF_PublicInstance)) 
            ?? new MethodInfo[] { };

    /// <summary>
    /// Gets the public methods declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">The instance type classification</param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredPublicMethods(this Type t, MemberInstanceType InstanceType)
        => InstanceType.IsStaticType() 
        ? t.GetMethods(BF_DeclaredPublicStatic) 
        : t.GetMethods(BF_DeclaredPublicInstance);

    /// <summary>
    /// Gets the public methods inherited or declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">The instance type classification</param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetPublicMethods(this Type t, MemberInstanceType InstanceType)
        => t.GetInheritedPublicMethods(InstanceType).Concat(t.GetDeclaredPublicMethods(InstanceType));
           
    /// <summary>
    /// Retrieves a type's public and read-only fields of a specific type
    /// </summary>
    /// <typeparam name="T">The field value type</typeparam>
    /// <param name="declaringType"></param>
    /// <returns></returns>
    public static IReadOnlyDictionary<string, T> GetDeclaredPublicReadonlyFieldIndex<T>(this Type declaringType)
        => declaringType.GetDeclaredPublicImmutableFields(MemberInstanceType.Static).Where(f => f.FieldType == typeof(T))
                .Map(field =>
                    (
                        field.Name,
                        field.GetMemberValue<T>(null)
                    )).ToReadOnlyDictionary();

    /// <summary>
    /// Retrieves the public and not public methods declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">Whether to selct static or instance </param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredMethods(this Type t, MemberInstanceType InstanceType)
        => t.GetMethods(InstanceType.IsStaticType() 
            ? BF_DeclaredStatic : BF_DeclaredInstance);

    /// <summary>
    /// Retrieves the public and non-public static methods declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">Whether to selct static or instance </param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredStaticMethods(this Type t)
        => t.GetMethods(BF_DeclaredStatic);

    /// <summary>
    /// Retrieves the public and non-public static methods declared by a type that have a specific name
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">Whether to selct static or instance </param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredStaticMethods(this Type t, string name)
        => t.GetMethods(BF_DeclaredStatic).Where(m => m.Name == name);

    /// <summary>
    /// Retrieves the public and non-public instance methods declared by a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="InstanceType">Whether to selct static or instance </param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetDeclaredInstanceMethods(this Type t)
        => t.GetMethods(BF_DeclaredInstance);


    /// <summary>
    /// Retrieves all public properties exposed by a type and appropriately handles interface inheritance
    /// </summary>
    /// <param name="type">The type to examine</param>
    /// <returns></returns>
    /// <remarks>
    /// Taken from: http://stackoverflow.com/questions/358835/getproperties-to-return-all-properties-for-an-interface-inheritance-hierarchy
    /// </remarks>   
    public static PropertyInfo[] GetPublicInstanceProperties(this Type type)
    {
        if (type.IsInterface)
        {
            var propertyInfos = MutableList.Create<PropertyInfo>();

            var considered = MutableList.Create<Type>();
            var queue = new Queue<Type>();
            considered.Add(type);
            queue.Enqueue(type);
            while (queue.Count > 0)
            {
                var subType = queue.Dequeue();
                foreach (var subInterface in subType.GetInterfaces())
                {
                    if (considered.Contains(subInterface)) continue;

                    considered.Add(subInterface);
                    queue.Enqueue(subInterface);
                }

                var typeProperties = subType.GetProperties(
                    BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.Instance);

                var newPropertyInfos = typeProperties
                    .Where(x => !propertyInfos.Contains(x));

                propertyInfos.InsertRange(0, newPropertyInfos);
            }

            return propertyInfos.ToArray();
        }

        return type.GetProperties(BindingFlags.FlattenHierarchy
            | BindingFlags.Public | BindingFlags.Instance);
    }

    /// <summary>
    /// Gets the static methods defined on a specified type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetStaticMethods(this Type t)
        => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

    /// <summary>
    /// Gets the static methods defined on a specified type
    /// </summary>
    /// <param name="this">The type to examine</param>
    /// <returns></returns>
    public static IEnumerable<PropertyInfo> GetStaticProperties(this Type @this)
        => @this.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

    /// <summary>
    /// Retrieves a static method by name, irrespective of its visibility
    /// </summary>
    /// <param name="t">The declaring type</param>
    /// <param name="name">The name of the method</param>
    /// <returns></returns>
    public static MethodInfo GetStaticMethod(this Type t, string name) 
        => t.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

    /// <summary>
    /// Attempts to retrieves a static field by name, irrespective of its visibility
    /// </summary>
    /// <param name="t">The declaring type</param>
    /// <param name="name">The name of the method</param>
    /// <returns></returns>
    public static Option<FieldInfo> TryGetStaticField(this Type t, string name) 
        => t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic 
                | BindingFlags.Static | BindingFlags.FlattenHierarchy);

    /// <summary>
    /// Attempts to retrieve the value of a named static field
    /// </summary>
    /// <param name="t">The declaring type</param>
    /// <param name="name">The name of the method</param>
    /// <returns></returns>
    public static Option<V> TryGetStaticFieldValue<V>(this Type t, string name)
        => t.TryGetStaticField(name).Map(x => (V)x.GetValue(null));


    /// <summary>
    /// Discovers a type's automatic properties
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    static IReadOnlyList<ValueMember> GetAutoProps(Type t)
    {
        var afquery = from f in t.GetRestrictedImmutableFields()
                      where f.IsCompilerGenerated() && f.Name.EndsWith("__BackingField")
                      select f;
        var backingFields = afquery.ToReadOnlySet();

        var propertyidx = t.GetPublicProperties(true, false).ToDictionary(x => x.Name);
        var candidates = propertyidx.Keys.Map(x =>
                (prop: propertyidx[x], Name:  $"\u003C{x}\u003Ek__BackingField"));
        var autoprops = MutableList.Create<ValueMember>();
        foreach (var candidate in candidates)
        {
            backingFields.TryGetFirst(f => f.Name == candidate.Name)
                         .OnSome(f => autoprops.Add(new ValueMember(candidate.prop, f)));
        }
        return autoprops;       
    }

    /// <summary>
    /// Gets the members of a type that can contain/represent data (properties and fields)
    /// </summary>
    /// <param name="ValueObjectType"></param>
    /// <returns></returns>
    public static ReadOnlyList<ValueMember> GetValueMembers(this Type ValueObjectType)
        => ValueMemberCache.GetOrAdd(ValueObjectType, t =>
        {
            var members = MutableList.Create<ValueMember>();        
            var autoMembers = GetAutoProps(ValueObjectType);
            members.AddRange(autoMembers);
            var fieldMembers = t.GetPublicImmutableFields(MemberInstanceType.Instance).Select(x => new ValueMember(x));
            members.AddRange(fieldMembers);
            var propMembers = t.GetPublicProperties(false, true).Where(x => x.CanRead && x.CanWrite).Select(x => new ValueMember(x));
            members.AddRange(propMembers);

            return ReadOnlyList.Create(members);
        });


    /// <summary>
    /// Retrieves a type's private default constructor, if present; otherwise, none
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static Option<ConstructorInfo> TryGetDefaultPrivateConstructor(this Type t)
        => t.GetConstructor(BF_DeclaredRestrictedInstance, null, new Type[] { }, new ParameterModifier[] { });

}

