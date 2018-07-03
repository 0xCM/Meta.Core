//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using static ExpressionMessages;
using static minicore;

using XPR = System.Linq.Expressions.Expression;
/// <summary>
/// Defines <see cref="Expression"/> related extensions
/// </summary>
public static class ExpressionX
{
    /// <summary>
    /// Creates a delegate for a (static) method
    /// </summary>
    /// <typeparam name="D">The type of the constructed delegate</typeparam>
    /// <param name="m">The method that will be invoked when delegate is activated</param>
    /// <returns></returns>
    public static D CreateDelegate<D>(this MethodInfo m)
    {
        var argTypes = m.GetParameterTypes().ToArray();
        var dType
            = m.IsAction()
            ? Expression.GetActionType(argTypes)
            : Expression.GetFuncType(argTypes.Concat(stream(m.ReturnType)).ToArray());
        var d = Delegate.CreateDelegate(typeof(D), null, m);
        return cast<D>(d);
    }

    /// <summary>
    /// Throws a <see cref="ArgumentOutOfRangeException"/> if the value under examination does not have the specified length
    /// </summary>
    /// <param name="x">The value being examined</param>
    /// <param name="length">The required length</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Require(this string x, int length, string argname = null)
        => x.Length != length
        ? throw new ArgumentOutOfRangeException(
                argname ?? String.Empty, StringLengthMismatch(x, length).Format(false))
        : x;

    /// <summary>
    /// Tests whether an expression is a conversion
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsConversion(this Expression x)
        => x.NodeType == ExpressionType.Convert;

    /// <summary>
    /// Extracts the operaand from the expression
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static Expression GetSubject(this UnaryExpression x)
        => x.Operand;

    /// <summary>
    /// Gets the expression that directly identifies the selected subject
    /// </summary>
    /// <typeparam name="TResult">The member type</typeparam>
    /// <param name="selector">Expression that identifies the member</param>
    /// <returns></returns>
    public static Expression GetSelectionSubject<TResult>(this Expression<Func<TResult>> selector)
        => selector.IsConversion()
            ? (selector.Body as UnaryExpression).GetSubject()
            : selector.Body;

    /// <summary>
    /// Gets the expression that directly identifies the selected subject
    /// </summary>
    /// <typeparam name="T">The declaring type</typeparam>
    /// <typeparam name="TResult">The member type</typeparam>
    /// <param name="selector">Expression that identifies the member</param>
    /// <returns></returns>
    static Expression SelectionSubject<T, TResult>(this Expression<Func<T, TResult>> selector)
        => selector.IsConversion()
            ? (selector.Body as UnaryExpression).GetSubject()
            : selector.Body;

    /// <summary>
    /// Extracts the <see cref="PropertyInfo"/> for the property referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="TResult">The property type</typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static PropertyInfo GetProperty<TResult>(this Expression<Func<TResult>> selector)
        => cast<PropertyInfo>(cast<MemberExpression>(selector.GetSelectionSubject()).Member);

    /// <summary>
    /// Extracts the <see cref="PropertyInfo"/> for the property referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="T">The declaring type</typeparam>
    /// <typeparam name="TResult">The property type</typeparam>
    /// <param name="selector">The member expression</param>
    /// <returns></returns>
    public static PropertyInfo GetProperty<T, TResult>(this Expression<Func<T, TResult>> selector)
        => cast<PropertyInfo>(cast<MemberExpression>(selector.SelectionSubject()).Member);

    /// <summary>
    /// Determines the name of the property as identified by the selector
    /// </summary>
    /// <typeparam name="TSrc">The declaring type</typeparam>
    /// <typeparam name="TResult">The property type</typeparam>
    /// <param name="selector">The selector to evauluate</param>
    /// <returns></returns>
    public static string SelectedPropertyName<TSrc, TResult>(this Expression<Func<TSrc, TResult>> selector)
        => selector.GetProperty().Name;

    /// <summary>
    /// Extracts the <see cref="PropertyInfo"/> for the property referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="TResult">The property type</typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static FieldInfo GetField<TResult>(this Expression<Func<TResult>> selector)
        => cast<FieldInfo>(cast<MemberExpression>(selector.GetSelectionSubject()).Member);

