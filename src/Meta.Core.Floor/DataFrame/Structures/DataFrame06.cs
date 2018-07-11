//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using Modules;

    using static metacore;

    /// <summary>
    /// Defines a six-column data frame
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    public class DataFrame<X1, X2, X3, X4, X5, X6> : DataFrameRoot<DataFrame<X1, X2, X3, X4, X5, X6>>
    {
        /// <summary>
        /// Captures a sequence of records into a frame
        /// </summary>
        /// <param name="source">The record source</param>
        public static implicit operator DataFrame<X1, X2, X3, X4, X5, X6>(Seq<Record<X1, X2, X3, X4, X5, X6>> source)
            => new DataFrame<X1, X2, X3, X4, X5, X6>(source);

        /// <summary>
        /// Initializes an empty frame
        /// </summary>
        public DataFrame()
            => this.Rows = Seq<Record<X1, X2, X3, X4, X5, X6>>.Empty;

        /// <summary>
        /// Initializes a nonempty frame from a row container
        /// </summary>
        /// <param name="records">The data that will be encapsualted by the frame</param>
        /// <param name="schema">The frame schema, if any</param>
        public DataFrame(IContainer<Record<X1, X2, X3, X4, X5, X6>> records)
            => this.Rows = Index.make(records.Stream());

        /// <summary>
        /// The data encapsulated by the frame
        /// </summary>
        public Index<Record<X1, X2, X3, X4, X5, X6>> Rows { get; }

        /// <summary>
        /// Presents the frame data as a sequence of item arrays
        /// </summary>
        public override Seq<Index<object>> ItemArrays
            => from row in Rows select row.ItemArray;

        /// <summary>
        /// Constructs a six-column data frame from a sequence of item arrays
        /// </summary>
        /// <param name="data">The item arrays to transform</param>
        /// <param name="schema">The associated schema, if any</param>
        /// <returns></returns>
        public override DataFrame<X1, X2, X3, X4, X5, X6> Construct(IContainer<object[]> data)
            => map(data.AsSeq(), item => Record.make(tupleOf<X1, X2, X3, X4, X5, X6>(item)));

        /// <summary>
        /// Presents the first column of data as a sequence
        /// </summary>
        public Seq<X1> Col01
            => Rows.Select(r => r.x1);

        /// <summary>
        /// Presents the second column of data as a sequence
        /// </summary>
        public Seq<X2> Col02
            => Rows.Select(r => r.x2);

        /// <summary>
        /// Presents the third column of data as a sequence
        /// </summary>
        public Seq<X3> Col03
            => Rows.Select(r => r.x3);

        /// <summary>
        /// Presents the fourth column of data as a sequence
        /// </summary>
        public Seq<X4> Col04
            => Rows.Select(r => r.x4);

        /// <summary>
        /// Presents the fifth column of data as a sequence
        /// </summary>
        public Seq<X5> Col05
            => Rows.Select(r => r.x5);

        /// <summary>
        /// Presents the fifth column of data as a sequence
        /// </summary>
        public Seq<X6> Col06
            => Rows.Select(r => r.x6);

    }
}