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
    using Meta.Models;
    using SqlT.Core;

    using static SqlSyntax;
    using static metacore;
    using sxc = contracts;

    partial class sql
    {
        public static name_expression nx(IName name)
            => new name_expression(name);

        public static name_expression table_name(SqlIdentifier name)
           => new SqlTableName(name).AsNameExpression();

        public static name_expression table_name(string schema, string name)
           => new SqlTableName(schema, name).AsNameExpression();

        public static name_expression procedure_name(string declaring_schema, string name)
           => new SqlProcedureName(declaring_schema, name).AsNameExpression();

        public static name_expression procedure_name(string name)
           => new SqlProcedureName(name).AsNameExpression();

        public static name_expression index_name(string name)
            => new SqlIndexName(name).AsNameExpression();

        public static name_expression synonym_name(SqlIdentifier name)
            => new SqlSynonymName(name).AsNameExpression();

        public static name_expression synonym_name(string declaring_schema, string name)
            => new SqlSynonymName(declaring_schema, name).AsNameExpression();

        public static name_expression type_name(string declaring_schema, string name)
           => new SqlTypeName(declaring_schema, name).AsNameExpression();

        public static name_expression type_name(string name)
           => new SqlTypeName(name).AsNameExpression();

        public static name_expression column(string name, bool quoted = false)
            => new SqlColumnName(name, quoted).AsNameExpression();

        public static name_expression column(string name, string alias)
            => new column_alias(name, alias).AsNameExpression();

        public static name_expression column(SqlColumnName name, SqlAliasName alias)
            => new column_alias(name, alias).AsNameExpression();
    }
}