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
    /// Defines a four-column data frame
    /// </summary>
    /// <typeparam name="X1">The first column's data type</typeparam>
    /// <typeparam name="X2">The second column's data type</typeparam>
    /// <typeparam name="X3">The third column's data type</typeparam>
    /// <typeparam name="X4">The fourth column's data type</typeparam>
    public class DataFrame<X1, X2, X3, X4> : DataFrameRoot<DataFrame<X1, X2, X3, X4>>
    {
        /// <summary>
        /// Initializes an empty frame
        /// </summary>
        public DataFrame()
            : base(null)
            => this.Rows = Seq<Record<X1, X2, X3, X4>>.Empty;

        /// <summary>
        /// Initializes a nonempty frame
        /// </summary>
        /// <param name="rows">The data that will be encapsualted by the frame</param>
        /// <param name="schema">The frame schema, if any</param>
        public DataFrame(Seq<Record<X1, X2, X3, X4>> DataRows, DataFrameSchema? Description = null)
            : base(Description)
        {
            this.Rows = DataRows;
        }

        /// <summary>
        /// The data encapsulated by the frame
        /// </summary>
        public Index<Record<X1, X2, X3, X4>> Rows { get; }

        /// <summary>
        /// Presents the frame data as a sequence of item arrays
        /// </summary>
        public override Seq<Index<object>> ItemArrays
            => from row in Rows
               select row.ItemArray;

        /// <summary>
        /// Constructs a four-column data frame from a sequence of item arrays
        /// </summary>
        /// <param name="data">The item arrays to transform</param>
        /// <param name="schema">The associated schema, if any</param>
        /// <returns></returns>
        public override DataFrame<X1, X2, X3, X4> Construct(Seq<object[]> data, DataFrameSchema? schema = null)
            => DataFrame.make(map(data, item => Record.make(tupleOf<X1, X2, X3, X4>(item) )), schema);

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
    }
}