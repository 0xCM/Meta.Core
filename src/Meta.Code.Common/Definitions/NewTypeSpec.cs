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
    /// Defines a "NewType" instance
    /// </summary>
    public class NewTypeSpec : TypeSpec<NewTypeSpec>
    {
        public NewTypeSpec()
        {

        }


        public NewTypeSpec(string TargetTypeName, string WrappedTypeName)
            : base(TargetTypeName)
        {
            this.WrappedTypeName = WrappedTypeName;
        }
        
        /// <summary>
        /// The type of encapsulated value
        /// </summary>
        public string WrappedTypeName { get; set; }

        /// <summary>
        /// Then name of the type that encapsulates the value
        /// </summary>
        public string DerivedTypeName
            => TargetName;

                    
    }
    
}
