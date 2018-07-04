//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Concurrent;

    /// <summary>
    /// Defines helpers for accessing proxy metadata
    /// </summary>
    public static class SqlProxyMetadataProvider 
    {
        static ConcurrentDictionary<Assembly, SqlProxyMetadataIndex> MetadataIndexes
            = new ConcurrentDictionary<Assembly, SqlProxyMetadataIndex>();

        static readonly SqlProxyMetadataCache GlobalCache 
            = new SqlProxyMetadataCache();

        static IReadOnlyDictionary<Type, Type> IndexOperationProviders(this Assembly a)
           => (from x in a.GetTypes()
               let attrib = x.GetCustomAttribute<SqlProxyOperationProviderAttribute>()
               where attrib != null
               select Tuple.Create(attrib.ContractType, x)
              ).ToDictionary(y => y.Item1, y => y.Item2);

        static IEnumerable<SqlTableTypeProxyInfo> DescribeRecords(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.TableType).Select(x
                => x.ProxyType.DescribeTableType((SqlRecordAttribute)x.Attribute));

        static IEnumerable<SqlTabularProxyInfo> DescribeTableFunctionResults(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.TableFunctionResult).Select(x
                => x.ProxyType.DescribeTabularResult((SqlTableFunctionResultAttribute)x.Attribute));

        static IEnumerable<SqlTabularProxyInfo> DescribeNamedResults(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.NamedResult).Select(x =>
                x.ProxyType.DescribeTabularResult((SqlNamedResultAttribute)x.Attribute));

        static IEnumerable<SqlIndexProxyInfo> DescribeIndexes(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.Index).Select(x
                => x.ProxyType.DescribeIndex((SqlIndexAttribute)x.Attribute));

        static IEnumerable<SqlPrimaryKeyProxyInfo> DescribePrimaryKeys(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.PrimaryKey).Select(x
                => x.ProxyType.DescribePrimaryKey((SqlPrimaryKeyAttribute)x.Attribute));

        static IEnumerable<SqlViewProxyInfo> DescribeViews(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.View).Select(x
                => x.ProxyType.DescribeView((SqlViewAttribute)x.Attribute));

        static SqlSequenceName GetSqlObjectName(this SqlSequenceAttribute a)
            => new SqlSequenceName(a.SchemaName, a.ObjectName);

        static SqlSequenceProxyInfo DescribeSequence(this Type type, SqlSequenceAttribute a)
            => new SqlSequenceProxyInfo(type, a.GetSqlObjectName());

        static IEnumerable<SqlSequenceProxyInfo> DescribeSequences(this SqlProxyAttributionIndex idx)
            => idx.Find(SqlProxyKind.Sequence).Select(x
                => x.ProxyType.DescribeSequence((SqlSequenceAttribute)x.Attribute));

        static IEnumerable<SqlRoutineProxyInfo> DescribeRoutines
            (
                this SqlProxyAttributionIndex idx,
                IReadOnlyDictionary<Type, SqlTableTypeProxyInfo> recordsLU,
                IReadOnlyDictionary<Type, SqlTabularProxyInfo> tfResultsLU
            ) => idx.Find(SqlProxyKind.TableFuntion)
                              .Union(idx.Find(SqlProxyKind.Procedure))
                              .Union(idx.Find(SqlProxyKind.ScalarFunction))
                              .Select(x => x.ProxyType.DescribeRoutine(recordsLU, tfResultsLU));

        static IEnumerable<SqlTableProxyInfo> DescribeTables(this SqlProxyAttributionIndex idx,
                IReadOnlyDictionary<string, IReadOnlyList<SqlIndexProxyInfo>> indexLU,
                IReadOnlyDictionary<string, SqlPrimaryKeyProxyInfo> primaryKeyLU
            ) => idx.Find(SqlProxyKind.Table).Select(x
                    => x.ProxyType.DescribeTable((SqlTableAttribute)x.Attribute, indexLU, primaryKeyLU));


        static IReadOnlyList<T> ReadOnlyList<T>(this IEnumerable<T> source)
            => source.ToList();

        static IReadOnlyDictionary<SqlProxyKind, IReadOnlyList<SqlProxyInfo>> CreateMetadataDictionary(this SqlProxyAttributionIndex idx)
        {

            var dict = new Dictionary<SqlProxyKind, IReadOnlyList<SqlProxyInfo>>();

            var records = idx.DescribeRecords().ReadOnlyList();
            dict.Add(SqlProxyKind.TableType, records);

            var tfResults = idx.DescribeTableFunctionResults().ReadOnlyList();
            dict.Add(SqlProxyKind.TableFunctionResult, tfResults);

            var recordsLU = records.ToDictionary(x => (Type)x.ClrElement);
            var tfResultsLU = tfResults.ToDictionary(x => (Type)(x.ClrElement));
            var routines = idx.DescribeRoutines(recordsLU, tfResultsLU).ReadOnlyList();

            dict.Add(SqlProxyKind.TableFuntion, routines.OfType<SqlTableFunctionProxyInfo>().ReadOnlyList());
            dict.Add(SqlProxyKind.ScalarFunction, routines.OfType<SqlScalarFunctionProxyInfo>().ReadOnlyList());
            dict.Add(SqlProxyKind.Procedure, routines.OfType<SqlProcedureProxyInfo>().ReadOnlyList());

            var primaryKeys = idx.DescribePrimaryKeys().ReadOnlyList();
            dict.Add(SqlProxyKind.PrimaryKey, primaryKeys);

            var indexes = idx.DescribeIndexes().ReadOnlyList();
            dict.Add(SqlProxyKind.Index, indexes);

            var primaryKeysLU = primaryKeys.ToDictionary(x => x.TableName.FullName);
            var indexLU = indexes.GroupBy(x => x.TableName.FullName)
                                 .ToDictionary(x => x.Key, x => x.ReadOnlyList());

            dict.Add(SqlProxyKind.Table, idx.DescribeTables(indexLU, primaryKeysLU).ReadOnlyList());
            dict.Add(SqlProxyKind.View, idx.DescribeViews().ReadOnlyList());
            dict.Add(SqlProxyKind.NamedResult, idx.DescribeNamedResults().ReadOnlyList());
            dict.Add(SqlProxyKind.Sequence, idx.DescribeSequences().ReadOnlyList());

            return dict;
        }

        /// <summary>
        /// Calculates a metadata index from an assembly
        /// </summary>
        /// <param name="a">The assembly for which proxies will be searched</param>
        /// <returns></returns>
        /// <remarks>
        /// This is expensive and is called exactly once per app-domain/assembly via <see cref="SqlProxyBrokerFactory{T}"/> closures
        /// </remarks>
        static SqlProxyMetadataIndex IndexAssembly(Assembly a)
        {
            var attribIdx = new SqlProxyAttributionIndex(a);
            var metadataIdx = attribIdx.CreateMetadataDictionary();
            var opProviders = a.IndexOperationProviders();
            var cache = new SqlProxyMetadataCache(a, metadataIdx, opProviders);
            GlobalCache.Merge(cache);
            return new SqlProxyMetadataIndex(a, cache);
        }


        public static void RegisterSqlProxies(this Assembly a)
            => IndexAssembly(a);

       
        public static ISqlProxyMetadataIndex SqlProxyMetadataIndex(this AppDomain d)
            => GlobalCache;


        public static ISqlProxyMetadataIndex SqlProxyMetadataIndex(this Assembly a)
        {
            MetadataIndexes.GetOrAdd(a, _a => IndexAssembly(_a));
            return GlobalCache;
        }

        /// <summary>
        /// Gets the metadata index in which the <typeparamref name="TSpecimen"/> is described
        /// </summary>
        /// <typeparam name="TSpecimen">The example type used to find the right metadata </typeparam>
        /// <returns></returns>
        public static ISqlProxyMetadataIndex ProxyMetadata<TSpecimen>() where TSpecimen : ISqlProxy
            => typeof(TSpecimen).Assembly.SqlProxyMetadataIndex();

    }



}
