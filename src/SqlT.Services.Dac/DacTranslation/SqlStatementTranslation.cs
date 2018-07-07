//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Language;

    using static metacore;

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;
    using sx = SqlT.Syntax.SqlSyntax;

    public static class SqlStatementTranslation
    {
        public static Option<sx.statement_list> ModelStatements(this DacX.TSqlModelElement dsql)
        {
            
            var sql = dsql.GetScript();
            return from s in SqlParser.Get().ParseStatements(new SqlScript(sql))
                   select new sx.statement_list(s.AsReadOnlyList());
        }
    }
}