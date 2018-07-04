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
    using N = SystemNode;


    using static metacore;

    class SqlResourceProvider : ApplicationService<SqlResourceProvider, ISqlResourceProvider>, ISqlResourceProvider
    {
        ISqlResourceLocator SqlResources { get; }

        public SqlResourceProvider(IApplicationContext C)
            : base(C)
        {
            SqlResources = C.SqlResources();        
        }

        public SqlTableEndpoint Table(N Host, SqlTableName TableName, EndpointRole Role)
            => SqlResources.TableEndpoint(Host,TableName, Role);

    }
}
