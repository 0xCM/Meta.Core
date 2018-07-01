//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    partial class etude
    {
        /// <summary>
        /// Constructs the canonical <see cref="IMonad"/> instance for a list
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <typeparam name="Y">The transformed element type</typeparam>
        /// <returns></returns>
        public static IMonad<X, List<X>, List<Func<X, Y>>, Y, List<Y>> listM<X, Y>()
            => ListMonad<X, Y>.instance;

        /// <summary>
        /// Instantiates the <see cref="IMonad"/> instance for a sequence
        /// </summary>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        /// <returns></returns>
        public static IMonad<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> seqM<X, Y>()
            => SeqMonad<X, Y>.instance;

    }
}