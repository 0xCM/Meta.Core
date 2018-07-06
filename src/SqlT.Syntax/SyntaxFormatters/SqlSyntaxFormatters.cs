//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;

    using static metacore;
    using static SqlSyntax;
    using static sql;

    using sxc = contracts;
    using op = SqlSyntax.sqlops;

    public static class SqlSyntaxFormatters
    {
        static readonly string commas 
            = comma() + space();

        static string paren(string enclosed)
            => "(" + enclosed + ")";

        static string FormatSyntax(string delimiter, IEnumerable<IModel> models)
            => string.Join(delimiter, map(models.Normalize(), item => item.FormatDynamic()));

        static string FormatSyntax(string delimiter, params IModel[] models)
            => string.Join(delimiter, map(models.Normalize(), item => item.FormatDynamic()));

        static string FormatSyntax(this sxc.keyword_list m, string sep = " ")
            => string.Join(sep, $"{map(m, kw => kw.FormatSyntax())}");

        public static string FormatSyntax(this sxc.augmentation augmentation)
        {
            var sb = new StringBuilder();
            sb.AppendLine(augmentation.subject.FormatDynamic());
            sb.AppendLine(GO);
            foreach (var addition in augmentation.additions)
                sb.AppendLine(addition.FormatDynamic());

            var text = sb.ToString();
            return text;
        }

        public static string FormatSyntax(this sxc.variable m)
            => $"@{m.name}";

        public static string FormatSyntax(this ISqlIdentifier m)
            => $"{m}";

        public static string FormatSyntax(this SqlColumnName n)
            => $"{n}";
        public static string FormatSyntax(this SqlVariableName n)
            => $"{n}";

        public static string FormatSyntax(this IDiscriminatedUnion m)
            => m.selected_value.FormatDynamic();

        public static string FormatSyntax(this ISyntaxExpression m)
            => $"{m}";

        public static string FormatSyntax(this IBooleanExpression e)
            => $"{e}";

        public static string FormatSyntax(this sxc.routine_argument m)
            => m.argument_value.FormatSyntax();

        public static string FormatSyntax(this sxc.routine_argument_value m)
            => m.FormatDynamic();

        public static string FormatSyntax(this SqlName name)
        {
            var nonemptyComponents = list(name.NameComponents.Where(c => isNotBlank(c)));
            if (nonemptyComponents.Count == 2 && nonemptyComponents[0] == SqlSchemaName.sys)
                return nonemptyComponents[1];

            var components = map(c => name.quoted ? bracket(c) : c, nonemptyComponents);
            var formatted = string.Join(".", components);
            return formatted;
        }

        public static string FormatSyntax(this IKeyword keyword)
            => keyword.KeywordName.ToLower();

        public static string FormatSyntax(this sxc.column_predicate predicate)
            => $"{predicate.column} {predicate.condition.FormatSyntax()}";

        public static string FormatSyntax(this sxc.routine_argument_list arglist)
            => string.Join(",", arglist.Select(arg => arg.FormatSyntax()));

        public static string FormatSyntax(this IKeyphrase keyphrase)
            => string.Join(space(), map(keyphrase.keywords, kw => kw.FormatSyntax()));

        public static string FormatSyntax(this IOperator op)
            => op.Symbol;

        public static string FormatSyntax(this IModelList m)
            => string.Join(m.delimiter,
                map(m.Cast<IModel>(), item => item.FormatDynamic()));

        public static string FormatSyntax(this sxc.function_call m)
        {
            var optSql = m.options.Any() ? $" with {m.options.FormatSyntax()}" : string.Empty;
            return $"{(m.function_name as sxc.ISqlObjectName).FormatSyntax()}{paren(m.args.FormatSyntax())}{optSql}";
        }

        public static string FormatSyntax(this statement_adapter m)
            => m.subect.FormatSyntax();

        public static string FormatSyntax(this sxc.ISqlObjectName m)
        {
            string FormatPart(string part, bool quoted)
                => isBlank(part) ? string.Empty
                : (quoted ? bracket(part) : part);

            if (m.IsSystemObject && not(m.IsDatabaseQualified()))
                return m.UnqualifiedName;
            else
                return concat(
                    FormatPart(m.ServerNamePart, m.quoted),
                    FormatPart(m.DatabaseNamePart, m.quoted),
                    FormatPart(m.SchemaNamePart, m.quoted),
                    FormatPart(m.UnqualifiedName, m.quoted)
                    );
        }

        public static string FormatSyntax(this variable_assignment m)
            => ~ (from sx1 in some(m.statement_designator.FormatSyntax())
                from varName in some(m.variable_name.FormatSyntax())
                from eq in some(op.EQ.FormatSyntax())
                from varVal in some(m.variable_value.FormatSyntax())
                select concat(sx1, space(), varName, eq, varVal));
                

        public static string FormatSyntax(this set_option m)
            => string.Join(space(), 
                    m.value.prepend(m.statement_designator).Select(x => x.FormatSyntax()));
               
        public static string FormatSyntax(this string_literal m)
            => (m.unicode ? "N" : String.Empty) + squote(m.value);

        public static string FormatSyntax(this binary_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this bit_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this date_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this time_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this datetime_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this character_literal m)
            => squote(m.value);

        public static string FormatSyntax(this integer_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this float_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this decimal_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this uniqueidentifier_literal m)
            => m.value.FormatDynamic();

        public static string FormatSyntax(this money_literal money)
            => money.value.ToString("C4");

        public static string FormatSyntax(this SqlIdentifier identifier)
            => identifier.ToString();

        public static string FormatSyntax(this between_expression expression)
            => FormatSyntax(space(),
                expression.test_expression,
                BETWEEN,
                expression.begin_expression,
                AND,
                expression.end_expression
                );

        public static string FormatSyntax(this table_source_name m)
            => m.quoted ? bracket(m.text) : m.text;

        public static string FormatSyntax(this between_predicate predicate)
            => predicate.expression.FormatSyntax();

        public static string FormatSyntax(from_table_or_view m)
            => m.source_name.FormatSyntax()
                + m.table_alias.map(v =>
                       v.alias.FormatSyntax(), () => String.Empty);

        public static string FormatSyntax(this column_alias m)
            => m.alias.IsEmpty() 
            ? m.column.FormatSyntax()
            : FormatSyntax(space(),
                m.column,
                AS,
                m.alias
                );

        public static string FormatSyntax(this inner_join m)
            => string.Empty;

        public static string FormatSyntax(this comparison_expression m)
            => FormatSyntax(space(),
                    m.Left,
                    m.op,
                    m.Right
                );

        public static string FormatSyntax(this logical_expression m)
        {
            switch (m.op)
            {
                case not_op n:
                    return n.Name + enclose(m.Left.FormatSyntax(), "(", ")");
                default:
                    return enclose(FormatSyntax(space(), m.Left, m.op, m.Right), "(", ")");
            }
        }

        public static string FormatSyntax(this variable<chronology_type> m)
            => m.FormatSyntax();

        public static string FormatSyntax(this system_time_as_of m)
            => FormatSyntax(space(), AS, OF, m.as_of);

        public static string FormatSyntax(this system_time_from m)
            => m.ToString();

        public static string FormatSyntax(this system_time_between m)
            => m.ToString();

        public static string FormatSyntax(this system_time_contained_in m)
            => m.ToString();

        public static string FormatSyntax(this system_time_all m)
            => m.ToString();

        public static string FormatSyntax(this select_list m)
            => FormatSyntax(commas, m.items);

        public static string FormatSyntax(this table_source_list m)
           => FormatSyntax(space(), m.items);

        public static string FormatSyntax(this select_clause m)
            => concat(SELECT,
                m.top.map(x => concat(space(), FormatSyntax(x)), () => string.Empty),
                m.distinct.map(x => concat(space(), x.KeywordName), () => string.Empty),
                space(), FormatSyntax(m.select_list)
                ); 

        public static string FormatSyntax(this from_clause m)
            => FormatSyntax(space(), m.designator, m.sources);

        public static string FormatSyntax(this where_clause m)
            => FormatSyntax(space(), m.designator, m.search_condition);

        public static string FormatSyntax(this select_statement m)
            => FormatSyntax(eol(),
                    m.statement_designator,
                    m.selection,
                    m.source,
                    m.criteria
                );

        public static string FormatSyntax(this argument_list m)
            => FormatSyntax(commas, m.items);

        public static string FormatSyntax(this name_expression m)
            => m.ExpressedName.FormatSyntax();


        public static string FormatSyntax(this scalar_value m)
            => m.Value.ToClrValue().FormatDynamic();

        public static string FormatSyntax(this alter_index m)
            => FormatSyntax(space(),
                    m.statement_designator,
                    m.element_designator,
                    m.index_name,
                    ON,
                    m.parent_object,
                    m.choice
                );


        public static string FormatSyntax(this alter_index_rebuild m)
            => m.choice_type.FormatSyntax();

        public static string FormatSyntax(this alter_index_disable m)
            => m.choice_type.FormatSyntax();

        
        public static string FormatSyntax(this xprop_value m)
            => exec("sp_addextendedproperty").FormatSyntax();

        public static string FormatSyntax(this top_clause m)
        {
            var sql = concat(
                    m.designator.FormatSyntax(),
                    paren(m.expression.FormatSyntax())
                );
            if (m.percent)
                sql = spaced(sql, PERCENT);
            if (m.with_ties)
                sql = spaced(sql, WITH, TIES);
            return sql;
        }

        public static string FormatSyntax(this create_schema m)
            => FormatSyntax(space(),
                m.statement_designator,
                m.element_designator,
                m.element_name
                );

        public static string FormatSyntax(this create_message_type m)
            => FormatSyntax(space(),
                    m.statement_designator,
                    m.element_designator,
                    m.element_name
                );

        public static string FormatSyntax(this create_queue m)
            => FormatSyntax(space(),
                    m.statement_designator,
                    m.element_designator,
                    m.element_name
                );

        public static string FormatSyntax(this contract_message_spec m)
            => FormatSyntax(space(),
                m.message_type,
                SENT,
                BY,
                m.message_sender
                );

        public static string FormatSyntax(this from_table_variable m)
            => m.table_alias.exists
                ? FormatSyntax(space(),
                    m.variable_name,
                    AS,
                    m.table_alias.value)
            : m.variable_name.FormatSyntax();

        public static string FormatSyntax(this create_contract m)
           => FormatSyntax(space(),
                   m.statement_designator,
                   m.element_designator,
                    m.element_name
               ) + $"({m.message_specs.FormatSyntax()})";

        public static string FormatSyntax(this create_service m)
            => concat(FormatSyntax(space(),
                m.statement_designator,
                m.element_designator,
                m.element_name,
                ON, QUEUE,m.queue_name),                 
                
                (m.contract_names.Count() != 0 
                ? paren(m.contract_names.FormatSyntax()) 
                : String.Empty)
            );

        public static IEnumerable<ISqlScript> FormatSyntax(this IEnumerable<IModelList> lists)
        {
            foreach (var list in lists)
                foreach (IModel item in list)
                    yield return new SqlScript(item.FormatDynamic());
        }
 
        public static string FormatSyntax(this IModel m)
        {
            if (m == null)
                return NULL;

            return m.FormatDynamic();
        }
    }
}

