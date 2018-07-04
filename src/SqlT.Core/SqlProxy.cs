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
    using System.Linq.Expressions;
    using System.Reflection;
    using static metacore;


    public static class SqlProxy
    {

        public static Y TransferArray<X, Y>(this X src, Y dst)
            where X : ISqlTabularProxy
            where Y : ISqlTabularProxy
        {
            dst.SetItemArray(src.GetItemArray());
            return dst;
        }

        static ISqlProxyBrokerFactory BrokerFactory<P>()
            where P : ISqlProxy
                => typeof(P).Assembly.ProxyBrokerFactory();

        static ISqlProxyMetadataIndex MetadataIndex<P>()
            where P : ISqlProxy
            => BrokerFactory<P>().Metadata;

        public static SqlObjectProxyInfo DescribeObject<T>()
            where T : ISqlObjectProxy
            => MetadataIndex<T>().Describe(typeof(T));



        public static SqlProcedureProxyInfo DescribeProcedure<P>()
            where P : class, ISqlProcedureProxy, new()
            => MetadataIndex<P>().Procedure<P>();

    }

}