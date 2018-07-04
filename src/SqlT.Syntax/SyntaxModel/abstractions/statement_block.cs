//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using Meta.Models;

    using static metacore;

    using sxc = contracts;
    using sx = SqlSyntax;
    using static SqlSyntax;

    public abstract class statement_block<B> : Model<B>, sxc.statement_list
        where B : statement_block<B>, new()
    {

        public static B define(params sxc.statement[] statements)
        {
            var block = new B();
            block.statements = statements;
            return block;
        }

        protected statement_block()
        {
            this.statements = array<sxc.statement>();
            this.delimiter = eol();
        }

        protected statement_block(statement_list statements)
            => this.statements = statements;

        protected statement_block(IEnumerable<sxc.statement> statements)
            : this(statements.to_statement_list())
        {
            this.statements = array(statements);
            this.delimiter = eol();
        }

        public statement_list statements { get; private set; }

        public string delimiter { get; private set; }

        IEnumerator<sxc.statement> IEnumerable<sxc.statement>.GetEnumerator()
            => (statements as sxc.statement_list).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => (statements as sxc.statement_list).GetEnumerator();

        IModelList<sxc.statement> IModelList<sxc.statement>.prepend(params sxc.statement[] statements)
            => SyntaxList.create(statements.Concat(this.statements));

        IModelList<sxc.statement> IModelList<sxc.statement>.append(params sxc.statement[] statements)
            => SyntaxList.create(this.statements.Concat(statements));
    }
}
