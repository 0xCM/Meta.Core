//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{

    /// <summary>
    /// Specifies a trasformation on a single type within the same space
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="X"></typeparam>
    public abstract class TypeTransformer<S, X>
        where S : ITypeSpace<S>
    {
        protected TypeTransformer(S Space)
        {
            this.Space = Space;
        }

        public S Space { get; }



    }


    /// <summary>
    /// Specifies a transformation from one type to another within the same space
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public abstract class TypeTransformer<S, X, Y>
        where S : ITypeSpace<S>
    {
        protected TypeTransformer(S Space)
        {
            this.Space = Space;
        }

        public S Space { get; }


    }

    public abstract class TypeTransformer<A, X, B, Y>
        where A : ITypeSpace<A>
        where B : ITypeSpace<B>
    {
        public TypeTransformer(A SourceSpace, B TargetSpace)
        {
            this.SourceSpace = SourceSpace;
            this.TargetSpace = TargetSpace;
        }

        public A SourceSpace { get; }


        public B TargetSpace { get; }

    }




}