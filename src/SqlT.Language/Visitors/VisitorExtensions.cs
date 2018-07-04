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
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;
    using O = System.Action<Meta.Models.IModel>;

    public static class VisitorExtensions
    {
        static ScalarExpressionVisitor Visit(this TSql.ScalarExpression tSql, O Observer)
            => new ScalarExpressionVisitor(tSql, Observer);

        static LiteralVisitor Visit(this TSql.Literal tSql, O Observer)
            => new LiteralVisitor(tSql, Observer);

        static RaiseErrorStatementVisitor Visit(this TSql.RaiseErrorStatement tSql, O Observer)
            => new RaiseErrorStatementVisitor(tSql, Observer);

        static DeclareVariableElementVisitor Visit(this TSql.DeclareVariableElement tSql, O Observer)
            => new DeclareVariableElementVisitor(tSql, Observer);

        static DeclareVariableStatementVisitor Visit(this TSql.DeclareVariableStatement tSql, O Observer)
            => new DeclareVariableStatementVisitor(tSql, Observer);

        static ValueExpressionVisitor Visit(this TSql.ValueExpression tSql, O Observer)
            => new ValueExpressionVisitor(tSql, Observer);

        public static IModel SqlT(this TSql.Literal tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m; }).Visit();
            return model;
        }

        public static IModel SqlT(this TSql.DeclareVariableElement tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m;}).Visit();
            return model;
        }

        public static IModel SqlT(this TSql.DeclareVariableStatement tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m; }).Visit();
            return model;
        }

        public static IModel SqlT(this TSql.ScalarExpression tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m;}).Visit();
            return model;
        }

        public static IModel SqlT(this TSql.RaiseErrorStatement tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m;}).Visit();
            return model;
        }

        public static IModel SqlT(this TSql.ValueExpression tSql)
        {
            var model = default(IModel);
            tSql.Visit(m => { model = m; }).Visit();
            return model;
        }

    }
}