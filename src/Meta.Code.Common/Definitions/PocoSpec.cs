//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Specifies a simple poco type
    /// </summary>
    public class PocoSpec : TypeSpec<PocoSpec>
    {

        public PocoSpec()
        {
        }

        public PocoSpec(string TypeName)
            : base(TypeName)
        {
        }


        /// <summary>
        /// The properties defined by the poco
        /// </summary>
        public IReadOnlyList<PocoPropertySpec> Properties { get; set; }
            = new List<PocoPropertySpec>();
    }


}