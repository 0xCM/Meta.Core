//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;
    using System.Collections.Generic;
    

    public interface ITypeConstructor<X, TX, AX>
    {
        Func<AX,TX> ctor();        
    }


    public class TypeConstructor
    {

        public TypeConstructor(Type GenericType)
        {
            this.GenericType = GenericType;
        }

        /// <summary>
        /// The open generic type from which a closed type can be formed
        /// </summary>
        public Type GenericType { get; }

        //public override string ToString()
        //    => $"{GenericType.DisplayName()}";

    }




 
}