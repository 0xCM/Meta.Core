//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using static minicore;
using static express.linqx;

using XPR = System.Linq.Expressions.Expression;
using PX = System.Linq.Expressions.ParameterExpression;

public static class express
{
    static ConcurrentDictionary<MethodInfo, Delegate> _funcCache { get; }
        = new ConcurrentDictionary<MethodInfo, Delegate>();

    /// <summary>
    /// Defines a conversion from the source expression to a target type
    /// </summary>
    /// <param name="e"></param>
    /// <param name="dstType"></param>
    /// <returns></returns>
    public static UnaryExpression conversion(XPR e, Type dstType)
        => XPR.Convert(e, dstType);

    /// <summary>
    /// Defines a conversion expression from an expression value <paramref name="e"/>
    /// to a value of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="e">The source value</param>
    /// <returns></returns>
    public static UnaryExpression conversion<T>(XPR e)
        => conversion(e, typeof(T));

    //public static Converter converter(MethodInfo m)
    //{
    //    var src = Expression.Parameter(typeof(object), "src");
    //    var convert = Expression.Convert(src, m.GetParameters()[0].ParameterType);
    //    var callResult = Expression.Call(null, m, convert);
    //    var result = Expression.Convert(callResult, typeof(object));
    //    return Expression.Lambda<Converter>(result, src).Compile();
    //}

    //public static Converter<TDst> converter<TDst>(MethodInfo m)
    //{
    //    var src = Expression.Parameter(typeof(object), "src");
    //    var convert = Expression.Convert(src, m.GetParameters()[0].ParameterType);
    //    var callResult = Expression.Call(null, m, convert);
    //    return Expression.Lambda<Converter<TDst>>(callResult, src).Compile();
    //}

    /// <summary>
    /// Creates an expression from a parameterless function delegate delegate
    /// </summary>
    /// <typeparam name="T">The delegate return type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Expression<Func<T>> funcx<T>(Func<T> f)
        => FuncExpression.make(f);

    /// <summary>
    /// Creates an expression from a 1-argument function delegate
    /// </summary>
    /// <typeparam name="X">The type of input value</typeparam>
    /// <typeparam name="Y">The delegate return type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Expression<Func<X, Y>> funcx<X, Y>(Func<X, Y> f)
        => FuncExpression.make(f);

    /// <summary>
    /// Creates an expression from a 2-argument function delegate
    /// </summary>
    /// <typeparam name="X1">The type of the delegate's first argument</typeparam>
    /// <typeparam name="X2">The type of the delegate's second argument</typeparam>
    /// <typeparam name="Y">The delegate return type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Expression<Func<X1, X2, Y>> funcx<X1, X2, Y>(Func<X1, X2, Y> f)
        => FuncExpression.make(f);

    /// <summary>
    /// Creates an expression from a 3-argument function delegate delegate
    /// </summary>
    /// <typeparam name="X1">The type of the delegate's first argument</typeparam>
    /// <typeparam name="X2">The type of the delegate's second argument</typeparam>
    /// <typeparam name="X3">The type of the delegate's third argument</typeparam>
    /// <typeparam name="Y">The delegate return type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Expression<Func<X1, X2, X3, Y>> funcx<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
        => FuncExpression.make(f);

    /// <summary>
    /// Creates a <typeparamref name="X1"/>-valued parameter expression
    /// </summary>
    /// <typeparam name="X1">The parameter type</typeparam>
    /// <param name="name">The parameter name</param>
    /// <returns></returns>
    public static PX paramX<X1>(string name = "x1")
        => Expression.Parameter(typeof(X1), name);

    /// <summary>
    /// Creates a parameter expression 2-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <param name="name1">The name of the first parameter</param>
    /// <param name="name2">The name of the second parameter</param>
    /// <returns></returns>
    public static (PX x1, PX x2) paramsX<X1, X2>(string name1 = "x1", string name2 = "x2")
        => (paramX<X1>(name1), paramX<X2>(name2));

    /// <summary>
    /// Creates a parameter expression 3-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    /// <param name="name1">The name of the first parameter</param>
    /// <param name="name2">The name of the second parameter</param>
    /// <param name="name3">The name of the third parameter</param>
    /// <returns></returns>
    public static (PX x1, PX x2, PX x3) paramsX<X1, X2, X3>(string name1 = "x1", string name2 = "x2", string name3 = "x3")
        => (paramX<X1>(name1), paramX<X2>(name2), paramX<X3>(name3));

    /// <summary>
    /// Creates <paramref name="t"/>-valued parameter expression
    /// </summary>
    /// <param name="t">The parameter type</param>
    /// <param name="name">The parameter name</param>
    /// <returns></returns>
    public static PX paramX(Type t, string name = "x1")
        => Expression.Parameter(t, name);

