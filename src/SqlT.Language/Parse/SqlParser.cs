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

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    public static class SqlParser
    {
        static TSqlParseResult<TSql.SchemaObjectName> ParseObjectName(this SqlScript sql)
            => TSqlParser.AdaptiveParser().ParseSql<TSql.SchemaObjectName>(sql);

        static void Visit(this SqlScript sql, Action<SqlSyntaxGraphNode> observer)
            => sql.ParseAny().Accept(new SqlGraphNodeVisitor(new SqlSyntaxGraphContext(), observer));

        public static T ParseExpression<T>(this SqlScript sql)
            => cast<T>(ParseScalarExpression(sql));

        public static TSql.ScalarExpression ParseScalarExpression(this SqlScript sql)
        {
            var parser = TSqlParser.NativeParser();
            var result = parser.ParseExpression(new StringReader(sql), 
                out IList<TSql.ParseError> parseErrors);
            if (parseErrors.Count != 0)
                throw new Exception("SQL Parse Error");
            return result;
        }

        public static ISqlParser Get()
            => new SqlParserService();

        public static SqlProjector ParseSimpleProjector(this SqlScript sql,  string projectorType,             
            SqlElementDescription documentation,  string peer,  IEnumerable<SqlPropertyAttachment> properties)
        {
            var script = sql.ParseAny();
            if (script.Batches.Count != 1)
                throw new ArgumentException("Exactly one statement is expected");
            if(script.Batches[0].Statements.Count != 1)
                throw new ArgumentException("Exactly one statement is expected");

            var statement = script.Batches[0].Statements[0] as TSql.CreateFunctionStatement;
            if (statement == null)
                throw new ArgumentException("Expected a function but got something else");
            return statement.ModelProjector(projectorType, documentation, peer, properties);
        }
    }
}
