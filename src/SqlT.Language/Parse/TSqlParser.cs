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
    using System.IO;
    using System.Collections.Concurrent;

    using Meta.Core;
    using Meta.Models;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;
    using sxc = Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using G = System.Collections.Generic;

    public static class TSqlParser
    {
        public static TSql.TSqlParser NativeParser(TSql.SqlVersion? version = null)
            => NativeParsers.GetOrAdd(version ?? TSql.SqlVersion.Sql130, v => CreateVersionedParser(v));

        static readonly ConcurrentDictionary<TSql.SqlVersion, TSql.TSqlParser> NativeParsers
            = new ConcurrentDictionary<TSql.SqlVersion, TSql.TSqlParser>();

        static TSql.TSqlParser CreateVersionedParser(TSql.SqlVersion v)
        {
            switch (v)
            {
                case TSql.SqlVersion.Sql90:
                    return new TSql.TSql90Parser(false);
                case TSql.SqlVersion.Sql80:
                    return new TSql.TSql80Parser(false);
                case TSql.SqlVersion.Sql100:
                    return new TSql.TSql100Parser(false);
                case TSql.SqlVersion.Sql110:
                    return new TSql.TSql110Parser(false);
                case TSql.SqlVersion.Sql120:
                    return new TSql.TSql120Parser(false);
                case TSql.SqlVersion.Sql130:
                    return new TSql.TSql130Parser(false);
                case TSql.SqlVersion.Sql140:
                    return new TSql.TSql140Parser(false);
                default:
                    throw new NotSupportedException();
            }
        }

        public static ITSqlParserAdapter AdaptiveParser(TSql.SqlVersion? version = null)
            => new SqlAdaptiveParser(NativeParser(version));

        public static SqlParseError Summarize(this IEnumerable<TSql.ParseError> errors, string Input)
            =>
            new SqlParseError(Input,
                map(errors, error
                    => new SqlParseErrorMessage(
                            error.Number,
                            error.Offset,
                            error.Line,
                            error.Column,
                            error.Message
                        )
                ));

        static TextReader CreateSqlReader(string sql)
            => new StringReader(sql);

        internal static ITSqlParserAdapter AdaptiveParser(this TSql.TSqlParser NativeParser)
            => new SqlAdaptiveParser(NativeParser);

        public static Lst<IModel> ParseSpecs(this ISqlGenerationContext GC, TSql.TSqlParser parser, SqlScript sql)
        {
            var specs = MutableList.Create<IModel>();
            var fails = MutableList.Create<TSql.TSqlFragment>();
            var visitor = new SqlFragmentVisitor(GC,spec => specs.Add(spec), fail => fails.Add(fail));
            iter(parser.ParseAny(sql).Statements(), s => s.Accept(visitor));
            return specs;
        }

        public static Option<TSpec> ParseSpec<TSpec>(this ISqlGenerationContext GC, TSql.TSqlParser parser, SqlScript sql)
            => ParseSpecs(GC,parser, sql).Stream().OfType<TSpec>().FirstOrDefault();

        public static Option<TSql.TSqlScript> TryParseAny(this TSql.TSqlParser parser, string sql)
        {
            using (var reader = CreateSqlReader(sql))
            {
                var result = parser.Parse(reader, out IList<TSql.ParseError> parseErrors);
                if (parseErrors.Count != 0)
                    return none<TSql.TSqlScript>(SqlParseError.FromParserResult(sql, parseErrors).GetApplicationError());
                else
                    return some(result as TSql.TSqlScript);
            }
        }

        public static TSql.TSqlScript ParseAny(this TSql.TSqlParser parser, string sql)
            => parser.TryParseAny(sql).Require();

        public static SqlSyntaxGraph ParseSyntaxGraph(this TSql.TSqlParser parser, ISqlScript sql)
        {
            var nodes = MutableList.Create<SqlSyntaxGraphNode>();
            var visitor = new SqlGraphNodeVisitor(new SqlSyntaxGraphContext(), node => nodes.Add(node));
            parser.ParseAny(sql.ScriptText).Accept(visitor);
            return new SqlSyntaxGraph(nodes);
        }
    }
}