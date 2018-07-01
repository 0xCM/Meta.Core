//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;
    using I = SolutionIdentifier;

    /// <summary>
    /// Identifies, within some context, a <see cref="SolutionModule"/>
    /// </summary>
    public sealed class SolutionIdentifier : SemanticIdentifier<I, string>
    {
        public static implicit operator I(string x) => new I(x);

        protected override I New(string IdentifierText)
            => new I(IdentifierText);

        SolutionIdentifier()
            : base(string.Empty)
        {

        }

        public SolutionIdentifier(string id)
            : base(id)
        {

        }
    }
}