    /// <summary>
    /// Creates a parameter expression from a reflected parameter
    /// </summary>
    /// <param name="p">The reflected parameter</param>
    /// <returns></returns>
    public static PX paramX(ParameterInfo p)
        => Expression.Parameter(p.ParameterType, p.Name);

    /// <summary>
    /// Creates a parameter expression where the name is derived from an integer,
    /// typically the position of the parameter
    /// </summary>
    /// <param name="i">The paremeter index</param>
    /// <returns></returns>
    public static PX paramX(Type paramType, int i)
        => Expression.Parameter(paramType, "x" + i.ToString());

    /// <summary>
    /// Creates a parameter expression where the name is derived from an integer,
    /// typically the position of the parameter
    /// </summary>
    /// <param name="i">The paremeter index</param>
    /// <returns></returns>
    public static PX paramX<T>(int i)
        => XPR.Parameter(typeof(T), "x" + i.ToString());

    /// <summary>
    /// Creates an auto-named parameter expression array from an array of parameter types
    /// </summary>
    /// <param name="paramTypes">The parameter types</param>
    /// <returns></returns>
    public static PX[] @params(params Type[] paramTypes)
        => Enumerable.Range(0, paramTypes.Length)
                .Map(i => XPR.Parameter(paramTypes[i], "x" + (i + 1).ToString()))
                .ToArray();

    /// <summary>
    /// Defines a lambda expression
    /// </summary>
    /// <typeparam name="T">The aligned delegate type</typeparam>
    /// <param name="parameters"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static Expression<T> lambda<T>(IEnumerable<PX> parameters, Expression body)
        where T : Delegate => XPR.Lambda<T>(body, parameters);

    /// <summary>
    /// Defines a lambda expression
    /// </summary>
    /// <typeparam name="T">The delegate type</typeparam>
    /// <param name="parameters"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static Expression<T> lambda<T>((PX p1, PX p2) parameters, Expression body)
        where T : Delegate
            => XPR.Lambda<T>(body, stream(parameters.p1, parameters.p2));

    /// <summary>
    /// Defines a lambda expression
    /// </summary>
    /// <typeparam name="T">The delegate type</typeparam>
    /// <param name="parameters"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static Expression<T> lambda<T>((PX p1, PX p2, PX p3) parameters, Expression body)
        where T : Delegate
            => XPR.Lambda<T>(body, stream(parameters.p1, parameters.p2, parameters.p3));

    /// <summary>
    /// Defines a lambda expression sans parameters
    /// </summary>
    /// <typeparam name="T">The aligned delegate type</typeparam>
    /// <param name="body"></param>
    /// <returns></returns>
    public static Expression<T> lambda<T>(XPR body)
        where T : Delegate => XPR.Lambda<T>(body);

    /// <summary>
    /// Defines a lambda expression
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static Expression<Func<X, Y>> lambda<X, Y>(IEnumerable<PX> parameters, XPR body)
            => XPR.Lambda<Func<X, Y>>(body, parameters);

    /// <summary>
    /// Defines a 2-argument lambda expression
    /// </summary>
    /// <param name="parameters">The expression parameters</param>
    /// <param name="body">The expression body</param>
    /// <returns></returns>
    public static Expression<Func<X1, X2, Y>> lambda<X1, X2, Y>(IEnumerable<PX> parameters, XPR body)
        => XPR.Lambda<Func<X1, X2, Y>>(body, parameters);

    /// <summary>
    /// Defines a 2-argument lambda expression
    /// </summary>
    /// <param name="parameters">The expression parameters</param>
    /// <param name="body">The expression body</param>
    /// <returns></returns>
    public static Expression<Func<X1, X2, X3, Y>> lambda<X1, X2, X3, Y>(IEnumerable<PX> parameters, XPR body)
        => XPR.Lambda<Func<X1, X2, X3, Y>>(body, parameters);

    /// <summary>
    /// Creates a unary lambda expression 
    /// </summary>
    /// <param name="f">The defining function</param>
    /// <returns></returns>
    public static Expression<Func<X, Y>> lambda<X, Y>(Func<XPR, UnaryExpression> f)
    {
        var p1 = paramX<X>("p1");
        var eval = f(p1);
        return lambda<Func<X, Y>>(stream(p1), eval);
    }