    /// <summary>
    /// Extracts the <see cref="PropertyInfo"/> for the property referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="T">The declaring type</typeparam>
    /// <typeparam name="TResult">The property type</typeparam>
    /// <param name="selector">The member expression</param>
    /// <returns></returns>
    public static FieldInfo GetField<T, TResult>(this Expression<Func<T, TResult>> selector)
        => cast<FieldInfo>(cast<MemberExpression>(selector.SelectionSubject()).Member);

    /// <summary>
    /// Extracts the <see cref="MemberInfo"/> for the member referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="T">The first selector parameter</typeparam>
    /// <typeparam name="M">The member type</typeparam>
    /// <param name="selector">The member expression</param>
    /// <returns></returns>
    public static MemberInfo GetMember<T, M>(this Expression<Func<T, M>> selector)
        => cast<MemberInfo>(cast<MemberExpression>(selector.Body).Member);

    /// <summary>
    /// Extracts the <see cref="ValueMember"/> for the member referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="T">The member selector</typeparam>
    /// <typeparam name="M">The member type</typeparam>
    /// <param name="selector">The member expression</param>
    /// <returns></returns>
    public static ValueMember GetValueMember<T, M>(this Expression<Func<T, M>> selector)
    {
        var property = selector.GetProperty();
        if (property != null)
            return property;

        var field = selector.GetField();
        if (field != null)
            return field;

        var member = selector.TryGetAccessedMember();
        if (member)
            throw new ArgumentException($"Members of type {(~member).MemberType} are not considered value memembers");
        else
            throw new ArgumentException($"Could not determine any member from {selector}");
    }

    /// <summary>
    /// Extracts the name of the value member referenced by a <see cref="MemberExpression"/>
    /// </summary>
    /// <typeparam name="T">The member selector</typeparam>
    /// <typeparam name="M">The member type</typeparam>
    /// <param name="selector">The member expression</param>
    /// <returns></returns>
    public static string GetValueMemberName<T, M>(this Expression<Func<T, M>> selector)
        => selector.GetValueMember().Name;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the function referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T">The function return type</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T>(this Expression<Func<T>> selector)
    {
        if (selector.Body is MethodCallExpression)
            return cast<MethodCallExpression>(selector.Body).Method;
        else if (selector.Body.IsConversion())
            return (cast<UnaryExpression>(selector.Body).Operand as MethodCallExpression).Method;
        else
            throw new NotSupportedException();
    }

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the function referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first function argument</typeparam>
    /// <typeparam name="T2">The function return type</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2>(this Expression<Func<T1, T2>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the function referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first function argument</typeparam>
    /// <typeparam name="T2">The second function argument</typeparam>
    /// <typeparam name="TResult">The function return type</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the function referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first function argument</typeparam>
    /// <typeparam name="T2">The second function argument</typeparam>
    /// <typeparam name="T3">The third function argument</typeparam>
    /// <typeparam name="TResult">The function return type</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2, T3, TResult>(this Expression<Func<T1, T2, T3, TResult>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the action referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T">The action argument</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T>(this Expression<Action<T>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the action referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first action argument</typeparam>
    /// <typeparam name="T2">The second action argument</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2>(this Expression<Action<T1, T2>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the action referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first action argument</typeparam>
    /// <typeparam name="T2">The second action argument</typeparam>
    /// <typeparam name="T3">The third action argument</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2, T3>(this Expression<Action<T1, T2, T3>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Extracts the <see cref="MethodInfo"/> for the action referenced by a <see cref="MethodCallExpression"/>
    /// </summary>
    /// <typeparam name="T1">The first action argument</typeparam>
    /// <typeparam name="T2">The second action argument</typeparam>
    /// <typeparam name="T3">The third action argument</typeparam>
    /// <typeparam name="T4">The fourth action argument</typeparam>
    /// <param name="selector">The call expression</param>
    /// <returns></returns>
    public static MethodInfo GetMethod<T1, T2, T3, T4>(this Expression<Action<T1, T2, T3, T4>> selector)
        => cast<MethodCallExpression>(selector.Body).Method;

