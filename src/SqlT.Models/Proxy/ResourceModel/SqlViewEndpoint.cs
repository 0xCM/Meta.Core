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


    public sealed class SqlViewEndpoint : SqlTabularEndpoint
    {
        public SqlViewEndpoint(N Node, SystemUri Identifier, EndpointRole Role)
            : base(Node, Identifier, typeof(SqlViewEndpoint), Role)
        {

        }

    }

    public class SqlViewEndpoint<T> : SqlTabularEndpoint<T,SqlViewName>
        where T : class, ISqlViewProxy, new()
    {
        public SqlViewEndpoint(N Node, Uri Location, EndpointRole Role)
            : base(Node, new SystemUri(Location), Role)
        {

        }

        public override SqlViewName ResourceName
            => SqlViewName.Construct(true, NameComponents);
    }


}