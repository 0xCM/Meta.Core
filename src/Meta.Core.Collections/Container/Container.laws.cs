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
        /// <summary>
        /// Presents the contained data as a sequence
        /// </summary>
        /// <returns></returns>
        Seq<X> Contained();

        /// <summary>
        /// Obtains the factory used to produce the container, but specialized
        /// for another type
        /// </summary>
        /// <typeparam name="Y"></typeparam>
        /// <returns></returns>
        ContainerFactory<Y> Factory<Y>();
        
    }


    public interface IContainer<X,CX> : IContainer, IStreamable<X>, IContext<X>
    {
        /// <summary>
        /// Obtains the factory used to produce the container, but specialized
        /// for another type
        /// </summary>
        /// <typeparam name="Y"></typeparam>
        /// <returns></returns>
        ContainerFactory<X,CX> Factory();

    }
}