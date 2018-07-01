//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using static metacore;

using XPR = System.Linq.Expressions.Expression;


/// <summary>
/// Canonical <see cref="ClrMethod{T}"/> closure
/// </summary>
public class ClrMethod : ClrMethod<ClrMethod>
{
    /// <summary>
    /// Creates a <see cref="ClrMethod"/> adapter
    /// </summary>
    /// <param name="m">The subject of adaptation</param>
    /// <returns></returns>
    public static ClrMethod Get(MethodInfo m)
    {
        if (m == null)
            throw new ArgumentNullException();
        return m.IsImplicitConverter() ? new ClrImplictConverter(m)
         : m.IsExplicitConverter() ? new ClrExplicitConverter(m)
         : new ClrMethod(m);
    }
    /// <summary>
    /// Implicitly extracts the method signature
    /// </summary>
    /// <param name="m"></param>
    public static implicit operator ClrMethodSignature(ClrMethod m)
        => new ClrMethodSignature(m.ReflectedElement);

    /// <summary>
    /// Implicitly converts an adapter to the underlying reflection primitive
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator MethodInfo(ClrMethod x) 
        => x.ReflectedElement;

    /// <summary>
    /// Implicitly adapts a reflection primitive
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator ClrMethod(MethodInfo x) 
        => new ClrMethod(x);

    public ClrMethod(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }

    /// <summary>
    /// Invokes a static method 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public object Invoke(params object[] parameters) 
        => ReflectedElement.Invoke(null, parameters.ToArray());

    /// <summary>
    /// Invokes a static method
    /// </summary>
    /// <typeparam name="TResult">The method's return type</typeparam>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public TResult Invoke<TResult>(params object[] parameters) 
        => (TResult)ReflectedElement.Invoke(null, parameters.ToArray());

    /// <summary>
    /// Invokes a non-static method
    /// </summary>
    /// <param name="host">An instance of the defining type</param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public object InvokeOnHost(object host, params object[] parameters)
        => ReflectedElement.Invoke(host, parameters);

    /// <summary>
    /// Invokes a non-static method
    /// </summary>
    /// <param name="host">An instance of the defining type</param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public TResult InvokeOnHost<TResult>(object host, params object[] parameters)
        => cast<TResult>(ReflectedElement.Invoke(host, parameters));

    static ParameterExpression GetParameter(int i)
        => XPR.Parameter(typeof(object), "x" + i.ToString());

    /// <summary>
    /// Creates a sequence of unary expressions corresponding the method arguments
    /// </summary>
    /// <returns></returns>
    public UnaryExpression[] ArgumentExpressions
        => Parameters
                .Mapi((i, p) => XPR.Convert(GetParameter(i + 1), p.ParameterType))
                .ToArray();

    static ParameterExpression[] GetParameters(int count)
        => Enumerable.Range(0, count)
                .Map(i => XPR.Parameter(typeof(object), "x" + (i + 1).ToString()))
                .ToArray();

    /// <summary>
    /// Creates a function that accepts 0 parameters and returns an untyped result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <returns></returns>
    public Func<object> Func0(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var result = XPR.Convert(XPR.Call(instance, this), typeof(object));
        return XPR.Lambda<Func<object>>(result).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 1 untyped parameter and returns an untyped result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <returns></returns>
    public Func<object, object> Func1(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default;
        var call = XPR.Call(instance, this, ArgumentExpressions);
        var result = XPR.Convert(call, typeof(object));
        return XPR.Lambda<Func<object, object>>(result, GetParameters(1)).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 2 untyped parameters and returns an untyped result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <returns></returns>
    public Func<object, object, object> Func2(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default;        
        var callResult = XPR.Call(instance, this, ArgumentExpressions);
        var result = XPR.Convert(callResult, typeof(object));        
        return XPR.Lambda<Func<object, object, object>>(result, GetParameters(2)).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 3 untyped parameters and returns an untyped result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <returns></returns>
    public Func<object, object, object, object> Func3(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default;        
        var callResult = XPR.Call(null, this, ArgumentExpressions);
        var result = XPR.Convert(callResult, typeof(object));
        return XPR.Lambda<Func<object, object, object, object>>(result, GetParameters(3)).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 0 parameters returns a typed result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <typeparam name="X">The result type</typeparam>
    /// <returns></returns>
    public Func<X> Func<X>(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var callResult = XPR.Call(instance, this);
        return XPR.Lambda<Func<X>>(callResult).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 1 typed parameter and returns a typed result
    /// </summary>
    /// <typeparam name="X">The type of the first parameter</typeparam>
    /// <typeparam name="Y">The result type</typeparam>
    /// <param name="Host">An instance of the declaring type, if applicable</param>
    /// <returns></returns>
    public Func<X, Y> Func<X, Y>(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var src = XPR.Parameter(typeof(X), "src");
        var callResult = XPR.Call(instance, this, src);
        return XPR.Lambda<Func<X, Y>>(callResult, src).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 2 typed parameters and returns a typed result
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="Y">The result type</typeparam>
    /// <param name="Host">An instance of the declaring type, if applicable</param>
    /// <returns></returns>
    public Func<X1, X2, Y> Func<X1, X2, Y>(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var callResult = XPR.Call(instance, this, x1, x2);
        return XPR.Lambda<Func<X1, X2, Y>>(callResult, x1, x2).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 3 typed parameters and returns an typed result
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">Tye type of the third parameter</typeparam>
    /// <typeparam name="Y">The result type</typeparam>
    /// <param name="Host">An instance of the declaring type, if applicable</param>
    /// <returns></returns>
    public Func<X1, X2, X3, Y> Func<X1, X2, X3, Y>(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var x3 = XPR.Parameter(typeof(X3), "x3");
        var callResult = XPR.Call(instance, this, x1, x2, x3);
        return XPR.Lambda<Func<X1, X2, X3, Y>>(callResult, x1, x2, x3).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 4 typed parameters and returns an typed result
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">Tye type of the third parameter</typeparam>
    /// <typeparam name="X4">Tye type of the fourth parameter</typeparam>
    /// <typeparam name="Y">The result type</typeparam>
    /// <param name="Host">An instance of the declaring type, if applicable</param>
    /// <returns></returns>
    public Func<X1, X2, X3, X4, Y> Func<X1, X2, X3, X4, Y>(object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var x3 = XPR.Parameter(typeof(X3), "x3");
        var x4 = XPR.Parameter(typeof(X4), "x4");
        var callResult = XPR.Call(instance, this, x1, x2, x3);
        return XPR.Lambda<Func<X1, X2, X3, X4, Y>>(callResult, x1, x2, x3,x4).Compile();
    }

}

/// <summary>
/// Strongly-typed <see cref="ClrMethod"/> collection
/// </summary>
public sealed class ClrMethods : TypedItemList<ClrMethods, ClrMethod>
{
    public static implicit operator ClrMethods(ClrMethod[] items)
        => Create(items);

    public static implicit operator ClrMethods(ReadOnlyList<ClrMethod> items)
        => Create(items);

}