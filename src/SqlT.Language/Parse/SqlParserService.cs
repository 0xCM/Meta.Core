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

    using Meta.Models;
    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines primary implementation of the <see cref="ISqlParser"/> contract
    /// </summary>
    class SqlParserService : ApplicationService<SqlParserService, ISqlParser>, ISqlParser
    {
        readonly ISqlGenerationContext GC;

        public SqlParserService(IApplicationContext C)
            : base(C)
        {
            this.Version = SqlVersions.Default;
            this.NativeParser = TSqlParser.NativeParser(Version.TSqlDomVersion());
            this.GC = C.SqlGenerationContext();            
        }

        public SqlParserService(SqlVersion? Version = null)
        {
            this.Version = (Version ?? SqlVersions.Default);
            this.NativeParser = TSqlParser.NativeParser(this.Version.TSqlDomVersion());            
        }

        TSql.TSqlParser NativeParser { get; }

        SqlVersion Version { get; }

        static SqlStatementScript ModelStatement(TSql.TSqlStatement src, SqlSyntaxGraph SyntaxGraph = null)
            => new SqlStatementScript(src.GetFragmentText(), src, SyntaxGraph);

        public SqlVersion ParserVersion
            => Version;

        public Option<TSpec> ParseSpec<TSpec>(ISqlScript script) where TSpec : SqlModel<TSpec>
            => GC.ParseSpec<TSpec>(NativeParser, script.ScriptText);

        public Option<SqlParameterizedScript> ParseRoutineBody(ISqlScript script)
            => SqlScript.FromContract(script).ParseRoutineBody(ParserVersion.TSqlDomVersion());

        public Lst<IModel> ParseSpecs(ISqlScript script)
            => GC.ParseSpecs(NativeParser, script.ScriptText);

        public SqlSyntaxGraph ParseSyntaxGraph(ISqlScript sql)
            => NativeParser.ParseSyntaxGraph(sql);

        public Option<SqlBatchScript> ParseBatches(ISqlScript script, bool parseSyntaxGraph)
        {
            var parser = TSqlParser.AdaptiveParser(ParserVersion.TSqlDomVersion());
            var result = parser.ParseSql<TSql.TSqlScript>(script.ScriptText);
            if(result.Failed)
                return none<SqlBatchScript>(result.Error.Message);

            var segments = new List<SqlBatchScriptSegment>();
            foreach (var b in result.Content.ValueOrDefault().Batches)
            {
                var statements = parseSyntaxGraph 
                    ? mapi(b.Statements,
                        (i,s) => ModelStatement(s, ParseSyntaxGraph(s.ToNamedScript($"Script{i}"))))
                    : map(b.Statements, s => ModelStatement(s));

                var segment = new SqlBatchScriptSegment(b.GetFragmentText(), statements, b.StartLine, b.FragmentLength + b.StartLine);
                segments.Add(segment);
            }
            return new SqlBatchScript(script.ScriptName, segments);                           
        }

        public Option<Lst<SqlStatementScript>> ParseStatements(ISqlScript script)
        {
            var statements = new List<sxc.statement>();
            var parser = TSqlParser.AdaptiveParser(ParserVersion.TSqlDomVersion());
            var result = parser.ParseSql<TSql.TSqlFragment>(script.ScriptText);
            if (result.Failed)
                return none<Lst<SqlStatementScript>>(result.GetApplicationError());

            return mapi(result.ExtractStatements(),
                        (i,s) => ModelStatement(s,
                            ParseSyntaxGraph(s.ToNamedScript($"Script{i}"))));            
        }

        public Option<object> ParseAny(ISqlScript script)
        {
            var parser = TSqlParser.AdaptiveParser(ParserVersion.TSqlDomVersion());
            var result = parser.ParseSql<TSql.TSqlFragment>(script.ScriptText);
            return result.Succeeded 
               ? some<object>(result.Content) 
               : none<object>(result.GetApplicationError());
        }
    }

}