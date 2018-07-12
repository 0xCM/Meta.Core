//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    /// <summary>
    /// Constructs and manipulates <see cref="IMonad"/> types and values
    /// </summary>
    public class Monad : ClassModule<Monad, IMonad>, IMonad
    {
        
        public Monad()
            : base(typeof(Monad<,,,,>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="IMonad"/> predicated on supplied data
        /// </summary>
        /// <param name="apply">A realization of the <see cref="IApply"/> typeclass </param>
        /// <param name="bind">A realization of the <see cref="IBind"/> typeclass </param>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="CX">A domain container</typeparam>
        /// <typeparam name="CFX">A function container</typeparam>
        /// <typeparam name="CY">A codomain container</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        public static IMonad<X, CX, CFX, Y, CY> make<X, CX, CFX, Y, CY>(IApplicative<X, CX, CFX, Y, CY> apply, IBind<X, CX, CFX, Y, CY> bind)
            where CX : IContainer<X>
            where CFX : IContainer<Func<X, Y>>
            where CY : IContainer<Y>
                => new Monad<X, CX, CFX, Y, CY>(apply, bind);
    }

}
