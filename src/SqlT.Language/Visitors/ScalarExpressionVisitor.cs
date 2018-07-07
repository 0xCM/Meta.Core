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

    class ScalarExpressionVisitor : TSqlVisitor<ScalarExpressionVisitor, TSql.ScalarExpression>
    {
        public ScalarExpressionVisitor()
        {

        }

        public ScalarExpressionVisitor(TSql.ScalarExpression Host, Action<IModel> Observer)
            : base(Host, Observer) {}

        public override void Visit(TSql.Literal node)
            => new LiteralVisitor(node, Observer).Visit();

        public override void Visit(TSql.AtTimeZoneCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.BinaryExpression node)
        {
            base.Visit(node);
        }


        public override void Visit(TSql.CastCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.CoalesceExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ColumnReferenceExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ConvertCall node)
        {
            base.Visit(node);
        }


        public override void Visit(TSql.ExtractFromExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.FunctionCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.GlobalVariableExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.IdentityFunctionCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.IIfCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.LeftFunctionCall node)
        {
            base.Visit(node);
        }


        public override void Visit(TSql.NextValueForExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.NullIfExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.OdbcConvertSpecification node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.OdbcFunctionCall node)
        {
            base.Visit(node);
        }


        public override void Visit(TSql.ParameterlessCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ParenthesisExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ParseCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.PartitionFunctionCall node)
        {
            base.Visit(node);
        }
        public override void Visit(TSql.RightFunctionCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ScalarExpressionSnippet node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.ScalarSubquery node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.SearchedCaseExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.SimpleCaseExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.SourceDeclaration node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.TryCastCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.TryConvertCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.TryParseCall node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.UnaryExpression node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.UserDefinedTypePropertyAccess node)
        {
            base.Visit(node);
        }

        public override void Visit(TSql.VariableReference node)
        {

            base.Visit(node);
        }


    }


}