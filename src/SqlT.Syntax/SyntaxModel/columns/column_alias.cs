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
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class column_alias : SqlName<column_alias>, sxc.column_name 
        {
            public static implicit operator column_alias((SqlColumnName, SqlAliasName) x)
                => new column_alias(x.Item1, x.Item2);

            public static implicit operator (SqlColumnName, SqlAliasName) (column_alias x)
                => (x.column, x.alias);
    
            public column_alias(SqlColumnName column, SqlAliasName alias)
            {
                this.column = column;
                this.alias = alias;
            }

            public column_alias()
            {
                column = SqlColumnName.Empty;
                alias = SqlAliasName.Empty;
            }

            public SqlColumnName column { get; }

            public SqlAliasName alias { get; }


            public override string ToString()
                => alias.IsEmpty()
                ? column.ToString() 
                : $"{column} as {alias}";
        }

    }

}