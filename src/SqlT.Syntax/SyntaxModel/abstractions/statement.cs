//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using Meta.Models;
    using Meta.Syntax;

    public abstract class statement<s> : Model<s>, sxc.statement
        where s : statement<s>
    {
        protected statement(IKeyword designator)
        {
            this.statement_designator = designator;
        }

        public IKeyword statement_designator { get; }

    }

}