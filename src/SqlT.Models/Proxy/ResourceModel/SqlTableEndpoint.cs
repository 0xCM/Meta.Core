//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
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


    public sealed class SqlTableEndpoint : SqlTabularEndpoint
    {
        public SqlTableEndpoint(N Node, SystemUri Resource, EndpointRole Role)
            : base(Node, Resource, typeof(SqlTableEndpoint), Role)
        {

        }

    }

    public class SqlTableEndpoint<T> : SqlTabularEndpoint<T,SqlTableName>
        where T : class, ISqlTableProxy, new()
    {
        public SqlTableEndpoint(N Node, SystemUri Resource, EndpointRole Role)
            : base(Node, Resource, Role)
        {

        }


        public override SqlTableName ResourceName
            => SqlTableName.Construct(true,NameComponents);

    }


}