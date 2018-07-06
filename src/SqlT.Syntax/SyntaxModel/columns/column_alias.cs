//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using static metacore;
    using sxc = contracts;

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