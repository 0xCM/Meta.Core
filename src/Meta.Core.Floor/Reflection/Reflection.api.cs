//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO;

using static CommonBindingFlags;

partial class metacore
{
    static ConcurrentDictionary<Type, PropertyInfo[]> _propsCache
        = new ConcurrentDictionary<Type, PropertyInfo[]>();

    static ConcurrentDictionary<Type, ConstructorInfo[]> _constructorCache
        = new ConcurrentDictionary<Type, ConstructorInfo[]>();

    static ConcurrentDictionary<Type, Type> _ulTypeCache
        = new ConcurrentDictionary<Type, Type>();

    static ConcurrentDictionary<Type, Type> _nnTypeCache 
        = new ConcurrentDictionary<Type, Type>();


    /// <summary>
    /// If non-nullable, returns the supplied type. If nullable, returns the underlying type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type nonNullable(Type t)
        => _nnTypeCache.GetOrAdd(t, x => x.IsNullableType() ? Nullable.GetUnderlyingType(x) : x);

    /// <summary>
    /// Defines <see cref="assembly(AssemblyChoice)"/> invocation options
    /// </summary>
    public enum AssemblyChoice
    {
        /// <summary>
        /// Specifies the intent to retrieve the calling assembly
        /// </summary>
        Calling = 0,
        /// <summary>
        /// Specifies the intent to retrieve the entry assembly
        /// </summary>
        Entry = 1
    }

    /// <summary>
    /// Retrieves the entry or calling assembly (default) or entry assemby as specified
    /// </summary>
    /// <param name="choice"></param>
    /// <returns></returns>
    public static ClrAssembly assembly(AssemblyChoice choice = AssemblyChoice.Calling)
        => choice == AssemblyChoice.Calling
        ? Assembly.GetCallingAssembly()
        : Assembly.GetEntryAssembly();

    /// <summary>
    /// Retrieves the identified <see cref="MethodInfo"/>
    /// </summary>
    /// <param name="o">The object on which the method is defined</param>
    /// <param name="name"></param>
    /// <returns></returns>
    static MethodInfo GetDelaredMethod(this object o, string name)
        => o.GetType().GetMethod(name, BF_DeclaredInstance);

    /// <summary>
    /// Dynamically invokes a named method on an object
    /// </summary>
    /// <param name="o">The object that defines the method</param>
    /// <param name="methodName">The method to invoke</param>
    /// <param name="parms">The parameters to pass to the method</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void invoke(object o, string methodName, params object[] parms)
        => o.GetDelaredMethod(methodName).Invoke(o, parms);

    /// <summary>
    /// Retrieves the identified <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="o">The object on which the property is defined</param>
    /// <param name="propname"></param>
    /// <returns></returns>
    static PropertyInfo GetProperty(object o, string propname)
        => o.GetType().GetProperty(propname, BF_Instance);

    /// <summary>
    /// Retrieves the public properties declared on an object's type
    /// </summary>
    /// <param name="o">The object</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<PropertyInfo> props(object o)
        => o == null
         ? array<PropertyInfo>()
         : _propsCache.GetOrAdd(o.GetType(),
             t => t.GetProperties(BF_PublicInstance));

    /// <summary>
    /// Retrieves the public properties declared on a type
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<PropertyInfo> props(Type type)
        => _propsCache.GetOrAdd(type, t => t.GetProperties(BF_PublicInstance));

    /// <summary>
    /// Gets the public properties defined on the supplied type
    /// </summary>
    /// <typeparam name="T">The type to examine</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<PropertyInfo> props<T>()
        => _propsCache.GetOrAdd(typeof(T),
                t => t.GetProperties(BF_PublicInstance));

    /// <summary>
    /// Attempts the retrieve a named property declared on a type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="name">The name of the property</param>
    /// <returns></returns>
    public static Option<PropertyInfo> prop(Type t, string name)
        => props(t).FirstOrDefault(p => p.Name == name);

    /// <summary>
    /// Gets the value of the identified property
    /// </summary>
    /// <param name="o">The object on which the property is defined</param>
    /// <param name="propname">The name of the property</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object propval(object o, string propname)
        => GetProperty(o,propname)?.GetValue(o);

    /// <summary>
    /// Gets the value of the identified property
    /// </summary>
    /// <typeparam name="T">The property value type</typeparam>
    /// <param name="o">The object on which the property is defined</param>
    /// <param name="propname">The name of the property</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T propval<T>(object o, string propname)
        => (T)propval(o, propname);

    /// <summary>
    /// Sets the identified property on the object to the supplied value
    /// </summary>
    /// <param name="o">The object whose property will be set</param>
    /// <param name="propname">The property that will be set</param>
    /// <param name="value">The value of the property</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void propval(object o, string propname, object value)
        => GetProperty(o,propname)?.SetValue(o, value);

