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

    public abstract class SqlDataset : ISqlDataset
    {

        public SqlDataset(SqlDatasetDesignator Designator)
        {
            this.Designator = Designator;
        }

        public SqlDatasetDesignator Designator { get; }

        protected abstract ISqlDataFrame ToUntypedFrame();

        protected abstract IEnumerable<ISqlTabularProxy> GetRecords();

        protected abstract void Include(IEnumerable<ISqlTabularProxy> Source);

        ISqlDataFrame ISqlDataset.ToDataFrame()
            => ToUntypedFrame();

        IEnumerable<ISqlTabularProxy> ISqlDataset.Records
            => GetRecords();

        void ISqlDataset.Include(IEnumerable<ISqlTabularProxy> Source)
            => Include(Source);

        public override string ToString()
            => Designator.ToString();

    }

    
}