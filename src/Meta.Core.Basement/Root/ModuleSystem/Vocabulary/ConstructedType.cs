//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    
    public class ConstructedType
    {
        public ConstructedType(TypeCtor Constructor, Type[] Arguments, Type Constructed)
        {
            this.Contructor = Constructor;
            this.Arguments = Arguments;
            this.Constructed = Constructed;
        }

        public TypeCtor Contructor { get; }

        public Type[] Arguments { get; }

        public Type Constructed { get; }
    }

}