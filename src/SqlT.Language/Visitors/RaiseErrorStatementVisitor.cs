//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Syntax;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    
    using sxc = SqlT.Syntax.contracts;
    

    class RaiseErrorStatementVisitor : TSqlVisitor<RaiseErrorStatementVisitor, TSql.RaiseErrorStatement>
    {

        public RaiseErrorStatementVisitor()
        {

        }
        public RaiseErrorStatementVisitor(TSql.RaiseErrorStatement Host, Action<IModel> Observer)
            : base(Host, Observer)
        {

            

        }


        public override void Visit(TSql.RaiseErrorStatement node)
        {
            base.Visit(node);            
        }



    }
}
