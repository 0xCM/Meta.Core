﻿//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Language;
    using static SqlT.Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static class SqlSyntaxX
    {
        static Option<create_schema> RecoverSchemaDefinition(this SqlStatementScript src)
        {
            var tSql = (TSql.CreateSchemaStatement)src.ScriptSource;
            return new create_schema(tSql.Name.ToSchemaName());            
        }

        static Option<SqlTable> RecoverTableDefinition(this SqlStatementScript src)
        {
            var tSql = (TSql.CreateTableStatement)src.ScriptSource;
            return tSql.SqlTModel();
        }

    }
}
