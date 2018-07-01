//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    public class TransformationName : SemanticIdentifier<TransformationName, string>
    {


        public static implicit operator TransformationName(string x)
            => new TransformationName(x);

        protected override TransformationName New(string IdentifierText)
            => new TransformationName(IdentifierText);

        public TransformationName(TransformationName Source, TransformationName Target)
            : base($"{Source}=>{Target}")
        {

        }


        TransformationName()
            : base(string.Empty)
        {

        }

        public TransformationName(string name)
            : base(name)
        {

        }

    }


}