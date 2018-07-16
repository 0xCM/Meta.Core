//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Signature for weakly-typed container constructors
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="stream"></param>
    /// <returns></returns>
    public delegate IContainer<X> ContainerFactory<X>(IEnumerable<X> stream);

    /// <summary>
    /// Signature for strongly-typed container constructors
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="CX"></typeparam>
    /// <param name="s"></param>
    /// <returns></returns>
    public delegate CX ContainerFactory<X, CX>(IEnumerable<X> s);

    /// <summary>
    /// Identifies a container
    /// </summary>
    public interface IContainer : IStreamable
    {
        
    }

    
    /// <summary>
    /// Characterizes a data structure that contains zero or more
    /// elements of a specific type
    /// </summary>
    /// <typeparam name="X">The contained element type</typeparam>
    public interface IContainer<X> : IContainer, IStreamable<X>, IContext<X>
    {
        ContainerFactory<X> GetFactory();

        /// <summary>
        /// Retrieves the empty container of the same clase for an element type <typeparamref name="Y"/>
        /// </summary>
        IContainer<Y> GetEmpty<Y>();
    }

    /// <summary>
    /// Defines contract for a parameterized container
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="CX"></typeparam>
    public interface IContainer<X,CX> : IContext<X, CX>, IEquatable<CX>,  IContainer<X>
        where CX : IContainer<X,CX>, new()
    {
        /// <summary>
        /// Obtains the factory used to produce the container
        /// </summary>
        /// <returns></returns>
        ContainerFactory<X, CX> Factory { get; }

        /// <summary>
        /// Specifies the empty container for <typeparamref name="X"/>
        /// </summary>
        CX Empty { get; }
           
    }

    /// <summary>
    /// Characterizes a data structure that contains zero or more
    /// elements of of a *factored* type
    /// </summary>
    /// <typeparam name="X1">The first factored type</typeparam>
    /// <typeparam name="X2">The second factoted type</typeparam>
    public interface IFactoredContainer<X1, X2> : IContainer, IStreamable<(X1, X2)>
    {
        /// <summary>
        /// Transforms the contained data via a supplied function and returns
        /// the transformed result in a new container
        /// </summary>
        /// <typeparam name="Y1">The first output factor type</typeparam>
        /// <typeparam name="Y2">The second output factor type</typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        IFactoredContainer<Y1, Y2> Recontain<Y1, Y2>(Func<(X1, X2), (Y1, Y2)> map);

    }


    /// <summary>
    /// Characterizes a data structure that contains zero or more
    /// elements of of a *factored* type
    /// </summary>
    /// <typeparam name="X1">The first factored type</typeparam>
    /// <typeparam name="X2">The second factored type</typeparam>
    /// <typeparam name="X3">The third factored type</typeparam>
    public interface IFactoredContainer<X1, X2, X3> : IContainer, IStreamable<(X1, X2, X3)>
    {
        /// <summary>
        /// Transforms the contained data via a supplied function and returns
        /// the transformed result in a new container
        /// </summary>
        /// <typeparam name="Y1">The first output factor type</typeparam>
        /// <typeparam name="Y2">The second output factor type</typeparam>
        /// <typeparam name="Y3">The third output factor type</typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        IFactoredContainer<Y1, Y2, Y3> Recontain<Y1, Y2, Y3>(Func<(X1, X2, X3), (Y1, Y2, Y3)> map);

    }


}