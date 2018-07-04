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

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    abstract class TSqlVisitor<V,H> : TSql.TSqlFragmentVisitor
        where V : TSqlVisitor<V,H>, new()
        where H : TSql.TSqlFragment
    {

        protected TSqlVisitor(H Host, Action<IModel> Observer)
        {
            this.Observer = Observer;
            this.Host = Host;
        }

        protected TSqlVisitor()
        {

        }

        protected Action<IModel> Observer { get; private set; }

        public H Host { get; private set; }

        public void Visit()
            => base.Visit(Host);


        protected void Visit(H Host, Action<IModel> Observer)
        {
            this.Host = Host;
            this.Observer = Observer;
            Visit();
        }

    }

}