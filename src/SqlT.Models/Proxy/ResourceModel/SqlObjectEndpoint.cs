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


    public class SqlObjectEndpoint : SqlEndpoint
    {
        public SqlObjectEndpoint(N Node, SystemUri Identifier, Type EndpointType,  EndpointRole Role)
            : base(Node, Identifier, EndpointType, Role)
        {

        }


        public sxc.ISqlObjectName SubjectName { get; }

    }


    public abstract class SqlObjectEndpoint<E,R> : SqlEndpoint<E>
       where E : class, ISqlObjectProxy, new()
        where R : sxc.ISqlObjectName, new()
    {
        public SqlObjectEndpoint(N Node, SystemUri Identifier, EndpointRole Role)
            : base(Node, Identifier, Role)
        {
           
           
           

                
            
        }

        public abstract R ResourceName { get; }
      
    }




}