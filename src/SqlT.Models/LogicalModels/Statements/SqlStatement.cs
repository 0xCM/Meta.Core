//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    using SqlT.Syntax;
    using Meta.Syntax;


    using sxc = Syntax.contracts;

    public abstract class SqlStatement<M> : SqlModel<M>, sxc.statement
        where M : SqlStatement<M>
    {
        protected SqlStatement(IKeyword designator, statement_kind kind)
        {
            this.statement_designator = designator;
        }

        public IKeyword statement_designator { get; }

    }





    




}
