//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;
    using System.Collections;
    using  System.Collections.Generic;


    /// <summary>
    /// Seq constructor
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    public readonly struct SeqC<X> : ITypeConstructor<X, Seq<X>, IEnumerable<X>>
    {
        public static implicit operator TypeConstructor(SeqC<X> c)
            => new TypeConstructor(typeof(Seq<>));

        static readonly SeqFactory<X> Factory = Seq<X>.Factory;

        public static SeqFactory<X> ctor()
            => Factory;

        Func<IEnumerable<X>, Seq<X>> ITypeConstructor<X, Seq<X>, IEnumerable<X>>.ctor()
            => source => ctor()(source);
    }


}