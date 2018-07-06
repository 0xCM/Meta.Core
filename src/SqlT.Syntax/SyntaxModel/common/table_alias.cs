//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    partial class SqlSyntax
    {
        public sealed class table_alias : Model<table_alias>
        {
            public static implicit operator table_alias((SqlTableName, SqlAliasName) x)
                => new table_alias(x.Item1, x.Item2);

            public static implicit operator (SqlTableName, SqlAliasName) (table_alias x)
                => (x.table, x.alias);

            public table_alias(SqlTableName column, SqlAliasName alias)
            {
                this.table = column;
                this.alias = alias;
            }

            public SqlTableName table { get; }

            public SqlAliasName alias { get; }

            public override string ToString()
                => alias.IsEmpty()
                ? table.ToString()
                : $"{table} as {alias}";
        }
    }
}