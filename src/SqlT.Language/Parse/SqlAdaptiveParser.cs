//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    /// <summary>
    /// Wraps a <see cref="TSql.TSqlParser"/> instance to surface a more strealined API
    /// </summary>
    class SqlAdaptiveParser : ITSqlParserAdapter
    {
        static TextReader CreateSqlReader(string sql)
            => new StringReader(sql);

        static TSqlParseResult<T> Parse<T>(TSqlParseMethod<T> method, string sql)
            where T : TSql.TSqlFragment => method(sql);

        readonly TSql.TSqlParser NativeParser;

        internal SqlAdaptiveParser(TSql.TSqlParser Subject)
        {
            this.NativeParser = Subject;
        }

        public TSqlParseResult<TSql.TSqlFragment> ParseFragment(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.Parse(reader, out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.StatementList> ParseStatementList(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseStatementList(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.TSqlStatement> ParseStatement(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseStatementList(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content.Statements.FirstOrDefault(), error);
            }
        }

        public TSqlParseResult<TSql.BooleanExpression> ParseBooleanExpression(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseBooleanExpression(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.ScalarExpression> ParseScalarExpression(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseExpression(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.DataTypeReference> ParseScalarDataType(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseScalarDataType(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.TSqlScript> ParseScript(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = (TSql.TSqlScript)NativeParser.Parse(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.SchemaObjectName> ParseSchemaObjectName(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var content = NativeParser.ParseSchemaObjectName(reader, 
                    out IList<TSql.ParseError> errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        object Parse<T>(string sql)
            where T : TSql.TSqlFragment
        {
            var t = typeof(T);

            if (t == typeof(TSql.SchemaObjectName))
                return
                    Parse(ParseSchemaObjectName, sql);
            else if (t == typeof(TSql.StatementList))
                return
                    Parse(ParseStatementList, sql);
            else if (t == typeof(TSql.TSqlStatement))
                return
                    Parse(ParseStatement, sql);
            else if (t == typeof(TSql.BooleanExpression))
                return
                    Parse(ParseBooleanExpression, sql);
            else if (t == typeof(TSql.DataTypeReference))
                return
                    Parse(ParseScalarDataType, sql);
            else if (t == typeof(TSql.ScalarExpression))
                return
                    Parse(ParseScalarExpression, sql);
            else if (t == typeof(TSql.TSqlScript))
                return Parse(ParseScript, sql);
            else
                return
                    Parse(ParseFragment, sql);                   
        }

        TSqlParseResult<T> ITSqlParserAdapter.ParseSql<T>(string sql)
            => cast<TSqlParseResult<T>>(Parse<T>(sql));
    }
}
