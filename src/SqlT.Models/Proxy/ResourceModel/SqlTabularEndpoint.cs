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

    using sxc = SqlT.Syntax.contracts;

    public class SqlTabularEndpoint : SqlObjectEndpoint
    {
        public SqlTabularEndpoint(N Node, SystemUri Identifier, Type EndpointType, EndpointRole Role)
            : base(Node, Identifier, EndpointType, Role)
        {

        }
    }



    public abstract class SqlTabularEndpoint<T,R> : SqlObjectEndpoint<T, R>
        where T : class, ISqlTabularProxy, new()
        where R : sxc.tabular_name, new()

    {
        public SqlTabularEndpoint(N Node, SystemUri Location, EndpointRole Role)
            : base(Node, new SystemUri(Location), Role)
        {

        }

    }

}