//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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

        static Option<sxc.statement> Weak<S>(this Option<S> statement)
            where S : sxc.statement => statement.Map(x => (sxc.statement)x);
    }
}
