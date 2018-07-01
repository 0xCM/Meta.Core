//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{

    using Meta.Models;


    public class SimpleName : Model<SimpleName>, ISimpleName
    {

        public SimpleName(Identifier Identifier)
        {
            this.Identifier = Identifier;
        }

        public Identifier Identifier { get; }

        public override string ToString()
            => Identifier.ToString();

        public override bool IsEmpty
            => Identifier.IsEmpty;
    }


}