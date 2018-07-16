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
    /// Defines a public property with both getters/setters
    /// </summary>
    public class PocoPropertySpec : PropertySpec<PocoPropertySpec>
    {
        public PocoPropertySpec()
        {


        }
        public PocoPropertySpec(string PropertyName, string PropertyType)
            : base(PropertyName, PropertyType)
        {

        }

    }

}