    /// <summary>
    /// Returns the expression if it is a logical conjunction and None otherwise
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static Option<X> TryGetConjunction<X>(this X x)
        where X : Expression
        => x.NodeType == ExpressionType.AndAlso ? x : none<X>();

    /// <summary>
    /// Returns the expression if it is a logical disjunction and None otherwise
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static Option<X> TryGetDisjunction<X>(this X x)
        where X : Expression
            => x.NodeType == ExpressionType.OrElse ? x : none<X>();


    public static PropertyInfo GetAccessedProperty(this Expression x)
        => cast<PropertyInfo>(cast<MemberExpression>(x)?.Member);

    public static Option<MemberInfo> TryGetAccessedMember(this Expression X)
    {
        var M = tryCast<MemberExpression>(X).ValueOrDefault();
        if (M != null)
            return M.Member;
        else
            return tryCast<LambdaExpression>(X).Map(y => y.Body.TryGetAccessedMember().ValueOrDefault());
    }

    static object GetConstant(this Expression x)
        => cast<ConstantExpression>(x)?.Value;

    public static Option<PropertyInfo> TryGetAccesedProperty(this Expression x)
    {
        var candiate = tryCast<MemberExpression>(x).Map(GetAccessedProperty);
        if (candiate)
            return candiate;
        else
            return tryCast<LambdaExpression>(x).Map(y => y.Body.TryGetAccesedProperty().ValueOrDefault());
    }

    public static Option<MemberInfo> TryGetAccessedMember(this BinaryExpression X)
        => X.Left.TryGetAccessedMember().ValueOrElse(() => X.Right.TryGetAccessedMember().ValueOrDefault());

    public static Option<object> GetValue(this BinaryExpression X)
        => X.Left.GetValue().ValueOrElse(() => X.Right.GetValue());

    public static Option<object> TryGetConstant(this Expression x)
        => tryCast<ConstantExpression>(x).Map(GetConstant);

    public static Option<object> GetValue(this Expression X)
    {
        var value = X.TryGetConstant();
        if (!value)
        {
            var N = (X as NewExpression);
            if (N != null)
            {
                var args = N.Arguments.Map(A => A.TryGetConstant().ValueOrDefault()).ToArray();
                value = Activator.CreateInstance(N.Type, args);

            }

        }
        return value;
    }

    /// <summary>
    /// Tests whether a member is wrapped in a conversion
    /// </summary>
    /// <typeparam name="T">The declaring type</typeparam>
    /// <typeparam name="TResult">The member type</typeparam>
    /// <param name="selector">Expression that identifies the member</param>
    /// <returns></returns>
    public static bool IsConversion<T, TResult>(this Expression<Func<T, TResult>> selector)
        => selector.Body.IsConversion();

    /// <summary>
    /// Tests whether the test expression is a member access expression
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsMemberAccess(this Expression x)
        => x.NodeType == ExpressionType.MemberAccess;

    /// <summary>
    /// Tests whether the test expression is a function call
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsCall(this Expression x)
        => x.NodeType == ExpressionType.Call;

    /// <summary>
    /// Returns the method invoked by an expression, if any
    /// </summary>
    /// <param name="x">The expression to test</param>
    /// <returns></returns>
    public static Option<MethodInfo> GetCalledMethod(this Expression x)
        => cast<MethodCallExpression>(x)?.Method;

    /// <summary>
    /// Tests whether an expression is an application of the LINQ select operator
    /// </summary>
    /// <param name="x">The expression to test</param>
    /// <returns></returns>
    public static bool IsSelect(this Expression x)
        => x.GetCalledMethod().Map(m => m.Name == nameof(Enumerable.Select)).ValueOrDefault(false);

    /// <summary>
    /// Deterines whether the test expression is a logical operator
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsLogical(this Expression x)
        => x.NodeType == ExpressionType.AndAlso ||
            x.NodeType == ExpressionType.OrElse ||
            x.NodeType == ExpressionType.Not;

    /// <summary>
    /// Deterines whether the test expression is a lambda expression
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsLambda(this Expression x)
        => x.NodeType == ExpressionType.Lambda;

    /// <summary>
    /// Tests whether the test expression is a logical disjunction
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsDisjunction<X>(this X x)
        where X : Expression
        => x.TryGetDisjunction().Exists;

