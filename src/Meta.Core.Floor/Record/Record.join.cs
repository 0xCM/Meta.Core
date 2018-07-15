//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static metacore;

    /// <summary>
    /// Defines operations on the Record type family
    /// </summary>
    partial class Record
    {

        /// <summary>
        /// Constructs a sequence of 2-records from 2 input sequences
        /// </summary>
        /// <typeparam name="X1">The item type of the first sequence</typeparam>
        /// <typeparam name="X2">The item type of the second sequence</typeparam>
        /// <param name="s1">The values from which the first column will be constructed</param>
        /// <param name="s2">The values from which the second column will be constructed</param>
        /// <returns></returns>
        public static Seq<Record<X1, X2>> join<X1, X2>(Seq<X1> s1, Seq<X2> s2)
            => from pair in Modules.Seq.zip(s1, s2)
               select record(pair.x1, pair.x2);

        /// <summary>
        /// Constructs a sequence of 3-records from 3 input sequences
        /// </summary>
        /// <typeparam name="X1">The item type of the first sequence</typeparam>
        /// <typeparam name="X2">The item type of the second sequence</typeparam>
        /// <typeparam name="X3">The item type of the third sequence</typeparam>
        /// <param name="s1">The values from which the first column will be constructed</param>
        /// <param name="s2">The values from which the second column will be constructed</param>
        /// <param name="s3">The values from which the third column will be constructed</param>
        /// <returns></returns>
        public static Seq<Record<X1, X2, X3>> join<X1, X2, X3>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3)
            => from tuple in zip(s1, s2, s3)
               select record(tuple.x1, tuple.x2, tuple.x3);

        /// <summary>
        /// Constructs a sequence of 4-records from 4 input sequences
        /// </summary>
        /// <typeparam name="X1">The item type of the first sequence</typeparam>
        /// <typeparam name="X2">The item type of the second sequence</typeparam>
        /// <typeparam name="X3">The item type of the third sequence</typeparam>
        /// <typeparam name="X4">The item type of the forth sequence</typeparam>
        /// <param name="s1">The values from which the first column will be constructed</param>
        /// <param name="s2">The values from which the second column will be constructed</param>
        /// <param name="s3">The values from which the third column will be constructed</param>
        /// <param name="s4">The values from which the fourth column will be constructed</param>
        /// <returns></returns>
        public static Seq<Record<X1, X2, X3, X4>> join<X1, X2, X3, X4>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4)
            => from tuple in zip(s1, s2, s3, s4)
               select record(tuple.x1, tuple.x2, tuple.x3, tuple.x4);

        /// <summary>
        /// Constructs a sequence of 4-records from 4 input sequences
        /// </summary>
        /// <typeparam name="X1">The item type of the first sequence</typeparam>
        /// <typeparam name="X2">The item type of the second sequence</typeparam>
        /// <typeparam name="X3">The item type of the third sequence</typeparam>
        /// <typeparam name="X4">The item type of the forth sequence</typeparam>
        /// <typeparam name="X5">The item type of the fifth sequence</typeparam>
        /// <param name="s1">The values from which the first column will be constructed</param>
        /// <param name="s2">The values from which the second column will be constructed</param>
        /// <param name="s3">The values from which the third column will be constructed</param>
        /// <param name="s4">The values from which the fourth column will be constructed</param>
        /// <param name="s5">The values from which the fifth column will be constructed</param>
        /// <returns></returns>
        public static Seq<Record<X1, X2, X3, X4, X5>> join<X1, X2, X3, X4, X5>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4, Seq<X5> s5)
            => from tuple in zip(s1, s2, s3, s4, s5)
               select record(tuple.x1, tuple.x2, tuple.x3, tuple.x4, tuple.x5);

    }

}