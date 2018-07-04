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
    using SqlT.Models;
    using static SqlSyntax;
    using static SqlFunctions;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static sql;
    
    partial class sql
    {
        static IEnumerable<routine_argument> raiserror_args(string_literal msg_str, severity severity, int state, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_str);
            yield return arg((short)severity);
            yield return arg(state);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(integer_literal msg_id, severity severity, int state, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_id);
            yield return arg((short)severity);
            yield return arg(state);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(string_literal msg_str, severity severity, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_str);
            yield return arg((short)severity);
            yield return arg(1);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(integer_literal msg_id, severity severity, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_id);
            yield return arg((short)severity);
            yield return arg(1);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(string_literal msg_str, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_str);
            yield return arg((short)1);
            yield return arg(1);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(int_or_string_literal msg_id_or_string, short? severity = null)
        {
            yield return arg(msg_id_or_string);
            yield return arg(severity ?? 1);
            yield return arg(1);
        }

        static IEnumerable<routine_argument> raiserror_args(integer_literal msg_id, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_id);
            yield return arg((short)1);
            yield return arg(1);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        static IEnumerable<routine_argument> raiserror_args(SqlVariableName msg_var, short? severity)
        {
            yield return arg(msg_var);
            yield return arg(severity ?? 1);
            yield return arg(1);
        }

        static IEnumerable<routine_argument> raiserror_args(SqlVariableName msg_var, severity severity, IEnumerable<object> fmtArgs)
        {
            yield return arg(msg_var);
            yield return arg((short)severity);
            yield return arg(1);

            foreach (var a in fmtArgs)
                yield return arg(L(a));
        }

        public static sxc.function_call raiserror(SqlVariableName msg_var, severity severity, params object[] fmtArgs)
            => call(RAISERROR, args(raiserror_args(msg_var, severity, fmtArgs)));

        public static sxc.function_call raiserror(int msg_id, severity severity, params object[] fmtArgs)
            => call(RAISERROR, args(raiserror_args(msg_id, severity, fmtArgs)));

        public static sxc.function_call raiserror(int msg_id, severity severity, IEnumerable<object> fmtArgs, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_id, severity, fmtArgs)),NOWAIT);

        public static sxc.function_call raiserror(int msg_id, IEnumerable<object> fmtArgs, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_id, fmtArgs)), NOWAIT);

        public static sxc.function_call raiserror(int msg_id, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_id, stream<object>())), NOWAIT);

        public static sxc.function_call raiserror(string msg_str, severity severity, params object[] fmtArgs)
            => call(RAISERROR, args(raiserror_args((string_literal)msg_str, severity, fmtArgs)));

        public static sxc.function_call raiserror(string msg_str, params object[] fmtArgs)
            => call(RAISERROR, args(raiserror_args(msg_str, fmtArgs)));

        public static sxc.function_call raiserror(string msg_str, severity severity, int state, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_str, severity, state, stream<object>()) ), NOWAIT);

        public static sxc.function_call raiserror(string msg_str, severity severity, IEnumerable<object> fmtArgs, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args((string_literal)msg_str, severity, fmtArgs)), NOWAIT);

        public static sxc.function_call raiserror(string msg_str, IEnumerable<object> fmtArgs, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, array(raiserror_args(msg_str, fmtArgs)), NOWAIT);

        public static sxc.function_call raiserror(string msg_str, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(L(msg_str), L((short)1), L(1)),NOWAIT);

        public static sxc.function_call raiserror(SqlVariableName msg_var, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_var, 1)), NOWAIT);

        public static sxc.function_call raiserror(SqlVariableName msg_var, short severity, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
            => call(RAISERROR, args(raiserror_args(msg_var,severity)), NOWAIT);

        public static sxc.function_call raiserror(SqlVariableName msg_var, severity severity, kwt.WITH WITH, kwt.NOWAIT NOWAIT)
           => call(RAISERROR, args(raiserror_args(msg_var, (short)severity)), NOWAIT);

    }
}