    /// <summary>
    /// Determines whether the test expression is a logical conjunction
    /// </summary>
    /// <param name="x">The expression to examine</param>
    /// <returns></returns>
    public static bool IsConjunction<X>(this X x)
        where X : Expression
        => x.TryGetConjunction().Exists;

    /// <summary>
    /// Deterines whether the test expression is either a logical conjuntion or disjunction
    /// </summary>
    /// <param name="X">The expression to examine</param>
    /// <returns></returns>
    public static bool IsJunction(this Expression X)
        => X.IsConjunction() || X.IsDisjunction();

    /// <summary>
    /// Tests whether an expression is of type <typeparamref name="X1"/> or <typeparamref name="X2"/>
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <param name="X">The expression to test</param>
    /// <returns></returns>
    public static bool IsOneOf<X1, X2>(this Expression X)
        where X1 : Expression
        where X2 : Expression
            => (X is X1) || (X is X2);

    /// <summary>
    /// Tests whether an expression is of type <typeparamref name="X1"/>, <typeparamref name="X2"/> or <typeparamref name="X3"/>
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="X3"></typeparam>
    /// <param name="X">The expression to test</param>
    /// <returns></returns>
    public static bool IsOneOf<X1, X2, X3>(this Expression X)
        where X1 : Expression
        where X2 : Expression
        where X3 : Expression
            => X.IsOneOf<X1, X2>() || (X is X3);

    /// <summary>
    /// Tests whether an expression is of type <typeparamref name="X1"/>, <typeparamref name="X2"/>,
    /// <typeparamref name="X3"/> or <typeparamref name="X4"/>
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="X3"></typeparam>
    /// <typeparam name="X4"></typeparam>
    /// <param name="X">The expression to test</param>
    /// <returns></returns>
    public static bool IsOneOf<X1, X2, X3, X4>(this Expression X)
        where X1 : Expression
        where X2 : Expression
        where X3 : Expression
        where X4 : Expression
            => X.IsOneOf<X1, X2, X3>() || (X is X4);

    /// <summary>
    /// Creates a function that accepts 0 parameters returns a typed result
    /// </summary>
    /// <param name="Host">The declaring type instance, if applicable</param>
    /// <typeparam name="X">The result type</typeparam>
    /// <returns></returns>
    public static Func<X> Func<X>(this MethodInfo method, object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var callResult = XPR.Call(instance, method);
        return XPR.Lambda<Func<X>>(callResult).Compile();
    }

    /// <summary>
    /// Creates a function that accepts 1 typed parameter and returns a typed result
    /// </summary>
    /// <typeparam name="X">The type of the first parameter</typeparam>
    /// <typeparam name="Y">The result type</typeparam>
    /// <param name="Host">An instance of the declaring type, if applicable</param>
    /// <returns></returns>
    public static Func<X, Y> Func<X, Y>(this MethodInfo method, object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var src = XPR.Parameter(typeof(X), "src");
        var callResult = XPR.Call(instance, method, src);
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
    public static Func<X1, X2, Y> Func<X1, X2, Y>(this MethodInfo method, object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var callResult = XPR.Call(instance, method, x1, x2);
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
    public static Func<X1, X2, X3, Y> Func<X1, X2, X3, Y>(this MethodInfo method, object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var x3 = XPR.Parameter(typeof(X3), "x3");
        var callResult = XPR.Call(instance, method, x1, x2, x3);
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
    public static Func<X1, X2, X3, X4, Y> Func<X1, X2, X3, X4, Y>(this MethodInfo method, object Host = null)
    {
        var instance = Host != null ? XPR.Constant(Host) : default(XPR);
        var x1 = XPR.Parameter(typeof(X1), "x1");
        var x2 = XPR.Parameter(typeof(X2), "x2");
        var x3 = XPR.Parameter(typeof(X3), "x3");
        var x4 = XPR.Parameter(typeof(X4), "x4");
        var callResult = XPR.Call(instance, method, x1, x2, x3);
        return XPR.Lambda<Func<X1, X2, X3, X4, Y>>(callResult, x1, x2, x3, x4).Compile();
    }

}

