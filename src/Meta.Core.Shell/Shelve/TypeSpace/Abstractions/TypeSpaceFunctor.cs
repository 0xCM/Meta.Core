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

    /// <summary>
    /// Defines a transformation between type spaces
    /// </summary>
    /// <typeparam name="A">The source space</typeparam>
    /// <typeparam name="X">A point in the source space</typeparam>
    /// <typeparam name="B">The target space</typeparam>
    /// <typeparam name="Y">A point in the source space</typeparam>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Functor
    /// </remarks>
    public abstract class TypeSpaceFunctor<A, X, B, Y>
        where A : ITypeSpace
        where B : ITypeSpace
    {
        protected TypeSpaceFunctor(A SourceSpace, B TargetSpace)
        {
            this.SourceSpace = SourceSpace;
            this.TargetSpace = TargetSpace;
        }

        public A SourceSpace { get; }

        public B TargetSpace { get; }
        

        public abstract Y Apply(X src);
    }

}