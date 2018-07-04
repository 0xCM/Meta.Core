//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;

    using Meta.Models;
    using SqlT.Services;
    using SqlT.Syntax;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    class ValueExpressionVisitor : TSqlVisitor<ValueExpressionVisitor, TSql.ValueExpression>
    {
        
        public ValueExpressionVisitor()
        {

        }

        public ValueExpressionVisitor(TSql.ValueExpression Host, Action<IModel> Observer)
            : base(Host, Observer) {}


        public override void Visit(TSql.Literal node)
            => new LiteralVisitor(node, Observer).Visit();

        public override void Visit(TSql.GlobalVariableExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.VariableReference node)
        {

            base.Visit(node);
        }
    }

}
