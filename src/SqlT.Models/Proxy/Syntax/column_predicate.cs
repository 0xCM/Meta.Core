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

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlT.Syntax.SqlSyntax;

    public partial class SqlProxySyntax
    {

        public class column_predicate<p> : sx.column_predicate, sxc.proxy_column_predicate<p>
            where p : ISqlTabularProxy
        {

            public column_predicate(sx.column_ref Column, IBooleanExpression Condition)
                : base(Column, Condition)
            {

            }
        }


        public class column_predicate<e, P> : column_predicate<P>
                , sxc.column_predicate
                , IBooleanExpression
                , sxc.proxy_column_predicate<P>
            where e : IBooleanExpression
            where P : ISqlTabularProxy
        {

            public column_predicate(sx.column_ref Column, IBooleanExpression Condition)
                : base(Column, Condition)
            {
                this.Condition = (e)Condition;
            }

            public e Condition { get; }
        }

    }

}