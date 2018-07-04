//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using SqlT.Language;

    public interface ISqlAdaptiveParser
    {
        TSqlParseResult<T> ParseSql<T>(string text) where T : TSql.TSqlFragment;

        TSqlParseResult<TSql.TSqlFragment> ParseFragment(string input);

        TSqlParseResult<TSql.StatementList> ParseStatementList(string input);

        TSqlParseResult<TSql.TSqlStatement> ParseStatement(string input);

        TSqlParseResult<TSql.BooleanExpression> ParseBooleanExpression(string input);

        TSqlParseResult<TSql.ScalarExpression> ParseScalarExpression(string input);

        TSqlParseResult<TSql.DataTypeReference> ParseScalarDataType(string input);

        TSqlParseResult<TSql.TSqlScript> ParseScript(string input);

        TSqlParseResult<TSql.SchemaObjectName> ParseSchemaObjectName(string input);
    }

    delegate TSqlParseResult<T> TSqlParseMethod<T>(string intput) 
        where T : TSql.TSqlFragment;
}
