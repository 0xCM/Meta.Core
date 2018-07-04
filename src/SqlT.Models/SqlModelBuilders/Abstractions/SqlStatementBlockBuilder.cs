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
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlStatementBlockBuilder<B, M> : SqlModelBuilder<M>
        where M : IModel
        where B : SqlStatementBlockBuilder<B, M>, new()
    {

        public static B Build(params sxc.statement[] statements)
        {
            var builder = new B();
            builder.WithStatements(statements);
            return builder;
        }

        public static implicit operator SqlStatementBlockBuilder<B,M>(sxc.statement[] statements)
            => Build(statements);

        protected SqlStatementBlockBuilder()
            => Statements = MutableList.Create<sxc.statement>();

        protected SqlStatementBlockBuilder(IEnumerable<sxc.statement> Statements)
            => this.Statements = MutableList.FromItems(Statements);

        protected MutableList<sxc.statement> Statements { get; }

        public Builder<B> WithStatements(params sxc.statement[] Statements)
        {
            this.Statements.AddRange(Statements);
            return (B)this;
        }
    }
}