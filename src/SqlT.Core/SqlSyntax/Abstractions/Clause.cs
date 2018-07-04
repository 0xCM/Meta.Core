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


    public abstract class Clause<c> : Model<c>, sxc.clause
        where c : Clause<c>
    {
        protected Clause(IKeyword designator)
        {
            this.designator = KeyPhrase.create(designator);
        }

        protected Clause(KeyPhrase designator)
        {
            this.designator = designator;
        }

        public KeyPhrase designator { get; }

        IKeyphrase sxc.clause.designator
            => designator;

    }
}