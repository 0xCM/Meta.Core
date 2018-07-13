//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    
    /// <summary>
    /// Encapsulates the result of a type constructor invocation
    /// </summary>
    public class TypeConstruction
    {
        public TypeConstruction(TypeConstructor Constructor, Type[] Arguments, Type Constructed)
        {
            this.Contructor = Constructor;
            this.Arguments = Arguments;
            this.Constructed = Constructed;
        }

        /// <summary>
        /// Specifies the type constructor that effected the consruction
        /// </summary>
        public TypeConstructor Contructor { get; }

        /// <summary>
        /// Specifies the arguments suppled to the type constructor
        /// </summary>
        public Type[] Arguments { get; }

        /// <summary>
        /// Specifies the constructed type
        /// </summary>
        public Type Constructed { get; }

    }

}