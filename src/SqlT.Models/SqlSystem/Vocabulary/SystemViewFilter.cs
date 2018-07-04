//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Constrains system view result sets
    /// </summary>
    public class SystemViewFilter
    {
        public SystemViewFilter()
        {
            IncludedSchemas = new List<string>();
            ExcludedSchemas = new List<string>();
            ExcludeSystemObjects = true;
        }

        public IReadOnlyList<string> IncludedSchemas { get; set; }
        public IReadOnlyList<string> ExcludedSchemas { get; set; }

        public bool IsActive 
            => union(ExcludedSchemas, IncludedSchemas).Count() != 0;

        /// <summary>
        /// Specifies whether system objects, i.e., database elements that are not user-defined, from the result
        /// </summary>
        public bool ExcludeSystemObjects { get; set; }

    }
}
