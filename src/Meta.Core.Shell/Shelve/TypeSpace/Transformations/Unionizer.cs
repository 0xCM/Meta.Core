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

    public sealed class TypeUnion<S, X, Y>
        where S : TypeSpace<S>, new()
    {
        public TypeUnion(S Space)
        {
            this.Space = Space;

        }

        public S Space { get; }

    }


    public static partial class TranformationFunctions
    {

        public static TypeUnion<S, X, Y> Union<S, X, Y>(this S s, IMetaType<S, X> x, IMetaType<S, X> y)
            where S : TypeSpace<S>, new() 
                => new TypeUnion<S, X, Y>(s);

    }


}