    /// <summary>
    /// Creates a binary lambda expression
    /// </summary>
    /// <param name="f">The defining function</param>
    /// <returns></returns>
    public static Expression<Func<X, Y, Z>> lambda<X, Y, Z>(Func<XPR, XPR, BinaryExpression> f)
    {
        var p1 = paramX<X>("p1");
        var p2 = paramX<Y>("p2");
        var eval = f(p1, p2);
        return lambda<Func<X, Y, Z>>(stream(p1, p2), eval);
    }

    /// <summary>
    /// Defines a function that will invoke the default constructor to create
    /// an instance of type <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The type of instance to create</typeparam>
    /// <returns></returns>
    public static Option<Func<X>> factory<X>()
        => from c in constructor<X>()
            let x = XPR.New(c)
            select XPR.Lambda<Func<X>>(x).Compile();

    /// <summary>                                                               
    /// Defines a function that will invoke a one parameter constructor to create
    /// an instance of type <typeparamref name="Y"/>
    /// </summary>
    /// <typeparam name="X">The constructor parameter type</typeparam>
    /// <typeparam name="Y">The type of instance to create</typeparam>
    /// <returns></returns>
    public static Option<Func<X, Y>> factory<X, Y>()
        => from c in constructor<Y>(typeof(X))
            let parameters = array(paramX<X>("a1"))
            let body = XPR.New(c, parameters)
            select lambda<Func<X, Y>>(parameters, body).Compile();

    /// <summary>
    /// Defines a function that will invoke a one parameter constructor to create
    /// an instance of type <paramref name="targetType"/>
    /// </summary>
    /// <param name="targetType">The type of object to construct</param>
    /// <param name="arg1Type">The constuctor argument type</param>
    /// <returns></returns>
    public static Option<Func<object, object>> factory(Type targetType, Type arg1Type)
        => from c in constructor(targetType, arg1Type)
            let cParams = array(paramX(arg1Type, "a1"))
            let lParams = array(paramX(typeof(object), "o1"))
            let converted = array(conversion(lParams[0], arg1Type))
            let body = XPR.New(c, converted)
            select lambda<Func<object, object>>(lParams, body).Compile();

    /// <summary>                                                               
    /// Defines a function that will invoke a two parameter constructor to create
    /// an instance of type <typeparamref name="Y"/>
    /// </summary>
    /// <typeparam name="X1">The first constructor parameter type</typeparam>
    /// <typeparam name="X2">The second constructor parameter type</typeparam>
    /// <typeparam name="Y">The type of instance to create</typeparam>
    /// <returns></returns>
    public static Option<Func<X1, X2, Y>> factory<X1, X2, Y>()
        => from c in constructor<Y>(typeof(X1), typeof(X2))
            let parameters = array(paramX<X1>("a1"), paramX<X2>("a2"))
            let body = XPR.New(c, parameters)
            select lambda<Func<X1, X2, Y>>(parameters, body).Compile();

    /// <summary>
    /// Defines a function that will invoke a one parameter constructor to create
    /// an instance of type <paramref name="targetType"/>
    /// </summary>
    /// <param name="targetType">The type of object to construct</param>
    /// <param name="arg1Type">The constuctor argument type</param>
    /// <returns></returns>
    public static Option<Func<object, object, object>> factory(Type targetType, Type arg1Type, Type arg2Type)
        => from c in constructor(targetType, arg1Type, arg2Type)
            let lParams = array(paramX<object>("o1"), paramX<object>("o2"))
            let converted = array(conversion(lParams[0], arg1Type), conversion(lParams[1], arg2Type))
            let body = conversion(XPR.New(c, converted), typeof(object))
            let final = lambda<Func<object, object, object>>(lParams, body)
            select final.Compile();

    /// <summary>                                                               
    /// Defines a function that will invoke a three-parameter constructor to create
    /// an instance of type <typeparamref name="Y"/>
    /// </summary>
    /// <typeparam name="X1">The first constructor parameter type</typeparam>
    /// <typeparam name="X2">The second constructor parameter type</typeparam>
    /// <typeparam name="X3">The third constructor parameter type</typeparam>
    /// <typeparam name="Y">The type of instance to create</typeparam>
    /// <returns></returns>
    public static Option<Func<X1, X2, X3, Y>> factory<X1, X2, X3, Y>()
        => from c in constructor<Y>(typeof(X1), typeof(X2))
            let parameters = array(paramX<X1>("a1"), paramX<X2>("a2"), paramX<X3>("a3"))
            let body = Expression.New(c, parameters)
            select lambda<Func<X1, X2, X3, Y>>(parameters, body).Compile();

