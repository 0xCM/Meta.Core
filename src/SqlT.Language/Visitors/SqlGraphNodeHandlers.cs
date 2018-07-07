//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    delegate SqlSyntaxGraphNode SqlGraphNodeHandler(TSql.TSqlFragment tSql);
    delegate SqlSyntaxGraphNode SqlGraphNodeHandler<in N>(N tSql)
        where N : TSql.TSqlFragment;

    class SqlGraphNodeHandlers
    {
        public static IEnumerable<TSql.TSqlParserToken> SelectSemanticTokens(TSql.TSqlFragment node)
            => from token in node.ScriptTokenStream
               where token.TokenType != TSql.TSqlTokenType.WhiteSpace
               select token;

        static SqlSyntaxGraphNode CreateDefaultHandler(SqlSyntaxGraphContext Context, TSql.TSqlFragment node)
            => new SqlSyntaxGraphNode(
                    Context: Context,
                    NodeValue: node,
                    NodeText: node.GetFragmentText(),
                    Tokens: map(SelectSemanticTokens(node), token => $"{token.TokenType}({token.Text})"));        

        readonly Dictionary<Type, SqlGraphNodeHandler> Lookup
            = new Dictionary<Type, SqlGraphNodeHandler>();

        readonly SqlGraphNodeHandler DefaultHandler;
        readonly SqlSyntaxGraphContext context;

        public SqlGraphNodeHandlers(SqlSyntaxGraphContext Context)
        {
            this.context = Context;
            this.DefaultHandler
                = tSql => CreateDefaultHandler(Context, tSql);
            AddHandler<TSql.ScalarExpressionRestoreOption>(tSql => CreateGraphNode(context, tSql));
        }

        void AddHandler<N>(SqlGraphNodeHandler<N> handler)
            where N : TSql.TSqlFragment
             => Lookup[typeof(N)] = tSql => handler((N)tSql);

        public SqlSyntaxGraphNode Handle(TSql.TSqlFragment node)
            => Lookup.TryFind(node.GetType())
                      .Map(h => h(node),                                                      
                           () => DefaultHandler(node));

        static SqlSyntaxGraphNode CreateGraphNode(SqlSyntaxGraphContext context, TSql.ScalarExpressionRestoreOption tSql)
        {
            return CreateDefaultHandler(context, tSql);
        }
    }
}