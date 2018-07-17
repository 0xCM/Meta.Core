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

    
    public interface INumber : IDataType
    {
        /// <summary>
        /// The encapsulated (and boxed) value
        /// </summary>
        object Value { get; }        
    }

    /// <summary>
    /// Defines the generic number concept
    /// </summary>
    /// <typeparam name="X">The underlying value type</typeparam>
    public interface INumber<X> : INumber, IDataType<X>
        where X : struct
    {
        /// <summary>
        /// The enapsulated (and unboxed) value
        /// </summary>
        new X Value { get; }
        
        /// <summary>
        /// Adds a value to the number
        /// </summary>
        /// <param name="x">The value to add</param>
        /// <returns></returns>
        X Add(X x);

        /// <summary>
        /// Subtracts a value from the number
        /// </summary>
        /// <param name="x">The value to subract</param>
        /// <returns></returns>
        X Sub(X x);

        /// <summary>
        /// Multiplies the number by a value
        /// </summary>
        /// <param name="x">The value to subract</param>
        /// <returns></returns>
        X Mul(X x);

        /// <summary>
        /// Divides the number by a value
        /// </summary>
        /// <param name="x">The value to subract</param>
        X Div(X x);

        /// <summary>
        /// Computes the modulus of a number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        X Mod(X x);

        /// <summary>
        /// Determines whether the number is equal to another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool Eq(X x);

        /// <summary>
        /// Determines whether the number is not equal to another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool Neq(X x);

        /// <summary>
        /// Determines whether the number is less than another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool Lt(X x);

        /// <summary>
        /// Determines whether the number is less than or equal to another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool LtEq(X x);

        /// <summary>
        /// Determines whether the number is greater than another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool Gt(X x);

        /// <summary>
        /// Determines whether the number is greater than or equal to another
        /// </summary>
        /// <param name="x">The value to compare</param>
        bool GtEq(X x);

        /// <summary>
        /// Increments the number by it's multiplicative unit
        /// </summary>
        /// <returns></returns>
        X Inc();

        /// <summary>
        /// Decrements the number by it's multiplicative unit
        /// </summary>
        /// <returns></returns>
        X Dec();
    }
}