//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Collections.Generic;


    public abstract class GenEmitter<G,T> : IGenEmitter
        where G : GenEmitter<G,T>, new()
        where T : GenSpec<T>,new()
    {

        /// <summary>
        /// Generates the code as defined by a spec
        /// </summary>
        /// <param name="spec">The defining spec</param>
        /// <returns></returns>
        public abstract IEnumerable<string> Emit(GenContext context, T spec);

        IEnumerable<string> IGenEmitter.Emit(GenContext context, GenSpec spec)
            => Emit(context, (T)spec);

        bool IGenEmitter.CanEmit(Type specType)
            => specType == typeof(T);
    }


}