//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using static metacore;

    /// <summary>
    /// Identifies a transformation
    /// </summary>
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