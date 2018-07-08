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
    /// Describes the shape of a <see cref="IDataFrame"/>
    /// </summary>
    public readonly struct DataFrameSchema
    {
        /// <summary>
        /// Specifies the canonical empty schema
        /// </summary>
        public static readonly DataFrameSchema Empty
            = new DataFrameSchema(Lst<DataFrameColumnInfo>.Empty);

        /// <summary>
        /// Constructs a schema from an explicit list of clumn types
        /// </summary>
        /// <param name="coltypes">The column types upon wich to base the list</param>
        /// <returns></returns>
        public static DataFrameSchema FromColumnTypes(Lst<Type> coltypes)
            => new DataFrameSchema(mapi(coltypes,
                (i, t) => new DataFrameColumnInfo($"Col0{i}", i, coltypes[i])));


        public DataFrameSchema(Lst<DataFrameColumnInfo> Columns)
            => this.Columns = Columns;

        /// <summary>
        /// The columns defined by the frame
        /// </summary>
        public Lst<DataFrameColumnInfo> Columns { get; }

    }
}