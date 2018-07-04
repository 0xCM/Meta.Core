//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static class SqlParseExtensions
    {
        public static TSql.TSqlScript ParseAny(this SqlScript sql, TSql.SqlVersion? version = null)
            => TSqlParser.NativeParser(version).ParseAny(sql);

        public static Option<TSql.TSqlStatement> TryParseStatement(this SqlScript script, TSql.SqlVersion? version = null)
            => TSqlParser.NativeParser(version).TryParseAny(script).Map(x => x.SingleStatement());

        /// <summary>
        /// Parses a single select statement
        /// </summary>
        /// <param name="sql">The SQL that represents the statement</param>
        /// <returns></returns>
        public static Option<TSql.SelectStatement> TryParseSelectStatement(this SqlScript sql)
            => sql.TryParseStatement().Map(x => x as TSql.SelectStatement);

        /// <summary>
        /// Converts a sql parser error to a <see cref="IApplicationMessage"/> error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static IApplicationMessage GetApplicationError(this SqlParseError error)
            => ApplicationMessage.Error($"The SQL parser encountered one or more error conditions: {error}");

        static void onType<V>(object value, Action<V> action)
        {
            switch (value)
            {
                case V v:
                    action(v);
                    break;
            }
        }

        static void onType<V1, V2>(object value, Action<V1> action1, Action<V2> action2)
        {
            switch (value)
            {
                case V1 v:
                    action1(v);
                    break;

                case V2 v:
                    action2(v);
                    break;
            }
        }

        public static Option<SqlParameterizedScript> ParseRoutineBody(this SqlScript sql, TSql.SqlVersion? version = null)
        {
            var _statment = sql.TryParseStatement(version);
            if (!_statment)
                return _statment.ToNone<SqlParameterizedScript>();

            var statement = _statment.Require();
            var script = none<SqlParameterizedScript>();

            onType(statement, (TSql.FunctionStatementBody b)
                => {
                        onType(b.ReturnType, (TSql.SelectFunctionReturnType r)
                        => {
                                var frag = r.GetFragmentText();
                                script = new SqlParameterizedScript(b.Name.GetSchemaQualifiedName(), frag);
                        },

                        (TSql.ScalarFunctionReturnType r) 
                            => {
                                onType(b.StatementList.Statements.FirstOrDefault(),
                                    (TSql.BeginEndBlockStatement block)
                                    =>
                                    {
                                        var sb = new StringBuilder();
                                        foreach (var s in block.StatementList.Statements)
                                        {
                                            sb.Append(s.GetFragmentText());
                                        }
                                        var body = sb.ToString();
                                        script = new SqlParameterizedScript(b.Name.GetSchemaQualifiedName(), body);
                                    });
                                }
                        );
                });

            onType(statement, (TSql.CreateProcedureStatement s)
                =>
            {
                script = new SqlParameterizedScript(
                    s.ProcedureReference.Name.GetSchemaQualifiedName(),
                    s.StatementList.GetFragmentText());
            });

            return script;
        }
    }
}