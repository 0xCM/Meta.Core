//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static minicore;

    /// <summary>
    /// Represents the content of a contiguous interval between comparable lower and upper bounds of the same type
    /// </summary>
    public interface IInterval 
    {
        /// <summary>
        /// The first endpoint
        /// </summary>
        object Min { get; }

        /// <summary>
        /// The second endpoint
        /// </summary>
        object Max { get; }

        /// <summary>
        /// Specifies whether the left endpoint is included in the interval
        /// </summary>
        bool LeftInclusive { get; }

        /// <summary>
        /// Specifies whether the right endpoint is included in the interval
        /// </summary>
        bool RightInclusive { get; }
    }

    /// <summary>
    /// Represents the content of a contiguous interval between comparable lower and upper bounds of the same type
    /// </summary>
    public interface IInterval<out T> : IInterval
    {
        /// <summary>
        /// The inclusive lower bound
        /// </summary>
        new T Min { get; }

        /// <summary>
        /// The inclusive upper bound
        /// </summary>
        new T Max { get; }

    }
}