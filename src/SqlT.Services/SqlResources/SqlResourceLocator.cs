//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using Meta.Core.Resources;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using N = SystemNode;
   

    class SqlResourceLocator : ApplicationService<SqlResourceLocator, ISqlResourceLocator>, ISqlResourceLocator
    {              

        public SqlResourceLocator(IApplicationContext C)
            : base(C)
        {

           
        }

        static SqlTableName TableName<T>()
            where T : class, ISqlTableProxy, new()
            => SqlProxyMetadataProvider.ProxyMetadata<T>().Table<T>().ObjectName;

        static SystemUri SysUri(N Host, SqlTableName Table)
            => new Uri($"table://{Host}/{Table.DatabaseNamePart}/{Table.SchemaNamePart}/{Table.UnquotedLocalName}").ToSystemUri();

        public SqlTableEndpoint<T> TableEndpoint<T>(N Host, EndpointRole Role)
            where T : class, ISqlTableProxy, new()
        {

            return new SqlTableEndpoint<T>(Host, SysUri(Host, TableName<T>()), Role);                

        }

        public SqlTableEndpoint TableEndpoint(N Host, SqlTableName Table, EndpointRole Role)
        {
            return new SqlTableEndpoint(Host, SysUri(Host, Table), Role);

        }


    }



}
