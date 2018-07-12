//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;

    public static class SqlDatasetX
    {
        public static ISqlDataFrame<T> ToDataFrame<T>(this IEnumerable<T> proxies)
           where T : class, ISqlTabularProxy, new()
               => new SqlDataFrame<T>(
               map(SqlProxyMetadataProvider.ProxyMetadata<T>().Tabular<T>().Columns,
                   c => new SqlColumnIdentifier(c.ColumnName, c.Position)), proxies);

        public static Option<IReadOnlyList<T>> Slice<T>(this ISqlDataFrame F, string ColumnName)
            where T : class, ISqlTabularProxy, new()
        {
            var col = F.Columns.FirstOrDefault(c => c.ColumnName == ColumnName);
            var colidx = col != null ? col.ColumnPosition : null;
            if (colidx == null)
                return none<IReadOnlyList<T>>(AppMessage.Error($"The {ColumnName} was not found"));
            else
                return F.Slice<T>(colidx.Value);
        }

        public static Option<IReadOnlyList<T>> Slice<T>(this ISqlDataFrame F, int ColumnIndex)
            where T : class, ISqlTabularProxy, new()
        {
            var slice = new T[F.Rows.Count];
            var rowidx = 0;
            foreach (var row in F.Rows)
            {
                try
                {
                    var val = row[ColumnIndex];
                    slice[rowidx++] = (val != null && !(val is DBNull)) ? (T)val : default(T);
                }
                catch (Exception)
                {
                    return none<IReadOnlyList<T>>(AppMessage.Error($"Could not cast the value {row[ColumnIndex]} to a value of type {typeof(T).Name}"));
                }
            }
            return slice;
        }

    }

}