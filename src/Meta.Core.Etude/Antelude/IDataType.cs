//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    
    /// <summary>
    /// Identifies a data type
    /// </summary>
    public interface IDataType
    {

    }

    /// <summary>
    /// Identifies a 1-parameter data type
    /// </summary>
    /// <typeparam name="X">The parameter type</typeparam>
    public interface IDataType<X> : IDataType
    {

    }

    /// <summary>
    /// Identifies a 2-parameter data type
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    public interface IDataType<X1,X2> : IDataType
    {

    }

    /// <summary>
    /// Identifies a 3-parameter data type
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    public interface IDataType<X1, X2, X3> : IDataType
    {

    }

    /// <summary>
    /// Identifies a 4-parameter data type
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    /// <typeparam name="X4">The type of the fourth parameter</typeparam>
    public interface IDataType<X1, X2, X3, X4> : IDataType
    {

    }

}