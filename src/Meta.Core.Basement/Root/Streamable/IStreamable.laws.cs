//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IStreamable
    {

    }

    public interface IStreamable<X> : IStreamable
    {
        /// <summary>
        /// Presents the underlying data as a stream
        /// </summary>
        /// <returns></returns>
        IEnumerable<X> Stream();

        /// <summary>
        /// Characterizes the cardinality of the stream
        /// </summary>
        Cardinality Cardinality { get; }
    }


}