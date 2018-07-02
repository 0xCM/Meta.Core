//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    

    using static minicore;

    public static class TypeClass
    {

        public static AssemblyTraverser traverser(params Action<Type>[] TypeHandlers)
            => new AssemblyTraverser(TypeHandlers);


        /// <summary>
        /// Closes a typeclass with the supplied arguments 
        /// </summary>
        /// <param name="Arguments"></param>
        /// <returns></returns>
        public static Option<ConstructedType> construct(TypeCtor constructor, params Type[] Arguments)
            => Try(() => new ConstructedType(constructor,
                    Arguments, constructor.GenericType.MakeGenericType(Arguments)));

    }


}