//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;


    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Models;
    using System.Linq;
    using SqlT.Core;

    using static metacore;
    using static SqlSyntax;
    using static SqlFunctionTypes;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;
    using F = SqlFunctions;

    using static sql;

    public static class SyntaxExtensions
    {

        public static function_call<MIN> Min(this sxc.column_name column)
           => call(F.MIN, column.AsNameExpression());

        public static function_call<MAX> Max(this sxc.column_name column)
            => call(F.MAX, column.AsNameExpression());

        public static sx.next_value_for NextValueFor(this SqlSequenceName s)
            => new sx.next_value_for(s);

        public static IEnumerable<function_call<DATEPART>> SqlDateParts(this DateTime dt)
        {
            yield return datepart(sx.YEAR, dt);
            yield return datepart(sx.MONTH, dt);
            yield return datepart(sx.DAY, dt);
            yield return datepart(sx.HOUR, dt);
            yield return datepart(sx.MINUTE, dt);
            yield return datepart(sx.SECOND, dt);
            yield return datepart(sx.MILLISECOND, dt);
        }

        public static function_call<DATEPART> SqlDatePart(this Date date, kwt.YEAR year)
            => datepart(year, date);

        public static routine_argument_list ToRoutineArgList(this IEnumerable<ISyntaxExpression> expressions)
            => sql.args(expressions);

        public static sxc.order_by_expression OrderBy(this SqlColumnName c, kwt.ASC asc, string collation_name = null)
        => new order_by_column(new sort_column(c, asc), collation_name);

        public static sxc.order_by_expression OrderBy(this SqlColumnName c, kwt.DESC desc, string collation_name = null)
            => new order_by_column(new sort_column(c, desc), collation_name);

        public static sxc.order_by_expression OrderBy(this SqlColumnName c, string collation_name = null)
            => new order_by_column(new sort_column(c, sx.ASC), collation_name);

        public static string Describe(this sxc.function_call fc)
          => concat($"{fc.function_name}({fc.args})",
                  fc.options.Count() == 0
                      ? string.Empty
                      : $" with {fc.options}");

        public static (SqlColumnName Column, SqlAliasName Alias)[] ColumnAliasNames(this column_alias_list list)
            => mapi(list, (i, x) => (x.column, x.alias)).ToArray();

        public static SqlColumnName[] ColumnNames(this column_alias_list list)
            => array(list.Select(x => x.column));

        public static SqlColumnName[] ColumnNames(this column_list list)
            => list.ToArray(x => new SqlColumnName(x));

        public static sxc.operator_application Apply(this IOperator Operator, ISyntaxExpression[] Operands)
            => new operator_application(Operator, Operands);

        public static name_expression<n> AsNameExpression<n>(this n name)
            where n : SqlName<n>, new() => new name_expression<n>(name);

        public static name_expression AsNameExpression(this IName name)
            => new name_expression(name);

        public static name_expression AsNameExpression(this sxc.column_name name)
            => new name_expression(name);

        public static argument_list ToArgList(this IEnumerable<sxc.routine_argument> expressions)
            => new argument_list(expressions);

        public static column_alias_list ToColumnAliasList(this IEnumerable<column_alias> columns)
            => new column_alias_list(array(columns));

        public static sql_cmd_variable Set(this sql_cmd_variable var, string value)
            => new sql_cmd_variable(var.Name, value);

        public static scalar_value ToSqlLiteral(this CoreDataValue value)
            => new scalar_value(value);

        public static column_alias As(this SqlColumnName column, SqlAliasName alias)
            => (column, alias);

        public static alter_index DisableIndexOn(this SqlIndexName index_name, table_or_view_name parent_object)
            => sql.disable(INDEX, index_name, parent_object);

        public static alter_index RebuildIndexOn(this SqlIndexName index_name, table_or_view_name parent_object)
            => sql.rebuild(INDEX, index_name, parent_object);

        public static alter_database SetSingleUser(this SqlDatabaseName db)
            => sql.alter(DATABASE, new simple_database_name(db.UnquotedLocalName, db.quoted), SET, SINGLE_USER, WITH, ROLLBACK, IMMEDIATE);

        public static alter_database SetMultiUser(this SqlDatabaseName db)
            => sql.alter(DATABASE, new simple_database_name(db.UnquotedLocalName, db.quoted), SET, MULTI_USER);

        public static statement_block ToStatementList(this Meta.Core.Seq<sxc.statement> statements)
            => new statement_block(statements);

        public static bool IsMatch(this IKeyword kw, string candidiate)
            => String.Compare(kw.KeywordName, candidiate, true) == 0;

    }


}