//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using N = SystemNode;

    using Meta.Core;

    public interface ISqlProxyChannel : ISqlChannel<ISqlProxyBroker>
    {
        WorkFlowed<int> Overwrite<T>(int? BatchSize = null, SqlPurgeOption? PurgeOption = null)
           where T : class, ISqlTableProxy, new();

        WorkFlowed<int> Append<T>(int? BatchSize = null)
           where T : class, ISqlTableProxy, new();

        WorkFlowed<int> Overwrite<X, Y>(int? BatchSize = null, SqlPurgeOption? PurgeOption = null)
               where X : class, ISqlTableProxy, new()
                where Y : class, ISqlTableProxy, new();

        WorkFlowed<int> Append<X, Y>(int? BatchSize = null)
               where X : class, ISqlTableProxy, new()
                where Y : class, ISqlTableProxy, new();

        WorkFlowed<int> Purge<T>(SqlPurgeOption? option = null)
                  where T : class, ISqlTableProxy, new();

        WorkFlowed<int> Transfer<T>(int? BatchSize)
            where T : class, ISqlTabularProxy, new();

        WorkFlowed<int> Transfer<T>(ISqlFilter<T> Filter, int? BatchSize)
            where T : class, ISqlTabularProxy, new();

        WorkFlowed<int> Push<T>(IEnumerable<T> Data, int? BatchSize)
            where T : class, ISqlTabularProxy, new();

        IEnumerable<R> Pull<F, R>(F f)
                    where F : class, ISqlTableFunctionProxy<F, R>, new()
                    where R : class, ISqlTabularProxy, new();

        IEnumerable<T> Pull<T>()
            where T : class, ISqlTabularProxy, new();
    }

}