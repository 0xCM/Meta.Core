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
    using SqlT.Core;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public sealed class transaction_block : statement_block<transaction_block>
        {
            public transaction_block()
            {

            }

            public transaction_block(IEnumerable<sxc.statement> Statements, SqlTransactionName transaction_name = null)
                : base(Statements)
            {
                this.transaction_name = transaction_name ?? SqlTransactionName.Empty;

            }

            public SqlTransactionName transaction_name { get; }

        }
    }
}
