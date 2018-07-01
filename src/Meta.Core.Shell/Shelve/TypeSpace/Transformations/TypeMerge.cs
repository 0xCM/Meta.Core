//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using static metacore;

    public sealed class TypeMerge<S, X, Y> 
        where S : TypeSpace<S>, new()

    {
        public TypeMerge(S Space)
        {
            this.Space = Space;

        }

        public S Space { get; }

    }


    public static partial class TranformationFunctions
    {

        public static TypeMerge<S, X, Y> Merge<S, X, Y>(this S s, IMetaType<S, X> x, IMetaType<S, X> y)
            where S : TypeSpace<S>, new()
                => new TypeMerge<S, X, Y>(s);

    }


}