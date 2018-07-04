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
    using SqlT.Core;

    using static SqlSyntax;
    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    public static partial class sql
    {
        /// <summary>
        /// Defines a variable reference to an existing variable
        /// </summary>
        /// <param name="name">The variable name</param>
        public static variable_reference sqlvar(string name)
            => name;

        public static column_alias alias(SqlColumnName column, SqlAliasName alias)
           => new column_alias(column, alias);

        public static alias_expression<e> alias<e>(e expression, string name)
            where e : ISyntaxExpression => new alias_expression<e>(expression, name);

        public static SqlAliasName alias(string text, bool quoted = false)
            => new SqlAliasName(text, quoted);

        public static SqlIdentifier identifier(string text, bool quoted = false)
          => new SqlIdentifier(text, quoted);

        public static IBooleanExpression<e> @bool<o, e>(o op, e operand)
           where o : IBooleanOperator
           where e : ISyntaxExpression
           => new boolean_operator_application<o, e>(op, operand);

        public static IBooleanExpression<l, r> @bool<O, l, r>(O op, l left, r right)
            where O : IBooleanOperator
            where l : ISyntaxExpression
            where r : ISyntaxExpression
                => new boolean_operator_application<O, l, r>(op, left, right);

        public static next_value_for next(kwt.VALUE VALUE, kwt.FOR @for, sxc.sequence_name sequence)
            => new next_value_for(sequence);

        public static file_size file_size(integer_literal value, file_size_unit? unit = null)
            => new file_size(value, unit);

        public static file_growth file_growth(integer_literal value, file_growth_unit? unit = null)
            => new file_growth(value, unit);

        public static string_expression textx(string text)
            => new string_expression(text);

        public static ISyntaxExpression nullcol(SqlAliasName alias = null)
            => sql.alias(literal(DBNull.Value), alias ?? new SqlAliasName(SqlColumnName.Random));


    }

}