    /// <summary>
    /// Creates an expression that invokes a static or instance method
    /// </summary>
    /// <param name="Host">The object that exposes the method if not static; otherwise null</param>
    /// <param name="m">The method to be invoked</param>
    /// <param name="args">The arguments supplied to the method when invoked</param>
    /// <returns></returns>
    public static MethodCallExpression invocation(object Host, MethodInfo m, params PX[] args)
        => XPR.Call(ifNotNull(Host, h => constant(h)), m, args);

    /// <summary>
    /// Creates an expression that invokes a static method
    /// </summary>
    /// <param name="m">The method to be invoked</param>
    /// <param name="args">The arguments supplied to the method when invoked</param>
    /// <returns></returns>
    public static MethodCallExpression invocation(MethodInfo m, params PX[] args)
        => invocation(null, m, args);

    /// <summary>
    /// Creates an invocation expression for a function delegate of the form X->Y
    /// </summary>
    /// <typeparam name="X">The function argument type</typeparam>
    /// <typeparam name="Y">The function return type</typeparam>
    /// <param name="f">The function delegate</param>
    /// <param name="argName">The name of argument</param>
    /// <returns></returns>
    public static InvocationExpression invocation<X, Y>(Func<X, Y> f, string argName)
        => XPR.Invoke(funcx(f), paramX<X>(argName));

    /// <summary>
    /// Creates an invocation expression for a function delegate of the form X1->X2->Y
    /// </summary>
    /// <typeparam name="X1">The type of the first function argument</typeparam>
    /// <typeparam name="X2">The type of the second function argument</typeparam>
    /// <typeparam name="Y">The function return type</typeparam>
    /// <param name="f">The function delegate</param>
    /// <param name="arg1">The name of the first argument</param>
    /// <param name="arg2">The name of the second argument</param>
    /// <returns></returns>
    public static InvocationExpression invocation<X1, X2, Y>(Func<X1, X2, Y> f, string arg1 = "x1", string arg2 = "x2")
        => XPR.Invoke(funcx(f), paramX<X1>(arg1), paramX<X2>(arg2));

    /// <summary>
    /// Creates and caches a function delegate m:() => X
    /// </summary>
    /// <typeparam name="X">The output type</typeparam>
    /// <param name="m"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public static Option<Func<X>> func<X>(MethodInfo m, object instance = null)
        => Try(() => (Func<X>)_funcCache.GetOrAdd(m, method =>
        {
            var result = conversion<X>(invocation(instance, m));
            return XPR.Lambda<Func<X>>(result).Compile();
        }));

    /// <summary>
    /// Creates and caches a function delegate for a method X1->X2
    /// </summary>
    /// <typeparam name="X1">The input type</typeparam>
    /// <typeparam name="X2">The output type</typeparam>
    /// <param name="m"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public static Option<Func<X1, X2>> func<X1, X2>(MethodInfo m, object instance = null)
        => Try(() => (Func<X1, X2>)_funcCache.GetOrAdd(m, method =>
        {
            var args = stream(paramX<X1>("x1"));
            var f = invocation(instance, m, args.ToArray());
            return lambda<X1, X2>(args, f).Compile();
        }));

    /// <summary>
    /// Attemts to create and cache a function delegate for a named method m:X1->X2
    /// </summary>
    /// <typeparam name="X1">The method input type</typeparam>
    /// <typeparam name="X2">The method output type</typeparam>
    /// <param name="declarer">The declaring type</param>
    /// <param name="name">The name of the method</param>
    /// <param name="instance">The instance of the declaring type, if method is not static</param>
    /// <returns></returns>
    public static Option<Func<X1, X2>> func<X1, X2>(Type declarer, string name, object instance = null)
        => from m in declarer.MatchMethod(name, typeof(X1))
            from f in func<X1, X2>(m, instance)
            select f;

    /// <summary>
    /// Creates and caches a function delegate for a method m:(X1,X2) -> Y
    /// </summary>
    /// <typeparam name="X1">The first argument</typeparam>
    /// <typeparam name="X2">The second argument</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="m"></param>
    /// <param name="instance">The instance of the declaring type, if method is not static</param>
    /// <returns></returns>
    public static Option<Func<X1, X2, Y>> func<X1, X2, Y>(MethodInfo m, object instance = null)
        => Try(() => (Func<X1, X2, Y>)_funcCache.GetOrAdd(m, method =>
        {
            var args = stream(paramX<X1>("x1"), paramX<X2>("x2"));
            var f = invocation(instance, m, args.ToArray());
            return lambda<X1, X2, Y>(args, f).Compile();
        }));

