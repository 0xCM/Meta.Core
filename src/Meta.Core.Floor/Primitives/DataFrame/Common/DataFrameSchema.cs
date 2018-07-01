//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;

/// <summary>
/// Describes the shape of a <see cref="IDataFrame"/>
/// </summary>
public class DataFrameSchema
{
    /// <summary>
    /// Specifies the canonical empty schema
    /// </summary>
    public static readonly DataFrameSchema Empty 
        = new DataFrameSchema(string.Empty, stream<DataFrameColumn>());

    public static DataFrameSchema Define(Type t, ICoreTypeProvider provider)
        => new DataFrameSchema(t.Name,
                mapi(from p in ClrType.Get(t).PublicInstanceProperties
                     where not(p.PropertyType.Realizes<IEnumerable>())
                     select p, (i, p) => new DataFrameColumn(p.Name, i, provider.GetPropertyType(p))));

    public DataFrameSchema(string Name, IEnumerable<DataFrameColumn> Columns)
    {
        this.Name = Name;
        this.Columns = Columns.ToList();
    }

    /// <summary>
    /// The name of the data frame
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The columns defined by the frame
    /// </summary>
    public IReadOnlyList<DataFrameColumn> Columns { get; }

}
