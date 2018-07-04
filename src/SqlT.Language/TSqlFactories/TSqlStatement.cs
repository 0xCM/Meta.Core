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
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Language;
    using SqlT.Templates;
    using static metacore;
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using Services;

    partial class TSqlFactory
    {

        [TSqlBuilder]
        public static TSql.TSqlStatement SingleStatement(this TSql.TSqlScript tSql)
        {
            if (tSql.Batches.Count != 1)
                throw new ArgumentException("Exactly one statement is expected");
            if (tSql.Batches[0].Statements.Count != 1)
                throw new ArgumentException("Exactly one statement is expected");
            return tSql.Batches[0].Statements[0];
        }

        public static TSql.StatementList TSqlStatementList(this IEnumerable<sxc.statement> src)
        {
            var list = new TSql.StatementList();
            list.Statements.AddRange(src.Select(statement => statement.TSqlStatement()));
            return list;
        }

        public static IEnumerable<TSql.TSqlStatement> Statements(this TSql.TSqlScript script)
           => from b in script.Batches
              from s in b.Statements
              select s;

        public static TSql.TSqlStatement TSqlStatement(this sxc.statement src)
        {
            var parser = TSqlParser.AdaptiveParser();
            if (src is SqlStatementScript)
                return parser.ParseStatement((src as SqlStatementScript).SqlScript.ScriptText).Content.Require();
            else if (src is SqlMergeStatement)
                return (src as SqlMergeStatement).TSqlStatement();
            else if (src is SqlSelectStatement)
                return (src as SqlSelectStatement).TSqlStatement();
            else if (src is SqlAlterIndex)
                return (src as SqlAlterIndex).TSqlStatement();
            else if (src is SqlTruncateTable)
                return (src as SqlTruncateTable).TSqlStatement();
            else if (src is SqlVariableDeclaration)
                return (src as SqlVariableDeclaration).TSqlStatement();
            else
                return parser.ParseStatement(src.FormatSyntax()).Content.Require();                     
        }
    }
}