//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;


public abstract class DataFrameRoot<F> : IDataFrameRoot
    where F : DataFrameRoot<F>, new()
{
    IDataFrame IDataFrameRoot.Construct(Seq<object[]> data, DataFrameSchema? schema)
        => Construct(data, schema);

    public abstract F Construct(Seq<object[]> data, DataFrameSchema? schema = null);

    protected DataFrameRoot(DataFrameSchema? schema = null)
    {
        this.Schema = schema.ValueOrNone();
    }

    public Option<DataFrameSchema> Schema { get; }

    public abstract Seq<Index<object>> ItemArrays { get; }

}


