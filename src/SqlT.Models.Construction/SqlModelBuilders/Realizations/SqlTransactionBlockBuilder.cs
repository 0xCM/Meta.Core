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
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;
    using static metacore;
    using static SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;
    

    using B = SqlTransactionBlockBuilder;


    public sealed class SqlTransactionBlockBuilder : SqlStatementBlockBuilder<B, transaction_block>
    {
        public SqlTransactionBlockBuilder() { }

        public SqlTransactionBlockBuilder(SqlTransactionName TransactionName)
            => TransactionName = TransactionName ?? SqlTransactionName.Empty;

        public SqlTransactionBlockBuilder(IEnumerable<sxc.statement> Statements, SqlTransactionName name = null)
            : this(name) => base.Statements.AddRange(Statements);

        SqlTransactionName TransactionName { get; }

        public override transaction_block Complete()
            => new transaction_block(Statements);
    }

}