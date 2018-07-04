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

    public class SqlDataset<T> : SqlDataset, ISqlDataset<T>
        where T: class, ISqlTabularProxy, new()
    {
        static readonly SqlTabularProxyInfo ProxyInfo = PXM.Tabular<T>();

        ConcurrentBag<T> rows { get; } 
            = new ConcurrentBag<T>();

        public SqlDataset(SqlDatasetDesignator Designator)
            : base(Designator)
        {

        }

        public SqlDataset(SqlDatasetDesignator Designator, IEnumerable<ISqlTabularProxy> Source)
            : base(Designator)
        {
            Include(Source);
        }

        protected sealed override void Include(IEnumerable<ISqlTabularProxy> Source)
            => Include(Source.Cast<T>());

        public void Include(IEnumerable<T> Source)
            => rows.AddRange(Source);

        public void Include<S>(IEnumerable<S> Source, Func<S, T> F)
            where S : class, ISqlTableProxy, new()
                => Source.AsParallel().ForAll(r => rows.Add(F(r)));

        public ISqlDataFrame<T> ToDataFrame()
            => new SqlDataFrame<T>(
                map(ProxyInfo.Columns, c => new SqlColumnIdentifier(c.ColumnName, c.Position)),
                rows);

        protected override ISqlDataFrame ToUntypedFrame()
            => ToDataFrame();

        protected override IEnumerable<ISqlTabularProxy> GetRecords()
            => Records;

        public IEnumerable<T> Records
            => rows;        
    }

}
