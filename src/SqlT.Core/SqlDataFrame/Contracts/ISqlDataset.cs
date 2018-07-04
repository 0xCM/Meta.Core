//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    public interface ISqlDataset
    {
        SqlDatasetDesignator Designator { get; }

        void Include(IEnumerable<ISqlTabularProxy> Source);

        ISqlDataFrame ToDataFrame();

        IEnumerable<ISqlTabularProxy> Records { get; }
    }

    public interface ISqlDataset<T> : ISqlDataset
        where T : class, ISqlTabularProxy, new()
    {
        void Include(IEnumerable<T> Source);

        void Include<S>(IEnumerable<S> Source, Func<S, T> F)
                where S : class, ISqlTableProxy, new();

        new IEnumerable<T> Records { get; }

        new ISqlDataFrame<T> ToDataFrame();


    }

}