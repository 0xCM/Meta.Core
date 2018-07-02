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
    /// Base class for typeclass-specific modules
    /// </summary>
    /// <typeparam name="M"></typeparam>
    /// <typeparam name="I"></typeparam>
    public abstract class ClassModule<M, I> : TypeModule<M>
        where M : ClassModule<M, I>, new()

    {


    }



}