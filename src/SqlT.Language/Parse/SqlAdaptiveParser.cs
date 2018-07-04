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
    using System.IO;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    class SqlAdaptiveParser : ISqlAdaptiveParser
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
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.Parse(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }


        public TSqlParseResult<TSql.StatementList> ParseStatementList(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseStatementList(reader, out errors);                
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }


        public TSqlParseResult<TSql.TSqlStatement> ParseStatement(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseStatementList(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content.Statements.FirstOrDefault(), error);
            }
        }

        public TSqlParseResult<TSql.BooleanExpression> ParseBooleanExpression(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseBooleanExpression(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.ScalarExpression> ParseScalarExpression(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseExpression(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.DataTypeReference> ParseScalarDataType(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseScalarDataType(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }

        public TSqlParseResult<TSql.TSqlScript> ParseScript(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = (TSql.TSqlScript)NativeParser.Parse(reader, out errors);
                var error = errors.Count != 0 ? SqlParseError.FromParserResult(input, errors) : null;
                return TSqlParseResult.Create(content, error);
            }
        }


        public TSqlParseResult<TSql.SchemaObjectName> ParseSchemaObjectName(string input)
        {
            using (var reader = CreateSqlReader(input))
            {
                var errors = default(IList<TSql.ParseError>);
                var content = NativeParser.ParseSchemaObjectName(reader, out errors);
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

        TSqlParseResult<T> ISqlAdaptiveParser.ParseSql<T>(string sql)
            => cast<TSqlParseResult<T>>(Parse<T>(sql));

    }

}
