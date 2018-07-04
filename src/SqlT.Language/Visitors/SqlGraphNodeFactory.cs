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

    using SqlT.Models;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    class GraphNodeFactory
    {
        static SqlGraphNodeHandlers DefineHandlers(SqlSyntaxGraphContext context)
            => new SqlGraphNodeHandlers(context);


        readonly SqlGraphNodeHandlers Handlers;

        public GraphNodeFactory(SqlSyntaxGraphContext context)
        {

            Handlers = DefineHandlers(context);
        }

        public SqlSyntaxGraphNode CreateGraphNode(TSql.TSqlFragment tSql)
            => Handlers.Handle(tSql);
    }



}