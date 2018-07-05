//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Language;

    using static metacore;

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;
    using sx = SqlT.Syntax.SqlSyntax;

    static class SqlStatementTranslation
    {
        public static Option<sx.statement_list> ModelStatements(this DacX.TSqlModelElement dsql)
        {
            var parser = new SqlParserService();
            var sql = dsql.GetScript();
            return from s in parser.ParseStatements(new SqlScript(sql))
                   select new sx.statement_list(s);
        }
    }
}