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

    public class SqlEndpoint : NodeEndpoint
    {
        protected SqlEndpoint(N Node, SystemUri Identifier, Type EndpointType, EndpointRole Role)
            : base(Node, Identifier, EndpointType, Role)
        {

            this.NameComponents = stream(stream(Node.NodeName), Identifier.Path.Components()).ToArray();
        }
       
        protected string[] NameComponents { get; }

    }



    public abstract class SqlEndpoint<E> : SqlEndpoint
        where E : class, ISqlProxy, new()
    {
        public SqlEndpoint(N Node, SystemUri Identifier, EndpointRole Role)
            : base(Node, Identifier, typeof(E), Role)
        {

        }

        
    }



}