//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
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
            => unionize(ExcludedSchemas, IncludedSchemas).Count() != 0;

        /// <summary>
        /// Specifies whether system objects, i.e., database elements that are not user-defined, from the result
        /// </summary>
        public bool ExcludeSystemObjects { get; set; }

    }
}
