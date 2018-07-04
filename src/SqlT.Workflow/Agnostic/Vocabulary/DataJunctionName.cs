//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    public class DataJunctionName : SemanticIdentifier<DataJunctionName, string>
    {
        public static implicit operator DataJunctionName(string x)
            => new DataJunctionName(x);

        protected override DataJunctionName New(string IdentifierText)
            => new DataJunctionName(IdentifierText);

        DataJunctionName()
            : base(string.Empty)
        {

        }

        public DataJunctionName(string name)
            : base(name)
        {

        }

    }


}