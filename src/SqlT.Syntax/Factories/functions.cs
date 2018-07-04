//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
   
    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;

    using static SqlSyntax;
    using static metacore;    
    using static SqlFunctions;
    using static sql;

    using sxc = Syntax.contracts;
    using kwt = SqlKeywordTypes;
    using sfx = SqlFunctionTypes;


    partial class sql
    {
        public static sxc.scalar_function_call app_name()
            => call(APP_NAME, routine_argument_list.empty);

        public static sxc.scalar_function_call avg(sxc.numeric_expression xpr)
            => call((sxc.function)AVG, arg(xpr));

        public static sxc.scalar_function_call concat(params sxc.routine_argument[] _args)
            => call(CONCAT, args(_args));

        public static sxc.scalar_function_call count(ISyntaxExpression e)
            => call((sxc.function)COUNT, arg(e));

        public static ISyntaxExpression count(kwt.STAR STAR, kwt.AS AS, SqlAliasName alias)
            => new alias_expression<sxc.function_call>(count(textx("*")), alias);

        public static sxc.scalar_function_call dateadd(datepart_selection datepart, int number, Date date)
            => call(DATEADD, 
                args(datepart, L((SqlVariant)number), L((SqlVariant)date)));

        public static sxc.scalar_function_call datediff(datepart_selection datepart, Date start_date, Date end_date)
            => call(DATEDIFF,
                    args(datepart, L((SqlVariant)start_date), L((SqlVariant)end_date)));

        public static sxc.scalar_function_call eomonth(DateTime date, int? monthsToAdd = null)
            => monthsToAdd.MapValueOrElse(
                x => call(EOMONTH,
                        args(L((SqlVariant)date), L((SqlVariant)x))),                   
                () => call(EOMONTH,
                            args(L((SqlVariant)date))));

        public static sxc.scalar_function_call eomonth(Date date, int? monthsToAdd = null)
            => monthsToAdd.MapValueOrElse(
                x => call(EOMONTH,
                        args(L((SqlVariant)date), L((SqlVariant)x))),
                () => call((sxc.function)EOMONTH,
                        arg(L((SqlVariant)date))));

        public static sxc.scalar_function_call filetablerootpath
           (SqlTableName filetable, FileTablePathOption option = FileTablePathOption.Default)
               => call(FILETABLEROOTPATH,
                   args(filetable.TrimCatalog().AsNameExpression(), L((int)option)));

        public static sxc.scalar_function_call getdate()
            => call(GETDATE, routine_argument_list.empty);

        public static sxc.scalar_function_call error_message()
            => call(ERROR_MESSAGE,routine_argument_list.empty);

        public static sxc.scalar_function_call error_number()
            => call(ERROR_NUMBER, routine_argument_list.empty);

        public static sxc.scalar_function_call indexproperty(object_id object_id,
            index_or_statistics_name index_name, index_property_name index_property)
                => call(INDEXPROPERTY,
                       args(L(object_id), nx(index_name), nx(index_property)));

        public static sxc.scalar_function_call indexproperty(sxc.scalar_expression object_id,
                index_or_statistics_name index_name, index_property_name index_property)
                    => call(INDEXPROPERTY,
                            args(object_id, nx(index_name), nx(index_property)));

        public static sxc.scalar_function_call isnull(ISyntaxExpression check_expression, ISyntaxExpression replacement_value)
            => call(ISNULL,
                    args(check_expression, replacement_value));

        public static sxc.scalar_function_call len(ISyntaxExpression x)
           => call((sxc.function)LEN, arg(x));

        public static sxc.scalar_function_call min(ISyntaxExpression x)
            => call((sxc.function)MIN, arg(x));

        public static sxc.scalar_function_call min(sxc.column_name x)
            => call((sxc.function)MIN, arg(new column_ref(x)));

        public static ISyntaxExpression min(sxc.column_name col, SqlAliasName alias)
        {
            if (isNull(alias))
                return min(new column_ref(col));
            else
                return new alias_expression<sxc.function_call>(min(col), alias);
        }

        public static sxc.scalar_function_call max(ISyntaxExpression x)
            => call((sxc.function)sfx.MAX.get(), arg(x));

        public static sxc.function_call max(sxc.column_name col)
            => call(sfx.MAX.get(), col.AsNameExpression());

        public static ISyntaxExpression max(sxc.column_name col, SqlAliasName alias)
        {
            if (isNull(alias))
                return max(new column_ref(col));
            else
                return new alias_expression<sxc.function_call>(max(col), alias);            
        }

        public static scalar_function_call<sxc.int_type> object_id(object_name name)
            => call<sxc.int_type>(OBJECT_ID, L(name.selected_value.ToString()));

        public static scalar_function_call<sxc.nvarchar_type> object_name(object_id object_id)
           => call<sxc.nvarchar_type>(OBJECT_NAME, L(object_id));

        public static scalar_function_call<sxc.nvarchar_type> object_name(procid procid)
            => call<sxc.nvarchar_type>(OBJECT_NAME, L(procid));

        public static sxc.function_call procid()
            => call(PROCID);

        public static sxc.function_call sum(sxc.numeric_expression x)
            => call(SUM, args(x));

        public static sxc.function_call suser_sname()
            => call(SUSER_SNAME);

        public static sxc.function_call sysdatetime()
            => call(SYSDATETIME);

        public static sxc.function_call sysdatetimeoffset()
            => call(SYSDATETIMEOFFSET);

        public static function_call<sfx.DATEPART> datepart(datepart_selection part, Date date)
            => call(DATEPART, part, L(date));

        public static function_call<sfx.DATEPART> datepart(datepart_selection part, DateTime date)
            => call(DATEPART, part, L(date));

        public static sxc.scalar_function_call left(variable_reference var, int count)
            => call(LEFT, args(var, L(count)));

        public static sxc.scalar_function_call left(string_literal literal, int count)
            => call(LEFT, args(literal, L(count)));

        public static sxc.scalar_function_call right(variable_reference var, int count)
            => call(RIGHT, args(var, L(count)));

    }

}