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

    /// <summary>
    /// Defines contract for a named segment of work
    /// </summary>
    public interface IPartitionedWork
    {
        /// <summary>
        /// The name of the work segment
        /// </summary>
        string PartitionName { get; }

        /// <summary>
        /// The name of the group to which the work belongs, if applicable
        /// </summary>
        string GroupName { get; }
    }

}