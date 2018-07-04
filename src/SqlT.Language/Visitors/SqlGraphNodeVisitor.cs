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

    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    class SqlGraphNodeVisitor : TSql.TSqlFragmentVisitor
    {
        readonly Action<SqlSyntaxGraphNode> observer;
        GraphNodeFactory factory;


        IReadOnlySet<Type> FragmentSkips =
            roset(typeof(TSql.StatementList),
                typeof(TSql.TSqlStatement),
                typeof(TSql.SetVariableStatement)
                );           
        
        SqlSyntaxGraphNode DefineNode(TSql.TSqlFragment tSql)
            => factory.CreateGraphNode(tSql);

        SqlSyntaxGraphNode VisitStatement(TSql.TSqlStatement tSql)
        {

            var newNode = DefineNode(tSql);
            var lastNode = newNode;
            observer(lastNode);
            base.Visit(tSql);
            return newNode;
        }
      
        public SqlGraphNodeVisitor(SqlSyntaxGraphContext context, Action<SqlSyntaxGraphNode> observer)
        { 
            this.observer = observer;
            this.factory = new GraphNodeFactory(context);
        }

        public override void Visit(TSql.StatementList node)
            => iter(node.Statements, s => VisitStatement(s));

        public override void Visit(TSql.TSqlStatement node)
            => observer(DefineNode(node));

        public override void Visit(TSql.TSqlFragment node)
        {
            if (!FragmentSkips.Contains(node.GetType()))
                observer(DefineNode(node));
        }
    }
}
