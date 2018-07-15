//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    public interface ITypeAssociation<S>
        where S : ITypeSpace<S>
    {
        S Space { get; }

        object x { get; }
        object y { get; }
    }


    public interface ITypeAssociation<S, X, Y> : ITypeAssociation<S>
            where S : ITypeSpace<S>
    {

        new X x { get; }
        new Y y { get; }
    }

    /// <summary>
    /// Specifies an association to self
    /// </summary>
    public interface ITypeAssociation<S, X> : ITypeAssociation<S, X, X>
        where S : ITypeSpace<S>
    {


    }
    

    public interface ITypeAssociation<A, X, B, Y>
            where A : ITypeSpace<A>
            where B : ITypeSpace<B>
    {
        A Domain { get; }

        X x { get; }       

        B Codomain { get; }

        Y y { get; }



    }
}