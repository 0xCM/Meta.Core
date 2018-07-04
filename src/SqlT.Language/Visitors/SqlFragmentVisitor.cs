//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using Meta.Models;
    using SqlT.Syntax;
    using SqlT.Language;
    using SqlT.Models;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sxc = SqlT.Syntax.contracts;

    public class SqlFragmentVisitor : TSql.TSqlFragmentVisitor
    {
        readonly Action<IModel> onSuccess;
        readonly Action<TSql.TSqlFragment> onFailure;
        readonly ISqlGenerationContext GC;

        public SqlFragmentVisitor(ISqlGenerationContext GC, Action<IModel> success, Action<TSql.TSqlFragment> failure)
        {
            this.GC = GC;
            this.onSuccess = success;
            this.onFailure = failure;
        }

        public override void Visit(TSql.RestoreStatement node)
            => node.Model().OnSome(onSuccess).OnNone(() => onFailure(node));

        public override void Visit(TSql.BackupStatement node)
            => GC.Model(node).OnSome(onSuccess).OnNone(() => onFailure(node));

        public override void Visit(TSql.DropIndexStatement node)
            => node.Model().OnSome(onSuccess).OnNone(() => onFailure(node));

        public override void Visit(TSql.CreateIndexStatement node)
            => node.Model().OnSome(onSuccess).OnNone(() => onFailure(node));

        public override void Visit(TSql.DeclareVariableStatement node)
            => node.Model().OnSome(onSuccess).OnNone(() => onFailure(node));
    }
}
