//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class transaction_block : statement_block<transaction_block>
        {
            public transaction_block()
            {

            }

            public transaction_block(Lst<sxc.statement> Statements, SqlTransactionName transaction_name = null)
                : base(Statements)
            {
                this.transaction_name = transaction_name ?? SqlTransactionName.Empty;

            }

            public transaction_block(Seq<sxc.statement> Statements, SqlTransactionName transaction_name = null)
                : base(Statements)
            {
                this.transaction_name = transaction_name ?? SqlTransactionName.Empty;

            }

            public SqlTransactionName transaction_name { get; }

        }
    }
}
