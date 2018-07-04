//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;
    using static SqlT.Syntax.SqlSyntax;

    partial class SqlProxySyntax
    {

        public class procedure<P> : SyntaxExpression<procedure<P>> , sxc.procedure 
            where P : ISqlProcedureProxy
        {
            public procedure(P proxy)
            {
                this.proxy = proxy;
                this.Name = SqlProxy.DescribeObject<P>().ObjectName.AsProcedureName();
            }

            public P proxy { get; }

            public SqlProcedureName Name { get; }

            public IName ElementName
                => Name;
        }


        public class procedure<P, R> : SyntaxExpression<procedure<P, R>>, sxc.procedure<R>
            where P : ISqlProcedureProxy
            where R : class, ISqlTabularProxy, new()
        {
            public procedure(P proxy)
            {
                this.proxy = proxy;
                this.Name = SqlProxy.DescribeObject<P>().ObjectName.AsProcedureName();
            }

            public P proxy { get; }

            public SqlProcedureName Name { get; }

            public IName ElementName
                => Name;
        }



    }

}