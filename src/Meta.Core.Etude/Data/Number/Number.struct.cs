//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static etude;
    using static metacore;
    
    /// <summary>
    /// Generic Number
    /// </summary>
    /// <typeparam name="X">The unederlying primitive type</typeparam>
    public readonly struct Number<X> : IEquatable<Number<X>>, INumber<X>
        where X : struct
    {
        /// <summary>
        /// Specifies the absence of a value
        /// </summary>
        public static Number<X>? None 
            => null;
        
        /// <summary>
        /// Specifies the additive identity
        /// </summary>    
        public static readonly Number<X> Zero 
            = operators.zero<X>();

        /// <summary>
        /// Specifies the multiplicative identity
        /// </summary>    
        public static readonly Number<X> One 
            = operators.one<X>();

        /// <summary>
        /// Specifies the smallest representable value
        /// </summary>
        public static readonly Number<X> Min
           = (from f in field<X>("MinValue")
              from v in value<X>(f)
              select v).Require();

        /// <summary>
        /// Specifies the greatest representable value
        /// </summary>
        public static readonly Number<X> Max
           = (from f in field<X>("MaxValue")
              from v in value<X>(f)
              select v).Require();

        /// <summary>
        /// Implicitly lifts/converts a <typeparamref name="X"/>-value to a <see cref="Number{T}"/>
        /// </summary>
        /// <param name="value"></param>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Number<X>(X value)
            => new Number<X>(value);

        /// <summary>
        /// Implicitly descends/converts a <see cref="Number{T}"/> to its underlying <typeparamref name="X"/>-value 
        /// </summary>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator X(Number<X> number)
            => number.Value;

        /// <summary>
        /// Computes the sum of two numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator +(Number<X> x, Number<X> y)
            => operators.add(x.Value, y.Value);

        /// <summary>
        /// Computes the difference of two numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator -(Number<X> x, Number<X> y)
            => operators.sub(x.Value, y.Value);

        /// <summary>
        /// Negates a number
        /// </summary>
        /// <param name="x">The number to negate</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator -(Number<X> x)
            => operators.neg(x.Value);

        /// <summary>
        /// Computes the product of two numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator *(Number<X> x, Number<X> y)
            => operators.mul(x.Value, y.Value);

        /// <summary>
        /// Computes the quotient of two numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator /(Number<X> x, Number<X> y)
            => operators.div(x.Value, y.Value);

        /// <summary>
        /// Computes the modulus of two numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator %(Number<X> x, Number<X> y)
            => operators.mod(x.Value, y.Value);

        /// <summary>
        /// Determines whether the first number is greater than the second number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Number<X> x, Number<X> y)
            => operators.gt(x.Value, y.Value);

        /// <summary>
        /// Determines whether the first number is less than the second number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Number<X> x, Number<X> y)
            => operators.lt(x.Value, y.Value);

        /// <summary>
        /// Determines whether the first number is greater than or equal to the second number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Number<X> x, Number<X> y)
            => operators.gteq(x.Value, y.Value);

        /// <summary>
        /// Determines whether the first number is less than the second number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Number<X> x, Number<X> y)
            => operators.lteq(x.Value, y.Value);

        /// <summary>
        /// Determines whether the first number is equal to the second number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Number<X> x, Number<X> y)
            => operators.eq(x.Value, y.Value);

        /// <summary>
        /// Determines whether two numbers are equal
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Number<X> x, Number<X> y)
            => operators.neq(x.Value, y.Value);

        /// <summary>
        /// Increments the number by it's multiplicative unit
        /// </summary>
        /// <param name="x">The number to decrement</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator ++(Number<X> x)
            => operators.increment(x.Value);

        /// <summary>
        /// Decrements the number by it's multiplicative unit
        /// </summary>
        /// <param name="x">The number to decrement</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<X> operator --(Number<X> x)
            => operators.decrement(x.Value);
        
        /// <summary>
        /// Intializes a numeric value
        /// </summary>
        /// <param name="Value">The value</param>
        public Number(X Value)
            => this.Value = Value;

        /// <summary>
        /// The encapsulated value
        /// </summary>
        public X Value { get; }

        /// <summary>
        /// Converts the represented value to a <typeparamref name="Y"/> value
        /// </summary>
        /// <typeparam name="Y">The target conversion type</typeparam>
        /// <returns></returns>
        public Number<Y> Convert<Y>()
            where Y : struct
                => operators.convert<X,Y>(Value);

        /// <summary>
        /// Attempts to convert the represented value; reuturns the
        /// converted value upon success or null if failure.
        /// </summary>
        /// <typeparam name="Y">The target conversion type</typeparam>
        /// <returns></returns>
        public Number<Y>? TryConvert<Y>()
            where Y : struct
        {
            try
            {
                return Convert<Y>();
            }
            catch(Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Applies a function to the underlying value
        /// </summary>
        /// <typeparam name="S">The output type</typeparam>
        /// <param name="f">The function to apply</param>
        /// <returns></returns>
        public Number<S> Map<S>(Func<X, S> f)
            where S : struct => f(this.Value);

        /// <summary>
        /// Implements the canonical bind operation
        /// </summary>
        /// <typeparam name="Y">The target domain type</typeparam>
        /// <param name="f">The function to apply to effect the bind</param>
        /// <returns></returns>
        public Number<Y> Bind<Y>(Func<X, Number<Y>> f)
            where Y : struct
                => f(Value);

        /// <summary>
        /// LINQ Select operator
        /// </summary>
        /// <typeparam name="Y"></typeparam>
        /// <param name="apply"></param>
        /// <returns></returns>
        public Number<Y> Select<Y>(Func<X, Y> apply)
            where Y : struct
                => Map(_x => apply(_x));

        /// <summary>
        /// LINQ SelectMany integration
        /// </summary>
        /// <typeparam name="Y"></typeparam>
        /// <typeparam name="Z"></typeparam>
        /// <param name="eval"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public Number<Z> SelectMany<Y, Z>(Func<X, Number<Y>> eval, Func<X, Y, Z> project)
            where Y : struct
            where Z : struct
        {
            var _value = Value;
            var y = eval(_value);
            var z = y.Bind(yVal => number(project(_value, yVal)));
            return z;
        }

        /// <summary>
        /// LINQ integration
        /// </summary>
        /// <returns></returns>
        public Number<X> Where(Func<X, bool> predicate)
                => predicate(Value) ? this : Zero;

        /// <summary>
        /// Determines equality by delegating to the encapsulated value
        /// </summary>
        /// <param name="obj">The value to compare against</param>
        /// <returns></returns>
        public override bool Equals(object obj)
            => !(obj is Number<X>) ? false
            : ((Number<X>)obj).Value.Equals(Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString();

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Number<X> other)
            => operators.eq(other.Value, this.Value);

        #region INumber
        object INumber.Value
            => Value;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Add(X x)
            => this + x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Sub(X x)
            => this - x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Mul(X x)
            => this * x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Div(X x)
            => this / x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Mod(X x)
            => this % x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.Eq(X x)
            => this == x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.Neq(X x)
            => this != x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.Lt(X x)
            => this < x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.LtEq(X x)
            => this <= x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.Gt(X x)
            => this > x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool INumber<X>.GtEq(X x)
            => this >= x;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Inc()
            => operators.increment(Value);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        X INumber<X>.Dec()
            => operators.decrement(Value);
        #endregion
    }
}