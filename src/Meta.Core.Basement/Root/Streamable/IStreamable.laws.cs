//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public interface IStreamable
    {
        IEnumerable Stream();    
    }

    public interface IStreamable<X> : IStreamable
    {
        /// <summary>
        /// Presents the underlying data as a stream
        /// </summary>
        /// <returns></returns>
        new IEnumerable<X> Stream();

        /// <summary>
        /// Characterizes the cardinality of the stream
        /// </summary>
        Cardinality Cardinality { get; }
    }


}