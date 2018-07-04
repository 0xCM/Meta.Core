//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using sxc = SqlT.Syntax.contracts;

    public class SqlTabularBroker<T> : ISqlTabularBroker<T>
       where T : class, ISqlTabularProxy, new()
    {
            
        public ISqlProxyBroker InnerBroker { get; }

        public SqlTabularBroker(ISqlProxyBroker InnerBroker)
        {
            this.InnerBroker = InnerBroker;
            this.BrokeredObjectName = Metadata.Tabular<T>().ObjectName;
        }

        public sxc.tabular_name BrokeredObjectName { get; }
            
        public SqlTabularProxyInfo TabularInfo
            => Metadata.Tabular<T>();

        public SqlConnectionString ConnectionString
            => InnerBroker.ConnectionString;

        public ISqlProxyMetadataIndex Metadata
            => InnerBroker.Metadata;

        public IEnumerable<T> Stream(string sql)
            => InnerBroker.Stream<T>(sql);

        public Option<int> Stream(string sql, Action<T> receiver)
            => InnerBroker.Stream(sql, receiver).ToOption();

        public Option<IReadOnlyList<T>> Get(SqlDatabaseName db = null)
            => InnerBroker.Get<T>(db).ToOption();

        public Option<IReadOnlyList<T>> Get(string sql)
            => InnerBroker.Get<T>(sql).ToOption();

        public Option<IReadOnlyList<C>> GetColumn<C>(string sql, Expression<Func<T, C>> selector)
            => InnerBroker.GetColumn(sql, selector);

        public Option<int> Save(IEnumerable<T> items, int? BatchSize = null)
        {
            var bs = BatchSize ?? 5000;
            var count = 0;
            var records = new List<T>(bs);
            foreach(var item in items)
            {
                records.Add(item);
                count++;
                if (count % BatchSize == 0)
                {
                    var saved = InnerBroker.Save(records);
                    if (!saved)
                        return saved;

                    records.Clear();
                }                
            }
            if (records.Count != 0)
            {
                var saved = InnerBroker.Save(records);
                if (!saved)
                    return saved;
            }
            return count;            
        }

        public override string ToString()
            => InnerBroker.ToString();
    }

}