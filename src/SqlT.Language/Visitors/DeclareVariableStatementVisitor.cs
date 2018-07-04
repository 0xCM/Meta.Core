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

    class DeclareVariableStatementVisitor : TSqlVisitor<DeclareVariableStatementVisitor, TSql.DeclareVariableStatement>
    {
        public DeclareVariableStatementVisitor()
        { }

        public DeclareVariableStatementVisitor(TSql.DeclareVariableStatement Host, Action<IModel> Observer)
            : base(Host, Observer){}


        public override void Visit(TSql.DeclareVariableElement node)
            =>  new DeclareVariableElementVisitor(node, Observer).Visit();            
        


    }

}