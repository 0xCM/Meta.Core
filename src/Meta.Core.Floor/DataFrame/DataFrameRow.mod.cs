//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

/// <summary>
/// Represents a row of data in a <see cref="IDataFrame"/>
/// </summary>
public class DataFrameRow : IDataFrameRow
{
    public static readonly DataFrameRow Empty 
        = new DataFrameRow(DataFrameSchema.Empty);

    public static DataFrameRow<X1> make<X1>(X1 x1, DataFrameSchema? schema = null)
        => new DataFrameRow<X1>(x1, schema);

    public static DataFrameRow<X1, X2> make<X1, X2>(X1 x1, X2 x2, DataFrameSchema? schema = null)
        => new DataFrameRow<X1, X2>(x1, x2, schema);

    public static DataFrameRow<X1, X2> make<X1, X2>((X1 x1, X2 x2) x, DataFrameSchema? schema = null)
            => new DataFrameRow<X1, X2>(x, schema);

    public static DataFrameRow<X1, X2, X3> make<X1, X2, X3>(X1 x1, X2 x2, X3 x3, DataFrameSchema? schema = null)
            => new DataFrameRow<X1, X2, X3>(x1, x2, x3, schema);

    /// <summary>
    /// Constructs a 3-column row from a 3-tuple
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x">The tuple value</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3> make<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x, DataFrameSchema? schema = null)
            => new DataFrameRow<X1, X2, X3>(x, schema);

    /// <summary>
    /// Constructs a 4-column row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x1">The value in cell 01</param>
    /// <param name="x2">The value in cell 02</param>
    /// <param name="x3">The value in cell 03</param>
    /// <param name="x4">The value in cell 04</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4> make<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4, DataFrameSchema? Schema = null)
            => new DataFrameRow<X1, X2, X3, X4>(x1, x2, x3, x4, Schema);

    /// <summary>
    /// Constructs a 4-column row from a 4-tuple
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x">The tuple value</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4> make<X1, X2, X3, X4>((X1 x1, X2 x2, X3 x3, X4 x4) x, DataFrameSchema? Schema = null)
            => new DataFrameRow<X1, X2, X3, X4>(x.x1, x.x2, x.x3, x.x4, Schema);

    /// <summary>
    /// Constructs a 5-column row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x1">The value in cell 01</param>
    /// <param name="x2">The value in cell 02</param>
    /// <param name="x3">The value in cell 03</param>
    /// <param name="x4">The value in cell 04</param>
    /// <param name="x5">The value in cell 05</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, DataFrameSchema? Schema = null)
            => new DataFrameRow<X1, X2, X3, X4, X5>(x1, x2, x3, x4, x5, Schema);

    /// <summary>
    /// Constructs a 5-column row from a 5-tuple
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <param name="Schema">The associated schema</param>
    /// <param name="x">The tuple value</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x, DataFrameSchema? Schema = null)
            => new DataFrameRow<X1, X2, X3, X4, X5>(x.x1, x.x2, x.x3, x.x4, x.x5, Schema);

    /// <summary>
    /// Constructs a six-column row from a tuple
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    /// <typeparam name="X4">The data type of the fourth column</typeparam>
    /// <typeparam name="X5">The data type of the fifth column</typeparam>
    /// <typeparam name="X6">The data type of the sixth column</typeparam>
    /// <param name="schema">The associated schema</param>
    /// <param name="x1">The value in cell 01</param>
    /// <param name="x2">The value in cell 02</param>
    /// <param name="x3">The value in cell 03</param>
    /// <param name="x4">The value in cell 04</param>
    /// <param name="x5">The value in cell 05</param>
    /// <param name="x6">The value in cell 06</param>
    /// <returns></returns>
    public static DataFrameRow<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>
        (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, DataFrameSchema? schema = null)
                => new DataFrameRow<X1, X2, X3, X4, X5, X6>(x1, x2, x3, x4, x5, x6, schema);

    public DataFrameRow(DataFrameSchema Schema, object[] ItemArray)
    {
        this.Schema = Schema;
        this.ItemArray = ItemArray;
    }

    protected DataFrameRow(DataFrameSchema? Schema)
    {
        this.ItemArray = new object[] { };
        this.Schema = Schema ?? DataFrameSchema.Empty;
    }

    /// <summary>
    /// The schema of the defining frame
    /// </summary>
    public DataFrameSchema Schema { get; }


    public virtual Index<object> ItemArray { get; }


}