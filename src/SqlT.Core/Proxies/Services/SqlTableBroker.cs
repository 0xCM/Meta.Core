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



    public class SqlTableBroker<T> : SqlTabularBroker<T>, ISqlTableBroker<T>
       where T : class, ISqlTableProxy, new()
    {

        public SqlTableBroker(ISqlProxyBroker InnerBroker)
            : base(InnerBroker)
        {

            this.BrokeredTableName = Metadata.Table<T>().ObjectName;
        }

        public SqlTableName BrokeredTableName { get; }

        public SqlTableProxyInfo TableInfo
            => Metadata.Table<T>();


    }
}