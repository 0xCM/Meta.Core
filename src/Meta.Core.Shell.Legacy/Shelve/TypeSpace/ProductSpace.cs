//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    using System;
    using System.Linq;

    public sealed class ProductSpace<A, B> : TypeSpace<ProductSpace<A,B>>
        where A : TypeSpace<A>, new()
        where B : TypeSpace<B>, new()
    {
        public ProductSpace()
            : this(new A(), new B())
        {


        }

        public ProductSpace(A SpaceA, B SpaceB)
            : base($"{SpaceA}x{SpaceB}")
        {

            this.SpaceA = SpaceA;
            this.SpaceB = SpaceB;
        }

        public A SpaceA { get; }

        public B SpaceB { get; }

    }
}