    /// <summary>
    /// Creates and caches a function delegate for a method m:(X1,X2) -> Y
    /// </summary>
    /// <typeparam name="X1">The first argument</typeparam>
    /// <typeparam name="X2">The second argument</typeparam>
    /// <typeparam name="X3">The third argument</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="m"></param>
    /// <param name="instance">The instance of the declaring type, if method is not static</param>
    /// <returns></returns>
    public static Func<X1, X2, X3, Y> func<X1, X2, X3, Y>(MethodInfo m, object instance = null)
        => (Func<X1, X2, X3, Y>)_funcCache.GetOrAdd(m, method =>
        {
            var args = stream(paramX<X1>("x1"), paramX<X2>("x2"), paramX<X3>("x3"));
            var f = invocation(instance, m, args.ToArray());
            return lambda<X1, X2, X3, Y>(args, f).Compile();
        });


    /// <summary>
    /// Creates and caches a weakly-typed delegate for a method m:(X1,X2) -> Y
    /// </summary>
    /// <returns></returns>
    public static Func<object, object> func1(MethodInfo method, object Host = null)
    {
        var instance = ifNotNull(Host, x => constant(x));
        var paramInfo = method.GetParameters().Single();
        var typeDef = typeof(Func<,>).GetGenericTypeDefinition();
        var type = typeDef.MakeGenericType(array(paramInfo.ParameterType, method.ReturnType));
        var args = paramX(paramInfo.ParameterType, paramInfo.Name);
        var call = Expression.Call(instance, method, args);
        var l = Expression.Lambda(type, call, args);
        var del = l.Compile();
        return x => del.DynamicInvoke(x);
    }

    public static SelectionBuilder<T, X, Y> Selection<T, X, Y>(T t, X x)
        => new SelectionBuilder<T, X, Y>();

    public static SelectionBuilder<T, Y> Selection<T, Y>(T t)
        => new SelectionBuilder<T, Y>(t);

    public static TypeSelectionBuilder<TResult> TypeSwitch<TResult>(object value)
        => new TypeSelectionBuilder<TResult>(value);

    /// <summary>
    /// Lifts a value to a constant expression
    /// </summary>
    /// <param name="value">The value to lift</param>
    /// <returns></returns>
    public static ConstantExpression constant(object value)
        => XPR.Constant(value);

    public static class linqx
    {
        public static BinaryExpression and(XPR left, XPR right)
            => XPR.AndAlso(left, right);

        public static BinaryExpression or(XPR left, XPR right)
            => XPR.OrElse(left, right);

        /// <summary>
        /// Creates an expression to adjudicate whether a value if of a specified type
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <param name="t">The type to test against</param>
        /// <returns></returns>
        public static TypeBinaryExpression typeIs(object value, Type t)
            => XPR.TypeIs(constant(value), t);

        /// <summary>
        /// Creates an expression to adjudicate whether a value if of a specified type
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <typeparam name="T">The type to test against</typeparam>
        /// <returns></returns>
        public static TypeBinaryExpression typeIs<T>(object value)
            => XPR.TypeIs(constant(value), typeof(T));

        /// <summary>
        /// Creates an expression to call a function
        /// </summary>
        /// <param name="f">An expression representing the function to invoke</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static InvocationExpression invoke(XPR f, params XPR[] args)
            => XPR.Invoke(f, args);

        /// <summary>
        /// Forms a conjunction from two function predicates
        /// </summary>
        /// <typeparam name="X1">The first predicate argument type</typeparam>
        /// <typeparam name="X2">The second predicate argument type</typeparam>
        /// <param name="p1">The first predicate</param>
        /// <param name="p2">The second predicate</param>
        /// <returns></returns>
        public static Option<Func<X1, X2, bool>> and<X1, X2>(Func<X1, bool> p1, Func<X2, bool> p2)
            => from args in some(paramsX<X1, X2>())
                let left = invoke(funcx(p1), args.x1)
                let right = invoke(funcx(p2), args.x2)
                let body = and(left, right)
                select lambda<Func<X1, X2, bool>>(args, body).Compile();

        /// <summary>
        /// Forms a disjunction from two function predicates
        /// </summary>
        /// <typeparam name="X1">The first predicate argument type</typeparam>
        /// <typeparam name="X2">The second predicate argument type</typeparam>
        /// <param name="p1">The first predicate</param>
        /// <param name="p2">The second predicate</param>
        /// <returns></returns>
        public static Option<Func<X1, X2, bool>> or<X1, X2>(Func<X1, bool> p1, Func<X2, bool> p2)
            => from args in some(paramsX<X1, X2>())
                let left = invoke(funcx(p1), args.x1)
                let right = invoke(funcx(p2), args.x2)
                let body = or(left, right)
                select lambda<Func<X1, X2, bool>>(args, body).Compile();
    }
}
