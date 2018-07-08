//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines a two-column data frame
    /// </summary>
    /// <typeparam name="X1">The first column's data type</typeparam>
    /// <typeparam name="X2">The second column's data type</typeparam>
    public class DataFrame<X1, X2> : DataFrameRoot<DataFrame<X1, X2>>
    {
        /// <summary>
        /// Initializes an empty frame
        /// </summary>
        public DataFrame()
            : base(null)
            => this.Rows = Seq<Record<X1, X2>>.Empty;

        /// <summary>
        /// Initializes a nonempty frame
        /// </summary>
        /// <param name="rows">The data that will be encapsualted by the frame</param>
        /// <param name="schema">The frame schema, if any</param>
        public DataFrame(Seq<Record<X1, X2>> Rows, DataFrameSchema? Schema = null)
            : base(Schema)
                => this.Rows = Rows;

        /// <summary>
        /// The data encapsulated by the frame
        /// </summary>
        public Index<Record<X1, X2>> Rows { get; }

        /// <summary>
        /// Presents the frame data as a sequence of item arrays
        /// </summary>
        public override Seq<Index<object>> ItemArrays
            => from row in Rows
               select row.ItemArray;

        /// <summary>
        /// Constructs a two-column data frame from a sequence of item arrays
        /// </summary>
        /// <param name="data">The item arrays to transform</param>
        /// <param name="schema">The associated schema, if any</param>
        /// <returns></returns>
        public override DataFrame<X1, X2> Construct(Seq<object[]> data, DataFrameSchema? schema = null)
            => DataFrame.make(map(data, item => Record.make(tupleOf<X1, X2>(item))),schema);

        /// <summary>
        /// Gets the first column of data
        /// </summary>
        public Seq<X1> Col01
            => Rows.Select(r => r.x1);

        /// <summary>
        /// Gets the second column of data
        /// </summary>
        public Seq<X2> Col02
            => Rows.Select(r => r.x2);


    }
}