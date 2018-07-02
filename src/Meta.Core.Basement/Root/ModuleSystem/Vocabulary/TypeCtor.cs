//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;
    
      

    public class TypeCtor
    {

        public TypeCtor(Type GenericType)
        {
            this.GenericType = GenericType;
        }

        /// <summary>
        /// The open generic type from which a closed type can be formed
        /// </summary>
        public Type GenericType { get; }

    }

 
}