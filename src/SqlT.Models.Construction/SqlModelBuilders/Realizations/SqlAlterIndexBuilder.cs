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


    /// <summary>
    /// Constructs <see cref="SqlAlterIndex"/> statements
    /// </summary>
    public sealed class SqlAlterIndexBuilder : SqlModelBuilder<SqlAlterIndex>
    {
        internal SqlAlterIndexBuilder(SqlTableName TableName, SqlIndexName IndexName, SqlAlterIndexAction AlterAction)
        {
            this.TableName = TableName;
            this.IndexName = IndexName;
            this.AlterAction = AlterAction;
        }

        SqlTableName TableName { get; }

        SqlIndexName IndexName { get; }

        SqlAlterIndexAction AlterAction { get; }

        public override SqlAlterIndex Complete()
            => new SqlAlterIndex(TableName, IndexName, AlterAction);
    }

}