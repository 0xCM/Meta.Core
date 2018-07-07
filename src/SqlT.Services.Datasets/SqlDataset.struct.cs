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

    using Meta.Core;

    using static metacore;

    /// <summary>
    /// Embodies the concept of a typed dataset: an identified collection of tabular proxy values
    /// </summary>
    /// <typeparam name="T">The tabular proxy type</typeparam>
    public readonly struct SqlDataset<T> :  ISqlDataset<T>
        where T: class, ISqlTabularProxy, new()
    {
        static readonly SqlTabularProxyInfo ProxyInfo = PXM.Tabular<T>();

        public SqlDataset(Seq<T> Source, SqlDatasetDesignator Designator)
        {
            this.Rows = Source;
            this.Designator = Designator;
        }

        public Lst<T> Rows { get; }

        public SqlDatasetDesignator Designator { get; }

        Seq<ISqlTabularProxy> ISqlDataset.Rows
            => seq(Rows.Stream().Cast<ISqlTabularProxy>());
    }

}
