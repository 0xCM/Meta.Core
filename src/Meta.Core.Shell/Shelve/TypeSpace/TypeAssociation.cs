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


    /// <summary>
    /// Represents a directed edge from from one metaclass to another metaclass in the same space
    /// </summary>
    /// <typeparam name="S">The defining Type Space</typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public sealed class TypeAssociation<S,X,Y> : ITypeAssociation<S, X, Y>
        where S : TypeSpace<S>, new()
    {
        public TypeAssociation(S Space, X x, Y y)
        {
            this.Space = Space;
            this.x = x;
            this.y = y;
          
        }

        public S Space { get; }

        public X x { get; }

        public Y y { get; }


        object ITypeAssociation<S>.x
            => x;


        object ITypeAssociation<S>.y
            => y;
    }


    /// <summary>
    /// Represents a directed edge from a Metaclass defined over a <see cref="TypeSpace{A}"/>  
    /// to a Metaclass defined over a <see cref="TypeSpace{B}"/>
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public sealed class TypeAssociation<A, X, B, Y> : ITypeAssociation<A, X, B, Y>
            where A : ITypeSpace<A>
            where B : ITypeSpace<B>
    {


        public TypeAssociation(A Domain, X x, B Codomain, Y y)
        {
            this.Domain = Domain;
            this.x = x;
            this.Codomain = Codomain;
            this.y = y;
        }

        public A Domain { get; }
        public X x { get; }




        public B Codomain { get; }
        public Y y { get; }

    }
}