    /// <summary>
    /// Gets the CLR runtime type of the identified property
    /// </summary>
    /// <param name="o">An instance of the type on which the property is defined</param>
    /// <param name="propname">The name of the property</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type proptype(object o, string propname)
        => o.GetType().GetProperty(propname).PropertyType;

    /// <summary>
    /// Retrieves any declared public/non-public,static or instance property with the given name
    /// </summary>
    /// <typeparam name="T">The type that defines the property</typeparam>
    /// <param name="name">The name of the property</param>
    /// <returns></returns>
    /// <remarks>
    /// This operation does not use the property cache, which only maintains lookups for public/instance properties
    /// </remarks>
    public static Option<PropertyInfo> prop<T>(string name)
        => typeof(T).GetProperties(BF_Declared).TryGetFirst(x => x.Name == name);

    /// <summary>
    /// Retrieves any declared public/non-public,static or instance field with the given name
    /// </summary>
    /// <typeparam name="T">The type that defines the field</typeparam>
    /// <param name="name">The name of the field</param>
    /// <returns></returns>
    public static Option<FieldInfo> field<T>(string name)
        => typeof(T).GetFields(BF_Declared).TryGetFirst(x => x.Name == name);

    /// <summary>
    /// Attempts to retrieves the value of a static or instance property
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="member">The property</param>
    /// <param name="instance">The object instance, if applicable</param>
    /// <returns></returns>
    public static Option<V> value<V>(PropertyInfo member, object instance = null)
        => from o in member.TryGetValue(instance)
           from v in tryCast<V>(o)
           select v;

    /// <summary>
    /// Attempts to retrieves the value of a static or instance field
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="member">The field</param>
    /// <param name="instance">The object instance, if applicable</param>
    /// <returns></returns>
    public static Option<V> value<V>(FieldInfo member, object instance = null)
        => from o in member.TryGetValue(instance)
           from v in tryCast<V>(o)
           select v;

    /// <summary>
    /// Gets the public constructors defined on the supplied type
    /// </summary>
    /// <param name="o">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<ConstructorInfo> constructors(object o)
        => _constructorCache.GetOrAdd(o.GetType(), t => t.GetConstructors());

    /// <summary>
    /// Searches a type for an instance constructor that matches a specified signature
    /// </summary>
    /// <param name="declaringType">The type to search</param>
    /// <param name="argTypes">The method parameter types in ordinal position</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ConstructorInfo> constructor(Type declaringType, params Type[] argTypes)
        => declaringType.GetConstructor(BF_Instance, null, argTypes, array<ParameterModifier>());

    /// <summary>
    /// Searches a type for an instance constructor that matches a specified signature
    /// </summary>
    /// <param name="argTypes">The method parameter types in ordinal position</param>
    /// <typeparam name="T">The type to search</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ConstructorInfo> constructor<T>(params Type[] argTypes)
        => constructor(typeof(T), argTypes);

    /// <summary>
    /// Constructs an object
    /// </summary>
    /// <typeparam name="O">The object type</typeparam>
    /// <param name="parms">The parameters passed to the oject's constructor</param>
    /// <returns></returns>
    public static Option<O> construct<O>(params object[] parms)
        => Try(parms, args => (O)Activator.CreateInstance(typeof(O), args));

    /// <summary>
    /// Gets the public constructors defined on the supplied type
    /// </summary>
    /// <typeparam name="T">The type to examine</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<ConstructorInfo> constructors<T>()
        => _constructorCache.GetOrAdd(typeof(T), t => t.GetConstructors());


    /// <summary>
    /// If nullable non-enumeration type, returns the type on which the type is based
    /// If nullable or non-nullable enumeration type, returns the underlying type of the enumeration
    /// If non-nullable non-enumeration type, returns the incoming type
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type underlying(Type t)
        => _ulTypeCache.GetOrAdd(t, _t => _t.GetUnderlyingType());

    /// <summary>
    /// If nullable non-enumeration type, returns the type on which the type is based
    /// If nullable or non-nullable enumeration type, returns the underlying type of the enumeration
    /// If non-nullable non-enumeration type, returns the incoming type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type underlying<T>()
        => _ulTypeCache.GetOrAdd(typeof(T), _t => _t.GetUnderlyingType());

    /// <summary>
    /// Gets the type's classification code
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TypeCode typecode(Type t)
        => Type.GetTypeCode(t);

    /// <summary>
    /// Gets the type's classification code
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TypeCode typecode<T>()
        => Type.GetTypeCode(typeof(T));

    /// <summary>
    /// Gets the type adapter for <paramref name="t"/>
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static ClrType type(Type t)
        => ClrType.Get(t);

    /// <summary>
    /// Invokes a sequence of actions
    /// </summary>
    /// <param name="actions">The actions that will be sequentially invoked</param>
    public static void invoke(params Action[] actions)
        => iter(actions, a => a());
}
