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

    /// <summary>
    /// Constructs and manipulates <see cref="Setoid{X}"/> types and values
    /// </summary>
    public class Setoid : ClassModule<Setoid, ISetoid>
    {
        public Setoid()
            : base(typeof(Setoid<>))
        {

        }

        /// <summary>
        /// Defines a Setoid over <typeparamref name="X"/> predicated 
        /// on a specified <see cref="Equator{X}"/>
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <returns></returns>
        public static ISetoid<X> make<X>(Equator<X> comparer)
            => new Setoid<X>(comparer);


        public static Option<ISetoid<X>> make<X>()
            => Try(() => new Setoid<X>((x1, x2) => operators.eq(x1, x2)) as ISetoid<X>);


    }

}