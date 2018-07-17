//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Runtime.CompilerServices;

using Meta.Core;

/// <summary>
/// Represents a potential value
/// </summary>
/// <typeparam name="T">The potential value type</typeparam>
public readonly struct Option<T> : IOption<T>, IEquatable<Option<T>>
{
    /// <summary>
    /// Initializes a None with optional message content
    /// </summary>
    /// <param name="Message">The reason for None</param>
    /// <returns></returns>
    public static Option<T> None(IAppMessage Message = null)
        => new Option<T>(Message);
    
    /// <summary>
    /// Populates a Some with optional message content
    /// </summary>
    /// <param name="Value">The encapsulated value</param>
    /// <param name="Message">The associated message</param>
    /// <returns></returns>
    public static Option<T> Some(T Value, IAppMessage Message = null)
        => new Option<T>(Value, Message ?? AppMessage.Empty);

    /// <summary>
    /// Populates a None with exception content
    /// </summary>
    /// <param name="e">The reason for None</param>
    /// <returns></returns>
    public static Option<T> None(Exception e)
        => new Option<T>(AppMessage.Error(e.ToString()));

    public static explicit operator T(Option<T> x)
        => x ? x.value : throw new ArgumentNullException();

    public static T operator ~ (Option<T> x)
        => x ? x.value : throw new ArgumentNullException();
    
    public static implicit operator Option<T>(T x)
        => x != null 
        ? new Option<T>(x) 
        : new Option<T>(AppMessage.Empty);

    /// <summary>
    /// Implmements value-based equality
    /// </summary>
    /// <param name="x">The first value</param>
    /// <param name="y">The second value</param>
    /// <returns></returns>
    public static bool operator == (Option<T> x, Option<T> y)
        => (x.IsNone() && y.IsNone())  
        ? true : (x.Exists && y.Exists && x.value.Equals(y.value));

    /// <summary>
    /// Implements value-based equality negation
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static bool operator != (Option<T> x, Option<T> y)
        => !(x == y);

    public static bool operator true(Option<T> x)
        => x.Exists;

    public static bool operator false(Option<T> x)
        => !x.Exists;

    public static bool operator !(Option<T> x)
        => !x.Exists;
   
    Option(bool isSome, T value, IAppMessage message)
    {
        this.Exists = isSome;
        this.value = value;
        this.Message = message ?? AppMessage.Empty;
    }

    /// <summary>
    /// Initializes a valued option with optional message content
    /// </summary>
    /// <param name="value">The encapsulated value</param>
    /// <param name="message">An optional message</param>
    public Option(T value, IAppMessage message = null)
    {
        if (value is IOption)
        {
            var o = value as IOption;
            this.Exists = o.IsSome;
            this.Message = message ?? o.Message ?? AppMessage.Empty;
            this.value = this.Exists ?
                (o.Value is T ? (T)o.Value : value)                
                : default;
        }
        else
        {
            this.Exists = (value != null);
            this.value = value;
            this.Message = message ?? AppMessage.Empty;
        }
        
    }

    public Option(IAppMessage message = null)
    {
        this.Exists = false;
        this.value = default;
        this.Message = message ?? AppMessage.Empty;
    }

    /// <summary>
    /// The encapsulated value, iff Exists is true
    /// </summary>
    readonly T value;

    /// <summary>
    /// Specifies whether the option has a value
    /// </summary>
    public bool Exists { get; }

    /// <summary>
    /// Specifies the message associated with the optional value
    /// </summary>
    public IAppMessage Message { get; }

    /// <summary>
    /// Returns true if the value exists
    /// </summary>
    /// <returns></returns>
    public bool IsSome()
        => Exists;

    /// <summary>
    /// Returns true if the value does not exist
    /// </summary>
    /// <returns></returns>
    public bool IsNone()
        => !Exists;

    /// <summary>
    /// Applies the a function to evaluate the underlying value if it exists
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="F"></param>
    /// <returns></returns>
    public Option<X> IfSome<X>(Func<T, X> F)
        => Exists ? F(value) : Option.None<X>();

    /// <summary>
    /// Invokes an action if the value exists
    /// </summary>
    /// <param name="ifSome">The action to potentially ivoke</param>
    /// <returns></returns>
    public Option<T> OnSome(Action<T> ifSome)
    {
        if (Exists)
            ifSome(value);
        return this;
    }

    /// <summary>
    /// Invokes an action if the value exists
    /// </summary>
    /// <param name="ifSome">The action to potentially ivoke</param>
    /// <returns></returns>
    public Option<T> OnSome(Action<T, IAppMessage> ifSome)
    {
        if (Exists)
            ifSome(value, Message);
        return this;
    }

    /// <summary>
    /// Invokes an action if the value doesn't exist
    /// </summary>
    /// <param name="ifNone">The action to invoke</param>
    /// <returns></returns>
    public Option<T> OnNone(Action ifNone)
    {
        if (IsNone())
            ifNone();
        return this;
    }

    /// <summary>
    /// Replaces the existing message
    /// </summary>
    /// <param name="message">The new message</param>
    /// <returns></returns>
    public Option<T> WithMessage(IAppMessage message)
        => new Option<T>(this.Exists, this.value, message);

    /// <summary>
    /// Replaces the message value when the value exists
    /// </summary>
    /// <param name="f">The message factory</param>
    /// <returns></returns>
    public Option<T> WithMessage(Func<T, IAppMessage> f)
        => this.Exists 
        ? new Option<T>(this.Exists, this.value, f(this.value))
        : this;
        
    /// <summary>
    /// Invokes an action if the value doesn't exist
    /// </summary>
    /// <param name="ifNone">The action to invoke</param>
    /// <returns></returns>
    public Option<T> OnNone(Action<IAppMessage> ifNone)
    {
        if (IsNone())
            ifNone(Message);
        return this;
    }


    /// <summary>
    /// Yields the encapulated value if present; otherwise, raises an exception
    /// </summary>
    /// <returns></returns>
    public T Require(
        [CallerMemberName] string caller = null, 
        [CallerFilePath] string file = null, 
        [CallerLineNumber] int linenumber = 0)
            =>  Exists ? value : throw new Exception<T>(this.Message?.Format(), caller, file, linenumber);
    

    static readonly T _Default = default;
        
    public T Default 
        => _Default;

    T IOption<T>.Value 
        => value;

    object IOption.Value 
        => value;

    bool IOption.IsSome 
        => Exists;

    bool IOption.IsNone 
        => !Exists;

    /// <summary>
    /// The type of the encapsulated value, if present
    /// </summary>
    public Type ValueType
        => typeof(T);

    /// <summary>
    /// Extracts the encapulated value if it exists; otherwise, returns the default value for
    /// the underlying type which is NULL for reference types
    /// </summary>
    /// <param name="default"></param>
    /// <returns></returns>
    public T ValueOrDefault(T @default = default(T))
        => Exists ? value : @default;

    /// <summary>
    /// Returns the encapsulated value if it exists; otherwise, invokes the fallback function <paramref name="fallback"/>
    /// to obtain value
    /// </summary>
    /// <param name="fallback"></param>
    /// <returns></returns>
    public T ValueOrElse(Func<T> fallback)
        => Exists ? value : fallback();

    /// <summary>
    /// Applies supplied function to value if present, otherwise invokes fallback <paramref name="fallback"/>
    /// </summary>
    /// <typeparam name="S">The output type</typeparam>
    /// <param name="f">The function to apply when value exists</param>
    /// <param name="fallback">The function to invoke when no value exists</param>
    /// <returns></returns>
    public S Map<S>(Func<T, S> f, Func<S> fallback)
        => Exists  ? f(value)  : fallback();

    /// <summary>
    /// Applies supplied function to value if present, otherwise invokes fallback <paramref name="fallback"/>
    /// </summary>
    /// <typeparam name="S">The output type</typeparam>
    /// <param name="f">The function to apply when value exists</param>
    /// <param name="fallback">The function to invoke when no value exists</param>
    /// <returns></returns>
    public S Map<S>(Func<T, S> f, Func<IAppMessage,S> fallback)
        => Exists ? f(value) : fallback(Message);

    /// <summary>
    /// Applies a function to value if present, otherwise returns None
    /// </summary>
    /// <typeparam name="S">The output type</typeparam>
    /// <param name="f">The function to apply when value exists</param>
    /// <returns></returns>
    public Option<S> Map<S>(Func<T, S> f)
        => Exists ? Option.Some(f(value), Message) : Option.None<S>(Message);

    /// <summary>
    /// Transforms the value, if present, otherwise invokes a function
    /// to produce an appropriate value of the target type if not
    /// </summary>
    /// <typeparam name="S">The target type</typeparam>
    /// <param name="ifSome">The transformer</param>
    /// <param name="fallback">The alternate transformer</param>
    /// <returns></returns>
    public S MapValueOrElse<S>(Func<T, S> ifSome, Func<IAppMessage, S> fallback)
        => Exists  ? ifSome(value)  : fallback(Message);

    /// <summary>
    /// Transforms the value, if present, otherwise invokes a function
    /// to produce an appropriate value of the target type if not
    /// </summary>
    /// <typeparam name="S">The target type</typeparam>
    /// <param name="ifSome">The transformer</param>
    /// <param name="fallback">The alternate transformer</param>
    /// <returns></returns>
    public S MapValueOrElse<S>(Func<T, IAppMessage, S> ifSome, Func<IAppMessage, S> fallback)
        => Exists  ? ifSome(value, Message)  : fallback(Message);

    /// <summary>
    /// Applies a function to the encapsulated value if it exists; otherwise, returns a default value
    /// </summary>
    /// <typeparam name="S">The projected value type</typeparam>
    /// <param name="ifSome">The function to apply when a value exists</param>
    /// <param name="default">The value to return when no value exists</param>
    /// <returns></returns>
    public S MapValueOrDefault<S>(Func<T, S> ifSome, S @default = default)
        => Exists ? ifSome(value) :  @default;

    /// <summary>
    /// Drops the encapsulated value, if any, and projects None to target space
    /// </summary>
    /// <typeparam name="S">The target space type</typeparam>
    /// <returns></returns>
    public  Option<S> ToNone<S>()
        => Option.None<S>(Message);

    /// <summary>
    /// Invokes an action when the message is nonempty
    /// </summary>
    /// <param name="action">The action to potentially invoke</param>
    /// <returns></returns>
    public Option<T> OnMessage(Action<IAppMessage> action)
    {
        if (!Message.IsEmpty)
            action(Message);
        else if (!Exists)
            action(AppMessage.Error("No value"));
        return this;
    }

    /// <summary>
    /// LINQ integration function
    /// </summary>
    /// <typeparam name="Y"></typeparam>
    /// <param name="apply"></param>
    /// <returns></returns>    
    public Option<Y> Select<Y>(Func<T, Y> apply)
        => Map(_x => apply(_x));

    /// <summary>
    /// LINQ integration function
    /// </summary>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <param name="eval"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public Option<Z> SelectMany<Y, Z>(Func<T, Option<Y>> eval, Func<T, Y, Z> project)
    {
        if (Exists)
        {
            var v = value;
            var y = eval(v);
            var z = Option.bind(y, yVal => Option.Some(project(v, yVal), y.Message));
            return z;
        }
        else
            return Option.None<Z>(Message);
    }

    /// <summary>
    /// LINQ integration function
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Option<T> Where(Func<T, bool> predicate)
    {
        if (Exists)
        {
            if (predicate(value))
                return value;
            else
                return new Option<T>(AppMessage.Empty);
        }
        else
            return value;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (Exists)
        {
            if (obj is IOption)
            {
                var other = obj as IOption;
                if (other.IsSome)
                    return object.Equals(value, other.Value);
                else
                    return false;
            }
            else if (obj is T)
                return object.Equals(this.value, obj);
            else
                return false;
        }
        else
        {
            if (obj is Option<T>)
                return (obj as IOption).IsNone;
            else
                return false;
        }
    }

    public override int GetHashCode()
        => Exists 
        ? value.GetHashCode() 
        : typeof(T).Name.GetHashCode();

    public override string ToString()
        => Option.render(this);

    public bool Equals(Option<T> other)
        => Option.eq(this, other);
}