//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;



/// <summary>
/// Base type for reflective method adapters
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
public abstract class ClrMethod<T> : ClrMember<MethodInfo, T>
    where T : ClrMethod<T>
{
    protected ClrMethod(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }

    /// <summary>
    /// Gets the name of the adapted method
    /// </summary>
    public override string Name
        => ReflectedElement.Name;

    /// <summary>
    /// Retrieves the value of an applied attribute
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    /// <summary>
    /// Determines whether an attribute is applied to a method
    /// </summary>
    /// <typeparam name="A">The attribute type to test</typeparam>
    /// <returns></returns>
    public override bool HasAttribute<A>()
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    /// <summary>
    /// Gets the parameters accepted by the method
    /// </summary>
    public IEnumerable<ClrMethodParameter> Parameters
        => from p in ReflectedElement.GetParameters()
           select new ClrMethodParameter(p);

    /// <summary>
    /// Gets the number of parameters accepted by the method
    /// </summary>
    public int ParameterCount
        => ReflectedElement.GetParameters().Length;

    /// <summary>
    /// Gets the method's return type if it has one, otherwise returns None
    /// </summary>
    public Option<ClrType> ReturnType
        => ReflectedElement.ReturnType == typeof(void) 
        ? null  : ClrType.Get(ReflectedElement.ReturnType);                  

    /// <summary>
    /// Returns true if the method returns a specified type
    /// </summary>
    /// <param name="t">The type to match</param>
    /// <returns></returns>
    public bool ReturnsType(Type t)
        => ReflectedElement.ReturnType == t;

    /// <summary>
    /// Returns true if the method returns a specified type
    /// </summary>
    /// <returns></returns>
    public bool ReturnsType<R>()
        => ReflectedElement.ReturnType == typeof(R);

    /// <summary>
    /// Returns true if the method returns a type assignable to a specified type
    /// </summary>
    /// <returns></returns>
    public bool ReturnsAssignableType<R>()
        => typeof(R).IsAssignableFrom(ReflectedElement.ReturnType);

    /// <summary>
    /// Creates a closed generic method from this (presumably) open generic method
    /// </summary>
    /// <param name="types">The method type arguments</param>
    /// <returns></returns>
    public ClrMethod Close(params Type[] types)
        => ReflectedElement.MakeGenericMethod(types);

    /// <summary>
    /// Specifies whether the method is generic
    /// </summary>
    public override bool IsGeneric
        => ReflectedElement.IsGenericMethod;

    /// <summary>
    /// Specifies whether the method is static
    /// </summary>
    public override bool IsStatic
        => ReflectedElement.IsStatic;

    /// <summary>
    /// Specifies whether the encapsulated <see cref="MethodInfo"/> is a generic method definition
    /// </summary>
    public bool IsGenericMethodDefinition
        => ReflectedElement.IsGenericMethodDefinition;

    /// <summary>
    /// Retrieves an attached attribute, if found; otherwise none
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    /// <summary>
    /// Indicates whether an identified attribute is applied to the method
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public override bool HasAttribute<A>(bool inherit = false)
        => System.Attribute.IsDefined(ReflectedElement, typeof(A), inherit);

    /// <summary>
    /// Gets the methood's canonical uri-based identifier
    /// </summary>
    public SystemUri Identifier
        => DeclaringType.ReflectedElement.Uri().WithAppendedPathComponts(Name);

    /// <summary>
    /// Specifies whether the method is abstract
    /// </summary>
    public override bool IsAbstract
        => ReflectedElement.IsAbstract;

    /// <summary>
    /// Specifies whether the method is public
    /// </summary>
    public override bool IsPublic
        => ReflectedElement.IsPublic;

    /// <summary>
    /// Specifies whether the method is private
    /// </summary>
    public override bool IsPrivate
        => ReflectedElement.IsPrivate;

    /// <summary>
    /// Specifies whether the method is an implicit conversion operator
    /// </summary>
    public bool IsImplicitConverter
        => ReflectedElement.IsImplicitConverter();

    /// <summary>
    /// Specifies whether the method is an explicit conversion operator
    /// </summary>
    public bool IsExplicitConverter
        => ReflectedElement.IsImplicitConverter();

    /// <summary>
    /// Specifies whether the method is either an implicit or explicit conversion operator
    /// </summary>
    public bool IsConversionOperator
        => IsExplicitConverter || IsImplicitConverter;

    /// <summary>
    /// Specifies whether the method is an override of a method declared by an ancestor
    /// </summary>
    public bool IsOverride
        => ReflectedElement.GetBaseDefinition().DeclaringType != ReflectedElement.DeclaringType;

    /// <summary>
    /// Specifies the methods' generic parameters
    /// </summary>
    public IEnumerable<ClrTypeParameter> TypeParameters
        => from a in ReflectedElement.GetGenericArguments()
           select ClrTypeParameter.Get(a);

    /// <summary>
    /// If the adapted method is a generic method definition with the supplied number and
    /// type of parameters, closes the method with the supplied arguments
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public Option<ClrMethod> CloseGenericMethod(params ClrType[] args)
        => Try(() => ClrMethod.Get(ReflectedElement.MakeGenericMethod(array(args, a => a.ReflectedElement))));

    static ClrType type<X>()
        => ClrType.Get<T>();

    /// <summary>
    /// If the adapted method is a generic method definition with one generic
    /// parameter, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1>()
        => CloseGenericMethod(type<T1>());

    /// <summary>
    /// If the adapted method is a generic method definition with two generic
    /// parameters, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The first type argument</typeparam>
    /// <typeparam name="T2">The second type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1, T2>()
        => CloseGenericMethod(type<T1>(),type<T2>());

    /// <summary>
    /// If the adapted method is a generic method definition with three generic
    /// parameters, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The first type argument</typeparam>
    /// <typeparam name="T2">The second type argument</typeparam>
    /// <typeparam name="T3">The third type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1, T2, T3>()
        => CloseGenericMethod(type<T1>(), type<T2>(),type<T3>());

    /// <summary>
    /// If the adapted method is a generic method definition with four generic
    /// parameters, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The first type argument</typeparam>
    /// <typeparam name="T2">The second type argument</typeparam>
    /// <typeparam name="T3">The third type argument</typeparam>
    /// <typeparam name="T4">The fourth type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1, T2, T3, T4>()
        => CloseGenericMethod(type<T1>(), type<T2>(), type<T3>(),type<T4>());

    /// <summary>
    /// If the adapted method is a generic method definition with four generic
    /// parameters, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The first type argument</typeparam>
    /// <typeparam name="T2">The second type argument</typeparam>
    /// <typeparam name="T3">The third type argument</typeparam>
    /// <typeparam name="T4">The fourth type argument</typeparam>
    /// <typeparam name="T5">The fifth type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1, T2, T3, T4, T5>()
        => CloseGenericMethod(type<T1>(), type<T2>(), type<T3>(), type<T4>(), type<T5>());

    /// <summary>
    /// If the adapted method is a generic method definition with four generic
    /// parameters, closes the method with the supplied value
    /// </summary>
    /// <typeparam name="T1">The first type argument</typeparam>
    /// <typeparam name="T2">The second type argument</typeparam>
    /// <typeparam name="T3">The third type argument</typeparam>
    /// <typeparam name="T4">The fourth type argument</typeparam>
    /// <typeparam name="T5">The fifth type argument</typeparam>
    /// <typeparam name="T6">The sixth type argument</typeparam>
    /// <returns>The invokable closed method</returns>
    public Option<ClrMethod> CloseGenericMethod<T1, T2, T3, T4, T5, T6>()
        => CloseGenericMethod(type<T1>(), type<T2>(), type<T3>(), type<T4>(), type<T5>(), type<T6>());

}

