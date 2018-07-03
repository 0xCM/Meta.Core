//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class etude
{
    /// <summary>
    /// Constructs the canonical <see cref="IMonad"/> instance for a list
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <typeparam name="Y">The transformed element type</typeparam>
    /// <returns></returns>
    public static IListMonad<X,Y> listM<X, Y>()
        => ListMonad<X, Y>.instance;

    /// <summary>
    /// Instantiates the <see cref="IMonad"/> instance for a sequence
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    /// <returns></returns>
    public static ISeqMonad<X,Y> seqM<X, Y>()
        => SeqMonad<X, Y>.instance;

}
