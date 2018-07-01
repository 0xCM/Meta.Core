//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Classifies an interval
    /// </summary>
    public enum IntervalType
    {
        /// <summary>
        /// Interval is closed and thus contains its lower and upper bounds
        /// </summary>
        Closed,
        
        /// <summary>
        /// Interval is open an thus contains niether its lower nor upper bound
        /// </summary>
        Open,

        /// <summary>
        /// Interval contain its upper bound but not its lower bound
        /// </summary>
        LeftOpen,

        /// <summary>
        /// Interval contains its lower bound but not its upper bound
        /// </summary>
        RightOpen,
        
    }

}