//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Zips the first sequence with the second into a sequence of 2-tuples
    /// </summary>
    /// <typeparam name="X">The item tyep of the first sequence</typeparam>
    /// <typeparam name="Y">The item type of the second sequence</typeparam>
    /// <param name="sx">The first sequence</param>
    /// <param name="sy">The second sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2)> zip<X1, X2>(Seq<X1> sx, Seq<X2> sy)
        => Seq.zip(sx, sy);

    /// <summary>
    /// Zips three sequences into a sequence of 3-tuples
    /// </summary>
    /// <typeparam name="X1">The first sequence item type</typeparam>
    /// <typeparam name="X2">The second sequence item type</typeparam>
    /// <typeparam name="X3">The third sequence item type</typeparam>
    /// <param name="s1">The firt sequence</param>
    /// <param name="s2">The second sequnce</param>
    /// <param name="s3">The third sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3)> zip<X1, X2, X3>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3)
        => zip(zip(s1, s2), s3, (head, x3) => (head.x1, head.x2, x3));

    /// <summary>
    /// Zips four sequences into a sequence of 4-tuples
    /// </summary>
    /// <typeparam name="X1">The first sequence item type</typeparam>
    /// <typeparam name="X2">The second sequence item type</typeparam>
    /// <typeparam name="X3">The third sequence item type</typeparam>
    /// <typeparam name="X4">The fourth sequence item type</typeparam>
    /// <param name="s1">The firt sequence</param>
    /// <param name="s2">The second sequnce</param>
    /// <param name="s3">The third sequence</param>
    /// <param name="s4">The fourth sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3, X4 x4)> zip<X1, X2, X3, X4>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4)
        => zip(zip(s1, s2, s3), s4, (head, x4) => (head.x1, head.x2, head.x3, x4));

    /// <summary>
    /// Zips five sequences into a sequence of 5-tuples
    /// </summary>
    /// <typeparam name="X1">The first sequence item type</typeparam>
    /// <typeparam name="X2">The second sequence item type</typeparam>
    /// <typeparam name="X3">The third sequence item type</typeparam>
    /// <typeparam name="X4">The fourth sequence item type</typeparam>
    /// <typeparam name="X5">The fifth sequence item type</typeparam>
    /// <param name="s1">The firt sequence</param>
    /// <param name="s2">The second sequnce</param>
    /// <param name="s3">The third sequence</param>
    /// <param name="s4">The fourth sequence</param>
    /// <param name="s5">The fifth sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)> zip<X1, X2, X3, X4, X5>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4, Seq<X5> s5)
        => zip(zip(s1, s2, s3, s4), s5, (head, x5) => (head.x1, head.x2, head.x3, head.x4, x5));

}