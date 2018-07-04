//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using sxc = SqlT.Syntax.contracts;
    using sx = SqlT.Syntax.SqlSyntax;

    public interface ISqlParser
    {
        SqlVersion ParserVersion { get; }

        SqlSyntaxGraph ParseSyntaxGraph(ISqlScript script);

       
        ReadOnlyList<IModel> ParseSpecs(ISqlScript script);

        Option<SqlBatchScript> ParseBatches(ISqlScript script, bool parseSyntaxGraph = false);

        Option<SqlParameterizedScript> ParseRoutineBody(ISqlScript script);

        Option<TSpec> ParseSpec<TSpec>(ISqlScript script) where TSpec : SqlModel<TSpec>;

        Option<ReadOnlyList<SqlStatementScript>> ParseStatements(ISqlScript script);

        Option<object> ParseAny(ISqlScript script);           
        

    }
}
