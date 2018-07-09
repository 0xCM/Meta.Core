//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using SqlT.Language;

    public interface ITSqlParserAdapter
    {
        TSqlParseResult<T> ParseSql<T>(string text) 
            where T : TSql.TSqlFragment;

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
