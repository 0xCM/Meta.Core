//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

using static metacore;

public abstract class DataFrameRowRoot<R> : IDataFrameRow
    where R : DataFrameRowRoot<R>, new()
{
    public static readonly R Empty = new R();
    public static readonly DataFrameSchema DefaultSchema
        = DataFrameSchema.FromColumnTypes(from t in Empty.ColumnTypes select t.ReflectedElement);

    protected DataFrameRowRoot(bool empty, DataFrameSchema? schema = null)
    {
        this.IsEmpty = empty;
        this.Schema = schema ?? DefaultSchema;
    }

    public bool IsEmpty { get; }
        = true;

    /// <summary>
    /// The schema of the defining frame
    /// </summary>
    public DataFrameSchema Schema { get; }

    public virtual Index<object> ItemArray { get; }

    protected abstract Lst<ClrType> ColumnTypes { get; }

}
